namespace Library.Application.DTOs;

public class BookRecommendationDto
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string? CategoryName { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public double Score { get; set; }
    public List<string> RecommendationReasons { get; set; } = [];
    public bool IsAvailable { get; set; }
    public double? AverageRating { get; set; }
    public int TimesLoaned { get; set; }
}

public class RecommendationRequestDto
{
    public Guid CustomerId { get; set; }
    public int MaxResults { get; set; } = 10;
    public bool OnlyAvailable { get; set; } = true;
    public string? PreferredLanguage { get; set; }
    public Guid? PreferredCategoryId { get; set; }
}

public class CustomerReadingProfileDto
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int TotalBooksRead { get; set; }
    public int TotalReviews { get; set; }
    public double AverageRatingGiven { get; set; }
    public List<CategoryPreferenceDto> TopCategories { get; set; } = [];
    public List<AuthorPreferenceDto> TopAuthors { get; set; } = [];
    public string? MostReadLanguage { get; set; }
    public int ReadingStreakDays { get; set; }
    public string ReadingLevel { get; set; } = "Beginner";
}

public class CategoryPreferenceDto
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int BooksRead { get; set; }
    public double AverageRating { get; set; }
    public double PreferenceScore { get; set; }
}

public class AuthorPreferenceDto
{
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public int BooksRead { get; set; }
    public double AverageRating { get; set; }
}
