### Project Overview
- Ad: Library — Amaç: Uygulama katmanında ortak istisna türleri sağlamak. Hedef çatı: Bu dosyadan kesin olarak belirlenemiyor.
- Mimari desen: Adlandırma ve klasör yapısı Clean Architecture’ı ima ediyor; bu dosya Application katmanına ait.
- Projeler/Assembly’ler: `Library.Application` — Uygulama kuralları, istisnalar ve olası iş akışları (bu dosyada yalnızca istisna).
- Harici paketler: Bu dosyadan görünmüyor.
- Konfigürasyon: Bu dosyada konfigürasyon gereksinimi yok.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Exceptions/BadRequestException.cs`

**1. Genel Bakış**
`BadRequestException`, uygulama katmanında hatalı istek senaryolarını temsil eden özel bir istisnadır. İsteğe bağlı olarak alan-bazlı hata mesajlarını taşıyacak `Errors` sözlüğünü içerir. Clean Architecture içinde Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `System.Exception`
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Exceptions`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BadRequestException()` | Varsayılan “Bad request.” mesajıyla oluşturur, `Errors` boş sözlük olur. |
| Ctor | `BadRequestException(string message)` | Özel mesajla oluşturur, `Errors` boş sözlük olur. |
| Ctor | `BadRequestException(string message, IDictionary<string, string[]> errors)` | Mesaj ve alan-bazlı hatalarla oluşturur. |
| Property | `IDictionary<string, string[]> Errors { get; }` | Alan adı–hata listesi eşleşmelerini taşır. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılan mesaj: “Bad request.”
- `Errors`, parametre verilmezse yeni boş `Dictionary<string, string[]>()` ile başlatılır.
- Sağlanan `errors` doğrudan atanır; kopyalama veya doğrulama yapılmaz.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod yalnızca Application katmanında özel bir istisna türü içeriyor; başka katman veya bileşenler görünmüyor.
- Hata sözlüğü için doğrulama/kopyalama yapılmaması, dışarıdan verilen sözlüğün dışsal değişikliklere açık kalmasına neden olabilir.### Project Overview
Proje adı: Library. Amaç: uygulama katmanında alan mantığına özgü özel istisnaları tanımlamak. Hedef çatı bu dosyadan anlaşılmıyor. Mimari desen adlandırmalara göre Clean Architecture izlenimi veriyor; doğrulama bu dosyadan yapılamıyor. Keşfedilen proje/assembly: Library.Application — uygulama kuralları, istisnalar ve iş akışları. Harici paketler bu dosyadan görünmüyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
(İsimler ve akış, namespace’lere göre çıkarımsal)
Library.API (varsayım)
  ↓
Library.Application
  ↓
Library.Domain (varsayım)

Library.Infrastructure (varsayım)
  ↙ depends on Domain & Application (typical Clean Architecture)

---
### `Library.Application/Common/Exceptions/ConflictException.cs`

**1. Genel Bakış**
`ConflictException`, uygulama katmanında çakışma/uyuşmazlık durumlarını (ör. eşzamanlılık, benzersizlik ihlali) belirtmek için tanımlanmış özel bir istisnadır. Mimari olarak Application katmanına aittir ve üst katmanlara alan-odaklı, anlamlı hata bildirimleri sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `System.Exception`
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Exceptions`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public ConflictException()` | Varsayılan mesaj olmadan istisna oluşturur. |
| Ctor | `public ConflictException(string message)` | Özel bir mesajla istisna oluşturur. |
| Ctor | `public ConflictException(string message, Exception innerException)` | Mesaj ve iç istisna ile sarmal istisna oluşturur. |

**5. Temel Davranışlar ve İş Kuralları**
- .NET `Exception` taban sınıfının standart davranışlarını devralır.
- İş kuralları: Çakışma durumlarını semantik olarak belirtmek için kullanılır; ek mantık içermez.

**Mantık içermeyen basit DTO/model'ler için** bu bölümü şu şekilde değiştir:
> DTO — davranış yok. Default değerler: [önemli default'ları listele, ör. `IsAvailable = true`, `string.Empty` başlangıç değerleri].

**6. Bağlantılar**
- **Yukarı akış:** Application içindeki komut/sorgu işleyicileri veya servisler tarafından fırlatılır (genel kullanım).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Diğer özel istisnalar (bu depoda görünmüyor).

Genel Değerlendirme
- Sınıf amacına uygun, yalın ve .NET istisna kalıplarıyla uyumlu.
- Proje yapısı Clean Architecture izlenimi verse de diğer katmanlar ve bağımlılıklar bu dosyadan teyit edilemiyor. Ek dosyalarla doğrulama önerilir.### Project Overview
Proje adı: Library. Amaç: uygulama katmanında alan genelindeki özel istisnaları tanımlamak ve kullanmak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari desen: namespace yapısı Clean Architecture/N‑Katman işaretleri gösteriyor; bu dosyadan yalnızca Application katmanı görülebiliyor. Keşfedilen proje/assembly: Library.Application — uygulama kuralları, istisnalar. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/Common/Exceptions/NotFoundException.cs`

**1. Genel Bakış**
`NotFoundException`, aranan bir varlık/ kayıt bulunamadığında atılan uygulama düzeyi özel istisnadır. Uygulama (Application) katmanında, özellikle komut/sorgu işleyicileri veya servislerde akış kontrolü ve hata iletimi için kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `System.Exception`
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Exceptions`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public NotFoundException()` | Varsayılan istisna oluşturur. |
| Ctor | `public NotFoundException(string message)` | Özel mesajla istisna oluşturur. |
| Ctor | `public NotFoundException(string message, Exception innerException)` | İç istisna ile zincirleme istisna oluşturur. |
| Ctor | `public NotFoundException(string entityName, object key)` | Varlık adı ve anahtar bilgisiyle standart “not found” mesajı üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `entityName` ve `key` alan kurucu, mesajı `"Entity \"{entityName}\" ({key}) was not found."` biçiminde üretir.
- Ek validasyon veya yan etki yok; saf istisna sarmalayıcıdır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece `Library.Application` katmanından bir dosya görülebiliyor; başka katmanlar ve akışlar bu repo kesitinden anlaşılamıyor.
- Hedef çatı, paketler ve konfigürasyon anahtarları belirlenemiyor.
- İstisna mesajı standart ve tutarlı; domain-özel kodlar için yeterli ancak lokalizasyon ihtiyacı varsa genişletme gerekebilir.### Project Overview
Proje adı “Library” olarak görünüyor; bu dosya `Application` katmanına ait ortak bir model içeriyor. Amaç, istek/işlem sonuçlarını tutarlı bir yanıt yapısında taşımak. Hedef çatı veya .NET sürümü bu dosyadan anlaşılmıyor. Mimari, `Application` katmanı izlerine dayanarak muhtemelen katmanlı/temiz mimari yaklaşımına uygun. Keşfedilen proje/assembly: `Library.Application` — uygulama katmanı ortak modelleri. Harici paket kullanımı ve konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Models/ApiResponse.cs`

**1. Genel Bakış**
`ApiResponse<T>` işlem sonuçlarını standartlaştırmak için kullanılan generic bir yanıt sarmalayıcıdır. Başarı bilgisi, veri içeriği, mesaj ve doğrulama hatalarını tek tipte taşır. Mimari olarak Application katmanında “ortak model” rolündedir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Models`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Success | `public bool Success { get; set; }` | İşlemin başarılı olup olmadığını belirtir. |
| Data | `public T? Data { get; set; }` | Başarılı sonuç verisini taşır. |
| Message | `public string? Message { get; set; }` | Bilgi veya hata mesajını içerir. |
| Errors | `public IDictionary<string, string[]>? Errors { get; set; }` | Alan bazlı hata listelerini taşır. |
| SuccessResponse | `public static ApiResponse<T> SuccessResponse(T data, string? message = null)` | Başarılı yanıt örneği üretir. |
| FailResponse | `public static ApiResponse<T> FailResponse(string message, IDictionary<string, string[]>? errors = null)` | Başarısız yanıt örneği üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `SuccessResponse` `Success = true`, `Data = data`, `Message = message` olarak ayarlar.
- `FailResponse` `Success = false`, `Message = message`, `Errors = errors` olarak ayarlar.
- `Data`, `Message` ve `Errors` null olabilir; `T` nullable desteklenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Generic `T` (taşınan veri tipi).

**7. Eksikler ve Gözlemler**
- Tüm property’lerin public setter’a sahip olması, fabrika metotlarıyla kurulan durumun sonradan tutarsız biçimde değiştirilebilmesine izin verir.

---

Genel Değerlendirme
- Sadece `Application` katmanında bir ortak yanıt modeli görülüyor; diğer katmanlar ve bağımlılıklar bu koddan çıkarılamıyor.
- Yanıt tipinin sade ve yeniden kullanılabilir olması olumlu; ancak immutability veya private setter ile durum bütünlüğü daha sıkı korunabilir.### Project Overview
Proje adı: Library. Amaç: uygulama katmanında sayfalama sonuçlarını temsil eden ortak bir model sağlamak. Hedef framework bu dosyadan anlaşılamıyor. Mimari düzen, ad alanına göre katmanlı/Clean Architecture tarzında “Application” katmanını işaret ediyor. Keşfedilen proje/assembly: Library.Application — uygulama mantığına ait DTO/Modeller. Harici paket kullanımı bu dosyadan anlaşılamıyor. Konfigürasyon gereksinimi yok.

### Architecture Diagram
Library.Application

---
### `Library.Application/Common/Models/PagedResult.cs`

**1. Genel Bakış**
Uygulama katmanı için generik sayfalama modelidir; veri koleksiyonunu ve sayfalama metadatasını taşır. Sorgu sonuçlarını UI veya API katmanına standart bir şekilde iletmek için kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Models`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Items | `public IEnumerable<T> Items { get; set; }` | Sayfalı sonuçtaki öğeler koleksiyonu; varsayılan boş dizidir. |
| TotalCount | `public int TotalCount { get; set; }` | Toplam öğe sayısı. |
| PageNumber | `public int PageNumber { get; set; }` | Mevcut sayfa numarası (1 tabanlı varsayım). |
| PageSize | `public int PageSize { get; set; }` | Sayfa başına öğe sayısı. |
| TotalPages | `public int TotalPages { get; }` | `TotalCount` ve `PageSize`’e göre toplam sayfa sayısı (tavana yuvarlanır). |
| HasPreviousPage | `public bool HasPreviousPage { get; }` | Mevcut sayfanın öncesi olup olmadığını belirtir. |
| HasNextPage | `public bool HasNextPage { get; }` | Mevcut sayfanın sonrası olup olmadığını belirtir. |

**5. Temel Davranışlar ve İş Kuralları**
- `TotalPages = Ceiling(TotalCount / (double)PageSize)`; `PageSize` 0 ise çalışma zamanı hatasına yol açabilir (sonsuzluk/taşma riski).
- `HasPreviousPage` yalnızca `PageNumber > 1` ise true.
- `HasNextPage` yalnızca `PageNumber < TotalPages` ise true.
- `Items` varsayılanı boş koleksiyondur; null yerine boş dönüş sağlar.

**6. Bağlantılar**
- **Yukarı akış:** Sorgu/handler’lar, servisler veya controller’lar kullanır (bu dosyadan kesin değil).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Generik `T` ile liste öğeleri; başka tipler bu dosyadan anlaşılamıyor.

Genel Değerlendirme
- Sadece Application katmanı keşfedildi; diğer katmanlar bu depodan anlaşılamıyor.
- `PageSize` için koruyucu doğrulama yok; 0 değerine karşı kullanım yerlerinde dikkat gerektirir.
- Hedef framework ve paket bağımlılıkları görünmüyor; proje yapılandırması hakkında çıkarım yapılamıyor.### Project Overview
Proje adı: Library. Amaç: uygulama katmanında sayfalama ve sıralama parametrelerini temsil eden ortak model sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Clean Architecture eğilimli; `Application` katmanı içinde `Common/Models` altında yer alan bir DTO bulunmaktadır. Keşfedilen proje/assembly: Library.Application — Uygulama iş kuralları ve ortak modeller. Dış paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  └─ Common.Models

---
### `Library.Application/Common/Models/PaginationParams.cs`

**1. Genel Bakış**
`PaginationParams`, istek bazlı sayfalama ve sıralama gereksinimleri için kullanılan basit bir parametre DTO’sudur. Uygulamanın Application katmanındaki sorgu/komut işleyicileri veya API uçları tarafından tüketilmek üzere tasarlanmıştır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Models`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Varsayılan Oluşturucu | `PaginationParams()` | Varsayılan değerlerle örnekleme yapar. |
| PageNumber | `int PageNumber { get; set; }` | 1 tabanlı sayfa numarası; varsayılan 1. |
| PageSize | `int PageSize { get; set; }` | Sayfa büyüklüğü; üst sınır 100, varsayılan 10. |
| SortBy | `string? SortBy { get; set; }` | Sıralanacak alan adı (opsiyonel). |
| SortDescending | `bool SortDescending { get; set; }` | Azalan sıralama için true. |

**5. Temel Davranışlar ve İş Kuralları**
- `PageSize` değeri 100’ü aşarsa otomatik olarak 100’e kırpılır.
- Varsayılanlar: `PageNumber = 1`, `PageSize = 10`, `SortBy = null`, `SortDescending = false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod sadece Application katmanında bir DTO sunuyor; diğer katmanlar (Domain, Infrastructure, API) bu depoda görünmüyor.
- Hedef framework, dış bağımlılıklar ve konfigürasyon anahtarları tespit edilemiyor.
- `PageNumber` için negatif/0 kontrolü yok; ihtiyaç varsa validasyon üst katmanda ele alınmalıdır.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait uygulama katmanında veri taşıma nesneleri (DTO) sağlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor). Mimari: katmanlı (en az “Application” katmanı mevcut). Bu katman, API veya servisler ile domain/infrastructure arasında veri sözleşmeleri sağlar. Bulunan proje/assembly: Library.Application — Application katmanı DTO’ları barındırır. Harici paketler ve konfigürasyon anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
(başka katman bağımlılığı bu dosyadan çıkarılamıyor)

---
### `Library.Application/DTOs/AuthorDtos.cs`

**1. Genel Bakış**
Yazar varlıklarına ilişkin veri alışverişini standartlaştıran üç DTO tanımlar: `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`. Application katmanında, API veya servis sözleşmelerinde kullanılır; mapping işlemlerinde kaynak/hedef model olarak görev yapar.

**2. Tip Bilgisi**
- **Tip:** class (`AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AuthorDto.Id | `Guid Id { get; set; }` | Yazarın benzersiz kimliği. |
| AuthorDto.FirstName | `string FirstName { get; set; }` | Yazarın adı. |
| AuthorDto.LastName | `string LastName { get; set; }` | Yazarın soyadı. |
| AuthorDto.Biography | `string? Biography { get; set; }` | Kısa biyografi. |
| AuthorDto.BirthDate | `DateTime? BirthDate { get; set; }` | Doğum tarihi. |
| AuthorDto.Nationality | `string? Nationality { get; set; }` | Uyruk. |
| AuthorDto.Website | `string? Website { get; set; }` | Web sitesi URL’si. |
| AuthorDto.BookCount | `int BookCount { get; set; }` | Yayımlanan kitap sayısı. |
| CreateAuthorDto.FirstName | `string FirstName { get; set; }` | Ad (oluşturma). |
| CreateAuthorDto.LastName | `string LastName { get; set; }` | Soyad (oluşturma). |
| CreateAuthorDto.Biography | `string? Biography { get; set; }` | Biyografi (oluşturma). |
| CreateAuthorDto.BirthDate | `DateTime? BirthDate { get; set; }` | Doğum tarihi (oluşturma). |
| CreateAuthorDto.DeathDate | `DateTime? DeathDate { get; set; }` | Ölüm tarihi (oluşturma). |
| CreateAuthorDto.Nationality | `string? Nationality { get; set; }` | Uyruk (oluşturma). |
| CreateAuthorDto.Website | `string? Website { get; set; }` | Web sitesi (oluşturma). |
| UpdateAuthorDto.FirstName | `string FirstName { get; set; }` | Ad (güncelleme). |
| UpdateAuthorDto.LastName | `string LastName { get; set; }` | Soyad (güncelleme). |
| UpdateAuthorDto.Biography | `string? Biography { get; set; }` | Biyografi (güncelleme). |
| UpdateAuthorDto.BirthDate | `DateTime? BirthDate { get; set; }` | Doğum tarihi (güncelleme). |
| UpdateAuthorDto.DeathDate | `DateTime? DeathDate { get; set; }` | Ölüm tarihi (güncelleme). |
| UpdateAuthorDto.Nationality | `string? Nationality { get; set; }` | Uyruk (güncelleme). |
| UpdateAuthorDto.Website | `string? Website { get; set; }` | Web sitesi (güncelleme). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`; diğer referans tipleri `null` başlatılabilir (nullable işaretli). `BookCount` için default `0`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Muhtemel `Author` entity’si ve mapping profilleri (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Sadece DTO’lar mevcut; domain, infrastructure veya API katmanlarına dair görünür referans yok.
- Doğrulama öznitelikleri veya explicit validation kuralları tanımlı değil; bu gereksinimler varsa ayrı katmanda ele alınmalıdır.
- Nullability bilinçli kullanılmış (`string?`, `DateTime?`), ancak zorunlu alanları teyit eden kurallar görünmüyor.### Project Overview
Proje adı: Library. Amaç: kitap kategorilerine yönelik veri transferini temsil eden Application katmanı DTO’su sağlamak. Hedef çatı bu dosyadan anlaşılmıyor. Mimari, katmanlı bir yapı izlenimine sahiptir; burada yalnızca Application katmanı görülmektedir. Keşfedilen proje/assembly: Library.Application — uygulama mantığına ait sözleşmeler/DTO’lar. Görünen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  [tek katman görünür; başka bağımlılık akışı bu dosyadan anlaşılmıyor]

---
### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisine ait temel verileri (Id, Name, Description) taşımak için kullanılan basit bir DTO’dur. Application katmanında istek/yanıt veya servis sınırları arasında veri aktarımı amacıyla yer alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kategori benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategori adı. Varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. Varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Application katmanına ait bir DTO görülebiliyor; diğer katmanlar ve akışlar bu repo kesitinde görünmüyor.
- Doğrulama ve iş kuralları DTO dışında ele alınmalıdır; bu dosyada bulunmuyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki varlıkları (örn. kitap) uygulama katmanında taşımak için DTO’lar sağlamak. Hedef çatı: bu dosyadan kesin belirlenemiyor. Mimari: katmanlı/Clean Architecture eğilimli; `Application` katmanı `Domain` tiplerine (enum) referans veriyor. Keşfedilen projeler/assembly’ler: `Library.Application` (DTO’lar, uygulama sözleşmeleri), `Library.Domain` (temel türler/enumerations). Dış bağımlılıklar: bu dosyadan görünmüyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitap bilgisini uygulama ile sunum katmanları arasında taşımak için kullanılan veri transfer nesnesidir. Mimari olarak Application katmanına aittir ve `Library.Domain.Enums.BookCondition` ile kitap durumunu taşır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kitabın benzersiz kimliği. |
| Title | `public string Title { get; set; } = string.Empty;` | Kitap başlığı. |
| ISBN | `public string ISBN { get; set; } = string.Empty;` | ISBN numarası. |
| Description | `public string Description { get; set; } = string.Empty;` | Kitap açıklaması. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `public int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `public string Language { get; set; } = string.Empty;` | Dil bilgisi. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcutluk durumu. |
| TotalCopies | `public int TotalCopies { get; set; }` | Toplam kopya. |
| AvailableCopies | `public int AvailableCopies { get; set; }` | Mevcut kopya. |
| Condition | `public BookCondition Condition { get; set; }` | Fiziksel durum. |
| Price | `public decimal? Price { get; set; }` | Fiyat (opsiyonel). |
| AuthorId | `public Guid AuthorId { get; set; }` | Yazar kimliği. |
| AuthorName | `public string AuthorName { get; set; } = string.Empty;` | Yazar adı. |
| PublisherId | `public Guid? PublisherId { get; set; }` | Yayıncı kimliği (opsiyonel). |
| PublisherName | `public string? PublisherName { get; set; }` | Yayıncı adı (opsiyonel). |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | Kategori adı (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Şube kimliği (opsiyonel). |
| LibraryBranchName | `public string? LibraryBranchName { get; set; }` | Şube adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title`, `ISBN`, `Description`, `Language`, `AuthorName` için `string.Empty`; `IsAvailable = false`; nullable alanlar `Price`, `PublisherId`, `PublisherName`, `BookCategoryId`, `BookCategoryName`, `LibraryBranchId`, `LibraryBranchName` varsayılan `null`; sayısal türler 0; `Guid` varsayılan boş `Guid`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.BookCondition`
- **İlişkili tipler:** `BookCondition` enum’u.

Genel Değerlendirme
- Kod, Clean Architecture yönelimini işaret ediyor (`Application` -> `Domain` bağımlılığı). Ancak yalnızca bir DTO bulundu; komut/sorgu işleyicileri, servisler veya haritalama profilleri görünmüyor.
- Hedef framework, konfigürasyon ve dış paket kullanımı bu örnekten belirlenemiyor.
- DTO alanları geniş; performans ve veri taşımı gereksinimlerine göre daha küçük görünüm modellerine ayrıştırma değerlendirilebilir.### Project Overview
Proje adı: Library (tahmin). Amaç: kütüphane ödünç alma süreçleri için uygulama ve etkileşim DTO’ları sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Clean Architecture tarzı katmanlama; `Library.Application` katmanı `Library.Domain` tiplerine (örn. `LoanStatus`) referans veriyor. Keşfedilen projeler: `Library.Application` (use case/DTO katmanı), `Library.Domain` (enum’lar ve muhtemel domain modelleri). Görünen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/DTOs/BookLoanDtos.cs`

**1. Genel Bakış**
Kütüphane ödünç verme akışları için istek/yanıt DTO’larını tanımlar (`BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`). Uygulama katmanına aittir ve presentation ile domain arasında veri taşıma amacı güder.

**2. Tip Bilgisi**
- Tip: `class` (4 adet DTO)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
- `LoanStatus` — `Library.Domain.Enums` içindeki ödünç durumunu temsil eder.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookLoanDto | `class BookLoanDto` | Ödünç kayıtlarının dışa aktarım görünümü. |
| Id | `Guid Id { get; set; }` | Ödünç işlem kimliği. |
| BookId | `Guid BookId { get; set; }` | Kitap kimliği. |
| BookTitle | `string BookTitle { get; set; }` | Kitap adı. |
| BookISBN | `string BookISBN { get; set; }` | Kitap ISBN’i. |
| CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CustomerName | `string CustomerName { get; set; }` | Müşteri adı. |
| ProcessedByStaffId | `Guid? ProcessedByStaffId { get; set; }` | İşlemi yapan personel. |
| ProcessedByStaffName | `string? ProcessedByStaffName { get; set; }` | Personel adı. |
| LoanDate | `DateTime LoanDate { get; set; }` | Ödünç alma tarihi. |
| DueDate | `DateTime DueDate { get; set; }` | Son iade tarihi. |
| ReturnDate | `DateTime? ReturnDate { get; set; }` | İade tarihi. |
| Status | `LoanStatus Status { get; set; }` | Ödünç durumu. |
| Notes | `string? Notes { get; set; }` | Notlar. |
| RenewalCount | `int RenewalCount { get; set; }` | Yenileme sayısı. |
| MaxRenewals | `int MaxRenewals { get; set; }` | Maksimum yenileme. |
| IsOverdue | `bool IsOverdue { get; set; }` | Gecikme bayrağı. |
| CreateBookLoanDto | `class CreateBookLoanDto` | Ödünç başlatma isteği. |
| BookId | `Guid BookId { get; set; }` | Kitap kimliği. |
| CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| ProcessedByStaffId | `Guid? ProcessedByStaffId { get; set; }` | Personel kimliği. |
| LoanDurationDays | `int LoanDurationDays { get; set; }` | Ödünç süresi (gün). |
| Notes | `string? Notes { get; set; }` | Notlar. |
| ReturnBookLoanDto | `class ReturnBookLoanDto` | İade isteği. |
| Notes | `string? Notes { get; set; }` | Notlar. |
| RenewBookLoanDto | `class RenewBookLoanDto` | Yenileme isteği. |
| AdditionalDays | `int AdditionalDays { get; set; }` | Ek gün sayısı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `BookTitle = string.Empty`, `BookISBN = string.Empty`, `CustomerName = string.Empty`, `LoanDurationDays = 14`, `AdditionalDays = 14`, `IsOverdue = false`.

**6. Bağlantılar**
- Yukarı akış: Uygulama servisleri/handler’ları ve API katmanı bu DTO’ları kullanır (bu dosyadan detay anlaşılmıyor).
- Aşağı akış: `Library.Domain.Enums.LoanStatus`.
- İlişkili tipler: `LoanStatus`.

Genel Değerlendirme
- Sadece DTO’lar mevcut; doğrulama öznitelikleri veya sözleşme düzeyi kurallar görünmüyor.
- Mimari iz: Application -> Domain bağımlılığı net; ancak Infrastructure/Presentation katmanları bu dosyadan çıkarılamıyor.### Project Overview
- Proje adı: Library (uygulama ve domain ad alanlarından çıkarım)
- Amaç: Kütüphanede kitap rezervasyonlarını temsil eden DTO’lar üzerinden istek/yanıt aktarımı.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture eğilimli; `Library.Domain` (iş kuralları/enums) ve `Library.Application` (DTO’lar, olası CQRS/servis sözleşmeleri).
- Projeler/Assembly’ler:
  - Library.Domain — Temel iş kavramları ve `Enums`.
  - Library.Application — Uygulama katmanı DTO’ları.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] <- [Library.Application]

---
### `Library.Application/DTOs/BookReservationDtos.cs`

**1. Genel Bakış**
Rezervasyon verilerinin taşınması için iki DTO sağlar: `BookReservationDto` görüntüleme/yanıt; `CreateBookReservationDto` oluşturma isteği. Application katmanına aittir ve domain’deki `ReservationStatus` enum’unu kullanır.

**2. Tip Bilgisi**
- Tip: class (`BookReservationDto`), class (`CreateBookReservationDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Rezervasyon benzersiz kimliği. |
| BookId | `public Guid BookId { get; set; }` | İlgili kitabın kimliği. |
| BookTitle | `public string BookTitle { get; set; }` | Kitap başlığı. |
| CustomerId | `public Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CustomerName | `public string CustomerName { get; set; }` | Müşteri adı. |
| ReservationDate | `public DateTime ReservationDate { get; set; }` | Rezervasyon tarihi. |
| ExpiryDate | `public DateTime ExpiryDate { get; set; }` | Geçerlilik bitiş tarihi. |
| Status | `public ReservationStatus Status { get; set; }` | Rezervasyon durumu (enum). |
| QueuePosition | `public int QueuePosition { get; set; }` | Kuyruk sırası. |
| BookId | `public Guid BookId { get; set; }` | Oluşturma için kitap kimliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Oluşturma için müşteri kimliği. |
| Notes | `public string? Notes { get; set; }` | İsteğe bağlı not. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `BookTitle = string.Empty`, `CustomerName = string.Empty`; diğer referans tipleri `null`/default, değer tipleri `default(T)`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Enums.ReservationStatus`.
- İlişkili tipler: `ReservationStatus` (enum).

Genel Değerlendirme
- Katman ayrımı net: Application DTO’ları Domain enum’unu referans alıyor.
- Sadece DTO’lar bulundu; iş kuralları, persistence veya API katmanlarına dair kod görünmüyor.
- Validasyon kuralları/kısıtlar DTO seviyesinde yok; muhtemelen başka katmanlarda ele alınmalı.### Project Overview
Proje adı: Library. Amaç: Kitap incelemeleri için uygulama katmanında kullanılan DTO’ları tanımlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli; bu dosya Application katmanına ait. Keşfedilen proje/assembly: Library.Application — uygulama servisleri/iş akışları için veri aktarım nesneleri. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
↑/↓ diğer katmanlar: bu dosyadan anlaşılmıyor

---
### `Library.Application/DTOs/BookReviewDtos.cs`

**1. Genel Bakış**
Kitap incelemeleri için veri alışverişini sağlayan üç DTO (`BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`) içerir. Application katmanında istek/yanıt modellemesi ve komut/sorgu işleyicileriyle veri taşımak için kullanılır.

**2. Tip Bilgisi**
- Tip: class — `BookReviewDto`; Miras: Yok; Uygular: Yok; Namespace: `Library.Application.DTOs`
- Tip: class — `CreateBookReviewDto`; Miras: Yok; Uygular: Yok; Namespace: `Library.Application.DTOs`
- Tip: class — `UpdateBookReviewDto`; Miras: Yok; Uygular: Yok; Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookReviewDto.Id | `Guid Id { get; set; }` | İncelemenin kimliği. |
| BookReviewDto.BookId | `Guid BookId { get; set; }` | İlgili kitabın kimliği. |
| BookReviewDto.BookTitle | `string BookTitle { get; set; }` | Kitap başlığı. |
| BookReviewDto.CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| BookReviewDto.CustomerName | `string CustomerName { get; set; }` | Müşteri adı. |
| BookReviewDto.Rating | `int Rating { get; set; }` | Puan. |
| BookReviewDto.Title | `string? Title { get; set; }` | Başlık (opsiyonel). |
| BookReviewDto.Comment | `string? Comment { get; set; }` | Yorum (opsiyonel). |
| BookReviewDto.IsApproved | `bool IsApproved { get; set; }` | Onay durumu. |
| BookReviewDto.CreatedAt | `DateTime CreatedAt { get; set; }` | Oluşturulma zamanı. |
| CreateBookReviewDto.BookId | `Guid BookId { get; set; }` | Kitap kimliği. |
| CreateBookReviewDto.CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CreateBookReviewDto.Rating | `int Rating { get; set; }` | Puan. |
| CreateBookReviewDto.Title | `string? Title { get; set; }` | Başlık. |
| CreateBookReviewDto.Comment | `string? Comment { get; set; }` | Yorum. |
| UpdateBookReviewDto.Rating | `int Rating { get; set; }` | Puan güncelleme. |
| UpdateBookReviewDto.Title | `string? Title { get; set; }` | Başlık güncelleme. |
| UpdateBookReviewDto.Comment | `string? Comment { get; set; }` | Yorum güncelleme. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `BookReviewDto.BookTitle = string.Empty`, `BookReviewDto.CustomerName = string.Empty`. Diğerleri .NET default’ları veya null.

**6. Bağlantılar**
- Yukarı akış: bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Muhtemelen bir `Book`, `Customer`, ve `BookReview` entity’si; bu dosyadan kesin değil.

Genel Değerlendirme
Sadece DTO tanımları mevcut; doğrulama öznitelikleri veya sözleşmeler (ör. `FluentValidation`, `DataAnnotations`) görünmüyor. Mimari ve diğer katmanlara ilişkin çıkarımlar bu dosyadan yapılmıyor.### Project Overview
Proje adı: Library (namespace’lerden çıkarım). Amaç: kitap/kategori gibi varlıklar için uygulama katmanında veri taşıma nesneleri sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli yapı (en azından `Application` katmanı mevcut). Keşfedilen proje/derleme: Library.Application — uygulama sözleşmeleri/DTO’ları. Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
^
[muhtemel üst katmanlar: API/Handlers/Services — bu dosyadan kesin değil]

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, kitap kategorisi oluşturma senaryosu için istemciden gelen veriyi taşır. Uygulama (Application) katmanına aittir ve komut/handler veya API endpoint’lerine giriş modeli olarak kullanılması amaçlanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| `Name` | `public string Name { get; set; }` | Kategori adı. |
| `Description` | `public string Description { get; set; }` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Create operasyonlarını kabul eden API endpoint’leri veya uygulama komut/handler’ları (spesifik çağırıcı bu dosyadan anlaşılmıyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemel `BookCategory` domain entity/komutları (bu dosyadan kesin değil).

Genel Değerlendirme
- Sadece Application katmanında bir DTO görülebiliyor; diğer katmanlar, hedef framework, paketler ve konfigürasyonlar bu dosyadan çıkarılamıyor.
- Validasyon kuralları (ör. `Name` zorunluluğu/uzunluk) tip içinde tanımlı değil; bu kuralların başka bir katmanda ele alınması gerekir.### Project Overview
Proje adı: Library (tahmin edilen ad alanından). Amaç: Kitap oluşturma senaryosu için uygulama katmanında DTO sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen büyük olasılıkla katmanlı/Clean benzeri; bu dosya Application katmanındaki DTO’yu gösteriyor. Keşfedilen proje/assembly: Library.Application — uygulama sözleşmeleri/DTO’lar. Harici paket kullanımı bu dosyadan anlaşılmıyor. Yapılandırma gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Caller (belirsiz)] -> Library.Application (DTOs)

---
### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
Kitap oluşturma işlemi için istemciden gelen verileri taşımaya yönelik bir DTO’dur. Uygulama katmanına aittir ve komut/işlem işleyicilerine girdi modeli sağlamayı amaçlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Title | `public string Title { get; set; }` | Kitap başlığı. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. |
| Description | `public string Description { get; set; }` | Kitap açıklaması. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `public int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `public string Language { get; set; }` | Dil. |
| TotalCopies | `public int TotalCopies { get; set; }` | Toplam kopya adedi. |
| Price | `public decimal? Price { get; set; }` | Fiyat (opsiyonel). |
| AuthorId | `public Guid AuthorId { get; set; }` | Yazar kimliği. |
| PublisherId | `public Guid? PublisherId { get; set; }` | Yayıncı kimliği (opsiyonel). |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Şube kimliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `ISBN = string.Empty`, `Description = string.Empty`, `Language = "Turkish"`, `TotalCopies = 1`, `Price = null`, `PublishedYear = 0`, `PageCount = 0`, `AuthorId = default`, `PublisherId = null`, `BookCategoryId = null`, `LibraryBranchId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Gerekli alanlara ilişkin validasyon/annotasyonlar yok (ör. `Title`, `ISBN`, `AuthorId` için zorunluluk kuralları belirtilmemiş).

Genel Değerlendirme
Kod tabanı hakkında yalnızca Application katmanındaki bir DTO görülebiliyor; mimari ve bağımlılıklar hakkında sınırlı görünürlük var. Veri bütünlüğü için DTO düzeyinde veya işleyicilerde validasyon stratejisi tanımlanması önerilir (ör. FluentValidation veya data annotations).### Project Overview
Proje adı: Library. Amaç: müşteri oluşturma verilerini Application katmanında taşımak; Domain katmanındaki enum’larla uyumlu veri girişini sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Clean Architecture/N‑Katmanlı yaklaşım; Application, Domain’a bağımlı. Keşfedilen projeler: Library.Application (DTO’lar, uygulama mantığı kontratları) ve Library.Domain (enum/temel tipler). Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.API/Presentation → Library.Application → Library.Domain

---
### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, yeni bir müşteri oluşturma talebinde gerekli alanları taşıyan bir veri transfer nesnesidir. Application katmanına aittir ve Domain katmanındaki `MembershipType` enum’unu referans alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.MembershipType` — Üyelik tipini temsil eder.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres bilgisi. |
| City | `public string City { get; set; }` | Şehir bilgisi. |
| PostalCode | `public string? PostalCode { get; set; }` | Opsiyonel posta kodu. |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik türü (varsayılan `Basic`). |
| DateOfBirth | `public DateTime? DateOfBirth { get; set; }` | Opsiyonel doğum tarihi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `PostalCode = null`, `MembershipType = MembershipType.Basic`, `DateOfBirth = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.MembershipType`
- **İlişkili tipler:** `MembershipType` (Domain)

Genel Değerlendirme
- Hedef framework, dış bağımlılıklar ve konfigürasyon anahtarları bu koddan belirlenemiyor.
- Sadece bir DTO bulundu; doğrulama kuralları veya iş mantığı başka katmanlarda olmalı. Bu dosyadan API/komut işleyicileri veya kalıcılık katmanı görülmüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane personel yönetimi için uygulama katmanında DTO sağlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli; `Application` katmanı `Domain` tiplerine referans veriyor. Keşfedilen projeler: `Library.Application` (DTO ve uygulama sözleşmeleri), `Library.Domain` (enum’lar ve alan modelleri). Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API → Library.Application → Library.Domain

---
### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
Yeni bir personel oluşturma isteği için veri taşıma nesnesidir. Uygulama katmanında yer alır ve API/komut işleyicilerine giriş modeli sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.StaffRole` — Personelin rolünü temsil eden domain enum’u

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | İletişim e-postası. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Position | `public string Position { get; set; }` | Pozisyon/unvan metni. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (domain enum). |
| Salary | `public decimal? Salary { get; set; }` | Opsiyonel maaş. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Opsiyonel şube kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `Role = StaffRole.Librarian`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `StaffRole` enum’u.
- **İlişkili tipler:** `Library.Domain.Enums.StaffRole`.

Genel Değerlendirme
- Projede yalnızca `Application` ve `Domain` katmanları görünüyor; diğer katmanlar (Infrastructure, API) bu dosyadan anlaşılamıyor.
- Validasyon kuralları veya zorunluluklar DTO içinde tanımlı değil; doğrulama muhtemelen dış katmanlara bırakılmış.### Project Overview
Proje adı: Library. Amaç: kütüphane müşterilerine ait verileri katmanlar arasında taşımak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Clean Architecture/N‑Katman; `Application` katmanı `Domain` tiplerini kullanıyor. Keşfedilen projeler: `Library.Application` (Uygulama katmanı, DTO’lar ve iş akışı sözleşmeleri), `Library.Domain` (Etki alanı modelleri ve `Enums`). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
API/Presentation (bu dosyadan anlaşılmıyor, varsayılan üst katman)
    ↓
Library.Application
    ↓
Library.Domain

---
### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
Kütüphane müşterisine ait temel kimlik ve üyelik bilgilerini katmanlar arasında taşımak için kullanılan bir DTO’dur. Mimari olarak Application katmanına aittir ve `Domain` içindeki `MembershipType` enum’unu referanslar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Müşteri benzersiz kimliği |
| FirstName | `public string FirstName { get; set; }` | Ad |
| LastName | `public string LastName { get; set; }` | Soyad |
| Email | `public string Email { get; set; }` | E-posta |
| Phone | `public string Phone { get; set; }` | Telefon |
| Address | `public string Address { get; set; }` | Adres |
| City | `public string City { get; set; }` | Şehir |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi (`Library.Domain.Enums`) |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi |
| MembershipExpiryDate | `public DateTime? MembershipExpiryDate { get; set; }` | Üyelik bitiş tarihi |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu |
| MaxBooksAllowed | `public int MaxBooksAllowed { get; set; }` | Maks. ödünç kitap sayısı |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `MembershipNumber = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.MembershipType`
- **İlişkili tipler:** `MembershipType` enum’u

**Genel Değerlendirme**
Kod tabanında yalnızca Application katmanındaki bir DTO görülüyor; API, Infrastructure ve diğer katmanlara dair bilgi yok. Doğrulama, mapping profilleri (ör. AutoMapper) ve kalıcı katmanla ilişkiler bu dosyadan çıkarılamıyor. Target framework ve konfigürasyon anahtarları belirsiz.### Proje Genel Bakış
Proje, bir kütüphane yönetim sistemine ait uygulama katmanında yer alan veri aktarım nesnelerini içerir. Amaç, gösterge paneli gibi sunum ihtiyaçları için özet istatistikleri taşımaktır. Hedef framework bu dosyadan anlaşılamıyor. Mimari olarak katmanlı bir yapı (en azından Application katmanı) kullanılıyor. Keşfedilen proje/assembly: Library.Application — uygulama katmanı DTO’ları. Harici paket kullanımı bu dosyadan anlaşılamıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılamıyor.

### Mimari Diyagram
Library.Application (DTO’lar)
↑
(Çağıran katman/sunum veya servisler — bu dosyadan anlaşılamıyor)

---
### `Library.Application/DTOs/DashboardStatsDto.cs`

**1. Genel Bakış**
Kütüphane gösterge paneli için toplam/aktif kitaplar, müşteriler, personel, ödünçler, gecikmeler ve cezalar gibi metrikleri taşıyan bir DTO’dur. Uygulama katmanında sunum veya sorgu sonuçlarını taşımak amacıyla kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| TotalBooks | `public int TotalBooks { get; set; }` | Toplam kitap sayısı. |
| AvailableBooks | `public int AvailableBooks { get; set; }` | Ödünç verilebilir kitap sayısı. |
| TotalCustomers | `public int TotalCustomers { get; set; }` | Toplam müşteri sayısı. |
| ActiveCustomers | `public int ActiveCustomers { get; set; }` | Aktif müşteriler. |
| TotalStaff | `public int TotalStaff { get; set; }` | Toplam personel sayısı. |
| ActiveLoans | `public int ActiveLoans { get; set; }` | Devam eden ödünç sayısı. |
| OverdueLoans | `public int OverdueLoans { get; set; }` | Gecikmiş ödünç sayısı. |
| PendingReservations | `public int PendingReservations { get; set; }` | Bekleyen rezervasyon sayısı. |
| TotalUnpaidFines | `public decimal TotalUnpaidFines { get; set; }` | Toplam ödenmemiş ceza tutarı. |
| TotalBranches | `public int TotalBranches { get; set; }` | Toplam şube sayısı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `int` için `0`, `decimal` için `0m`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanı yalnızca Application katmanındaki bir DTO’yu gösteriyor; diğer katmanlar veya veri erişim/iş mantığı bu dosyadan anlaşılamıyor.
- Paket bağımlılıkları ve konfigürasyon anahtarları görünmüyor; genişletilebilirlik ve validasyon gereksinimleri üst katmanlarda ele alınmalıdır.### Project Overview
Proje adı: Library. Amaç: kütüphane işlemleri için uygulama ve domain katmanları arasında veri aktarımını sağlayan DTO’lar. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture benzeri yapı; `Library.Application` katmanı `Library.Domain` tiplerini referans alıyor. Keşfedilen projeler: Library.Application (Application katmanı, DTO’lar), Library.Domain (Domain katmanı, `Enums` referansı üzerinden). Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/DTOs/FineDtos.cs`

**1. Genel Bakış**
Kütüphane cezaları için veri aktarım nesnelerini (`DTO`) tanımlar: ceza görüntüleme (`FineDto`), ceza oluşturma (`CreateFineDto`), ceza ödeme isteği (`PayFineDto`). Uygulama katmanında sunum ve servisler arasında veri taşımak için kullanılır.

**2. Tip Bilgisi**
- Tip: class (`FineDto`, `CreateFineDto`, `PayFineDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
- `FineStatus` — `Library.Domain.Enums` içinden ceza durumunu temsil eder.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FineDto.Id | `public Guid Id { get; set; }` | Ceza kimliği. |
| FineDto.BookLoanId | `public Guid BookLoanId { get; set; }` | İlgili ödünç alma kaydı. |
| FineDto.CustomerId | `public Guid CustomerId { get; set; }` | Müşteri kimliği. |
| FineDto.CustomerName | `public string CustomerName { get; set; }` | Müşteri adı. |
| FineDto.BookTitle | `public string BookTitle { get; set; }` | Kitap adı. |
| FineDto.Amount | `public decimal Amount { get; set; }` | Ceza tutarı. |
| FineDto.Reason | `public string Reason { get; set; }` | Ceza nedeni. |
| FineDto.Status | `public FineStatus Status { get; set; }` | Ceza durumu. |
| FineDto.PaidDate | `public DateTime? PaidDate { get; set; }` | Ödeme tarihi. |
| FineDto.PaymentMethod | `public string? PaymentMethod { get; set; }` | Ödeme yöntemi. |
| CreateFineDto.BookLoanId | `public Guid BookLoanId { get; set; }` | Ödünç alma kaydı. |
| CreateFineDto.CustomerId | `public Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CreateFineDto.Amount | `public decimal Amount { get; set; }` | Tutar. |
| CreateFineDto.Reason | `public string Reason { get; set; }` | Neden. |
| PayFineDto.PaymentMethod | `public string PaymentMethod { get; set; }` | Ödeme yöntemi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `CustomerName = string.Empty`, `BookTitle = string.Empty`, `Reason = string.Empty`, `PayFineDto.PaymentMethod = string.Empty`, `FineDto.PaymentMethod` nullable.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Enums.FineStatus`
- İlişkili tipler: `FineStatus`

Genel Değerlendirme
- Kod yalnızca DTO’lardan oluşuyor; iş kuralları veya doğrulama görünmüyor.
- Katman bağımlılığı Application → Domain yönünde; mimari tutarlı görünüyor.
- Hedef framework, dış bağımlılıklar ve konfigürasyon hakkında bilgi bu dosyadan çıkarılamıyor.### Project Overview
Proje adı koddan “Library” olarak anlaşılıyor. Amaç: kütüphane şubelerine ait verileri uygulama katmanı üzerinden taşımak (DTO’lar). Hedef çatı: .NET 6+ (TimeOnly kullanımı). Mimari düzen katmanlı: DTO’lar Application katmanında. Keşfedilen proje/derleme: Library.Application — uygulama sözleşmeleri/DTO’ları. Harici paketlere dair kanıt yok. Konfigürasyon anahtarları veya bağlantı dizgileri bu koddan görülmüyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/DTOs/LibraryBranchDtos.cs`

**1. Genel Bakış**
Kütüphane şubesi için okuma, oluşturma ve güncelleme işlemlerinde kullanılan DTO tiplerini sağlar. Application katmanına aittir ve API/Handlers ile Domain/Infrastructure arasında veri taşıma amacıyla kullanılır.

**2. Tip Bilgisi**
- Tip: class (`LibraryBranchDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

- Tip: class (`CreateLibraryBranchDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

- Tip: class (`UpdateLibraryBranchDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `Guid Id { get; set; }` | . |
| Name | `string Name { get; set; }` | . |
| Address | `string Address { get; set; }` | . |
| City | `string City { get; set; }` | . |
| Phone | `string Phone { get; set; }` | . |
| Email | `string? Email { get; set; }` | . |
| Description | `string? Description { get; set; }` | . |
| OpeningTime | `TimeOnly OpeningTime { get; set; }` | . |
| ClosingTime | `TimeOnly ClosingTime { get; set; }` | . |
| IsActive | `bool IsActive { get; set; }` | . |
| StaffCount | `int StaffCount { get; set; }` | . |
| BookCount | `int BookCount { get; set; }` | . |
| Name | `string Name { get; set; }` | . |
| Address | `string Address { get; set; }` | . |
| City | `string City { get; set; }` | . |
| PostalCode | `string? PostalCode { get; set; }` | . |
| Phone | `string Phone { get; set; }` | . |
| Email | `string? Email { get; set; }` | . |
| Description | `string? Description { get; set; }` | . |
| OpeningTime | `TimeOnly OpeningTime { get; set; }` | . |
| ClosingTime | `TimeOnly ClosingTime { get; set; }` | . |
| Latitude | `double? Latitude { get; set; }` | . |
| Longitude | `double? Longitude { get; set; }` | . |
| Name | `string Name { get; set; }` | . |
| Address | `string Address { get; set; }` | . |
| City | `string City { get; set; }` | . |
| PostalCode | `string? PostalCode { get; set; }` | . |
| Phone | `string Phone { get; set; }` | . |
| Email | `string? Email { get; set; }` | . |
| Description | `string? Description { get; set; }` | . |
| OpeningTime | `TimeOnly OpeningTime { get; set; }` | . |
| ClosingTime | `TimeOnly ClosingTime { get; set; }` | . |
| IsActive | `bool IsActive { get; set; }` | . |
| Latitude | `double? Latitude { get; set; }` | . |
| Longitude | `double? Longitude { get; set; }` | . |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name/Address/City/Phone = string.Empty`, `Email/Description/PostalCode/Latitude/Longitude = null`, `IsActive` varsayılanı sadece `UpdateLibraryBranchDto` içinde ayarlanır (bool default: `false`).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Bu dosyadan anlaşılmıyor.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
Sadece DTO’lar mevcut. Doğrulama öznitelikleri, mapping profilleri veya kullanıldığı handler/service/controller kodu görünmüyor; bu nedenle uçtan uca sözleşme ve doğrulama stratejisi belirsiz. DTO’ların varsayılan değerleri tutarlı; ancak `TimeOnly` alanlar için operasyonel saat mantığı veya validasyon sinyali yok.### Project Overview
- Proje adı: Library (kod alanlarından çıkarım)
- Amaç: Bildirimlerle ilgili veri alışverişi için DTO’lar sağlamak; `Application` katmanından `Domain` tiplerine referansla iş akışlarını desteklemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean benzeri yapı — `Application` katmanı `Domain` tiplerine bağımlı.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı (DTO’lar)
  - Library.Domain — Temel domain tipleri (ör. `Enums.NotificationType`)
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/DTOs/NotificationDtos.cs`

**1. Genel Bakış**
Bildirimlerle ilgili veri transferi için iki DTO sağlar: `NotificationDto` okuma/görüntüleme, `CreateNotificationDto` oluşturma senaryoları. Application katmanında yer alır ve `Domain` içindeki `NotificationType` enum’una dayanır.

**2. Tip Bilgisi**
- Tip: `class` (`NotificationDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

- Tip: `class` (`CreateNotificationDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.NotificationType` — Bildirim tipini belirtir.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `Guid Id { get; set; }` | Bildirimin benzersiz kimliği. |
| CustomerId | `Guid CustomerId { get; set; }` | Bildirim sahibi müşteri kimliği. |
| Title | `string Title { get; set; }` | Bildirim başlığı. |
| Message | `string Message { get; set; }` | Bildirim içeriği. |
| Type | `NotificationType Type { get; set; }` | Bildirim türü. |
| IsRead | `bool IsRead { get; set; }` | Okunma durumu. |
| ReadAt | `DateTime? ReadAt { get; set; }` | Okunma zamanı (varsa). |
| CreatedAt | `DateTime CreatedAt { get; set; }` | Oluşturulma tarihi. |
| CustomerId | `Guid CustomerId { get; set; }` | (Create) Hedef müşteri kimliği. |
| Title | `string Title { get; set; }` | (Create) Başlık. |
| Message | `string Message { get; set; }` | (Create) Mesaj. |
| Type | `NotificationType Type { get; set; }` | (Create) Tür. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Message = string.Empty`. `ReadAt` nullable. `IsRead` ve `CreatedAt` için default bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: Controller/Handler/Service’ler tarafından kullanılabilir (bu dosyadan somut çağırıcılar anlaşılmıyor).
- Aşağı akış: `Library.Domain.Enums.NotificationType`.
- İlişkili tipler: `NotificationType` (Domain enum).

Genel Değerlendirme
- Sadece DTO’lar mevcut; davranış ve validasyon yok, bu beklenen bir durum. 
- Katman bağımlılığı `Application -> Domain` doğru yönde. 
- Hedef framework, konfigürasyon ve harici paketler bu dosyadan çıkarılamıyor.### Project Overview
Proje adı: Library. Amaç: Uygulama katmanında yayıncıya (publisher) ait veri transfer nesnelerini (DTO) tanımlamak. Hedef çatı: Bu dosyadan anlaşılamıyor. Mimari: Katmanlı/Clean benzeri; yalnızca Application katmanı (DTO’lar) görülebiliyor. Keşfedilen proje/assembly: Library.Application — Application katmanı, DTO tanımları. Harici paket/çatı: Bu dosyadan anlaşılamıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
[Library.Application (DTOs)]

---

### `Library.Application/DTOs/PublisherDtos.cs`

**1. Genel Bakış**
Yayıncı varlığı için okuma (`PublisherDto`) ve yazma (`CreatePublisherDto`, `UpdatePublisherDto`) amaçlı DTO’lar sağlar. Application katmanına aittir; API ile Domain/Service katmanı arasında veri taşıma sözleşmesi olarak kullanılır.

**2. Tip Bilgisi**
- Tip: class (`PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| PublisherDto | `class PublisherDto` | Okuma amaçlı yayıncı DTO’su. |
| Id | `Guid Id { get; set; }` | Yayıncı benzersiz kimliği. |
| Name | `string Name { get; set; }` | Yayıncı adı. |
| City | `string? City { get; set; }` | Şehir. |
| Country | `string? Country { get; set; }` | Ülke. |
| Phone | `string? Phone { get; set; }` | Telefon. |
| Email | `string? Email { get; set; }` | E-posta. |
| Website | `string? Website { get; set; }` | Web sitesi. |
| FoundedYear | `int? FoundedYear { get; set; }` | Kuruluş yılı. |
| IsActive | `bool IsActive { get; set; }` | Aktiflik durumu. |
| BookCount | `int BookCount { get; set; }` | İlişkili kitap sayısı. |
| CreatePublisherDto | `class CreatePublisherDto` | Oluşturma giriş DTO’su. |
| Name | `string Name { get; set; }` | Yayıncı adı. |
| Address | `string? Address { get; set; }` | Adres. |
| City | `string? City { get; set; }` | Şehir. |
| Country | `string? Country { get; set; }` | Ülke. |
| Phone | `string? Phone { get; set; }` | Telefon. |
| Email | `string? Email { get; set; }` | E-posta. |
| Website | `string? Website { get; set; }` | Web sitesi. |
| FoundedYear | `int? FoundedYear { get; set; }` | Kuruluş yılı. |
| UpdatePublisherDto | `class UpdatePublisherDto` | Güncelleme giriş DTO’su. |
| Name | `string Name { get; set; }` | Yayıncı adı. |
| Address | `string? Address { get; set; }` | Adres. |
| City | `string? City { get; set; }` | Şehir. |
| Country | `string? Country { get; set; }` | Ülke. |
| Phone | `string? Phone { get; set; }` | Telefon. |
| Email | `string? Email { get; set; }` | E-posta. |
| Website | `string? Website { get; set; }` | Web sitesi. |
| FoundedYear | `int? FoundedYear { get; set; }` | Kuruluş yılı. |
| IsActive | `bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`; opsiyonel alanlar `null` olabilir; `PublisherDto.IsActive` varsayılan `false`; `PublisherDto.BookCount` varsayılan `0`.

**6. Bağlantılar**
- Yukarı akış: API/Handlers/Services tarafından istek/yanıt modelleri olarak kullanılır (bu dosyadan ayrıntı anlaşılamıyor).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Muhtemel `Publisher` domain entity’si (bu dosyadan anlaşılamıyor).

Genel Değerlendirme
- Sadece DTO’lar mevcut; validasyon öznitelikleri veya sözleşme düzeyi doğrulama yok. Bu, doğrulamanın başka katmanda yapıldığını varsayar; aksi halde eksik olabilir.
- Mimari diğer katmanlar bu dosyadan çıkarılamıyor; bağımlılık yönü ve hedef çatı belirsiz.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki personel verilerini uygulama katmanında taşımak için DTO’lar sağlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari olarak katmanlı/Clean Architecture yaklaşımı izleniyor: Domain (temel tipler/enumerations) ve Application (DTO’lar, olası servisler/iş akışları). Keşfedilen projeler: Library.Domain (roller/enums), Library.Application (DTO’lar). Harici paketler: bu dosyadan anlaşılmıyor. Yapılandırma gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, personel bilgilerini (kimlik, iletişim, rol, durum, şube) taşıyan veri aktarım nesnesidir. Uygulama katmanında API/uygulama mantığı ile domain varlıkları arasında veri alışverişini kolaylaştırır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.StaffRole` — Personel rolünü tanımlayan domain enum’ı.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Personelin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Ad bilgisi. |
| LastName | `public string LastName { get; set; }` | Soyad bilgisi. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Position | `public string Position { get; set; }` | Pozisyon/ünvan. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (domain enum). |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| EmployeeNumber | `public string? EmployeeNumber { get; set; }` | Personel numarası (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Bağlı şube kimliği (opsiyonel). |
| LibraryBranchName | `public string? LibraryBranchName { get; set; }` | Bağlı şube adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`. Diğer alanlar C# varsayılanlarıdır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genelde API controller’ları, application servisleri/handler’ları).
- **Aşağı akış:** `Library.Domain.Enums.StaffRole`
- **İlişkili tipler:** `StaffRole` (domain enum). Olası `Staff` entity’si (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Kod, Clean Architecture’a işaret eden katman ayrımı (Application -> Domain) sergiliyor.
- Harici paketler, konfigürasyon anahtarları ve hedef framework bu dosyadan çıkarılamıyor.
- DTO’nun isim/iletişim alanlarında uygun boş string varsayılanları belirlenmiş; null güvenliği tutarlı.### Project Overview
Proje adı: Library.Application. Amaç: Uygulama katmanında kitap kategorisi güncellemeleri için DTO sağlamak. Hedef çatı (target framework): bu dosyadan anlaşılmıyor. Mimari katmanlandırma: en azından Application katmanı mevcut; diğer katmanlar bu dosyadan anlaşılmıyor. Keşfedilen proje/assembly: Library.Application — Uygulama katmanı, DTO’lar içerir. Harici paket/çatı: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
^
(başka katmanlar bu dosyadan anlaşılmıyor)

---
### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisi güncelleme işlemlerinde istenen veriyi taşımak için kullanılan basit bir aktarım nesnesidir (DTO). Uygulama (Application) katmanına aittir ve giriş/çıkış sözleşmelerini sade tutar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Name | `public string Name { get; set; } = string.Empty;` | Kategori adı. |
| Description | `public string Description { get; set; } = string.Empty;` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanındaki bir DTO görülebiliyor; diğer katmanlar, iş kuralları ve veri erişimi bu dosyadan anlaşılamıyor.
- Doğrulama kuralları veya anotasyonlar yok; validasyonun nerede yapıldığı belirsiz.### Project Overview
Proje: Library — Amaç: kütüphane alanındaki varlıklar için uygulama katmanında DTO’lar ve domain tipleriyle işlem yapmak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Clean Architecture (Domain, Application katmanları izleniyor). Görünen projeler: Library.Domain (alan modelleri/enumerations), Library.Application (DTO’lar, uygulama sözleşmeleri). Dış bağımlılıklar bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain -> Library.Application

---
### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
Bir kitabın güncellenmesi için gerekli alanları taşıyan DTO’dur. Uygulama katmanında, komut/işlemlere veri taşıma amaçlı kullanılır ve iş kuralı barındırmaz.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Title | `public string Title { get; set; }` | DTO alanı. |
| ISBN | `public string ISBN { get; set; }` | DTO alanı. |
| Description | `public string Description { get; set; }` | DTO alanı. |
| PublishedYear | `public int PublishedYear { get; set; }` | DTO alanı. |
| PageCount | `public int PageCount { get; set; }` | DTO alanı. |
| Language | `public string Language { get; set; }` | DTO alanı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | DTO alanı. |
| TotalCopies | `public int TotalCopies { get; set; }` | DTO alanı. |
| AvailableCopies | `public int AvailableCopies { get; set; }` | DTO alanı. |
| Condition | `public BookCondition Condition { get; set; }` | DTO alanı. |
| Price | `public decimal? Price { get; set; }` | DTO alanı. |
| AuthorId | `public Guid AuthorId { get; set; }` | DTO alanı. |
| PublisherId | `public Guid? PublisherId { get; set; }` | DTO alanı. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | DTO alanı. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | DTO alanı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `ISBN = string.Empty`, `Description = string.Empty`, `Language = "Turkish"`. Diğer alanlar CLR default (ör. `PublishedYear = 0`, `IsAvailable = false`, `Price = null`).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: `Library.Domain.Enums.BookCondition`.

Genel Değerlendirme
- Kod yalnızca Application katmanında bir DTO ve Domain’deki bir enum’a referans içerdiğini gösteriyor. Doğrulama, mapping profilleri ve işlem akışları bu parçadan görünmüyor. Dış paketler ve konfigürasyonlar tespit edilemiyor. Clean Architecture izlenimi var, ancak diğer katmanlar (Infrastructure, API) bu koddan doğrulanamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait müşteri güncelleme verilerini taşımak için uygulama katmanında DTO sağlamak. Hedef çatı: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: Katmanlı/Clean Architecture esintili; `Domain` iş kuralları ve tipleri, `Application` DTO ve kullanım senaryoları.

Katman/Projeler:
- Library.Domain — Temel iş kuralları ve paylaşılan tipler (örn. `Enums.MembershipType`).
- Library.Application — Uygulama katmanı, DTO’lar ve muhtemel use-case/handler’lar.

Harici paketler: Bu dosyadan görünmüyor. Konfigürasyon: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, bir müşterinin güncelleme isteğinde taşınacak alanları temsil eden basit bir veri taşıyıcıdır. Uygulama katmanında yer alır ve `Domain` katmanındaki `MembershipType` enum’unu kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- Harici bağımlılık yok. (Alan tipi olarak `Library.Domain.Enums.MembershipType` kullanılır.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşteri e-postası. |
| Phone | `public string Phone { get; set; }` | Müşteri telefonu. |
| Address | `public string Address { get; set; }` | Adres satırı. |
| City | `public string City { get; set; }` | Şehir. |
| PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `PostalCode = null`, `MembershipType` varsayılan enum değeri, `IsActive = default(bool)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.MembershipType`.
- **İlişkili tipler:** `MembershipType` (Domain).

Genel Değerlendirme
- Kod yalnızca Application katmanındaki bir DTO’yu içeriyor; doğrulama, mapping profilleri veya handler/service katmanı bu dosyadan görünmüyor.
- `Application` → `Domain` bağımlılığı Clean Architecture’a uygundur. Ancak katmanlar arası sınırların tamamı (ör. API/Infrastructure) bu dosyadan tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: kütüphane personel yönetimiyle ilişkili uygulama katmanında DTO alışverişini sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari, katman adlarından Clean Architecture’a işaret ediyor: Domain (iş kuralları ve enum’lar), Application (DTO’lar, use-case’ler). Keşfedilen projeler/assembly’ler: Library.Application (DTO’lar), Library.Domain (enum’lar). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Application  
(Üst katmanlar/presentation/infrastructure varlığı ve bağımlılık yönleri bu dosyadan anlaşılmıyor)

---
### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel güncelleme işlemlerinde kullanılan veri taşıma nesnesidir. Application katmanına aittir ve dış katmanlardan gelen güncelleme girişlerini iş kurallarına iletmek için alanların taşınmasını sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (`Library.Domain.Enums`). |
| Salary | `public decimal? Salary { get; set; }` | Opsiyonel maaş bilgisi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Opsiyonel şube kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`. `Salary` ve `LibraryBranchId` opsiyoneldir (`null` olabilir).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Library.Domain.Enums.StaffRole`

Genel Değerlendirme
- Kod parçacığı Clean Architecture katmanlamasına işaret ediyor ancak yalnızca bir DTO ve bir enum referansı görülebiliyor. Validasyon, mapping profilleri (ör. AutoMapper) ve iş akışlarını yöneten hizmetler/handler’lar bu dosyadan anlaşılmıyor. Dış bağımlılıklar, hedef framework ve konfigürasyon anahtarları tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: uygulama katmanındaki servislerin DI konteynerine kaydı. Hedef framework: bu dosyadan anlaşılmıyor (.NET tabanlı). Mimari: katmanlı (Application katmanı). Keşfedilen proje/assembly: Library.Application — uygulama servislerinin kompozisyonu ve DI uzantısı. Dış bağımlılıklar: `Microsoft.Extensions.DependencyInjection`. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DI uzantısı)
  -> Microsoft.Extensions.DependencyInjection (IServiceCollection)

---
### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
Uygulama katmanındaki servisleri `IServiceCollection` üzerine “scoped” ömürle kaydeden DI uzantı sınıfı. Başlatım aşamasında çağrılarak Application servislerinin arayüz-implementasyon eşlemelerini merkezi olarak sağlar.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Uygulama servislerini arayüz-implementasyon eşleşmeleriyle “scoped” olarak DI konteynerine ekler. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm servisler “Scoped” ömürle kaydedilir: `IBookService→BookService`, `IBookCategoryService→BookCategoryService`, `IStaffService→StaffService`, `ICustomerService→CustomerService`, `IAuthorService→AuthorService`, `IPublisherService→PublisherService`, `IBookLoanService→BookLoanService`, `IBookReservationService→BookReservationService`, `IFineService→FineService`, `ILibraryBranchService→LibraryBranchService`, `IBookReviewService→BookReviewService`, `INotificationService→NotificationService`, `IDashboardService→DashboardService`.
- Metot, zincirleme kayıtlar için `IServiceCollection` döner.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama başlatımında kompozisyon kökünce çağrılır.
- **Aşağı akış:** `Microsoft.Extensions.DependencyInjection` API’si.
- **İlişkili tipler:** Yukarıda listelenen tüm `I*Service` arayüzleri ve karşılık gelen `*Service` sınıfları.

**7. Eksikler ve Gözlemler**
- Hedef servis sınıfları ve arayüzleri bu dosyada tanımlı değil; varlıkları ve konumları bu dosyadan anlaşılmıyor.

---
Genel Değerlendirme
- Mimari katman işaretleri Application ile sınırlı; diğer katmanlar (Domain, Infrastructure, API) bu girdiyle görünmüyor.
- Servis yaşam süreleri tutarlı biçimde “Scoped”. Farklı yaşam süreleri gerekiyorsa (örn. stateless helper’lar için Singleton/Transient) ayrıştırma değerlendirilebilir.
- Konfigürasyon veya bağlantı stringi ihtiyacı bu dosyada yer almıyor; servislerin iç bağımlılıkları hakkında görünürlük yok.### Project Overview
Proje adı muhtemelen “Library” ve bu kod, uygulamanın “Application” katmanında e‑posta yapılandırmalarını temsil eder. Amaç: e‑posta gönderimi için yapılandırma ayarlarını tip güvenli şekilde taşımak. Hedef framework bu dosyadan anlaşılmıyor. Mimari yaklaşım Clean Architecture/katmansal düzeni işaret ediyor; `Library.Application` iş kuralları/uygulama servisleri katmanıdır. Keşfedilen proje/assembly: `Library.Application` — uygulama hizmetleri ve konfigürasyon sözleşmeleri. Harici paket görünmüyor. Konfigürasyon gereksinimleri: e‑posta için `Host`, `Port`, `Username`, `Password`, `From`, `NotificationTo`, `EnableSsl` ayarları (anahtar adları bu dosyadan anlaşılmıyor).

### Architecture Diagram
[Consumer (API/Worker)] -> Library.Application

---
### `Library.Application/Email/EmailSettings.cs`

**1. Genel Bakış**
`EmailSettings`, e‑posta servislerinin ihtiyaç duyduğu yapılandırma değerlerini tutan bir ayar sınıfıdır. Uygulama (Application) katmanında, e‑posta altyapısına bağımlı kodlardan konfigürasyonu soyutlamak için kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Email`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Host | `public string Host { get; set; }` | SMTP sunucu adresi. |
| Port | `public int Port { get; set; }` | SMTP portu. |
| Username | `public string Username { get; set; }` | SMTP kullanıcı adı. |
| Password | `public string Password { get; set; }` | SMTP parolası. |
| From | `public string From { get; set; }` | Gönderen e‑posta adresi. |
| NotificationTo | `public string NotificationTo { get; set; }` | Varsayılan bildirim alıcısı. |
| EnableSsl | `public bool EnableSsl { get; set; }` | SSL/TLS kullanım bayrağı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Host = string.Empty`, `Port = 587`, `Username = string.Empty`, `Password = string.Empty`, `From = string.Empty`, `NotificationTo = string.Empty`, `EnableSsl = true`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir veya configuration binding ile doldurulur.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- `Password` gibi gizli değerlerin düz metin ayarlardan gelmesi güvenlik riski olabilir; secret store/KeyVault gibi mekanizmalar tercih edilmelidir.

Genel Değerlendirme
- Kod, Clean Architecture benzeri katmanda yalın bir konfigürasyon POCO’su sunuyor. Başka katmanlar/projeler görünmediğinden bağımlılık akışı sınırlı gözlemlenebiliyor. Güvenlik açısından parola yönetimi için gizli yönetimi (secret manager) ve güvenli konfigürasyon bağlama stratejileri önerilir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanında yazar yönetimi için uygulama katmanı sözleşmeleri sağlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: katmanlı (Application katmanı tespit edildi). Bulunan proje/assembly: Library.Application — uygulama hizmet sözleşmeleri ve DTO referansları. Dış bağımlılıklar: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]
  └─ (diğer katman bağımlılıkları bu dosyadan anlaşılmıyor)

---
### `Library.Application/Interfaces/IAuthorService.cs`

**1. Genel Bakış**
`IAuthorService`, yazar varlıklarına yönelik asenkron CRUD ve arama işlemleri için uygulama katmanı sözleşmesini tanımlar. Application katmanında, üst katmanlara (ör. API) kararlı bir arayüz sağlar ve DTO’lar üzerinden çalışır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<AuthorDto?> GetByIdAsync(Guid id)` | Kimliğe göre yazarı getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<AuthorDto>> GetAllAsync()` | Tüm yazarları döner. |
| SearchAsync | `Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)` | Arama terimine göre yazarları filtreler. |
| CreateAsync | `Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)` | Yeni yazar oluşturur ve döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)` | Mevcut yazarı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Yazarı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış tanımlı değil. `GetByIdAsync` `null` dönebilir. Tüm operasyonlar asenkron ve DTO tabanlıdır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik çağırıcılar API controller’ları veya uygulama hizmetleri olabilir.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- İmzalarda `CancellationToken` bulunmuyor; uzun süren işlemlerde iptal desteği eksik olabilir.
- `SearchAsync` için sayfalama/sıralama parametreleri yok; büyük veri kümelerinde verimsizlik yaratabilir.

---
Genel Değerlendirme
Kod tabanında sadece Application katmanındaki bir arayüz görünür durumda. Katmanlar arası bağımlılık akışı, hedef çatı ve dış paketler bu dosyadan çıkarılamıyor. Asenkron sözleşmelerde `CancellationToken` ve arama/sayfalama yeteneklerinin standartlaştırılması önerilir. DTO’ların tanımları ve somut servis implementasyonları incelenerek validasyon ve hata yönetimi politikaları netleştirilmelidir.### Project Overview
Proje adı bu dosyadan anlaşılmıyor. Amaç: kitap kategorileri için uygulama katmanı sözleşmeleri tanımlamak. Hedef çatı ve sürüm bu dosyadan anlaşılmıyor. Mimari olarak katmanlı bir yapı işaret ediyor; `Application` katmanı DTO’lar üzerinden veri taşır ve servis sözleşmeleri sunar. Keşfedilen proje/derleme: `Library.Application` — uygulama katmanı, servis arayüzleri ve DTO’lar. Harici paketler ve yapılandırma gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  └─ uses: Library.Application.DTOs

---
### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorileri için CRUD odaklı uygulama hizmeti sözleşmesini tanımlar. Uygulama katmanına aittir ve üst katmanların (örn. API) kategori yönetimi operasyonlarını soyutlamasını sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Arayüz, `Library.Application.DTOs` tiplerini parametre/dönüş olarak kullanır.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Belirli `id` ile kategoriyi getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori listesini döner. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Mevcut kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirli kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz sözleşmesi; davranış/validasyon detayları bu dosyadan anlaşılmıyor.
- CRUD semantiği: oluşturma döner, güncelleme/silme geri dönüş değeri içermez.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/controller veya application command handler’lar kullanır.
- **Aşağı akış:** `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `BookCategoryDto`.
- **İlişkili tipler:** `Library.Application.DTOs` içindeki ilgili DTO’lar.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri yok; uzun süren I/O işlemlerinde iptal desteği eksik olabilir.
- `GetAllAsync` için sayfalama/filtreleme yok; büyük veri kümelerinde performans etkisi olabilir.

---
Genel Değerlendirme
Kod, uygulama katmanında net bir servis sözleşmesi sunuyor. Ancak iptal belirteçleri ve potansiyel sayfalama/filtreleme sözleşmesinin eklenmesi ölçeklenebilirlik ve dayanıklılık açısından faydalı olabilir. Harici bağımlılıklar ve alt katmanlar bu dosyadan belirlenemiyor; uygulama bütününde katmanlar arası bağımlılık yönlerinin tutarlı olduğundan emin olunmalıdır.### Project Overview
Proje adı: Library. Amaç: kütüphane ödünç verme akışlarını uygulama katmanında tanımlamak (kitap ödünç alma, iade, uzatma, durum/filtreleme). Hedef çatı ve sürüm bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli; `Application` katmanı, `Domain` tiplerini kullanıyor. Keşfedilen projeler: Library.Application (uygulama sözleşmeleri/servis arayüzleri, DTO kullanımı), Library.Domain (enum ve muhtemel çekirdek tipler). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Application

---
### `Library.Application/Interfaces/IBookLoanService.cs`

**1. Genel Bakış**
Kütüphane kitap ödünç işlemleri için uygulama servis sözleşmesini tanımlar. Ödünç kaydını getirme, listeleme, durum bazlı filtreleme, oluşturma, iade ve uzatma operasyonlarını standartlaştırır. Mimari olarak Application katmanına aittir ve Domain’deki `LoanStatus` ile DTO’lar arasında sınır sözleşmesi sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookLoanDto?> GetByIdAsync(Guid id)` | Belirli ödünç kaydını getirir. |
| GetAllAsync | `Task<IEnumerable<BookLoanDto>> GetAllAsync()` | Tüm ödünç kayıtlarını listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye göre ödünçleri listeler. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()` | Aktif (iade edilmemiş) ödünçleri döner. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()` | Gecikmiş ödünçleri döner. |
| GetByStatusAsync | `Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)` | Duruma göre filtreler. |
| CreateAsync | `Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)` | Yeni ödünç oluşturur. |
| ReturnBookAsync | `Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)` | Kitabı iade eder. |
| RenewLoanAsync | `Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)` | Ödüncü uzatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Ödünç kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Bu arayüz, iş kurallarını uygulayacak implementasyonlar için sözleşme sağlar (oluşturma, iade, uzatma, durum/aktif/gecikmiş filtreleri). Ayrıntılı validasyon ve exception davranışı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel tüketiciler API controller’ları veya uygulama iş akışları.
- **Aşağı akış:** Yok (arayüz). Uygulamalarında repository/DB çağrıları beklenir, bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`, `LoanStatus`.

Genel Değerlendirme
- Yalın ve tutarlı bir Application servis sözleşmesi. İptal destekleri (`CancellationToken`) ve sayfalama parametreleri eksik olabilir; gereksinime bağlıdır. Dış bağımlılıklar ve hata yönetimi stratejisi bu dosyadan anlaşılamıyor.### Project Overview
Proje adı: Library. Amaç: kitap rezervasyonlarıyla ilgili uygulama sözleşmelerini tanımlamak. Hedef çerçeve: Bu dosyadan anlaşılmıyor. Mimari olarak uygulama sözleşmeleri Application katmanında toplanmış görünüyor. Keşfedilen proje/assembly: Library.Application — uygulama sözleşmeleri ve DTO referansları. Harici paketler: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/Interfaces/IBookReservationService.cs`

**1. Genel Bakış**
Kitap rezervasyonlarına yönelik uygulama hizmet sözleşmesini tanımlar. Okuma, listeleme, müşteri/kitap bazlı sorgular ve oluşturma/iptal/tamamlama/silme işlemleri için asenkron metod imzaları sağlar. Application katmanında bir servis arayüzüdür.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
- `Library.Application.DTOs.BookReservationDto` — Rezervasyon veri aktarım modeli
- `Library.Application.DTOs.CreateBookReservationDto` — Rezervasyon oluşturma isteği modeli

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookReservationDto?> GetByIdAsync(Guid id)` | Belirli rezervasyonu kimliğe göre döndürür (yoksa null). |
| GetAllAsync | `Task<IEnumerable<BookReservationDto>> GetAllAsync()` | Tüm rezervasyonları listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin rezervasyonlarını listeler. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın rezervasyonlarını listeler. |
| CreateAsync | `Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)` | Yeni rezervasyon oluşturur ve sonucu döndürür. |
| CancelReservationAsync | `Task CancelReservationAsync(Guid id)` | Rezervasyonu iptal eder. |
| FulfillReservationAsync | `Task FulfillReservationAsync(Guid id)` | Rezervasyonu karşılama/tamamlama işlemini yapar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Rezervasyonu kalıcı olarak siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımlı değil. İmzalardan çıkarımlar: iptal ve tamamlama işlemleri yan etki içerir; `GetByIdAsync` null dönebilir; tüm operasyonlar asenkron.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/servis katmanı tüketicileri (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** DTO tipleri (`BookReservationDto`, `CreateBookReservationDto`).
- **İlişkili tipler:** `Library.Application.DTOs.BookReservationDto`, `Library.Application.DTOs.CreateBookReservationDto`.

**7. Eksikler ve Gözlemler**
- Arayüzün implementasyonu bu depoda görünmüyor.
- Doğrulama ve hata yönetimi sözleşmede belirtilmemiş; domain kuralları belirsiz.

---

Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir servis arayüzünü içeriyor. Uç noktalar, altyapı implementasyonları, DTO tanımları ve domain modelleri görünmüyor; bu nedenle mimari bağımlılık akışı ve konfigürasyon gereksinimleri çıkarılamıyor. Asenkron sözleşmeler tutarlı; ancak iptal/tamamlama/silme operasyonlarında beklenen hata durumları ve istisna sözleşmeleri netleştirilmeli.### Project Overview
Proje adı: Library (uygulama katmanı). Amaç: kitap yorumları yönetimi için uygulama servisi sözleşmeleri tanımlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: katmanlı/N-Tier tarzı; Application katmanı DTO’lar ve servis sözleşmeleri içerir. Keşfedilen proje/assembly: Library.Application — uygulama sözleşmeleri ve DTO’lar. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
 ├─ Interfaces
 └─ DTOs

---
### `Library.Application/Interfaces/IBookReviewService.cs`

**1. Genel Bakış**
Kitap yorumlarıyla ilgili okuma, oluşturma, güncelleme, onaylama ve silme işlemleri için uygulama katmanı servis sözleşmesini tanımlar. Uygulama (Application) katmanına aittir ve üst katmanlarca DI üzerinden tüketilmek üzere tasarlanmıştır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookReviewDto?> GetByIdAsync(Guid id)` | Belirli yorum kimliğine göre yorumu getirir; bulunamazsa `null`. |
| GetByBookIdAsync | `Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)` | Belirli kitap için tüm onaylı/ilgili yorumları döndürür. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin yazdığı yorumları listeler. |
| GetAverageRatingAsync | `Task<double> GetAverageRatingAsync(Guid bookId)` | Bir kitabın ortalama puanını hesaplar. |
| CreateAsync | `Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)` | Yeni bir yorum oluşturur ve döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)` | Var olan yorumu günceller. |
| ApproveReviewAsync | `Task ApproveReviewAsync(Guid id)` | Yorumu onaylar (moderasyon). |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Yorumu siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByIdAsync` bulunamazsa `null` dönebilir; diğer sorgular boş koleksiyon döndürebilir.
- `GetAverageRatingAsync` hesaplama detayları bu dosyadan anlaşılmıyor (filtre: sadece onaylı yorumlar mı?).
- `ApproveReviewAsync` moderasyon akışına işaret eder; yetkilendirme/rol kontrolü bu dosyadan anlaşılmıyor.
- Validasyon ve hata yönetimi sözleşmede belirtilmemiştir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/Service katmanları çağırır.
- **Aşağı akış:** `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto` (DTO bağımlılıkları).
- **İlişkili tipler:** `Library.Application.DTOs.BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`.

**7. Eksikler ve Gözlemler**
- Tüm async imzalarda `CancellationToken` eksik.
- Listeleme uçlarında sayfalama/sıralama parametreleri yok.
- Hata sözleşmeleri (bulunamadı/izin verilmedi gibi) ve yetkilendirme davranışları tanımlı değil.

---
Genel Değerlendirme
Kod tabanından görülen tek katman Application olup, servis sözleşmesi DTO’lara bağımlıdır. İmzalar net fakat iptal belirteci, sayfalama ve hata/izin sözleşmeleri eksik. Mimari ve altyapı ayrıntıları (veri erişimi, domain modelleri, dış paketler) bu dosyadan anlaşılamıyor; proje büyüdükçe bu sözleşmelerde tutarlı iptal, validasyon ve yetkilendirme desenleri eklenmesi önerilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına ait uygulama katmanında kitap yönetimi sözleşmelerini (servis arayüzü) tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı yapı; `Library.Application` katmanı görülebiliyor. Diğer katmanlar bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve servis arayüzleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application.DTOs <- Library.Application.Interfaces

---
### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara yönelik uygulama servisinin sözleşmesini tanımlar: sorgulama, oluşturma, güncelleme ve silme işlemleri. Uygulama (Application) katmanına aittir ve üst katmanlara iş kurallarını sunan bir arayüz görevi görür.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirli bir kitap kimliğiyle kitabı getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait/ödünç verilebilir kitapları listeler. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur ve oluşturulan kitabı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Dönüş tipleri `BookDto` ve koleksiyonları; girişler `CreateBookDto`, `UpdateBookDto`.
- `GetByIdAsync` kitap bulunamazsa `null` dönebileceğini ifade eder.
- `GetAvailableBooksAsync` kullanılabilirlik filtresi içerir; kesin kriterler bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar controller’lar veya application katmanı handler’ları (bu dosyadan kesin değil).
- **Aşağı akış:** Harici bağımlılık yok (arayüz tanımı).
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto` (`Library.Application.DTOs`).

Genel Değerlendirme
- Yalnızca arayüz görülebiliyor; implementasyon, veri erişimi ve API katmanı bu dosyadan anlaşılmıyor.
- Hedef framework, dış bağımlılıklar ve konfigürasyon anahtarları belirsiz.
- Mimari eğilim Application katmanına işaret ediyor; diğer katmanlar (Domain, Infrastructure, API) hakkında teyit edilebilir veri yok.### Proje Genel Bakış
Proje adı: Library. Amaç: müşteri yönetimi için uygulama katmanı sözleşmeleri ve DTO’lar üzerinden CRUD operasyonlarını tanımlamak. Hedef çatı: modern .NET (tam sürüm bu dosyadan anlaşılmıyor).
Mimari: Clean Architecture eğilimli; `Application` katmanı arayüz ve DTO sözleşmeleri içeriyor.
Projeler/Assembly’ler: 
- Library.Application — Uygulama sözleşmeleri (`Interfaces`) ve DTO referansları.
Harici paketler: Bu dosyadan anlaşılmıyor.
Yapılandırma: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (Interfaces, DTOs)
  ↳ (Uygulama arayüzleri uygular) → (Infrastructure/Application.Services — bu dosyadan anlaşılmıyor)
  ↳ (Kullanıcıları) → API/Presentation katmanı — bu dosyadan anlaşılmıyor

---

### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri yönetimi için CRUD ve filtrelenmiş listeleme operasyonlarını tanımlayan uygulama katmanı arayüzüdür. Üst katmanlar (API/Handlers) ile alt katmandaki uygulama mantığı/depoya erişim implementasyonları arasında sözleşme sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Kimliğe göre müşteriyi getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri listeler. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — iş mantığı içermez; CRUD ve “aktif müşteriler” için sözleşme tanımlar.
- `GetByIdAsync` null dönebilir; diğer listeleme çağrıları boş koleksiyon dönebilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; API/Controllers, Application Handlers tarafından çağrılması beklenir.
- **Aşağı akış:** Implementasyonların repository/DB erişimine bağımlı olması muhtemel — bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri yok; uzun süren I/O işlemleri için iptal desteği eklenebilir.
- `GetAllAsync` ve `GetActiveCustomersAsync` için sayfalama/sıralama sözleşmesi tanımlı değil; büyük veri setlerinde performans riski.

---

### Genel Değerlendirme
Kod tabanı, Clean Architecture yaklaşımıyla Application katmanında net bir sözleşme sunuyor. İptal belirteci ve sayfalama/sıralama gibi en iyi uygulama sözleşmeleri eksik. Diğer katmanlar ve konfigürasyonlar bu girdiyle görülemiyor; proje geneline dair bağımlılıklar ve hata yönetimi stratejisi belirsiz.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait uygulama içi işlemler için Application katmanında sözleşmeler ve DTO’lar tanımlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor). Mimari, katmanlı/temiz mimari izlenimi veriyor; bu projede Application katmanı mevcut. Keşfedilen projeler/assembly’ler: 
- Library.Application — Application katmanı, `Interfaces` ve `DTOs` içerir.
Dış bağımlılıklar: Görünmüyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
 ├─ Interfaces
 │   └─ depends on → DTOs
 └─ DTOs

---
### `Library.Application/Interfaces/IDashboardService.cs`

**1. Genel Bakış**
`IDashboardService`, uygulamanın dashboard ekranı için özet/istatistik verilerini sağlamaya yönelik sözleşmeyi tanımlar. Application katmanında yer alır ve üst katmanlara (API/UI) istatistik toplama için bir giriş noktası sunar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetStatsAsync | `Task<DashboardStatsDto> GetStatsAsync()` | Dashboard için istatistik özetini asenkron olarak döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Asenkron sözleşme; istatistiklerin elde edilmesi potansiyel olarak I/O içerir.
- Dönüş tipi `DashboardStatsDto` ile standartlaştırılmış çıktı beklenir.
- İptal/timeout yönetimi için `CancellationToken` parametresi bulunmuyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar API/Presentation katmanı (bu dosyadan kesin değil).
- **Aşağı akış:** Bu dosyadan anlaşılmıyor (implementasyonlara bağlı).
- **İlişkili tipler:** `DashboardStatsDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Asenkron operasyonda `CancellationToken` eksik; uzun süren sorgularda iptal desteği beklenebilir. 

Genel Değerlendirme
- Sadece Application katmanında bir servis sözleşmesi görünüyor; katmanlar arası bağımlılık ve akış büyük ölçüde doğru fakat iptal/akış kontrolü için `CancellationToken` desteği önerilir.
- Dış paket, konfigürasyon ve hedef çatı sürümü bu koddan belirlenemiyor.### Project Overview
Proje: Library. Amaç: uygulama içinde e-posta gönderimini soyutlamak için bir sözleşme sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari katman olarak yalnızca Application katmanı görünüyor; diğer katmanlar (Infrastructure, API) bu dosyadan anlaşılmıyor. Keşfedilen derleme: Library.Application — uygulama servis sözleşmeleri. Harici paketler ve konfigürasyon anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces)
  └─ (Uygulama bu arayüzü tüketir; somut implementasyonlar muhtemelen başka bir katmanda, bu dosyadan net değil)

---
### `Library.Application/Interfaces/IEmailService.cs`

**1. Genel Bakış**
`IEmailService`, e-posta gönderimi için uygulama katmanında bir sözleşme tanımlar. Amaç, e-posta altyapısına doğrudan bağımlılığı önleyerek implementasyon ayrıntılarını başka bir katmana bırakmaktır. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | Asenkron e-posta gönderir; HTML içeriği isteğe bağlıdır. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok. Default değerler: `isHtml = true`, `cancellationToken = default`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir
- **Aşağı akış:** Yok
- **İlişkili tipler:** `Task`, `CancellationToken`

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanında bir arayüz mevcut. Hedef çatı, dış bağımlılıklar, konfigürasyon ve diğer katmanlar bu dosyadan anlaşılamıyor. Implementasyonu ve kullanım yerleri eklenirse katmanlar arası bağımlılık akışı netleşir.### Project Overview
Proje adı: Library. Amaç: kütüphane cezaları için uygulama katmanında servis sözleşmesi tanımlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture izlenimi; Application katmanı arayüzleriyle iş kurallarını soyutlar. Keşfedilen projeler: Library.Application — uygulama sözleşmeleri ve DTO referansları. Dış paketler: bu dosyadan anlaşılmıyor. Konfigürasyon: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces)
  [tek başına keşfedildi; bağımlılık yönleri bu dosyadan anlaşılmıyor]

---
### `Library.Application/Interfaces/IFineService.cs`

**1. Genel Bakış**
Kütüphane ceza işlemleri için servis sözleşmesi tanımlar: cezaları listeleme, müşteriye göre sorgulama, ödeme/affetme, oluşturma ve silme. Application katmanına aittir ve domain/infrastructure detaylarını soyutlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<FineDto?> GetByIdAsync(Guid id)` | Belirli cezanın detayını getirir. |
| GetAllAsync | `Task<IEnumerable<FineDto>> GetAllAsync()` | Tüm cezaları listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)` | Müşterinin cezalarını listeler. |
| GetPendingFinesAsync | `Task<IEnumerable<FineDto>> GetPendingFinesAsync()` | Ödenmemiş/aktif cezaları listeler. |
| GetTotalUnpaidByCustomerAsync | `Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)` | Müşterinin toplam ödenmemiş ceza tutarını döner. |
| CreateAsync | `Task<FineDto> CreateAsync(CreateFineDto createDto)` | Yeni ceza oluşturur. |
| PayFineAsync | `Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)` | Cezayı ödeme bilgisiyle kapatır/günceller. |
| WaiveFineAsync | `Task WaiveFineAsync(Guid id)` | Cezayı affeder/iptal eder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Cezayı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme; iş kuralları implementasyonda belirlenir.
- Ödeme (`PayFineAsync`) ve affetme (`WaiveFineAsync`) işlemleri için durum geçişleri beklenir; detaylar bu dosyadan anlaşılmıyor.
- `GetPendingFinesAsync` ödenmemiş cezaları filtrelemeyi ima eder.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar controller’lar veya application handler’ları (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** Implementasyon veri erişimi ve ödeme/doğrulama altyapılarına bağlanabilir (bu dosyadan anlaşılmıyor).
- **İlişkili tipler:** `FineDto`, `CreateFineDto`, `PayFineDto`.

**7. Eksikler ve Gözlemler**
- Async imzalar `CancellationToken` içermiyor; uzun süren IO işlemlerinde iptal desteği eklenmesi faydalı olabilir.
- `GetAllAsync` için sayfalama/sıralama parametreleri yok; büyük veri setlerinde performans ve kullanım açısından gözden geçirilmeli.

Genel Değerlendirme
- Sadece Application katmanındaki bir servis arayüzü görünüyor; diğer katmanlar ve DTO tanımları bu girdiden anlaşılamıyor.
- Sözleşme kapsamı net; ancak iptal belirteci ve sayfalama gibi çapraz kesen kaygılar API seviyesinde düşünülmeli.### Project Overview
Proje adı: Library. Amaç: kütüphane şubeleriyle ilgili uygulama iş mantığı için servis sözleşmeleri ve DTO’lar üzerinden uygulama katmanını tanımlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor).
Mimari: İsimlendirmeler, Application katmanına işaret eden tipik Clean Architecture/N-Tier yaklaşımını düşündürüyor; ancak diğer katmanlar bu dosyadan doğrulanamıyor.
Projeler/Assemblies: Library.Application — Uygulama katmanı, servis arayüzleri ve DTO sözleşmeleri.
Dış bağımlılıklar: Bu dosyada görünmüyor.
Konfigürasyon: Bu dosyada görünmüyor.

### Architecture Diagram
Library.Application

---
### `Library.Application/Interfaces/ILibraryBranchService.cs`

**1. Genel Bakış**
`ILibraryBranchService`, kütüphane şubeleri için sorgulama ve CRUD işlemlerine yönelik uygulama katmanı servis sözleşmesini tanımlar. Application katmanına aittir ve DTO’lar üzerinden veri taşır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<LibraryBranchDto?> GetByIdAsync(Guid id)` | Id ile tek şube bilgisini getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<LibraryBranchDto>> GetAllAsync()` | Tüm şubeleri listeler. |
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()` | Aktif şubeleri listeler. |
| CreateAsync | `Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)` | Yeni şube oluşturur ve oluşturulan şubeyi döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)` | Var olan şubeyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Şubeyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımlamaz. Dönüş tipleri asenkron Task tabanlıdır; `GetByIdAsync` `null` dönebilir. CRUD kapsamı: oluşturma, güncelleme, silme ve sorgulama sözleşmeleri belirlenmiştir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/üst katmanlar (ör. API) çağırır.
- **Aşağı akış:** Bu dosyada tanımlı değil.
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`.

**7. Eksikler ve Gözlemler**
- İmzalarda `CancellationToken` parametresi yok; uzun süren işlemler için iptal desteği eksik olabilir.
- `UpdateAsync`/`DeleteAsync` hata durumları (ör. bulunamadı) için sözleşmede net davranış (exception vs. no-op) belirtilmiyor.

---

Genel Değerlendirme
- Mevcut kod, Application katmanına ait servis kontratını net tanımlar; ancak diğer katmanlar (Domain, Infrastructure, API) bu depoda görünmüyor.
- Asenkron imzalar iyi; fakat iptal desteği (`CancellationToken`) ve hata sözleşmeleri (özelleşmiş sonuç tipleri veya istisna dokümantasyonu) standartlaştırılabilir.
- Listeleme uçları için sayfalama/sıralama/filtreleme parametreleri arayüz seviyesinde tanımlanabilir.### Project Overview
Proje adı: Library. Amaç: uygulama katmanında bildirimlerle ilgili sözleşmeleri tanımlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli — `Application` katmanı DTO’ları ve servis arabirimlerini içerir. Keşfedilen proje/assembly: `Library.Application` (iş kuralları sözleşmeleri ve DTO’lar). Görülen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application] (Interfaces, DTOs)

---

### `Library.Application/Interfaces/INotificationService.cs`

**1. Genel Bakış**
Müşteri bildirimleri için okuma, sayma, oluşturma, okundu işaretleme ve silme operasyonlarının sözleşmesini tanımlayan servis arabirimi. Mimari olarak Application katmanında yer alır ve Infrastructure’da sağlanacak implementasyonlara kontrat oluşturur.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait tüm bildirimleri döner. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)` | Müşteriye ait okunmamış bildirimleri döner. |
| GetUnreadCountAsync | `Task<int> GetUnreadCountAsync(Guid customerId)` | Okunmamış bildirim sayısını döner. |
| CreateAsync | `Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)` | Yeni bildirim oluşturur ve döner. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Bildirimi okundu işaretler. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm bildirimlerini okundu işaretler. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Bildirimi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arabirim — davranış yok. İş kuralları ve validasyonlar implementasyonlarda belirlenecektir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri, API controller’ları tüketebilir.
- **Aşağı akış:** `NotificationDto`, `CreateNotificationDto`
- **İlişkili tipler:** `Library.Application.DTOs.NotificationDto`, `Library.Application.DTOs.CreateNotificationDto`

**7. Eksikler ve Gözlemler**
- Okuma operasyonlarında sayfalama/sıralama sözleşmesi tanımlı değil; büyük veri setlerinde eksik olabilir.
- Hata ve yetkilendirme davranışları belirsiz; exception sözleşmesi dokümante edilmemiş.

---

Genel Değerlendirme
- Sadece Application katmanındaki bir arabirim görülebiliyor; implementasyonlar ve diğer katmanlar (Infrastructure, API, Domain) bu depodan anlaşılmıyor.
- DTO tanımları referanslanmış ancak içerikleri görünmüyor; validasyon ve zorunlu alanlar belirsiz.
- Listeleme uçlarında sayfalama/sıralama/filtreleme sözleşmesinin eklenmesi ölçeklenebilirlik için faydalı olur.
- Metotların hata senaryoları ve beklenen exception tipleri (ör. bulunamadı) netleştirilmeli.### Project Overview
Proje adı muhtemelen “Library”. Amaç: yayınevi (publisher) verilerini uygulama katmanında işlemek için bir servis sözleşmesi tanımlamak. Hedef framework bu dosyadan anlaşılamıyor. Mimari, `Library.Application` ad alanı ve servis arayüzü varlığına dayanarak Clean Architecture/N‑Katmanlı yaklaşımı ima ediyor: Application katmanında DTO’lar ve servis kontratları. Keşfedilen proje/derleme: Library.Application — uygulama iş kuralları, servis sözleşmeleri ve DTO’lar. Harici paketler bu dosyadan görünmüyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılamıyor.

### Architecture Diagram
[Consumers (bilinmiyor)]
   ↓
Library.Application (Interfaces, DTOs)

---
### `Library.Application/Interfaces/IPublisherService.cs`

**1. Genel Bakış**
`IPublisherService`, yayınevi varlıkları için uygulama katmanında CRUD benzeri operasyonları tanımlayan servis arayüzüdür. Amaç, `PublisherDto` tabanlı sorgulama ve `Create/Update` DTO’larıyla komut operasyonları için sözleşme sağlamaktır. Mimari olarak Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Yalnızca `Library.Application.DTOs` tiplerine başvurur.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<PublisherDto?> GetByIdAsync(Guid id)` | Kimliğe göre yayınevini getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<PublisherDto>> GetAllAsync()` | Tüm yayınevlerini döner. |
| GetActivePublishersAsync | `Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()` | Yalnızca aktif yayınevlerini döner. |
| CreateAsync | `Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)` | Yeni yayınevi oluşturur ve sonucu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)` | Mevcut yayınevini günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Yayınevini siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez. İş kuralları uygulamada belirlenir.
- `GetActivePublishersAsync` aktiflik filtresi beklentisi oluşturur; aktiflik ölçütü bu dosyadan anlaşılamıyor.
- `GetByIdAsync` `null` dönebilir; çağıranların `null` kontrolü yapması gerekir.

**6. Bağlantılar**
- **Yukarı akış:** Çağıranlar bu dosyadan anlaşılamıyor.
- **Aşağı akış:** `CreatePublisherDto`, `UpdatePublisherDto`, `PublisherDto`.
- **İlişkili tipler:** `Library.Application.DTOs` altındaki ilgili DTO’lar.

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametresi yok; uzun süren işlemler için iptal desteği eklenebilir.
- `UpdateAsync` sonuç döndürmüyor; güncellenen kaydın geri dönmesi veya etkilenen kayıt bilgisi gerekebilir.
- Silme semantiği (soft vs hard delete) belirsiz.

---
Genel Değerlendirme
- Yalnızca Application katmanından bir arayüz mevcut; diğer katmanlar (Domain, Infrastructure, API) bu depoda görünmüyor.
- Arayüz imzalarında iptal belirteci ve hata yönetimi sözleşmesi (ör. özel exception tipleri) tanımlı değil; sözleşme netliği artırılabilir.
- DTO ad alanına bağımlılık Application içinde tutarlı; ancak doğrulama kurallarının yeri bu dosyadan anlaşılamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane personel yönetimine yönelik Application katmanı sözleşmeleri; `Staff` işlemlerinin use case sözleşmelerini tanımlar. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen: Katmanlı mimari (muhtemelen Clean Architecture/N-Tier); bu dosyadan yalnızca Application katmanı görünüyor. Keşfedilen projeler/assembly’ler: Library.Application — Use case sözleşmeleri ve DTO referansları. Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (`Staff`) ile ilgili sorgulama ve komut operasyonları için Application katmanında bir servis sözleşmesi sağlar. Listeleme, aktif personeli getirme, oluşturma, güncelleme ve silme use case’lerini tanımlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını döner. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif personeli döner. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve sonucu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut personeli günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Personel kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir
- **Aşağı akış:** Yok
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (`Library.Application.DTOs`)

**7. Eksikler ve Gözlemler**
- Async imzalarda `CancellationToken` parametresi yok; uzun süren işlemlerde iptal desteği eksik olabilir.
- `UpdateAsync` ve `DeleteAsync` sonuç veya etki bilgisi döndürmüyor; bulunamadı/başarısız durumları için geri bildirim sınırlı.
- Listeleme operasyonlarında sayfalama/filtreleme sözleşmesi tanımlı değil.

---

Genel Değerlendirme
Mevcut kod yalnızca Application katmanında bir servis arayüzü içeriyor. Sözleşme net ancak iptal belirteci ve daha zengin sonuç tipleri (ör. `Result`, `bool`/`NotFound` ayrımı) eksik. Katmanlar arası bağımlılık, altyapı ve domain detayları bu depodan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: yazar varlıklarını DTO’lara maplemek ve CRUD akışlarında entity <-> DTO dönüşümünü kolaylaştırmak. Hedef çerçeve bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli; `Domain` (entity’ler) ve `Application` (DTO’lar, mapping) katmanları görülüyor. Bulunan projeler/assembly’ler: Library.Domain (varlıklar), Library.Application (DTO ve mapping). Harici paket kullanımı bu dosyadan görünmüyor. Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/AuthorMappings.cs`

**1. Genel Bakış**
`Author` entity’si ile `AuthorDto`/`CreateAuthorDto`/`UpdateAuthorDto` arasında dönüşüm sağlayan extension metotları içerir. Application katmanında, veri alışverişi ve güncelleme senaryolarında mapping sorumluluğu üstlenir.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.
- `Library.Application.DTOs` — DTO türleri
- `Library.Domain.Entities` — `Author` entity’si

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static AuthorDto ToDto(this Author author)` | `Author` bilgisini `AuthorDto`’ya dönüştürür; `BookCount`’u `Books?.Count ?? 0` ile hesaplar. |
| ToEntity | `public static Author ToEntity(this CreateAuthorDto dto)` | `CreateAuthorDto`’dan yeni `Author` oluşturur; `Id` ve `CreatedAt` değerlerini üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateAuthorDto dto, Author author)` | Var olan `Author`’ı günceller ve `UpdatedAt`’i UTC olarak ayarlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id = Guid.NewGuid()` ve `CreatedAt = DateTime.UtcNow` otomatik atanır.
- `ToDto`: `BookCount` `Books` koleksiyonu yoksa 0 olur.
- `UpdateEntity`: Alanları DTO’dan kopyalar, `UpdatedAt = DateTime.UtcNow`.
- Açık validasyon veya hata yönetimi yok; null kontrolleri yalnızca `Books` için yapılır.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Author`, `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`.
- İlişkili tipler: `Author` (Domain), ilgili DTO’lar (Application).

**7. Eksikler ve Gözlemler**
- Kimlik ve zaman damgası üretimi mapping katmanında yapılıyor; bu sorumlulukların Domain veya Persistence katmanında olması tercih edilebilir. Null DTO/Entity girdileri için koruyucu kontroller yok.

---
Genel Değerlendirme
- Clean Architecture’a uygun katman ayrımı sinyali var (Domain ve Application). Ancak tek dosyadan hareketle diğer katmanlar (Infrastructure, API) doğrulanamıyor.
- Mapping içinde kimlik/zaman üretimi sorumluluğu tartışmalı; tutarlılık için bu kararın proje genelinde netleştirilmesi önerilir.
- Null ve veri bütünlüğü validasyonları görünmüyor; servis veya domain seviyesinde tamamlanması gerekir.### Project Overview
Proje adı: Library. Amaç: Kitap kategorileri için DTO–Entity dönüşümleri sağlayarak Application ve Domain katmanları arasında veri aktarımını kolaylaştırmak. Hedef framework: Bu dosyadan anlaşılmıyor (muhtemelen modern .NET). Mimari: Clean Architecture eğilimli; `Library.Application` (iş kuralları/uygulama hizmetleri) Domain’e bağımlı, `Library.Domain` çekirdek varlıkları içerir. Keşfedilen projeler: `Library.Application` (DTO ve mapping), `Library.Domain` (entity’ler). Harici paketler: Bu dosyadan anlaşılmıyor. Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` entity’si ile ilgili DTO’lar arasında dönüşüm yapan extension method’ları içerir. Application katmanında yer alır ve veri aktarımını standardize eder; yeni kategori oluşturma, güncelleme ve okuma senaryolarına yönelik mapping sağlar.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` varlığını `BookCategoryDto`'ya map eder. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`'dan yeni `BookCategory` oluşturur (ID ve `CreatedAt` otomatik atanır). |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Mevcut `BookCategory` üzerinde alanları günceller ve `UpdatedAt`'i ayarlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id = Guid.NewGuid()` ve `CreatedAt = DateTime.UtcNow` otomatik atanır.
- `UpdateEntity`: `UpdatedAt = DateTime.UtcNow` ile güncelleme zamanı kaydedilir.
- Alanlar bire bir kopyalanır; null/boş kontrolü veya validasyon yapılmaz.
- `UpdateEntity` yan etkisi: geçirilen `category` nesnesini yerinde değiştirir.

**6. Bağlantılar**
- **Yukarı akış:** Application katmanında DTO–Entity dönüşümüne ihtiyaç duyan servis/handler akışları.
- **Aşağı akış:** `Library.Domain.Entities.BookCategory`, `Library.Application.DTOs.*`.
- **İlişkili tipler:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- Null referanslara karşı koruma/validasyon yok (`category`/`dto` null olabilir).
- Tarih atamalarında zaman kaynağı konfigüre edilebilir değil (sabit `DateTime.UtcNow`). 

Genel Değerlendirme
- Clean Architecture yönelimi belirgin: Application, Domain’e bağımlı. Ancak yalnızca mapping görülüyor; servis/handler, persistence veya API katmanları bu dosyadan anlaşılamıyor.
- Validasyon ve hata yönetimi mapping seviyesinde yok; bu sorumluluk muhtemelen farklı katmanlarda ele alınmalı.
- Zaman/ID üretimi doğrudan yapılmış; test edilebilirlik için soyut zaman/ID sağlayıcıları ileride tercih edilebilir.### Project Overview
Proje: Library — kütüphane ödünç verme süreçlerinin yönetimi (ödünç alma, iade, durum izleme). Katmanlar isimlendirmeden Clean Architecture yaklaşımı (Domain ve Application) seziliyor. Hedef framework bu dosyadan anlaşılmıyor. Görülen katmanlar: Domain (entity ve enum’lar), Application (DTO ve mapping). Application katmanı Domain tiplerini DTO’lara dönüştürüp temel iş varsayımlarını uygular. Dış bağımlılık görünmüyor. Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Mappings/BookLoanMappings.cs`

**1. Genel Bakış**
`BookLoan` entity’si ile `BookLoanDto`/`CreateBookLoanDto` arasında dönüşüm sağlayan extension mapping sınıfıdır. Application katmanında yer alır ve okuma/yazma akışlarında DTO <-> Entity köprüsü kurar.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookLoanDto ToDto(this BookLoan loan)` | `BookLoan` nesnesini görüntü amaçlı `BookLoanDto`’ya map eder. |
| ToEntity | `public static BookLoan ToEntity(this CreateBookLoanDto dto)` | `CreateBookLoanDto`’dan yeni bir `BookLoan` entity’si oluşturur. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `BookTitle`/`BookISBN` null ise `string.Empty`; `CustomerName` bulunamazsa `string.Empty`; `ProcessedByStaffName` yoksa `null`.
- `IsOverdue`: `loan.Status == LoanStatus.Active && loan.DueDate < DateTime.UtcNow` ile hesaplanır.
- `ToEntity`: `Id = Guid.NewGuid()`, `LoanDate = DateTime.UtcNow`, `DueDate = UtcNow + dto.LoanDurationDays`.
- Varsayılanlar: `Status = LoanStatus.Active`, `RenewalCount = 0`, `MaxRenewals = 2`, `CreatedAt = DateTime.UtcNow`.
- `Notes` DTO’dan aktarılır.

**6. Bağlantılar**
- **Yukarı akış:** Doğrudan extension metot olarak çağrılır (ör. Application servisleri/handler’ları).
- **Aşağı akış:** `Library.Domain.Entities.BookLoan`, `Library.Application.DTOs.*`, `Library.Domain.Enums.LoanStatus`.
- **İlişkili tipler:** `BookLoan`, `Book`, `Customer`, `Staff` (navigasyonlar), `BookLoanDto`, `CreateBookLoanDto`.

**7. Eksikler ve Gözlemler**
- Zaman kaynağı (`DateTime.UtcNow`) sabit; test edilebilirlik için `IClock` gibi bir soyutlama tercih edilebilir.
- `MaxRenewals = 2` sabit değer; konfigürasyona taşınması daha esnek olur.
- Null/empty tutarsızlığı: `ProcessedByStaffName` null dönerken diğer metinsel alanlar `string.Empty` kullanıyor. Tutarlılık gözden geçirilebilir. 

---

### Genel Değerlendirme
- Clean Architecture çizgisine uygun bağımlılık yönü (Application -> Domain) korunuyor.
- Mapping’lerde iş kuralı gömülü sabitler ve zaman kullanımı test/konfigürasyon açısından iyileştirilebilir.
- Null/empty tutarlılığı için ortak bir string normalizasyon stratejisi önerilir.
- Katmanlar arası bağımlılıklar net; ek paket/çerçeve görünmüyor.### Project Overview
Proje, kütüphane alanına yönelik katmanlı bir .NET uygulaması izlenimi veriyor. Amaç: Domain `Book` varlığını Application katmanındaki DTO’larla dönüştürmek. Hedef framework bu dosyadan anlaşılmıyor. Mimari: N‑Tier/Layers — Domain (entity’ler), Application (DTO ve mapping). Keşfedilen projeler: `Library.Application` (DTO/mapping), `Library.Domain` (entity). Harici paketler ve konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` entity’si ile `BookDto`/`CreateBookDto`/`UpdateBookDto` arasında dönüşüm sağlayan extension method’ları içeren `static` bir yardımcı sınıftır. Uygulamanın Application katmanında yer alır; entity-DTO ayrımını korur ve veri akışında mapleme sorumluluğunu üstlenir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` entity’sini `BookDto`’ya dönüştürür; ilişkili ad alanlarını birleştirir. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto`’dan yeni `Book` entity örneği üretir; kimlik ve zaman damgası atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan `Book`’u `UpdateBookDto` ile günceller; güncelleme zamanını set eder. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `AuthorName` “`FirstName LastName`” biçiminde; ilişkiler `null` ise `string.Empty` veya `null` atanır.
- `ToEntity`: `Id = Guid.NewGuid()`, `IsAvailable = true`, `AvailableCopies = TotalCopies`, `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`: Alanların tamamını DTO değerleriyle günceller; `UpdatedAt = DateTime.UtcNow`.
- Null guard/validasyon yok; DTO alanlarının doğruluğu bu seviyede kontrol edilmez.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.
- **İlişkili tipler:** `Book`, `BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- Extension metodlarında `book`/`dto` için null kontrolü yok; olası `ArgumentNullException` koruması eklenebilir.
- `ToDto` içinde ilişkili nesneler yüklü değilse ad alanları boş/`null` kalır; lazy loading beklentisi varsa belirsizlik yaratabilir.

---
### Genel Değerlendirme
Kod, Application ve Domain arasında net bir mapping sınırı kuruyor. Validasyon, hata yönetimi ve ilişki yükleme stratejileri bu seviyede tanımlı değil; bu da sorumluluk ayrımına uygun ancak çağıran katmanlarda ek önlem gerektirir. Framework sürümü, paket bağımlılıkları ve konfigürasyonlar bu koddan çıkarılamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane rezervasyon akışında domain `BookReservation` varlığını uygulama katmanındaki DTO’larla dönüştürmek. Hedef framework bu dosyadan anlaşılmıyor. Mimari, katmanlı/Clean yaklaşımı izleniyor: `Library.Domain` (entity/enum), `Library.Application` (DTO, mapping). Dış paketler bu dosyadan görünmüyor. Yapılandırma/connection string bilgisi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/BookReservationMappings.cs`

**1. Genel Bakış**
`BookReservation` ile `BookReservationDto`/`CreateBookReservationDto` arasında iki yönlü mapping sağlayan extension metodlarını içerir. Uygulama katmanında DTO-Entity dönüşümünü merkezileştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookReservationDto ToDto(this BookReservation reservation)` | Domain rezervasyonunu gösterim/aktarımı için DTO’ya dönüştürür. |
| ToEntity | `public static BookReservation ToEntity(this CreateBookReservationDto dto)` | Oluşturma DTO’sundan yeni `BookReservation` entity’si üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book?.Title` yoksa `BookTitle` boş string atanır.
- `Customer` yoksa `CustomerName` boş string; varsa ad ve soyad birleştirilir.
- `ToEntity`: `Id = Guid.NewGuid()`.
- `ReservationDate = DateTime.UtcNow`.
- `ExpiryDate = DateTime.UtcNow.AddDays(3)` sabit 3 gün.
- `Status = ReservationStatus.Pending`.
- `CreatedAt = DateTime.UtcNow`.
- `Notes` DTO’dan aktarılır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.BookReservation`, `Library.Domain.Enums.ReservationStatus`, `Library.Application.DTOs.BookReservationDto`, `Library.Application.DTOs.CreateBookReservationDto`.
- **İlişkili tipler:** `Book`, `Customer` navigation alanları (başlık ve ad/soyadı için kullanılır).

**7. Eksikler ve Gözlemler**
- Zaman/expiry için `DateTime.UtcNow` doğrudan kullanılıyor; test edilebilirlik için saat/konfigürasyon soyutlaması tercih edilebilir.
- 3 günlük `ExpiryDate` değeri sabit; konfigüre edilebilir olması beklenebilir.

---

### Genel Değerlendirme
Kod, Application ↔ Domain dönüşümlerini net ve basit tutuyor. Sabit süre ve doğrudan zaman üretimi, test/konfigürasyon açısından iyileştirilebilir. Daha geniş projede, mapping’lerin tutarlılığı için merkezi bir saat sağlayıcısı ve konfigürasyon anahtarları önerilir. Dış bağımlılık/paket izi görülmüyor; kapsam yalnızca mapping.### Project Overview
- Ad: Library (çıkarım: `Library.Application`, `Library.Domain`)
- Amaç: Kitap yorumları için Application katmanında DTO-Entity dönüşümleri sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean yaklaşım. Domain (entity ve çekirdek modeller) → Application (DTO, mapping, iş akışı).
- Projeler:
  - Library.Domain — Entity tanımları (ör. `BookReview`)
  - Library.Application — DTO’lar ve mapping’ler (ör. `BookReviewMappings`)
- Harici paketler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Application

---
### `Library.Application/Mappings/BookReviewMappings.cs`

**1. Genel Bakış**
`BookReview` entity’si ile ilgili DTO’lara dönüşüm sağlayan extension method’ları içerir. Application katmanında DTO-Entity mapping sorumluluğunu üstlenir; Domain’e bağımlıdır ancak tersine bağımlılık yoktur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookReviewDto ToDto(this BookReview review)` | `BookReview` entity’sini `BookReviewDto`’ya dönüştürür. |
| ToEntity | `public static BookReview ToEntity(this CreateBookReviewDto dto)` | `CreateBookReviewDto`’dan yeni `BookReview` entity örneği üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookReviewDto dto, BookReview review)` | `UpdateBookReviewDto` alanlarını mevcut `BookReview`’e uygular. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `Book?.Title` yoksa `string.Empty`; `Customer` yoksa `CustomerName` `string.Empty`.
- `ToEntity`: `Id = Guid.NewGuid()`, `IsApproved = false`, `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`: `Rating`, `Title`, `Comment` güncellenir; `UpdatedAt = DateTime.UtcNow`.
- Her iki yönde tarih damgaları UTC olarak atanır.
- Validasyon mantığı içermez; sadece alan kopyalama ve varsayılan atamalar yapar.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Entities.BookReview`, `Library.Application.DTOs.*`
- İlişkili tipler: `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`, `BookReview`

**7. Eksikler ve Gözlemler**
- `Rating` için aralık kontrolü yok (ör. 1–5); validasyon başka katmanda bekleniyor olabilir.

---
Genel Değerlendirme
- Clean/katmanlı yapıya uygun bağımlılık yönü: Application → Domain. 
- Mapping’ler sade ve yan etkiler net (UTC zaman damgaları, yeni GUID). 
- Validasyonun yeri bu dosyadan görünmüyor; Rating ve metin alanları için ayrı bir validasyon katmanı/kuralları önerilir. 
- Harici paket ve konfigürasyon izine rastlanmadı; proje çapında standart bir mapping kütüphanesi (ör. AutoMapper) kullanımı değerlendirilebilir.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library”dir. Amaç, kütüphane müşterileri için DTO–Entity dönüşümleri sağlayarak uygulama katmanında veri aktarımını düzenlemektir. Hedef çatı .NET (C#) ve katmanlar `Library.Application` ile `Library.Domain` üzerinden ayrışmaktadır. Mimari desen Clean Architecture/N‑Tier yönündedir: Domain (Entity/Enum), Application (DTO, Mapping). Keşfedilen projeler/assembly’ler: `Library.Application` (DTO ve mapping), `Library.Domain` (entity ve enum). Görünür harici paket yok. Bu dosyadan konfigürasyon gereksinimleri anlaşılamıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` entity’si ile `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` arasında dönüşüm sağlayan extension mapping sınıfıdır. Application katmanında yer alır ve entity–DTO ayrışmasını korur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`)
- `Library.Domain.Entities.Customer` — Domain entity
- `Library.Domain.Enums.MembershipType` — Üyelik türü enum’ı

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` entity’sini `CustomerDto`’ya dönüştürür. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`’dan yeni `Customer` entity oluşturur ve varsayılan alanları ayarlar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` entity alanlarını `UpdateCustomerDto` ile günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`:
  - `Id = Guid.NewGuid()` otomatik üretilir.
  - `MembershipNumber = "LIB-" + Guid[..8]` formatında benzersiz numara atanır.
  - `RegisteredDate = DateTime.UtcNow`, `MembershipExpiryDate = UtcNow + 1 yıl`.
  - `IsActive = true` varsayılan.
  - `MaxBooksAllowed`, `MembershipType`’a göre: `Premium=10`, `Standard=7`, `Student=5`, `Senior=7`, diğer=5.
  - `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`:
  - Alanları DTO’dan kopyalar; `UpdatedAt = DateTime.UtcNow`.
- DTO — davranış yok; dönüşümler yalnızca alan eşleme ve varsayılan değer atamasıdır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Customer`, `MembershipType`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.
- **İlişkili tipler:** `Library.Domain.Entities.Customer`, `Library.Application.DTOs.*`, `Library.Domain.Enums.MembershipType`.

**7. Eksikler ve Gözlemler**
- `ToDto` içinde `PostalCode` eşlenmiyor; DTO’da alan yoksa doğal, ancak alan varsa asimetri olabilir (bu dosyadan teyit edilemiyor).
- Null kontrolü/validasyon yok; null `customer` veya `dto` verilirse `NullReferenceException` oluşabilir.### Project Overview
Proje adı: Library. Amaç: kütüphane alan nesneleri için uygulama katmanında DTO–Entity dönüşümleri sağlamak. Hedef çatı bu dosyadan anlaşılmıyor. Mimari: Clean Architecture eğilimli (Application, Domain katmanları görülüyor). Projeler: Library.Domain (entities, enums), Library.Application (DTO, mapping). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/UI (varsayım) -> Library.Application -> Library.Domain

---

### `Library.Application/Mappings/FineMappings.cs`

**1. Genel Bakış**
`Fine` entity’si ile `FineDto`/`CreateFineDto` arasında iki yönlü dönüşüm sağlayan extension metotlarını içerir. Uygulama katmanında DTO–Entity ayrımını korur ve temel default/başlatma değerlerini atar. Clean Architecture içinde Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static FineDto ToDto(this Fine fine)` | `Fine` entity’sini güvenli null kontrolleriyle `FineDto`’ya dönüştürür. |
| ToEntity | `public static Fine ToEntity(this CreateFineDto dto)` | `CreateFineDto`’dan yeni bir `Fine` entity’si üretir ve bazı alanları otomatik başlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `CustomerName` null ise `string.Empty`; `BookTitle` null zincirinde `string.Empty` döner.
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir.
- `ToEntity`: `Status` alanını `FineStatus.Pending` olarak varsayar.
- `ToEntity`: `CreatedAt` alanını `DateTime.UtcNow` ile başlatır.
- `PaidDate` ve `PaymentMethod` oluşturma sırasında set edilmez (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Entities.Fine`, `Library.Domain.Enums.FineStatus`, `Library.Application.DTOs.FineDto`, `Library.Application.DTOs.CreateFineDto`.
- İlişkili tipler: `Fine`, `FineDto`, `CreateFineDto`.

**7. Eksikler ve Gözlemler**
- `ToDto` parametresi için null koruması yok; `fine` null ise `NullReferenceException` oluşabilir.
- Oluşturma sırasında `PaymentMethod` gibi alanlar map edilmez; ihtiyaçsa eksik olabilir (bu dosyadan anlaşılmıyor).

---

### Genel Değerlendirme
Kod, Application → Domain bağımlılık yönünü koruyor ve mapping mantığını merkezileştiriyor. Null güvenliği giriş parametresi seviyesinde iyileştirilebilir. Mimari katmanlar dışında ek projeler ve harici bağımlılıklar bu dosyadan tespit edilemiyor.### Project Overview
Proje adı “Library” ad alanlarından anlaşılmaktadır. Amaç: kütüphane şubesi gibi domain varlıklarını DTO’lara maplemek ve uygulama katmanında veri aktarımını düzenlemek. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen Clean Architecture: Domain (entity’ler), Application (DTO ve mapping). Keşfedilen projeler: Library.Domain (entity’ler), Library.Application (DTO, mapping). Dış bağımlılıklar görünmüyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/LibraryBranchMappings.cs`

**1. Genel Bakış**
`LibraryBranch` entity’si ile ilgili DTO’lar arasında iki yönlü dönüşüm yapan extension method’lar içerir. Application katmanında, domain verisini API/uygulama sınırlarına uygun hale getirir ve güncelleme işlemlerinde alan atamalarını merkezileştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static LibraryBranchDto ToDto(this LibraryBranch branch)` | `LibraryBranch` içeriğini özet bilgilerle `LibraryBranchDto`'ya mapler. |
| ToEntity | `public static LibraryBranch ToEntity(this CreateLibraryBranchDto dto)` | Create DTO’dan yeni `LibraryBranch` entity’si üretir ve varsayılan alanları atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateLibraryBranchDto dto, LibraryBranch branch)` | Update DTO değerlerini mevcut entity üzerine uygular ve güncellenme zamanını set eder. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `Staff?.Count ?? 0`, `Books?.Count ?? 0` ile null güvenli sayım yapar.
- `ToEntity`: `Id = Guid.NewGuid()`, `IsActive = true`, `CreatedAt = DateTime.UtcNow` varsayılanları atar.
- `UpdateEntity`: Alanları DTO’dan kopyalar, `UpdatedAt = DateTime.UtcNow` set eder.
- Validasyon veya hata yönetimi bu dosyada yok; null parametreler kontrol edilmiyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.LibraryBranch`, `Library.Application.DTOs.*`
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `LibraryBranch`

**7. Eksikler ve Gözlemler**
- Null parametreler için guard/validasyon yok; `branch` veya `dto` null ise `NullReferenceException` oluşabilir.
- Varsayılan `IsActive = true` kuralı iş gereksinimi olarak belgelendirilmeli.

---
### Genel Değerlendirme
Kod, Clean Architecture prensipleriyle uyumlu basit bir mapping katmanı sunuyor. Null güvenliği ve input validasyonu eksik; özellikle extension method’larda guard eklenmesi faydalı olur. Zaman damgaları ve yeni kimlik üretimi merkezi olarak doğru yönetiliyor. Dış bağımlılık ve konfigürasyon görünmüyor; hedef framework ve diğer katmanlar bu repo kesitinden belirlenemiyor.### Project Overview
Proje adı: Library (bu dosyadan çıkarılan namespace’lere göre). Amaç: Bildirim entity’si ile DTO’lar arasında mapping sağlamak. Hedef framework: .NET (sürüm bu dosyadan anlaşılmıyor).
Mimari: Clean Architecture tarzı katmanlama. Application katmanı DTO ve mapping’leri barındırır; Domain katmanı entity’leri içerir.
Projeler/Assembly’ler: Library.Application (DTO, mapping), Library.Domain (Entities).
Harici paketler: Bu dosyadan görünmüyor.
Yapılandırma: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/NotificationMappings.cs`

**1. Genel Bakış**
`Notification` entity’si ile DTO’ları (`NotificationDto`, `CreateNotificationDto`) arasında dönüştürme yapan extension mapping sınıfıdır. Uygulamanın Application katmanında yer alır ve entity-DTO ayrımını korur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static NotificationDto ToDto(this Notification notification)` | `Notification` entity’sini `NotificationDto`’ya dönüştürür. |
| ToEntity | `public static Notification ToEntity(this CreateNotificationDto dto)` | `CreateNotificationDto`’dan yeni `Notification` entity’si üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir.
- `ToEntity`: `IsRead` başlangıçta `false` atanır.
- `ToEntity`: `SentAt` ve `CreatedAt` alanları `DateTime.UtcNow` olarak ayarlanır.
- `ToDto`: Entity içindeki alanları doğrudan DTO’ya kopyalar (`Id`, `CustomerId`, `Title`, `Message`, `Type`, `IsRead`, `ReadAt`, `CreatedAt`).
- `SentAt` entity’de ayarlanır; DTO’ya yönelik eşlemesi bu dosyada yapılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu mapping’leri çağıran katman/servisler bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Application.DTOs` (`NotificationDto`, `CreateNotificationDto`), `Library.Domain.Entities` (`Notification`).
- **İlişkili tipler:** `Notification`, `NotificationDto`, `CreateNotificationDto`.

**7. Eksikler ve Gözlemler**
- `SentAt` alanı entity’de set edilirken DTO’ya haritalama yok; DTO’da karşılığı varsa eksik olabilir (bu dosyadan net değil).

---
Genel Değerlendirme
Kod, Application ve Domain ayrımına uygun basit bir mapping sağlayıcı sunuyor. Harici paket, konfigürasyon veya altyapı bağımlılığı görünmüyor. Zaman damgalarının `UtcNow` ile üretilmesi tutarlı. DTO alanlarıyla entity alanları arasında kapsam uyumu bu dosyadan tam doğrulanamıyor; özellikle `SentAt` için karşılık kontrol edilmeli.### Project Overview
Proje: Library. Amaç: Yayıncı (`Publisher`) varlığını Application katmanındaki DTO’larla eşleyerek CRUD akışlarını desteklemek. Hedef çatı: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: Katmanlı/Clean Architecture yaklaşımı (Application ↔ Domain ayrımı net). Keşfedilen projeler: Library.Application (DTO ve mapping), Library.Domain (entity’ler). Harici paketler: Bu dosyadan görünmüyor. Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/PublisherMappings.cs`

**1. Genel Bakış**
`Publisher` entity’si ile `PublisherDto`/`CreatePublisherDto`/`UpdatePublisherDto` arasında dönüşüm sağlayan extension mapping’lerdir. Application katmanında, komut/sorgu işleyicilerinin veri transferi ve kalıcı modele projeksiyonu için kullanılır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri için
- `Library.Domain.Entities` — `Publisher` entity’si için

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static PublisherDto ToDto(this Publisher publisher)` | `Publisher` varlığını `PublisherDto`'ya projekte eder; `BookCount` için koleksiyon sayısını hesaplar. |
| ToEntity | `public static Publisher ToEntity(this CreatePublisherDto dto)` | `CreatePublisherDto`’dan yeni `Publisher` oluşturur; `Id`, `IsActive`, `CreatedAt` gibi alanları varsayılanlar ile ayarlar. |
| UpdateEntity | `public static void UpdateEntity(this UpdatePublisherDto dto, Publisher publisher)` | Mevcut `Publisher`’ı `UpdatePublisherDto` değerleriyle günceller; `UpdatedAt`’i günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `BookCount` için `publisher.Books?.Count ?? 0` ile null güvenli sayım.
- `ToEntity`: `Id = Guid.NewGuid()`, `IsActive = true`, `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`: `UpdatedAt = DateTime.UtcNow` otomatik set edilir.
- Girdi null kontrolleri veya iş kuralı validasyonları yok; null parametreler `NullReferenceException` doğurabilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Publisher` (Domain), `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto` (Application DTOs).
- **İlişkili tipler:** `Publisher`, `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`.

**7. Eksikler ve Gözlemler**
- Extension metodlarda null guard/validasyon yok; null parametrelerde hata riski var.
- `Address` alanı `ToDto` çıktısında yer almıyor; DTO ile entity alanları arasında kısmi eşleşme olabilir. Bu kasıtlı değilse veri kaybı yaşanabilir.

---
Genel Değerlendirme
- Clean Architecture uyumlu katman ayrımı izleniyor (Application ↔ Domain). Ancak yalnızca mapping dosyası göründüğü için daha geniş mimari unsurlar (Infrastructure, API, DI) doğrulanamıyor.
- Mapping’lerde null koruması ve temel validasyon eksik; güvenli kullanım için guard’lar veya merkezi validasyon önerilir.
- DTO ve entity alan uyumu gözden geçirilmeli (ör. `Address` DTO projeksiyonu).### Project Overview
Proje adı: Library. Amaç: Kütüphane personel yönetimi için entity–DTO dönüştürmeleri sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli; `Application` katmanı `Domain` varlıklarını DTO’lara map’ler. Keşfedilen projeler: `Library.Application` (uygulama mantığı, mapping) ve `Library.Domain` (entity’ler). Dış paketler bu dosyadan görünmüyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  ↑
Library.Application (Mappings, DTO kullanımı)

---
### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` entity’si ile `StaffDto`/`CreateStaffDto`/`UpdateStaffDto` arasında dönüşüm sağlayan extension method’lar içerir. Uygulama (Application) katmanında, veri aktarım sınırları için mapping sorumluluğunu üstlenir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` entity’sini `StaffDto`’ya map’ler; şube adını null güvenli biçimde taşır. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni `Staff` entity’si üretir; kimlik ve çalışan numarasını oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Var olan `Staff` üzerinde güncellemeleri uygular ve `UpdatedAt`’i ayarlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id = Guid.NewGuid()` üretilir.
- `EmployeeNumber`: `"EMP-" + Guid.NewGuid().ToString("N")[..6].ToUpper()` formatında rastgele 6 karakterli kod.
- `IsActive` varsayılanı `true`.
- `CreatedAt = DateTime.UtcNow`; `UpdateEntity` içinde `UpdatedAt = DateTime.UtcNow`.
- `ToDto`: `LibraryBranch?.Name` ile null güvenli şube adı aktarımı.
- Validasyon veya çakışma kontrolü (ör. `EmployeeNumber` benzersizliği) yok.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Application.DTOs` (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`), `Library.Domain.Entities` (`Staff`).
- **İlişkili tipler:** `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- Girdi null kontrolleri yok; `staff`/`dto` null ise `NullReferenceException` oluşabilir.
- `EmployeeNumber` benzersizlik kontrolü yok; olası çakışmalar ele alınmıyor.
- Kimlik ve varsayılanların Application katmanında üretilmesi, domain kuralları açısından tartışmalı olabilir.

---
Genel Değerlendirme
- Clean Architecture’a işaret eden katman ayrımı mevcut (Application ↔ Domain), ancak hedef framework, paketler ve diğer katmanlar (Infrastructure, API) görünmüyor.
- Mapping katmanında entity kimliği ve iş kurallarına yakın varsayılanlar üretiliyor; bunlar domain veya factory’lere taşınabilir.
- Null güvenliği ve benzersizlik/doğrulama kontrolleri eklenerek sağlamlık artırılabilir.### Project Overview
Proje adı: Library. Amaç: yazar yönetimi için uygulama servisi katmanı sağlamak (CRUD, arama). Hedef framework bu dosyadan anlaşılmıyor. Mimari yapı Clean Architecture’a benzer: Application katmanı `DTO` ve mapping ile çalışır, Domain katmanındaki repository arayüzlerine bağımlıdır ve dış dünyaya `IAuthorService` sunar.

- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama hizmetleri, DTO’lar, mapping, özel istisnalar.
  - Library.Domain.Interfaces — Repository arayüzleri.
  - Library.Domain.Entities — Domain varlıkları (adla referanslanıyor).
- Dış paketler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  ├─ uses → Library.Domain.Interfaces
  ├─ uses → Library.Domain.Entities (ad referansı)
  ├─ internal → Library.Application.DTOs, Library.Application.Mappings
  └─ exposed as → IAuthorService (kullanıcı katmanı bu dosyadan anlaşılmıyor)

---
### `Library.Application/Services/AuthorService.cs`

**1. Genel Bakış**
`AuthorService`, yazarlar için CRUD ve arama işlemlerini sağlayan uygulama servisidir. Application katmanında yer alır ve Domain katmanındaki `IAuthorRepository` üzerinden veri erişimini soyutlar. DTO mapping işlemlerini kullanarak entity-DTO dönüşümleri yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IAuthorService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IAuthorRepository` — Yazar verilerine erişim (getir, ekle, güncelle, sil, arama).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `AuthorService(IAuthorRepository authorRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<AuthorDto?> GetByIdAsync(Guid id)` | Yazarı kitaplarıyla birlikte getirip DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<AuthorDto>> GetAllAsync()` | Tüm yazarları listeler ve DTO’ya map eder. |
| SearchAsync | `Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)` | Arama terimine göre yazarları döndürür. |
| CreateAsync | `Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)` | Yeni yazar oluşturur ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)` | Mevcut yazarı günceller; yoksa hata fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Yazarı siler; yoksa hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync`: Yazar yoksa `NotFoundException` fırlatır.
- `DeleteAsync`: Varlık yoksa `NotFoundException` fırlatır.
- DTO ↔ Entity dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` extension’larıyla yapılır.
- `GetByIdAsync` kitaplarıyla birlikte yükleme için `GetWithBooksAsync` kullanır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; `IAuthorService` tüketicileri (ör. API Controller) bu servisi çağırır.
- **Aşağı akış:** `IAuthorRepository`, mapping extension’ları, `NotFoundException`.
- **İlişkili tipler:** `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`, `Domain.Entities.Author`, `IAuthorService`, `IAuthorRepository`.

**7. Eksikler ve Gözlemler**
- `SearchAsync` için boş/null arama terimine yönelik validasyon bu dosyada yok.
- Listeleme/arama için sayfalama desteği görünmüyor.

---
Genel Değerlendirme
- Uygulama servisi, repository ve DTO/mapping kullanımıyla katmanlar arası ayrımı net uyguluyor.
- Hata yönetimi “bulunamadı” senaryosunda tutarlı; ancak input validasyonu ve sayfalama gibi sınırlandırmalar eksik.
- Dış bağımlılıklar ve konfigürasyon gereksinimleri bu dosyadan anlaşılamıyor; proje genelinde belgelendirme önerilir.### Project Overview
Proje adı: Library. Amaç: kitap kategorileri için uygulama katmanı hizmetleri ve iş kuralları sağlamak. Hedef çatı: .NET (katman adlarından Clean Architecture yaklaşımı; kesin TFM bu dosyadan anlaşılmıyor). Mimari: Clean Architecture — Domain (entitiy ve repository sözleşmeleri), Application (DTO, mapping, servisler), Infrastructure (repository implementasyonları, veri erişimi), API/Presentation (uç noktalar).

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri ve `Repository` arayüzleri.
- Library.Application — DTO’lar, servisler, mapping ve uygulama istisnaları.

Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
API/Presentation -> Application -> Domain
Infrastructure -> Domain
API/Presentation -> Application -> Infrastructure (DI üzerinden, çalışma zamanında)

---
### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD odaklı uygulama hizmetlerini sağlayan Application katmanı servisidir. Domain’deki `IBookCategoryRepository` üzerinden veri erişimini soyutlar, DTO-Entity mapping işlemlerini koordine eder ve çakışma/ bulunamadı gibi iş kuralı istisnalarını üretir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori veri erişimi için repository sözleşmesi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Id ile kategoriyi getirir ve DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri listeler ve DTO’ya map eder. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | İsim çakışmasını kontrol ederek yeni kategori oluşturur. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Kategoriyi bulur, DTO ile günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Var olup olmadığını kontrol ederek kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Oluşturma öncesi `GetByNameAsync` ile isim benzersizliği kontrolü; var ise `ConflictException`.
- Güncellemede id ile kategori bulunamazsa `NotFoundException`.
- Silmede varlık yoksa `NotFoundException`.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla DTO-Entity dönüştürmeleri.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir (muhtemelen API Controller veya Application katmanı tüketir).
- **Aşağı akış:** `IBookCategoryRepository`.
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `ConflictException`, `NotFoundException`, mapping uzantıları (`Library.Application.Mappings`), `Domain.Entities.BookCategory`.

Genel Değerlendirme
- Servis, Application katmanında iş kurallarını konumlandırıp repository’yi soyutlayarak Clean Architecture’a uygun görünüyor.
- Exception tipleriyle tutarlı hata modellemesi mevcut. Mapping uzantılarıyla ayrışma iyi. Konfigürasyon veya dış bağımlılık görünmüyor; altyapı ve API katmanları bu koddaki sözleşmelere göre şekillenmeli.### Project Overview
Proje adı: Library. Amaç: kütüphane ödünç alma süreçlerini yönetmek (ödünç oluşturma, iade, uzatma, sorgulama). Hedef framework: Bu dosyadan kesin değil; modern .NET (async/Task bazlı) kullanımı görülüyor. Mimari: Clean Architecture eğilimi; `Application` katmanı `Domain`’a bağımlı, repository arabirimleri `Domain`’da. Keşfedilen projeler: `Library.Application` (uygulama servisleri, DTO, mapping, istisnalar), `Library.Domain` (entity, enum, repository arabirimleri). Dış bağımlılıklar: Bu dosyada görünmüyor. Konfigürasyon: Bu dosyada görünmüyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Services/BookLoanService.cs`

**1. Genel Bakış**
`BookLoanService`, kitap ödünç alma yaşam döngüsünü yönetir: oluşturma, iade, uzatma ve sorgulamalar. Application katmanında yer alır, `Domain` arabirimleri üzerinden persistence’a erişir ve DTO–Entity mapping kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygılar:** `Library.Application.Interfaces.IBookLoanService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookLoanRepository` — Ödünç kayıtlarına erişim ve sorgular
- `IBookRepository` — Kitap stok/uygunluk yönetimi
- `ICustomerRepository` — Müşteri üyelik/limit doğrulamaları

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| .ctor | `BookLoanService(IBookLoanRepository, IBookRepository, ICustomerRepository)` | Repository bağımlılıklarını alır. |
| GetByIdAsync | `Task<BookLoanDto?> GetByIdAsync(Guid id)` | Tek ödünç kaydını detaylarıyla döndürür. |
| GetAllAsync | `Task<IEnumerable<BookLoanDto>> GetAllAsync()` | Tüm ödünç kayıtlarını listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait ödünçleri listeler. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()` | Aktif ödünçleri listeler. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()` | Gecikmiş ödünçleri listeler. |
| GetByStatusAsync | `Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)` | Duruma göre ödünçleri listeler. |
| CreateAsync | `Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)` | İş kurallarıyla yeni ödünç oluşturur ve stok günceller. |
| ReturnBookAsync | `Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)` | İade işlemini gerçekleştirir, stokları geri artırır. |
| RenewLoanAsync | `Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)` | Aktif ödünç için vade uzatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Ödünç kaydını siler (mevcut değilse hata). |

**5. Temel Davranışlar ve İş Kuralları**
- Ödünç oluşturma: Kitap mevcut kopya > 0 olmalı; müşteri aktif olmalı; aktif ödünç sayısı `MaxBooksAllowed`’ı aşmamalı; aksi halde `BadRequestException`.
- Kaynak doğrulama: Kitap/müşteri/ödünç bulunamazsa `NotFoundException`.
- Stok yönetimi: Oluşturmada `AvailableCopies--`; sıfırsa `IsAvailable=false`. İadede `AvailableCopies++`, `IsAvailable=true`.
- İade: Yalnızca `Active`/`Overdue` iade edilebilir; aksi halde `BadRequestException`.
- Uzatma: Yalnızca `Active`; `RenewalCount < MaxRenewals` olmalı; aksi halde `BadRequestException`. `DueDate` güncellenir, `RenewalCount++`, `UpdatedAt` set edilir.
- Mapping: Entity↔DTO dönüşümü `ToDto`/`ToEntity` extension’larıyla.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözülür.
- Aşağı akış: `IBookLoanRepository`, `IBookRepository`, `ICustomerRepository`.
- İlişkili tipler: `BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`, `LoanStatus`, `Domain.Entities.Book`, `Domain.Entities.Customer`, `Domain.Entities.BookLoan`.

**7. Eksikler ve Gözlemler**
- Transactional bütünlük: Ödünç oluşturma/iade sırasında birden çok repository çağrısı var; tek bir işlem kapsamında yönetim bu dosyadan görünmüyor (potansiyel tutarsızlık riski).

---
Genel Değerlendirme
- Clean Architecture yönelimi net: Application, Domain arabirimlerine dayanıyor ve mapping/DTO kullanıyor.
- Transaction yönetimine dair işaret yok; kritik stok güncellemelerinde birim iş (transaction) ihtiyacı olabilir.
- Dış bağımlılıklar ve konfigürasyonlar bu kesitte görünmüyor; çözüm genelinde belgelendirme faydalı olacaktır.### Project Overview
Proje adı: Library. Amaç: kütüphane rezervasyon işlevlerini uygulama katmanında yönetmek (oluşturma, iptal, tamamlama, sorgulama). Hedef çatı bu dosyadan anlaşılmıyor. Mimari katmanlar koddan çıkarıma göre Domain ve Application mevcut. Uygulama katmanı, Domain tiplerini ve sözleşmelerini kullanır, DTO/Mapping üzerinden dışa açılır. Görülen projeler: Library.Application (servisler, DTO’lar, mapping, özel istisnalar), Library.Domain (entity/enums, repository sözleşmeleri). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Application

---

### `Library.Application/Services/BookReservationService.cs`

**1. Genel Bakış**
`BookReservationService`, kitap rezervasyonlarının sorgulanması ve yaşam döngüsü işlemlerini (oluşturma, iptal, tamamlama, silme) yürütür. Uygulama katmanında yer alır ve repository sözleşmeleri üzerinden Domain verilerine erişir, DTO ve mapping kullanarak sınırları korur.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookReservationService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookReservationRepository` — Rezervasyonlara erişim ve değişiklikler
- `IBookRepository` — Kitap varlık doğrulaması
- `ICustomerRepository` — Müşteri varlık ve durum doğrulaması

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Yapıcı | `BookReservationService(IBookReservationRepository, IBookRepository, ICustomerRepository)` | Repository bağımlılıklarını alır. |
| GetByIdAsync | `Task<BookReservationDto?> GetByIdAsync(Guid id)` | Rezervasyonu detaylarıyla alır ve DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<BookReservationDto>> GetAllAsync()` | Tüm rezervasyonları DTO olarak döner. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteri bazlı rezervasyonları döner. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)` | Kitap bazlı rezervasyonları döner. |
| CreateAsync | `Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)` | Doğrulamalarla yeni rezervasyon oluşturur, sıra numarası atar. |
| CancelReservationAsync | `Task CancelReservationAsync(Guid id)` | Rezervasyonu iptal eder, zaman damgasını günceller. |
| FulfillReservationAsync | `Task FulfillReservationAsync(Guid id)` | Rezervasyonu karşılanmış olarak işaretler, zaman damgasını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Rezervasyonu siler (mevcudiyet doğrulamasıyla). |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: Kitap ve müşteri mevcudiyet kontrolü; müşteri `IsActive` değilse `BadRequestException`. Kitap için bekleyen (`ReservationStatus.Pending`) sayısına göre `QueuePosition = pending + 1`. `ToEntity` ve `ToDto` mapping kullanılır.
- `CancelReservationAsync`/`FulfillReservationAsync`: Mevcut değilse `NotFoundException`; `Status` güncellenir, `UpdatedAt = DateTime.UtcNow`.
- `DeleteAsync`: Mevcudiyet kontrolünden sonra siler.
- İstisnalar: `NotFoundException`, `BadRequestException`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `IBookReservationRepository`, `IBookRepository`, `ICustomerRepository`.
- **İlişkili tipler:** `BookReservationDto`, `CreateBookReservationDto`, `ReservationStatus`, `Domain.Entities.{Book, Customer, BookReservation}`, `ToDto`/`ToEntity`, `NotFoundException`, `BadRequestException`.

**7. Eksikler ve Gözlemler**
- `QueuePosition` atamasında yarış koşulu olasılığı (eşzamanlı oluşturmalarda sıra tutarsızlığı).
- Durum geçişi doğrulaması yok (örn. iptal edilmiş bir rezervasyonu tekrar tamamlamak engellenmiyor).
- Aynı müşteri için aynı kitapta yinelenen bekleyen rezervasyonların önlenmesine dair kontrol görünmüyor.

---

### Genel Değerlendirme
Kod, Application katmanında temiz ayrımla repository sözleşmeleri ve DTO/mapping kullanıyor. İstisna tabanlı doğrulama net. Eşzamanlılık ve geçiş kuralları için ek iş kuralları (transaction/concurrency kontrolü, durum makinesi) ve olası idempotency kontrolleri faydalı olacaktır. Konfigürasyon, altyapı ve dış bağımlılıklar bu dosyadan belirlenemiyor.### Proje Genel Bakış
- Ad: Library (çıkarım). Amaç: Kitap incelemeleri için uygulama servisleri; DTO-mapping ve domain repository arayüzleri üzerinden iş kuralları uygular. Hedef çatı: .NET (Task tabanlı async, Clean Architecture izleri).
- Mimari: Clean Architecture. Application katmanı (servisler, DTO’lar, mapping), Domain katmanı (entity’ler, repository arayüzleri).
- Projeler:
  - Library.Application — Uygulama servisleri, DTO’lar, mapping, özel istisnalar.
  - Library.Domain — Domain entity’leri ve repository arayüzleri.
- Dış paketler: Bu dosyadan anlaşılmıyor (özel istisnalar ve mapping extension’ları projeye özgü görünüyor).
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (Services, DTOs, Mappings, Exceptions)
  -> Library.Domain (Interfaces, Entities)

---

### `Library.Application/Services/BookReviewService.cs`

**1. Genel Bakış**
`BookReviewService`, kitap incelemeleri için CRUD-benzeri operasyonları ve onay akışını yönetir. Application katmanında yer alır; domain repository arayüzleri üzerinden veri erişimini soyutlar ve DTO-entity mapping uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IBookReviewService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookReviewRepository` — İnceleme verilerine erişim
- `IBookRepository` — Kitap varlık doğrulaması
- `ICustomerRepository` — Müşteri varlık doğrulaması

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookReviewDto?> GetByIdAsync(Guid id)` | İncelemeyi ID ile getirir, DTO’ya map eder. |
| GetByBookIdAsync | `Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)` | Kitaba ait onaylı incelemeleri listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)` | Müşterinin yaptığı incelemeleri listeler. |
| GetAverageRatingAsync | `Task<double> GetAverageRatingAsync(Guid bookId)` | Kitaba ait ortalama puanı döner. |
| CreateAsync | `Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)` | Doğrulayıp yeni inceleme oluşturur ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)` | Mevcut incelemeyi günceller. |
| ApproveReviewAsync | `Task ApproveReviewAsync(Guid id)` | İncelemeyi onaylar ve zaman damgasını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | İncelemeyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync` öncesi kitap ve müşteri varlığını doğrular; yoksa `NotFoundException`.
- Puan (`Rating`) 1–5 aralığı dışında ise `BadRequestException`.
- `GetByBookIdAsync` sadece onaylı incelemeleri döndürür.
- `ApproveReviewAsync` `IsApproved = true` ve `UpdatedAt = DateTime.UtcNow` atar.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` extension metotlarıyla yapılır.
- `UpdateAsync` yoksa `NotFoundException` fırlatır; sonra mapping ve güncelleme yapar.
- `DeleteAsync` yoksa `NotFoundException` fırlatır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `IBookReviewRepository`, `IBookRepository`, `ICustomerRepository`
- **İlişkili tipler:** `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`, `Domain.Entities.Book`, `Domain.Entities.Customer`, `Domain.Entities.BookReview`, `NotFoundException`, `BadRequestException`, mapping extension’ları.

**7. Eksikler ve Gözlemler**
- `GetByCustomerIdAsync`’de onay filtresi belirtilmemiş; gereksinime göre tutarlılık gözden geçirilmeli (kitap bazlı liste onaylıyı döndürürken müşteri bazlı liste tümünü döndürebilir). 
- İşlemler arası atomiklik/transaction davranışı bu seviyede tanımlı değil; çok adımlı akışlar için değerlendirilmelidir.

---

### Genel Değerlendirme
Kod, Clean Architecture prensiplerine uygun; Application katmanı domain arayüzlerine dayanıyor ve DTO-mapping net. Validasyonlar kritik alanlarda mevcut. Onay filtreleme tutarlılığı ve olası transaction gereksinimleri gözden geçirilebilir. Dış bağımlılıklar ve konfigürasyon bu örnekten görülemiyor.### Project Overview
Proje adı: Library. Amaç: kitap yönetimi (oluşturma, güncelleme, listeleme) ve eklenme bildirimleri. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Clean Architecture eğilimli; `Application` katmanı domain’e bağımlı, repository ve servis arayüzleriyle soyutlamalar kullanıyor. Keşfedilen projeler/assembly’ler: 
- Library.Domain — `Entities`, `Interfaces` (repository sözleşmeleri)
- Library.Application — `Services`, `DTOs`, `Mappings`, `Common.Exceptions`, `Email`, `Interfaces`
Dış paketler bu dosyadan anlaşılmıyor. Konfigürasyon: `EmailSettings.NotificationTo` (bildirim alıcısı e-posta adresi).

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik uygulama hizmetlerini sağlar: sorgulama, oluşturma, güncelleme, silme ve ekleme sonrası e-posta bildirimi. Clean Architecture’da Application katmanındadır ve domain repository arayüzlerine ve e-posta servisine bağımlıdır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap veri erişimi (sorgu/ekleme/güncelleme/silme)
- `IEmailService` — E-posta gönderimi
- `EmailSettings` — E-posta bildirim konfigürasyonu (alıcı)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookService(IBookRepository bookRepository, IEmailService emailService, EmailSettings emailSettings)` | Servisin bağımlılıklarını alır. |
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Kitabı detaylarıyla getirip `BookDto` döner. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları `BookDto` olarak listeler. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/erişilebilir kitapları listeler. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | ISBN çakışmasını kontrol edip kitap oluşturur ve gerekirse bildirim gönderir. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller; yoksa hata fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kitabı siler; yoksa hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByISBNAsync` ile tekillik kontrolü; mevcutsa `ConflictException` fırlatır.
- `CreateAsync`: `CreateBookDto.ToEntity()` ile entity oluşturarak `AddAsync` sonrası `EmailSettings.NotificationTo` doluysa e-posta bildirimi gönderir.
- `GetByIdAsync`: `GetWithDetailsAsync` kullanır; yoksa `null` döner.
- `UpdateAsync`: `GetByIdAsync` ile varlık doğrulaması; yoksa `NotFoundException`. `UpdateBookDto.UpdateEntity` ile mapping.
- `DeleteAsync`: `ExistsAsync` ile doğrulama; yoksa `NotFoundException`.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` extension’ları kullanılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/controller veya uygulama katmanı orchestrator’ları çağırır.
- **Aşağı akış:** `IBookRepository`, `IEmailService`, `EmailSettings`
- **İlişkili tipler:** `Book`, `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`, `IBookRepository`, `EmailSettings`, `ConflictException`, `NotFoundException`

**7. Eksikler ve Gözlemler**
- `CreateAsync` dışında e-posta bildirimi yok; iş gereksinimine göre güncelleme/silme için de bildirim gerekebilir.
- `GetAllAsync` ve `GetAvailableBooksAsync` sonuçlarında sayfalama/filtreleme bulunmuyor; büyük veri setlerinde performans riski olabilir.

---
Genel Değerlendirme
Kod, Application katmanında temiz sorumluluk ayrımı ve repository/DTO/mapping kullanımı ile tutarlı. Hata yönetimi kritik noktalarda mevcut (`NotFoundException`, `ConflictException`). Konfigürasyon bağımlılığı (`EmailSettings`) doğrudan ctor’dan alınıyor; opsiyonel yapılandırma validasyonu eklenebilir. Dış bağımlılıklar ve altyapı ayrıntıları (persistans, DI kayıtları) bu dosyadan görülmüyor.### Project Overview
Proje adı: Library. Amaç: müşteri yönetimi için uygulama katmanında servis mantığı sağlamak (oluşturma, okuma, güncelleme, silme ve filtreleme). Hedef framework: bu dosyadan anlaşılmıyor. Mimari katmanlı/Clean Architecture yaklaşımı izleniyor gibi; `Application` katmanı, `Domain` arayüzlerine bağımlı. Keşfedilen projeler/assembly’ler: 
- Library.Application — Uygulama servisleri, DTO’lar, eşlemeler, özel exception’lar
- Library.Domain — Etki alanı varlıkları ve repository arayüzleri
Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application.Services
  -> Library.Domain.Interfaces
  -> Library.Application.DTOs
  -> Library.Application.Mappings
  -> Library.Application.Common.Exceptions

---

### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri varlıkları için okuma/yazma işlemlerini gerçekleştirir ve DTO-Entity dönüşümlerini koordine eder. Uygulama katmanına aittir ve `ICustomerRepository` üzerinden etki alanına erişir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri veri erişimi (CRUD, aktif filtreleme, e-posta ile arama)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<CustomerDto?> GetByIdAsync(Guid id)` | Kimliğe göre müşteriyi DTO olarak döndürür. |
| GetAllAsync | `public Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri DTO listesi olarak döndürür. |
| GetActiveCustomersAsync | `public Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri DTO listesi olarak döndürür. |
| CreateAsync | `public Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | E-posta eşsizliğini kontrol ederek müşteri oluşturur ve DTO döndürür. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByEmailAsync` ile e-posta eşsizliği kontrolü; mevcutsa `ConflictException` fırlatır.
- `UpdateAsync`: Kimlikle müşteri bulunamazsa `NotFoundException` fırlatır; `UpdateCustomerDto.UpdateEntity` ile alan bazlı güncelleme yapar.
- `DeleteAsync`: Kayıt yoksa `NotFoundException` fırlatır; aksi halde siler.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla DTO-Entity dönüşümleri.
- Sorgular: Aktif filtre `GetActiveCustomersAsync` üzerinden repository katmanına delege edilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `ICustomerRepository`, `Library.Application.Mappings` uzantıları.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `Domain.Entities.Customer`, `ConflictException`, `NotFoundException`.

**7. Eksikler ve Gözlemler**
- `CreateAsync`/`UpdateAsync` için alan düzeyinde input validasyonu (ör. e-posta formatı, zorunlu alanlar) bu seviyede görünmüyor; başka katmanlara bırakılmış olabilir.

---

Genel Değerlendirme
- Uygulama servisi, etki alanına yalnızca repository arayüzü üzerinden erişerek katmanlı/Clean Architecture ilkelerine uyuyor.
- DTO-Entity eşleme mantığı uzantılara ayrılmış; okunabilirlik iyi.
- Görünür harici paket veya konfigürasyon bağımlılığı yok.
- Girdi validasyonunun yeri belirsiz; merkezi bir validasyon katmanı veya filtre kullanımı önerilir.### Project Overview
Proje adı “Library” (namespace’lerden). Amaç: kütüphane yönetimi için istatistik/toplamalar üreten uygulama servisleri sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari, Domain ve Application katmanlarını ayıran Clean Architecture yaklaşımına benziyor: Application katmanı, Domain arayüzlerine dayanarak kullanım senaryolarını orkestre eder.

- Katmanlar/Projeler:
  - Library.Domain — Alan modelleri, `Enums`, repository arayüzleri.
  - Library.Application — Uygulama servisleri, DTO’lar, iş akışları.
- Dış bağımlılıklar: Bu dosyada görünmüyor.
- Konfigürasyon: Bu dosyada görünmüyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Services/DashboardService.cs`

**1. Genel Bakış**
`DashboardService`, sistem genelindeki metrikleri toplayıp `DashboardStatsDto` olarak dönen bir uygulama servisidir. Application katmanında yer alır ve Domain repository arayüzlerini kullanarak kitap, müşteri, personel, ödünç, rezervasyon, ceza ve şube istatistiklerini bir araya getirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IDashboardService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap sayımı ve uygunluk sorguları
- `ICustomerRepository` — Müşteri sayımı ve aktif müşteriler
- `IStaffRepository` — Personel sayımı
- `IBookLoanRepository` — Aktif ve geciken ödünçler
- `IBookReservationRepository` — Rezervasyon durumuna göre sorgular
- `IFineRepository` — Bekleyen cezalar
- `ILibraryBranchRepository` — Şube sayımı

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `DashboardService(IBookRepository, ICustomerRepository, IStaffRepository, IBookLoanRepository, IBookReservationRepository, IFineRepository, ILibraryBranchRepository)` | Repository bağımlılıklarını alır. |
| GetStatsAsync | `Task<DashboardStatsDto> GetStatsAsync()` | Farklı kaynaklardan metrikleri toplayıp özet DTO döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Kitap, müşteri, personel ve şube sayıları `CountAsync` ile alınır.
- Aktif/geciken ödünçler ve bekleyen rezervasyonlar ilgili repository sorgularıyla sayılır.
- Bekleyen cezaların toplam tutarı `Amount` alanlarının toplamıyla hesaplanır.
- Bütün sorgular ardışık `await` çağrılarıyla yapılır; tek bir `DashboardStatsDto` üretilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir (ör. API katmanındaki controller/handler’lar).
- **Aşağı akış:** Yukarıda listelenen repository arayüzleri.
- **İlişkili tipler:** `DashboardStatsDto`, `ReservationStatus` (Domain enum), repository arayüzleri.

**7. Eksikler ve Gözlemler**
- `GetStatsAsync` içinde çoklu bağımsız çağrılar paralelleştirilebilir; performans için `Task.WhenAll` değerlendirilebilir.
- `CancellationToken` desteği yok; uzun süren sorgular için eklenmesi faydalı olabilir. 

---

Genel Değerlendirme
- Uygulama ve Domain ayrımı net; Clean Architecture yönelimi görülüyor.
- Asenkron toplu sorgular sırayla çalıştırılıyor; paralelleştirme ve `CancellationToken` eklenmesiyle iyileştirilebilir.
- Dış paketler ve konfigürasyon bu parçadan görünmüyor; proje genelinde tutarlı DI ve hataya dayanıklılık politikaları doğrulanmalı.### Project Overview
Proje adı: Library. Amaç: Kütüphane cezalarını (fine) yönetmek; ceza oluşturma, ödeme, affetme, silme ve sorgulama işlemleri. Hedef çerçeve koddan anlaşılmıyor. Mimari katmanlar arası ayrım: Application katmanı, Domain sözleşmeleri ve türlerine dayanıyor. Görünen projeler/assembly’ler: Library.Application (servisler, DTO/mapping, özel exception’lar), Library.Domain (entity’ler, enum’lar, repository arayüzleri). Harici paket görünmüyor. Konfigürasyon anahtarları veya connection string bilgisi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  ↳ uses Library.Domain (Enums, Interfaces, Entities)
  ↳ internal: Application.DTOs, Application.Mappings, Application.Common.Exceptions

---

### `Library.Application/Services/FineService.cs`

**1. Genel Bakış**
`FineService`, kütüphane ceza işlemlerinin uygulama katmanındaki servisidir. Cezaları sorgular, oluşturur, öder, affeder ve siler; repository aracılığıyla Domain katmanıyla haberleşir. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IFineService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IFineRepository` — Ceza verilerine erişim için repository

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `FineService(IFineRepository fineRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<FineDto?> GetByIdAsync(Guid id)` | ID’ye göre cezayı döndürür. |
| GetAllAsync | `Task<IEnumerable<FineDto>> GetAllAsync()` | Tüm cezaları listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait cezaları listeler. |
| GetPendingFinesAsync | `Task<IEnumerable<FineDto>> GetPendingFinesAsync()` | Bekleyen (ödenmemiş) cezaları listeler. |
| GetTotalUnpaidByCustomerAsync | `Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)` | Müşterinin toplam ödenmemiş cezasını döndürür. |
| CreateAsync | `Task<FineDto> CreateAsync(CreateFineDto createDto)` | Yeni ceza oluşturur. |
| PayFineAsync | `Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)` | Cezayı öder ve günceller. |
| WaiveFineAsync | `Task WaiveFineAsync(Guid id)` | Cezayı affeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Cezayı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByIdAsync`, `PayFineAsync`, `WaiveFineAsync`, `DeleteAsync` bulunamayan kayıt için `NotFoundException` fırlatır.
- `PayFineAsync` zaten ödenmiş ceza için `BadRequestException` fırlatır.
- Ödeme sırasında `fine.Status = FineStatus.Paid`, `PaidDate = DateTime.UtcNow`, `PaymentMethod` ve `UpdatedAt` set edilir, ardından güncellenir.
- Affetmede `fine.Status = FineStatus.Waived` ve `UpdatedAt` set edilerek güncellenir.
- `CreateAsync` DTO’dan entity’ye map eder (`ToEntity()`), ekler ve DTO’ya map eder (`ToDto()`).
- `Get*` metodlarında sonuçlar `ToDto()` ile map edilir.

**6. Bağlantılar**
- Yukarı akış: `IFineService` tüketicileri (DI üzerinden çözümlenir)
- Aşağı akış: `IFineRepository`
- İlişkili tipler: `FineDto`, `CreateFineDto`, `PayFineDto`, `Domain.Entities.Fine`, `FineStatus`, `NotFoundException`, `BadRequestException`, `Library.Application.Mappings` uzantıları.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `PayFineAsync` için DTO içeriğine yönelik açık bir input validasyonu bu dosyadan görülmüyor; servis düzeyinde temel kontroller eklenebilir.

---

Genel Değerlendirme
- Katman ayrımı net: Application servisi Domain repository arayüzünü kullanıyor ve DTO-map katmanı ile ayrıştırılmış.
- Exception bazlı akış tutarlı; ancak DTO alan validasyonları ve potansiyel concurrency/çoklu güncelleme senaryolarına yönelik korumalar (ör. durum geçişleri için idempotency/concurrency token) belirtilmemiş.
- Harici paket ve konfigürasyon görünmediğinden altyapı ayrıntıları belirsiz.### Project Overview
Proje adı: Library. Amaç: kütüphane şubeleri için CRUD ve sorgulama operasyonlarını katmanlı yapıda sunmak. Hedef çatı: .NET (katman adlarına göre Clean Architecture; tam sürüm bu dosyadan anlaşılmıyor). Katmanlar: Domain (entity ve repository sözleşmeleri), Application (DTO’lar, mapping, servisler). Görünen projeler/assembly’ler: Library.Application (iş kuralları, DTO, mapping), Library.Domain (entity ve repository arayüzleri). Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon: bağlantı dizgileri veya app settings anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API → Application (`Library.Application`)
Application → Domain (`Library.Domain`)
Application → Application.DTOs/Mappings
Infrastructure (varsayım) → Domain.Interfaces (uyarlama)
Presentation/API → Application → Domain.Interfaces → Infrastructure

---
### `Library.Application/Services/LibraryBranchService.cs`

**1. Genel Bakış**
`LibraryBranchService`, kütüphane şubeleri için sorgulama ve CRUD işlemlerini yürütür; Application katmanında yer alır. Repository arayüzü üzerinden Domain katmanı ile konuşur, DTO/Entity mapping uzantılarını kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ILibraryBranchService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ILibraryBranchRepository` — Şube verilerine erişim için repository sözleşmesi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryBranchService(ILibraryBranchRepository branchRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<LibraryBranchDto?> GetByIdAsync(Guid id)` | ID’ye göre şube döndürür; bulunamazsa null. |
| GetAllAsync | `Task<IEnumerable<LibraryBranchDto>> GetAllAsync()` | Tüm şubeleri listeler. |
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()` | Aktif şubeleri listeler. |
| CreateAsync | `Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)` | Yeni şube oluşturur ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)` | Mevcut şubeyi günceller; yoksa hata fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Şubeyi siler; yoksa hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync` ve `DeleteAsync` işlemlerinde kayıt yoksa `NotFoundException` fırlatılır.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla DTO ↔ Entity dönüşümü yapılır.
- `CreateAsync` ekledikten sonra oluşturulan entity doğrudan DTO’ya çevrilir ve döndürülür.
- `GetActiveBranchesAsync` yalnızca aktif şubeleri repository üzerinden filtreleyerek getirir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/Controller veya Application katmanı orkestrasyonları çağırır.
- **Aşağı akış:** `ILibraryBranchRepository`, mapping uzantıları (`Library.Application.Mappings`), `NotFoundException`.
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `Domain.Entities.LibraryBranch`, `ILibraryBranchService`, `ILibraryBranchRepository`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için input validasyonu bu seviyede görünmüyor; null/boş alan kontrolleri veya kurallar Application katmanında eklenebilir.
- Transaction veya concurrency kontrolü belirtilmemiş; çok adımlı güncellemelerde gerekebilir.

---
### Genel Değerlendirme
Kod, Application katmanında servis + repository sözleşmeleri ve DTO/mapping ayrımıyla Clean Architecture’a uygundur. Hata yönetimi NotFound senaryoları için tutarlı. Gözle görülür konfigürasyon, dış paket veya logging/caching stratejisi bu dosyadan anlaşılmıyor. Girdi validasyonu ve concurrency/transaction politikaları netleştirilmeli; Infrastructure ve Presentation katmanlarıyla entegrasyon belirsiz.### Project Overview
Proje adı: Library. Amaç: bildirimlerin okunma durumu, sayımı, oluşturulması ve silinmesi için uygulama katmanı servisleri sağlamak. Hedef çatı: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: Clean Architecture’a yakın katmanlama; Application katmanı Domain arayüzlerine bağımlı. Keşfedilen projeler: Library.Application (uygulama servisleri, DTO ve mapping kullanımı), Library.Domain (repository arayüzleri). Harici paketler: Bu dosyadan belirlenemiyor. Konfigürasyon: Bu dosyada bağlantı dizesi veya app settings anahtarı görünmüyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Services/NotificationService.cs`

**1. Genel Bakış**
`NotificationService`, müşteri bazlı bildirimleri listeleme, okunmamışları sayma, oluşturma ve okundu/temizleme işlemlerini sağlar. Uygulama (Application) katmanında yer alır ve Domain katmanındaki `INotificationRepository` üzerinden veri erişimini soyutlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `INotificationService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `INotificationRepository` — Bildirimlerin veri erişim operasyonlarını sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public NotificationService(INotificationRepository notificationRepository)` | Repository bağımlılığını alır. |
| GetByCustomerIdAsync | `public Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait tüm bildirimleri DTO’ya map’leyerek döner. |
| GetUnreadByCustomerIdAsync | `public Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)` | Müşteriye ait okunmamış bildirimleri getirir. |
| GetUnreadCountAsync | `public Task<int> GetUnreadCountAsync(Guid customerId)` | Müşteriye ait okunmamış bildirim sayısını döner. |
| CreateAsync | `public Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)` | DTO’yu entitiye çevirip ekler, oluşanı DTO olarak döner. |
| MarkAsReadAsync | `public Task MarkAsReadAsync(Guid id)` | Belirtilen bildirimi okundu işaretler. |
| MarkAllAsReadAsync | `public Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm bildirimlerini okundu işaretler. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Belirtilen bildirimi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `CreateNotificationDto.ToEntity()` ile entity oluşturur; `ToDto()` ile dönüşlerde DTO üretir.
- Filtreleme/iş: Okunmamış bildirimleri ve sayısını repository seviyesinde elde eder.
- Doğrudan validasyon veya hata yönetimi bu sınıfta yok; repository’nin sözleşmesine güvenir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `INotificationRepository`
- **İlişkili tipler:** `INotificationService`, `NotificationDto`, `CreateNotificationDto`, `Library.Application.Mappings` uzantıları (`ToDto`, `ToEntity`).

**7. Eksikler ve Gözlemler**
- `CreateAsync` için `createDto` null kontrolü veya alan validasyonu yok.
- Id parametreleri için format/varlık doğrulaması bu seviyede yapılmıyor. 

---
Genel Değerlendirme
Kod, Application katmanından Domain arayüzlerine bağımlılığı koruyarak temiz bir ayrım yapıyor; mapping uzantılarıyla DTO/entity dönüşümü düzenli. Ancak servis düzeyinde temel validasyonlar ve hata yönetimi görünmüyor; bu karar bilinçliyse sorun değil, değilse minimal kontroller eklenmeli. Yapıya göre diğer katmanlar (Infrastructure, API) bu depoda görünmüyor, bağımlılık akışı tek yönlü korunuyor.### Proje Genel Bakış
Proje, bir kütüphane alanında yayıncıları yönetmek için Application katmanında servis mantığı sağlar. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak Domain ve Application katmanları ayrıştırılmıştır; Application, Domain repository arayüzlerine dayanır ve DTO/Entity dönüşümleri için mapping kullanır. Keşfedilen projeler: Library.Application (iş mantığı, DTO ve mapping kullanımı) ve Library.Domain (repository arayüzleri). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Domain (Entities, Interfaces)
^
|
Library.Application (Services, DTOs, Mappings)

---
### `Library.Application/Services/PublisherService.cs`

**1. Genel Bakış**
`PublisherService`, yayıncılar için CRUD ve sorgulama işlemlerini sağlayan Application katmanı servisidir. Domain katmanındaki `IPublisherRepository` üzerinden veri erişimini soyutlar ve DTO/Entity dönüşümlerini mapping uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IPublisherService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IPublisherRepository` — Yayıncı varlıkları için veri erişim operasyonlarını sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `PublisherService(IPublisherRepository publisherRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<PublisherDto?> GetByIdAsync(Guid id)` | İlgili yayıncıyı kitaplarıyla getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `Task<IEnumerable<PublisherDto>> GetAllAsync()` | Tüm yayıncıları listeler ve DTO’ya dönüştürür. |
| GetActivePublishersAsync | `Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()` | Aktif yayıncıları listeler ve DTO’ya dönüştürür. |
| CreateAsync | `Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)` | İsim bazlı çakışmayı kontrol ederek yeni yayıncı oluşturur. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)` | Varlığı bulup DTO’dan entity’e alan güncellemesi yapar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varlık mevcutsa siler, değilse hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByNameAsync` ile isim benzersizliği kontrol edilir; varsa `ConflictException` fırlatılır.
- `UpdateAsync`: Kimlikle varlık bulunamazsa `NotFoundException` fırlatılır; `UpdateEntity` ile alanlar güncellenir.
- `DeleteAsync`: Yoksa `NotFoundException` fırlatır; varsa `DeleteAsync` çağrılır.
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla DTO/Entity dönüşümü yapılır.
- `GetByIdAsync`: Yayıncıyı ilişkili kitaplarla `GetWithBooksAsync` üzerinden çeker.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `IPublisherRepository`
- **İlişkili tipler:** `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`, `ConflictException`, `NotFoundException`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`).

**7. Eksikler ve Gözlemler**
- `UpdateAsync` içinde isim benzersizliği kontrolü yok; güncellemede isim çakışması oluşabilir. Bu, veri bütünlüğü açısından tutarsızlığa yol açabilir.

---
Genel Değerlendirme
Kod, Application ve Domain ayrımını takip eden temiz bir servis soyutlaması sunuyor. Exception tabanlı akış ve mapping uzantıları tutarlı. Ancak güncelleme senaryosunda isim benzersizliği kontrolünün eksik olması, oluşturma ile tutarsızlık yaratabilir. Hedef framework, konfigürasyon ve harici bağımlılıklar dosyadan anlaşılamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane personel yönetimi için uygulama katmanında iş mantığı sağlamak. Hedef çerçeve bu dosyadan anlaşılmıyor. Mimari, Application katmanının Domain arayüzlerine bağımlı olduğu klasik katmanlı bir düzen izliyor. Application’da servisler, DTO’lar, eşlemeler ve özel istisnalar; Domain’de arayüzler ve varlıklar bulunuyor. Harici paket kullanımı bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri (bağlantı dizgileri, app settings) bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

- Library.Application: Servisler, DTO’lar, eşleme uzantıları, uygulama düzeyi istisnalar ve servis arayüzleri.
- Library.Domain: Varlıklar ve repository arayüzleri.

- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama iş mantığı ve sözleşmeleri
  - Library.Domain — Etki alanı sözleşmeleri (repository) ve varlıklar

---

### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel (staff) ile ilgili uygulama iş mantığını sağlar: listeleme, aktifleri getirme, oluşturma, güncelleme ve silme. Application katmanında yer alır ve `IStaffRepository` üzerinden Domain’e erişir. DTO–Entity dönüşümleri `Mappings` uzantılarıyla yapılır, iş kuralı olarak e‑posta tekilliği ve varlık bulunurluğu kontrol edilir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel verisine erişim (Domain katmanı repository arayüzü)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Kurucu | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public async Task<StaffDto?> GetByIdAsync(Guid id)` | ID’ye göre personeli DTO olarak döndürür. |
| GetAllAsync | `public async Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personeli DTO listesi olarak döndürür. |
| GetActiveStaffAsync | `public async Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personeli DTO listesi olarak döndürür. |
| CreateAsync | `public async Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | E‑posta tekilliği kontrolüyle yeni personel oluşturur. |
| UpdateAsync | `public async Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut personeli günceller; yoksa hata fırlatır. |
| DeleteAsync | `public async Task DeleteAsync(Guid id)` | Personeli siler; yoksa hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByEmailAsync` ile e‑posta tekilliği kontrolü; mevcutsa `ConflictException` fırlatır.
- `UpdateAsync`: ID ile personel bulunamazsa `NotFoundException` fırlatır; `UpdateEntity` ile alan bazlı güncelleme yapar.
- `DeleteAsync`: `ExistsAsync` ile varlık kontrolü; yoksa `NotFoundException` fırlatır.
- Mapping: `ToEntity`, `ToDto`, `UpdateEntity` uzantılarıyla DTO–Entity dönüşümü.
- Listeleme: Aktif personel `GetActiveStaffAsync` repository filtresiyle sağlanır.

**6. Bağlantılar**
- **Yukarı akış:** `IStaffService` kullanan Application/API katmanı bileşenleri (DI üzerinden çözümlenir).
- **Aşağı akış:** `IStaffRepository`, `Library.Application.Mappings` uzantıları.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `ConflictException`, `NotFoundException`, `Domain.Entities.Staff`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok.
- `Create/Update` için DTO doğrulaması bu dosyadan anlaşılmıyor; servis içinde ek validasyon görünmüyor.

---

Genel Değerlendirme
Kod, Application katmanının Domain arayüzlerine bağımlı olduğu net bir katmanlı mimari sergiliyor. Servis içinde mapping uzantıları kullanımı tutarlı. Hata durumlarında anlamlı istisnalar fırlatılıyor. Gözle görülür eksikler: `CancellationToken` desteği, potansiyel DTO validasyonu ve olası işlem/transaction sınırlarına dair görünürlük. Harici paketler ve konfigürasyonlar bu koddaki bağlamdan çıkarılamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait çekirdek domain tiplerini barındırmak (ör. denetim/audit kayıtları). Hedef framework bu dosyadan anlaşılmıyor. Mimari katmanlardan yalnızca Domain katmanı görülebiliyor. Keşfedilen proje/assembly: Library.Domain — domain entity’leri ve temel modeller. Harici paket kullanımı bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] (bağımsız domain katmanı)

---
### `Library.Domain/Entities/AuditLog.cs`

**1. Genel Bakış**
`AuditLog`, sistemdeki bir varlık üzerinde gerçekleşen işlemleri (oluşturma, güncelleme, silme vb.) geçmişe dönük izlemek için kullanılan domain entity’sidir. Domain katmanına aittir ve denetim kaydı verisini taşır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| EntityName | `public string EntityName { get; set; }` | İşlem yapılan varlığın adı. |
| EntityId | `public Guid EntityId { get; set; }` | İşlem yapılan varlığın kimliği. |
| Action | `public string Action { get; set; }` | Gerçekleşen eylem (ör. Create/Update/Delete). |
| OldValues | `public string? OldValues { get; set; }` | Değişim öncesi değerlerin serileştirilmiş temsili. |
| NewValues | `public string? NewValues { get; set; }` | Değişim sonrası değerlerin serileştirilmiş temsili. |
| UserId | `public string? UserId { get; set; }` | İşlemi yapan kullanıcının kimliği. |
| UserName | `public string? UserName { get; set; }` | İşlemi yapan kullanıcının adı. |
| IpAddress | `public string? IpAddress { get; set; }` | İsteğin IP adresi. |
| Timestamp | `public DateTime Timestamp { get; set; }` | İşlemin zaman damgası. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `EntityName = string.Empty`, `Action = string.Empty`. Diğer referans tipleri `null` olabilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BaseEntity`.

Genel Değerlendirme
- Sadece Domain katmanı görünür durumda; diğer katmanlar (Application/Infrastructure/API) bu girdiyle tespit edilemiyor.
- `BaseEntity` tanımı bu depoda gösterilmemiş; ortak alanlar (örn. `Id`, zaman damgaları) varsa davranışları belirsiz.
- Harici paket/konfigürasyon izine rastlanmadı; kalıcılık stratejisi (EF Core vb.) bu dosyadan çıkarılamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki temel domain varlıklarını modellemek (ör. yazar, kitap). Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak Domain katmanı gözüküyor; muhtemelen diğer katmanlar (Application/Infrastructure/API) bunu tüketir, ancak bu depodan doğrulanamıyor. Keşfedilen proje/assembly: Library.Domain — Domain varlıkları ve temel tipler. Görülen harici paket yok. Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain (Entities)]
(Şu an tek bağımsız katman; başka katman/bağımlılık görünmüyor)

---
### `Library.Domain/Entities/Author.cs`

**1. Genel Bakış**
`Author` bir yazar varlığını temsil eder; ad, biyografi, doğum/ölüm tarihi, milliyet ve ilişkili `Book` koleksiyonunu içerir. Domain katmanında yer alan bir entity’dir ve muhtemel persistance katmanındaki eşlenik tabloya haritalanmak üzere tasarlanmıştır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Yazarın adı. Varsayılanı boş string. |
| LastName | `public string LastName { get; set; }` | Yazarın soyadı. Varsayılanı boş string. |
| Biography | `public string? Biography { get; set; }` | Yazarın biyografisi (opsiyonel). |
| BirthDate | `public DateTime? BirthDate { get; set; }` | Doğum tarihi (opsiyonel). |
| DeathDate | `public DateTime? DeathDate { get; set; }` | Ölüm tarihi (opsiyonel). |
| Nationality | `public string? Nationality { get; set; }` | Milliyet (opsiyonel). |
| Website | `public string? Website { get; set; }` | Web sitesi (opsiyonel). |
| PhotoUrl | `public string? PhotoUrl { get; set; }` | Fotoğraf URL’si (opsiyonel). |
| Books | `public ICollection<Book> Books { get; set; }` | Yazara ait kitaplar koleksiyonu; varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılanlar: `FirstName = string.Empty`, `LastName = string.Empty`, `Books = []`.
- Tüm diğer metinsel ve tarihsel alanlar opsiyonel; null olabilir.
- `Books` ilişki navigasyonu hazır başlatıldığı için null referans hatası önlenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity`, `Book` (tip referansı).
- **İlişkili tipler:** `Book` (ilişkili koleksiyon), `BaseEntity` (ortak kimlik/zaman damgası vb. için olası temel sınıf).

Genel Değerlendirme
- Kod yalnızca Domain katmanından bir entity içeriyor; diğer katmanlar ve bağımlılıklar görünmüyor.
- `BaseEntity` ve `Book` tanımları bu depoda sunulmamış; kimlik ve ilişki ayrıntıları belirsiz.
- Hedef framework, veri erişim teknolojisi ve konfigürasyon anahtarları tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: kitap/kütüphane alanına ait domain modelini tanımlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari örüntü: Clean Architecture eğilimli; bu repoda yalnızca Domain katmanı (entity temeli) görülüyor. Keşfedilen proje/assembly: Library.Domain — Domain entity’lerinin çekirdeği ve ortak taban özellikleri. Harici paket kullanımı: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]
  └─ Bağımlılık: Yok
  └─ Üst katmanlar (muhtemel): Application/Infrastructure/API bu dosyadan görülmüyor

---
### `Library.Domain/Entities/BaseEntity.cs`

**1. Genel Bakış**
`BaseEntity`, domain varlıkları için ortak kimlik, denetim (audit) ve yumuşak silme (`IsDeleted`) alanlarını sağlayan soyut bir temel sınıftır. Clean Architecture’da Domain katmanına aittir ve tüm entity’ler için standart alanlar sunar.

**2. Tip Bilgisi**
- **Tip:** abstract class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `Guid Id { get; set; }` | Varlığın benzersiz kimliği. |
| CreatedAt | `DateTime CreatedAt { get; set; }` | Oluşturulma zamanı. |
| CreatedBy | `string? CreatedBy { get; set; }` | Oluşturan kullanıcı/işlem. |
| UpdatedAt | `DateTime? UpdatedAt { get; set; }` | Son güncellenme zamanı. |
| UpdatedBy | `string? UpdatedBy { get; set; }` | Son güncelleyen kullanıcı/işlem. |
| IsDeleted | `bool IsDeleted { get; set; }` | Yumuşak silinmiş bayrağı. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Default değerler: `Guid` default, `DateTime` default, referanslar `null`, `IsDeleted = false` (CLR default).

**6. Bağlantılar**
- **Yukarı akış:** Bu tabanı miras alan entity sınıfları.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (türeyen entity’ler görünmüyor).

---

### Genel Değerlendirme
- Domain katmanında sadece temel entity altyapısı görülüyor; denetim alanlarının set edilmesi için altyapı (ör. interceptor, `SaveChanges` override, domain event) bu dosyadan anlaşılmıyor.
- Soft delete için `IsDeleted` alanı mevcut; ilişkili global query filter’ları veya repository/persistance mantığı görünmüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki varlıkları (kitap vb.) temsil eden domain katmanını sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari katmanlardan sadece Domain katmanı görünür; diğer katmanlar bu dosyadan anlaşılamıyor. Keşfedilen proje/assembly: Library.Domain — domain varlıkları ve enum’lar. Harici paket/çatı kullanımına dair bir iz yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)

---
### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kütüphane kitabını temsil eden domain entity’sidir. Kitabın kimlik bilgileri, stok/uygunluk durumu ve ilişkili varlıkları (yazar, yayınevi, kategori, şube) içerir. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Title | `public string Title { get; set; }` | Kitap adı. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. |
| Description | `public string Description { get; set; }` | Açıklama/özet. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `public int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `public string Language { get; set; }` | Dil. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik. |
| TotalCopies | `public int TotalCopies { get; set; }` | Toplam kopya. |
| AvailableCopies | `public int AvailableCopies { get; set; }` | Uygun kopya sayısı. |
| Condition | `public BookCondition Condition { get; set; }` | Kitap durumu. |
| CoverImageUrl | `public string? CoverImageUrl { get; set; }` | Kapak görseli URL. |
| Price | `public decimal? Price { get; set; }` | Fiyat (opsiyonel). |
| AuthorId | `public Guid AuthorId { get; set; }` | İlgili yazar ID. |
| Author | `public Author Author { get; set; }` | Yazar navigasyonu. |
| PublisherId | `public Guid? PublisherId { get; set; }` | Yayınevi ID. |
| Publisher | `public Publisher? Publisher { get; set; }` | Yayınevi navigasyonu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori ID. |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | Kategori navigasyonu. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Şube ID. |
| LibraryBranch | `public LibraryBranch? LibraryBranch { get; set; }` | Şube navigasyonu. |
| BookLoans | `public ICollection<BookLoan> BookLoans { get; set; }` | Ödünç kayıtları. |
| BookReservations | `public ICollection<BookReservation> BookReservations { get; set; }` | Rezervasyonlar. |
| BookReviews | `public ICollection<BookReview> BookReviews { get; set; }` | İncelemeler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Default değerler: `Title = ""`, `ISBN = ""`, `Description = ""`, `Language = "Turkish"`, `IsAvailable = true`, `TotalCopies = 1`, `AvailableCopies = 1`, `Condition = BookCondition.New`; koleksiyonlar boş koleksiyonla başlar; `CoverImageUrl`, `Price`, `PublisherId`, `BookCategoryId`, `LibraryBranchId` opsiyoneldir.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Author`, `Publisher`, `BookCategory`, `LibraryBranch`, `BookLoan`, `BookReservation`, `BookReview`, `BookCondition`.
- İlişkili tipler: `BaseEntity` (kimlik/zaman damgası vb. içerebilir — bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- `AvailableCopies <= TotalCopies` ve `IsAvailable` ile stok tutarlılığına dair doğrulama bulunmuyor.
- `ISBN` format/doğrulama kuralları tanımlı değil.

### Genel Değerlendirme
Kod tabanında yalnızca Domain katmanına ait bir entity görünür. Davranış ve iş kuralları entity içinde modellenmemiş; doğrulama ve tutarlılık kontrolleri uygulama/infrastructure katmanlarına bırakılmış olabilir. Diğer katmanlar, ORM eşlemeleri ve konfigürasyonlar bu dosyadan anlaşılamıyor.### Project Overview
Proje adı: Library. Amaç: kitap kategorilerini temsil eden domain entity’leri tanımlamak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: Clean Architecture tarzına uygun katmanlaşma sinyalleri (Domain katmanı). Keşfedilen projeler/assembly’ler: Library.Domain — domain modelleri ve kuralları. Dış paketler: görünmüyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)

---
### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, bir kitap kategorisini ve hiyerarşik ilişkilerini (ebeveyn/alt kategori) temsil eden domain entity’sidir. Domain katmanına aittir ve kategori adlandırma, açıklama, görünürlük/aktiflik ve ilişkilendirilmiş kitaplar için navigasyonlar sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |
| IconUrl | `public string? IconUrl { get; set; }` | Opsiyonel ikon URL’si. |
| DisplayOrder | `public int DisplayOrder { get; set; }` | Listeleme/sıralama önceliği. |
| IsActive | `public bool IsActive { get; set; }` | Kategorinin aktiflik durumu. |
| ParentCategoryId | `public Guid? ParentCategoryId { get; set; }` | Ebeveyn kategori kimliği (opsiyonel). |
| ParentCategory | `public BookCategory? ParentCategory { get; set; }` | Ebeveyn kategori navigasyonu. |
| SubCategories | `public ICollection<BookCategory> SubCategories { get; set; }` | Alt kategori koleksiyonu. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye ait kitaplar. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `IsActive = true`, `SubCategories` ve `Books` boş koleksiyon olarak başlatılır, `IconUrl` ve `ParentCategoryId` opsiyoneldir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BaseEntity`, `Book`, self-referans `BookCategory` (ebeveyn/alt ilişki).

Genel Değerlendirme
- Yalnızca Domain katmanından bir entity görülebiliyor; uygulama, altyapı ve sunum katmanlarına dair kanıt yok.
- Varlıkta doğrulama/iş kuralı bulunmuyor; bu kurallar muhtemelen başka katmanlarda ele alınacaktır.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelini temsil eden domain varlıklarını sağlamak (ödünç alma süreçleri vb.). Hedef framework bu dosyadan anlaşılmıyor. Mimari desen: Clean Architecture’a uygun bir katmanlaşma izlenimi; burada yalnızca Domain katmanı görülüyor. Keşfedilen projeler/assembly’ler: Library.Domain — alan varlıkları, enum’lar ve temel tipler. Harici paketler/çatı: Bu dosyadan anlaşılmıyor (EF Core kullanımı muhtemel, ancak kodda doğrudan referans yok). Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Entities/BookLoan.cs`

**1. Genel Bakış**
`BookLoan`, bir kitabın müşteri tarafından ödünç alınmasını ve iade sürecini modelleyen domain varlığıdır. İlişkili kitap, müşteri, personel ve para cezalarıyla birlikte ödünç alma durumunu ve yenileme metriklerini tutar. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookId | `public Guid BookId { get; set; }` | İlişkili kitabın kimliği. |
| Book | `public Book Book { get; set; }` | İlişkili kitap navigasyon özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Ödünç alan müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | Müşteri navigasyon özelliği. |
| ProcessedByStaffId | `public Guid? ProcessedByStaffId { get; set; }` | İşlemi yapan personel kimliği (opsiyonel). |
| ProcessedByStaff | `public Staff? ProcessedByStaff { get; set; }` | Personel navigasyon özelliği (opsiyonel). |
| LoanDate | `public DateTime LoanDate { get; set; }` | Ödünç alma tarihi. |
| DueDate | `public DateTime DueDate { get; set; }` | Son iade tarihi. |
| ReturnDate | `public DateTime? ReturnDate { get; set; }` | Fiili iade tarihi (opsiyonel). |
| Status | `public LoanStatus Status { get; set; }` | Ödünç alma durumu. |
| Notes | `public string? Notes { get; set; }` | Notlar (opsiyonel). |
| RenewalCount | `public int RenewalCount { get; set; }` | Yapılan yenileme sayısı. |
| MaxRenewals | `public int MaxRenewals { get; set; }` | İzin verilen maksimum yenileme sayısı. |
| Fines | `public ICollection<Fine> Fines { get; set; }` | Uygulanan para cezaları koleksiyonu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Status = LoanStatus.Active`, `MaxRenewals = 2`, `Book` ve `Customer` null-forgiving ile başlatılmış, `Fines` boş koleksiyonla başlatılmış.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book`, `Customer`, `Staff`, `Fine`, `LoanStatus`, `BaseEntity`.
- **İlişkili tipler:** `Book`, `Customer`, `Staff`, `Fine`, `LoanStatus`.

---

### Genel Değerlendirme
Kod, Domain katmanında zengin ilişkisel alan modelini gösteriyor ancak davranış (iş kuralları, validasyon) içermiyor; tüm kurallar muhtemelen başka katmanlarda ele alınacak. Hedef framework, konfigürasyon ve diğer katman/proje referansları bu tek dosyadan belirlenemiyor. Entity, EF Core kullanımına uygun navigasyon ve koleksiyon kurulumları içeriyor ancak bu da doğrudan doğrulanmıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelini temsil eden domain varlıklarını sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen: Katmanlı mimari (Domain katmanı görülebiliyor). Domain katmanı; çekirdek iş kurallarını, entity ve enum’ları içerir. Keşfedilen projeler/assembly’ler: Library.Domain — domain varlıkları ve enum’lar. Harici paket/çatı bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)
^
[Diğer katmanlar bu dosyadan anlaşılmıyor]

---
### `Library.Domain/Entities/BookReservation.cs`

**1. Genel Bakış**
`BookReservation`, bir kitabın müşteri tarafından rezervasyonunu temsil eden domain varlığıdır. Kitap, müşteri, tarih aralığı, durum ve sıra bilgilerini tutar. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| `BookId` | `public Guid BookId { get; set; }` | İlişkili kitabın kimliği. |
| `Book` | `public Book Book { get; set; }` | İlişkili `Book` gezinti özelliği. |
| `CustomerId` | `public Guid CustomerId { get; set; }` | Rezervasyonu yapan müşterinin kimliği. |
| `Customer` | `public Customer Customer { get; set; }` | İlişkili `Customer` gezinti özelliği. |
| `ReservationDate` | `public DateTime ReservationDate { get; set; }` | Rezervasyonun oluşturulma tarihi. |
| `ExpiryDate` | `public DateTime ExpiryDate { get; set; }` | Rezervasyonun sona ereceği tarih. |
| `Status` | `public ReservationStatus Status { get; set; }` | Rezervasyon durumu; varsayılan `Pending`. |
| `Notes` | `public string? Notes { get; set; }` | Opsiyonel notlar. |
| `QueuePosition` | `public int QueuePosition { get; set; }` | Rezervasyon sırası. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılan durum: `Status = ReservationStatus.Pending`.
- `Book` ve `Customer` gezinti özellikleri `null!` ile işaretlenmiş; kullanımda null olmaları beklenmez.
- İş kuralı veya validasyon bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book`, `Customer`, `ReservationStatus`, `BaseEntity`.
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `Library.Domain.Entities.Customer`, `Library.Domain.Enums.ReservationStatus`.

Genel Değerlendirme
- Sadece Domain katmanı görülebiliyor; diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılamıyor.
- `BaseEntity` içeriği belirsiz; ortak alanlar (ör. `Id`, zaman damgaları) varsayılsa da bu dosyadan çıkarılamaz.
- Validasyon, durum geçişleri ve tarih tutarlılığı gibi iş kuralları kodda tanımlı değil; muhtemelen başka katman veya konfigürasyonda ele alınmalıdır.### Project Overview
Proje adı: Library (çıkarım). Amaç: kitap incelemelerini içeren bir kütüphane alan modeli sağlamak. Hedef çatı (Target Framework): bu dosyadan anlaşılmıyor. Mimari: Clean Architecture eğilimli katmanlı yapı; görünen katman Domain (iş kuralları ve entity tanımları). Keşfedilen proje/assembly: Library.Domain — Domain entity’leri ve temel modeller. Harici paketler/çatı: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] -> (diğer katmanlar bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Entities/BookReview.cs`

**1. Genel Bakış**
`BookReview`, bir kitabın müşteri tarafından yapılan incelemesini temsil eden Domain katmanı entity’sidir. Kitap ve müşteri ilişkilerini, puanlamayı ve onay durumunu tutar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
- `Book` — İlişkili kitap navigasyon nesnesi
- `Customer` — İncelemeyi yapan müşteri navigasyon nesnesi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookId | `public Guid BookId { get; set; }` | İlişkili kitabın kimliği. |
| Book | `public Book Book { get; set; }` | Kitap navigasyon özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | İncelemeyi yapan müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | Müşteri navigasyon özelliği. |
| Rating | `public int Rating { get; set; }` | İnceleme puanı. |
| Title | `public string? Title { get; set; }` | İncelemenin başlığı (opsiyonel). |
| Comment | `public string? Comment { get; set; }` | İnceleme metni (opsiyonel). |
| IsApproved | `public bool IsApproved { get; set; }` | Onay durumu. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO/Entity — davranış içermez. Default değerler: `IsApproved = false` (bool varsayılan), `Title = null`, `Comment = null`.
- `Book` ve `Customer` null-forgiving (`null!`) ile işaretlenmiş; çalışma zamanında null olmaması beklenir.
- `Rating` için aralık doğrulaması bu dosyada yok (örn. 1–5 arası).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Book`, `Customer`, `BaseEntity`.
- İlişkili tipler: `Book`, `Customer` (muhtemel diğer entity’ler).

**7. Eksikler ve Gözlemler**
- `Rating` aralığına ilişkin doğrulama veya kısıt bu dosyada tanımlı değil.
- Onay akışına (IsApproved) dair süreç/kurallar bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Domain katmanından tek bir entity görülüyor; diğer katmanlar ve akışlar bu dosyadan çıkarılamıyor.
- Doğrulama ve iş kuralları entity üzerine yansıtılmamış; muhtemelen başka katmanlarda uygulanıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki müşteri varlıklarının modellenmesi (Domain katmanı). Hedef framework bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimi; görünen katman sadece Domain. Keşfedilen assembly: Library.Domain — çekirdek varlıklar ve enum’lar. Dış paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)

---

### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer` bir kütüphane müşterisini temsil eden Domain varlığıdır. Müşteri kimlik, iletişim, üyelik ve ilişkilı işlem koleksiyonlarını tutar. Mimari olarak Domain katmanına aittir ve muhtemel kalıcı katman tarafından persist edilir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygılar:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres. |
| City | `public string City { get; set; }` | Şehir. |
| PostalCode | `public string? PostalCode { get; set; }` | Posta kodu. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| MembershipExpiryDate | `public DateTime? MembershipExpiryDate { get; set; }` | Üyelik bitiş tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| MaxBooksAllowed | `public int MaxBooksAllowed { get; set; }` | Maksimum ödünç kitap sayısı. |
| ProfileImageUrl | `public string? ProfileImageUrl { get; set; }` | Profil resmi URL. |
| DateOfBirth | `public DateTime? DateOfBirth { get; set; }` | Doğum tarihi. |
| BookLoans | `public ICollection<BookLoan> BookLoans { get; set; }` | Ödünç kayıtları. |
| BookReservations | `public ICollection<BookReservation> BookReservations { get; set; }` | Rezervasyonlar. |
| BookReviews | `public ICollection<BookReview> BookReviews { get; set; }` | İncelemeler. |
| Fines | `public ICollection<Fine> Fines { get; set; }` | Cezalar. |
| Notifications | `public ICollection<Notification> Notifications { get; set; }` | Bildirimler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName/LastName/Email/Phone/Address/City/MembershipNumber = string.Empty`, `MembershipType = MembershipType.Basic`, `IsActive = true`, `MaxBooksAllowed = 5`, koleksiyonlar boş `[]`.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama/Altyapı katmanlarındaki veri erişimi ve iş mantığı bileşenlerince kullanılabilir (bu dosyadan detay anlaşılmıyor).
- **Aşağı akış:** `BookLoan`, `BookReservation`, `BookReview`, `Fine`, `Notification` koleksiyon tipleri; `MembershipType` enum’u.
- **İlişkili tipler:** `BaseEntity` (kimlik/zaman damgası gibi alanlar barındırıyor olabilir — bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- Alan seviyesinde validasyon (örn. `Email` formatı, zorunlu alanlar) Domain içinde yer almıyor; doğrulama başka katmanlarda ele alınmalıdır. 

---

Genel Değerlendirme
Kod doğrudan Domain varlıklarını gösteriyor; katmanlar arası bağımlılık düzeni ve altyapı detayları bu dosyadan anlaşılamıyor. Varlıklar davranış içermiyor; iş kuralları ve doğrulama muhtemelen Application/Infrastructure katmanlarına bırakılmış. Bu yaklaşım Clean Architecture’a uygun olabilir, ancak güçlü tutarlılık için validasyon ve ilişki kuralları yer/katman netliği dokümante edilmelidir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki varlıkları modellemek (ör. cezalar). Hedef framework bu dosyadan anlaşılmıyor. Mimari, çok katmanlı (Domain katmanı görülüyor). Domain katmanı temel iş kurallarını ve varlıkları içerir. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan teyit edilemiyor. Keşfedilen proje/assembly: Library.Domain — domain varlıkları ve enum’lar. Harici paketler/framework’ler ve konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---
### `Library.Domain/Entities/Fine.cs`

**1. Genel Bakış**
`Fine`, bir kitap ödüncüne bağlı olarak müşteriye kesilen para cezasını temsil eden domain varlığıdır. Domain katmanına aittir ve cezanın tutarı, nedeni, durumu ve ödeme bilgilerini taşır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookLoanId | `public Guid BookLoanId { get; set; }` | İlgili ödünç alma kaydının kimliği. |
| BookLoan | `public BookLoan BookLoan { get; set; }` | İlgili `BookLoan` navigasyon özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Cezanın ait olduğu müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | İlgili `Customer` navigasyon özelliği. |
| Amount | `public decimal Amount { get; set; }` | Ceza tutarı. |
| Reason | `public string Reason { get; set; }` | Cezanın nedeni. |
| Status | `public FineStatus Status { get; set; }` | Cezanın durumu. |
| PaidDate | `public DateTime? PaidDate { get; set; }` | Ödeme tarihi (varsa). |
| PaymentMethod | `public string? PaymentMethod { get; set; }` | Ödeme yöntemi (varsa). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Reason = string.Empty`, `Status = FineStatus.Pending`, `BookLoan` ve `Customer` null-forgiving ile işaretlenmiş, `PaidDate = null`, `PaymentMethod = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity`, `BookLoan`, `Customer`, `FineStatus`.
- **İlişkili tipler:** `BookLoan`, `Customer`, `FineStatus`.

Genel Değerlendirme
- Sadece Domain varlığının görüldüğü bir kesit mevcut; diğer katmanlar ve akışlar doğrulanamıyor.
- Varlıkta iş kuralı/metot bulunmuyor; tüm kurallar muhtemelen başka katmanlarda ele alınıyor veya eksik.
- `BaseEntity` içeriği belirsiz; ortak alanlar (ör. `Id`, `CreatedAt`) varsayılamaz.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelini temsil eden varlıkları sağlamak. Hedef framework: .NET 6+ (TimeOnly kullanımı). Mimari: Clean Architecture eğilimli; bu depoda yalnızca Domain katmanı gözlemleniyor. Katmanlar: Domain (entity’ler ve temel tipler). Keşfedilen proje/assembly: Library.Domain — alan varlıkları. Görünen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Consumers] -> [Library.Domain]

---
### `Library.Domain/Entities/LibraryBranch.cs`

**1. Genel Bakış**
`LibraryBranch`, bir kütüphane şubesinin alan modelini temsil eder; adres, çalışma saatleri, iletişim bilgileri ve coğrafi konum gibi nitelikleri içerir. Domain katmanına aittir ve şube ile ilişkilendirilmiş `Book` ve `Staff` koleksiyonlarını barındırır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Name | `public string Name { get; set; }` | Şube adı. |
| Address | `public string Address { get; set; }` | Adres. |
| City | `public string City { get; set; }` | Şehir. |
| PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| Phone | `public string Phone { get; set; }` | Telefon. |
| Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| Description | `public string? Description { get; set; }` | Açıklama (opsiyonel). |
| OpeningTime | `public TimeOnly OpeningTime { get; set; }` | Açılış saati. |
| ClosingTime | `public TimeOnly ClosingTime { get; set; }` | Kapanış saati. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| Latitude | `public double? Latitude { get; set; }` | Enlem (opsiyonel). |
| Longitude | `public double? Longitude { get; set; }` | Boylam (opsiyonel). |
| Books | `public ICollection<Book> Books { get; set; }` | Şubedeki kitaplar. |
| Staff | `public ICollection<Staff> Staff { get; set; }` | Şubedeki personel. |

**5. Temel Davranışlar ve İş Kuralları**
Entity — davranış yok. Default değerler: `Name = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `Phone = string.Empty`, `IsActive = true`, `Books = []`, `Staff = []`. `PostalCode`, `Email`, `Description`, `Latitude`, `Longitude` opsiyonel.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity`, `Book`, `Staff`.
- **İlişkili tipler:** `Book`, `Staff`, `BaseEntity`.

Genel Değerlendirme
- Sadece Domain katmanı görünür; Application/Infrastructure/API katmanlarına dair kod yok.
- Varlık üzerinde doğrulama veya iş kuralı bulunmuyor; bu kurallar muhtemelen başka katmanlarda ele alınmalıdır (bu dosyadan doğrulanamıyor).
- Harici paket kullanımı ve yapılandırma anahtarları görünmüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait domain varlıklarını tanımlamak. Hedef çatı: .NET (spesifik sürüm bu dosyadan anlaşılmıyor). Mimari: Clean Architecture eğilimli; bu katman Domain olarak yalnızca varlık ve enum tanımları içerir, iş kurallarının çekirdeğini temsil eder. Keşfedilen projeler: Library.Domain — domain varlıkları, base entity ve enum’lar. Dış paketler: bu dosyadan görünmüyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] -> [Application] -> [Infrastructure] -> [Library.Domain]

---
### `Library.Domain/Entities/Notification.cs`

**1. Genel Bakış**
`Notification` bir müşteriye ait bildirim varlığıdır; başlık, mesaj, tür ve okuma/gönderilme zamanlarını taşır. Domain katmanına aittir ve muhtemelen persistence katmanında bir tabloya karşılık gelir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| CustomerId | `public Guid CustomerId { get; set; }` | Bildirimin ilişkili olduğu müşteri kimliği. |
| Customer | `public Customer Customer { get; set; }` | İlgili `Customer` navigasyon nesnesi. |
| Title | `public string Title { get; set; }` | Bildirim başlığı. |
| Message | `public string Message { get; set; }` | Bildirim içeriği. |
| Type | `public NotificationType Type { get; set; }` | Bildirim türü (enum). |
| IsRead | `public bool IsRead { get; set; }` | Bildirim okundu bilgisini tutar. |
| ReadAt | `public DateTime? ReadAt { get; set; }` | Okunma zamanı. |
| SentAt | `public DateTime? SentAt { get; set; }` | Gönderilme zamanı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Message = string.Empty`, `Customer = null!`, `IsRead = false`, `Type` varsayılan enum değeri, `ReadAt`/`SentAt = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Customer`, `BaseEntity`, `NotificationType`
- **İlişkili tipler:** `Customer` (entity), `NotificationType` (enum), `BaseEntity`

**7. Eksikler ve Gözlemler**
`IsRead` ile `ReadAt` arasındaki tutarlılık domain seviyesinde doğrulanmıyor; bu ilişki varsa uygulama veya persistence katmanında kural gerekebilir.

Genel Değerlendirme
Kod yalnızca Domain katmanına ait bir varlık sunuyor; mimarinin diğer katmanları görünmüyor. Varlıkta davranış/koruyucu kurallar bulunmadığından, iş kurallarının uygulama hizmetlerinde veya veri erişim katmanında sağlanması gerekecek. Dış bağımlılık ve konfigürasyon izine rastlanmadı.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki çekirdek varlıkları (ör. `Publisher`) tanımlamak. Hedef çatı: Bu dosyadan kesinleşmiyor; yalnızca Domain katmanı görülüyor. Mimari: Katmanlı/Clean Architecture eğilimli; görünen katman Domain (Entities). Keşfedilen proje/assembly: Library.Domain — domain modelleri ve taban tipler. Harici paketler: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyada yok.

### Architecture Diagram
Library.Domain (Entities)

---

### `Library.Domain/Entities/Publisher.cs`

**1. Genel Bakış**
`Publisher` bir yayınevini temsil eden domain entity’sidir. Yayıncıya ait temel kimlik ve iletişim bilgilerini tutar ve `Book` koleksiyonu ile ilişkilidir. Mimari olarak Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Name | `public string Name { get; set; }` | Yayınevi adı. Varsayılan `string.Empty`. |
| Address | `public string? Address { get; set; }` | Adres (opsiyonel). |
| City | `public string? City { get; set; }` | Şehir (opsiyonel). |
| Country | `public string? Country { get; set; }` | Ülke (opsiyonel). |
| Phone | `public string? Phone { get; set; }` | Telefon (opsiyonel). |
| Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| Website | `public string? Website { get; set; }` | Web sitesi (opsiyonel). |
| FoundedYear | `public int? FoundedYear { get; set; }` | Kuruluş yılı (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. Varsayılan `true`. |
| Books | `public ICollection<Book> Books { get; set; }` | İlişkili kitaplar koleksiyonu. Varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `IsActive = true`, `Books = []` (boş koleksiyon). Diğer alanlar `null` olabilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book` (ilişkili koleksiyon), `BaseEntity` (kalıtılan taban tip).
- **İlişkili tipler:** `Book`, `BaseEntity`.

**7. Eksikler ve Gözlemler**
- `Name`, `Email`, `Website`, `Phone` gibi alanlar için format/iş kuralı validasyonu entity içinde yok; doğrulama başka katmanlarda bekleniyorsa sorun değil, ancak bu dosyadan görülemiyor.

---

Genel Değerlendirme
Kod tabanında yalnızca Domain katmanından tek bir entity görülebiliyor. Mimari, Clean Architecture yönelimli görünse de diğer katmanlar (Application/Infrastructure/API) ve kalıtılan `BaseEntity` tanımı bu depoda gösterilmemiş. Hedef framework, harici bağımlılıklar ve konfigürasyon anahtarları bu dosyadan tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki çekirdek modellemeleri sağlamak (ör. personel). Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: Clean Architecture/N‑Katman eğilimli; görülen katman Domain. Keşfedilen projeler/assembly’ler: Library.Domain (rol: domain varlıkları ve değer nesneleri). Dış paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)
↑ (başka katmanlar bu dosyadan anlaşılmıyor)

---

### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff`, kütüphane personelini temsil eden domain varlığıdır. Kimlik ve iletişim bilgileri, rol, çalışma durumu ve şube ilişkilendirmesini tutar. Domain katmanına aittir ve diğer varlıklarla (ör. `LibraryBranch`, `BookLoan`) ilişkileri içerir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseEntity`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Position | `public string Position { get; set; }` | Pozisyon/unvan. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (enum). |
| Salary | `public decimal? Salary { get; set; }` | Opsiyonel maaş. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| TerminationDate | `public DateTime? TerminationDate { get; set; }` | İşten ayrılma tarihi (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| EmployeeNumber | `public string? EmployeeNumber { get; set; }` | Opsiyonel personel numarası. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Bağlı şube Id’si. |
| LibraryBranch | `public LibraryBranch? LibraryBranch { get; set; }` | Şube navigasyon özelliği. |
| ProcessedLoans | `public ICollection<BookLoan> ProcessedLoans { get; set; }` | Personelin işlediği ödünçler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `Role = StaffRole.Librarian`, `IsActive = true`, `ProcessedLoans = []`. `Salary`, `TerminationDate`, `EmployeeNumber`, `LibraryBranchId`, `LibraryBranch` null olabilir.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok; ilişkili navigasyonlar `LibraryBranch`, `BookLoan`.
- İlişkili tipler: `Library.Domain.Enums.StaffRole`, `Library.Domain.Entities.LibraryBranch`, `Library.Domain.Entities.BookLoan`, `BaseEntity`.

Genel Değerlendirme
- Sadece Domain katmanı görülebiliyor; diğer katmanlar ve akışlar bu dosyadan anlaşılamıyor.
- `Staff` üzerinde alan doğrulaması veya tutarlılık kuralları (ör. `TerminationDate >= HireDate`) tanımlı değil; bu kuralların nerede uygulandığı belirsiz.
- `BaseEntity` içeriği bilinmediğinden kimlik ve izleme özellikleri (Id, CreatedAt vb.) görünmüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki işlemler (ödünç, rezervasyon, ceza, bildirim, üyelik, personel) için domain düzeyinde sabit durum/sınıflandırma tanımları sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimi; bu repository’de yalnızca Domain katmanı görünüyor. Projeler: Library.Domain — domain modelleri ve sabitler. Harici paketler: bu dosyadan görünmüyor. Konfigürasyon gereksinimleri: bu dosyada yok.

### Architecture Diagram
Library.Domain (Enums)
  └─ bağımlılığı yok; diğer katmanlar tipik olarak Library.Domain’a bağımlı olur

---
### `Library.Domain/Enums/Enums.cs`

**1. Genel Bakış**
Kütüphane iş alanında kullanılan durum ve sınıflandırmaları temsil eden çoklu `enum` tanımları içerir. Domain katmanına aittir; entity/servislerde tutarlı durum yönetimi ve tip güvenliği sağlar.

**2. Tip Bilgisi**
- **Tip:** enum (çoklu)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Enums`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| `LoanStatus` | `public enum LoanStatus` | Ödünç verme durumlarını belirtir: `Active`, `Returned`, `Overdue`, `Lost`. |
| `ReservationStatus` | `public enum ReservationStatus` | Rezervasyon yaşam döngüsü: `Pending`, `Confirmed`, `Cancelled`, `Fulfilled`, `Expired`. |
| `FineStatus` | `public enum FineStatus` | Ceza tahsilat durumları: `Pending`, `Paid`, `Waived`. |
| `NotificationType` | `public enum NotificationType` | Bildirim tipleri: `LoanDueReminder`, `LoanOverdue`, `ReservationReady`, `ReservationExpired`, `FineIssued`, `General`. |
| `MembershipType` | `public enum MembershipType` | Üyelik seviyeleri: `Basic`, `Standard`, `Premium`, `Student`, `Senior`. |
| `BookCondition` | `public enum BookCondition` | Kitap fiziksel durumları: `New`, `Good`, `Fair`, `Poor`, `Damaged`, `Lost`. |
| `StaffRole` | `public enum StaffRole` | Personel rolleri: `Librarian`, `SeniorLibrarian`, `AssistantManager`, `Manager`, `Director`, `ITSupport`, `Volunteer`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: her enum için ilk üye varsayılan değer olur (ör. `LoanStatus.Active`, `ReservationStatus.Pending`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor; genellikle domain entity’leri, uygulama servisleri ve API modelleri tarafından kullanılır.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Domain katmanındaki enum’lar mevcut; diğer katmanlar ve kullanım yerleri görünmüyor.
- Hedef framework, paket bağımlılıkları ve konfigürasyonlar bu dosyadan tespit edilemiyor.
- Enum adları ve değerleri tutarlı ve alan odaklı; ileride genişletilebilirlik için uygun.### Project Overview
Proje adı: Library. Amaç: kütüphane domain’inde denetim (audit) kayıtları için depo sözleşmeleri tanımlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor). Mimari: katmanlı/Clean yaklaşımı; bu dosya Domain katmanına aittir. Keşfedilen derleme: Library.Domain — domain varlıkları ve arayüzler. Harici paketler: bu dosyadan görünmüyor. Konfigürasyon: bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Interfaces, Entities)
  └─ (Diğer katmanlar bu dosyadan belirlenemiyor; Domain bağımlılık yayımlamaz)

---
### `Library.Domain/Interfaces/IAuditLogRepository.cs`

**1. Genel Bakış**
`IAuditLogRepository`, `AuditLog` varlığı için okuma odaklı sorguları tanımlayan depo arayüzüdür. Domain katmanında, audit kayıtlarına erişim için sözleşme sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<AuditLog>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEntityAsync | `Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId)` | Belirli bir varlık adı ve kimliğine ait audit kayıtlarını döner. |
| GetByUserAsync | `Task<IEnumerable<AuditLog>> GetByUserAsync(string userId)` | Belirli bir kullanıcıya ait audit kayıtlarını döner. |
| GetByDateRangeAsync | `Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)` | Tarih aralığındaki audit kayıtlarını döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgu sözleşmeleri entity adı/ID, kullanıcı ID’si ve tarih aralığına göre filtrelemeyi hedefler.
- Dönüşler asenkron ve çoklu sonuç koleksiyonudur; sıralama/paginasyon sözleşmede tanımlı değil.
- `CancellationToken` parametresi sunulmamış.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** Yok.
- **İlişkili tipler:** `AuditLog`, `IRepository<AuditLog>`.

**7. Eksikler ve Gözlemler**
- Asenkron yöntemlerde `CancellationToken` eksik.
- Paging/sorting desteği yok; geniş veri setlerinde performans/paging ihtiyacı olabilir.

Genel Değerlendirme
- Mevcut kod yalnızca Domain katmanındaki bir depo arayüzünü gösteriyor; diğer katmanlar ve uygulamalar görünmüyor.
- İyileştirme: Asenkron imzalara `CancellationToken` eklemek ve gerekli ise paging/sorting sözleşmelerini tanımlamak.### Project Overview
Proje adı: Library. Amaç: kitap-yazar alanında domain sözleşmelerini tanımlamak (özellikle repository kontratları). Hedef çatı: bu dosyadan anlaşılmıyor. Mimari, katmanlı/Clean Architecture yaklaşımına uygun şekilde Domain katmanında arayüzler sağlar. Keşfedilen proje/assembly: Library.Domain — domain entity’leri ve repository arayüzleri. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain sözleşmeleri)
[Başka katmanlar bu dosyadan anlaşılmıyor]

---

### `Library.Domain/Interfaces/IAuthorRepository.cs`

**1. Genel Bakış**
`IAuthorRepository`, `Author` entity’si için repository kontratını genişletir ve arama ile ilişkili kitaplarla birlikte getirme işlemlerini tanımlar. Domain katmanında, persistance detaylarından bağımsız iş kurallarına uygun veri erişim sözleşmesi sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Author>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| SearchAsync | `Task<IEnumerable<Author>> SearchAsync(string searchTerm)` | Verilen arama terimine göre `Author` koleksiyonu döndürmeyi amaçlayan asenkron işlem. |
| GetWithBooksAsync | `Task<Author?> GetWithBooksAsync(Guid id)` | Belirli bir `Author`’ı ilişkili kitaplarıyla birlikte getirmeyi amaçlayan asenkron işlem. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme seviyesi tanımlar; somut sorgulama kriterleri ve eşleme stratejileri bu dosyadan anlaşılmıyor.
- `GetWithBooksAsync` ilişkili `Books` navigasyonunun yüklenmesini amaçlar; yükleme yöntemi (eager/explicit) bu dosyadan anlaşılmıyor.
- `SearchAsync` arama teriminin hangi alanlarda kullanıldığı (ad, soyad vb.) bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/kullanım noktaları bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Author`, `IRepository<Author>`

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` parametresi yok; uzun süren sorgular için iptal desteği eklenmesi düşünülebilir. 

---

### Genel Değerlendirme
Kod tabanı Domain sözleşmesine odaklı ve repository pattern kullanıyor. Sadece tek bir dosya görüldüğünden katmanlar arası bağımlılık akışı ve hedef çatı belirsiz. Asenkron işlemlerde iptal belirteci eksikliği dikkat çekiyor; uygulama genelinde tutarlı `CancellationToken` kullanımı önerilir.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelini tanımlamak ve kategori repo sözleşmesini sunmak. Hedef çatı: bu dosyadan anlaşılmıyor. Mimari: katmanlı/temiz mimari yaklaşımı izleniyor gibi; bu dosya Domain katmanına aittir. Keşfedilen projeler: Library.Domain — domain entity’leri ve repository arayüzleri. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  [başka katmanlar bu dosyadan anlaşılmıyor]

---

### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlıkları için repository sözleşmesini genişletir ve ada göre sorgulama, hiyerarşik ilişkiler ve aktif kategoriler gibi domain-özel sorguları tanımlar. Domain katmanında yer alır ve uygulama/altyapı katmanları tarafından implement edilmek üzere sözleşme sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<BookCategory>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre tek bir kategori döndürür; bulunamazsa `null`. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili kitaplarıyla birlikte kategoriyi getirir; yoksa `null`. |
| GetActiveCategoriesAsync | `Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync()` | Aktif durumdaki kategorileri listeler. |
| GetRootCategoriesAsync | `Task<IEnumerable<BookCategory>> GetRootCategoriesAsync()` | Üst kategorisi olmayan kök kategorileri listeler. |
| GetSubCategoriesAsync | `Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId)` | Belirtilen üst kategoriye ait alt kategorileri listeler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByNameAsync` ve `GetWithBooksAsync` sonuç bulunamadığında `null` dönecek şekilde tasarlanmıştır.
- `GetWithBooksAsync` ilişkili `Book` koleksiyonunun yüklenmesini ima eder (eager/explicit load kararı implementasyona aittir).
- “Aktif”, “kök” ve “alt” kategori kavramları domain’de var; filtreleme kriterleri uygulamada/altyapıda tanımlanacaktır.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama servisleri/use-case’ler (DI üzerinden çözümlenir).
- **Aşağı akış:** Harici bağımlılık yok (implementasyon veri erişimine bağlanır).
- **İlişkili tipler:** `BookCategory`, `IRepository<BookCategory>`

Genel Değerlendirme
- Sadece Domain katmanı görünür durumda; diğer katmanlar bu dosyadan anlaşılamıyor.
- Repository sözleşmesi tutarlı ve domain-özel sorguları kapsıyor; implementasyon, hata yönetimi ve performans konuları (ilişkili veri yükleme stratejileri, indeks kullanımı) altyapıda ele alınmalıdır.### Project Overview
Proje: Library.Domain — Amaç: kütüphane alan modelini ve sözleşmelerini tanımlamak (özellikle ödünç verme/loan akışları). Hedef framework bu dosyadan anlaşılmıyor. Mimari: Katmanlı (N-Tier) yaklaşımın Domain katmanı; repository sözleşmeleri ile persistence detaylarından bağımsızlık sağlar. Keşfedilen proje/assembly: Library.Domain (rol: entity’ler, enum’lar, repository arayüzleri). Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/IBookLoanRepository.cs`

**1. Genel Bakış**
Kütüphane ödünç verme işlemleri için `BookLoan` varlıklarına odaklı repository sözleşmesi. Farklı sorgu senaryoları (müşteriye, kitaba, duruma göre; aktif/gecikmiş) ve detay yüklü getirme ihtiyacını tanımlar. Domain katmanına aittir ve persistence implementasyonlarından bağımsızdır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<BookLoan>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm loan kayıtlarını döner. |
| GetByBookIdAsync | `Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın tüm loan kayıtlarını döner. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoan>> GetActiveLoansAsync()` | Şu an aktif olan loan’ları döner. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()` | Vadesi geçmiş loan’ları döner. |
| GetByStatusAsync | `Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)` | Verilen `LoanStatus`a göre loan’ları döner. |
| GetWithDetailsAsync | `Task<BookLoan?> GetWithDetailsAsync(Guid id)` | İlgili loan’ı ilişkili detaylarıyla birlikte döner. |
| GetActiveLoanCountByCustomerAsync | `Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)` | Müşterinin aktif loan sayısını döner. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımlamaz. Sözleşme, aktif ve gecikmiş ayrımlarının veri katmanında doğru filtrelenmesini ve `GetWithDetailsAsync` ile ilişkilerin eager loading yapılmasını ima eder.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/servis katmanı tarafından çağrılır.
- **Aşağı akış:** Harici bağımlılık yok (implementasyon tarafında veri erişimi olacaktır).
- **İlişkili tipler:** `BookLoan` (entity), `LoanStatus` (enum), `IRepository<BookLoan>` (genel repository sözleşmesi).

Genel Değerlendirme
- Sadece Domain sözleşmesi mevcut; Application/Infrastructure/API katmanları bu veriyle görünmüyor.
- `IRepository<BookLoan>` detayları görünmediğinden temel CRUD kapsamı belirsiz; özel sorgular iyi tanımlanmış.
- Pagination/sıralama gibi çapraz kesen endişeler arayüzde yer almıyor; ihtiyaç varsa genişletme gerekebilir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki `Book` varlıkları için depo sözleşmelerini tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari, en azından Domain katmanını içeren katmanlı bir düzeni işaret ediyor; burada domain arayüzleri ve varlıklar tanımlanmış. Keşfedilen proje/assembly: Library.Domain — domain varlıkları ve repository arayüzleri. Görünen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlığı için okuma/arama odaklı depo sözleşmesini genişletir. Domain katmanında yer alır ve uygulama/infrastructure katmanlarında somut veri erişim implementasyonlarına kılavuzluk eder.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Book>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
- `IRepository<Book>` — Ortak CRUD sözleşmesini sağlar
- `Book` — Hedef domain varlığı

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Uygun/ödünç verilebilir kitapları döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre tek kitabı getirir. |
| GetByAuthorIdAsync | `Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)` | Yazara göre kitapları listeler. |
| GetByCategoryIdAsync | `Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)` | Kategoriye göre kitapları listeler. |
| GetByBranchIdAsync | `Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)` | Şubeye göre kitapları listeler. |
| GetByPublisherIdAsync | `Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)` | Yayıncıya göre kitapları listeler. |
| SearchAsync | `Task<IEnumerable<Book>> SearchAsync(string searchTerm)` | Serbest metin araması yapar. |
| GetWithDetailsAsync | `Task<Book?> GetWithDetailsAsync(Guid id)` | İlgili detaylarla (ilişkilerle) kitabı getirir. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımsız; gerçekleme veri kaynağına ve sorgu stratejisine bağlıdır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir
- **Aşağı akış:** `IRepository<Book>`
- **İlişkili tipler:** `Book`

**7. Eksikler ve Gözlemler**
- Tüm async imzalarda `CancellationToken` parametresi yok; uzun süren veri işlemlerinde iptal desteği eklenmesi faydalı olabilir.
- Sayfalama desteği (limit/offset) tanımlı değil; büyük veri setlerinde performans için düşünülebilir.

---

Genel Değerlendirme
Kod tabanında yalnızca Domain katmanına ait bir repository arayüzü görülüyor. İmzalarda iptal belirteci ve sayfalama eksikliği dikkat çekiyor. Diğer katmanlar (Application/Infrastructure/Presentation) ve ortak paket kullanımları bu girdiyle belirlenemiyor. Implementasyonların hata yönetimi, güvenlik ve performans konularını ele alması gerekecektir.### Project Overview
Proje adı: Library. Amaç: kütüphane rezervasyon alanı için domain sözleşmeleri ve tiplerini tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Domain odaklı (Clean Architecture/N‑Tier benzeri); görünen katman yalnızca Domain. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor. Keşfedilen proje/assembly: Library.Domain — Entities, Enums, Interfaces barındırır. Harici paket kullanımı bu dosyadan görünmüyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums, Interfaces)
↑ (başka katman bağımlılıkları bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Interfaces/IBookReservationRepository.cs`

**1. Genel Bakış**
`IBookReservationRepository`, `BookReservation` varlıkları için okuma/arama odaklı repository sözleşmesini tanımlar. Domain katmanında yer alır ve rezervasyonların müşteri, kitap, durum ve vade sonuna göre sorgulanmasını standartlaştırır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<BookReservation>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)` | Verilen müşteri kimliğiyle ilişkili rezervasyonları döner. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)` | Verilen kitap kimliği için tüm rezervasyonları döner. |
| GetByStatusAsync | `Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)` | Rezervasyon durumuna göre filtreler. |
| GetExpiredReservationsAsync | `Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()` | Süresi geçmiş rezervasyonları getirir. |
| GetWithDetailsAsync | `Task<BookReservation?> GetWithDetailsAsync(Guid id)` | İlgili detaylarıyla tek rezervasyonu getirir (ilişkili veriler dahil). |

**5. Temel Davranışlar ve İş Kuralları**
- Arama/sorgu amaçlı sözleşme; implementasyon detayları bu dosyadan anlaşılmıyor.
- `GetWithDetailsAsync` ilişkili navigasyonların yüklenmesini ima eder.
- Dönüşler asenkron ve koleksiyon bazlıdır; sıralama/paginasyon sözleşmede tanımlı değildir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; çağıranlar bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BookReservation`, `ReservationStatus`, `IRepository<BookReservation>`.
- **İlişkili tipler:** `BookReservation` (Entity), `ReservationStatus` (Enum), `IRepository<T>` (genel repository sözleşmesi).

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` desteği yok.
- Paginasyon/sıralama sözleşmesi tanımlı değil; büyük veri setlerinde performans sorunlarına yol açabilir.

Genel Değerlendirme
- Mevcut kod yalnızca Domain katmanında bir repository sözleşmesini ortaya koyuyor; diğer katmanlar görünmüyor.
- Asenkron API’lerde `CancellationToken` eksikliği ve sorgular için paginasyon/sıralama kriterlerinin belirtilmemesi ileride performans ve iptal kontrolü açısından geliştirme alanlarıdır.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı)
- Amaç: Kütüphane alan modelinde kitap yorumlarına yönelik repository sözleşmelerini tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; Domain katmanında arayüzler ve varlıklar tanımlı.
- Projeler/Assembly’ler:
  - Library.Domain — Domain katmanı; entity’ler ve repository arayüzleri.
- Kullanılan dış paketler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IBookReviewRepository.cs`

**1. Genel Bakış**
Kitap yorumları (`BookReview`) için veri erişim sözleşmesini tanımlar. Domain katmanında, uygulama ve altyapı katmanları arasında gevşek bağlılık sağlar. Kitaba ve müşteriye göre sorgular, onaylı yorumlar ve ortalama puan işlemlerini soyutlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<BookReview>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByBookIdAsync | `Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)` | Belirli kitaba ait tüm yorumları asenkron döner. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin yazdığı tüm yorumları asenkron döner. |
| GetApprovedReviewsByBookAsync | `Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)` | Belirli kitaba ait onaylanmış yorumları asenkron döner. |
| GetAverageRatingByBookAsync | `Task<double> GetAverageRatingByBookAsync(Guid bookId)` | Belirli kitabın ortalama puanını asenkron hesaplayıp döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular asenkron tasarlanmıştır.
- Ortalama puan hesaplamasının boş yorum kümesinde nasıl davrandığı bu dosyadan anlaşılmıyor (örn. 0 mı döner, exception mı fırlatır).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/kullanım durumları tarafından çağrılması beklenir (bu dosyadan doğrudan görülmüyor).
- **Aşağı akış:** `IRepository<BookReview>` kontratındaki genel CRUD işlemlerini genişletir.
- **İlişkili tipler:** `BookReview` entity, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri yok; uzun süren veri erişimlerinde iptal desteği eksik.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki müşteri varlığını yönetmek için domain sözleşmeleri (repository arayüzleri) sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen: Clean Architecture (çıkarım) — görülen katman Domain; Entities ve Interfaces içerir. Diğer katmanlar (Application, Infrastructure, API) bu dosyadan anlaşılmıyor. Keşfedilen proje/assembly: Library.Domain — domain model ve repository kontratları. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---
### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` varlığı için sorgu odaklı repository sözleşmesi sunar. Domain katmanında yer alır ve uygulama/infrastructure katmanlarının müşteri verisini alma senaryolarına yönelik ihtiyaçlarını tanımlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Customer>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E‑posta ile müşteriyi getirir; yoksa `null`. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarası ile müşteriyi getirir; yoksa `null`. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif müşterileri döndürür. |
| GetWithLoansAsync | `Task<Customer?> GetWithLoansAsync(Guid id)` | Verilen müşteri ile ilişkili ödünç alma bilgileri yüklü müşteri döner. |
| GetWithReservationsAsync | `Task<Customer?> GetWithReservationsAsync(Guid id)` | Rezervasyonları yüklü müşteri döner. |
| SearchAsync | `Task<IEnumerable<Customer>> SearchAsync(string searchTerm)` | Arama terimi ile müşterileri arar. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgu metotları asenkron ve bulunamadığında `null` dönebilir.
- `GetWithLoansAsync`/`GetWithReservationsAsync` ilişkili gezinme verilerini yüklemeyi hedefler.
- `SearchAsync` serbest metin araması için sözleşme sağlar; sıralama/sayfalama bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama hizmetleri/handler’lar tarafından kullanılabilir.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Customer` (Entity), `IRepository<Customer>` (genel CRUD sözleşmesi — üyeleri bu dosyada görünmüyor).

**7. Eksikler ve Gözlemler**
- Tüm asenkron metotlarda `CancellationToken` parametresi eksik.
- `SearchAsync` için sayfalama/sıralama sözleşmesi yok; büyük veri kümelerinde performans riski oluşturabilir.

Genel Değerlendirme
- Yalnızca Domain katmanı görülebiliyor; Clean Architecture uyumlu bir repository sözleşmesi tanımlanmış.
- Asenkron operasyonlarda `CancellationToken` ve arama/sayfalama sözleşmelerinin eklenmesi genişleyebilirlik ve performans için faydalı olacaktır.
- Diğer katmanlar ve altyapı implementasyonları bu depo görünümünde mevcut değil, tutarlılık analizi yapılamıyor.### Project Overview (required, once)
Proje adı koddan “Library” olarak anlaşılıyor. Amaç: kütüphane alanındaki ceza (“fine”) varlıkları için depo (repository) sözleşmesi tanımlamak. Hedef çatı .NET, kesin sürüm bu dosyadan anlaşılmıyor. Mimari olarak Domain katmanında repository arabirimi kullanımı, katmanlı/temiz mimariye işaret eder. Keşfedilen proje/assembly: Library.Domain (Entities, Enums, Interfaces). Dış bağımlılık görünmüyor. Yapılandırma gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram (required, once)
Library.Domain
  ├─ Entities
  ├─ Enums
  └─ Interfaces → depends on Entities, Enums

---

### `Library.Domain/Interfaces/IFineRepository.cs`

**1. Genel Bakış**
`IFineRepository`, `Fine` varlıkları için sorgu operasyonlarını tanımlayan domain düzeyi repository sözleşmesidir. Müşteri bazlı, durum bazlı, bekleyen cezalar ve toplam ödenmemiş ceza tutarı sorgularını soyutlar. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Fine>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm cezalarını döndürür. |
| GetByStatusAsync | `Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)` | Verilen `FineStatus` durumuna göre cezaları döndürür. |
| GetPendingFinesAsync | `Task<IEnumerable<Fine>> GetPendingFinesAsync()` | Bekleyen/işlem görmemiş cezaları listeler. |
| GetTotalUnpaidFinesByCustomerAsync | `Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)` | Müşterinin toplam ödenmemiş ceza tutarını hesaplar. |

**5. Temel Davranışlar ve İş Kuralları**
- Asenkron sorgu sözleşmeleri tanımlar; iptal desteği (CancellationToken) yok.
- “Pending” ve “Unpaid” ayrımı/filtre mantığı bu dosyadan anlaşılmıyor.
- Toplam tutar `decimal` olarak dönülür; para birimi belirtilmemiş.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; domain sözleşmesi olarak application/infrastructure tarafından uygulanır/kullanılır.
- **Aşağı akış:** `Fine` (entity), `FineStatus` (enum), `IRepository<Fine>` (temel repository sözleşmesi).
- **İlişkili tipler:** `Library.Domain.Entities.Fine`, `Library.Domain.Enums.FineStatus`, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri eksik; uzun süren sorgular için iptal desteği yok.
- `IRepository<Fine>` tanımı bu depoda görünmüyor; sözleşmenin kapsamı belirsiz.

---

Genel Değerlendirme
- Yalnızca Domain katmanı görünür; temel repository sözleşmesi temizdir ancak iptal ve hata yönetimi sözleşme düzeyinde düşünülmemiş.
- Para birimi, “pending/unpaid” tanımları ve sıralama/sayfalama gibi sözleşme detayları belirtildiğinde uygulama tutarlılığı artar.
- `IRepository<T>` kontratı görünmediğinden, ortak CRUD kapsamı ve davranışlar net değil.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelleri ve sözleşmelerini tanımlamak. Hedef çatı bu dosyadan anlaşılmıyor. Kod, `Domain` katmanında entity ve repository sözleşmelerini barındırıyor. Mimari, Domain merkezli (Clean Architecture/N-Tier eğilimli) bir yapıyı işaret ediyor: uygulama/infrastructure katmanları bu sözleşmeleri kullanarak veri erişimini uygular. Keşfedilen proje: `Library.Domain` — entity’ler ve repository arayüzleri. Harici paket kullanımı ve konfigürasyon anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Tüketiciler (Application/Infrastructure)] -> Library.Domain

---
### `Library.Domain/Interfaces/ILibraryBranchRepository.cs`

**1. Genel Bakış**
`ILibraryBranchRepository`, `LibraryBranch` için genel `IRepository<T>` sözleşmesini genişleterek şube özel sorgularını tanımlar (`aktif şubeler`, `personelle`, `kitaplarla`). Domain katmanına aittir ve veri erişimi implementasyonları için sözleşme sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<LibraryBranch>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()` | Aktif olarak işaretlenmiş şubeleri döndürür. |
| GetWithStaffAsync | `Task<LibraryBranch?> GetWithStaffAsync(Guid id)` | Belirli şubeyi ilişkili personel ile birlikte getirir; bulunamazsa `null`. |
| GetWithBooksAsync | `Task<LibraryBranch?> GetWithBooksAsync(Guid id)` | Belirli şubeyi ilişkili kitaplarla birlikte getirir; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme — davranış tanımı yok; aktiflik kriteri ve ilişki yükleme stratejisi implementasyona bırakılır.
- `Guid` bazlı aramalarda bulunamazsa `null` döner; exception sözleşmesi tanımlı değil.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri tarafından çağrılması beklenir.
- **Aşağı akış:** Implementasyon katmanı (ör. veri erişimi) tarafından uygulanır.
- **İlişkili tipler:** `Library.Domain.Entities.LibraryBranch`, `IRepository<LibraryBranch>`

**7. Eksikler ve Gözlemler**
- Async metotlarda `CancellationToken` parametresi yok; uzun süren sorgular için iptal desteği eksik olabilir.

### Genel Değerlendirme
Kod, Domain katmanında repository sözleşmesini tanımlayarak temiz ayrım sağlar. Ancak tek dosyadan mimarinin tamamı, hedef çatı ve harici bağımlılıklar çıkarılamıyor. Sözleşmede iptal desteği ve olası filtreleme/sayfalama gibi kesme noktaları tanımlanmadığından, uygulama katmanında performans ve dayanıklılık için ek düzenlemeler gerekebilir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına ait `Domain` katmanında bildirimlere yönelik repository sözleşmesini tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari yaklaşım: katmanlı/alan odaklı tasarım; sadece Domain katmanı görülüyor. Keşfedilen proje/assembly: Library.Domain — Entity ve repository arayüzleri. Harici paketler bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---

### `Library.Domain/Interfaces/INotificationRepository.cs`

**1. Genel Bakış**
Müşteri bildirimleri için okuma/işaretleme operasyonlarını tanımlayan repository arayüzüdür. Domain katmanında persistence sözleşmesi sağlar; uygulama ve altyapı arasında bağımlılık tersine çevirmeye hizmet eder.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `Yok`
- **Uygular:** `IRepository<Notification>`
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşteriye ait tüm bildirimleri getirir. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)` | Belirli müşterinin okunmamış bildirimlerini getirir. |
| GetUnreadCountByCustomerIdAsync | `Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)` | Müşterinin okunmamış bildirim sayısını döner. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Tek bir bildirimi okundu olarak işaretler. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm bildirimlerini okundu olarak işaretler. |

**5. Temel Davranışlar ve İş Kuralları**
- Domain sözleşmesi; veri erişim ayrıntıları ve hata yönetimi bu arayüzde tanımlı değil.
- Metotlar asenkron ve I/O odaklı kullanım için tasarlanmış görünür.
- Okunmamış bildirimlerin filtrelenmesi ve işaretleme işlemlerinin nasıl yapıldığı implementasyona bırakılmıştır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından kullanılabilir.
- **Aşağı akış:** `IRepository<Notification>` sözleşmesinin genelleyici üyeleri; `Notification` entity’si.
- **İlişkili tipler:** `Notification`, `IRepository<T>`

Genel Değerlendirme
- Sadece Domain arayüzü mevcut; implementasyon ve üst katman kullanımları görünmüyor.
- Hedef framework, paketler ve konfigürasyonlar belirlenemiyor.
- Arayüz tutarlı ve amaç odaklı; okuma/işaretleme senaryoları net tanımlanmış.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki yayıncı (`Publisher`) varlığı için domain katmanında repository sözleşmeleri tanımlamak. Hedef çatı: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: Katmanlı/Clean Architecture eğilimli; bu dosyada yalnızca Domain katmanı (Entities, Interfaces) görülüyor. Keşfedilen proje/assembly: Library.Domain — domain entity’leri ve repository arayüzleri. Dış paketler: Bu dosyadan görünmüyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

Not: Diğer katmanlar ve bağımlılık akışı bu dosyadan anlaşılmıyor.

---
### `Library.Domain/Interfaces/IPublisherRepository.cs`

**1. Genel Bakış**
`IPublisherRepository`, `Publisher` varlığı için repository sözleşmesini genişletir ve ada göre arama, ilişkili kitaplarla birlikte getirme ve aktif yayıncıları listeleme operasyonlarını tanımlar. Domain katmanında bulunur ve uygulama/infrastructure katmanları için bir port görevi görür.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Publisher>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<Publisher?> GetByNameAsync(string name)` | Ada göre tek bir `Publisher` döner (yoksa `null`). |
| GetWithBooksAsync | `Task<Publisher?> GetWithBooksAsync(Guid id)` | Belirtilen `id` için ilişkili kitaplarla birlikte `Publisher` döner. |
| GetActivePublishersAsync | `Task<IEnumerable<Publisher>> GetActivePublishersAsync()` | Aktif durumdaki tüm yayıncıları döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Interface — davranış tanımlamaz; uygulamalar veriyi ada göre arama, ilişkili `Books` koleksiyonunu eager loading ile getirme ve “aktif” filtrelemesini sağlamalıdır.
- “Aktif” kriterinin nasıl belirlendiği bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya use-case’ler tarafından çağrılır.
- **Aşağı akış:** `IRepository<Publisher>`, `Library.Domain.Entities.Publisher`
- **İlişkili tipler:** `Publisher`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- Async imzalarda `CancellationToken` parametresi yok; uzun süren sorgularda iptal desteği eksik olabilir.
- Aktif yayıncılar için sayfalama/paging imzası bulunmuyor; büyük veri setlerinde verimsizlik yaratabilir.

---
### Genel Değerlendirme
Kod, Domain katmanında temiz bir repository sözleşmesi sunuyor. Ancak asenkron imzalarda `CancellationToken` eksikliği ve listeleme operasyonları için sayfalama sözleşmesinin bulunmaması ileride scalability ve dayanıklılık açısından sınırlayıcı olabilir. Diğer katmanlar ve altyapı detayları bu depoda görünmüyor; uygulama ve veri erişim stratejileri belirsiz.### Project Overview
Proje adı: Library. Amaç: domain odaklı bir kütüphane sistemi için veri erişim soyutlamalarını tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen: katmanlı/Domain odaklı; görülen katman: Domain (soyutlamalar). Keşfedilen proje/assembly: Library.Domain — domain arayüzleri ve sözleşmeleri. Harici paketler: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
`IRepository<T>` generic repository sözleşmesini tanımlar; CRUD, sayfalama, varlık sayımı ve kriter bazlı sorgular için metotlar sunar. Domain katmanında yer alır ve veri erişim detaylarını soyutlamak için kullanılır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Kimliğe göre tek varlığı asenkron getirir. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları asenkron döner. |
| FindAsync | `Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)` | Lambda ifadesiyle filtrelenmiş varlıkları getirir. |
| GetPagedAsync | `Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)` | Sayfalı sonuç ve toplam kayıt sayısını döner. |
| CountAsync | `Task<int> CountAsync()` | Toplam kayıt sayısını döner. |
| CountAsync | `Task<int> CountAsync(Expression<Func<T, bool>> predicate)` | Koşula uyan kayıt sayısını döner. |
| ExistsAsync | `Task<bool> ExistsAsync(Guid id)` | Kimliğe göre varlık var mı kontrol eder. |
| AddAsync | `Task AddAsync(T entity)` | Yeni varlık ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut varlığı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kimliğe göre varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış içermez. Anlamlı noktalar: sayfalama için `pageNumber`/`pageSize` parametreleri, filtreleme için `Expression<Func<T,bool>>` kullanımı, silme/güncelleme/ekleme asenkron sözleşme düzeyinde tanımlıdır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `T` generic varlık tipi.

**7. Eksikler ve Gözlemler**
- `GetPagedAsync` için sıralama desteği sözleşmede tanımlı değil; deterministik sayfalama için genelde sıralama gerekli olabilir.

---

Genel Değerlendirme
Kod tabanında sadece Domain katmanına ait bir repository arayüzü görülüyor. Uygulama, Infrastructure ve API katmanları bu dosyadan çıkarılamıyor. Sözleşme kapsamlı olsa da sayfalama için sıralama/filtre kombinasyonları ve iptal belirteci (`CancellationToken`) desteği eklenmesi düşünülebilir.### Project Overview
Proje adı muhtemelen “Library” ve bu dosyadan görülen katman “Domain”. Amaç: kütüphane personeli (`Staff`) için depo (repository) sözleşmelerini tanımlamak. Hedef çatı .NET, kesin sürüm bu dosyadan anlaşılmıyor. Mimari örüntü Clean Architecture/N-Tier’a uygun: Domain katmanında sadece arayüzler ve varlıklar. Keşfedilen proje/assembly: Library.Domain — domain varlıkları ve repository arayüzleri. Harici paket bilgisi bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` varlıkları için depo sözleşmesini tanımlar. Domain katmanında yer alır; `IRepository<Staff>`’i genişleterek personeli e-posta, şube, aktiflik ve sicil numarasına göre sorgulama operasyonlarını belirtir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Staff>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | E-postaya göre tekil personeli getirir. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki personel listesini döner. |
| GetByBranchIdAsync | `Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)` | Şube kimliğine göre personel listesini döner. |
| GetByEmployeeNumberAsync | `Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)` | Sicil numarasına göre tekil personeli getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Asenkron okuma odaklı sözleşme; filtreleme kriterleri: e-posta, `branchId`, `employeeNumber`, aktiflik durumu.
- `null` dönebilme, “bulunamadı” durumunu ifade eder.
- Koleksiyon dönen üyeler boş koleksiyon dönebilir (uygulamaya bağlı).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından çağrılması beklenir (bu dosyadan kesin değil).
- **Aşağı akış:** Yok (sadece sözleşme).
- **İlişkili tipler:** `Library.Domain.Entities.Staff`, `IRepository<Staff>`.

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri yok; yoğun I/O senaryolarında faydalı olabilir.

---

Genel Değerlendirme
- Sadece Domain katmanı görünür durumda; diğer katmanlar bu depoda/çıktıda yer almıyor.
- Repository sözleşmeleri net; ancak iptal belirteci olmaması ve olası paging/sıralama ihtiyaçlarının belirtilmemesi ileri kullanımda eksik kalabilir.### Project Overview
Proje adı: Library. Amaç: kütüphane yönetimi (kitap, yazar, yayınevi, ödünç, rezervasyon, ceza vb.) verilerinin kalıcı katmanda yönetimi. Hedef çatı: bu dosyadan anlaşılmıyor (modern .NET, EF Core kullanımı). Mimari: Clean Architecture benzeri; `Infrastructure` katmanı EF Core ile veri erişimi sağlar, `Domain` entity’leri barındırır. Proje/assembly’ler: `Library.Domain` (entity’ler), `Library.Infrastructure` (EF Core `DbContext`). Dış bağımlılıklar: `Microsoft.EntityFrameworkCore`. Konfigürasyon: `DbContext` için connection string gerekir; anahtar adı/sağlayıcı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure

---
### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
EF Core `DbContext`’i; kütüphane domain entity’lerinin tablo eşlemelerini, ilişkileri, indeksleri ve soft delete filtrelerini tanımlar. Mimari olarak Infrastructure/Veri Erişimi katmanındadır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlam seçenekleri (sağlayıcı, bağlantı, vb.)

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | Bağlamı konfigüre eder |
| Books | `DbSet<Book> Books { get; }` | Kitaplar |
| BookCategories | `DbSet<BookCategory> BookCategories { get; }` | Kategoriler |
| Authors | `DbSet<Author> Authors { get; }` | Yazarlar |
| Publishers | `DbSet<Publisher> Publishers { get; }` | Yayınevleri |
| Staff | `DbSet<Staff> Staff { get; }` | Personel |
| Customers | `DbSet<Customer> Customers { get; }` | Müşteriler |
| BookLoans | `DbSet<BookLoan> BookLoans { get; }` | Ödünçler |
| BookReservations | `DbSet<BookReservation> BookReservations { get; }` | Rezervasyonlar |
| Fines | `DbSet<Fine> Fines { get; }` | Cezalar |
| LibraryBranches | `DbSet<LibraryBranch> LibraryBranches { get; }` | Şubeler |
| BookReviews | `DbSet<BookReview> BookReviews { get; }` | İncelemeler |
| Notifications | `DbSet<Notification> Notifications { get; }` | Bildirimler |
| AuditLogs | `DbSet<AuditLog> AuditLogs { get; }` | Denetim kayıtları |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Eşlemeleri/kuralları yapılandırır |

**5. Temel Davranışlar ve İş Kuralları**
- Global soft delete filtresi: çoğu entity için `!IsDeleted`.
- Zorunlu alanlar ve uzunluklar: ör. `Book.Title` (300), `Author.FirstName/LastName` (100), `Publisher.Name` (200) vb.
- Benzersiz indeksler: `Book.ISBN`, `BookCategory.Name`, `Staff.Email`, `Staff.EmployeeNumber` (nullable filtered), `Customer.Email`, `Customer.MembershipNumber`, `BookReview (BookId, CustomerId)`, `LibraryBranch.Name`.
- Hassasiyet: parasal alanlarda `HasPrecision(10, 2)`.
- İlişkiler ve silme davranışları: ör. `Book.Author` Restrict; `Book.Publisher/Category/LibraryBranch` SetNull; `BookLoan.Book/Customer` Restrict; `BookReview.Book` Cascade; `Notification.Customer` Cascade vb.
- Sorgu performansı için indeksler: durum/tarih alanlarında (`Status`, `DueDate`, `Timestamp`).

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `Microsoft.EntityFrameworkCore`, `Library.Domain.Entities` tipleri.
- İlişkili tipler: `Book`, `BookCategory`, `Author`, `Publisher`, `Staff`, `Customer`, `BookLoan`, `BookReservation`, `Fine`, `LibraryBranch`, `BookReview`, `Notification`, `AuditLog`.

**7. Eksikler ve Gözlemler**
- Soft delete filtresi `AuditLog` için yok; kasıtlı olabilir ancak tutarlılık açısından not edilmeli.
- `HasFilter("[EmployeeNumber] IS NOT NULL")` sağlayıcıya (SQL Server) özgü; farklı sağlayıcılarda taşınabilirlik etkilenebilir.

---
Genel Değerlendirme
Kod tabanı, Infrastructure katmanında zengin bir EF Core modellemeye sahip ve domain odaklı kuralları (benzersiz indeksler, ilişkiler, silme kuralları) net tanımlıyor. Soft delete tutarlılığı ve sağlayıcıya özgü indeks filtresi taşınabilirlik açısından gözden geçirilebilir. Konfigürasyon anahtarları ve hedef çatı sürümü koddan çıkarılamıyor.### Project Overview
Proje adı: Library (gözlemlenen namespace’lerden). Amaç: kütüphane alanına ait depolama ve altyapı servislerinin DI ile kaydı ve EF Core veritabanı erişiminin yapılandırılması. Hedef framework: bu dosyadan kesin olarak anlaşılamıyor. Mimari, Domain/Application/Infrastructure katmanlarıyla Clean Architecture’a uyumlu görünüyor. Keşfedilen projeler: Library.Domain (domain sözleşmeleri), Library.Application (use case/contractlar), Library.Infrastructure (EF Core ve repository implementasyonları). Dış paketler: EF Core SqlServer, Microsoft.Extensions.*. Konfigürasyon: “DefaultConnection” bağlantı dizesi, SQL Server, komut zaman aşımı 30 sn, retry politikası (3 deneme), migrasyon assembly’si `LibraryDbContext`’in assembly’si.

### Architecture Diagram
Library.Domain  <—  Library.Infrastructure
Library.Application  <—  Library.Infrastructure

Not: Yalnızca bu dosyada görülen bağımlılıklar gösterilmiştir.

---
### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
Altyapı katmanının DI kayıt noktasını sağlar. EF Core `LibraryDbContext` için SQL Server yapılandırmasını ve çok sayıda repository arayüzü–implementasyon eşlemesini `Scoped` yaşam süresiyle kaydeder. Clean Architecture’ın Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core ve repository’leri DI konteynerine ekler. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server ile kaydedilir; retry politikası: 3 deneme, 10 sn maksimum gecikme.
- Komut zaman aşımı 30 saniye olarak ayarlanır.
- Migrasyon assembly’si `LibraryDbContext`’in assembly adından belirlenir.
- Aşağıdaki repository eşlemeleri `Scoped` olarak kaydedilir: `IBookRepository`→`BookRepository`, `IBookCategoryRepository`→`BookCategoryRepository`, `IStaffRepository`→`StaffRepository`, `ICustomerRepository`→`CustomerRepository`, `IAuthorRepository`→`AuthorRepository`, `IPublisherRepository`→`PublisherRepository`, `IBookLoanRepository`→`BookLoanRepository`, `IBookReservationRepository`→`BookReservationRepository`, `IFineRepository`→`FineRepository`, `ILibraryBranchRepository`→`LibraryBranchRepository`, `IBookReviewRepository`→`BookReviewRepository`, `INotificationRepository`→`NotificationRepository`, `IAuditLogRepository`→`AuditLogRepository`.

**6. Bağlantılar**
- **Yukarı akış:** Kompozisyon kökü (ör. barındırma başlangıç kodu) tarafından çağrılır; spesifik çağıran bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `LibraryDbContext`, çeşitli repository implementasyonları, EF Core SQL Server sağlayıcısı.
- **İlişkili tipler:** `Library.Infrastructure.Data.LibraryDbContext`, `Library.Infrastructure.Repositories.*`, ilgili `Library.Domain.Interfaces.*` arayüzleri.

**7. Eksikler ve Gözlemler**
- `using Library.Application.Email;` ve `using Library.Infrastructure.Email;` mevcut fakat e-posta ile ilgili bir servis kaydı yok; bu, eksik DI kaydı veya kullanılmayan using olabilir. 

---
Genel Değerlendirme
- Altyapı DI modülü tutarlı ve EF Core için üretim dostu (retry, timeout) ayarlara sahip.
- E-posta bileşenlerine dair using’ler işaret ettiği halde DI kaydı görünmüyor; tutarlılık için gözden geçirilmeli.
- Hedef framework ve üst katman (API/Presentation) görünmediğinden, başlangıç entegrasyonuna dair doğrulama yapılamıyor.### Project Overview
Proje adı: Library. Amaç: uygulama katmanındaki `IEmailService` kontratını SMTP üzerinden gerçekleştiren altyapı bileşeni sağlamak. Hedef framework: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: Clean Architecture — Application (iş kuralları/kontratlar), Infrastructure (harici sistem entegrasyonları). Keşfedilen projeler: 
- Library.Application — `IEmailService`, `EmailSettings` gibi kontrat/ayar tipleri.
- Library.Infrastructure — SMTP e-posta gönderimi implementasyonu.
Harici paketler: .NET BCL `System.Net.Mail`. Konfigürasyon: `EmailSettings` — `Host`, `Port`, `EnableSsl`, `Username`, `Password`, `From` (appsettings veya gizli değişkenlerden sağlanmalı).

### Architecture Diagram
Library.Application (Contracts)
        ↑ depends on
Library.Infrastructure (Implementations)

---

### `Library.Infrastructure/Email/SmtpEmailService.cs`

**1. Genel Bakış**
`SmtpEmailService`, `IEmailService`’in SMTP tabanlı implementasyonudur ve e-posta gönderimini gerçekleştirir. Clean Architecture’da Infrastructure katmanına aittir ve Application’daki kontratı uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IEmailService`
- **Namespace:** `Library.Infrastructure.Email`

**3. Bağımlılıklar**
- `EmailSettings` — SMTP sunucusu için host, port, kimlik bilgileri ve gönderici adresi konfigürasyonu.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Kurucu | `SmtpEmailService(EmailSettings settings)` | SMTP ayarlarını enjekte eder. |
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | SMTP üzerinden e-posta gönderir. |

**5. Temel Davranışlar ve İş Kuralları**
- `MailMessage` `IsBodyHtml` bayrağı parametreye göre ayarlanır.
- `SmtpClient` `Host`, `Port`, `EnableSsl`, `Credentials` ayarları `EmailSettings`’ten alınır.
- Kaynaklar `using` ile dispose edilir.
- `SendMailAsync` çağrısına `CancellationToken` iletilir.
- Hata yönetimi/loglama bu sınıfta yapılmaz; istisnalar çağırana geçer.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Presentation katmanındaki hizmetler tarafından çağrılır.
- **Aşağı akış:** `EmailSettings`, `System.Net.Mail.SmtpClient`, `System.Net.Mail.MailMessage`.
- **İlişkili tipler:** `IEmailService`, `EmailSettings`.

**7. Eksikler ve Gözlemler**
- Girdi doğrulaması yok (ör. `to` adres formatı).
- Hata yönetimi ve loglama yok; SMTP hataları doğrudan fırlatılır.
- Kimlik bilgileri/şifrelerin güvenli depolanmasına dair mekanizma belirtilmemiş (ör. Secret Manager, Key Vault). 

---

Genel Değerlendirme
- Clean Architecture ilkeleriyle uyumlu: Application’daki kontrat, Infrastructure’da uygulanmış.
- Konfigürasyon nesnesi doğrudan enjekte ediliyor; `IOptions<T>` kullanımı tercih edilebilir.
- Operasyonel sağlamlık için retry/policy, loglama ve temel validasyon eklenmesi faydalı olur.### Project Overview
Proje adı: Library. Amaç: Domain varlıkları için denetim/audit kayıtlarını kalıcı depoda sorgulamak ve yönetmek. Hedef framework: .NET (sürüm bu dosyadan anlaşılmıyor). Mimari: N‑Katmanlı/Clean benzeri; Domain (Entities, Interfaces) katmanı, Infrastructure (Data, Repositories) katmanından bağımsızdır. Keşfedilen projeler/assembly’ler: Library.Domain (entity’ler ve repository arayüzleri), Library.Infrastructure (EF Core tabanlı veri erişimi ve repository implementasyonları). Harici paket/çatı: Microsoft.EntityFrameworkCore. Konfigürasyon: `LibraryDbContext` için bağlantı dizesi gerekli (anahtar/format bu dosyadan anlaşılmıyor).

### Architecture Diagram
Library.Infrastructure (Repositories, Data) --> Library.Domain (Entities, Interfaces)
Library.Infrastructure (Data) --> Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/AuditLogRepository.cs`

**1. Genel Bakış**
`AuditLog` kayıtlarını sorgulayan EF Core tabanlı repository implementasyonu. Infrastructure katmanında yer alır ve `IAuditLogRepository` sözleşmesini uygular. Varlığa, kullanıcıya veya tarih aralığına göre denetim kayıtlarını indirgeme ve sıralama sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<AuditLog>`
- **Uygular:** `IAuditLogRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext` üzerinden veri erişimi
- `BaseRepository<AuditLog>` — `_dbSet` ve ortak CRUD altyapısı sağlar

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public AuditLogRepository(LibraryDbContext context)` | `DbContext` enjekte eder. |
| GetByEntityAsync | `public Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId)` | Belirli varlık adına ve kimliğine göre kayıtları zaman damgasına göre azalan sırada döner. |
| GetByUserAsync | `public Task<IEnumerable<AuditLog>> GetByUserAsync(string userId)` | Belirli kullanıcı kimliğine ait kayıtları zaman damgasına göre azalan sırada döner. |
| GetByDateRangeAsync | `public Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)` | Tarih aralığına (dahil) göre kayıtları zaman damgasına göre azalan sırada döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Filtreler: varlık adı+ID eşleşmesi, kullanıcı ID eşleşmesi veya `Timestamp` aralığı (başlangıç ve bitiş dahil).
- Sıralama: tüm sorgular `Timestamp` azalan.
- Asenkron EF Core sorguları (`ToListAsync`).
- Girdi validasyonu veya boş/`null` denetimi yapılmaz; `entityName`/`userId` için boş değerler engellenmez.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; application/service katmanı tarafından çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext`, `BaseRepository<AuditLog>`, EF Core LINQ uzantıları.
- **İlişkili tipler:** `AuditLog`, `IAuditLogRepository`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` desteği yok; uzun sorgularda iptal edilebilirlik eksik.
- Sayfalama/pagination yok; büyük veri kümelerinde performans ve bellek kullanımı etkilenebilir.

---
Genel Değerlendirme
Kod, Domain ve Infrastructure ayrımına uygun ve EF Core ile repository desenini takip ediyor. Sorgu yöntemleri açık ve amaç odaklı; ancak `CancellationToken` ve sayfalama gibi çapraz kesen kaygılar eksik. Yapılandırma ve hedef çatı sürümü bu kesitte görünmüyor; merkezi ayarlar ve bağlantı zinciri isimlendirmesinin belgelendirilmesi önerilir.### Project Overview
Proje adı: Library. Amaç: `Author` varlıkları için EF Core tabanlı depo (repository) işlemleri sağlamak; Domain ile Infrastructure katmanlarını ayırmak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean esintili yapı; Domain (entity ve kontratlar) + Infrastructure (EF Core implementasyonları). Keşfedilen projeler/assembly’ler: Library.Domain (entitiy ve `IAuthorRepository`), Library.Infrastructure (EF Core repository implementasyonu, `LibraryDbContext`). Harici paketler: `Microsoft.EntityFrameworkCore`. Konfigürasyon gereksinimleri: bağlantı dizesi ve EF Core ayarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <-  Library.Infrastructure.Data
Library.Domain  <-  Library.Infrastructure.Repositories

---
### `Library.Infrastructure/Repositories/AuthorRepository.cs`

**1. Genel Bakış**
`Author` varlığı için EF Core tabanlı depo operasyonlarını uygular; arama ve ilişkili `Books` yükleme işlevleri sunar. Infrastructure katmanında yer alır ve Domain’deki `IAuthorRepository` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Author>`
- **Uygular:** `IAuthorRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; temel CRUD ve sorgular için veri erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `AuthorRepository(LibraryDbContext context)` | Repository’i verilen `DbContext` ile kurar. |
| SearchAsync | `Task<IEnumerable<Author>> SearchAsync(string searchTerm)` | Ad/soyad `Contains` filtrelemesiyle yazarları arar. |
| GetWithBooksAsync | `Task<Author?> GetWithBooksAsync(Guid id)` | Verilen `id` için yazarı ilişkili `Books` ile birlikte yükler. |

**5. Temel Davranışlar ve İş Kuralları**
- `SearchAsync`: `FirstName` veya `LastName` üzerinde `Contains` ile filtreleme yapar; tüm eşleşen kayıtları döndürür.
- `GetWithBooksAsync`: `Include(a => a.Books)` ile eager loading yapar; bulunamazsa `null` döner.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisi/handler’lar tarafından çağrılır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<Author>`, EF Core LINQ uzantıları.
- **İlişkili tipler:** `Author`, `IAuthorRepository`, `BaseRepository<Author>`.

**7. Eksikler ve Gözlemler**
- `SearchAsync` için `searchTerm` null/boş kontrolü yok; null girişler çalışma zamanı hatasına yol açabilir.### Project Overview
Proje adı: Library. Amaç: EF Core tabanlı generic repository ile veri erişim işlemlerini soyutlamak. Hedef çatı: Bu dosyadan anlaşılmıyor (muhtemelen .NET 6+). Mimari: Clean Architecture eğilimli; Domain ve Infrastructure katmanları görünüyor. Keşfedilen projeler/assembly’ler: Library.Domain (entity’ler, arayüzler), Library.Infrastructure (EF Core, DbContext, repository’ler). Kullanılan dış paketler: Microsoft.EntityFrameworkCore. Konfigürasyon: `LibraryDbContext` için bağlantı dizesi gerekir; anahtar adları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <-used by- Library.Infrastructure

---
### `Library.Infrastructure/Repositories/BaseRepository.cs`

**1. Genel Bakış**
Generic repository implementasyonu; EF Core `DbSet<T>` üzerinden temel CRUD, sayfalama ve sorgulama sağlar. Clean Architecture’da Infrastructure katmanında yer alır, `Library.Domain` içindeki `IRepository<T>` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IRepository<T>`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; veri erişimi ve `SaveChangesAsync` yönetimi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `public virtual Task<T?> GetByIdAsync(Guid id)` | Kimliğe göre varlık getirir. |
| GetAllAsync | `public virtual Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları listeler. |
| FindAsync | `public virtual Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)` | Koşula göre filtreler. |
| GetPagedAsync | `public virtual Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)` | `CreatedAt` azalan sırada sayfalama yapar ve toplam sayıyı döner. |
| CountAsync | `public virtual Task<int> CountAsync()` | Toplam kayıt sayısını döner. |
| CountAsync | `public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)` | Koşula göre kayıt sayısını döner. |
| ExistsAsync | `public virtual Task<bool> ExistsAsync(Guid id)` | Kimliğe göre varlık var mı kontrol eder. |
| AddAsync | `public virtual Task AddAsync(T entity)` | `CreatedAt = UtcNow` atar, ekler ve kaydeder. |
| UpdateAsync | `public virtual Task UpdateAsync(T entity)` | `UpdatedAt = UtcNow` atar, günceller ve kaydeder. |
| DeleteAsync | `public virtual Task DeleteAsync(Guid id)` | Varlığı bulur, `IsDeleted = true` ve `UpdatedAt = UtcNow` set eder, kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `AddAsync`: `CreatedAt` otomatik `DateTime.UtcNow`.
- `UpdateAsync`: `UpdatedAt` otomatik `DateTime.UtcNow`.
- `DeleteAsync`: Fiziksel silme yok; soft delete (`IsDeleted = true`) uygular.
- `GetPagedAsync`: `CreatedAt`’e göre azalan sıralama; sayfa atlama ve alma.
- Her değişiklik işleminde `SaveChangesAsync` çağrılır (işlem başına kaydetme).
- `GetAllAsync` ve `FindAsync` soft delete filtrelemesi uygulamaz; silinmişleri de döndürebilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; somut repository’ler veya servisler tarafından kullanılır/kalıtılır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<T>`, EF Core LINQ uzantıları.
- **İlişkili tipler:** `BaseEntity` (özellikler: `Id`, `CreatedAt`, `UpdatedAt`, `IsDeleted` varsayılır), `IRepository<T>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Soft delete uygulandığı halde global query filter yok; listeleme/sorgulama silinmişleri de içerebilir.
- `CancellationToken` desteği yok.
- Sayfalama için girdi validasyonu yok (`pageNumber < 1`, `pageSize < 1` senaryoları).
- Her metotta `SaveChangesAsync` çağrısı birim-iş (Unit of Work)/transaction senaryolarını kısıtlayabilir; toplu işlemlerde verimsizlik yaratabilir. 

---
Genel Değerlendirme
Kod, Infrastructure katmanında EF Core ile generic repository düzenini sağlıklı kuruyor. Soft delete stratejisi ile sorgu filtresi eksikliği arasında tutarsızlık var; global filter veya repository düzeyinde filtre eklenmeli. Transactionel iş akışları için Unit of Work veya dışarıdan yönetilen `SaveChangesAsync` stratejisi düşünülmeli. İptal belirteci (CancellationToken) ve temel girdi validasyonları eklenirse dayanıklılık artar.### Project Overview
Proje adı: Library (inferred). Amaç: kütüphane alanındaki varlıklar için veri erişimi ve depolama işlemleri. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor), EF Core tabanlı. Mimari: Katmanlı/Clean benzeri; `Infrastructure` katmanı, `Domain` varlık ve arayüzlerine bağımlı. Görülen projeler: 
- Library.Domain — varlıklar ve arayüzler.
- Library.Infrastructure — EF Core tabanlı repository ve DbContext erişimi.
Dış bağımlılıklar: `Microsoft.EntityFrameworkCore`. Yapılandırma: bağlantı dizesi ve DbContext ayarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---
### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için EF Core tabanlı repository implementasyonudur. `Infrastructure` katmanında yer alır ve `IBookCategoryRepository` sözleşmesini sağlar; kategori sorguları (isimle, aktif, kök, alt kategoriler) ve ilişkili kitap yüklemeleri gibi işlemleri kapsar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookCategory>`
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryRepository(LibraryDbContext context)` | DbContext’i alarak temel repository’yi başlatır. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşen kategoriyi getirir. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili `Books` koleksiyonuyla kategoriyi yükler. |
| GetActiveCategoriesAsync | `Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync()` | `IsActive` olan kategorileri listeler. |
| GetRootCategoriesAsync | `Task<IEnumerable<BookCategory>> GetRootCategoriesAsync()` | Üst kategorisi olmayan kök kategorileri ve `SubCategories` ile getirir. |
| GetSubCategoriesAsync | `Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId)` | Belirli üst kategoriye bağlı alt kategorileri listeler. |

**5. Temel Davranışlar ve İş Kuralları**
- Ada göre arama tam eşitlik ile yapılır; büyük/küçük harf duyarlılığı veritabanı karşılaştırmasına bağlıdır.
- `GetWithBooksAsync` `Include(c => c.Books)` ile eager loading yapar.
- `GetRootCategoriesAsync` kökleri `SubCategories` ile birlikte yükler.
- Sorgular asenkron EF Core `FirstOrDefaultAsync`/`ToListAsync` kullanır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; hizmetler/uygulama katmanı repository’yi kullanır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<BookCategory>`, EF Core `Include/Where/FirstOrDefaultAsync/ToListAsync`.
- **İlişkili tipler:** `BookCategory`, `IBookCategoryRepository`, `BaseRepository<BookCategory>`.

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` desteği yok.
- Ada göre aramada kültür/harf duyarlılığına dair açık bir strateji belirtilmemiş. 

### Genel Değerlendirme
Kod, Infrastructure katmanında EF Core ile repository desenini uygular ve Domain’e bağımlıdır. İlişkili yükleme ve temel filtreleme net ve odaklıdır. İyileştirme olarak her asenkron metoda `CancellationToken` eklenebilir ve metin aramalarında kültür/karşılaştırma stratejisi netleştirilebilir. Yapılandırma ve diğer katmanlar (API/Application) bu içerikten görülememektedir.### Project Overview
Proje adı: Library. Amaç: kütüphane domain’inde ödünç alma (“loan”) verilerine erişim ve sorgulama. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak katmanlı/layered bir yapı: Domain (entity/enum/interface) ve Infrastructure (EF Core tabanlı repository) katmanları görülüyor. Keşfedilen projeler/assembly’ler: Library.Domain (entity’ler, enum’lar, repository kontratları), Library.Infrastructure (EF Core veri erişimi). Dış bağımlılıklar: Microsoft.EntityFrameworkCore (EF Core). Konfigürasyon gereksinimleri (bağlantı dizesi vb.) bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure

---
### `Library.Infrastructure/Repositories/BookLoanRepository.cs`

**1. Genel Bakış**
`BookLoan` varlıkları için EF Core tabanlı repository implementasyonudur. Müşteri, kitap, durum ve gecikme kriterlerine göre sorgular sağlar. Mimari olarak Infrastructure veri erişim katmanında yer alır ve `IBookLoanRepository` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookLoan>`
- **Uygular:** `IBookLoanRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookLoanRepository(LibraryDbContext context)` | DbContext enjekte ederek repository’i oluşturur. |
| GetByCustomerIdAsync | `public Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin ödünç kayıtlarını, kitap ve müşteri dâhil, tarihe göre sıralı getirir. |
| GetByBookIdAsync | `public Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın tüm ödünç kayıtlarını müşteri dâhil getirir. |
| GetActiveLoansAsync | `public Task<IEnumerable<BookLoan>> GetActiveLoansAsync()` | Durumu `Active` olan ödünçleri kitap ve müşteri dâhil getirir. |
| GetOverdueLoansAsync | `public Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()` | Vadesi geçmiş (Active ve `DueDate < UtcNow`) ödünçleri kitap ve müşteri dâhil getirir. |
| GetByStatusAsync | `public Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)` | Verilen duruma göre ödünçleri kitap ve müşteri dâhil getirir. |
| GetWithDetailsAsync | `public Task<BookLoan?> GetWithDetailsAsync(Guid id)` | Tek bir ödünç kaydını kitap, müşteri, işlem personeli ve cezalarla birlikte getirir. |
| GetActiveLoanCountByCustomerAsync | `public Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)` | Müşteriye ait aktif ödünç sayısını döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Eager loading: `Include` ile `Book`, `Customer`, `ProcessedByStaff`, `Fines` ilişkileri yüklenir.
- Gecikmiş kayıtlar: `Status == Active` ve `DueDate < DateTime.UtcNow`.
- Müşteri bazlı sorgu: `LoanDate` desc sıralama.
- Durum bazlı filtreler `LoanStatus` enum’ına göre yapılır.
- Sayım işlemi aktif ödünçler için yapılır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `LibraryDbContext`, `BaseRepository<BookLoan>`, EF Core `_dbSet`.
- İlişkili tipler: `BookLoan`, `LoanStatus`, `IBookLoanRepository`.

**7. Eksikler ve Gözlemler**
- Büyük veri setleri için sayfalama yok; tüm sonuçlar `ToListAsync()` ile çekiliyor, potansiyel performans etkisi olabilir.
- Bazı sorgularda `AsNoTracking()` kullanılmıyor; yalnızca okuma senaryolarında performans/izleme maliyeti düşünülebilir.

---
Genel Değerlendirme
Kod, Domain ve Infrastructure katmanları arasında net bir bağımlılık yönü sergiliyor ve repository deseni EF Core ile tutarlı uygulanmış. Okuma sorgularında performans için `AsNoTracking()` ve sayfalama desteği eklenmesi faydalı olabilir. Hedef framework ve uygulama katmanları (Application/API) bu kesitte görülmediğinden genel mimari tam doğrulanamıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane kitap verilerine erişim için repository katmanı. Hedef framework bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean benzeri; `Domain` varlık ve sözleşmeleri, `Infrastructure` veri erişimi (EF Core + Repository deseni). Keşfedilen projeler: Library.Domain (entity ve repository arayüzleri), Library.Infrastructure (EF Core tabanlı repository implementasyonları). Dış bağımlılık: Microsoft.EntityFrameworkCore. Konfigürasyon: `LibraryDbContext` için bağlantı dizesi gerekli, anahtar adları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure

---
### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`Book` varlıkları için EF Core tabanlı repository implementasyonudur. Kitapları farklı ölçütlerle sorgulama ve ilişkili navigasyon verileriyle getirme işini yapar. Mimari olarak Infrastructure/Data Access katmanındadır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Book>`
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`, veri erişimi için.
- `BaseRepository<Book>` — `_dbSet` ve temel CRUD altyapısı sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookRepository(LibraryDbContext context)` | DbContext ile repository’yi başlatır. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable` olan kitapları `Author` ve `BookCategory` ile döner. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre kitabı `Author` dahil getirir. |
| GetByAuthorIdAsync | `Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)` | Yazara göre kitapları `Author`, `BookCategory` ile getirir. |
| GetByCategoryIdAsync | `Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)` | Kategoriye göre kitapları `Author` ile getirir. |
| GetByBranchIdAsync | `Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)` | Şubeye göre kitapları `Author` ile getirir. |
| GetByPublisherIdAsync | `Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)` | Yayıncıya göre kitapları `Author` ile getirir. |
| SearchAsync | `Task<IEnumerable<Book>> SearchAsync(string searchTerm)` | Başlık, ISBN ve yazar ad/soyadında `Contains` ile arama yapar; `Author`, `BookCategory` dahil. |
| GetWithDetailsAsync | `Task<Book?> GetWithDetailsAsync(Guid id)` | Kitabı `Author`, `Publisher`, `BookCategory`, `LibraryBranch` ile getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Eager loading için `Include` kullanılır; navigasyonlar sorguya göre değişir.
- Filtreler: `IsAvailable`, `AuthorId`, `BookCategoryId`, `LibraryBranchId`, `PublisherId`, `ISBN`, `Title` ve `Author` ad/soyad.
- `SearchAsync` metni için `Contains` kullanımı; boş/değersiz giriş kontrolü yok.
- Liste dönen sorgularda sıralama ve sayfalama uygulanmaz.
- `GetByISBNAsync` ve `GetWithDetailsAsync` bulunamazsa `null` döner.

**6. Bağlantılar**
- Yukarı akış: `IBookRepository` üzerinden servisler/handler’lar tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, `DbSet<Book>`, EF Core uzantıları (`Include`, `Where`, `ToListAsync`).
- İlişkili tipler: `Book`, `Author`, `Publisher`, `BookCategory`, `LibraryBranch`, `IBookRepository`, `BaseRepository<Book>`.

**7. Eksikler ve Gözlemler**
- Arama ve listeleme metodlarında sayfalama ve sıralama yok; büyük veri setlerinde performans riski.
- `SearchAsync` için `searchTerm` null/boş validasyonu yok; potansiyel çalışma zamanı davranışı belirsiz.
- `CancellationToken` desteği yok; uzun süren sorguların iptali desteklenmiyor.

---
### Genel Değerlendirme
Kod, EF Core ile klasik Repository desenini uygular ve ilişkileri uygun şekilde eager-load eder. Katmanlaşmada Domain ve Infrastructure net; diğer katmanlar bu dosyadan anlaşılmıyor. Sorgularda sayfalama/sıralama ve iptal belirteci eksikliği ölçeklenebilirlikte sınırlayıcı olabilir. Giriş doğrulama (özellikle arama) için basit kontroller eklenmesi ve ortak sorgular için tutarlı Include stratejisi belirlenmesi faydalı olacaktır.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki rezervasyon/veri erişim işlemlerini yönetmek. Hedef çerçeve: modern .NET ve EF Core kullanımı görülüyor; kesin sürüm bu dosyadan anlaşılmıyor. Mimari: katmanlı yapı (Domain ve Infrastructure). Domain katmanı temel varlıklar/enumeration ve sözleşmeleri barındırır; Infrastructure veri erişimi ve EF Core implementasyonlarını içerir. Keşfedilen projeler: Library.Domain (entity/enum/interface’ler), Library.Infrastructure (repository ve DbContext tabanlı erişim). Harici paket: Microsoft.EntityFrameworkCore. Konfigürasyon: EF Core `DbContext` için bir veritabanı connection string’i gerekir; anahtar/ad bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <--  Library.Infrastructure  <--  Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/BookReservationRepository.cs`

**1. Genel Bakış**
`BookReservation` varlıkları için EF Core tabanlı repository implementasyonudur. Müşteri, kitap, durum ve son kullanma tarihlerine göre sorgular sağlar. Infrastructure katmanında veri erişim görevini üstlenir ve `IBookReservationRepository` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookReservation>`
- **Uygular:** `IBookReservationRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookReservationRepository(LibraryDbContext context)` | Repository’i verilen `DbContext` ile başlatır. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin rezervasyonlarını kitap dâhil, tarihe göre azalan sıralı döner. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın rezervasyonlarını müşteri dâhil, kuyruk sırasına göre artan döner. |
| GetByStatusAsync | `Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)` | Verilen duruma sahip rezervasyonları kitap ve müşteri dâhil döner. |
| GetExpiredReservationsAsync | `Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()` | `Pending` olup `ExpiryDate < UtcNow` olan süresi geçen rezervasyonları kitap ve müşteri dâhil döner. |
| GetWithDetailsAsync | `Task<BookReservation?> GetWithDetailsAsync(Guid id)` | Kimliğe göre tek rezervasyonu kitap ve müşteri dâhil getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Eager loading: Çoğu sorguda `Book` ve/veya `Customer` `Include` ile yüklenir.
- Sıralama: Müşteri bazlı sorguda `ReservationDate` azalan; kitap bazlı sorguda `QueuePosition` artan.
- Durum filtresi: `GetByStatusAsync` doğrudan `ReservationStatus` ile filtreler.
- Süre aşımı: `GetExpiredReservationsAsync` yalnızca `Pending` ve `ExpiryDate < DateTime.UtcNow` kayıtlarını döner.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından çağrılır.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<BookReservation>`.
- **İlişkili tipler:** `BookReservation`, `ReservationStatus`, `IBookReservationRepository`, `BaseRepository<T>`.

**7. Eksikler ve Gözlemler**
- İptal desteği yok: Async yöntemlerde `CancellationToken` parametresi bulunmuyor.
- Okuma senaryolarında `AsNoTracking()` kullanılmıyor; performans/izleme maliyeti olabilir.
- Büyük veri setleri için sayfalama/paginasyon bulunmuyor.
- Sistem zamanı için `DateTime.UtcNow` doğrudan kullanılıyor; test edilebilirlik için saat soyutlaması tercih edilebilir.

---
## Genel Değerlendirme
Kod, EF Core ile Infrastructure katmanında temiz ve amaç odaklı repository yöntemleri sunuyor. Katmanlar arası bağımlılık yönü tutarlı (Infrastructure → Domain). İyileştirme için iptal belirteci, `AsNoTracking()` ve paginasyon eklenebilir; zaman bağımlı mantık için saat soyutlaması kullanılabilir. Konfigürasyon ve hedef framework ayrıntıları repo genelinde daha açık tanımlanmalıdır.### Proje Genel Bakış
- Ad: Library
- Amaç: Kütüphane alanındaki `BookReview` verilerine erişim için repository altyapısı sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture/N-Tier varyantı. Katmanlar:
  - Domain: `Entities`, `Interfaces` (iş kuralları ve kontratlar)
  - Infrastructure: EF Core tabanlı veri erişimi (`Repositories`, `LibraryDbContext`)
- Projeler/Assembly’ler:
  - Library.Domain — entity ve repository kontratları
  - Library.Infrastructure — veri erişim implementasyonları
- Dış Bağımlılıklar: Entity Framework Core (`Microsoft.EntityFrameworkCore`)
- Konfigürasyon: Bağlantı dizesi ve EF Core context ayarları — bu dosyadan detayları anlaşılmıyor.

### Mimari Diyagram
Library.Infrastructure -> Library.Domain

---
### `Library.Infrastructure/Repositories/BookReviewRepository.cs`

**1. Genel Bakış**
`BookReview` varlıkları için özel sorgular sağlayan repository implementasyonudur. EF Core üzerinden kitap ve müşteri bazlı inceleme sorguları, onaylı incelemeleri çekme ve ortalama puan hesaplama işlevlerini sunar. Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookReview>`
- **Uygular:** `IBookReviewRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookReviewRepository(LibraryDbContext context)` | DbContext ile repository örneği oluşturur. |
| GetByBookIdAsync | `Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın incelemelerini müşteriyle birlikte, tarihe göre azalan sıralı getirir. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin incelemelerini kitap bilgisiyle birlikte getirir. |
| GetApprovedReviewsByBookAsync | `Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)` | Onaylı incelemeleri müşteriyle birlikte, tarihe göre azalan sıralı getirir. |
| GetAverageRatingByBookAsync | `Task<double> GetAverageRatingByBookAsync(Guid bookId)` | Onaylı incelemelerin ortalama puanını; yoksa 0 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `Include` kullanımları: kitap/müşteri navigasyonları yüklenir.
- Filtreler: Kitap bazlı sorgularda `BookId`; onaylı sorgularda `IsApproved == true`.
- Sıralama: Kitap bazlı listelerde `CreatedAt` azalan sırada.
- Ortalama hesaplama: Onaylı incelemeler üzerinden; hiç yoksa `0` döner.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir (uygulama servisleri/kullanım katmanı).
- **Aşağı akış:** `LibraryDbContext`, EF Core LINQ/`ToListAsync`.
- **İlişkili tipler:** `BookReview`, `IBookReviewRepository`, `BaseRepository<T>`, `LibraryDbContext`, `Book`, `Customer`.

**7. Eksikler ve Gözlemler**
- `GetAverageRatingByBookAsync` tüm kayıtları belleğe alıp sonra ortalama alıyor; `AverageAsync` ile doğrudan veritabanında hesaplanarak optimize edilebilir.

### Genel Değerlendirme
- Katmanlaşma Domain ve Infrastructure arasında net; repository deseni tutarlı.
- EF Core kullanımı doğru; navigation yüklemeleri amaçlı ve seçici.
- Küçük bir performans iyileştirmesi (ortalama hesaplama) dışında belirgin mimari sorun gözlenmedi.### Project Overview
- Proje adı: Library (adlandırmadan çıkarım); amaç: kütüphane alanındaki müşteri verilerine erişim; hedef çatı: .NET ve EF Core tabanlı (bu dosyadan anlaşılan).
- Mimari: Katmanlı/Clean Architecture esintili. Domain (entity ve interface’ler), Infrastructure (EF Core Repository’ler, DbContext).
- Projeler/assembly’ler:
  - Library.Domain — entity’ler (`Customer`), sözleşmeler (`ICustomerRepository`).
  - Library.Infrastructure — veri erişimi (`LibraryDbContext`, repository’ler).
- Dış bağımlılıklar: Microsoft.EntityFrameworkCore (Include/ThenInclude, LINQ async).
- Konfigürasyon: Veritabanı bağlantı dizesi gereksinimi muhtemel; anahtar/isim bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure
- Library.Infrastructure.Repositories depends on:
  - Library.Domain.Entities
  - Library.Domain.Interfaces
  - Library.Infrastructure.Data (DbContext)
  - Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`Customer` varlıkları için EF Core tabanlı repository implementasyonu. Domain katmanındaki `ICustomerRepository` sözleşmesini karşılar ve Infrastructure katmanında yer alır. Müşteriyi e‑posta, üyelik numarası, aktiflik durumu ve ilişkili yüklemeler (ödünçler/rezervasyonlar) ile sorgular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Customer>`
- **Uygular:** `ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerRepository(LibraryDbContext context)` | DbContext’i alır ve taban repository’yi başlatır. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E‑postaya göre ilk eşleşen müşteriyi getirir. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre müşteriyi getirir. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive` olan müşterileri listeler. |
| GetWithLoansAsync | `Task<Customer?> GetWithLoansAsync(Guid id)` | İlgili `BookLoans` ve `Book` dâhil müşteri getirir. |
| GetWithReservationsAsync | `Task<Customer?> GetWithReservationsAsync(Guid id)` | İlgili `BookReservations` ve `Book` dâhil müşteri getirir. |
| SearchAsync | `Task<IEnumerable<Customer>> SearchAsync(string searchTerm)` | Ad, soyad, e‑posta veya üyelik numarasına göre arama yapar. |

**5. Temel Davranışlar ve İş Kuralları**
- `FirstOrDefaultAsync` ile tekil getirilerde bulunamazsa `null` döner.
- `Include/ThenInclude` kullanılarak ilişkili `BookLoans/BookReservations` ve `Book` eager load edilir.
- `SearchAsync` içinde `Contains` ile çok alanlı arama yapılır; karşılaştırma duyarlılığı veritabanı kolasyonuna bağlıdır.
- `GetActiveCustomersAsync` sadece `IsActive == true` kayıtları döndürür.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama servisleri veya API katmanı; genelde DI üzerinden çözümlenir.
- **Aşağı akış:** `LibraryDbContext`, EF Core `_dbSet<Customer>`.
- **İlişkili tipler:** `Customer`, `ICustomerRepository`, `BaseRepository<T>`, ilişkiler: `BookLoans`, `BookReservations`, `Book`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok; uzun süren sorgularda iptal desteği eksik olabilir.

### Genel Değerlendirme
Kod, EF Core ile Repository desenini tutarlı uygular ve okunabilir. İlişkili veriler için açık eager loading tercih edilmiş. Geliştirme alanları: tüm async sorgularda `CancellationToken` desteği; arama senaryolarında potansiyel indeksleme/performans değerlendirmesi. Konfigürasyon ve diğer katmanlar bu dosyadan görülemiyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanında para cezalarını (`Fine`) veri erişim katmanında yönetmek. Hedef framework bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli; `Domain` (entity, enum, interface) ve `Infrastructure` (EF Core tabanlı repository) katmanları gözleniyor. Keşfedilen projeler/assembly’ler: Library.Domain (varlıklar, sözleşmeler), Library.Infrastructure (EF Core repository ve `LibraryDbContext`). Kullanılan dış bağımlılıklar: Entity Framework Core (`Microsoft.EntityFrameworkCore`). Konfigürasyon: `LibraryDbContext` için bağlantı dizesi ve EF sağlayıcı ayarları gerekli; anahtar adları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure

---
### `Library.Infrastructure/Repositories/FineRepository.cs`

**1. Genel Bakış**
`Fine` varlıkları için EF Core tabanlı repository uygulaması sağlar. Mimaride Infrastructure/Repository katmanına aittir ve `IFineRepository` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Fine>`
- **Uygular:** `IFineRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `FineRepository(LibraryDbContext context)` | Repository’yi belirli `DbContext` ile başlatır. |
| GetByCustomerIdAsync | `Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm cezalarını, ilişkili `BookLoan` ve `Book` ile döner. |
| GetByStatusAsync | `Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)` | Duruma göre cezaları, ilişkili `Customer` ile döner. |
| GetPendingFinesAsync | `Task<IEnumerable<Fine>> GetPendingFinesAsync()` | `FineStatus.Pending` olan cezaları `Customer` ve `BookLoan.Book` dahil ederek döner. |
| GetTotalUnpaidFinesByCustomerAsync | `Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)` | Müşterinin ödenmemiş (Pending) cezalarının toplam tutarını hesaplar. |

**5. Temel Davranışlar ve İş Kuralları**
- Navigasyon yüklemeleri: `Include`/`ThenInclude` ile `Customer`, `BookLoan`, `Book` yüklenir.
- Filtreleme: müşteri bazlı (`CustomerId`), durum bazlı (`FineStatus`), bekleyen (`Pending`) cezalar.
- Toplam hesaplama: bekleyen cezaların `Amount` alanı üzerinden `SumAsync`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya handler’lar çağırır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<Fine>`.
- **İlişkili tipler:** `Fine`, `FineStatus`, `IFineRepository`, `BaseRepository<Fine>`, `LibraryDbContext`, `BookLoan`, `Book`, `Customer`.

**7. Eksikler ve Gözlemler**
- Async metotlarda `CancellationToken` desteği yok; uzun süren sorgularda iptal edilebilirlik eksik. 

Genel Değerlendirme
- Katmanlı yapı tutarlı: Infrastructure Domain’e bağımlı. EF Core kullanımı açık.
- Repository metotları amaca yönelik; ancak `CancellationToken` eklenmesi ve okuma senaryolarında `AsNoTracking` kullanımı düşünülebilir.
- Hedef framework ve konfigürasyon anahtarları koddan çıkarılamıyor; dokümantasyonda netleştirilmeli.### Project Overview
Proje adı (çıkarım): Library. Amaç: kütüphane alanındaki varlıklar için veri erişimi ve altyapı işlemleri. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: katmanlı/Clean Architecture eğilimli; `Library.Domain` alan modelleri ve sözleşmeleri, `Library.Infrastructure` veri erişimi ve EF Core tabanlı kalıcılık. Keşfedilen projeler/assembly’ler: Library.Domain (entity’ler, interface’ler), Library.Infrastructure (repository’ler, DbContext). Dış bağımlılıklar: Entity Framework Core (`Microsoft.EntityFrameworkCore`). Konfigürasyon: `LibraryDbContext` için bağlantı dizesi ve EF Core sağlayıcı ayarları gerekir; detaylar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <--  Library.Infrastructure

---

### `Library.Infrastructure/Repositories/LibraryBranchRepository.cs`

**1. Genel Bakış**
`LibraryBranch` varlığı için özel sorgular sağlayan repository implementasyonudur. Altyapı katmanında, EF Core üzerinden aktif şubeleri ve ilişkili koleksiyonlarla şubeleri okur.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<LibraryBranch>`
- **Uygular:** `ILibraryBranchRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; base sınıfa iletilir ve `_dbSet` erişimini sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryBranchRepository(LibraryDbContext context)` | DbContext’i alır ve base repository’e iletir. |
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()` | `IsActive == true` olan şubeleri döndürür. |
| GetWithStaffAsync | `Task<LibraryBranch?> GetWithStaffAsync(Guid id)` | İlgili `Staff` koleksiyonu dahil edilerek şubeyi getirir. |
| GetWithBooksAsync | `Task<LibraryBranch?> GetWithBooksAsync(Guid id)` | İlgili `Books` koleksiyonu dahil edilerek şubeyi getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Aktif filtre: `GetActiveBranchesAsync` yalnızca `IsActive` true olanları döndürür.
- Eager loading: `GetWithStaffAsync` `Staff`, `GetWithBooksAsync` `Books` navigasyonlarını `Include` ile yükler.
- Varlık bulunamazsa `null` döner.
- `_dbSet` erişimi base sınıftan sağlanır; sorgular asenkron yürütülür.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya üst katman repository kontratı üzerinden çağırır.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<LibraryBranch>`.
- **İlişkili tipler:** `LibraryBranch`, `ILibraryBranchRepository`, `BaseRepository<LibraryBranch>`.

**7. Eksikler ve Gözlemler**
- Asenkron metodlarda `CancellationToken` desteği yok; uzun sorgularda iptal desteği eklenebilir.
- Salt-okuma sorgularında `AsNoTracking()` düşünülerek performans iyileştirilebilir (senaryoya bağlı).

---

Genel Değerlendirme
- Katmanlar arasında net ayrım ve EF Core tabanlı repository yaklaşımı görülüyor.
- Sözleşme (`ILibraryBranchRepository`) ve implementasyon uyumlu; ancak iptal belirteci ve olası no-tracking stratejileri tutarlı bir şekilde ele alınmamış.
- Hedef framework, konfigürasyon anahtarları ve diğer projeler (Application/API) bu dosyadan belirlenemiyor.### Proje Genel Bakış
- Ad: Library (Domain/Infrastructure katmanları görülüyor). Amaç: bildirimler için veri erişimi ve persistence işlemleri. Hedef çatı: .NET (bu dosyadan kesin sürüm anlaşılamıyor).
- Mimari: N‑Katmanlı / Clean-Architecture benzeri. Domain: entity ve kontratlar. Infrastructure: EF Core tabanlı repository implementasyonları ve DbContext.
- Projeler: 
  - Library.Domain — entity’ler ve `INotificationRepository` gibi kontratlar.
  - Library.Infrastructure — EF Core `LibraryDbContext` ve repository implementasyonları.
- Dış bağımlılıklar: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon: `LibraryDbContext` için veritabanı connection string’i (anahtar adı bu dosyadan anlaşılamıyor).

### Mimari Diyagram
Library.Domain (Entities, Interfaces)
        ↑
        └──── Library.Infrastructure (Data, Repositories) ──> EF Core

---
### `Library.Infrastructure/Repositories/NotificationRepository.cs`

**1. Genel Bakış**
`Notification` varlıkları için EF Core tabanlı repository’dir. Müşteri bazlı bildirim sorguları, okunmamış sayımı ve okundu işaretleme operasyonlarını sağlar. Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Notification>`
- **Uygular:** `INotificationRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext, veri erişimi ve `SaveChangesAsync` için.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `NotificationRepository(LibraryDbContext context)` | DbContext’i alır, base repository’i başlatır. |
| GetByCustomerIdAsync | `Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)` | Müşterinin tüm bildirimlerini tarihine göre döndürür. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)` | Müşterinin okunmamış bildirimlerini döndürür. |
| GetUnreadCountByCustomerIdAsync | `Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)` | Okunmamış bildirim sayısını döndürür. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Bildirimi okundu işaretler ve `ReadAt` atar. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm okunmamış bildirimlerini okundu işaretler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular `CreatedAt` azalan sıralıdır.
- Okundu işaretlemede `IsRead = true`, `ReadAt = DateTime.UtcNow`.
- `MarkAsReadAsync`: Kayıt bulunamazsa sessizce çıkar, exception fırlatmaz.
- `MarkAllAsReadAsync`: Tüm okunmamışları belleğe alıp tek `SaveChangesAsync` ile kaydeder.

**6. Bağlantılar**
- Yukarı akış: Uygulama servisleri; DI üzerinden `INotificationRepository` çözümlemesi.
- Aşağı akış: `LibraryDbContext`, EF Core, `Notification` entity.
- İlişkili tipler: `Notification`, `INotificationRepository`, `BaseRepository<T>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok.
- `MarkAllAsReadAsync` büyük veri setlerinde performans etkisi yaratabilir (toplu güncelleme yok).
- `MarkAsReadAsync` bulunamayan id için geribildirim/hata üretmiyor.

### Genel Değerlendirme
Kod, Infrastructure’da EF Core repository desenini tutarlı uygular. Domain ve Infrastructure ayrımı net. Geliştirme için öneriler: tüm async metotlara `CancellationToken` eklenmesi, toplu güncellemelerde daha verimli yöntemler (ör. EF Core `ExecuteUpdate`) ve bulunamayan kayıtlar için isteğe bağlı geribildirim politikası belirlenmesi.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki `Publisher` varlıkları için kalıcı veri erişimi sağlamak. Hedef çatı: .NET ile EF Core tabanlı katmanlı yapı (tam sürüm bu dosyadan anlaşılmıyor). Mimari: Domain ve Infrastructure katmanları gözlemleniyor; Infrastructure, EF Core ile repository kalıbını uygular. Keşfedilen projeler/assembly’ler: `Library.Domain` (entity ve interface tanımları), `Library.Infrastructure` (EF Core repository implementasyonları). Dış bağımlılıklar: `Microsoft.EntityFrameworkCore`. Konfigürasyon: `LibraryDbContext` bağlantı dizesi ve EF Core sağlayıcı ayarları gerekli, ancak anahtar adları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain <-- Infrastructure

---
### `Library.Infrastructure/Repositories/PublisherRepository.cs`

**1. Genel Bakış**
`Publisher` varlığı için EF Core tabanlı repository implementasyonudur. Temel CRUD’u `BaseRepository<T>`’den devralır ve yayıncı adına göre arama, ilişkili kitaplarıyla getirme ve aktif yayıncıları listeleme gibi sorgular sağlar. Mimari olarak Infrastructure veri erişim katmanındadır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Publisher>`
- **Uygular:** `IPublisherRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı ve `DbSet<Publisher>` erişimi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `PublisherRepository(LibraryDbContext context)` | DbContext’i alarak temel repository’yi başlatır. |
| GetByNameAsync | `Task<Publisher?> GetByNameAsync(string name)` | Ada göre ilk eşleşen yayıncıyı döner. |
| GetWithBooksAsync | `Task<Publisher?> GetWithBooksAsync(Guid id)` | `Books` navigasyonuyla yayıncıyı yükler. |
| GetActivePublishersAsync | `Task<IEnumerable<Publisher>> GetActivePublishersAsync()` | `IsActive` olan yayıncıları listeler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByNameAsync`: `Name` tam eşitlik filtresi; ilk kaydı veya `null` döner.
- `GetWithBooksAsync`: `Include(p => p.Books)` ile eager loading yapar; yoksa `null`.
- `GetActivePublishersAsync`: `IsActive` true olanları döner.
- Sorgular `FirstOrDefaultAsync`/`ToListAsync` ile asenkron çalışır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; application/service katmanları kullanır.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<Publisher>`.
- **İlişkili tipler:** `Publisher`, `IPublisherRepository`, `BaseRepository<Publisher>`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri eksik; uzun süren sorgularda iptal desteği yok.
- `GetByNameAsync` ad karşılaştırması kültür/harf duyarlılığına göre farklı davranabilir; gereksinim net değil.

### Genel Değerlendirme
Kod tabanı, Infrastructure katmanında EF Core tabanlı repository kalıbını izliyor ve Domain’e bağımlı. İptal belirteci desteği ve olası kültür-duyarlı arama stratejileri netleştirilebilir. Konfigürasyon anahtarları ve diğer katmanlar (Application/API) bu içerikten görünmüyor; proje genelinde tutarlı DI ve birim testleri için arayüz sözleşmelerinin korunması önerilir.### Project Overview
Proje adı: Library. Amaç: kütüphane personeli verilerine erişim sağlayan katmanlı bir yapı. Hedef framework bu dosyadan anlaşılmıyor. Mimari, katmanlı/N-Tier: Domain (entity ve sözleşmeler), Infrastructure (EF Core veri erişimi). Görülen projeler/assembly’ler: Library.Domain (Entities, Interfaces), Library.Infrastructure (Data, Repositories). Harici paket/çatı: Microsoft.EntityFrameworkCore (EF Core). Yapılandırma: `LibraryDbContext` için veritabanı bağlantı dizesi gerekir (anahtar/ad bu dosyadan anlaşılmıyor).

### Architecture Diagram
Library.Domain  ←  Library.Infrastructure
                    ↳ Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`Staff` varlıkları için EF Core tabanlı repository uygular. Personeli e-posta, çalışan numarası, şube ve aktiflik durumuna göre sorgular. Infrastructure veri erişim katmanının parçasıdır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Staff>`
- **Uygular:** `IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbSet<Staff>` erişimi için bağlam

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public StaffRepository(LibraryDbContext context)` | EF Core bağlamı ile repository’i oluşturur. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | E-posta ile ilk eşleşen personeli getirir. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive` değeri true olan personelleri listeler. |
| GetByBranchIdAsync | `public Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)` | Verilen şubeye bağlı personelleri `LibraryBranch` dahil ederek getirir. |
| GetByEmployeeNumberAsync | `public Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)` | Çalışan numarasıyla ilk eşleşen personeli getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Eşleşme kriterleri: `Email` ve `EmployeeNumber` için ilk kayıt (`FirstOrDefaultAsync`).
- Aktif personel filtresi: `IsActive == true`.
- Şubeye göre sorguda `LibraryBranch` gezinti özelliği `Include` ile yüklenir.
- Tüm sorgular asenkron çalışır ve sonuç listeleri `ToListAsync` ile malzeme edilir.

**6. Bağlantılar**
- **Yukarı akış:** `IStaffRepository` üzerinden DI ile çözümlenir.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<Staff>`, `Include`.
- **İlişkili tipler:** `Staff`, `LibraryBranch`, `BaseRepository<Staff>`, `IStaffRepository`.

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri yok.
- Okuma senaryolarında potansiyel performans için `AsNoTracking()` kullanılmıyor.

---
Genel Değerlendirme
- Katmanlı mimari net: Domain sözleşmeleri ve Infrastructure uygulamaları ayrık.
- Repository deseni tutarlı; ancak iptal belirteci ve izleme kapatma gibi performans/sağlamlık iyileştirmeleri eklenebilir.
- Hedef framework ve konfigürasyon anahtarları koddan anlaşılamıyor; merkezi konfigürasyon dokümantasyonu önerilir.### Project Overview
Proje adı: Library. Amaç: yazar yönetimi için RESTful uç noktalar sağlayan bir ASP.NET Core Web API. Hedef çerçeve: .NET (ASP.NET Core). Mimari: Katmanlı (API/Presentation → Application). API katmanı HTTP uç noktalarını sunar, Application katmanı iş mantığı ve DTO’ları barındırır. Keşfedilen projeler: Library (API/Presentation), Library.Application (DTO’lar ve servis sözleşmeleri). Dış bağımlılıklar: `Microsoft.AspNetCore.Mvc`. Konfigürasyon gereksinimi: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Services, DTOs)

---
### `Library/Controllers/AuthorsController.cs`

**1. Genel Bakış**
`AuthorsController`, yazar kaynakları için CRUD ve arama uç noktalarını sağlar. ASP.NET Core API katmanında yer alır ve `IAuthorService` üzerinden Application katmanına çağrılar yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IAuthorService` — Yazarlar üzerinde listeleme, sorgulama ve CRUD işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetAll | `Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()` | Tüm yazarları döner. |
| GetById | `Task<ActionResult<AuthorDto>> GetById(Guid id)` | ID’ye göre yazarı döner; yoksa 404. |
| Search | `Task<ActionResult<IEnumerable<AuthorDto>>> Search([FromQuery] string term)` | Terime göre yazar arar. |
| Create | `Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorDto createDto)` | Yeni yazar oluşturur; 201 ve konum döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto updateDto)` | Yazarı günceller; 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Yazarı siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Bulunamazsa `NotFound()` döner.
- `Create`: `CreatedAtAction` ile 201 ve `Location` başlığı sağlar.
- `Update`/`Delete`: 204 döner; 404 durumunun yönetimi servis tarafına bırakılmış görünüyor.
- Model validasyonu `ApiController` özelliğiyle otomatik tetiklenir (yanlış modelde 400).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; HTTP istekleri tarafından çağrılır.
- **Aşağı akış:** `IAuthorService`.
- **İlişkili tipler:** `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`, `IAuthorService`.

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` için 404 tanımlı olsa da controller içinde açık kontrol yok; servis istisna fırlatmasına bağımlı.
- Yetkilendirme niteliği (`[Authorize]`) yok; korumalı kaynaklar için güvenlik açığı oluşturabilir.

### Genel Değerlendirme
Kod, temiz bir API → Application bağımlılık yönü sergiliyor ve REST konvansiyonlarına uyuyor. Hata haritalaması (servis istisnalarını uygun HTTP kodlarına çevirme) için bir global exception handling/middleware eksik olabilir. Uç noktalar için yetkilendirme stratejisi belirtisiz; güvenlik gereksinimleri netleştirilmeli.### Project Overview
Proje, ASP.NET Core tabanlı bir kitap kategorileri Web API’sidir. Amaç, kitap kategorileri üzerinde CRUD işlemlerini HTTP üzerinden sunmaktır. Hedef framework net sürümü bu dosyadan anlaşılmıyor. Mimari, Application katmanına arayüzler ve DTO’lar üzerinden bağımlı bir API/presentation katmanı içerir.

- Mimari desen: N-Tier (Presentation/API → Application). Presentation, HTTP uç noktalarını; Application, iş kurallarını ve DTO’ları barındırır.
- Projeler/Assembly’ler:
  - Library (API/Presentation) — Controller’lar ve HTTP uç noktaları
  - Library.Application — `DTO` ve `Service` arayüzleri
- Dış paketler/çerçeveler: `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC)
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için CRUD uç noktalarını sağlayan bir ASP.NET Core API controller’ıdır. Presentation katmanında yer alır ve işlemleri `IBookCategoryService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori CRUD iş akışlarını sağlayan uygulama servisi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını alır. |
| GetAll | `Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategorileri döner. |
| GetById | `Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID’ye göre kategori getirir; yoksa 404. |
| Create | `Task<ActionResult<BookCategoryDto>> Create([FromBody] CreateBookCategoryDto createDto)` | Kategori oluşturur; 201 ve konum başlığı döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateBookCategoryDto updateDto)` | Kategoriyi günceller; 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Kategoriyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` (404) verir.
- `Create`: `CreatedAtAction` ile 201 ve `Location` header’ı üretir.
- `Update`/`Delete`: 204 döner; 404 durumları için servis tarafında exception/sonuç beklenir.
- DTO’lar body’den bağlanır (`[FromBody]`).

**6. Bağlantılar**
- **Yukarı akış:** HTTP istekleri (ASP.NET Core routing)
- **Aşağı akış:** `IBookCategoryService`
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` 404’leri controller’da açık kontrol etmez; servis exception eşlemesi varsayılıyor.
- Giriş validasyonu (ör. `ModelState.IsValid`) ve yetkilendirme (`[Authorize]`) görünmüyor.

Genel Değerlendirme
- Sunum katmanı Application’a arayüzler ve DTO’lar üzerinden temizce bağlı; katmanlar arası bağımlılık yönü doğru.
- İstek iptali (`CancellationToken`) ve model doğrulama/yetkilendirme yok; eklenmesi önerilir.
- Hata yönetimi ve 404 eşleme servis katmanına bırakılmış; global exception handling ile tutarlılık sağlanmalı.### Project Overview
Proje adı: Library. Amaç: kütüphane ödünç alma işlemleri için HTTP API uç noktaları sağlamak. Hedef çatı: ASP.NET Core Web API (C#). Mimari katmanlar: Presentation/API (`Library`), Application (`Library.Application`), Domain (`Library.Domain`). Controller, Application katmanındaki servis ve DTO’ları kullanır; Domain enum’larına başvurur. Görünen dış bağımlılıklar: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Yapılandırma gereksinimi bu dosyada görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Services, DTOs, Interfaces) --> Library.Domain (Enums, Entities)

---

### `Library/Controllers/BookLoansController.cs`

**1. Genel Bakış**
Kütüphane ödünç alma işlemleri için HTTP uç noktalarını sunan API denetleyicisidir. Listeleme, durum bazlı sorgulama, oluşturma, iade ve yenileme işlemlerini koordine eder. Presentation/API katmanında yer alır ve Application servislerine delegasyon yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookLoanService` — Ödünç alma işlemleri için uygulama servis sözleşmesi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookLoansController(IBookLoanService loanService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetAll()` | Tüm ödünçleri döndürür. |
| GetById | `public Task<ActionResult<BookLoanDto>> GetById(Guid id)` | Id’ye göre ödünç kaydı getirir; yoksa 404. |
| GetByCustomer | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetByCustomer(Guid customerId)` | Müşterinin tüm ödünçlerini getirir. |
| GetActive | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetActive()` | Aktif ödünçleri listeler. |
| GetOverdue | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetOverdue()` | Gecikmiş ödünçleri listeler. |
| GetByStatus | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetByStatus(LoanStatus status)` | Duruma göre ödünçleri listeler. |
| Create | `public Task<ActionResult<BookLoanDto>> Create([FromBody] CreateBookLoanDto createDto)` | Yeni ödünç oluşturur, 201 ve konum döner. |
| ReturnBook | `public Task<ActionResult<BookLoanDto>> ReturnBook(Guid id, [FromBody] ReturnBookLoanDto returnDto)` | Ödünç iadesini işler. |
| RenewLoan | `public Task<ActionResult<BookLoanDto>> RenewLoan(Guid id, [FromBody] RenewBookLoanDto renewDto)` | Ödünç yenilemesini işler. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Ödünç kaydını siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` servis `null` dönerse 404 üretir.
- `Create` başarıyla oluşturulan kayda `CreatedAtAction` ile 201 ve `Location` başlığı döner.
- Diğer uç noktalar servis sonuçlarını doğrudan 200/204 ile döndürür; 400/404 durumları için servis katmanına veya global hata işleyiciye güvenildiği izlenimi vardır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (REST çağrıları)
- **Aşağı akış:** `IBookLoanService`
- **İlişkili tipler:** `BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`, `LoanStatus`, `IBookLoanService`

**7. Eksikler ve Gözlemler**
- `Delete` 404 döndürebileceğini beyan ediyor ancak mevcut metot gövdesi 404 üretmiyor; varlık yoksa davranış belirsiz.
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; uç noktalar korumasız görünüyor.
- 400/404 durumları bazı uç noktalarda belgelenmiş olsa da kontrol çoğunlukla servis/exception middleware’ine bırakılmış; controller seviyesinde doğrulama/hata eşleme görünmüyor.

---

### Genel Değerlendirme
Katmanlı (N-Tier) yapı net: API, Application ve Domain bağımlılık yönü doğru. Controller ince; iş kuralları Application’a delege edilmiş. API katmanında tutarlı hata dönüşleri ve yetkilendirme politikaları netleştirilmeli; özellikle silme ve işlem hatalarında 400/404 üretimi için servis istisnalarını HTTP’ye eşleyen bir middleware veya açık kontrol eklenmesi faydalı olacaktır.### Project Overview
Proje, ASP.NET Core tabanlı bir Web API olarak kitap rezervasyon işlemlerini expose eder. API katmanı `Library` (Controllers) üzerinden `Library.Application` katmanındaki servis ve DTO’ları kullanır. Hedef framework sürümü bu dosyadan anlaşılmıyor. Mimari olarak katmanlı (N‑Tier) yaklaşım izlenmiş: API → Application. Veri erişimi veya Domain/Infrastructure katmanları bu dosyadan görülmüyor.

- Mimari desen: N‑Tier (API → Application)
- Projeler/Assembly’ler:
  - Library (API/Presentation): HTTP endpoint’leri
  - Library.Application (Application): Servis sözleşmeleri ve DTO’lar
- Dış bağımlılıklar: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Application)

---
### `Library/Controllers/BookReservationsController.cs`

**1. Genel Bakış**
`BookReservationsController`, kitap rezervasyonları için CRUD’e yakın uç noktalar sağlar: listeleme, kimliğe göre getirme, müşteri/kitap bazlı sorgular, oluşturma, iptal ve tamamlama ile silme. API/Presentation katmanında yer alır ve tüm iş kurallarını `IBookReservationService`’e delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookReservationService` — Rezervasyon sorgulama/oluşturma/iptal/tamamlama/silme işlemlerini yürütür.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookReservationsController(IBookReservationService reservationService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetAll()` | Tüm rezervasyonları döner. |
| GetById | `public async Task<ActionResult<BookReservationDto>> GetById(Guid id)` | Kimliğe göre rezervasyonu döner; yoksa 404. |
| GetByCustomer | `public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByCustomer(Guid customerId)` | Müşteriye ait rezervasyonları döner. |
| GetByBook | `public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByBook(Guid bookId)` | Kitaba ait rezervasyonları döner. |
| Create | `public async Task<ActionResult<BookReservationDto>> Create([FromBody] CreateBookReservationDto createDto)` | Rezervasyon oluşturur; 201 ve konum başlığı döner. |
| Cancel | `public async Task<IActionResult> Cancel(Guid id)` | Rezervasyonu iptal eder; 204 döner. |
| Fulfill | `public async Task<IActionResult> Fulfill(Guid id)` | Rezervasyonu tamamlar; 204 döner. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Rezervasyonu siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` sonucu `null` ise 404 döner.
- `Create` sonrası `CreatedAtAction` ile 201 ve `Location` başlığı sağlanır.
- `Cancel`, `Fulfill`, `Delete` idempotent benzeri 204 No Content döner; hata durumları servis tarafından belirlenir.
- Tüm işlemler iş kurallarını servis katmanına delege eder; controller üzerinde ek validasyon mantığı yoktur.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (ASP.NET Core routing ile `/api/BookReservations` altı).
- Aşağı akış: `IBookReservationService`.
- İlişkili tipler: `BookReservationDto`, `CreateBookReservationDto`, `IBookReservationService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme/kimlik doğrulama öznitelikleri yok; güvenlik açısından değerlendirilmelidir.
- Listeleme uç noktalarında sayfalama/sıralama parametreleri bulunmuyor; potansiyel performans ve cevap boyutu riskleri. 

Genel Değerlendirme
- Mimari katman ayrımı net: Controller yalnızca Application servislerine delege ediyor.
- Güvenlik (Authorization) ve API sözleşmelerinde sayfalama/filtreleme gibi üretim ihtiyaçları görünmüyor.
- Hata yönetimi servis katmanına bırakılmış; tutarlı problem yanıtları için global exception handling ve problem details önerilir.### Project Overview
Proje adı: Library. Amaç: kitap incelemeleri için RESTful uç noktalar sunan bir ASP.NET Core Web API. Hedef çatı: ASP.NET Core (muhtemelen .NET 6+ minimal hosting). Katmanlı yapı: API/Presentation katmanı `Library.Controllers` ile Application katmanındaki `Library.Application.DTOs` ve `Library.Application.Interfaces`’e bağımlı. Keşfedilen projeler: Library (API) ve Library.Application (Application). Görülen dış paket/çerçeveler: `Microsoft.AspNetCore.Mvc`. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Controllers)
  ↓ uses
Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookReviewsController.cs`

**1. Genel Bakış**
`BookReviewsController`, kitap incelemelerine yönelik CRUD ve onay işlemleri için HTTP uç noktaları sağlar. Presentation/API katmanındadır ve iş mantığını `IBookReviewService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookReviewService` — Kitap incelemeleri için sorgulama, oluşturma, güncelleme, onaylama ve silme işlemlerini gerçekleştirir.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookReviewsController(IBookReviewService reviewService)` | Servis bağımlılığını alır. |
| GetByBook | `Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(Guid bookId)` | Belirli kitap için incelemeleri döner. |
| GetByCustomer | `Task<ActionResult<IEnumerable<BookReviewDto>>> GetByCustomer(Guid customerId)` | Belirli müşteri tarafından yazılan incelemeleri döner. |
| GetAverageRating | `Task<ActionResult<double>> GetAverageRating(Guid bookId)` | Kitabın ortalama puanını döner. |
| GetById | `Task<ActionResult<BookReviewDto>> GetById(Guid id)` | İncelemenin detayını döner; bulunamazsa 404. |
| Create | `Task<ActionResult<BookReviewDto>> Create([FromBody] CreateBookReviewDto createDto)` | Yeni inceleme oluşturur; 201 ve `Location` başlığı ile döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateBookReviewDto updateDto)` | Mevcut incelemeyi günceller; 204 döner. |
| Approve | `Task<IActionResult> Approve(Guid id)` | İncelemeyi onaylar; 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | İncelemeyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound üretir.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile 201 ve `Location` header’ı döner.
- `Update`, `Approve`, `Delete`: Başarılıysa 204 NoContent döner; 404 durumları servis katmanının exception/sonuç yönetimine bırakılmış görünüyor.
- Route kısıtları: `Guid` formatında yol parametreleri.

**6. Bağlantılar**
- **Yukarı akış:** API istemcileri (HTTP). Controller, DI üzerinden çözümlenir.
- **Aşağı akış:** `IBookReviewService`
- **İlişkili tipler:** `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`, `IBookReviewService`

**7. Eksikler ve Gözlemler**
- `ProducesResponseType(StatusCodes.Status404NotFound)` belirtilmiş olsa da `Update`, `Approve`, `Delete` içinde açık NotFound dönüşü yok; 404 yönetimi servis tarafından exception ile yapılmalı, aksi halde tutarsızlık olabilir.
- Yetkilendirme/kimlik doğrulama attribute’ları görünmüyor; inceleme oluşturma/onay işlemlerinde güvenlik açısından eksik olabilir.

---
Genel Değerlendirme
- Katman bağımlılıkları doğru yönde: Controller yalnızca Application katmanındaki `Interfaces` ve `DTOs`’a bağımlı.
- Hata/sonuç modellemesi servis katmanına bırakılmış; controller düzeyinde 404 dışı hata yönetimi görülmüyor.
- Güvenlik, validasyon ve konfigürasyon sinyalleri bu dosyada yok; projede global filtreler veya middleware ile ele alınıp alınmadığı bu dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: Kitaplarla ilgili CRUD ve listeleme işlemlerini HTTP üzerinden sunan bir ASP.NET Core Web API. Hedef framework sürümü bu dosyadan anlaşılmıyor (ASP.NET Core). Mimari: Katmanlı (API → Application). API katmanı controller’lar ile HTTP isteklerini karşılar; Application katmanı `IBookService` ve DTO’ları barındırır. Keşfedilen projeler/assembly’ler: Library (API), Library.Application (uygulama servisleri ve DTO’lar). Harici çerçeveler: ASP.NET Core MVC. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  ↓ depends on
Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplara yönelik CRUD ve listeleme uç noktalarını sağlayan ASP.NET Core API controller’ıdır. API/Presentation katmanına aittir ve iş kurallarını `IBookService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitap yönetimi için uygulama hizmeti; CRUD ve filtreli sorgular.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BooksController(IBookService bookService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları 200 ile döner. |
| GetById | `public Task<ActionResult<BookDto>> GetById(Guid id)` | Bulunamazsa 404, aksi halde 200 döner. |
| GetAvailable | `public Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Uygun/erişilebilir kitapları 200 ile döner. |
| Create | `public Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | 201 Created ve `Location` başlığıyla oluşturur. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Günceller, 204 NoContent döner. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Siler, 204 NoContent döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound; aksi halde 200 OK.
- `Create`: `CreatedAtAction` ile yeni kaynağın URI’sini üretir; 201 döner.
- `Update` ve `Delete`: Başarılıysa 204 NoContent; 404 durumları servis katmanındaki istisna/sonuç yönetimine bağlı.
- Model validasyonu `ApiController` özniteliğiyle framework’e bırakılmıştır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri; ASP.NET Core routing ile çağrılır.
- **Aşağı akış:** `IBookService`
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme öznitelikleri (`[Authorize]`) görünmüyor; güvenlik gereksinimi varsa eklenmeli.
- `Update`/`Delete` için 404 üretilmesi servis istisnalarına bağlı; controller seviyesinde açık eşleme yok.

Genel Değerlendirme
- Katman ayrımı net: API controller doğrudan Application arayüzüne dayanıyor.
- Hata ve validasyon yönetimi büyük ölçüde framework ve servis katmanına delege edilmiş; global exception handling/policy varlığı bu dosyadan anlaşılmıyor.
- Güvenlik/yetkilendirme stratejisi belirtilmemiş; ihtiyaç varsa politika/özniteliklerle tamamlanmalı.### Project Overview
- Ad: Library — Müşteri yönetimine yönelik RESTful uç noktalar sunan ASP.NET Core Web API.
- Amaç: Müşterileri listeleme, tekil getirme, aktifleri getirme, oluşturma, güncelleme ve silme işlemleri.
- Hedef çerçeve: ASP.NET Core Web API (kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari: Katmanlı (N‑Tier/Clean benzeri). API katmanı `Application` katmanındaki servis arayüzlerine bağımlı.
- Projeler/Assembly’ler:
  - Library (API/Presentation) — HTTP endpoint’ler.
  - Library.Application (Application) — `DTO` ve `Service` arayüzleri.
- Harici paketler/çerçeveler: ASP.NET Core MVC/Minimal Hosting (Controller tabanlı).
- Konfigürasyon: Bu dosyadan görülebilir özel ayar/connection string yok.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri işlemleri için REST endpoint’leri sağlar. Presentation/API katmanındadır ve iş kurallarını `ICustomerService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri iş mantığı ve veri erişimi orkestrasyonu.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomersController(ICustomerService customerService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döner (`200 OK`). |
| GetById | `public Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID ile müşteri; yoksa `404`. |
| GetActive | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri listeler. |
| Create | `public Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Müşteri oluşturur; `201 Created` ve `Location`. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Müşteriyi günceller; `204 No Content`. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; `204 No Content`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `404 NotFound`.
- `Create`: `CreatedAtAction` ile yönlendirme bilgisi döner.
- `Update`/`Delete`: Sonuç ne olursa olsun `204 NoContent`; bulunamama durumlarının servis tarafından yönetildiği varsayılıyor.
- Filtreleme (aktif müşteriler) servis katmanına delege edilir.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri); DI üzerinden çözümlenir.
- **Aşağı akış:** `ICustomerService`.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`.

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` için `ProducesResponseType(404)` belirtilmiş olsa da controller içinde 404’e çeviren kontrol yok; servis istisnalarını uygun HTTP statülerine eşlemek için hata işleme eksik.
- Girdi validasyonu (ör. `[FromBody]` modeller için `[Required]` vs.) controller seviyesinde görünmüyor.
- Yetkilendirme niteliği (`[Authorize]`) yok; güvenlik gereksinimleri varsa eklenmeli.

Genel Değerlendirme
- Katman ayrımı net: API, Application arayüzlerine bağımlı. Ancak hata haritalama (ör. domain istisnalarını 404/409’a çevirme), model validasyonu ve yetkilendirme yönergeleri eksik görünüyor. API sözleşmesi tutarlılığı için `Update/Delete` işlemlerinde bulunamama senaryoları açıkça ele alınmalı.### Project Overview
Proje adı: Library. Amaç: Kitaplık uygulaması için RESTful API; dashboard istatistiklerini sunar. Hedef çatı: ASP.NET Core Web API (kesin .NET sürümü bu dosyadan anlaşılmıyor). Mimari: Katmanlı/Clean benzeri; API katmanı `Library.Application` katmanının DTO ve servis arayüzlerine bağımlı. Projeler/Assembly’ler: Library (API/Presentation), Library.Application (Application sözleşmeleri ve DTO’lar). Harici çatı/paketler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Konfigürasyon: Bu dosyadan özel bir ayar/connection string görülmüyor.

### Architecture Diagram
Library (API/Controllers)
  -> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/DashboardController.cs`

**1. Genel Bakış**
`DashboardController`, dashboard istatistiklerini HTTP üzerinden sağlayan API uç noktasıdır. Application katmanındaki `IDashboardService`’e delegasyon yapar ve sonuçları `DashboardStatsDto` olarak döner. Sunum/API katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IDashboardService` — Dashboard istatistiklerini uygulama katmanından sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public DashboardController(IDashboardService dashboardService)` | Servis bağımlılığını DI üzerinden alır. |
| GetStats | `public Task<ActionResult<DashboardStatsDto>> GetStats()` | `GET api/dashboard/stats` için istatistikleri 200 OK ile döner. |

**5. Temel Davranışlar ve İş Kuralları**
- İstekleri `IDashboardService.GetStatsAsync()` çağrısına delege eder.
- Başarılı durumda 200 OK ve `DashboardStatsDto` döner.
- Lokal validasyon veya hata yakalama mantığı içermez.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (`GET api/dashboard/stats`); DI üzerinden çözümlenir.
- **Aşağı akış:** `IDashboardService`
- **İlişkili tipler:** `DashboardStatsDto`, `IDashboardService`

**7. Eksikler ve Gözlemler**
- Endpoint’te yetkilendirme niteliği (`[Authorize]`) yok; güvenlik gereksinimine göre eklenmelidir.
- `CancellationToken` desteği yok; uzun süren işlemler için eklenmesi faydalı olabilir.

---
Genel Değerlendirme
Kod, katmanlı yapıya uygun olarak API’nin Application arayüzlerine bağımlı olmasını sağlıyor. Güvenlik ve dayanıklılık açısından `[Authorize]`, hata yakalama/ProblemDetails ve `CancellationToken` entegrasyonları gözden geçirilmeli. Daha geniş mimari resmi görmek için Application ve olası Infrastructure/Domain katmanları incelenmeli.### Project Overview
Proje adı: Library. Amaç: Kütüphane ceza (fine) işlemlerini HTTP üzerinden expose eden bir Web API. Hedef framework: ASP.NET Core (tam sürüm bu dosyadan anlaşılmıyor). Mimari: Katmanlı yaklaşım; API katmanı `Library` projesinde, uygulama sözleşmeleri ve DTO’lar `Library.Application` altında. API, iş kurallarını `IFineService` aracılığıyla Application katmanına delege eder. Keşfedilen projeler/assembly’ler: Library (API), Library.Application (Application). Harici çerçeveler: ASP.NET Core MVC. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API) -> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/FinesController.cs`

**1. Genel Bakış**
`FinesController`, ceza (fine) kaynakları için RESTful uç noktalar sunar. Application katmanındaki `IFineService` üzerinden CRUD ve domain işlemlerini delege eden API/presentasyon katmanı denetleyicisidir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IFineService` — Ceza listeleme, getirme, oluşturma, ödeme ve silme işlemleri için uygulama hizmeti.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public FinesController(IFineService fineService)` | `IFineService` bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<FineDto>>> GetAll()` | Tüm cezaları döndürür. |
| GetById | `public async Task<ActionResult<FineDto>> GetById(Guid id)` | ID’ye göre cezayı getirir; yoksa 404. |
| GetByCustomer | `public async Task<ActionResult<IEnumerable<FineDto>>> GetByCustomer(Guid customerId)` | Müşteriye ait cezaları listeler. |
| GetTotalUnpaid | `public async Task<ActionResult<decimal>> GetTotalUnpaid(Guid customerId)` | Müşterinin ödenmemiş toplam cezasını döndürür. |
| GetPending | `public async Task<ActionResult<IEnumerable<FineDto>>> GetPending()` | Bekleyen/ödenmemiş cezaları listeler. |
| Create | `public async Task<ActionResult<FineDto>> Create([FromBody] CreateFineDto createDto)` | Ceza oluşturur; 201 ve konum döner. |
| PayFine | `public async Task<ActionResult<FineDto>> PayFine(Guid id, [FromBody] PayFineDto payDto)` | Cezayı ödeme işlemi; güncel ceza döner. |
| WaiveFine | `public async Task<IActionResult> WaiveFine(Guid id)` | Cezayı affeder; 204 döner. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Cezayı siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm işlemler `IFineService`’e delege edilir; controller’da domain mantığı yoktur.
- `GetById` bulunamadığında 404 döner; diğer uç noktalar başarıda 200/201/204 döner.
- `Create` işlemi `CreatedAtAction` ile kaynak konumu ve oluşturulan `FineDto`’yu döner.
- Model binding `[FromBody]` ile `CreateFineDto` ve `PayFineDto` için uygulanır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (ör. frontend, Postman); DI üzerinden çözümlenir.
- **Aşağı akış:** `IFineService`
- **İlişkili tipler:** `FineDto`, `CreateFineDto`, `PayFineDto`, `IFineService`

**7. Eksikler ve Gözlemler**
- Güvenlik: Hiçbir endpoint’te `[Authorize]` bulunmuyor; yetkilendirme gereksinimi varsa eklenmeli. 

Genel Değerlendirme
- API katmanı Application’a doğru düzgün şekilde bağımlı ve iş kurallarını delege ediyor.
- Güvenlik/Authorization ve global hata işleme (problem details, exception middleware) bu dosyadan görünmüyor; proje genelinde doğrulanmalı.
- Versiyonlama, pagination ve filtreleme stratejileri `GetAll`/listeleme uç noktalarında tanımlı değil; gereksinime göre eklenebilir.### Project Overview
Proje adı: Library (ASP.NET Core Web API). Amaç: Kütüphane şubeleri için RESTful uç noktalar sağlamak (listeleme, tekil getirme, oluşturma, güncelleme, silme, aktif şubeleri listeleme). Hedef framework bu dosyadan anlaşılmıyor. Mimari: Uygulama ve Sunum katmanlarına ayrılmış, Clean Architecture eğilimli katmanlı yapı. Keşfedilen projeler/assembly’ler: Library (API/Presentation) — HTTP uç noktaları; Library.Application (Application) — `DTO` ve `ILibraryBranchService` sözleşmeleri. Harici paketler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) -> Library.Application (Application)

---
### `Library/Controllers/LibraryBranchesController.cs`

**1. Genel Bakış**
`LibraryBranchesController`, kütüphane şubeleri için CRUD ve “aktif şubeler” uç noktalarını sunan Web API denetleyicisidir. Sunum katmanında yer alır ve iş kurallarını `ILibraryBranchService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ILibraryBranchService` — Şube verileri için sorgulama ve değişiklik operasyonlarını yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public LibraryBranchesController(ILibraryBranchService branchService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetAll()` | Tüm şubeleri 200 ile döner. |
| GetById | `public Task<ActionResult<LibraryBranchDto>> GetById(Guid id)` | Bulunursa 200, yoksa 404 döner. |
| GetActive | `public Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetActive()` | Aktif şubeleri 200 ile döner. |
| Create | `public Task<ActionResult<LibraryBranchDto>> Create([FromBody] CreateLibraryBranchDto createDto)` | Oluşturur, 201 ve `Location` başlığıyla döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateLibraryBranchDto updateDto)` | Günceller, 204 döner. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Siler, 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` bulunamazsa `NotFound()` (404) döner.
- `Create` sonrası `CreatedAtAction` ile 201 ve kaynak konumu döner.
- `Update` ve `Delete` her zaman 204 döndürür; 404 üretimi servis katmanına bırakılmış olabilir.
- Route desenleri: `api/LibraryBranches`, `{id:guid}`, `active`.
- İçerik türü `application/json`.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, sistem entegrasyonları).
- **Aşağı akış:** `ILibraryBranchService`.
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `ILibraryBranchService`.

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` için 404 üretilmesi controller içinde ele alınmıyor; servis hatasına bağımlı olabilir.
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; erişim kontrolü görünmüyor.

Genel Değerlendirme
- Katman ayrımı net: Controller yalnızca Application servislerini çağırıyor.
- REST ilkelerine uygun route ve durum kodları genel olarak tutarlı; `Update/Delete` 404 akışı belirsiz.
- Girdi doğrulama (ör. `ModelState` kontrolü) ve yetkilendirme eksik; güvenlik ve veri bütünlüğü açısından değerlendirilmeli.### Project Overview
- Ad: Library — Amaç: Bildirimler için RESTful uç noktalar sunan ASP.NET Core Web API katmanı. Hedef çerçeve bu dosyadan kesin değil (ASP.NET Core).
- Mimari: Katmanlı (API/Presentation → Application). Controller’lar Application servis arabirimlerine bağımlı.
- Projeler/Assembly’ler:
  - Library (API/Presentation) — Web API uç noktaları.
  - Library.Application — `DTO` ve `Service` arabirimleri.
- Harici paket/çatı: `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC/Web API).
- Konfigürasyon: Bu dosyadan bir bağlantı dizesi veya ayar anahtarı görünmüyor.

### Architecture Diagram
Library (API/Presentation)
  ↓
Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/NotificationsController.cs`

**1. Genel Bakış**
`NotificationsController`, bildirimlerle ilgili CRUD-benzeri uç noktaları sağlar: listeleme, okunmamışları getirme, okunmamış sayısı, oluşturma, okundu işaretleme ve silme. Presentation (API) katmanındadır ve Application katmanındaki `INotificationService` üzerinden iş kurallarını çalıştırır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `INotificationService` — Bildirim sorgulama/komutlarını iş katmanında yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `NotificationsController(INotificationService notificationService)` | Servis bağımlılığını alır. |
| GetByCustomer | `Task<ActionResult<IEnumerable<NotificationDto>>> GetByCustomer(Guid customerId)` | Müşterinin tüm bildirimlerini döner. |
| GetUnread | `Task<ActionResult<IEnumerable<NotificationDto>>> GetUnread(Guid customerId)` | Müşterinin okunmamış bildirimlerini döner. |
| GetUnreadCount | `Task<ActionResult<int>> GetUnreadCount(Guid customerId)` | Okunmamış bildirim sayısını döner. |
| Create | `Task<ActionResult<NotificationDto>> Create(CreateNotificationDto createDto)` | Yeni bildirim oluşturur. |
| MarkAsRead | `Task<IActionResult> MarkAsRead(Guid id)` | Belirli bildirimi okundu işaretler. |
| MarkAllAsRead | `Task<IActionResult> MarkAllAsRead(Guid customerId)` | Müşterinin tüm bildirimlerini okundu işaretler. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Belirli bildirimi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Uç noktalar, Application servisindeki asenkron metotları çağırır.
- Başarı durumlarında HTTP 200/201/204 döner; `Create` için `Created(string.Empty, ...)` kullanır.
- Parametre validasyonu ve hata yönetimi bu seviyede özel olarak yapılmıyor; servis katmanına bırakılmış görünüyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (REST); DI üzerinden çözümlenir.
- **Aşağı akış:** `INotificationService`
- **İlişkili tipler:** `NotificationDto`, `CreateNotificationDto`, `INotificationService`

**7. Eksikler ve Gözlemler**
- Uç noktalarda `Authorize` niteliği yok; erişim kontrolü belirsiz (potansiyel güvenlik riski).
- `Create` yanıtında Location header için boş URL döndürülüyor; kaynağın konumu sağlanmıyor.
- Girdi validasyonu (ör. `ModelState.IsValid`) ve özel hata yanıtları görünmüyor.

Genel Değerlendirme
- API katmanı Application katmanına düzgün şekilde bağımlı; temiz ayrım mevcut.
- Güvenlik (yetkilendirme) ve doğrulama endişeleri belirgin; global filtrelerle çözümlenmiyorsa controller seviyesinde eklenmeli.
- Kaynak oluşturma için Location header iyileştirilmeli (örn. `CreatedAtAction`).### Project Overview
Proje adı: Library. Amaç: Yayıncı (publisher) varlıkları için RESTful uç noktalar sağlayan ASP.NET Core Web API katmanı. Hedef framework bu dosyadan anlaşılmıyor.

Mimari: Katmanlı mimari (API → Application). Controller, Application katmanındaki `DTO` ve `Service` arayüzlerine bağımlı.

Projeler/Assembly’ler:
- Library (API/Presentation): Web API controller’ları.
- Library.Application (Application): `DTO`’lar ve `IPublisherService` kontratı.

Harici paketler/çatı: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Diğerleri bu dosyadan anlaşılmıyor.

Konfigürasyon: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
Library (API) --> Library.Application

---
### `Library/Controllers/PublishersController.cs`

**1. Genel Bakış**
`PublishersController`, yayıncılar için CRUD ve aktif yayıncı listeleme uç noktalarını sunar. API/Presentation katmanında yer alır ve iş mantığını `IPublisherService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IPublisherService` — Yayıncılar için uygulama servis kontratı; listeleme, getirme, oluşturma, güncelleme, silme işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `PublishersController(IPublisherService publisherService)` | Servis bağımlılığını alır. |
| GetAll | `Task<ActionResult<IEnumerable<PublisherDto>>> GetAll()` | Tüm yayıncıları döner. |
| GetById | `Task<ActionResult<PublisherDto>> GetById(Guid id)` | ID ile yayıncıyı getirir; yoksa 404. |
| GetActive | `Task<ActionResult<IEnumerable<PublisherDto>>> GetActive()` | Aktif yayıncıları listeler. |
| Create | `Task<ActionResult<PublisherDto>> Create([FromBody] CreatePublisherDto createDto)` | Yeni yayıncı oluşturur; 201 Created döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdatePublisherDto updateDto)` | Yayıncıyı günceller; 204 No Content. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Yayıncıyı siler; 204 No Content. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servisten `null` dönerse 404 Not Found.
- `Create`: `CreatedAtAction` ile konum başlığı içerir; ID servisten dönen `PublisherDto.Id`’den alınır.
- `GetAll`, `GetActive`, `Update`, `Delete`: Başarılı senaryoda 200/204 döner; hata durumları servis katmanına bırakılmıştır.
- Üretim formatı `application/json`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; HTTP istekleri tarafından çağrılır.
- **Aşağı akış:** `IPublisherService` (Application).
- **İlişkili tipler:** `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`, `IPublisherService`.

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` için 404 üretilmesi dokümante edilmiş olsa da controller düzeyinde açık bir 404 dönüş yok; servis istisnalarına güveniliyor. Bu durum tutarlılık ve hata yönetimi açısından net değil.
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; güvenlik gereksinimleri varsa eksik olabilir.

---
### Genel Değerlendirme
Kod, API katmanının Application katmanına sade bir delegeci olduğunu gösteriyor. Hata yönetimi ve 404 eşleme mantığı servis istisnalarına bırakılmış; API seviyesinde daha belirgin hata haritalama eklenmesi düşünülebilir. Güvenlik, logging ve model doğrulama öznitelikleri bu dosyada görünmüyor; ihtiyaç varsa eklenmelidir.### Project Overview
Proje adı: Library. Amaç: Kütüphane personeli (staff) için HTTP API uç noktaları sunmak. Hedef çatı: ASP.NET Core Web API (.NET). Mimari katmanlı yaklaşım: API/Presentation katmanı, Application katmanındaki servis sözleşmeleri ve DTO’ları kullanır. Keşfedilen projeler/assembly’ler: Library (API/Controllers), Library.Application (DTO’lar, servis arayüzleri). Harici çerçeveler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Controllers)
  ↳ depends on Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel yönetimi için CRUD ve listeleme uç noktalarını sağlayan ASP.NET Core API controller’ıdır. Presentation/API katmanındadır ve iş mantığını `Library.Application` katmanındaki `IStaffService` aracılığıyla uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel verileri için uygulama servis sözleşmesi; CRUD ve filtreli sorgular.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `StaffController(IStaffService staffService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli döner, 200. |
| GetById | `Task<ActionResult<StaffDto>> GetById(Guid id)` | Id ile personeli bulur; yoksa 404. |
| GetActive | `Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döner, 200. |
| Create | `Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; 201 ve `Location`. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; 204. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Personeli siler; 204. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` null sonuçta `404 NotFound` döner.
- `Create` başarılı olduğunda `201 Created` ve `CreatedAtAction` ile konum başlığı üretir.
- `Update` ve `Delete` başarıda `204 NoContent` döner.
- `[ApiController]` ile model bağlama hataları otomatik 400’a dönüştürülür.
- `ProducesResponseType(409)` ve `ProducesResponseType(404)` belirtilmiş; somut döndürme/handle bu dosyada yok, muhtemelen servis katmanına delegedir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; API çağrıları tarafından tetiklenir.
- **Aşağı akış:** `IStaffService`
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`

**7. Eksikler ve Gözlemler**
- Yetkilendirme/rol kontrolü için `[Authorize]` niteliği yok; hassas operasyonlar için güvenlik açığı oluşturabilir.
- 404/409 durumları için controller içinde açık hata yönetimi yok; servis istisnalarına bağımlı.### Project Overview
Proje adı: Library. Amaç: ASP.NET Core uygulamasında merkezi hata yakalama ve standart JSON hata yanıtı üretmek. Hedef çerçeve: Bu dosyadan anlaşılmıyor. Mimari: Katmanlı (N-Tier) — Presentation (Web/API) katmanı, Application katmanındaki özel exception’ları yakalayıp HTTP yanıtına çeviriyor. Keşfedilen projeler/assembly’ler: Library (Presentation/Web), Library.Application (Application). Harici paket/çatı: ASP.NET Core (middleware, logging), System.Text.Json. Konfigürasyon gereksinimi: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (Presentation/Web)
  ↓ uses
Library.Application (Common.Exceptions, Common.Models)

---
### `Library/Middleware/GlobalExceptionHandlerMiddleware.cs`

**1. Genel Bakış**
`GlobalExceptionHandlerMiddleware`, istek hattındaki hataları merkezi olarak yakalar, `Library.Application.Common.Exceptions` türlerini uygun HTTP durum kodlarına map eder ve `ApiResponse` ile standart JSON gövdesi döner. Presentation/Web katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Middleware`

**3. Bağımlılıklar**
- `RequestDelegate` — Sonraki middleware’i çağırmak için pipeline temsilcisi
- `ILogger<GlobalExceptionHandlerMiddleware>` — Hata/uyarı loglama

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)` | Middleware’i pipeline ve logger ile başlatır. |
| InvokeAsync | `Task InvokeAsync(HttpContext context)` | İsteği işler; exception’ları yakalayıp standart yanıt üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `NotFoundException` → 404, `BadRequestException` (hata listesiyle) → 400, `ConflictException` → 409, `UnauthorizedAccessException` → 401, diğerleri → 500.
- 500 durumunda `LogError`, diğerlerinde `LogWarning` ile tip ve mesaj loglanır.
- Yanıt `application/json`, camelCase serileştirme ile `ApiResponse<object>.FailResponse(...)`.
- İstisna detayları son kullanıcıya açılmaz; beklenmeyen hatalarda genel mesaj döner.

**6. Bağlantılar**
- **Yukarı akış:** ASP.NET Core middleware pipeline (Startup/Program’da eklenir).
- **Aşağı akış:** `ApiResponse<object>`, `NotFoundException`, `BadRequestException`, `ConflictException`, `UnauthorizedAccessException`, `ILogger`.
- **İlişkili tipler:** `Library.Application.Common.Models.ApiResponse`, `Library.Application.Common.Exceptions.*`.

**7. Eksikler ve Gözlemler**
- RFC 7807 `ProblemDetails` yerine özel `ApiResponse` kullanılıyor; istemci standardizasyonu gerekebilir.
- Yerelleştirme ve korelasyon kimliği (Correlation-Id) ekleme imkanı bulunmuyor; izlenebilirlik için düşünülebilir. 

### Genel Değerlendirme
Merkezi hata yönetimi iyi yapılandırılmış ve Application katmanındaki domain-odaklı exception’lara göre HTTP map’leri net. Proje/çatı sürümü ve diğer katmanlar bu dosyadan görünmüyor. `ApiResponse` sözleşmesinin tutarlı kullanımı ve middleware’in doğru sırada kaydedilmesi önemli. Geliştirme olarak ProblemDetails/Correlation-Id ve çok dillilik destekleri değerlendirilebilir.### Project Overview
Proje adı: Library. Amaç: ASP.NET Core isteklerinin korelasyon kimliğiyle loglanması ve süre ölçümü. Hedef framework: bu dosyadan anlaşılmıyor (ASP.NET Core tabanlı olduğu anlaşılıyor). Mimari: API/Presentation katmanında özel middleware kullanımı. Keşfedilen proje/assembly: Library (web/presentation). Dış bağımlılıklar: `Microsoft.AspNetCore.Http` (middleware/pipeline), `Microsoft.Extensions.Logging` (logging), `System.Diagnostics` (`Stopwatch`). Konfigürasyon: Özel bir ayar gereksinimi görünmüyor; `X-Correlation-ID` HTTP header’ı opsiyonel olarak okunuyor/üretiliyor.

### Architecture Diagram
[Client] -> [ASP.NET Core Pipeline] -> [Library.Middleware.RequestLoggingMiddleware] -> [Next Middleware/Endpoint]

---

### `Library/Middleware/RequestLoggingMiddleware.cs`

**1. Genel Bakış**
`RequestLoggingMiddleware`, her HTTP isteği için korelasyon kimliği üretip yayar, isteğin başlangıç/bitişini ve süreyi loglar. ASP.NET Core pipeline’ında Presentation/API katmanında yer alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Middleware`

**3. Bağımlılıklar**
- `RequestDelegate _next` — Pipeline’daki bir sonraki middleware/endpoint’e geçişi sağlar.
- `ILogger<RequestLoggingMiddleware> _logger` — İstek başlangıç/bitiş loglarını yazar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)` | Pipeline akışını ve logger’ı DI üzerinden alır. |
| InvokeAsync | `Task InvokeAsync(HttpContext context)` | Korelasyon kimliği üretir/okur, loglar ve bir sonraki middleware’e devir eder. |

**5. Temel Davranışlar ve İş Kuralları**
- `X-Correlation-ID` header’ı varsa kullanılır; yoksa `Guid.NewGuid()` ile üretilir.
- `HttpContext.Items["CorrelationId"]` ve `Response.Headers["X-Correlation-ID"]` olarak yayılır.
- İstek başlangıcı ve tamamlanmasını, HTTP method, path, status code ve geçen süre (ms) ile `Information` seviyesinde loglar.
- Süre ölçümü `Stopwatch` ile yapılır.

**6. Bağlantılar**
- **Yukarı akış:** ASP.NET Core tarafından `app.UseMiddleware<RequestLoggingMiddleware>()` ile çağrılır.
- **Aşağı akış:** `_next` (sonraki middleware/endpoint), `ILogger`.
- **İlişkili tipler:** `HttpContext`, `RequestDelegate`, `ILogger<T>`, `Stopwatch`.

---

### Genel Değerlendirme
Kod, tek bir middleware ile sınırlı ve amaca uygun, sade bir uygulama sunuyor. Korelasyon kimliği yönetimi ve süre ölçümü doğru konumlandırılmış. Konfigürasyon/çevresel ayar ihtiyacı bulunmuyor. Genişleme durumda, log seviyesi/formatı veya korelasyon kimliği adının konfigüre edilebilir yapılması değerlendirilebilir.### Project Overview
Library Management API; amaç: kurumsal kütüphane yönetimi için HTTP endpoint’leri sağlamak. Hedef: ASP.NET Core (.NET 6+). Katmanlı mimari: API sunumu, `Application` iş kuralları, `Infrastructure` dış kaynak entegrasyonları, `Middleware` çapraz kesen kaygılar. Projeler: `Library` (API), `Library.Application` (iş mantığı/DI), `Library.Infrastructure` (persistans/konfig), `Library.Middleware` (istek loglama ve global hata yakalama). Ana bileşenler: Controllers, CORS, Swagger, HealthChecks, Response Caching. Konfigürasyon: `AddInfrastructure(builder.Configuration)` bağlantı/uygulama ayarları gerektirebilir; bu dosyadan detaylar anlaşılmıyor.

### Architecture Diagram
Library (API)
 ├─> Library.Application
 ├─> Library.Infrastructure
 └─> Library.Middleware

---
### `Library/Program.cs`

**1. Genel Bakış**
Uygulamanın giriş noktası ve ASP.NET Core pipeline’ının kompozisyonu. DI ile `Application` ve `Infrastructure` servislerini ekler, controller’ları, CORS, Swagger, HealthChecks ve Response Caching’i konfigüre eder. Sunum (API) katmanında yer alır.

**2. Tip Bilgisi**
- **Tip:** top-level statements (program bootstrapping)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** bu dosyadan anlaşılmıyor

**3. Bağımlılıklar**
- `Library.Application.AddApplication()` — Uygulama katmanı servislerinin kaydı
- `Library.Infrastructure.AddInfrastructure(IConfiguration)` — Altyapı bağımlılıklarının kaydı/konfigürasyonu
- `Library.Middleware.RequestLoggingMiddleware` — İstek loglama
- `Library.Middleware.GlobalExceptionHandlerMiddleware` — Global hata yakalama
- `Microsoft.OpenApi.Models` — Swagger metadata

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| — | — | Public/protected üye yok; uygulama başlangıç akışı tanımlanır. |

**5. Temel Davranışlar ve İş Kuralları**
- JSON: enum’lar `JsonStringEnumConverter` ile string olarak yazılır; `null` alanlar yazılmaz.
- CORS: `AllowAll` politikası tüm origin/metot/header’lara izin verir.
- Swagger: Sadece Development ortamında UI etkin; başlık/versiyon/açıklama/iletişim bilgisi ayarlı.
- Health Checks: `/health` endpoint’i eşlenir.
- Middleware sırası: `RequestLoggingMiddleware` -> `GlobalExceptionHandlerMiddleware` -> HTTPS yönlendirme -> CORS -> Response Caching -> Authorization -> Controllers.
- Response Caching etkinleştirilmiş.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama host’u tarafından çalıştırılır (DI üzerinden çözümlenir).
- **Aşağı akış:** `Library.Application`, `Library.Infrastructure`, `RequestLoggingMiddleware`, `GlobalExceptionHandlerMiddleware`, Swagger/HealthChecks/CORS/Response Caching.
- **İlişkili tipler:** `WebApplication`, `OpenApiInfo`, `OpenApiContact`.

**7. Eksikler ve Gözlemler**
- `UseAuthorization()` var ancak kimlik doğrulama/rol ataması görünmüyor; yetkilendirme etkisiz olabilir.
- CORS `AllowAll` üretim ortamı için güvenlik riski oluşturabilir.

Genel Değerlendirme
- Katman ayrımı net; API yalnızca kompozisyon yapıyor. Güvenlik tarafında kimlik doğrulama konfigürasyonu ve kısıtlayıcı CORS politikaları eklenmeli. Swagger’ın prod ortamında kapalı kalması doğru; ek olarak HealthChecks için güvenlik/filtreleme düşünülebilir. Configuration anahtarları ve Infrastructure bağımlılıkları şeffaflaştırılmalı (ör. bağlantı string adları).