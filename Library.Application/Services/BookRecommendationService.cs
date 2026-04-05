using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookRecommendationService : IBookRecommendationService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookLoanRepository _loanRepository;
    private readonly IBookReviewRepository _reviewRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookCategoryRepository _categoryRepository;
    private readonly IAuthorRepository _authorRepository;

    private const double CategoryMatchWeight = 3.0;
    private const double AuthorMatchWeight = 2.5;
    private const double RatingWeight = 2.0;
    private const double PopularityWeight = 1.5;
    private const double LanguageMatchWeight = 1.0;
    private const double RecencyBonus = 0.5;

    public BookRecommendationService(
        IBookRepository bookRepository,
        IBookLoanRepository loanRepository,
        IBookReviewRepository reviewRepository,
        ICustomerRepository customerRepository,
        IBookCategoryRepository categoryRepository,
        IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
        _reviewRepository = reviewRepository;
        _customerRepository = customerRepository;
        _categoryRepository = categoryRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<BookRecommendationDto>> GetRecommendationsAsync(RecommendationRequestDto request)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId)
            ?? throw new NotFoundException(nameof(Customer), request.CustomerId);

        // Build reading profile
        var customerLoans = await _loanRepository.GetByCustomerIdAsync(request.CustomerId);
        var returnedLoans = customerLoans.Where(l => l.Status == LoanStatus.Returned).ToList();
        var customerReviews = await _reviewRepository.GetByCustomerIdAsync(request.CustomerId);

        // Determine preferences
        var readBookIds = customerLoans.Select(l => l.BookId).ToHashSet();
        var categoryScores = BuildCategoryScores(returnedLoans, customerReviews);
        var authorScores = BuildAuthorScores(returnedLoans, customerReviews);
        var preferredLanguage = request.PreferredLanguage ?? DetectPreferredLanguage(returnedLoans);

        // Get candidate books (exclude already read)
        var allBooks = await _bookRepository.GetAllAsync();
        var candidates = allBooks.Where(b => !readBookIds.Contains(b.Id));

        if (request.OnlyAvailable)
            candidates = candidates.Where(b => b.IsAvailable && b.AvailableCopies > 0);

        if (request.PreferredCategoryId.HasValue)
            candidates = candidates.Where(b => b.BookCategoryId == request.PreferredCategoryId.Value);

        // Score each candidate
        var scoredBooks = new List<(Book Book, double Score, List<string> Reasons)>();

        foreach (var book in candidates)
        {
            var score = 0.0;
            var reasons = new List<string>();

            // Category match
            if (book.BookCategoryId.HasValue && categoryScores.TryGetValue(book.BookCategoryId.Value, out var catScore))
            {
                score += catScore * CategoryMatchWeight;
                reasons.Add("Matches your favorite categories");
            }

            // Author match
            if (authorScores.TryGetValue(book.AuthorId, out var authScore))
            {
                score += authScore * AuthorMatchWeight;
                reasons.Add("From an author you enjoy");
            }

            // Average rating
            var avgRating = await _reviewRepository.GetAverageRatingByBookAsync(book.Id);
            if (avgRating > 0)
            {
                score += (avgRating / 5.0) * RatingWeight;
                if (avgRating >= 4.0)
                    reasons.Add($"Highly rated ({avgRating:F1}/5)");
            }

            // Popularity (loan count)
            var bookLoans = await _loanRepository.GetByBookIdAsync(book.Id);
            var loanCount = bookLoans.Count();
            if (loanCount > 0)
            {
                var popularityScore = Math.Min(loanCount / 10.0, 1.0);
                score += popularityScore * PopularityWeight;
                if (loanCount >= 5)
                    reasons.Add($"Popular choice ({loanCount} times borrowed)");
            }

            // Language match
            if (!string.IsNullOrEmpty(preferredLanguage) &&
                book.Language.Equals(preferredLanguage, StringComparison.OrdinalIgnoreCase))
            {
                score += LanguageMatchWeight;
                reasons.Add("In your preferred language");
            }

            // Recency bonus (books published in last 2 years)
            if (book.PublishedYear >= DateTime.UtcNow.Year - 2)
            {
                score += RecencyBonus;
                reasons.Add("Recently published");
            }

            if (reasons.Count == 0)
                reasons.Add("Explore something new");

            scoredBooks.Add((book, score, reasons));
        }

        return scoredBooks
            .OrderByDescending(x => x.Score)
            .Take(request.MaxResults)
            .Select(x => new BookRecommendationDto
            {
                BookId = x.Book.Id,
                Title = x.Book.Title,
                AuthorName = x.Book.Author?.FirstName is not null
                    ? $"{x.Book.Author.FirstName} {x.Book.Author.LastName}"
                    : string.Empty,
                CategoryName = x.Book.BookCategory?.Name,
                ISBN = x.Book.ISBN,
                Score = Math.Round(x.Score, 2),
                RecommendationReasons = x.Reasons,
                IsAvailable = x.Book.IsAvailable,
                AverageRating = null,
                TimesLoaned = 0
            });
    }

    public async Task<CustomerReadingProfileDto> GetReadingProfileAsync(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId)
            ?? throw new NotFoundException(nameof(Customer), customerId);

        var customerLoans = await _loanRepository.GetByCustomerIdAsync(customerId);
        var returnedLoans = customerLoans.Where(l => l.Status == LoanStatus.Returned).ToList();
        var customerReviews = (await _reviewRepository.GetByCustomerIdAsync(customerId)).ToList();

        // Top categories
        var categoryGroups = returnedLoans
            .Where(l => l.Book?.BookCategoryId.HasValue == true)
            .GroupBy(l => l.Book!.BookCategoryId!.Value)
            .ToList();

        var topCategories = new List<CategoryPreferenceDto>();
        foreach (var group in categoryGroups.OrderByDescending(g => g.Count()).Take(5))
        {
            var category = await _categoryRepository.GetByIdAsync(group.Key);
            var categoryBookIds = group.Select(l => l.BookId).ToHashSet();
            var ratingsForCategory = customerReviews
                .Where(r => categoryBookIds.Contains(r.BookId))
                .Select(r => (double)r.Rating)
                .ToList();

            topCategories.Add(new CategoryPreferenceDto
            {
                CategoryId = group.Key,
                CategoryName = category?.Name ?? "Unknown",
                BooksRead = group.Count(),
                AverageRating = ratingsForCategory.Count > 0 ? ratingsForCategory.Average() : 0,
                PreferenceScore = Math.Round(group.Count() * (ratingsForCategory.Count > 0 ? ratingsForCategory.Average() : 3.0), 2)
            });
        }

        // Top authors
        var authorGroups = returnedLoans
            .GroupBy(l => l.Book?.AuthorId ?? Guid.Empty)
            .Where(g => g.Key != Guid.Empty)
            .ToList();

        var topAuthors = new List<AuthorPreferenceDto>();
        foreach (var group in authorGroups.OrderByDescending(g => g.Count()).Take(5))
        {
            var author = await _authorRepository.GetByIdAsync(group.Key);
            var authorBookIds = group.Select(l => l.BookId).ToHashSet();
            var ratingsForAuthor = customerReviews
                .Where(r => authorBookIds.Contains(r.BookId))
                .Select(r => (double)r.Rating)
                .ToList();

            topAuthors.Add(new AuthorPreferenceDto
            {
                AuthorId = group.Key,
                AuthorName = author is not null ? $"{author.FirstName} {author.LastName}" : "Unknown",
                BooksRead = group.Count(),
                AverageRating = ratingsForAuthor.Count > 0 ? Math.Round(ratingsForAuthor.Average(), 1) : 0
            });
        }

        // Reading streak
        var readingStreak = CalculateReadingStreak(returnedLoans);

        // Average rating given
        var avgRatingGiven = customerReviews.Count > 0
            ? Math.Round(customerReviews.Average(r => r.Rating), 1)
            : 0;

        // Reading level
        var readingLevel = ClassifyReadingLevel(returnedLoans.Count, customerReviews.Count, readingStreak);

        return new CustomerReadingProfileDto
        {
            CustomerId = customerId,
            CustomerName = $"{customer.FirstName} {customer.LastName}",
            TotalBooksRead = returnedLoans.Count,
            TotalReviews = customerReviews.Count,
            AverageRatingGiven = avgRatingGiven,
            TopCategories = topCategories,
            TopAuthors = topAuthors,
            MostReadLanguage = DetectPreferredLanguage(returnedLoans),
            ReadingStreakDays = readingStreak,
            ReadingLevel = readingLevel
        };
    }

    public async Task<IEnumerable<BookRecommendationDto>> GetTrendingBooksAsync(int count = 10)
    {
        if (count <= 0) count = 10;
        if (count > 50) count = 50;

        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
        var allLoans = await _loanRepository.GetAllAsync();
        var recentLoans = allLoans.Where(l => l.LoanDate >= thirtyDaysAgo).ToList();

        var bookLoanCounts = recentLoans
            .GroupBy(l => l.BookId)
            .Select(g => new { BookId = g.Key, LoanCount = g.Count() })
            .OrderByDescending(x => x.LoanCount)
            .Take(count)
            .ToList();

        var trending = new List<BookRecommendationDto>();
        foreach (var item in bookLoanCounts)
        {
            var book = await _bookRepository.GetByIdAsync(item.BookId);
            if (book is null) continue;

            var avgRating = await _reviewRepository.GetAverageRatingByBookAsync(item.BookId);

            trending.Add(new BookRecommendationDto
            {
                BookId = book.Id,
                Title = book.Title,
                AuthorName = book.Author is not null
                    ? $"{book.Author.FirstName} {book.Author.LastName}"
                    : string.Empty,
                CategoryName = book.BookCategory?.Name,
                ISBN = book.ISBN,
                Score = Math.Round(item.LoanCount + (avgRating / 5.0) * 2, 2),
                RecommendationReasons = [$"Trending: borrowed {item.LoanCount} times in last 30 days"],
                IsAvailable = book.IsAvailable,
                AverageRating = avgRating > 0 ? Math.Round(avgRating, 1) : null,
                TimesLoaned = item.LoanCount
            });
        }

        return trending;
    }

    public async Task<IEnumerable<BookRecommendationDto>> GetSimilarBooksAsync(Guid bookId, int count = 5)
    {
        var book = await _bookRepository.GetByIdAsync(bookId)
            ?? throw new NotFoundException(nameof(Book), bookId);

        var allBooks = await _bookRepository.GetAllAsync();
        var candidates = allBooks.Where(b => b.Id != bookId).ToList();

        var scoredBooks = new List<(Book Candidate, double Score, List<string> Reasons)>();

        foreach (var candidate in candidates)
        {
            var score = 0.0;
            var reasons = new List<string>();

            // Same category
            if (book.BookCategoryId.HasValue &&
                candidate.BookCategoryId.HasValue &&
                book.BookCategoryId == candidate.BookCategoryId)
            {
                score += 3.0;
                reasons.Add("Same category");
            }

            // Same author
            if (candidate.AuthorId == book.AuthorId)
            {
                score += 4.0;
                reasons.Add("Same author");
            }

            // Same language
            if (candidate.Language.Equals(book.Language, StringComparison.OrdinalIgnoreCase))
            {
                score += 1.0;
                reasons.Add("Same language");
            }

            // Similar page count (within 30%)
            if (book.PageCount > 0 && candidate.PageCount > 0)
            {
                var ratio = (double)candidate.PageCount / book.PageCount;
                if (ratio >= 0.7 && ratio <= 1.3)
                {
                    score += 0.5;
                    reasons.Add("Similar length");
                }
            }

            // Similar publication year (within 5 years)
            if (Math.Abs(candidate.PublishedYear - book.PublishedYear) <= 5)
            {
                score += 0.5;
                reasons.Add("Similar era");
            }

            // Rating bonus
            var avgRating = await _reviewRepository.GetAverageRatingByBookAsync(candidate.Id);
            if (avgRating >= 4.0)
            {
                score += 1.0;
                reasons.Add($"Highly rated ({avgRating:F1}/5)");
            }

            if (score > 0)
                scoredBooks.Add((candidate, score, reasons));
        }

        return scoredBooks
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => new BookRecommendationDto
            {
                BookId = x.Candidate.Id,
                Title = x.Candidate.Title,
                AuthorName = x.Candidate.Author is not null
                    ? $"{x.Candidate.Author.FirstName} {x.Candidate.Author.LastName}"
                    : string.Empty,
                CategoryName = x.Candidate.BookCategory?.Name,
                ISBN = x.Candidate.ISBN,
                Score = Math.Round(x.Score, 2),
                RecommendationReasons = x.Reasons,
                IsAvailable = x.Candidate.IsAvailable,
                AverageRating = null,
                TimesLoaned = 0
            });
    }

    private static Dictionary<Guid, double> BuildCategoryScores(
        List<BookLoan> returnedLoans, IEnumerable<BookReview> reviews)
    {
        var scores = new Dictionary<Guid, double>();
        var reviewLookup = reviews.ToDictionary(r => r.BookId, r => r.Rating);

        foreach (var loan in returnedLoans)
        {
            if (loan.Book?.BookCategoryId is not { } categoryId) continue;

            if (!scores.ContainsKey(categoryId))
                scores[categoryId] = 0;

            var ratingMultiplier = reviewLookup.TryGetValue(loan.BookId, out var rating)
                ? rating / 3.0  // normalize: 3 = neutral, >3 = positive, <3 = negative
                : 1.0;

            scores[categoryId] += ratingMultiplier;
        }

        // Normalize to 0-1
        if (scores.Count > 0)
        {
            var maxScore = scores.Values.Max();
            if (maxScore > 0)
            {
                foreach (var key in scores.Keys.ToList())
                    scores[key] /= maxScore;
            }
        }

        return scores;
    }

    private static Dictionary<Guid, double> BuildAuthorScores(
        List<BookLoan> returnedLoans, IEnumerable<BookReview> reviews)
    {
        var scores = new Dictionary<Guid, double>();
        var reviewLookup = reviews.ToDictionary(r => r.BookId, r => r.Rating);

        foreach (var loan in returnedLoans)
        {
            if (loan.Book is null) continue;
            var authorId = loan.Book.AuthorId;

            if (!scores.ContainsKey(authorId))
                scores[authorId] = 0;

            var ratingMultiplier = reviewLookup.TryGetValue(loan.BookId, out var rating)
                ? rating / 3.0
                : 1.0;

            scores[authorId] += ratingMultiplier;
        }

        if (scores.Count > 0)
        {
            var maxScore = scores.Values.Max();
            if (maxScore > 0)
            {
                foreach (var key in scores.Keys.ToList())
                    scores[key] /= maxScore;
            }
        }

        return scores;
    }

    private static string? DetectPreferredLanguage(List<BookLoan> returnedLoans)
    {
        return returnedLoans
            .Where(l => l.Book is not null && !string.IsNullOrEmpty(l.Book.Language))
            .GroupBy(l => l.Book!.Language)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
    }

    private static int CalculateReadingStreak(List<BookLoan> returnedLoans)
    {
        if (returnedLoans.Count == 0)
            return 0;

        var returnDates = returnedLoans
            .Where(l => l.ReturnDate.HasValue)
            .Select(l => l.ReturnDate!.Value.Date)
            .Distinct()
            .OrderByDescending(d => d)
            .ToList();

        if (returnDates.Count == 0)
            return 0;

        // Count consecutive months with at least one return
        var streak = 0;
        var currentMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

        foreach (var date in returnDates)
        {
            var dateMonth = new DateTime(date.Year, date.Month, 1);
            if (dateMonth == currentMonth || dateMonth == currentMonth.AddMonths(-streak))
            {
                if (dateMonth == currentMonth.AddMonths(-streak))
                    streak++;
            }
            else
            {
                break;
            }
        }

        return streak * 30; // approximate days
    }

    private static string ClassifyReadingLevel(int booksRead, int reviewsGiven, int streakDays)
    {
        var score = booksRead * 2 + reviewsGiven + (streakDays / 30);

        return score switch
        {
            >= 50 => "Bookworm",
            >= 30 => "Avid Reader",
            >= 15 => "Regular Reader",
            >= 5 => "Casual Reader",
            _ => "Beginner"
        };
    }
}
