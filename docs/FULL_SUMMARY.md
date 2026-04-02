### Project Overview
- Proje adı: Library (isimlendirme `Library.Application` üzerinden çıkarılmıştır)
- Amaç: Uygulama katmanında özel istisnalar tanımlayarak istek doğrulama/hata durumlarını anlamlandırmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/Katmanlı mimariye işaret eden bir yapı (namespace içinde `.Application` segmenti). Görülebilen katman: Application.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; istisnalar ve muhtemel iş kuralları/akışlar.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Application)
  └─ (bu dosyadan başka katman bağımlılığı anlaşılmıyor)

---
### `Library.Application/Common/Exceptions/BadRequestException.cs`

**1. Genel Bakış**
`BadRequestException`, hatalı istek senaryolarını temsil eden özel bir istisna tipidir ve isteğe bağlı olarak alan-bazlı hata listelerini taşır. Uygulama (Application) katmanında, doğrulama hataları veya 400 Bad Request'e karşılık gelen durumları ifade etmek için kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `Exception`
- **Uygular:** Yok
- **Namespace:** `Library.Application.Common.Exceptions`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BadRequestException()` | Varsayılan mesajla (`"Bad request."`) yeni bir örnek oluşturur ve `Errors`'ı boş sözlük olarak başlatır. |
| Ctor | `BadRequestException(string message)` | Özel bir mesajla yeni bir örnek oluşturur ve `Errors`'ı boş sözlük olarak başlatır. |
| Ctor | `BadRequestException(string message, IDictionary<string, string[]> errors)` | Özel mesaj ve alan-bazlı hata sözlüğü ile yeni bir örnek oluşturur. |
| Property | `IDictionary<string, string[]> Errors { get; }` | Alan adını hata iletileri listesine eşleyen hata koleksiyonu. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılan kurucu `Errors` için boş `Dictionary<string, string[]>()` başlatır.
- `message` alanı ile özelleştirilebilir; hata detayları `errors` sözlüğü üzerinden taşınır.
- `Errors` get-only property’dir ancak tutulan `Dictionary` mutabledır; dışarıdan içerik değiştirilebilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor; tipik olarak Application katmanında doğrulama/iş kuralı ihlallerinde fırlatılır.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait tek bir özel istisna görünmektedir; diğer katmanlar veya akışlar bu dosyadan çıkarılamıyor.
- `Errors` için mutable bir `Dictionary` dışarıya açılıyor; gerekirse `IReadOnlyDictionary` veya iç kopyalama ile mutasyon sınırlandırılabilir.
- Hedef framework, dış bağımlılıklar ve konfigürasyon anahtarları görünür değil; proje genelinde standardizasyonu teyit etmek için ek dosyalar incelenmelidir.### Project Overview
- Proje adı: Library
- Amaç: Uygulama katmanında alan-agnostik ortak tipler (ör. özel exception’lar) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean benzeri ayrışım işaretleri mevcut; yalnızca `Application` katmanı görülebiliyor. Application katmanı, iş kuralları ve ortak altyapı tiplerini içerir (ör. `Common.Exceptions`).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; ortak tipler ve muhtemel iş kuralları bileşenleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Exceptions/ConflictException.cs`

**1. Genel Bakış**
`ConflictException`, uygulama içinde çakışma durumlarını (ör. mevcut durumla uyumsuz bir işlem) temsil etmek için tanımlanmış özel bir exception tipidir. Uygulama (Application) katmanına aittir ve akış kontrollü hata yönetiminde semantik bir sinyal sağlar.

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
| Oluşturucu | `public ConflictException()` | Varsayılan mesaj olmadan bir çakışma hatası oluşturur. |
| Oluşturucu | `public ConflictException(string message)` | Açıklayıcı bir mesaj ile çakışma hatası oluşturur. |
| Oluşturucu | `public ConflictException(string message, Exception innerException)` | İç hata ile ilişkilendirilmiş çakışma hatası oluşturur. |

**5. Temel Davranışlar ve İş Kuralları**
- `Exception`'dan türeyerek standart .NET exception davranışlarını miras alır.
- Mesaj ve iç exception akışını destekler; böylece üst katmanlarda hata zincirlemesi mümkündür.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan doğrudan anlaşılmıyor; genellikle uygulama hizmetleri/işleyicileri tarafından fırlatılır.
- **Aşağı akış:** `System.Exception`
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- .NET yönergelerine göre özel exception’lar için `[Serializable]` niteliği ve korumalı serileştirme oluşturucusu `protected ConflictException(SerializationInfo info, StreamingContext context)` eksik.

---

Genel Değerlendirme
- Kod tabanında yalnızca `Application` katmanındaki bir özel exception görülüyor; diğer katmanlar (Domain/Infrastructure/API) bu dosyadan doğrulanamıyor.
- Özel exception için serileştirme desteği eklenmesi (Serializable özniteliği ve serileştirme kurucusu) tavsiye edilir.### Project Overview
- Proje Adı: Library.Application
- Amaç: Uygulama katmanında ortak istisna tiplerini sağlamak; özellikle bulunamayan kaynaklar için `NotFoundException` üretmek.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Bu dosyadan anlaşılmıyor; `Library.Application` ad alanı uygulama katmanını işaret ediyor.
- Keşfedilen Projeler/Assembly’ler ve Rolleri:
  - Library.Application — Uygulama katmanı; ortak istisnalar.
- Dış Bağımlılıklar: Görünmüyor (sadece `System.Exception`).
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Exceptions/NotFoundException.cs`

**1. Genel Bakış**
`NotFoundException`, aranan bir varlığın/kimliğin bulunamadığı durumlarda fırlatılmak üzere tanımlanmış özel bir istisna tipidir. Uygulama katmanı içinde ortak kullanım için konumlandırılmıştır ve hata mesajı üretimini kolaylaştırır.

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
| NotFoundException | `public NotFoundException()` | Varsayılan kurucu; özel mesaj içermez. |
| NotFoundException | `public NotFoundException(string message)` | Özel açıklama mesajıyla kurucu. |
| NotFoundException | `public NotFoundException(string message, Exception innerException)` | İç istisna sarmalama desteğiyle kurucu. |
| NotFoundException | `public NotFoundException(string entityName, object key)` | `Entity "name" (key) was not found.` şeklinde standartlaştırılmış mesaj üreten kurucu. |

**5. Temel Davranışlar ve İş Kuralları**
- Varlık adı ve anahtar (id) verilirse, istikrarlı ve anlaşılır bir hata mesajı oluşturur.
- `innerException` alabilen aşırı yük ile istisna zincirlemesi desteklenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor; tipik olarak uygulama hizmetleri/komut-sorgu işleyicileri tarafından fırlatılır.
- **Aşağı akış:** `System.Exception` temel sınıfı.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanında yalnızca uygulama katmanındaki bir özel istisna görülüyor. Mimari katmanlar, hedef çatı/çerçeve ve konfigürasyon hakkında çıkarım yapmak için veri yetersiz. İleride kapsam genişlediğinde, istisna yönetimi rehberliği (standart mesaj formatları, hata kodları, domain-özel istisnalar) ve merkezi hata işleme stratejisi ile tutarlılık sağlanması önerilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım). Amaç: Uygulama katmanında standart bir API yanıt modeli sağlamak. Hedef çerçeve sürümü bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture’a işaret eden yapı (Application katmanı mevcut). Application katmanı iş kurallarına ve ortak modellere odaklanır.
- Projeler/Assembly’ler:
  - Library.Application: Uygulama katmanı; ortak modelleri ve muhtemelen use-case/iş akışlarını barındırır.
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Models/ApiResponse.cs`

**1. Genel Bakış**
`ApiResponse<T>` uygulama genelinde tutarlı bir yanıt sarmalayıcısı sağlayan generic bir modeldir. Başarı durumu, veri içeriği, mesaj ve hataları tek yapı içinde taşır. Mimari olarak Application katmanındaki “Common/Models” içinde yer alır.

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
| Data | `public T? Data { get; set; }` | Başarılı sonuçta döndürülen veri içeriği. |
| Message | `public string? Message { get; set; }` | Bilgilendirici veya hata mesajı. |
| Errors | `public IDictionary<string, string[]>? Errors { get; set; }` | Alan bazlı hata listeleri (validasyon vb.). |
| SuccessResponse | `public static ApiResponse<T> SuccessResponse(T data, string? message = null)` | Başarılı yanıt üretir; `Success = true`, `Data` atanır. |
| FailResponse | `public static ApiResponse<T> FailResponse(string message, IDictionary<string, string[]>? errors = null)` | Başarısız yanıt üretir; `Success = false`, `Message` ve opsiyonel `Errors` atanır. |

**5. Temel Davranışlar ve İş Kuralları**
- `SuccessResponse` otomatik olarak `Success = true` ayarlar ve isteğe bağlı mesaj ile veri taşır.
- `FailResponse` otomatik olarak `Success = false` ayarlar, mesaj zorunludur, alan bazlı hatalar opsiyoneldir.
- `Data` başarısız yanıtta null bırakılabilir; `Errors` yalnızca hata durumlarında doldurulması beklenir.
- Exception fırlatma davranışı yok; tip salt veri sarmalayıcıdır.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
- Sadece Application katmanına ait ortak bir yanıt modeli görülüyor; diğer katmanlar ve hedef çerçeve sürümü bu dosyadan çıkarılamıyor.
- Model, başarılı/başarısız yanıtları standartlaştırmak için uygun; ancak sürümleme, izleme korelasyon kimliği veya durum kodu gibi genişletmeler gerekiyorsa ilave alanlar gerekebilir.### Proje Genel Bakış
- Proje adı: Library.Application (namespace’ten çıkarım)
- Amaç: Uygulama katmanında sayfalama sonuçlarını temsil eden ortak bir model sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean tarzı isimlendirme (`.Application`) kullanılmış görünüyor; diğer katmanlar bu dosyadan anlaşılmıyor. Bu katman tipik olarak use case/iş mantığı DTO’larını ve yardımcı modelleri barındırır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; ortak modeller ve muhtemelen use case’lere ait tipler.
- Kilit harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application
  ↳ (bu dosyadan başka katman/bağımlılık görünmüyor)

---

### `Library.Application/Common/Models/PagedResult.cs`

**1. Genel Bakış**
`PagedResult<T>`, sayfalama yapılan sorgularda döndürülen öğeler ve sayfalama metadatasını taşıyan genel amaçlı bir sonuç kapsayıcısıdır. Uygulama (Application) katmanında, sorgu/servis çıktılarında standartlaştırılmış sayfalama bilgisi sağlamak için kullanılır.

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
| Items | `public IEnumerable<T> Items { get; set; }` | Döndürülen sayfadaki öğeler koleksiyonu. |
| TotalCount | `public int TotalCount { get; set; }` | Tüm kayıtların toplam sayısı. |
| PageNumber | `public int PageNumber { get; set; }` | Geçerli sayfa numarası (1-tabanlı varsayılır). |
| PageSize | `public int PageSize { get; set; }` | Sayfa başına öğe sayısı. |
| TotalPages | `public int TotalPages { get; }` | Toplam sayfa sayısı; `Ceiling(TotalCount / PageSize)`. |
| HasPreviousPage | `public bool HasPreviousPage { get; }` | Önceki sayfa var mı. |
| HasNextPage | `public bool HasNextPage { get; }` | Sonraki sayfa var mı. |

**5. Temel Davranışlar ve İş Kuralları**
- `Items` varsayılanı boş koleksiyon (`[]`).
- `TotalPages` değeri `Math.Ceiling(TotalCount / (double)PageSize)` ile hesaplanır.
- `HasPreviousPage` `PageNumber > 1` koşuluna göre belirlenir.
- `HasNextPage` `PageNumber < TotalPages` koşuluna göre belirlenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- `PageSize == 0` durumunda `TotalPages` hesaplaması `double.PositiveInfinity` üretir ve `int`’e cast edilirken `OverflowException` fırlatabilir; `PageSize` için > 0 doğrulaması yok. Ayrıca `PageNumber` için alt/üst sınır doğrulaması bulunmuyor.

---

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir sayfalama DTO’su görünüyor; diğer katmanlar ve akış bu dosyadan çıkarılamıyor.
- `PagedResult<T>` pratik ancak giriş doğrulamaları (özellikle `PageSize` ve `PageNumber`) eksik; bu değerler ayarlanırken koruyucu kontroller eklenmesi faydalı olur.### Project Overview
- Ad: Library (namespace’ten çıkarım)
- Amaç: Uygulama katmanında sayfalama ve sıralama için ortak bir model sağlamak. Geniş bağlam (ör. kütüphane yönetimi) bu dosyadan anlaşılmıyor.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean Architecture izlenimi var; `Library.Application` ad alanı uygulama katmanını işaret ediyor. Diğer katmanlar (Domain/Infrastructure/API) bu dosyadan görülemiyor.
- Proje/Assembly’ler:
  - Library.Application — Uygulama katmanı; ortak modeller içeriyor.
- Harici paketler: Bu dosyadan görünmüyor.
- Konfigürasyon: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Common/Models/PaginationParams.cs`

**1. Genel Bakış**
`PaginationParams`, sayfalama ve sıralama parametrelerini temsil eden basit bir modeldir. Uygulama katmanında sorgu/komut işleyicileri veya repository benzeri bileşenlere kullanıcı girişlerini taşımak için kullanılır.

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
| PageNumber | `public int PageNumber { get; set; }` | 1’den başlayan geçerli sayfa numarası. Varsayılan 1. |
| PageSize | `public int PageSize { get; set; }` | Sayfa başına kayıt sayısı; üst sınır 100 ile kısıtlanır. Varsayılan 10. |
| SortBy | `public string? SortBy { get; set; }` | Sıralama yapılacak alan adı; boş/null ise sıralama belirsizdir. |
| SortDescending | `public bool SortDescending { get; set; }` | Azalan sıralama istendiğini belirtir. Varsayılan false. |

**5. Temel Davranışlar ve İş Kuralları**
- `PageSize` için üst sınır `MaxPageSize = 100`; daha büyük değer atanırsa 100’e zorlanır.
- Varsayılanlar: `PageNumber = 1`, `PageSize = 10`, `SortDescending = false`, `SortBy = null`.
- Negatif veya 0 değerler için `PageNumber` ve `PageSize` doğrulaması yapılmıyor; setter yalnızca üst sınırı kısıtlıyor.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- `PageNumber <= 0` ve `PageSize <= 0` durumlarına karşı alt sınır doğrulaması yok; tüketen katmanlarda ek validasyon gerekebilir.

---

Genel Değerlendirme
- Kod, Application katmanında ortak bir DTO sağlıyor ve Clean Architecture düzenine işaret ediyor; ancak diğer katmanlar ve bağımlılıklar görünmüyor.
- Sayfalama için üst sınır mantığı mevcut; alt sınır validasyonu eksik. Bu, veri erişim veya API katmanında girdi doğrulaması ile tamamlanmalı.
- Proje adını, hedef framework’ü, harici paketleri ve yapılandırma gereksinimlerini doğrulamak için ek dosyalara ihtiyaç var.### Project Overview
Proje adı, namespace’lerden “Library” olarak anlaşılıyor; bu parça “Application” katmanındaki DTO tanımlarını içeriyor. Amaç, yazar (author) ile ilgili veri aktarım modellerini (listeleme, oluşturma, güncelleme) API veya uygulama servisleri arasında taşımaktır. Hedef framework bu dosyadan anlaşılmıyor. Mimari katmanlama işaretleri “Application” ad alanıyla görülüyor; DTO’lar tipik olarak Use Case/Application katmanına aittir.

Mimari desen: Katmanlı/temiz mimari eğilimli (yalnızca Application/DTO’lar görünür). Application katmanı domain ve sunum arasında veri şekillendirmeden sorumlu.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO tanımları.

Harici paketler: Bu dosyada görünmüyor.

Konfigürasyon: Bu dosyada görünmüyor.

### Architecture Diagram
Library.Application (DTOs)
↳ Dış bağımlılık görünmüyor; diğer katmanlara ilişkin bilgi bu dosyada yok.

---
### `Library.Application/DTOs/AuthorDtos.cs`

**1. Genel Bakış**
`AuthorDto`, `CreateAuthorDto` ve `UpdateAuthorDto` yazar verisini okumak, oluşturmak ve güncellemek için kullanılan veri aktarım nesneleridir. Uygulama (Application) katmanında, API ve servisler arasında veri sözleşmesi sağlarlar.

**2. Tip Bilgisi**
- Tip: class (3 adet)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AuthorDto.Id | `public Guid Id { get; set; }` | Yazarın benzersiz kimliği. |
| AuthorDto.FirstName | `public string FirstName { get; set; } = string.Empty` | Yazarın adı. |
| AuthorDto.LastName | `public string LastName { get; set; } = string.Empty` | Yazarın soyadı. |
| AuthorDto.Biography | `public string? Biography { get; set; }` | Yazar biyografisi. |
| AuthorDto.BirthDate | `public DateTime? BirthDate { get; set; }` | Doğum tarihi. |
| AuthorDto.Nationality | `public string? Nationality { get; set; }` | Uyruk. |
| AuthorDto.Website | `public string? Website { get; set; }` | Web sitesi. |
| AuthorDto.BookCount | `public int BookCount { get; set; }` | Yayınlanmış kitap sayısı. |
| CreateAuthorDto.FirstName | `public string FirstName { get; set; } = string.Empty` | Oluşturma için ad. |
| CreateAuthorDto.LastName | `public string LastName { get; set; } = string.Empty` | Oluşturma için soyad. |
| CreateAuthorDto.Biography | `public string? Biography { get; set; }` | Oluşturma için biyografi. |
| CreateAuthorDto.BirthDate | `public DateTime? BirthDate { get; set; }` | Doğum tarihi. |
| CreateAuthorDto.DeathDate | `public DateTime? DeathDate { get; set; }` | Ölüm tarihi (varsa). |
| CreateAuthorDto.Nationality | `public string? Nationality { get; set; }` | Uyruk. |
| CreateAuthorDto.Website | `public string? Website { get; set; }` | Web sitesi. |
| UpdateAuthorDto.FirstName | `public string FirstName { get; set; } = string.Empty` | Güncelleme için ad. |
| UpdateAuthorDto.LastName | `public string LastName { get; set; } = string.Empty` | Güncelleme için soyad. |
| UpdateAuthorDto.Biography | `public string? Biography { get; set; }` | Güncelleme için biyografi. |
| UpdateAuthorDto.BirthDate | `public DateTime? BirthDate { get; set; }` | Doğum tarihi. |
| UpdateAuthorDto.DeathDate | `public DateTime? DeathDate { get; set; }` | Ölüm tarihi (varsa). |
| UpdateAuthorDto.Nationality | `public string? Nationality { get; set; }` | Uyruk. |
| UpdateAuthorDto.Website | `public string? Website { get; set; }` | Web sitesi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`. Diğer metin alanları `null` olabilir. `BookCount` için default C# değeri 0’dır.

**6. Bağlantılar**
- Yukarı akış: API controller’ları veya Application servisleri tarafından kullanılır (bu dosyadan kesin çağırıcılar anlaşılmıyor).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Muhtemel `Author` entity’si veya mapping profilleri (bu dosyadan görünmüyor).

Genel Değerlendirme
- Kod yalnızca DTO tanımlarını içeriyor; validasyon, mapping ve iş kuralları görünmüyor.
- Proje yapısına dair yalnızca `Application/DTOs` katmanı gözlenebiliyor; diğer katmanlar (Domain, Infrastructure, API) bu girdiyle doğrulanamıyor.### Project Overview
- Proje adı: Library (isim ve namespace’lerden çıkarım)
- Amaç: Uygulama katmanında kitap kategorilerine ait verileri taşımak için DTO tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture esintili yapı; görülen katman Application (DTO’lar). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı tipleri (DTO).
- Dış bağımlılıklar: Görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisi bilgisini (Id, Name, Description) katmanlar arasında taşımak için kullanılan basit bir veri aktarım nesnesidir. Uygulama (Application) katmanına aittir ve genellikle API ile domain/servis katmanları arasında mapping için kullanılır.

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
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
- Kod yalnızca Application katmanında bir DTO içeriyor; diğer katmanlar (Domain, Infrastructure, API) görünmüyor.
- Validasyon, mapping profilleri (ör. AutoMapper) veya kullanım bağlamı belirtilmemiş; bu, projenin geri kalanına bağlı olarak eksik olabilir.
- Hedef framework ve dış paketler bu dosyadan tespit edilemiyor.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına ait veri transferini sağlamak (özellikle kitap bilgileri) ve katmanlar arası sınırları korumak.
- Hedef framework: .NET (sürüm bu dosyadan anlaşılmıyor).
- Mimari desen: Clean Architecture (işaretler: `Library.Domain`, `Library.Application` ad alanları). Uygulama katmanı Domain’e bağımlı, Domain bağımsız.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Temel domain modelleri ve enum’lar (ör. `BookCondition`).
  - Library.Application — DTO’lar ve muhtemel uygulama mantığı (ör. `BookDto`).
- Dış bağımlılıklar: Bu dosyadan görünen yok.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain -> Library.Application

---

### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitaplara ait özet verileri katmanlar arası taşımak için kullanılan bir veri transfer nesnesidir. Application katmanında yer alır ve Domain’de tanımlı `BookCondition` enum’unu referans alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.BookCondition` — Kitabın fiziksel durumunu ifade eden domain enum’u.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kitabın benzersiz kimliği. |
| Title | `public string Title { get; set; }` | Kitap adı. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. |
| Description | `public string Description { get; set; }` | Kitap açıklaması. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `public int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `public string Language { get; set; }` | Dil bilgisi. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik durumu. |
| TotalCopies | `public int TotalCopies { get; set; }` | Toplam kopya sayısı. |
| AvailableCopies | `public int AvailableCopies { get; set; }` | Mevcut (ödünç verilebilir) kopya sayısı. |
| Condition | `public BookCondition Condition { get; set; }` | Fiziksel durum. |
| Price | `public decimal? Price { get; set; }` | Fiyat (opsiyonel). |
| AuthorId | `public Guid AuthorId { get; set; }` | Yazar kimliği. |
| AuthorName | `public string AuthorName { get; set; }` | Yazar adı. |
| PublisherId | `public Guid? PublisherId { get; set; }` | Yayıncı kimliği (opsiyonel). |
| PublisherName | `public string? PublisherName { get; set; }` | Yayıncı adı (opsiyonel). |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | Kategori adı (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Kütüphane şube kimliği (opsiyonel). |
| LibraryBranchName | `public string? LibraryBranchName { get; set; }` | Kütüphane şube adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `ISBN = string.Empty`, `Description = string.Empty`, `Language = string.Empty`, `AuthorName = string.Empty`. Diğer string alanlarda null olabilenler `null` başlar; sayısal ve bool alanlar türlerinin default değerlerini alır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Presentation katmanındaki handler, service veya controller’lar tarafından kullanılır.
- **Aşağı akış:** `Library.Domain.Enums.BookCondition`
- **İlişkili tipler:** `BookCondition` (Domain). Muhtemel ilişkiler: Author, Publisher, Category, LibraryBranch entity/DTO’ları (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Clean Architecture’a uygun katman ayrımı işaretleri mevcut (Application, Domain).
- Yalnızca DTO bulunduğu için iş kuralları ve servis/controller katmanlarına ilişkin validasyon, hata yönetimi, konfigürasyon veya harici paket kullanımı bu dosyadan anlaşılamıyor.
- DTO’daki isimlendirmeler tutarlı; string alanlarda uygun `string.Empty` başlangıçları NRE riskini azaltıyor.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Kütüphane ödünç verme alanında veri transferi için DTO tipleri sağlamak (ödünç işlemi yaratma, iade, uzatma, durum görüntüleme).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Application katmanı Domain’a bağımlı). Application katmanı istemci/endpoint ile Domain arasındaki veri sözleşmelerini taşır; Domain iş kurallarını ve sabitleri barındırır.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve muhtemel uygulama hizmetleri.
  - Library.Domain — Domain model ve enum’lar (ör. `LoanStatus`).
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor (paket referansı görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application] -> [Library.Domain]

---
### `Library.Application/DTOs/BookLoanDtos.cs`

**1. Genel Bakış**
Ödünç verme süreçlerine ait veri transfer nesnelerini (`BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`) tanımlar. Application katmanında, API/uygulama hizmetleri ile istemciler arasında veri sözleşmesi sağlar. Domain katmanındaki `LoanStatus` enum’unu kullanır.

**2. Tip Bilgisi**
- **Tip:** class (4 adet DTO sınıfı)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

- BookLoanDto
| Üye | İmza | Açıklama |
|---|---|---|
| Id | `Guid Id { get; set; }` | Ödünç işleminin benzersiz kimliği. |
| BookId | `Guid BookId { get; set; }` | İlgili kitabın kimliği. |
| BookTitle | `string BookTitle { get; set; }` | Kitap başlığı. |
| BookISBN | `string BookISBN { get; set; }` | Kitabın ISBN bilgisi. |
| CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CustomerName | `string CustomerName { get; set; }` | Müşteri adı. |
| ProcessedByStaffId | `Guid? ProcessedByStaffId { get; set; }` | İşlemi yapan personel kimliği. |
| ProcessedByStaffName | `string? ProcessedByStaffName { get; set; }` | İşlemi yapan personel adı. |
| LoanDate | `DateTime LoanDate { get; set; }` | Ödünç verme tarihi. |
| DueDate | `DateTime DueDate { get; set; }` | Son teslim tarihi. |
| ReturnDate | `DateTime? ReturnDate { get; set; }` | İade tarihi. |
| Status | `LoanStatus Status { get; set; }` | Ödünç durum enum’u. |
| Notes | `string? Notes { get; set; }` | Notlar. |
| RenewalCount | `int RenewalCount { get; set; }` | Yapılan uzatma sayısı. |
| MaxRenewals | `int MaxRenewals { get; set; }` | İzin verilen maksimum uzatma. |
| IsOverdue | `bool IsOverdue { get; set; }` | Gecikme durumu bayrağı. |

- CreateBookLoanDto
| Üye | İmza | Açıklama |
|---|---|---|
| BookId | `Guid BookId { get; set; }` | Ödünç verilecek kitabın kimliği. |
| CustomerId | `Guid CustomerId { get; set; }` | Müşteri kimliği. |
| ProcessedByStaffId | `Guid? ProcessedByStaffId { get; set; }` | İşlemi yapan personel kimliği. |
| LoanDurationDays | `int LoanDurationDays { get; set; }` | Ödünç süresi (gün). |
| Notes | `string? Notes { get; set; }` | Notlar. |

- ReturnBookLoanDto
| Üye | İmza | Açıklama |
|---|---|---|
| Notes | `string? Notes { get; set; }` | İade notları. |

- RenewBookLoanDto
| Üye | İmza | Açıklama |
|---|---|---|
| AdditionalDays | `int AdditionalDays { get; set; }` | Uzatma gün sayısı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler:
- `BookLoanDto`: `BookTitle = string.Empty`, `BookISBN = string.Empty`, `CustomerName = string.Empty`, diğer referans tipleri null olabilir (`ProcessedByStaffName`, `ReturnDate`, `Notes`), sayısallar 0, `IsOverdue = false`.
- `CreateBookLoanDto`: `LoanDurationDays = 14`.
- `ReturnBookLoanDto`: Özel default yok.
- `RenewBookLoanDto`: `AdditionalDays = 14`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Enums.LoanStatus`.
- İlişkili tipler: `LoanStatus` (Domain enum’u).

Genel Değerlendirme
- Kod sadece DTO tanımlarını içeriyor; uygulama akışları, doğrulamalar ve servis/handler katmanı bu dosyadan görülmüyor.
- Application katmanının Domain’a bağımlılığı net; başka katman/proje bağımlılıkları (Infrastructure, API) bu dosyadan çıkarılamıyor.
- Validasyon kuralları (ör. tarih tutarlılığı, uzatma limitleri) DTO seviyesinde tanımlı değil; muhtemelen servis/handler katmanında ele alınmalı.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kitap rezervasyonları ve ilgili müşteri/kitap bilgilerini uygulama katmanında taşımak için DTO modelleri sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli; `Application` katmanı, `Domain` tiplerine (enum) bağımlı. Bu, iş kurallarını Domain’de, akış/taşıma modellerini Application’da tutma yaklaşımına işaret eder.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı, DTO’lar ve (muhtemelen) use-case’ler.
- Library.Domain — Alan modeli; burada `ReservationStatus` enum’u tanımlı.

Dış bağımlılıklar: Görünmüyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/DTOs/BookReservationDtos.cs`

**1. Genel Bakış**
Bu dosya, kitap rezervasyonlarına ilişkin veri transferini temsil eden iki DTO içerir: `BookReservationDto` (okuma/yanıt) ve `CreateBookReservationDto` (oluşturma isteği). Application katmanında sorgu/komut sonuçlarını ve isteklerini taşımak amacıyla kullanılır.

**2. Tip Bilgisi**
- Tip: class (`BookReservationDto`)
  - Miras: Yok
  - Uygular: Yok
  - Namespace: `Library.Application.DTOs`
- Tip: class (`CreateBookReservationDto`)
  - Miras: Yok
  - Uygular: Yok
  - Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
- `ReservationStatus` — Domain katmanındaki rezervasyon durumunu temsil eden enum (durum bilgisini taşımak için kullanılır)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookReservationDto.Id | `public Guid Id { get; set; }` | Rezervasyonun benzersiz kimliği. |
| BookReservationDto.BookId | `public Guid BookId { get; set; }` | Rezervasyonu yapılan kitabın kimliği. |
| BookReservationDto.BookTitle | `public string BookTitle { get; set; }` | Kitabın başlığı. |
| BookReservationDto.CustomerId | `public Guid CustomerId { get; set; }` | Rezervasyonu yapan müşterinin kimliği. |
| BookReservationDto.CustomerName | `public string CustomerName { get; set; }` | Müşteri adı. |
| BookReservationDto.ReservationDate | `public DateTime ReservationDate { get; set; }` | Rezervasyonun oluşturulma tarihi. |
| BookReservationDto.ExpiryDate | `public DateTime ExpiryDate { get; set; }` | Rezervasyonun geçerlilik bitiş tarihi. |
| BookReservationDto.Status | `public ReservationStatus Status { get; set; }` | Rezervasyonun durumu. |
| BookReservationDto.QueuePosition | `public int QueuePosition { get; set; }` | Rezervasyon kuyruğundaki sıra. |
| CreateBookReservationDto.BookId | `public Guid BookId { get; set; }` | Rezervasyonu yapılacak kitabın kimliği. |
| CreateBookReservationDto.CustomerId | `public Guid CustomerId { get; set; }` | Rezervasyonu yapacak müşterinin kimliği. |
| CreateBookReservationDto.Notes | `public string? Notes { get; set; }` | İsteğe bağlı notlar. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `BookReservationDto.BookTitle = string.Empty`, `BookReservationDto.CustomerName = string.Empty`; diğer alanlar CLR default’ları (ör. `DateTime` varsayılanı, `Guid.Empty`, `int = 0`, `ReservationStatus` varsayılan enum değeri). `CreateBookReservationDto.Notes` null olabilir.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (genellikle API controller’ları veya application hizmetleri tarafından kullanılır).
- Aşağı akış: `Library.Domain.Enums.ReservationStatus`.
- İlişkili tipler: `ReservationStatus` (Domain).

Genel Değerlendirme
- Katman bağımlılığı doğru yönde: Application → Domain. Ancak yalnızca DTO’lar göründüğü için kullanım bağlamı ve doğrulama/iş kuralları bu dosyadan anlaşılamıyor.
- Null/boş string tutarlılığı iyi; fakat tarih alanları ve `Guid`’ler için zorunluluk/validasyon sinyali yok. Bu validasyonların nerede yapıldığı belirsiz.### Project Overview
- Proje adı: Library (namespaceten çıkarım)
- Amaç: Kitap incelemeleri için veri transferini (DTO) temsil etmek; muhtemelen kitap/müşteri değerlendirme akışlarında API ve uygulama katmanları arasında veri taşımak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Uygulama katmanı (`Library.Application`) mevcuttur; diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Application: Uygulama katmanı; DTO tanımları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  ↑
[Diğer katmanlar bu dosyadan anlaşılmıyor]

---

### `Library.Application/DTOs/BookReviewDtos.cs`

**1. Genel Bakış**
Kitap incelemelerine ilişkin veri transfer nesnelerini (`BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`) tanımlar. API veya uygulama servisleri ile istemciler arasında inceleme verisini taşımak için kullanılır. Uygulama (Application) katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

Aynı dosyada tanımlı ek tipler:
- `CreateBookReviewDto` — class, miras yok, interface yok
- `UpdateBookReviewDto` — class, miras yok, interface yok

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| BookReviewDto.Id | `public Guid Id { get; set; }` | İncelemenin benzersiz kimliği. |
| BookReviewDto.BookId | `public Guid BookId { get; set; }` | İlgili kitabın kimliği. |
| BookReviewDto.BookTitle | `public string BookTitle { get; set; }` | Kitabın başlığı. |
| BookReviewDto.CustomerId | `public Guid CustomerId { get; set; }` | İncelemeyi yapan müşterinin kimliği. |
| BookReviewDto.CustomerName | `public string CustomerName { get; set; }` | Müşteri adı. |
| BookReviewDto.Rating | `public int Rating { get; set; }` | Puan (aralık bu dosyadan anlaşılmıyor). |
| BookReviewDto.Title | `public string? Title { get; set; }` | İnceleme başlığı. |
| BookReviewDto.Comment | `public string? Comment { get; set; }` | İnceleme metni. |
| BookReviewDto.IsApproved | `public bool IsApproved { get; set; }` | Onay durumu. |
| BookReviewDto.CreatedAt | `public DateTime CreatedAt { get; set; }` | Oluşturulma zamanı. |
| CreateBookReviewDto.BookId | `public Guid BookId { get; set; }` | İncelenen kitap kimliği. |
| CreateBookReviewDto.CustomerId | `public Guid CustomerId { get; set; }` | İncelemeyi yapan müşteri kimliği. |
| CreateBookReviewDto.Rating | `public int Rating { get; set; }` | Puan. |
| CreateBookReviewDto.Title | `public string? Title { get; set; }` | Başlık. |
| CreateBookReviewDto.Comment | `public string? Comment { get; set; }` | Yorum. |
| UpdateBookReviewDto.Rating | `public int Rating { get; set; }` | Güncel puan. |
| UpdateBookReviewDto.Title | `public string? Title { get; set; }` | Güncel başlık. |
| UpdateBookReviewDto.Comment | `public string? Comment { get; set; }` | Güncel yorum. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `BookTitle = string.Empty`, `CustomerName = string.Empty`. Diğer referans tipleri null olabilir (`Title`, `Comment`). `IsApproved` varsayılanı `false`. `CreatedAt` için otomatik atama yok.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (muhtemelen controller/handler’lar kullanır).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: `CreateBookReviewDto`, `UpdateBookReviewDto`, `BookReviewDto` (birbirleriyle ilişkili varyantlar).

**7. Eksikler ve Gözlemler**
- `Rating` için aralık/doğrulama attribute’ları yok (ör. `[Range]`), validasyon başka katmanlara bırakılmış olabilir.
- `CreatedAt` değerinin set edilme anı bu dosyadan anlaşılmıyor; üretim zamanı tutarlılığı için servis veya persistence katmanında belirlenmesi gerekebilir.

---

### Genel Değerlendirme
Kod yalnızca Application katmanında DTO tanımlarını içeriyor. Mimari katmanlar, bağımlılıklar, konfigürasyon ve dış paket kullanımı bu dosyadan görülemiyor. Validasyon kuralları (özellikle `Rating` aralığı) ve denetim alanları DTO seviyesinde tanımlı değil; muhtemelen farklı bir katmanda ele alınmalı. DTO’lar tutarlı isimlendirilmiş ve oluşturma/güncelleme senaryoları için ayrıştırılmış.### Project Overview
- Proje adı: Library (görünen katmandan türetilen)
- Amaç: Uygulamada kitap kategori oluşturma verisini taşımak için DTO tanımı
- Hedef framework: Bu dosyadan anlaşılmıyor
- Mimari desen: Katmanlı mimari işaretleri var (Application katmanı). Application katmanı, Use Case/Service’ler ile dış katmanlar arasında veri taşıma görevini üstlenir (DTO’lar).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO, muhtemel komut/sorgu modelleri ve iş akışlarına yönelik tipler
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor

### Architecture Diagram
Library.Application (DTOs)
  ↑
(kullanıcı arayüzü/API tarafından tüketilmesi muhtemel, fakat bu dosyadan net değil)

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, kitap kategorisi oluşturma iş akışında ihtiyaç duyulan alanları (ad ve açıklama) temsil eden basit bir veri taşıyıcıdır. Application katmanına aittir ve muhtemelen komut/handler veya controller eylemleri arasında veri alışverişini sadeleştirir.

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
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor
- **Aşağı akış:** Harici bağımlılık yok
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor

### Genel Değerlendirme
Kod tabanı yalnızca bir DTO dosyası içeriyor; bu nedenle katmanlar arası akış, doğrulama, kalıcılık ve API yüzeyi hakkında çıkarım yapılamıyor. Doğrulama kuralları (ör. `Name` zorunluluğu, uzunluk kısıtları) tip içinde veya ayrı bir doğrulama mekanizmasında görünmüyor; ileride FluentValidation veya benzeri bir yaklaşım eklenmesi düşünülebilir.### Project Overview
- Proje adı: Library (namespace’ten çıkarım)
- Amaç: Uygulama katmanında kitap oluşturma senaryosuna girdi olarak kullanılacak veri aktarım nesnelerini (DTO) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Tam olarak çıkarılamıyor; ancak `Library.Application` adlandırması, katmanlı/temiz mimari yaklaşımlarında görülen Application katmanının varlığına işaret ediyor.
- Keşfedilen projeler/assembly’ler: 
  - Library.Application — Uygulama katmanı; DTO’lar içeriyor.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---
### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, yeni bir kitabın oluşturulması için gerekli alanları taşıyan bir veri aktarım nesnesidir. Uygulama katmanına aittir ve komut/handler veya controller gibi üst katmanlara giriş modeli sağlar.

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
| Title | `string Title { get; set; }` | Kitap başlığı. |
| ISBN | `string ISBN { get; set; }` | Kitabın ISBN değeri. |
| Description | `string Description { get; set; }` | Kitabın açıklaması/özeti. |
| PublishedYear | `int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `string Language { get; set; }` | Dil bilgisi. |
| TotalCopies | `int TotalCopies { get; set; }` | Envanterdeki toplam kopya sayısı. |
| Price | `decimal? Price { get; set; }` | Opsiyonel fiyat bilgisi. |
| AuthorId | `Guid AuthorId { get; set; }` | Yazarın benzersiz kimliği. |
| PublisherId | `Guid? PublisherId { get; set; }` | Opsiyonel yayınevi kimliği. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Opsiyonel kategori kimliği. |
| LibraryBranchId | `Guid? LibraryBranchId { get; set; }` | Opsiyonel kütüphane şubesi kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `ISBN = string.Empty`, `Description = string.Empty`, `Language = "Turkish"`, `TotalCopies = 1`. Diğerleri .NET default’ları veya nullable.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod yalnızca bir DTO içeriyor; katmanlar arası bağımlılık, iş kuralları, veri erişimi veya API yüzeyi hakkında çıkarım yapılamıyor.
- Varsayılan değerler alan doğrulaması yerine geçmiyor; gerçek dünyada `Title`, `ISBN`, `AuthorId` gibi kritik alanlar için validasyonun nerede yapıldığı bu dosyadan görülmüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına yönelik uygulama katmanında müşteri oluşturma verilerini taşımak (DTO). Hedef framework bu dosyadan anlaşılmıyor. Mimari, isimlendirmelere göre katmanlı/Clean Architecture yaklaşımı izliyor: Domain (iş kuralları ve temel türler), Application (DTO’lar, use-case’ler, arayüzler). Bu dosyada yalnızca Application katmanı ve Domain’daki bir enum kullanımı görülüyor.

Keşfedilen projeler/derlemeler ve rolleri:
- Library.Domain — temel domain türleri ve `Enums` (örn. `MembershipType`)
- Library.Application — uygulama katmanı, DTO’lar ve muhtemel use-case’ler

Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, yeni bir müşteri oluşturma işlemi için gerekli alanları taşıyan bir veri transfer objesidir. Application katmanına aittir ve üst katmanlar (örn. API) ile iş mantığı arasında veri alışverişini standardize eder.

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
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. Varsayılanı `string.Empty`. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. Varsayılanı `string.Empty`. |
| Email | `public string Email { get; set; }` | Müşteri e-postası. Varsayılanı `string.Empty`. |
| Phone | `public string Phone { get; set; }` | Müşteri telefonu. Varsayılanı `string.Empty`. |
| Address | `public string Address { get; set; }` | Adres. Varsayılanı `string.Empty`. |
| City | `public string City { get; set; }` | Şehir. Varsayılanı `string.Empty`. |
| PostalCode | `public string? PostalCode { get; set; }` | Opsiyonel posta kodu. |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi. Varsayılanı `MembershipType.Basic`. |
| DateOfBirth | `public DateTime? DateOfBirth { get; set; }` | Opsiyonel doğum tarihi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `PostalCode = null`, `MembershipType = MembershipType.Basic`, `DateOfBirth = null`.

**6. Bağlantılar**
- **Yukarı akış:** Üst katmanlar (örn. API Controller veya Application Use Case) tarafından doldurulur.
- **Aşağı akış:** `Library.Domain.Enums.MembershipType` kullanır.
- **İlişkili tipler:** `MembershipType` (Domain enum).

Genel Değerlendirme
- Yalnızca DTO görülebildi; iş akışları, doğrulama ve kalıcılık katmanına dair kod bu dosyadan anlaşılmıyor.
- DTO üzerinde veri doğrulama öznitelikleri veya kurallar bulunmuyor; doğrulamanın nerede yapıldığı belirsiz.
- Mimari katmanlar arası bağımlılık yönü tutarlı görünüyor: Application, Domain türünü referanslıyor.### Project Overview
Proje adı: Library (çıkarım). Amaç: kütüphane personel yönetimi dâhil olmak üzere kütüphane domain’ine ait işlemleri desteklemek (bu dosyadan anlaşılabildiği kadarıyla). Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı/Clean Architecture izleri görülüyor. `Library.Application` katmanı `Library.Domain` içindeki `Enums`’a referans veriyor; bu, Application → Domain bağımlılık yönünü ima eder.

Projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemelen use-case/handler’lar.
- Library.Domain (çıkarım) — Domain tipleri; en azından `Enums` içeriyor.

Kullanılan dış paketler/çatı: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, yeni bir personel (staff) oluşturma isteği için kullanılan veri taşıma nesnesidir. Application katmanında, üst katmanlardan (örn. API) gelen input’u use-case/komut işleyicilerine taşımak amacıyla yer alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `StaffRole` — `Library.Domain.Enums` içinden personel rolünü temsil eden enum.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | İletişim e-postası. |
| Phone | `public string Phone { get; set; }` | İletişim telefonu. |
| Position | `public string Position { get; set; }` | Ünvan/pozisyon. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (varsayılan: `Librarian`). |
| Salary | `public decimal? Salary { get; set; }` | Opsiyonel maaş bilgisi. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe alım tarihi. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Opsiyonel şube kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler:
- `FirstName`, `LastName`, `Email`, `Phone`, `Position` = `string.Empty`
- `Role` = `StaffRole.Librarian`
- `Salary` = `null`
- `HireDate` = `default(DateTime)` (belirtilmezse 01/01/0001)
- `LibraryBranchId` = `null`

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.StaffRole`
- **İlişkili tipler:** `StaffRole` (enum)

**7. Eksikler ve Gözlemler**
- Zorunlu alanlara (örn. `FirstName`, `LastName`, `Email`, `HireDate`) ilişkin doğrulama/annotation bulunmuyor.
- `HireDate` için `default(DateTime)` değeri anlamsız olabilir; geçerli tarih doğrulaması gerekebilir.
- `Email` formatı ve `Phone` numarası için format doğrulaması görünmüyor. 

---

Genel Değerlendirme
- Katmanlaşma: Application → Domain bağımlılığı Clean Architecture ile uyumlu görünüyor.
- Validasyon: DTO üzerinde veri anotasyonları veya ayrı bir validasyon katmanı izine rastlanmıyor; ileride FluentValidation veya benzeri bir yaklaşım gerekebilir.
- Yapılandırma/harici bağımlılıklar: Mevcut dosyadan belirlenemiyor.
- Tutarlılık: String alanların `string.Empty` ile başlatılması tutarlı; `DateTime` için anlamlı bir varsayılan veya nullable kullanımının değerlendirilmesi önerilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanındaki müşteri bilgilerini uygulama katmanında taşımak/aktarmak için DTO tanımı sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor (muhtemelen modern .NET).
- Mimari desen: Clean Architecture eğilimi; en azından `Application` ve `Domain` katmanları ayrışmış görünüyor.
  - Domain: Temel iş kuralları ve tipler (örn. `Enums`) — bu projeden yalnızca `MembershipType` referansı görülüyor.
  - Application: DTO’lar, muhtemel use-case/handler’lar ve mapping’ler; dış katmanlara veri sözleşmeleri sağlar.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — DTO barındırır, üst katmanlara veri aktarım sözleşmesi sağlar.
  - Library.Domain — Enum gibi domain tiplerini barındırır.
- Kullanılan dış paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Presentation/API (varsayım)  
  → Library.Application  
    → Library.Domain

---

### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri bilgilerini (ad, iletişim, üyelik) katmanlar arasında taşımak için kullanılan bir veri aktarım objesidir. Clean Architecture içinde Application katmanına aittir ve üst katmanlardaki API/Handlers ile Domain arasında veri sözleşmesi rolü görür.

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
| Id | `public Guid Id { get; set; }` | Müşteri benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Müşteri adı. |
| LastName | `public string LastName { get; set; }` | Müşteri soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres bilgisi. |
| City | `public string City { get; set; }` | Şehir. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi (Domain enum). |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| MembershipExpiryDate | `public DateTime? MembershipExpiryDate { get; set; }` | Üyeliğin bitiş tarihi (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Müşteri aktiflik durumu. |
| MaxBooksAllowed | `public int MaxBooksAllowed { get; set; }` | İzinli maksimum kitap adedi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName/LastName/Email/Phone/Address/City/MembershipNumber = string.Empty`; diğerleri türlerinin varsayılanı (`IsActive = false`, `MaxBooksAllowed = 0`, `RegisteredDate = default`, `MembershipType = 0`, `MembershipExpiryDate = null`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.MembershipType`
- **İlişkili tipler:** `MembershipType` (Domain enum)

Genel Değerlendirme
- Kod tabanında Clean Architecture katmanlaşması ima ediliyor ancak yalnızca tek bir DTO görülebiliyor; Application ile Domain dışında başka katman/projeler (Infrastructure, API) bu dosyadan anlaşılamıyor.
- Validasyon, mapping profilleri (ör. AutoMapper) ve kullanım bağlamı belirsiz; ilgili kurallar muhtemelen farklı katmanlarda ele alınmalıdır.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane yönetimi için istatistik/raporlama verileri dâhil, kitaplar, müşteriler, personel, ödünç alma, gecikme, rezervasyon ve cezalarla ilgili uygulama mantığını desteklemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı yapı (muhtemelen Application katmanı olan bir Clean Architecture/N-Tier). Bu dosyada yalnızca Application katmanına ait bir DTO görülüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case/servis kontratlarını barındırır.
- Kullanılan dış paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/DashboardStatsDto.cs`

**1. Genel Bakış**
`DashboardStatsDto`, gösterge paneli için özet istatistikleri taşıyan bir veri transfer nesnesidir. Uygulama (Application) katmanında, raporlama/okuma senaryolarında API veya UI’ye veri taşımak için kullanılır.

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
| AvailableBooks | `public int AvailableBooks { get; set; }` | Mevcut/ödünç verilmeye uygun kitap sayısı. |
| TotalCustomers | `public int TotalCustomers { get; set; }` | Toplam müşteri sayısı. |
| ActiveCustomers | `public int ActiveCustomers { get; set; }` | Aktif müşterilerin sayısı. |
| TotalStaff | `public int TotalStaff { get; set; }` | Toplam personel sayısı. |
| ActiveLoans | `public int ActiveLoans { get; set; }` | Devam eden ödünç işlemleri sayısı. |
| OverdueLoans | `public int OverdueLoans { get; set; }` | Gecikmiş ödünç işlemleri sayısı. |
| PendingReservations | `public int PendingReservations { get; set; }` | Bekleyen rezervasyon sayısı. |
| TotalUnpaidFines | `public decimal TotalUnpaidFines { get; set; }` | Ödenmemiş toplam ceza tutarı. |
| TotalBranches | `public int TotalBranches { get; set; }` | Toplam şube sayısı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: sayısal tipler için `0`, `TotalUnpaidFines` için `0m`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; genellikle Application servisleri/handler’ları veya API controller’ları tarafından doldurulur ve döndürülür.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait tek bir DTO görülüyor; diğer katmanlar (Domain, Infrastructure, API/Presentation) ve akışlar bu dosyadan çıkarılamıyor.
- Dış bağımlılıklar, konfigürasyon anahtarları ve hedef framework belirsiz.
- Mimari katmanlar arası bağımlılık yönleri tahmin edilemediğinden diyagram tek düğümle sınırlı kaldı.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanında para cezası (fine) bilgilerini istemci ile paylaşmak ve komut girişini almak için DTO’lar sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture tarzı katmanlama işareti var. `Application` katmanı, `Domain` katmanındaki enum’u referans alıyor.
  - Domain: İş kuralları ve temel türler (ör. `FineStatus` enum).
  - Application: DTO’lar, olası komut/sorgu modelleri ve uygulama kontratları.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Temel domain türleri (enum).
  - Library.Application — Uygulama katmanı DTO’ları.
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---

### `Library.Application/DTOs/FineDtos.cs`

**1. Genel Bakış**
Para cezası (fine) ile ilgili veri transferini sağlayan DTO tiplerini içerir: mevcut cezayı gösteren `FineDto`, yeni ceza oluşturma girdi modeli `CreateFineDto` ve ödeme girdi modeli `PayFineDto`. Application katmanına aittir ve dış dünyaya/üst katmanlara contract sağlar.

**2. Tip Bilgisi**
- Tip: class (`FineDto`, `CreateFineDto`, `PayFineDto`)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FineDto | `public class FineDto` | Para cezasının istemciye sunulan görünümü. |
| Id | `public Guid Id { get; set; }` | Ceza kimliği. |
| BookLoanId | `public Guid BookLoanId { get; set; }` | İlgili ödünç işlem kimliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Müşteri kimliği. |
| CustomerName | `public string CustomerName { get; set; }` | Müşteri adı. |
| BookTitle | `public string BookTitle { get; set; }` | Kitap adı. |
| Amount | `public decimal Amount { get; set; }` | Ceza tutarı. |
| Reason | `public string Reason { get; set; }` | Ceza nedeni. |
| Status | `public FineStatus Status { get; set; }` | Ceza durumu. |
| PaidDate | `public DateTime? PaidDate { get; set; }` | Ödeme tarihi (varsa). |
| PaymentMethod | `public string? PaymentMethod { get; set; }` | Ödeme yöntemi (varsa). |
| CreateFineDto | `public class CreateFineDto` | Ceza oluşturma girdi modeli. |
| BookLoanId | `public Guid BookLoanId { get; set; }` | İlgili ödünç işlem kimliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Müşteri kimliği. |
| Amount | `public decimal Amount { get; set; }` | Ceza tutarı. |
| Reason | `public string Reason { get; set; }` | Ceza nedeni. |
| PayFineDto | `public class PayFineDto` | Ceza ödeme girdi modeli. |
| PaymentMethod | `public string PaymentMethod { get; set; }` | Ödeme yöntemi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `CustomerName = string.Empty`, `BookTitle = string.Empty`, `Reason = string.Empty`, `PaymentMethod` (`FineDto` için `null`, `PayFineDto` için `string.Empty`).

**6. Bağlantılar**
- Yukarı akış: Çağırıcılar bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Enums.FineStatus` enum’una bağımlıdır.
- İlişkili tipler: `FineStatus` (Domain).

---

Genel Değerlendirme
- Kod, Clean Architecture yönelimli bir ayrımı işaret ediyor: Application DTO’ları Domain enum’una bağımlı. Diğer katmanlar (Infrastructure, API) bu dosyadan görülemiyor.
- Doğrulama anotasyonları veya kuralları DTO’larda yok; validasyon muhtemelen başka katmanlarda ele alınmalı.### Project Overview
Proje adı: Library (tahmin). Amaç: kütüphane şubelerine ait verilerin uygulama katmanında taşınması için DTO’lar sağlamak. Hedef çatı: .NET 6+ (TimeOnly kullanımı nedeniyle). Mimari desen: Clean Architecture/N‑Katmanlı yaklaşım izleniyor gibi; bu dosya Application katmanındaki DTO’ları temsil ediyor. Keşfedilen proje/assembly: Library.Application — rolü: Use case’ler, DTO’lar, arayüzler ve uygulama mantığı sözleşmeleri. Görünen harici paket yok. Konfigürasyon gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
↑
(Üst katmanlar: API/Presentation ve Application servisleri/handler’ları — bu dosyadan net değil)
↓
(Alt katmanlar: Domain, Infrastructure — bu dosyadan net değil)

---

### `Library.Application/DTOs/LibraryBranchDtos.cs`

**1. Genel Bakış**
Kütüphane şubelerine ilişkin veri aktarımını temsil eden üç DTO sunar: `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`. Uygulama katmanında isteklere/yanıtlara taşınacak alanları tanımlar; alan doğrulaması veya iş mantığı içermez.

**2. Tip Bilgisi**
- Tip: class (3 adet DTO)
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| LibraryBranchDto.Id | `public Guid Id { get; set; }` | Şubenin benzersiz kimliği. |
| LibraryBranchDto.Name | `public string Name { get; set; }` | Şube adı. |
| LibraryBranchDto.Address | `public string Address { get; set; }` | Adres. |
| LibraryBranchDto.City | `public string City { get; set; }` | Şehrin adı. |
| LibraryBranchDto.Phone | `public string Phone { get; set; }` | Telefon. |
| LibraryBranchDto.Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| LibraryBranchDto.Description | `public string? Description { get; set; }` | Açıklama (opsiyonel). |
| LibraryBranchDto.OpeningTime | `public TimeOnly OpeningTime { get; set; }` | Açılış saati. |
| LibraryBranchDto.ClosingTime | `public TimeOnly ClosingTime { get; set; }` | Kapanış saati. |
| LibraryBranchDto.IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| LibraryBranchDto.StaffCount | `public int StaffCount { get; set; }` | Personel sayısı. |
| LibraryBranchDto.BookCount | `public int BookCount { get; set; }` | Kitap sayısı. |
| CreateLibraryBranchDto.Name | `public string Name { get; set; }` | Oluşturma için şube adı. |
| CreateLibraryBranchDto.Address | `public string Address { get; set; }` | Adres. |
| CreateLibraryBranchDto.City | `public string City { get; set; }` | Şehir. |
| CreateLibraryBranchDto.PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| CreateLibraryBranchDto.Phone | `public string Phone { get; set; }` | Telefon. |
| CreateLibraryBranchDto.Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| CreateLibraryBranchDto.Description | `public string? Description { get; set; }` | Açıklama (opsiyonel). |
| CreateLibraryBranchDto.OpeningTime | `public TimeOnly OpeningTime { get; set; }` | Açılış saati. |
| CreateLibraryBranchDto.ClosingTime | `public TimeOnly ClosingTime { get; set; }` | Kapanış saati. |
| CreateLibraryBranchDto.Latitude | `public double? Latitude { get; set; }` | Enlem (opsiyonel). |
| CreateLibraryBranchDto.Longitude | `public double? Longitude { get; set; }` | Boylam (opsiyonel). |
| UpdateLibraryBranchDto.Name | `public string Name { get; set; }` | Güncelleme için şube adı. |
| UpdateLibraryBranchDto.Address | `public string Address { get; set; }` | Adres. |
| UpdateLibraryBranchDto.City | `public string City { get; set; }` | Şehir. |
| UpdateLibraryBranchDto.PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| UpdateLibraryBranchDto.Phone | `public string Phone { get; set; }` | Telefon. |
| UpdateLibraryBranchDto.Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| UpdateLibraryBranchDto.Description | `public string? Description { get; set; }` | Açıklama (opsiyonel). |
| UpdateLibraryBranchDto.OpeningTime | `public TimeOnly OpeningTime { get; set; }` | Açılış saati. |
| UpdateLibraryBranchDto.ClosingTime | `public TimeOnly ClosingTime { get; set; }` | Kapanış saati. |
| UpdateLibraryBranchDto.IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| UpdateLibraryBranchDto.Latitude | `public double? Latitude { get; set; }` | Enlem (opsiyonel). |
| UpdateLibraryBranchDto.Longitude | `public double? Longitude { get; set; }` | Boylam (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `string` alanlar `string.Empty`; `Email`, `Description`, `PostalCode`, `Latitude`, `Longitude` nullable; `IsActive` varsayılan `false`; `StaffCount` ve `BookCount` varsayılan `0`; `OpeningTime`/`ClosingTime` varsayılan `default(TimeOnly)`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (muhtemelen API Controller istek/yanıt modelleri veya Application katmanı handler’ları).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto` birbirleriyle ilişkilidir (okuma/oluşturma/güncelleme senaryoları).

### Genel Değerlendirme
Kod yalnızca Application katmanında DTO tanımlarını içeriyor; başka katmanlara dair referans görünmüyor. Doğrulama, mapping profilleri veya handler/service katmanı bu dosyada yer almıyor; bu bileşenler başka dosyalarda olabilir. TimeOnly kullanımı .NET 6+ gereksinimine işaret eder. Ek yapılandırma veya harici paket kullanımı bu içerikten çıkarılamıyor.## Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına yönelik uygulama katmanında bildirimlerle ilgili veri aktarımını (DTO) temsil etmek; domain katmanındaki `NotificationType` ile entegrasyon sağlamak.
- Hedef çerçeve: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli yapı. En azından `Application` ve `Domain` katmanları mevcut görünüyor. Application, Domain’e bağımlı.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, DTO tanımları.
  - Library.Domain — Domain katmanı (enum `NotificationType` referansı üzerinden anlaşılıyor).
- Kullanılan başlıca harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

## Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/DTOs/NotificationDtos.cs`

**1. Genel Bakış**
`NotificationDto` ve `CreateNotificationDto`, bildirim verilerinin dış katmanlar arasında taşınması için tasarlanmış veri aktarım nesneleridir. Application katmanına aittir ve Domain’deki `NotificationType` enum’unu kullanır.

**2. Tip Bilgisi**
- **Tip:** classes (`NotificationDto`, `CreateNotificationDto`)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `NotificationType` — Domain katmanından bildirim türünü temsil eden enum.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| `NotificationDto.Id` | `Guid Id { get; set; }` | Bildirimin benzersiz kimliği. |
| `NotificationDto.CustomerId` | `Guid CustomerId { get; set; }` | Bildirimin ait olduğu müşteri kimliği. |
| `NotificationDto.Title` | `string Title { get; set; }` | Bildirim başlığı. Varsayılanı `string.Empty`. |
| `NotificationDto.Message` | `string Message { get; set; }` | Bildirim mesajı. Varsayılanı `string.Empty`. |
| `NotificationDto.Type` | `NotificationType Type { get; set; }` | Bildirim türü. |
| `NotificationDto.IsRead` | `bool IsRead { get; set; }` | Okunma durumu. |
| `NotificationDto.ReadAt` | `DateTime? ReadAt { get; set; }` | Okunma zamanı (varsa). |
| `NotificationDto.CreatedAt` | `DateTime CreatedAt { get; set; }` | Oluşturulma zamanı. |
| `CreateNotificationDto.CustomerId` | `Guid CustomerId { get; set; }` | Hedef müşteri kimliği. |
| `CreateNotificationDto.Title` | `string Title { get; set; }` | Başlık. Varsayılanı `string.Empty`. |
| `CreateNotificationDto.Message` | `string Message { get; set; }` | Mesaj içeriği. Varsayılanı `string.Empty`. |
| `CreateNotificationDto.Type` | `NotificationType Type { get; set; }` | Bildirim türü. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Message = string.Empty`. Diğer alanlar CLR varsayılanlarıdır (`Guid.Empty`, `false`, `default(DateTime)`, `null`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.NotificationType`
- **İlişkili tipler:** `NotificationType` (Domain)

Genel Değerlendirme
- Kod, Clean Architecture benzeri katman ayrımını ima ediyor: Application katmanı Domain tipini referans alıyor.
- Sadece DTO’lar mevcut; doğrulama, mapping profilleri (ör. AutoMapper) veya iş kuralları bu dosyadan görünmüyor.
- Hedef framework, konfigürasyon anahtarları ve dış bağımlılıklar bu dosyadan tespit edilemiyor.### Proje Genel Bakış
- Proje adı: Library (koddan çıkarım). Amaç: Yayıncı (Publisher) bilgilerini uygulama katmanında taşıyan DTO tiplerini sağlamak. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari desen: Kesin değil; ancak `Library.Application.DTOs` ad alanı en azından katmanlı bir mimaride Application katmanının varlığını işaret eder.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO tanımları içerir.
- Kullanılan dış paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (DTO’lar)
  (Başka katman/bağımlılık bu dosyadan görünmüyor)

---
### `Library.Application/DTOs/PublisherDtos.cs`

**1. Genel Bakış**
Yayıncı (Publisher) varlığı için okuma (`PublisherDto`) ve yazma (`CreatePublisherDto`, `UpdatePublisherDto`) senaryolarını ayıran veri taşıma nesnelerini tanımlar. Application katmanına aittir ve API/Service sınırlarında veri sözleşmesi olarak kullanılması amaçlanır.

**2. Tip Bilgisi**
- Tip: class (`PublisherDto`)
  - Miras: Yok
  - Uygular: Yok
  - Namespace: `Library.Application.DTOs`
- Tip: class (`CreatePublisherDto`)
  - Miras: Yok
  - Uygular: Yok
  - Namespace: `Library.Application.DTOs`
- Tip: class (`UpdatePublisherDto`)
  - Miras: Yok
  - Uygular: Yok
  - Namespace: `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| PublisherDto.Id | `public Guid Id { get; set; }` | Yayıncının benzersiz kimliği. |
| PublisherDto.Name | `public string Name { get; set; }` | Yayıncı adı. |
| PublisherDto.City | `public string? City { get; set; }` | Şehir bilgisi. |
| PublisherDto.Country | `public string? Country { get; set; }` | Ülke bilgisi. |
| PublisherDto.Phone | `public string? Phone { get; set; }` | Telefon numarası. |
| PublisherDto.Email | `public string? Email { get; set; }` | E-posta adresi. |
| PublisherDto.Website | `public string? Website { get; set; }` | Web sitesi. |
| PublisherDto.FoundedYear | `public int? FoundedYear { get; set; }` | Kuruluş yılı. |
| PublisherDto.IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| PublisherDto.BookCount | `public int BookCount { get; set; }` | Yayınladığı kitap sayısı. |
| CreatePublisherDto.Name | `public string Name { get; set; }` | Yayıncı adı. |
| CreatePublisherDto.Address | `public string? Address { get; set; }` | Adres. |
| CreatePublisherDto.City | `public string? City { get; set; }` | Şehir. |
| CreatePublisherDto.Country | `public string? Country { get; set; }` | Ülke. |
| CreatePublisherDto.Phone | `public string? Phone { get; set; }` | Telefon. |
| CreatePublisherDto.Email | `public string? Email { get; set; }` | E-posta. |
| CreatePublisherDto.Website | `public string? Website { get; set; }` | Web sitesi. |
| CreatePublisherDto.FoundedYear | `public int? FoundedYear { get; set; }` | Kuruluş yılı. |
| UpdatePublisherDto.Name | `public string Name { get; set; }` | Yayıncı adı. |
| UpdatePublisherDto.Address | `public string? Address { get; set; }` | Adres. |
| UpdatePublisherDto.City | `public string? City { get; set; }` | Şehir. |
| UpdatePublisherDto.Country | `public string? Country { get; set; }` | Ülke. |
| UpdatePublisherDto.Phone | `public string? Phone { get; set; }` | Telefon. |
| UpdatePublisherDto.Email | `public string? Email { get; set; }` | E-posta. |
| UpdatePublisherDto.Website | `public string? Website { get; set; }` | Web sitesi. |
| UpdatePublisherDto.FoundedYear | `public int? FoundedYear { get; set; }` | Kuruluş yılı. |
| UpdatePublisherDto.IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler:
- `Name = string.Empty`
- `IsActive` varsayılanı: `false` (yalnızca `UpdatePublisherDto` ve `PublisherDto` için tanımlı)
- Diğer referans tipleri `null` kabul eder.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto` (birbirleriyle ilişkili okuma/oluşturma/güncelleme sözleşmeleri).

### Genel Değerlendirme
- Sadece DTO katmanı görünüyor; diğer katmanlara (Domain, Infrastructure, API) dair kanıt yok.
- Validasyon anotasyonları veya kuralları (örn. `Required`, uzunluk sınırları) yok; bu, doğrulamanın başka bir katmanda yapıldığını veya eksik olduğunu düşündürür ancak bu dosyadan kesinleşmez.
- `Address` alanı sadece create/update DTO’larında mevcut, `PublisherDto` içinde yok; bu, listeleme/okuma çıktısında adresin bilinçli olarak dışlandığı bir tasarım tercihine işaret edebilir.### Project Overview
- Proje adı: Library (katman adlarına göre çıkarım)
- Amaç: Kütüphane personel verilerini uygulama katmanında taşımak/aktarmak için DTO tipleri sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture (gözlenen katmanlar: Application, Domain)
  - Domain: Temel iş kavramları ve enum’lar (`Library.Domain.Enums.StaffRole`)
  - Application: DTO’lar, muhtemel use case/handler/sözleşmeler (bu dosyada yalnızca DTO görünüyor)
- Projeler/Assembly’ler:
  - Library.Domain — Temel domain türleri ve enum’lar
  - Library.Application — Uygulama sözleşmeleri/DTO’ları
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, kütüphane personeline ait kimlik, iletişim, rol ve bağlı şube bilgilerini taşımak için kullanılan veri transfer nesnesidir. Clean Architecture bağlamında Application katmanına aittir ve Domain katmanındaki `StaffRole` enum’unu kullanır.

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
| Id | `public Guid Id { get; set; }` | Personelin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| Role | `public StaffRole Role { get; set; }` | Personelin sistemsel rolü (Domain enum’u). |
| HireDate | `public DateTime HireDate { get; set; }` | İşe alınma tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |
| EmployeeNumber | `public string? EmployeeNumber { get; set; }` | Personel numarası (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Bağlı şube kimliği (opsiyonel). |
| LibraryBranchName | `public string? LibraryBranchName { get; set; }` | Bağlı şube adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`. `Role` varsayılan `0` (enum default), `HireDate = default(DateTime)`, `IsActive = false`, `EmployeeNumber = null`, `LibraryBranchId = null`, `LibraryBranchName = null`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Enums.StaffRole`
- İlişkili tipler: `StaffRole` (Domain enum’u)

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO ve Domain’e referans tespit edildi; diğer katmanlar (Infrastructure, API/Presentation) bu dosyadan anlaşılmıyor.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları görünür değil.
- Clean Architecture izleri mevcut: Application katmanı Domain’e bağımlı, tersine bağımlılık yok. DTO’larda beklenen şekilde iş mantığı bulunmuyor.### Project Overview
- Proje adı: Library (isim uzayından çıkarım)
- Amaç: Kitap kategorileri gibi kavramlar için uygulama katmanında kullanılan veri aktarım nesnelerini (DTO) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/temiz sınırlar ima ediliyor (Application katmanı mevcut). Diğer katmanların (Domain/Infrastructure/API) varlığı bu dosyadan kesin değil.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel komut/sorgu işleyicilerinin sözleşmeleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisi güncelleme işlemlerinde taşınan veriyi temsil eden basit bir DTO’dur. Uygulama (Application) katmanına aittir ve özellikle güncelleme komutları/handler’ları ile API istek/yanıt gövdeleri arasında veri taşımayı amaçlar.

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
| Name | `public string Name { get; set; }` | Kategori adını taşır. |
| Description | `public string Description { get; set; }` | Kategori açıklamasını taşır. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod yalnızca Application katmanında bir DTO içeriyor; diğer katmanlar ve akışlar görünmüyor.
- Doğrulama kuralları (ör. `Name` zorunluluğu, uzunluk sınırları) DTO üzerinde tanımlı değil; muhtemelen başka bir katmanda ele alınıyor. Bu dosyadan doğrulanamıyor.
- Hedef framework, paketler ve konfigürasyon bilgileri tespit edilemiyor.### Project Overview (required, once)
Proje adı: Library. Amaç: kütüphane alanına ait varlıklar için uygulama katmanında veri taşıma nesneleri (DTO) sağlamak ve domain sabitlerini kullanmak. Hedef çatı çerçevesi bu dosyadan anlaşılmıyor. Mimari, en azından Domain ve Application katmanlarını içeren katmanlı bir yapıdadır.

Mimari desen: Katmanlı mimari (Domain ↔ Application). Application katmanı, istemci/arayüz katmanları ile Domain arasındaki veri sözleşmelerini taşır. Domain, temel enum ve kuralları barındırır.

Projeler/Assembly’ler:
- Library.Application — DTO’lar ve uygulama-odaklı sözleşmeler.
- Library.Domain — Domain enum’ları ve muhtemel domain modelleri.

Harici paketler/çatı: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram (required, once)
Library.Application -> Library.Domain

---
### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
`UpdateBookDto`, bir kitabın güncellenmesi için gerekli alanları toplayan veri taşıma nesnesidir. Uygulama (Application) katmanına aittir ve Domain’de tanımlı `BookCondition` enum’unu kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.BookCondition` — Kitap durumunu temsil eden domain enum’u.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Title | `string Title { get; set; }` | Kitap başlığı. |
| ISBN | `string ISBN { get; set; }` | Uluslararası standart kitap numarası. |
| Description | `string Description { get; set; }` | Kitap açıklaması/özeti. |
| PublishedYear | `int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `string Language { get; set; }` | Dil bilgisi. |
| IsAvailable | `bool IsAvailable { get; set; }` | Kullanılabilirlik durumu. |
| TotalCopies | `int TotalCopies { get; set; }` | Toplam kopya sayısı. |
| AvailableCopies | `int AvailableCopies { get; set; }` | Mevcut kullanılabilir kopya sayısı. |
| Condition | `BookCondition Condition { get; set; }` | Fiziksel durum enum’u. |
| Price | `decimal? Price { get; set; }` | Opsiyonel fiyat bilgisi. |
| AuthorId | `Guid AuthorId { get; set; }` | Yazar kimliği. |
| PublisherId | `Guid? PublisherId { get; set; }` | Opsiyonel yayınevi kimliği. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Opsiyonel kategori kimliği. |
| LibraryBranchId | `Guid? LibraryBranchId { get; set; }` | Opsiyonel kütüphane şubesi kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `ISBN = string.Empty`, `Description = string.Empty`, `Language = "Turkish"`. Diğer alanlar için default CLR değerleri kullanılır (`bool` için `false`, `int` için `0`, `Guid` için `default`, nullable alanlar için `null`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.BookCondition`.
- **İlişkili tipler:** `Library.Domain.Enums.BookCondition`.

Genel Değerlendirme
- Kodda Application ve Domain katmanlarının varlığı, katmanlı bir mimariye işaret ediyor; ancak hedef framework, dış bağımlılıklar ve konfigürasyon anahtarları bu dosyadan görülemiyor.
- DTO’larda alan adları tutarlı ve güncelleme senaryoları için yeterli görünüyor; fakat doğrulama kuralları (zorunlu alanlar, aralık kontrolleri) bu seviyede tanımlı değil, muhtemelen başka katmanlarda ele alınmalı.### Proje Özeti
- Proje adı: Library
- Amaç: Kütüphane alanına yönelik müşteri bilgilerini güncelleme süreçlerinde kullanılan uygulama katmanı DTO’larını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Muhtemelen Clean Architecture (veya N‑Katmanlı). Katmanlar:
  - Domain: Temel iş kuralları ve enum’lar (`Library.Domain.Enums.MembershipType`).
  - Application: Use case’ler, DTO’lar, arayüzler ve iş akışları (bu dosya burada).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve iş akışı sözleşmeleri.
  - Library.Domain — İş kuralı tipleri ve enum’lar (enum kullanımından çıkarım).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application → Library.Domain

---

### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, müşteri güncelleme işlemleri için gerekli alanları taşıyan bir veri aktarım nesnesidir. Uygulama (Application) katmanında, komut/sorgu işleyicileri veya controller’lar ile domain/servis katmanları arasında veri taşımak için kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adres bilgisi. |
| City | `public string City { get; set; }` | Müşterinin şehir bilgisi. |
| PostalCode | `public string? PostalCode { get; set; }` | Müşterinin posta kodu (opsiyonel). |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi (`Library.Domain.Enums.MembershipType`). |
| IsActive | `public bool IsActive { get; set; }` | Müşteri durum bilgisi (aktif/pasif). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `PostalCode = null`, `MembershipType = default(MembershipType)`, `IsActive = false`.

**6. Bağlantılar**
- **Yukarı akış:** Komut/sorgu işleyicileri veya controller’lar tarafından kullanılır (bu dosyadan kesin çağırıcılar anlaşılmıyor).
- **Aşağı akış:** `Library.Domain.Enums.MembershipType` enum’ına tür bağımlılığı.
- **İlişkili tipler:** `MembershipType` (Domain katmanı enum’ı).

---

### Genel Değerlendirme
- Mimari, Domain ve Application katmanları arasında bağımlılık yönüne uygun bir ayrımı işaret ediyor. Ancak hedef framework, paketler ve konfigürasyonlar bu dosyadan tespit edilemiyor.
- DTO’da validasyon anotasyonları veya kuralları bulunmuyor; bu durumun başka katmanlarda ele alınması beklenir.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kütüphane personel yönetimi ve ilgili uygulama işlevleri için veri taşıma tipleri sağlamak. Hedef framework: Bu dosyadan anlaşılmıyor.

Mimari desen: Clean Architecture/N‑Katmanlı. Katmanlar:
- Domain: Temel iş kuralları ve tipler (ör. `Library.Domain.Enums.StaffRole`).
- Application: Use case’lere yönelik DTO’lar, komut/sorgu modelleri ve iş akışları (ör. `Library.Application.DTOs.UpdateStaffDto`).
Diğer katmanlar (Infrastructure, API/Presentation) bu dosyadan anlaşılmıyor.

Projeler/Assembly’ler:
- Library.Domain — Domain tipleri ve sabitler (enum vb.).
- Library.Application — Uygulama katmanı; DTO’lar ve iş akışı giriş/çıkış modelleri.

Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
Kütüphane personelini güncelleme işlemleri için kullanılan bir DTO’dur. İstemciden gelen güncelleme verilerini uygulama katmanına taşır; doğrulama veya iş mantığı içermez. Clean Architecture içinde Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
- `Library.Domain.Enums.StaffRole` — Personel rolünü temsil eden domain enum’u

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e‑posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyon/ünvan bilgisi. |
| Role | `public StaffRole Role { get; set; }` | Personelin rolü (domain enum). |
| Salary | `public decimal? Salary { get; set; }` | Personelin maaşı (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Bağlı olduğu şube kimliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `Salary = null`, `IsActive = false`, `LibraryBranchId = null`, `Role` için enum’un varsayılan değeri (0).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Enums.StaffRole`
- **İlişkili tipler:** `StaffRole` (Domain enum)

**7. Eksikler ve Gözlemler**
- DTO üzerinde hiçbir validasyon niteliği (ör. `Required`, `EmailAddress`) yok; zorunlu alanlar ve format doğrulaması başka bir katmanda yapılmalı veya eklenmeli.

---

Genel Değerlendirme
- Kod tabanından görüldüğü kadarıyla Application ve Domain katmanları ayrışmış durumda; Clean Architecture yönelimi var.
- DTO’larda veri doğrulama bulunmuyor; API veya Application katmanında ayrı validasyon (ör. FluentValidation veya data annotations) eklenmesi önerilir.
- Hedef framework, konfigürasyon ve harici bağımlılıklar bu dosyadan net değil; proje genelinde belgelendirilmesi faydalı olur.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Uygulama katmanındaki servis arayüzlerini somut servis implementasyonlarıyla DI konteynerine eklemek; uygulama servislerinin yaşam döngülerini yönetmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; bu dosya Application katmanına ait DI kurulumunu sağlar. Diğer katmanlar bu dosyadan görünmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama servislerinin DI kayıtlarını yapan uygulama katmanı.
- Harici paketler/çatı:
  - Microsoft.Extensions.DependencyInjection — DI kayıtları için.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Microsoft.Extensions.DependencyInjection

---

### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
Uygulama katmanı servislerini DI konteynerine ekleyen `IServiceCollection` uzantısını sağlar. Amaç, `Library.Application` içindeki arayüz–implementasyon eşleşmelerini scoped yaşam döngüsüyle kaydetmektir. Application katmanına aittir.

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
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Application servislerini scoped olarak DI konteynerine ekler ve koleksiyonu geri döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm servisler scoped olarak kaydedilir: `IBookService`→`BookService`, `IBookCategoryService`→`BookCategoryService`, `IStaffService`→`StaffService`, `ICustomerService`→`CustomerService`, `IAuthorService`→`AuthorService`, `IPublisherService`→`PublisherService`, `IBookLoanService`→`BookLoanService`, `IBookReservationService`→`BookReservationService`, `IFineService`→`FineService`, `ILibraryBranchService`→`LibraryBranchService`, `IBookReviewService`→`BookReviewService`, `INotificationService`→`NotificationService`, `IDashboardService`→`DashboardService`.
- Kayıtların kapsamı HTTP istek başına veya benzer scope’a uygun olacak şekilde ayarlanır.
- Metot akışında ek validasyon veya hata yönetimi bulunmaz; DI kayıtları başarısız olursa bu, çalışma zamanındaki type resolution aşamasında ortaya çıkar.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; genelde Composition Root (ör. API veya Host) bu uzantıyı çağırır.
- Aşağı akış: `Microsoft.Extensions.DependencyInjection.IServiceCollection`.
- İlişkili tipler: `IBookService`, `BookService`, `IBookCategoryService`, `BookCategoryService`, `IStaffService`, `StaffService`, `ICustomerService`, `CustomerService`, `IAuthorService`, `AuthorService`, `IPublisherService`, `PublisherService`, `IBookLoanService`, `BookLoanService`, `IBookReservationService`, `BookReservationService`, `IFineService`, `FineService`, `ILibraryBranchService`, `LibraryBranchService`, `IBookReviewService`, `BookReviewService`, `INotificationService`, `NotificationService`, `IDashboardService`, `DashboardService`.

**7. Eksikler ve Gözlemler**
- Kayıtlı arayüz ve sınıfların tanımları bu dosyada bulunmuyor; sözleşme-implementasyon uyumu bu dosyadan doğrulanamıyor.
- Yaşam döngüsü tercihleri (scoped vs transient/singleton) ile ilgili gerekçe belirtilmemiş; ancak web tabanlı senaryolar için scoped tipik bir seçimdir.

---

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait DI kurulumu görünür durumda; Domain/Infrastructure/API gibi katmanlar bu veriyle doğrulanamıyor.
- Servis kayıtları kapsamlı görünüyor; ancak tiplerin varlığı ve isim uyumları proje genelinde doğrulanmalı.
- Konfigürasyon, logging, validation pipeline, MediatR gibi ortak uygulama altyapılarına dair kayıtlar görünmüyor; ihtiyaç varsa composition root’ta veya ek uzantılarda tanımlanmalıdır.### Project Overview
Proje adı: Library (çıkarım: `Library.Application` ad alanı). Amaç: uygulamanın e‑posta gönderimine ilişkin yapılandırma ayarlarını temsil eden bir konfigürasyon tipi sağlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak katmanlı bir yaklaşıma işaret eder; bu dosya Application katmanında konumlanmıştır.

Mimari desen: Katmanlı (en azından Application katmanı gözlemleniyor). Application katmanı: uygulama mantığına ve konfigürasyon sözleşmelerine ait tipler.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; e‑posta ayarları gibi konfigürasyon sözleşmeleri içerir.

Harici paketler/çerçeveler: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: E‑posta gönderimi için host, port, kullanıcı adı, parola, gönderici adresi, bildirim alıcısı ve SSL etkinliği gibi ayarlar beklenir (ör. `Host`, `Port`, `Username`, `Password`, `From`, `NotificationTo`, `EnableSsl`).

### Architecture Diagram
Library.Application

---

### `Library.Application/Email/EmailSettings.cs`

**1. Genel Bakış**
`EmailSettings`, e‑posta gönderimi için gereken yapılandırma değerlerini taşıyan basit bir konfigürasyon sınıfıdır. Application katmanında yer alır ve tipik olarak konfigürasyondan bağlanarak e‑posta servislerine iletilir.

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
| Port | `public int Port { get; set; }` | SMTP portu (varsayılan 587). |
| Username | `public string Username { get; set; }` | SMTP kimlik doğrulama kullanıcı adı. |
| Password | `public string Password { get; set; }` | SMTP kimlik doğrulama parolası. |
| From | `public string From { get; set; }` | Gönderici e‑posta adresi. |
| NotificationTo | `public string NotificationTo { get; set; }` | Bildirimlerin gönderileceği alıcı adresi. |
| EnableSsl | `public bool EnableSsl { get; set; }` | SSL kullanım bayrağı (varsayılan true). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Host = string.Empty`, `Port = 587`, `Username = string.Empty`, `Password = string.Empty`, `From = string.Empty`, `NotificationTo = string.Empty`, `EnableSsl = true`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; e‑posta gönderen servisler/handler’lar tarafından kullanılması beklenir.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel ilişki: e‑posta servis implementasyonları).

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanından bir konfigürasyon DTO’su görülüyor; diğer katmanlar ve e‑posta gönderim servisi implementasyonları bu dosyadan anlaşılamıyor.
- Hedef framework, paket bağımlılıkları ve yapılandırmanın bağlanma yöntemi (ör. `IOptions<EmailSettings>`) görünür değil; projede bu alanların netleştirilmesi dokümantasyon açısından faydalı olacaktır.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına yönelik uygulama katmanında servis sözleşmeleri ve DTO’lar üzerinden işlevlerin tanımlanması.
- Hedef framework: Bu dosyadan çıkarılamıyor.
- Mimari desen: Katmanlı/Clean Architecture benzeri yaklaşım; `Application` katmanında servis arayüzleri ve DTO’lar tanımlanmış.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri (`Interfaces`) ve veri transfer nesneleri (`DTOs`) kullanılıyor.
- Kullanılan dış paketler/çatı: Bu dosyadan çıkarılamıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan çıkarılamıyor.

### Architecture Diagram
- Katman/Proje bağımlılıkları (bu dosyadan görülebildiği kadarıyla):
  - Library.Application.Interfaces --> Library.Application.DTOs

---
### `Library.Application/Interfaces/IAuthorService.cs`

**1. Genel Bakış**
`IAuthorService`, yazarlara ilişkin CRUD ve arama operasyonlarını tanımlayan uygulama katmanı servis arayüzüdür. Sunum veya altyapı katmanları tarafından uygulanıp çağrılması hedeflenen bir sözleşme görevi görür.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Arayüz düzeyinde sadece `Library.Application.DTOs` türleri referanslanır.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<AuthorDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için yazarı döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<AuthorDto>> GetAllAsync()` | Tüm yazarları döndürür. |
| SearchAsync | `Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)` | Arama terimine göre yazarları filtreleyip döndürür. |
| CreateAsync | `Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)` | Yeni yazar oluşturur ve oluşturulan yazarı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)` | Verilen `id` için yazar bilgisini günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’deki yazarı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış tanımlı değil. Beklentiler: id ile tekil erişim, toplu listeleme, metin bazlı arama, oluşturma, güncelleme ve silme operasyonlarının asenkron yürütülmesi. Validasyon, hata yönetimi ve transaction ayrıntıları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak uygulama servisleri veya API katmanı tarafından çağrılır (bu dosyadan kesinleşmiyor).
- **Aşağı akış:** Harici bağımlılık yok (arayüz). DTO bağımlılıkları: `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`.
- **İlişkili tipler:** `Library.Application.DTOs.AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`.

**7. Eksikler ve Gözlemler**
- Tüm asenkron imzalarda `CancellationToken` parametresi bulunmuyor; uzun süren işlemler için iptal desteği eklenmesi faydalı olabilir.
- `GetAllAsync` ve `SearchAsync` için sayfalama/sıralama desteği yok; geniş veri kümelerinde performans ve tüketim açısından eksiklik yaratabilir.
- `UpdateAsync` ve `DeleteAsync` dönüş değerleri/sonuç bilgisi yok; bulunamayan kayıt, versiyonlama/eşzamanlılık gibi durumlar için geribildirim eksik olabilir.

### Genel Değerlendirme
Kod parçası yalnızca uygulama katmanına ait bir servis arayüzü sunuyor. Mimari olarak Clean Architecture benzeri bir ayrım ima edilse de diğer katmanlar ve dış bağımlılıklar görünmüyor. İptal belirteci, sayfalama ve daha ifade gücü yüksek dönüş türleri (ör. sonuç tipi veya bool) gibi sözleşme iyileştirmeleri, ölçeklenebilirlik ve hata yönetimi açısından önerilir.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Kitap kategorileri için uygulama katmanında hizmet sözleşmelerini ve DTO’ları tanımlamak; uygulama mantığını domain ve altyapıdan ayrıştırmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean Architecture eğilimli yapı. Application katmanı, DTO’ları ve servis arayüzlerini içerir; uygulama iş kuralları ve sözleşmeler burada tanımlanır, implementasyon başka katmanlarda sağlanır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; `Interfaces` ve `DTOs` içerir.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application.Interfaces] -> [Library.Application.DTOs]

---

### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorileri üzerinde CRUD operasyonları için uygulama katmanında servis sözleşmesini tanımlar. Bu arayüz, Application katmanına aittir ve implementasyonlarının Infrastructure veya başka bir katmanda sağlanmasını amaçlar.

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
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Verilen `id` için kategori DTO’sunu getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori DTO’larını döner. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni bir kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Verilen `id`’deki kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’deki kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok. İş kuralları ve validasyon detayları implementasyonlarda belirlenir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/uygulama hizmetleri veya handler’lar çağırır.
- **Aşağı akış:** `Library.Application.DTOs` tipleri (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`).
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- `UpdateAsync` ve `DeleteAsync` için bulunamayan kayıt, eşzamanlılık veya doğrulama hataları durumunda sözleşme düzeyinde açık hata yönetimi/sonuç tipi tanımlı değil (ör. Result tipi, özel exception sözleşmesi).

---

Genel Değerlendirme
- Kod tabanı, Application katmanında servis arayüzü ve DTO ayrımıyla Clean Architecture yönelimini işaret ediyor. Ancak yalnızca bir arayüz görülebildiği için hedef framework, dış bağımlılıklar ve diğer katmanlar (Domain, Infrastructure, API) bu dosyadan anlaşılamıyor.
- Sözleşmede hata yönetimi ve sonuç tipleri (ör. Result, OneOf) standardize edilmemiş; uygulama genelinde tutarlı bir desen önerilir.### Project Overview
- Project name: Library
- Purpose: Kütüphane ödünç verme süreçlerini yönetmeye yönelik uygulama; `Application` katmanında kitap ödünç işlemleri için servis sözleşmesi tanımlanıyor.
- Target framework: Bu dosyadan anlaşılmıyor.
- Architecture pattern: Katmanlı/Clean Architecture eğilimli. `Application` katmanı, `Domain` tiplerine (enum) referans veriyor ve muhtemel olarak Infrastructure ve API katmanları tarafından kullanılacak.
- Discovered projects/assemblies and roles:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri ve DTO’lar.
  - Library.Domain — Domain model/enum’lar (ör. `LoanStatus`).
- Key external packages/frameworks: Bu dosyadan anlaşılmıyor.
- Configuration requirements: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <-  Library.Application

---

### `Library.Application/Interfaces/IBookLoanService.cs`

**1. Genel Bakış**
Kütüphane ödünç verme yaşam döngüsünü (oluşturma, iade, uzatma, silme) ve sorgulama operasyonlarını tanımlayan servis arayüzüdür. Application katmanına aittir ve UI/API tarafından tüketilmek üzere iş kurallarını soyutlar.

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
| GetByIdAsync | `Task<BookLoanDto?> GetByIdAsync(Guid id)` | Belirli bir ödünç kaydını kimliğiyle getirir; bulunamazsa null döner. |
| GetAllAsync | `Task<IEnumerable<BookLoanDto>> GetAllAsync()` | Tüm ödünç kayıtlarını listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)` | Verilen müşteri kimliğine ait ödünçleri döner. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()` | Aktif (iade edilmemiş) ödünçleri listeler. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()` | Gecikmiş ödünçleri listeler. |
| GetByStatusAsync | `Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)` | Verilen `LoanStatus` durumuna göre filtreler. |
| CreateAsync | `Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)` | Yeni ödünç kaydı oluşturur. |
| ReturnBookAsync | `Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)` | Belirli ödünç kaydını iade işlemiyle kapatır. |
| RenewLoanAsync | `Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)` | Belirli ödünç kaydının süresini uzatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Ödünç kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış belirtmez; sözleşme olarak operasyonları tanımlar.
- İpuçları: `ReturnBookAsync` iade tarihi/ceza hesapları, `RenewLoanAsync` uygunluk kontrolü ve yeni bitiş tarihi gibi iş kuralları içerebilir; detaylar bu dosyadan anlaşılmıyor.
- `GetOverdueLoansAsync` gecikme belirleme kriterlerini uygulamada bırakır.

**6. Bağlantılar**
- **Yukarı akış:** API controller’ları veya Application hizmetlerini kullanan üst katmanlar; DI üzerinden çözümlenir.
- **Aşağı akış:** DTO’lar (`BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`) ve domain enum’ı (`LoanStatus`).
- **İlişkili tipler:** `Library.Application.DTOs.*`, `Library.Domain.Enums.LoanStatus`.

Genel Değerlendirme
- Yalnızca servis sözleşmesi mevcut; uygulama sınıfları, veri erişimi ve doğrulama detayları bu depoda görünmüyor.
- Hedef çatı, konfigürasyon anahtarları ve dış bağımlılıklar çıkarılamıyor.
- Mimari olarak Application → Domain bağımlılığı tutarlı; potansiyel Clean Architecture yaklaşımıyla uyumlu görünüyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki “rezervasyon” işlemlerini uygulama katmanında soyutlamak ve dış katmanlara (API/Infrastructure) sözleşme sunmak. Hedef çatı: bu dosyadan anlaşılmıyor (ör. net7.0/net8.0 belirsiz).

Mimari desen: Katmanlı/Clean Architecture yaklaşımı izleniyor gibi; bu dosya Application katmanında bir servis sözleşmesini tanımlıyor. Application katmanı: DTO’lar ve servis arayüzleri ile iş kurallarını tanımlayan sözleşmeler. Diğer katmanlar bu dosyadan anlaşılmıyor.

Projeler/assembly’ler:
- Library.Application — Application katmanı; DTO’lar ve servis arayüzleri (ör. `IBookReservationService`) içerir.

Dış bağımlılıklar: Görünürde paket bilgisi yok (EF Core, MediatR vb. bu dosyadan anlaşılmıyor).

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
[Consumers (API/Workers)] → Library.Application (Interfaces, DTOs)
Diğer katman/bağımlılıklar bu dosyadan anlaşılamıyor.

---
### `Library.Application/Interfaces/IBookReservationService.cs`

**1. Genel Bakış**
`IBookReservationService`, kitap rezervasyonlarına ilişkin sorgulama ve yaşam döngüsü işlemlerinin sözleşmesini tanımlar. Application katmanında yer alır ve implementasyonları Infrastructure veya API tarafından DI ile tüketilmek üzere bir servis kontratı sağlar.

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
| GetByIdAsync | `Task<BookReservationDto?> GetByIdAsync(Guid id)` | Belirli rezervasyonu kimliğe göre döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookReservationDto>> GetAllAsync()` | Tüm rezervasyonları listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteri kimliğine göre rezervasyonları listeler. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)` | Kitap kimliğine göre rezervasyonları listeler. |
| CreateAsync | `Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)` | Yeni rezervasyon oluşturur ve döndürür. |
| CancelReservationAsync | `Task CancelReservationAsync(Guid id)` | Rezervasyonu iptal eder. |
| FulfillReservationAsync | `Task FulfillReservationAsync(Guid id)` | Rezervasyonu karşılama/tamamlama işlemini yapar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Rezervasyonu kalıcı olarak siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez. İş kuralları implementasyonlarda tanımlanacaktır.
- DTO kullanımı: Girdi için `CreateBookReservationDto`, çıktı için `BookReservationDto`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; API Controller’ları, Application hizmetleri veya arka plan işlerince çağrılabilir.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor (veri erişimi/transaction altyapısı belirtilmemiş).
- **İlişkili tipler:** `BookReservationDto`, `CreateBookReservationDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Listeleme metotlarında sayfalama/sıralama sözleşmesi yok; büyük veri setlerinde performans/kullanılabilirlik etkilenebilir.
- İptal/fulfillment işlemlerinin hata durumları (ör. zaten iptal edilmiş rezervasyon) için beklenen exception/sonuç sözleşmesi tanımlı değil.

Genel Değerlendirme
- Kod tabanı sadece Application katmanındaki bir servis arayüzünü gösteriyor; diğer katmanlar görünmüyor.
- Sözleşme açık ve ayrıştırılmış; ancak sorgular için sayfalama/sıralama ve durum geçişleri için beklenen hata/sonuç sözleşmelerinin netleştirilmesi faydalı olur.
- Hedef çatı ve dış bağımlılıklar görünmediğinden, proje düzeyinde paket ve konfigürasyon belgelenmesi eksik.### Project Overview
Proje adı: Library (uygulama katmanı). Amaç: kitap incelemeleriyle ilgili uygulama servis sözleşmelerini tanımlamak (okuma, oluşturma, güncelleme, onaylama, silme). Hedef çatı/TFM bu dosyadan anlaşılmıyor.
Mimari: Katmanlı/Clean benzeri yapı işaretleri var; `Library.Application` içinde sadece arayüzler ve DTO referansları bulunuyor. Uygulama katmanı, alan modelleri ve altyapı detaylarından bağımsız sözleşmeler sunuyor.
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; arayüzler (`Interfaces`) ve DTO’lar (`DTOs`) ile use-case sözleşmelerini tanımlar.
Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
Konfigürasyon gereksinimleri: Görünür değil.

### Architecture Diagram
Library.Application
 └─ Interfaces → DTOs

---

### `Library.Application/Interfaces/IBookReviewService.cs`

**1. Genel Bakış**
Kitap inceleme operasyonlarına yönelik uygulama servis sözleşmesini tanımlar. Okuma (ID’ye, kitaba, müşteriye göre), ortalama puan hesaplama, oluşturma, güncelleme, onaylama ve silme işlemlerini kapsar. Uygulama (Application) katmanına aittir ve altyapıdan bağımsızdır.

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
| GetByIdAsync | `Task<BookReviewDto?> GetByIdAsync(Guid id)` | İncelemeyi kimliğine göre getirir; bulunamazsa `null`. |
| GetByBookIdAsync | `Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)` | Belirli bir kitaba ait tüm incelemeleri döner. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)` | Belirli bir müşterinin tüm incelemelerini döner. |
| GetAverageRatingAsync | `Task<double> GetAverageRatingAsync(Guid bookId)` | Bir kitabın ortalama puanını hesaplar. |
| CreateAsync | `Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)` | Yeni inceleme oluşturur ve döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)` | Mevcut incelemeyi günceller. |
| ApproveReviewAsync | `Task ApproveReviewAsync(Guid id)` | İncelemeyi onaylar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | İncelemeyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme — davranış içermez; iş kuralları implementasyona bırakılmıştır.
- `GetByIdAsync` için bulunamama durumunda `null` dönebilir.
- `GetAverageRatingAsync` için hiç inceleme olmadığında dönüş davranışı (0.0 mı, exception mı) bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/Presentation katmanındaki controller/handler’lar çağırır.
- **Aşağı akış:** DTO türleri: `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`.
- **İlişkili tipler:** `Library.Application.DTOs.*`

**7. Eksikler ve Gözlemler**
- Tüm async imzalarda `CancellationToken` desteği yok; uzun sürebilecek IO işlemlerinde iptal edilebilirlik eksik.
- Listeleme operasyonlarında sayfalama/sıralama parametreleri yok; veri hacmi büyüdüğünde performans/taşıma maliyeti artabilir.
- `GetAverageRatingAsync` için inceleme yokken davranış belirsiz.

---

Genel Değerlendirme
- Görünen tek katman `Library.Application`; arayüz odaklı tasarım, Clean/katmanlı mimariye uyumlu.
- Sözleşmeler net; ancak iptal belirteci (`CancellationToken`) ve potansiyel sayfalama/sıralama eksik.
- Hata ve bulunamama durumları için sözleşme seviyesinde standart belirteçler (ör. özel sonuç tipleri, `Result<T>`, domain-specific exceptions) tanımlanmamış; uygulamada tutarlılık için değerlendirilebilir.### Project Overview
Proje adı: Library. Amaç: Kitap yönetimi için uygulama katmanında servis sözleşmelerini tanımlamak. Hedef çatı/TFM: Bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean-vari yapı; bu repository’de yalnızca Application katmanına ait bir arayüz görünür.

Katmanlar:
- Application: Use case/iş mantığı sözleşmeleri, DTO’lar ve servis arayüzleri (ör. `IBookService`).

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; servis arayüzleri ve DTO sözleşmeleri.

Harici paketler/çerçeveler:
- Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri:
- Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Caller/Üst Katman] → Library.Application

(Üst katman(lar) ve altyapı projeleri bu dosyadan anlaşılmıyor; yalnızca Application katmanı keşfedildi.)

---

### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara yönelik CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Application katmanında yer alır ve üst katmanlar (ör. API) tarafından DI üzerinden kullanılması amaçlanır.

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
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kitabı döner, bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları listeler. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait/ödünç verilebilir kitapları listeler. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni bir kitap oluşturur ve oluşturulan kaydı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Mevcut kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme düzeyinde; validasyon ve iş kuralları belirtilmemiştir.
- `GetByIdAsync` bulunamadığında `null` dönebilecek şekilde tasarlanmıştır.
- Oluşturma/güncelleme DTO’ları: `CreateBookDto`, `UpdateBookDto` kullanılır; detayları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar: API/Presentation katmanı.
- **Aşağı akış:** Bu arayüzün implementasyonunda veri erişimi katmanı (Repository/ORM) olabilir; bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto` (`Library.Application.DTOs` içinde).

Genel Değerlendirme
- Yalnızca Application katmanından tek bir arayüz görünür; implementasyon sınıfları ve diğer katmanlar (Infrastructure, API) bu dosyadan anlaşılmıyor.
- Hata yönetimi, yetkilendirme ve validasyon kuralları arayüzden anlaşılamaz; ilgili sorumlulukların muhtemelen implementasyon veya üst katmanda tanımlanması beklenir.
- DTO tanımları mevcut ancak içeriği görünmüyor; mapping/validator örüntüleri belirsiz.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alanında müşteri yönetimi için uygulama katmanı sözleşmeleri sağlamak (CRUD ve sorgulama operasyonları).  
Hedef Framework: Bu dosyadan kesinleşmiyor; .NET 6+ tarzı async API’ler kullanılıyor.  
Mimari: Katmanlı/Clean Architecture yaklaşımı. Application katmanı, domain kurallarını yansıtan DTO’lar ve servis sözleşmeleri ile use-case odaklıdır; Infrastructure uygulamaları ve API sunumu bu sözleşmeleri uygular/çağırır.  
Projeler/Assembly’ler:
- Library.Application: Uygulama katmanı; `DTO` ve `Interfaces` içerir.
Harici Paketler: Bu dosyadan görünmüyor.  
Konfigürasyon: Bu dosyadan görünmüyor.

### Architecture Diagram
API/Presentation → Application (Library.Application) → (Interfaces üzerinden) → Infrastructure (Concrete Implementations) → Data Store

---
### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**  
`ICustomerService`, müşteri yönetimi için uygulama katmanı sözleşmesini tanımlar. Müşteri oluşturma, güncelleme, silme ve çeşitli sorgulama operasyonlarını asenkron olarak sunar. Clean Architecture’da Application katmanına aittir ve Infrastructure’daki somut implementasyonlarla gerçekleştirilir.

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
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için müşteri verisini getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri listeler. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Belirtilen müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**  
Interface — davranış tanımı yok. Beklenenler bu dosyadan çıkarılabiliyor:  
- `GetByIdAsync` bulunamadığında `null` dönebilir.  
- `CreateAsync` başarıda oluşturulan `CustomerDto` döndürür.  
- `UpdateAsync` ve `DeleteAsync` yan etkili operasyonlardır; geriye değer döndürmez.  
- `GetActiveCustomersAsync` aktiflik kriterine göre filtreleme yapmalıdır (kriter detayları bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; API controller’ları veya Application içi handler/service katmanları çağırabilir.
- **Aşağı akış:** Harici bağımlılık yok (sadece sözleşme).
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri yok.  
- Listeleme uçları için sayfalama/sıralama sözleşmesi tanımlı değil.  
- Hata durumlarını ifade eden sonuç türleri (ör. Result/OneOf) veya domain-specifik exception sözleşmeleri belirtilmemiş.  

---
Genel Değerlendirme
- Sözleşme, temel CRUD ve sorgulama ihtiyaçlarını kapsıyor ancak operasyonel endişeler (iptal, sayfalama, sıralama, hata modellemesi) eksik.  
- Clean Architecture’a uygun biçimde Application katmanı bağımlılık tersine çevirmeyi sağlıyor; ancak DTO ve interface isimleri dışında domain kuralları görünür değil.  
- Genişleme için öneriler: `CancellationToken` eklenmesi, sayfalama modellerinin tanımlanması, hata/sunum katmanı uyumu için standart sonuç sözleşmesi belirlenmesi.### Project Overview
- Proje adı: Library (namespace’ten çıkarım)
- Amaç: Uygulama katmanında dashboard/özet istatistikleri sunan bir servis sözleşmesi tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari; en azından Application katmanı mevcut. Diğer katmanlar (Domain/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri ve DTO referansları.
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTO referansları)
  ↑ (muhtemel çağıranlar: API/Presentation veya Application içi handler’lar — bu dosyadan net değil)

---

### `Library.Application/Interfaces/IDashboardService.cs`

**1. Genel Bakış**
`IDashboardService`, uygulama genelinde dashboard istatistiklerini asenkron olarak sağlayacak servisler için sözleşmedir. Application katmanına aittir ve üst katmanların (ör. API) istatistik verilerine erişimini soyutlar.

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
| GetStatsAsync | `Task<DashboardStatsDto> GetStatsAsync()` | Dashboard özet istatistiklerini asenkron olarak döndürür. |

**5. Temel Davranışlar ve İş Kuralları**
- Okuma/raporlama amaçlı tek bir operasyon tanımlar.
- Dönüş tipi `DashboardStatsDto` ile istatistiklerin bir DTO olarak taşınacağı belirtilir.
- İptal belirteci veya kapsam parametreleri yok; kapsam ve filtreleme bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor (muhtemel repository/okuma kaynakları).
- **İlişkili tipler:** `DashboardStatsDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametresi bulunmuyor; uzun süren sorgular için iptal desteği düşünülebilir.
- Uygulama kapsamı/filtreleme (tarih aralığı, kullanıcı bağlamı) parametreleri yok; ihtiyaç varsa genişletilmesi gerekir.

---

### Genel Değerlendirme
Kod tabanından yalnızca Application katmanındaki bir servis sözleşmesi görülebiliyor. Mimari bütünlük (Domain, Infrastructure, API), veri erişim stratejisi, hata yönetimi ve konfigürasyon ayrıntıları bu dosyadan çıkarılamıyor. Sözleşmenin yalın tutulması iyi; ancak iptal belirteci ve muhtemel filtreleme parametreleri eklenerek daha sağlam bir kontrat sağlanabilir.### Project Overview
- Proje adı: Library (namespace’ten çıkarım)
- Amaç: Uygulama katmanında e‑posta gönderimi için bir soyutlama sağlayarak altyapıdan bağımsız iş mantığına olanak tanır.
- Hedef çatı/TFM: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli — Application katmanında arayüz tanımları ile altyapı uygulamalarından ayrışma.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; arayüzler ve iş kurallarına yakın sözleşmeler.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces)
  ↑ consumed by
[Diğer katmanlar — bu dosyadan anlaşılmıyor]

---
### `Library.Application/Interfaces/IEmailService.cs`

**1. Genel Bakış**
`IEmailService`, uygulama katmanında e‑posta gönderimine yönelik sözleşmeyi tanımlar. Amaç, e‑posta altyapı ayrıntılarını soyutlayarak üst katmanların bağımlılığını arayüz seviyesinde tutmaktır. Clean/Application katmanına aittir.

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
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | Belirtilen alıcıya konu ve içerik ile e‑posta gönderir; HTML içeriği varsayılan olarak etkindir ve iptal desteği sunar. |

**5. Temel Davranışlar ve İş Kuralları**
- `isHtml` varsayılanı `true`: İçeriğin HTML olarak yorumlanması beklenir.
- `CancellationToken` isteğe bağlıdır ve varsayılan değeri `default`’tur; çağıran iptali tetikleyebilir.
- Gerçek gönderim mekanizması bu arayüzde tanımlanmaz; davranış uygulamaya bırakılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/komut işleyicileri veya servisler bu arayüzü kullanır.
- **Aşağı akış:** Bağımlılık yok (uygulama sınıfları bu arayüzü implemente ederken SMTP/3rd‑party sağlayıcılara bağlanabilir — bu dosyadan anlaşılmıyor).
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Application katmanında bir arayüz görülebiliyor; diğer katmanlar (Domain/Infrastructure/API) bu depodan anlaşılamıyor.
- E‑posta işlemi için doğru şekilde arayüzle soyutlama yapılmış; ancak uygulama (implementation), konfigürasyon anahtarları ve hata yönetimi bu dosyada tanımlı değil.### Project Overview
- Proje adı: Library (adı ve katman adı `Library.Application` ve namespace’lerden çıkarılmıştır)
- Amaç: Kütüphane ceza/fine yönetimi için uygulama katmanında ceza işlemlerine yönelik sözleşme (`IFineService`) tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Bu dosya, Application katmanında arayüz ve DTO referanslarını içeriyor. İş kuralları/akışları Application’da tanımlanır; kalıcı depolama ve dış sistemler Infrastructure’da (bu dosyadan görünmüyor); sunum API/Presentation katmanında (bu dosyadan görünmüyor).
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri (`Interfaces`) ve DTO kullanımı.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application.DTOs <- Library.Application.Interfaces

(“Interfaces” bölümü `DTO` türlerini referanslar. Diğer katman bağımlılıkları bu dosyadan anlaşılmıyor.)

---
### `Library.Application/Interfaces/IFineService.cs`

**1. Genel Bakış**
Kütüphane ceza yönetimi için uygulama katmanında kullanılan servis sözleşmesini tanımlar. Cezaların sorgulanması, oluşturulması, ödenmesi, affedilmesi ve silinmesine yönelik operasyon imzaları içerir. Clean/Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
- Harici bağımlılık yok.
- Not: Yöntem imzaları `Library.Application.DTOs` içindeki `FineDto`, `CreateFineDto`, `PayFineDto`’ları kullanır.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<FineDto?> GetByIdAsync(Guid id)` | Belirli bir cezanın detayını döner; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<FineDto>> GetAllAsync()` | Tüm cezaları listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşteriye ait cezaları listeler. |
| GetPendingFinesAsync | `Task<IEnumerable<FineDto>> GetPendingFinesAsync()` | Ödenmemiş/bekleyen cezaları döner. |
| GetTotalUnpaidByCustomerAsync | `Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)` | Müşterinin toplam ödenmemiş ceza tutarını hesaplar. |
| CreateAsync | `Task<FineDto> CreateAsync(CreateFineDto createDto)` | Yeni ceza oluşturur ve döner. |
| PayFineAsync | `Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)` | Bir cezayı ödeme bilgisiyle işaretler ve güncel halini döner. |
| WaiveFineAsync | `Task WaiveFineAsync(Guid id)` | Belirli cezayı affeder/iptal eder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirli cezayı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımlamaz. İş kuralları ve doğrulamalar implementasyonlarda belirlenir.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Application.DTOs.FineDto`, `CreateFineDto`, `PayFineDto`
- İlişkili tipler: İlgili DTO’lar (adı geçenler); olası implementasyonlar bu dosyadan görünmüyor.

**7. Eksikler ve Gözlemler**
- Arayüz tanımlı; implementasyon dosyası bu repoda görünmüyor.
- İptal/timeout, işlem (transaction) kapsamı, hata yönetimi ve yetkilendirme semantiği imzalardan anlaşılamıyor; implementasyonlara bırakılmış.

---

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanındaki bir servis sözleşmesi görünür durumda. Uçtan uca akışı, veri erişimini, DTO tanımlarını ve API yüzeyini değerlendirmek için ek dosyalar gerekir.
- Mimari yapı Clean/Application merkezli görünüyor; ancak Domain, Infrastructure ve Presentation katmanlarına dair kanıt bu dosyada yoktur.### Proje Genel Bakış
- Proje adı: Library (ad alanlarından çıkarım)
- Amaç: Kütüphane şubelerine yönelik uygulama katmanı sözleşmelerini ve DTO kullanımını tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Uygulama katmanında `Interfaces` ve `DTOs` yer alıyor; uygulama servis sözleşmeleri tanımlanmış.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı: servis arayüzleri ve DTO kullanımı.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Metin tabanlı bağımlılık akışı (sadece görülebilenler):

[Consumers (API/Other Layers)] -> Library.Application (Interfaces, DTOs)

---
### `Library.Application/Interfaces/ILibraryBranchService.cs`

**1. Genel Bakış**
Kütüphane şubelerine ilişkin CRUD ve sorgulama operasyonlarını tanımlayan uygulama servisi arayüzüdür. Uygulama katmanında yer alır ve üst katmanlar (API, UI) tarafından DI üzerinden tüketilecek sözleşmeyi belirler.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
- Harici bağımlılık yok. (Arayüz; yalnızca `Library.Application.DTOs` tiplerini referanslar.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<LibraryBranchDto?> GetByIdAsync(Guid id)` | Belirli şube kimliği ile şube bilgisini getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<LibraryBranchDto>> GetAllAsync()` | Tüm şubeleri listeler. |
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()` | Yalnızca aktif şubeleri listeler. |
| CreateAsync | `Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)` | Yeni şube oluşturur ve oluşturulan şubeyi döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)` | Var olan şubeyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Şubeyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme — davranış tanımı yok; validasyon, hata yönetimi ve filtreleme kuralları implementasyona bırakılmıştır.
- `GetByIdAsync` için bulunamama durumunda `null` dönebilir.
- `CreateAsync` başarıyla oluşturulan `LibraryBranchDto` döndürmeyi vaat eder.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/controller veya uygulama hizmetleri tarafından çağrılır.
- **Aşağı akış:** `Library.Application.DTOs` (`LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`).
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto` (aynı uygulama katmanında DTO’lar).

**7. Eksikler ve Gözlemler**
- Güncelleme/silme işlemlerinde bulunamama senaryolarına ilişkin sözleşmede dönüş modeli/exception davranışı belirtilmemiş; implementasyonlar arası tutarsızlık riski olabilir.
- `UpdateAsync` ve `DeleteAsync` dönüş değeri/veri sonucunu (ör. etkilenen kayıt) belirtmiyor; çağıranlar için başarı durumunu ayırt etmek zor olabilir.

### Genel Değerlendirme
- Kod yalnızca uygulama servis arayüzünü içeriyor; uygulama genelinde Clean Architecture benzeri katmanlaşma işaretleri mevcut ancak diğer katmanlar bu dosyadan görülemiyor.
- Sözleşmede hata modeline dair standart bir yaklaşım (ör. `Result` tipi, domain-specifik exception’lar) tanımlı değil; projede tutarlı hata yönetimi için ek yönergeler gerekebilir.
- DTO’lar referanslanıyor ancak tip tanımları bu girdi setinde görünmüyor; alan adları ve validasyon kuralları belirsiz.### Project Overview
- Proje adı: Library (görünen ad alanına göre). Amaç: Bildirim yönetimi için uygulama katmanında sözleşmeler sağlamak (ör. okuma, oluşturma, okundu işaretleme, silme).
- Hedef framework: Bu dosyadan anlaşılmıyor (C# async/Task kullanımı mevcut).
- Mimari desen: Katmanlı/Temiz Mimari izleri; bu dosya Application katmanında bir servis sözleşmesi sunuyor. Diğer katmanlar bu girdiyle görünmüyor.
- Projeler/assembly’ler: Library.Application — Uygulama katmanı; use-case/service sözleşmeleri ve DTO kullanımı.
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application (Interfaces, DTO kullanımı)
  ↳ Uygulama katmanındaki interface’ler, uygulamada başka katmanlarca (ör. Infrastructure/Presentation) implemente/çağrılır. Diğer katmanlar bu girdiyle görünmüyor.

---
### `Library.Application/Interfaces/INotificationService.cs`

**1. Genel Bakış**
`INotificationService`, müşteri bazlı bildirimlerin sorgulanması, oluşturulması, okunma durumunun yönetimi ve silinmesi için uygulama katmanı sözleşmesini tanımlar. Amaç, bildirimlerle ilgili iş akışlarını arayüz üzerinden soyutlamak ve farklı implementasyonlara olanak tanımaktır. Mimari olarak Application katmanına aittir.

**2. Tip Bilgisi**
- Tip: interface
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)` | Belirtilen müşteriye ait tüm bildirimleri getirir. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)` | Belirtilen müşterinin okunmamış bildirimlerini listeler. |
| GetUnreadCountAsync | `Task<int> GetUnreadCountAsync(Guid customerId)` | Belirtilen müşteri için okunmamış bildirim sayısını döner. |
| CreateAsync | `Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)` | Yeni bir bildirimi oluşturur ve döner. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Belirli bir bildirimi okundu olarak işaretler. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşteriye ait tüm bildirimleri okundu olarak işaretler. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirli bir bildirimi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Interface — davranış yok. DTO odaklı sözleşme: `NotificationDto` döner, oluşturma için `CreateNotificationDto` kabul eder. Asenkron desen (`Task`) kullanır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; Application katmanını kullanan hizmetler/denetleyiciler bu arayüzü çağırır.
- Aşağı akış: Implementasyonlar; veri erişimi ve kalıcılık katmanları (bu dosyadan anlaşılmıyor).
- İlişkili tipler: `NotificationDto`, `CreateNotificationDto` (`Library.Application.DTOs`).

Genel Değerlendirme
- Yalnızca Application katmanındaki bir arayüz görülebiliyor; diğer katmanlar, veri modeli ve altyapı detayları bu girdiyle doğrulanamıyor.
- İptal belirteci (`CancellationToken`) desteği yok; yüksek hacimli/IO operasyonlarında eklenmesi düşünülebilir.
- Hata yönetimi ve yetkilendirme akışları arayüz seviyesinde tanımlanmamış; bunlar genelde implementasyon/üst katmanlarda ele alınır.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki yayıncı (publisher) verilerini yönetmek için uygulama katmanında servis sözleşmeleri tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari, katmanlı/Clean Architecture yaklaşımına işaret ediyor: Application katmanı içinde DTO’lar ve servis arayüzleri tanımlı.

Katmanlar:
- Application: Use case’ler için servis sözleşmeleri, DTO’lar ve iş kuralları (bu dosyada arayüzler ve DTO referansları gözüküyor).
Diğer katmanlar (Domain, Infrastructure, API) bu dosyadan kesin olarak görülemiyor.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı, servis arayüzleri ve DTO sözleşmeleri.

Dış bağımlılıklar: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
[Consumers (API/Presentation)] -> Library.Application (Interfaces, DTOs)
Diğer katman bağımlılıkları bu dosyadan anlaşılmıyor.

---
### `Library.Application/Interfaces/IPublisherService.cs`

**1. Genel Bakış**
`IPublisherService`, yayıncı (publisher) varlıklarına yönelik CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Uygulama katmanında yer alır ve üst katmanların (örn. API) yayıncılarla çalışmasını sağlar.

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
| GetByIdAsync | `Task<PublisherDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için yayıncıyı getirir; bulunamazsa `null` döner. |
| GetAllAsync | `Task<IEnumerable<PublisherDto>> GetAllAsync()` | Tüm yayıncıları döner. |
| GetActivePublishersAsync | `Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()` | Aktif yayıncıları filtreleyip döner. |
| CreateAsync | `Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)` | Yeni yayıncı oluşturur ve oluşturulan kaydı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)` | Mevcut yayıncıyı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Yayıncıyı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Interface — davranış yok. Varsayılanlar bu dosyadan anlaşılmıyor. `GetActivePublishersAsync` aktiflik kriterine göre filtreleme beklentisi oluşturur; kriter tanımı bu dosyada yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağıranlar Controller’lar veya Application hizmetleri.
- **Aşağı akış:** `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto` (mapping ve veri erişimi detayları implementasyonda olacaktır).
- **İlişkili tipler:** `Library.Application.DTOs.PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`.

### Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir servis arayüzünü gösteriyor. Implementasyon sınıfları, veri erişim stratejisi, doğrulama ve hata yönetimi görünmüyor. Mimari desenin Clean Architecture olması muhtemel ancak diğer projeler ve bağımlılıklar bu dosyadan tespit edilemiyor. DTO tanımları da görünmediğinden alan modeli ve doğrulama kuralları belirsiz. Implementasyonlarda yetkilendirme, hata yönetimi ve tutarlı null-handling konularına dikkat edilmesi önerilir.### Project Overview
- Proje Adı: Library (isim uzayından çıkarım)
- Amaç: Personel yönetimi için uygulama katmanında servis sözleşmeleri tanımlamak (personel verisini listeleme, getirme, oluşturma, güncelleme, silme).
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı mimari (N-Tier benzeri) — görünen katman: Application. Uygulama katmanı, alan mantığına yönelik servis kontratlarını ve DTO’ları barındırır. Diğer katmanlar (API/Infrastructure/Domain) bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri (`Interfaces`) ve DTO referansları.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTO referansları)

---

### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (staff) varlığına yönelik asenkron CRUD benzeri operasyonların kontratını tanımlar. Uygulama katmanında yer alır ve personel verisini almak, listelemek, oluşturmak, güncellemek ve silmek için gerekli imzaları sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Sadece DTO tür referansları: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Verilen `id` için personeli döndürür; bulunamazsa `null` dönebilir. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personellerin listesini döndürür. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif personelleri döndürür. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşan personeli döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Belirtilen `id` için personel bilgilerini günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`’deki personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez; asenkron operasyon imzaları tanımlar.
- `GetByIdAsync` null dönebilir; bulunamayan kayıt durumunu ifade eder.
- `GetActiveStaffAsync` aktiflik durumuna göre filtreleme öngörür (kriter ayrıntısı bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`

---

Genel Değerlendirme
- Kod tabanında yalnızca Uygulama katmanındaki bir servis arayüzü görünüyor. Domain, Infrastructure ve API katmanlarına dair bilgi yok.
- Dış bağımlılıklar, hedef framework ve konfigürasyon anahtarları bu veriden çıkarılamıyor.
- `IStaffService` kontratı net ve minimal; DTO türleriyle uyumlu görünüyor. Uygulamada hata yönetimi, validasyon ve yetkilendirme stratejileri bu dosyadan anlaşılamıyor.### Project Overview
- Ad: Library (tahmin edilen çözüm adı; `Library.Application` ve `Library.Domain` namespace’lerinden çıkarım)
- Amaç: Domain `Author` varlığını Application katmanındaki DTO’lara map etmek ve CRUD senaryolarında entity/DTO dönüşümlerini kolaylaştırmak.
- Hedef Framework: Bu dosyadan kesin olarak belirlenemiyor.
- Mimari: Katmanlı/Clean-vari yapı. Application katmanı Domain’e bağımlı; mapping genişletme metodlarıyla sınırdaki dönüşümleri üstleniyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları (`Library.Domain.Entities.Author`)
  - Library.Application — DTO’lar ve mapping’ler (`Library.Application.DTOs`, `Library.Application.Mappings`)
- Harici paketler/çatı: Bu dosyadan görünmüyor.
- Konfigürasyon: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/AuthorMappings.cs`

**1. Genel Bakış**
`Author` entity’si ile `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto` arasında dönüşüm sağlayan extension mapping’leri içerir. Uygulama katmanında entity-DTO ayrımını korur ve oluşturma/güncelleme işlemlerinde tarih/id gibi alanları otomatik set eder. Application katmanına aittir.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static AuthorDto ToDto(this Author author)` | `Author` entity’sini `AuthorDto`’ya map eder; `BookCount` için null güvenli sayım yapar. |
| ToEntity | `public static Author ToEntity(this CreateAuthorDto dto)` | `CreateAuthorDto`’dan yeni `Author` entity’si üretir; `Id` için `Guid.NewGuid()`, `CreatedAt` için `DateTime.UtcNow` atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateAuthorDto dto, Author author)` | Var olan `Author` entity’sinin alanlarını `UpdateAuthorDto` ile günceller; `UpdatedAt` için `DateTime.UtcNow` atar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: Tüm temel alanları bire bir taşır; `BookCount` için `author.Books?.Count ?? 0` kullanır.
- `ToEntity`: Kimlik `Guid.NewGuid()` ile üretilir; `CreatedAt` UTC zamanıyla set edilir; alanlar DTO’dan doldurulur.
- `UpdateEntity`: Tüm güncellenebilir alanlar DTO’dan entity’ye kopyalanır; `UpdatedAt` UTC olarak set edilir; referans `author` nesnesi yerinde (in-place) mutasyona uğrar.
- Validasyon, null-guard veya alan bazlı koşullu güncelleme bu dosyada yoktur; DTO’daki null değerler aynı şekilde entity’ye yazılabilir.

DTO — davranış yok. Default değerler: `BookCount` hesaplanırken null koleksiyonlar 0 kabul edilir; yeni entity’de `Id` ve zaman damgaları otomatik atanır.

**6. Bağlantılar**
- Yukarı akış: Application katmanındaki komut/sorgu işleyicileri, servisler veya controller’lar tarafından doğrudan çağrılır.
- Aşağı akış: `Library.Domain.Entities.Author`, `Library.Application.DTOs.AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`.
- İlişkili tipler: `Author`, `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`.

**7. Eksikler ve Gözlemler**
- Metotlarda `author`/`dto` için null-kontrol yok; null argümanlar `NullReferenceException` doğurabilir.
- `UpdateEntity` tüm alanları koşulsuz yazar; kısmi güncelleme senaryolarında istenmeyen null overwrite riski bulunur.

---
Genel Değerlendirme
- Kod, Clean-vari katman ayrımına uygun olarak mapping’i Application katmanında tutuyor.
- Görünen dosyada harici paket, konfigürasyon veya altyapı bağımlılığı yok.
- Null-guard ve koşullu güncelleme eksikliği, servis katmanında validasyon olmaması halinde runtime hatalarına veya istenmeyen veri kayıplarına neden olabilir.### Project Overview
Proje adı: Library. Amaç: Kütüphane alanındaki `BookCategory` varlıkları için Application katmanında DTO-Entity dönüşümleri sağlamak. Hedef framework bu dosyadan anlaşılmıyor; ancak .NET modern C# uzantı metodları kullanımı görülüyor.

Mimari desen: Katmanlı/Clean Architecture eğilimli. Gözlemlenen katmanlar:
- Domain: `Library.Domain.Entities` — temel varlıklar (`BookCategory`) ve muhtemel alan kuralları.
- Application: `Library.Application` — DTO’lar ve mapping uzantıları; use case’lere hizmet eden dönüştürmeler.

Projeler/assemblies:
- Library.Domain — Domain varlıkları (rol: core model).
- Library.Application — DTO’lar ve mapping (rol: uygulama hizmetleri ve model dönüşümü).

Dış bağımlılıklar: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Domain (Library.Domain)
  ^ 
  |
Application (Library.Application)

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` varlığı ile ilgili DTO’lar (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`) arasında dönüşüm sağlayan uzantı metodlarını içerir. Application katmanında yer alır ve veri alışverişinde tutarlı mapping kuralları sağlar.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri için.
- `Library.Domain.Entities` — `BookCategory` varlığı için.
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` varlığını `BookCategoryDto`'ya dönüştürür. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`'dan yeni bir `BookCategory` varlığı oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Mevcut `BookCategory` varlığını `UpdateBookCategoryDto` değerleriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id` alanı `Guid.NewGuid()` ile otomatik üretilir.
- `ToEntity`: `CreatedAt` alanı `DateTime.UtcNow` olarak atanır.
- `UpdateEntity`: `UpdatedAt` alanı `DateTime.UtcNow` olarak güncellenir.
- DTO alanları (`Name`, `Description`) doğrudan varlığa kopyalanır, ek validasyon uygulanmaz.
- Null kontrolü yapılmaz; null argümanlar durumunda potansiyel `NullReferenceException` riski vardır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor; genelde Application hizmetleri/handler’ları veya API katmanı çağırır.
- **Aşağı akış:** `Library.Domain.Entities.BookCategory`, `Library.Application.DTOs.*`.
- **İlişkili tipler:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- Girdi validasyonu yok; `dto` veya `category` null olabilir.
- Domain kurallarını (ör. `Name` zorunluluğu) enforce eden kontroller bu seviyede bulunmuyor; tasarıma göre başka katmanda olabilir.

---
Genel Değerlendirme
- Kod, Clean/katmanlı mimariyi işaret eden net bir Application-Domain ayrımı içeriyor.
- Mapping mantığı basit ve anlaşılır; ID ve zaman damgalarının merkezi üretimi tutarlılık sağlar.
- Null ve alan validasyonlarının eksikliği, çağıran katmanlarda ele alınmayı gerektirir.
- Dış bağımlılık ve konfigürasyon görünmüyor; proje genelini değerlendirmek için ek dosyalara ihtiyaç var.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kütüphane ödünç alma süreçleri için uygulama katmanında DTO-Entity dönüşümleri sağlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor), C# 10+ uyumlu.  
Mimari: Clean Architecture/N‑Katmanlı yaklaşım. Gözlemlenen katmanlar:
- Domain: `Library.Domain.Entities`, `Library.Domain.Enums` — çekirdek varlıklar ve alan sabitleri.
- Application: `Library.Application.DTOs`, `Library.Application.Mappings` — DTO’lar ve mapping mantığı.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Domain — Domain entity’leri (`BookLoan`) ve enum’lar (`LoanStatus`).
- Library.Application — DTO’lar (`BookLoanDto`, `CreateBookLoanDto`) ve mapping uzantıları.

Dış bağımlılıklar: Bu dosyada harici paket/çatı görülmüyor.  
Konfigürasyon: Bağlantı dizgileri veya app settings anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/BookLoanMappings.cs`

**1. Genel Bakış**  
`BookLoan` entity’si ile `BookLoanDto`/`CreateBookLoanDto` arasında iki yönlü dönüşüm sağlayan mapping uzantıları sunar. Application katmanında, veri alışverişi için entity-DTO ayrımını korur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Entity/DTO referansları: `Library.Application.DTOs`, `Library.Domain.Entities`, `Library.Domain.Enums`)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookLoanDto ToDto(this BookLoan loan)` | `BookLoan` entity’sini gösterim/taşıma için `BookLoanDto`'ya dönüştürür. |
| ToEntity | `public static BookLoan ToEntity(this CreateBookLoanDto dto)` | `CreateBookLoanDto`’dan yeni bir `BookLoan` entity örneği üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`:
  - `BookTitle` ve `BookISBN` için `Book` null ise `string.Empty` kullanır.
  - `CustomerName` için ad-soyadı birleştirir; `Customer` yoksa `string.Empty`.
  - `ProcessedByStaffName` eğer personel yoksa `null` döner (diğer alanlarla farklı default).
  - `IsOverdue`, `Status == LoanStatus.Active` ve `DueDate < DateTime.UtcNow` ise true.
- `ToEntity`:
  - `Id = Guid.NewGuid()` otomatik üretilir.
  - `LoanDate = DateTime.UtcNow`.
  - `DueDate = DateTime.UtcNow.AddDays(dto.LoanDurationDays)`.
  - `Status = LoanStatus.Active`.
  - `RenewalCount = 0`, `MaxRenewals = 2` (sabit).
  - `CreatedAt = DateTime.UtcNow`.
- Zaman hesaplamaları UTC tabanlıdır.

**Mantık içermeyen basit DTO/model'ler için** bu dosyada DTO oluşturma/mapping vardır; ek davranış yok.

**6. Bağlantılar**
- **Yukarı akış:** Extension method olarak Application katmanındaki service/handler/controller benzeri bileşenler tarafından çağrılır (bu dosyadan spesifik çağırıcılar anlaşılmıyor).
- **Aşağı akış:** `BookLoan`, `LoanStatus`, `BookLoanDto`, `CreateBookLoanDto`.
- **İlişkili tipler:** `Library.Domain.Entities.BookLoan`, `Library.Domain.Enums.LoanStatus`, `Library.Application.DTOs.BookLoanDto`, `Library.Application.DTOs.CreateBookLoanDto`.

**7. Eksikler ve Gözlemler**
- `MaxRenewals = 2` magic number; konfigüre edilebilir hale getirilmeli.
- `DateTime.UtcNow`’ın doğrudan kullanımı test edilebilirliği zorlaştırır; saat sağlayıcısı soyutlaması önerilir.
- `LoanDurationDays` için negatif/0 değer validasyonu yok; `DueDate` geçmişe düşebilir.
- `ProcessedByStaffName` için `null`/`string.Empty` kullanımında tutarsızlık (diğer alanlar boş string’e set ediliyor). Tutarlı default belirlenmeli.

---

### Genel Değerlendirme
- Mimari Clean Architecture yönelimli; Application, Domain’a bağımlı ve mapping’ler extension method olarak düzenli.
- Zaman ve sabit değerler için konfigürasyon/soyutlama eksikliği var (test edilebilirlik ve esneklik açısından).
- Validasyon mantığı Application katmanında görünmüyor; oluşturma sırasında iş kuralı doğrulamaları eklenmeli veya ayrı bir validation katmanıyla tamamlanmalı.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” çözümünün bir parçasıdır. Amaç, kütüphane alanındaki `Book` varlığı için Application katmanında DTO-Entity dönüşümleri sağlamaktır. Hedef çerçeve/sürüm bu dosyadan anlaşılamıyor. Mimari, katmanlı (Domain ve Application katmanları) bir yapı izlemektedir: Domain varlıkları (`Library.Domain.Entities`) ve Application DTO’ları ile mapping mantığı (`Library.Application.Mappings`).

Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain varlıkları (`Book`, `Author`, `Publisher`, `BookCategory`, `LibraryBranch`)
- Library.Application — DTO’lar ve mapping uzantıları

Harici paketler: Bu dosyadan anlaşılamıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` varlığı ile ilgili DTO’lar (`BookDto`, `CreateBookDto`, `UpdateBookDto`) arasında çift yönlü mapping sağlayan statik bir uzantı sınıfıdır. Application katmanında yer alır ve Entity-DTO dönüşümünü merkezileştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Statik uzantı metotları; DI ile enjekte edilmez.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` varlığını `BookDto`'ya dönüştürür; ilişkili ad alanlarını okunabilir isimlerle doldurur. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto`'dan yeni bir `Book` varlığı üretir; bazı alanları otomatik atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Mevcut `Book` varlığını `UpdateBookDto` değerleriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`:
  - `AuthorName` null yazar için `string.Empty`; doluysa `"{FirstName} {LastName}"`.
  - `PublisherName`, `BookCategoryName`, `LibraryBranchName` için null-coalescing kullanır.
- `ToEntity`:
  - `Id` otomatik `Guid.NewGuid()` ile üretilir.
  - `IsAvailable = true` varsayılandır.
  - `AvailableCopies = TotalCopies` olarak ayarlanır.
  - `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`:
  - Bütün temel alanları DTO’dan set eder; `UpdatedAt = DateTime.UtcNow`.
  - `AvailableCopies` doğrudan DTO’dan alınır; `TotalCopies` ile tutarlılık kontrolü yapılmaz.
  - `Condition` ve `Price` yalnızca update ile set edilir; create sırasında set edilmez.

**6. Bağlantılar**
- **Yukarı akış:** Application içindeki hizmetler/handler’lar veya controller’lar tarafından doğrudan çağrılır (statik uzantı).
- **Aşağı akış:** `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.
- **İlişkili tipler:** `Book`, `BookDto`, `CreateBookDto`, `UpdateBookDto`, `Author`, `Publisher`, `BookCategory`, `LibraryBranch`.

**7. Eksikler ve Gözlemler**
- `UpdateEntity` için `AvailableCopies <= TotalCopies` ve negatif olmama gibi tutarlılık kontrolleri yok.
- `ToEntity` içinde `Condition` ve `Price` set edilmez; create senaryosunda bu alanlar boş kalabilir (tasarıma bağlı olarak bilinçli olabilir).
- Null navigation property’lerden ad üretiminde farkı yaklaşım: `AuthorName` boş string, diğerleri nullable; tüketiciler için tutarsızlık yaratabilir.

---

Genel Değerlendirme
- Mimari katmanlar en azından Domain ve Application olarak ayrılmış görünüyor; bu iyi bir ayrım. Ancak hedef framework, kullanılan paketler ve diğer katmanlar (Infrastructure/API) bu dosyadan anlaşılamıyor.
- Mapping mantığı merkezi ve okunaklı; fakat update/create tutarlılık kontrolleri (özellikle stok/adet alanları) Application seviyesinde ele alınmalı.
- Null işleme stratejisi (`AuthorName` boş string vs. diğerlerinin null) tutarlı hale getirilmeli.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane rezervasyonları için Application katmanında DTO-Entity dönüşümleri sağlamak.
- Hedef framework: Bu dosyadan kesinleşmiyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Gözlemlenen katmanlar:
  - Domain: `Entities`, `Enums` (iş kuralları ve çekirdek modeller)
  - Application: `DTOs`, `Mappings` (use-case’lere yakın veri aktarımı ve mapleme)
- Keşfedilen projeler/assembly’ler:
  - Library.Application — DTO’lar ve mapleme mantığı
  - Library.Domain — Entity ve Enum’lar (namespace referanslarından anlaşılıyor)
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyada konfigürasyon kullanılmıyor.

### Architecture Diagram
Presentation/API (varsayılan) -> Library.Application -> Library.Domain

---

### `Library.Application/Mappings/BookReservationMappings.cs`

**1. Genel Bakış**
`BookReservation` entity’si ile `BookReservationDto`/`CreateBookReservationDto` arasında çift yönlü mapleme sağlayan statik extension sınıfıdır. Uygulama (Application) katmanında yer alır ve veri sunumu/taşıma için gerekli alanları üretir.

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
| ToDto | `public static BookReservationDto ToDto(this BookReservation reservation)` | `BookReservation` entity’sini güvenli null kontrolleriyle `BookReservationDto`'ya dönüştürür. |
| ToEntity | `public static BookReservation ToEntity(this CreateBookReservationDto dto)` | Oluşturma DTO’sundan yeni bir `BookReservation` entity örneği üretir ve bazı alanları otomatik doldurur. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`:
  - `BookTitle` yoksa `string.Empty`.
  - `CustomerName` null müşteri durumunda `string.Empty`, aksi halde `FirstName LastName` birleşimi.
- `ToEntity`:
  - DTO — entity maplemesi sırasında otomatik değerler atanır:
    - `Id = Guid.NewGuid()`
    - `ReservationDate = DateTime.UtcNow`
    - `ExpiryDate = DateTime.UtcNow.AddDays(3)`
    - `Status = ReservationStatus.Pending`
    - `CreatedAt = DateTime.UtcNow`
  - `Notes` doğrudan DTO’dan alınır.
- Zaman damgaları UTC olarak belirlenir.

**6. Bağlantılar**
- **Yukarı akış:** Statik extension olarak doğrudan çağrılır (ör. Application servisleri/handler’ları); bu dosyadan kesinleşmiyor.
- **Aşağı akış:** `Library.Domain.Entities.BookReservation`, `Library.Domain.Enums.ReservationStatus`, `Library.Application.DTOs.BookReservationDto`, `CreateBookReservationDto`.
- **İlişkili tipler:** `BookReservation`, `BookReservationDto`, `CreateBookReservationDto`, `ReservationStatus`, ayrıca `Book` ve `Customer` navigation alanları.

**7. Eksikler ve Gözlemler**
- `ExpiryDate` için sabit 3 gün iş kuralı kod içine gömülü; konfigüre edilebilir olmaması esneklik kısıtı yaratabilir. 

---

Genel Değerlendirme
- Mimari olarak Application ve Domain katmanları belirgin; Clean Architecture yaklaşımıyla uyumlu.
- Mapleme mantığı sade ve null güvenli. Zaman ve durum varsayılanları tutarlı şekilde atanıyor.
- Sabit iş kuralı (3 gün) konfigürasyona taşınabilir. Dış bağımlılık ve konfigürasyon anahtarları bu dosyadan görünmüyor.### Project Overview
- Proje adı: Library (koddaki `Library.Application` ve `Library.Domain` ad alanlarından çıkarım).
- Amaç: Kitap incelemeleri için Application katmanında DTO-Entity dönüşümlerini sağlamak (mapping uzantıları).
- Hedef çatı: Bu dosyadan anlaşılmıyor (örn. .NET 6/7 belirtilmemiş).
- Mimari: Katmanlı mimari (Application → Domain). Application katmanı DTO’lar ve mapping mantığını içerir; Domain katmanı çekirdek varlıkları içerir.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama mantığı ve DTO/Mapping.
  - Library.Domain — Domain varlıkları (`Entities`).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Mappings, DTOs) --> Library.Domain (Entities)

---
### `Library.Application/Mappings/BookReviewMappings.cs`

**1. Genel Bakış**
`BookReview` domain varlığı ile ilgili DTO’lar (`BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`) arasında dönüşüm yapan extension method’lar sağlar. Application katmanına aittir ve sunum/servis katmanlarının domain nesneleriyle veri alışverişini kolaylaştırır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri.
- `Library.Domain.Entities` — `BookReview` domain varlığı.
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookReviewDto ToDto(this BookReview review)` | `BookReview` varlığını güvenli alan kontrolleriyle `BookReviewDto`’ya map eder. |
| ToEntity | `public static BookReview ToEntity(this CreateBookReviewDto dto)` | `CreateBookReviewDto`’dan yeni `BookReview` varlığı oluşturur ve bazı alanları otomatik üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookReviewDto dto, BookReview review)` | Mevcut `BookReview` üzerinde güncelleme alanlarını uygular. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`:
  - `BookTitle` için `review.Book?.Title ?? string.Empty`.
  - `CustomerName` için müşteri varsa ad+soyad birleştirme, yoksa `string.Empty`.
- `ToEntity`:
  - `Id` için `Guid.NewGuid()` otomatik üretilir.
  - `IsApproved = false` başlangıç değeri.
  - `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity`:
  - `Rating`, `Title`, `Comment` güncellenir.
  - `UpdatedAt = DateTime.UtcNow`.
- DTO — davranış yok. Default değerler bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; genelde Application/Presentation katmanındaki handler/service/controller’lar çağırır.
- **Aşağı akış:** `Library.Domain.Entities.BookReview`, `Library.Application.DTOs.*`.
- **İlişkili tipler:** `BookReview`, `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`.

**7. Eksikler ve Gözlemler**
- `ToEntity` ve `UpdateEntity` içinde `dto` veya `review` için null kontrolü yok; runtime `NullReferenceException` riski.
- `ToDto` müşteri/kitap null durumda boş string döndürüyor; i18n veya placeholder stratejisi belirtilmemiş.
- `IsApproved` başlangıçta sabit `false`; onay akışı bu dosyadan anlaşılmıyor (iş kuralı belgelendirilmeli). 

---
Genel Değerlendirme
- Katmanlı yapı net: Application katmanı Domain varlıklarını DTO’lara map ediyor. Yine de hedef framework, kullanılan paketler ve diğer katmanlar (Infrastructure, API) bu dosyadan anlaşılamıyor.
- Mapping’lerde otomatik alan üretimi (Id, CreatedAt, UpdatedAt) tutarlı, ancak null kontrolleri ve olası doğrulama eksikleri dikkat çekiyor.
- Onay/denetim akışı (`IsApproved`) dışarıda yönetiliyor; bu davranışın merkezi bir politika ile desteklenmesi önerilir.### Proje Genel Bakış
- Proje adı: Library
- Amaç: `Domain` katmanındaki `Customer` varlıkları ile `Application` katmanındaki DTO’lar arasında mapping sağlayarak müşteri oluşturma, güncelleme ve görüntüleme akışlarını desteklemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli yapı. Domain (iş kuralları ve varlıklar) ve Application (DTO’lar, mapping ve muhtemel iş akışları) katmanları gözlemleniyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Varlıklar (`Customer`) ve enum’lar (`MembershipType`).
  - Library.Application — DTO’lar ve mapping uzantıları.
- Kullanılan ana paketler/çerçeveler: Bu dosyadan anlaşılmıyor (harici paket referansı görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application -> Library.Domain

---

### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` varlığını `CustomerDto`’ya dönüştüren ve `CreateCustomerDto`/`UpdateCustomerDto` ile varlık oluşturma/güncelleme işlemlerini yapan statik mapping uzantılarıdır. Application katmanına aittir ve DTO-Entity dönüşümlerindeki iş kurallarını merkezileştirir.

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
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` varlığını `CustomerDto`'ya map eder. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`'dan yeni `Customer` varlığı oluşturur ve bazı alanları otomatik üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` üzerinde güncellemeleri uygular. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde:
  - `Id = Guid.NewGuid()` otomatik atanır.
  - `MembershipNumber` formatı: `LIB-` + 8 karakterlik büyük harf GUID parçası.
  - `RegisteredDate = DateTime.UtcNow`, `MembershipExpiryDate = UtcNow + 1 yıl`.
  - `IsActive = true` varsayılan.
  - `MaxBooksAllowed` `MembershipType`’a göre atanır:
    - `Premium = 10`, `Standard = 7`, `Student = 5`, `Senior = 7`, diğer = 5.
  - `CreatedAt = DateTime.UtcNow`.
- `UpdateEntity` içinde:
  - Temel iletişim/adres alanları ve `MembershipType`, `IsActive` güncellenir.
  - `UpdatedAt = DateTime.UtcNow` atanır.
- `ToDto` tüm temel alanları doğrudan map eder; `PostalCode`, `DateOfBirth`, `CreatedAt`, `UpdatedAt` DTO’ya taşınmaz (DTO’da yok).

**6. Bağlantılar**
- Yukarı akış: Çağıranlar bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Entities.Customer`, `Library.Application.DTOs.CreateCustomerDto`, `UpdateCustomerDto`, `CustomerDto`, `Library.Domain.Enums.MembershipType`.
- İlişkili tipler: `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `MembershipType`.

**7. Eksikler ve Gözlemler**
- `ToDto`’da `PostalCode`, `DateOfBirth`, `CreatedAt`, `UpdatedAt` gibi varlık alanları DTO’ya map edilmiyor; bu, DTO tasarım tercihiyse sorun değil, aksi halde bilgi kaybı olabilir.
- `ToEntity`/`UpdateEntity` içinde input validasyonu yok; geçersiz değerler üst katmanda doğrulanmalıdır.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane yönetiminde ceza (fine) nesnelerinin Domain ile Application katmanı arasında DTO-Entity dönüşümünü sağlamak.
- Hedef Framework: .NET (sürüm bu dosyadan anlaşılmıyor).
- Mimari Desen: Clean Architecture/N‑Tier tarzı ayrım. Katmanlar:
  - Domain: `Entities`, `Enums` (iş kuralları ve çekirdek modeller).
  - Application: `DTOs`, `Mappings` (use case’ler, mapleme ve orkestrasyon).
- Keşfedilen Projeler/Assembly’ler:
  - Library.Domain — Entity ve enum tanımları.
  - Library.Application — DTO’lar ve mapleme mantığı.
- Kullanılan Dış Paketler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Mappings, DTOs)
  ↓
Library.Domain (Entities, Enums)

---
### `Library.Application/Mappings/FineMappings.cs`

**1. Genel Bakış**
`Fine` ile `FineDto`/`CreateFineDto` arasında iki yönlü dönüşüm sağlayan extension metotlarını içerir. Application katmanında, Domain varlıklarını API’ye/uygulama yüzeyine uygun DTO’lara maplemek ve create senaryosunda DTO’dan yeni `Fine` entity’si üretmek için kullanılır.

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
| ToDto | `public static FineDto ToDto(this Fine fine)` | `Fine` entity’sini sunum için `FineDto`’ya dönüştürür. |
| ToEntity | `public static Fine ToEntity(this CreateFineDto dto)` | `CreateFineDto`’dan yeni bir `Fine` entity örneği oluşturur. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`:
  - `CustomerName` null müşteride `string.Empty`.
  - `BookTitle` null ilişkilerde `string.Empty`.
  - Diğer alanlar doğrudan entity’den aktarılır.
- `ToEntity`:
  - `Id` otomatik `Guid.NewGuid()` ile üretilir.
  - `Status` varsayılan `FineStatus.Pending`.
  - `CreatedAt` `DateTime.UtcNow` ile atanır.
  - `BookLoanId`, `CustomerId`, `Amount`, `Reason` DTO’dan alınır.

DTO — davranış yok. Default değerler: `CustomerName` ve `BookTitle` mapleme sırasında boş string olabilir.

**6. Bağlantılar**
- **Yukarı akış:** Application katmanındaki service/handler’lar, controller’lar bu extension’ları çağırır.
- **Aşağı akış:** `Library.Domain.Entities.Fine`, `Library.Domain.Enums.FineStatus`, `Library.Application.DTOs.FineDto`, `Library.Application.DTOs.CreateFineDto`.
- **İlişkili tipler:** `Fine`, `FineDto`, `CreateFineDto`, `FineStatus`.

**7. Eksikler ve Gözlemler**
- Kimlik üretimi (`Guid.NewGuid()`) ve `CreatedAt`’in mapper içinde set edilmesi, kimlik/denetimli alanların Domain/Infrastructure yerine Application’da belirlenmesine yol açar; veri kaynağı (DB) veya Domain kurallarıyla çakışma riski olabilir. Zaman kaynağı için saat bağımlılığı soyutlanabilir. 

---
Genel Değerlendirme
- Mimari ayrım net: Application ve Domain katmanları görünüyor; mapleme extension’ları Application’da konumlanmış.
- Mapleme içinde ID ve zaman damgası üretimi, sorumlulukların Domain/Infrastructure’a kaydırılması veya merkezi bir factory/time provider kullanımıyla iyileştirilebilir.
- Hedef framework, dış paketler ve konfigürasyon bu koddan çıkarılamıyor; proje genelinde dokümantasyon veya bağımlılık dosyaları (csproj) üzerinden tamamlanmalı.### Project Overview
- Proje adı: Library (koddan çıkarım). Amaç: Kütüphane şubesi varlıklarını DTO’lara maplemek ve CRUD akışlarında entity/DTO dönüşümlerini sağlamak. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture eğilimi. Katmanlar:
  - Domain: Temel varlıklar ve iş kuralları (ör. `Library.Domain.Entities.LibraryBranch`).
  - Application: DTO’lar ve mapping mantığı (ör. `Library.Application.DTOs`, `Library.Application.Mappings`).
- Projeler/Assembly’ler:
  - Library.Domain — Varlıklar ve alan modeli.
  - Library.Application — DTO’lar ve mapleme uzantıları.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Application (Library.Application) --> Domain (Library.Domain)

---
### `Library.Application/Mappings/LibraryBranchMappings.cs`

**1. Genel Bakış**
`LibraryBranch` entity’si ile ilgili DTO’lar (`CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `LibraryBranchDto`) arasında mapleme sağlayan statik uzantı metotlarını içerir. Application katmanında, veri aktarımı ve command/query işlemlerinde dönüşüm sorumluluğunu üstlenir.

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
| ToDto | `public static LibraryBranchDto ToDto(this LibraryBranch branch)` | `LibraryBranch` entity’sini `LibraryBranchDto`’ya dönüştürür; koleksiyon sayımlarını güvenli şekilde hesaplar. |
| ToEntity | `public static LibraryBranch ToEntity(this CreateLibraryBranchDto dto)` | `CreateLibraryBranchDto`’dan yeni `LibraryBranch` entity örneği oluşturur; kimlik ve zaman damgasını üretir, `IsActive`’i true yapar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateLibraryBranchDto dto, LibraryBranch branch)` | Var olan `LibraryBranch` entity’sini `UpdateLibraryBranchDto` değerleriyle günceller ve `UpdatedAt`’i ayarlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `StaffCount` ve `BookCount` için null koleksiyonlara karşı `?.Count ?? 0` kullanır.
- `ToEntity`: 
  - `Id` için `Guid.NewGuid()` üretir.
  - `IsActive` varsayılanı `true` olarak set edilir.
  - `CreatedAt` için `DateTime.UtcNow` kullanılır.
- `UpdateEntity`:
  - Alanları DTO’dan entity’ye kopyalar.
  - `UpdatedAt` için `DateTime.UtcNow` kullanır.
- Doğrulama veya iş kuralı kontrolü bu sınıfta yapılmıyor; yalnızca alan eşlemesi var.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genellikle Application servisleri/handler’ları tarafından çağrılır).
- **Aşağı akış:** `Library.Domain.Entities.LibraryBranch`, `Library.Application.DTOs.CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `LibraryBranchDto`.
- **İlişkili tipler:** `LibraryBranch`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `LibraryBranchDto`.

**7. Eksikler ve Gözlemler**
- `ToDto`, `ToEntity` ve özellikle `UpdateEntity` için null parametre kontrolleri yok; null argüman durumunda `NullReferenceException` riski mevcut.
- `ToEntity` içinde `IsActive`’in zorla `true` yapılması, dışarıdan gönderilen bir isActive bilgisi varsa göz ardı edilmesine yol açabilir; bu bir tasarım tercihi ise belgelenmeli.

---
### Genel Değerlendirme
Kod, Application katmanında sade ve odaklı mapping fonksiyonları sağlar ve Clean Architecture düzenine uygundur. Varsayılan değer üretimi (ID, zaman damgaları, `IsActive`) tutarlı. Ancak null argüman kontrollerinin eksikliği potansiyel hatalara yol açabilir; `ArgumentNullException` kontrolleri eklenmesi önerilir. Ayrıca mapping sorumluluğu dışında doğrulama yapılmaması doğru; ancak doğrulamanın nerede konumlandığı (ör. Application servisleri/validator’lar) proje genelinde netleştirilmeli. Harici paketler ve hedef framework bu dosyadan belirlenemiyor; çözümün diğer katmanlarıyla bütünlük kontrolü önerilir.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Bildirim varlıklarını (`Notification`) DTO’lara ve istek modellerine (ör. `CreateNotificationDto`) dönüştürmek için mapping yardımcıları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı Mimari
  - Domain: `Library.Domain.Entities` altında çekirdek varlıklar (ör. `Notification`).
  - Application: `Library.Application` altında DTO’lar ve mapping mantığı (bu dosya).
  - Diğer katmanlar: Bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain varlıkları.
  - Library.Application — Uygulama katmanı, DTO’lar ve mapping.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/NotificationMappings.cs`

**1. Genel Bakış**
`Notification` varlıkları ile `NotificationDto` ve `CreateNotificationDto` arasında dönüşüm sağlayan extension mapping yardımcı sınıfıdır. Uygulama (Application) katmanında, veri alışverişini ve katmanlar arası ayrımı kolaylaştırmak amacıyla kullanılır.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static NotificationDto ToDto(this Notification notification)` | `Notification` varlığını `NotificationDto`’ya dönüştürür. |
| ToEntity | `public static Notification ToEntity(this CreateNotificationDto dto)` | `CreateNotificationDto` bilgisinden yeni bir `Notification` varlığı üretir. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `Notification` alanlarını olduğu gibi `NotificationDto`’ya kopyalar; `Id`, `CustomerId`, `Title`, `Message`, `Type`, `IsRead`, `ReadAt`, `CreatedAt`.
- `ToEntity`:
  - `Id` için `Guid.NewGuid()` üretir.
  - `IsRead` alanını varsayılan olarak `false` ayarlar.
  - `SentAt` ve `CreatedAt` alanlarını `DateTime.UtcNow` ile set eder.
  - `CustomerId`, `Title`, `Message`, `Type` alanlarını DTO’dan alır.
- Zaman damgaları UTC olarak atanır; bu, zaman uyumluluğu için bilinçli bir tercihtir.

**6. Bağlantılar**
- Yukarı akış: Application katmanındaki komut/handler/servisler veya controller’lar bu mapping’i çağırır (bu dosyadan net çağırıcılar anlaşılmıyor).
- Aşağı akış: `Library.Domain.Entities.Notification`, `Library.Application.DTOs.NotificationDto`, `Library.Application.DTOs.CreateNotificationDto`.
- İlişkili tipler: `Notification`, `NotificationDto`, `CreateNotificationDto`.

**7. Eksikler ve Gözlemler**
- `ToEntity` içinde `CreateNotificationDto` validasyonu yapılmıyor; null veya zorunlu alan kontrolleri (ör. `Title`, `Message`, `CustomerId`) dışarıya bırakılmış görünüyor. Katman genelinde beklenen validasyon stratejisi belirtilmemiş.

---
### Genel Değerlendirme
- Katmanlı ayrım net: Application mapping, Domain varlıklarıyla çalışıyor. Ancak proje genel yapısı, hedef framework, konfigürasyon ve dış bağımlılıklar bu dosyadan görülemiyor.
- Mapping kuralları açık ve tutarlı; ID ve zaman damgalarının otomatik üretilmesi iyi bir pratik. Buna karşın input validasyonu mapping içinde değil; bu sorumluluğun nerede ele alındığı (DTO seviyesinde anotasyonlar, Application servisleri veya handler’lar) koddan anlaşılamıyor.
- Genişleme için öneri: Ters mapping’ler, null guard’lar ve olası `Type` dönüşümleri için koruyucu kontroller eklenebilir.### Project Overview
- Proje adı: Library (koddan çıkarım)
- Amaç: Yayınevi (`Publisher`) varlıklarını Application katmanındaki DTO’lara map etmek ve oluşturma/güncelleme senaryolarında entity-DTO dönüşümlerini sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture eğilimi. Application katmanı Domain varlıklarına referans verir; mapping extension’ları Application’da konumlanmış.
- Projeler/Assembly’ler:
  - Library.Domain — Temel domain varlıkları (ör. `Publisher`)
  - Library.Application — DTO’lar ve mapping mantığı (ör. `PublisherMappings`)
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor (paket kullanımı görünmüyor).
- Konfigürasyon: Bu dosyadan anlaşılmıyor (connection string veya appSettings anahtarı yok).

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/PublisherMappings.cs`

**1. Genel Bakış**
`Publisher` entity’si ile Application DTO’ları (`PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`) arasında dönüşüm sağlayan extension metodlarını içerir. Clean Architecture’da Application katmanında yer alır ve entity-DTO sınırını korur.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static PublisherDto ToDto(this Publisher publisher)` | `Publisher` entity’sini okunabilir `PublisherDto`’ya dönüştürür. |
| ToEntity | `public static Publisher ToEntity(this CreatePublisherDto dto)` | `CreatePublisherDto`’dan yeni bir `Publisher` entity’si oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdatePublisherDto dto, Publisher publisher)` | Var olan `Publisher` entity’sini `UpdatePublisherDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `BookCount` değeri `publisher.Books?.Count ?? 0` ile hesaplanır (null güvenli).
- `ToEntity`:
  - `Id` `Guid.NewGuid()` ile otomatik üretilir.
  - `IsActive` varsayılan olarak `true` atanır.
  - `CreatedAt` `DateTime.UtcNow` olarak set edilir.
- `UpdateEntity`:
  - Tüm temel alanlar DTO’dan entity’ye kopyalanır.
  - `UpdatedAt` `DateTime.UtcNow` olarak set edilir.
- Validasyon veya null kontrolü metod içinde yapılmaz; DTO ve entity’nin geçerli olduğu varsayılır.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Entities.Publisher`, `Library.Application.DTOs.PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`
- İlişkili tipler: `Publisher`, `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`

**7. Eksikler ve Gözlemler**
- `DateTime.UtcNow` ve `Guid.NewGuid()` üretimi doğrudan metodlarda; saat/ID üretimi soyutlanmadığı için test edilebilirlik azalabilir.
- `ToEntity` ve `UpdateEntity` içinde null kontrolü yok; `dto` veya `publisher` null ise `NullReferenceException` oluşabilir.
- `IsActive`’in create senaryosunda sabit `true` atanması iş kuralı olarak doğru olmayabilir; dışarıdan kontrol gerektirebilir.

---
Genel Değerlendirme
- Clean Architecture çizgisi belirgin: Application, Domain’a bağımlı; mapping extension’ları Application’da konumlanmış.
- Test edilebilirlik için zaman/ID üretimi ve mapping null kontrolleri soyutlanabilir veya guard clause eklenebilir.
- Yalnızca mapping dosyası görülebildi; API, Infrastructure ve Persistence katmanları veya paket bağımlılıkları bu bağlamdan anlaşılamıyor.### Project Overview
Proje adı: Library (çıkarım: `Library.*` ad alanları). Amaç: Uygulama katmanında personel (`Staff`) varlıkları ile DTO’lar arasında mapleme sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Katmanlı mimari (Application → Domain). Application katmanı DTO ve mapleme mantığını içerirken, Domain katmanı temel varlıkları barındırır. Keşfedilen projeler/assembly’ler:
- Library.Application — DTO’lar ve mapleme yardımcıları.
- Library.Domain — Varlıklar (`Entities`).
Harici paketler: Bu dosyadan anlaşılmıyor. Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` varlıkları ile `StaffDto`/`CreateStaffDto`/`UpdateStaffDto` arasındaki dönüşümleri yöneten mapleme yardımcılarıdır. Application katmanında yer alır ve veri alışverişinde katmanlar arası ayrışmayı sağlar.

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
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` varlığını `StaffDto`’ya projekte eder. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni bir `Staff` varlığı oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Var olan `Staff` varlığını `UpdateStaffDto` bilgileriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `LibraryBranchName`, `staff.LibraryBranch?.Name` ile doldurulur; `LibraryBranch` null ise isim de null olur.
- `ToEntity`:
  - `Id` otomatik `Guid.NewGuid()` ile üretilir.
  - `EmployeeNumber` otomatik: `"EMP-" + Guid.NewGuid().ToString("N")[..6].ToUpper()`.
  - `IsActive` varsayılan `true`.
  - `CreatedAt` `DateTime.UtcNow` olarak atanır.
- `UpdateEntity`:
  - Alanlar DTO’dan kopyalanır; `UpdatedAt` `DateTime.UtcNow` olarak güncellenir.
- Açık validasyon veya hata fırlatma yok; null/format kontrolleri bu dosyada yapılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenmez; Application katmanı içinde servis/handler/controller mantıkları tarafından çağrılması beklenir (bu dosyadan net değil).
- **Aşağı akış:** `Library.Domain.Entities.Staff`, `Library.Application.DTOs.*`.
- **İlişkili tipler:** `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `LibraryBranch`.

**7. Eksikler ve Gözlemler**
- Mapleme sırasında alan validasyonu yapılmıyor; yanlış/eksik veri için koruma yok.
- `EmployeeNumber` üretimi deterministik değil; benzersizlik kontrolü yapılmıyor (iş kurallarına göre gerekebilir).

---
Genel Değerlendirme
- Mimari katmanlar arası yön doğru: Application, Domain’e bağımlı. Sadece mapleme kodu görüldüğü için geniş resim sınırlı.
- Mapleme kuralları açık ve tutarlı; oluşturma ve güncellemede zaman damgaları ile aktiflik/numara üretimi net.
- Validasyon, hata yönetimi ve benzersizlik/iş kuralı kontrolleri Application veya Domain’de başka yerlerde olmalı; bu dosyada bulunmuyor.### Project Overview
- Ad: Library (varsayılan adlandırma ve namespace’lerden çıkarım)
- Amaç: Yazar (Author) yönetimi için uygulama katmanında iş mantığını sağlamak; CRUD ve arama işlemleri yapıp DTO dönüşümleri gerçekleştirmek.
- Hedef Çerçeve: .NET (C# async/Task kullanımı; spesifik sürüm bu dosyadan anlaşılmıyor).
- Mimari: Clean Architecture benzeri katmanlı yapı.
  - Domain: `IAuthorRepository`, `Domain.Entities.Author` gibi çekirdek model ve repository sözleşmeleri.
  - Application: `AuthorService`, DTO’lar ve mapping uzantıları ile iş mantığı ve koordinasyon.
- Projeler/Assembly’ler:
  - Library.Domain — Alan modeli ve repository arayüzleri (çıkarım: `Library.Domain.Interfaces`).
  - Library.Application — Uygulama hizmetleri, DTO’lar, mapping ve özel exception’lar.
- Dış Bağımlılıklar: Bu dosyadan üçüncü parti paket görünmüyor.
- Konfigürasyon: Bu dosyada konfigürasyon gereksinimi görünmüyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Services/AuthorService.cs`

**1. Genel Bakış**
`AuthorService`, yazarlarla ilgili CRUD ve arama operasyonlarını yürüten uygulama katmanı servisidir. Domain katmanındaki `IAuthorRepository` ile çalışır, entity-DTO dönüşümlerini mapping uzantılarıyla gerçekleştirir ve bulunamayan kayıtlar için `NotFoundException` fırlatır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IAuthorService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IAuthorRepository` — Yazar verilerine erişim ve kalıcılık işlemleri için repository arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public AuthorService(IAuthorRepository authorRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<AuthorDto?> GetByIdAsync(Guid id)` | İlgili yazarı (kitaplarıyla birlikte) getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `public Task<IEnumerable<AuthorDto>> GetAllAsync()` | Tüm yazarları listeler ve DTO’ya dönüştürür. |
| SearchAsync | `public Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)` | Arama terimine göre yazarları filtreleyip DTO’ya dönüştürür. |
| CreateAsync | `public Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)` | Yeni yazar oluşturur, kaydeder ve DTO döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)` | Mevcut yazarı bulur, DTO’dan entity’e alan günceller ve kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Yazarın varlığını doğrular ve siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByIdAsync` domain repo üzerinden ilişkili kitapları içerecek şekilde getirir (`GetWithBooksAsync`) ve `ToDto()` ile map eder.
- Listeleme ve arama sonuçları `Select(a => a.ToDto())` ile DTO’ya dönüştürülür.
- Oluşturma: `CreateAuthorDto.ToEntity()` ile entity oluşturulur; `AddAsync` sonrası `ToDto()` döner.
- Güncelleme: Yazar yoksa `NotFoundException` fırlatılır; `UpdateAuthorDto.UpdateEntity(author)` ile alan günceller, sonra `UpdateAsync`.
- Silme: Varlık kontrolü `ExistsAsync`; yoksa `NotFoundException`, varsa `DeleteAsync`.
- DTO — mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`) üzerinden dönüşüm mantığı bu sınıf dışında konumlanmıştır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; `IAuthorService` tüketen application/presentation katmanı bileşenleri.
- Aşağı akış: `IAuthorRepository`, mapping uzantıları (`Library.Application.Mappings`), `NotFoundException`.
- İlişkili tipler: `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`, `Domain.Entities.Author`, `IAuthorService`, `IAuthorRepository`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok.
- Girdi validasyonu (ör. `searchTerm` boşluğu, DTO alan doğrulamaları) servis seviyesinde görünmüyor; hatalı girişler repo/alt katmana sarkabilir.

---

Genel Değerlendirme
- Uygulama katmanı, repository ve mapping uzantıları ile temiz ayrışmış; Clean Architecture ilkelerine uyumlu.
- Hata yönetiminde bulunamayan kaynaklar için tutarlı `NotFoundException` kullanımı var.
- İyileştirme fırsatları: `CancellationToken` yaygınlaştırılması, servis katmanında temel validasyonların eklenmesi ve olası transaction/işlem sınırlarının belirginleştirilmesi (özellikle birden fazla değişiklik gerektiren senaryolarda).### Project Overview
- Proje adı: Library
- Amaç: Kitap kategorileri için uygulama katmanı hizmetlerini sunmak (CRUD ve sorgulama), domain repository’leri üzerinden çalışmak ve DTO–Entity dönüşümleri sağlamak.
- Hedef framework: .NET (sürüm bu dosyadan anlaşılmıyor)
- Mimari desen: Clean Architecture benzeri katmanlı yapı
  - Domain: `Library.Domain` — Entity’ler ve repository sözleşmeleri.
  - Application: `Library.Application` — DTO’lar, servisler, mapping ve özel exception’lar.
  - (Varsayılan başka katmanlar bu dosyadan anlaşılmıyor: Infrastructure, API/Presentation)
- Projeler/Assembly’ler:
  - `Library.Application` — Uygulama hizmetleri, DTO’lar, mapping, exception’lar.
  - `Library.Domain` — Domain sözleşmeleri (`IBookCategoryRepository`) ve entity referansları.
- Dış bağımlılıklar: Bu dosyada doğrudan harici paket görünmüyor.
- Konfigürasyon: Bağlantı dizesi veya app settings anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Presentation/API (belirsiz) -> Library.Application -> Library.Domain
Library.Application.Mappings -> Library.Domain.Entities
Library.Application.Common.Exceptions -> (uygulama içinde kullanılır)

---
### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD ve listeleme işlemlerini sunan uygulama katmanı servisidir. Domain katmanındaki `IBookCategoryRepository` üzerinden çalışır, DTO–Entity dönüşümleri için mapping uzantılarını kullanır. Clean Architecture’da Application katmanına aittir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookCategoryService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori varlıklarına yönelik veri erişim sözleşmesi (getir, ekle, güncelle, sil, varlık kontrolü).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Id ile kategoriyi getirir, DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri listeler, DTO’ya map eder. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | İsim benzersizliği kontrolü sonrası yeni kategori oluşturur. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Mevcut kategoriyi bulup DTO’dan entity’e günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Var olan kategoriyi siler; yoksa hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByNameAsync` ile isim tekilliği kontrolü yapar; mevcutsa `ConflictException` fırlatır.
- `UpdateAsync`: `GetByIdAsync` sonucu yoksa `NotFoundException` fırlatır; `UpdateEntity` ile alanları günceller.
- `DeleteAsync`: `ExistsAsync` ile varlık kontrolü yapar; yoksa `NotFoundException` fırlatır.
- DTO–Entity dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantıları ile yönetilir.
- Dönüş tipleri asenkron `Task` kullanır; transaction veya unit of work davranışı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; muhtemel çağırıcılar Application/Presentation katmanı bileşenleri (bu dosyadan tam olarak anlaşılmıyor).
- Aşağı akış: `IBookCategoryRepository`
- İlişkili tipler: `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `ConflictException`, `NotFoundException`, `Domain.Entities.BookCategory`, mapping uzantıları (`Library.Application.Mappings`).

**7. Eksikler ve Gözlemler**
- `CreateAsync` için isim tekilliği var; `UpdateAsync` sırasında isim değişikliği durumunda tekillik kontrolü yapılmıyor olabilir (bu servis içinde uygulanmamış).

### Genel Değerlendirme
- Katmanlar arası ayrım net: Application servis, Domain repository sözleşmesine dayanıyor ve DTO/mapping ile çalışıyor.
- Hata yönetimi iş kuralları açısından yeterli görünüyor (bulunamadı/çakışma). Güncellemede isim tekilliğinin doğrulanması gerekebilir.
- Dış paket/altyapı katmanı görünmediğinden veri kalıcılığı, transaction ve logging stratejileri bu koddan anlaşılamıyor.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane ödünç verme süreçlerini (ödünç oluşturma, iade, uzatma, listeleme/filtreleme) yönetmek için uygulama katmanı servisleri ve DTO/mapping altyapısını sağlamak.
- Hedef framework: Bu dosyadan anlaşılamıyor.
- Mimari desen: Clean Architecture/N‑Katmanlı; Application katmanı domain kurallarını uygular ve repository arayüzleriyle çalışır, Domain katmanı entity/enumeration ve repository sözleşmelerini içerir.
- Keşfedilen projeler/assembly:
  - Library.Application — Uygulama servisleri, DTO’lar, mapping uzantıları, application-level exception tipleri.
  - Library.Domain — Domain entity’leri, `Enums`, `Interfaces` (repository sözleşmeleri).
- Kullanılan dış paket/çatı: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---

### `Library.Application/Services/BookLoanService.cs`

**1. Genel Bakış**
`BookLoanService`, ödünç alma yaşam döngüsünü yönetir: oluşturma, iade, uzatma ve çeşitli sorgular. Uygulama katmanında yer alır ve domain kurallarını repository arayüzleri üzerinden uygular, DTO ve mappinglerle dış katmanlara veri döndürür.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IBookLoanService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookLoanRepository` — Ödünç işlemlerinin kalıcı katman erişimi ve sorguları.
- `IBookRepository` — Kitap stok bilgisi güncelleme ve sorgulama.
- `ICustomerRepository` — Müşteri durum ve limit doğrulamaları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookLoanService(IBookLoanRepository loanRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)` | Repository bağımlılıklarını alır. |
| GetByIdAsync | `Task<BookLoanDto?> GetByIdAsync(Guid id)` | İlgili ödünç kaydını detaylarıyla getirir. |
| GetAllAsync | `Task<IEnumerable<BookLoanDto>> GetAllAsync()` | Tüm ödünç kayıtlarını listeler. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye göre ödünçleri listeler. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()` | Aktif ödünçleri döndürür. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()` | Gecikmiş ödünçleri döndürür. |
| GetByStatusAsync | `Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)` | Duruma göre ödünçleri döndürür. |
| CreateAsync | `Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)` | İş kuralları doğrultusunda yeni ödünç oluşturur ve kitap stokunu günceller. |
| ReturnBookAsync | `Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)` | İade işlemini yapar, statüyü günceller ve kitap stokunu artırır. |
| RenewLoanAsync | `Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)` | Aktif ödünç için vade uzatma (yenileme) yapar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Ödünç kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`:
  - Kitap mevcut değilse `NotFoundException` fırlatır.
  - `book.AvailableCopies <= 0` ise `BadRequestException`.
  - Müşteri yoksa `NotFoundException`; aktif değilse `BadRequestException`.
  - Aktif ödünç sayısı `customer.MaxBooksAllowed` sınırını aşarsa `BadRequestException`.
  - Başarılı oluşturma sonrası `book.AvailableCopies--`; 0 ise `book.IsAvailable = false` yapılır.
- `ReturnBookAsync`:
  - Ödünç yoksa `NotFoundException`.
  - Statü `Active` veya `Overdue` değilse `BadRequestException`.
  - `ReturnDate` ve `UpdatedAt` UTC olarak ayarlanır; statü `Returned`.
  - İlgili kitap bulunursa `AvailableCopies++` ve `IsAvailable = true`.
- `RenewLoanAsync`:
  - Ödünç yoksa `NotFoundException`.
  - Yalnızca `Active` statüde yenileme yapılır; değilse `BadRequestException`.
  - `RenewalCount >= MaxRenewals` ise `BadRequestException`.
  - `DueDate` `AdditionalDays` kadar uzatılır; `RenewalCount++`.
- `DeleteAsync`:
  - Kayıt yoksa `NotFoundException`; varsa siler.
- Tüm sorgu metotları entity’leri `ToDto()` ile DTO’ya map eder.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/Controller veya Application orchestrator’ları çağırır.
- **Aşağı akış:** `IBookLoanRepository`, `IBookRepository`, `ICustomerRepository`, mapping uzantıları (`ToDto()`, `ToEntity()`).
- **İlişkili tipler:** `CreateBookLoanDto`, `BookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`, `LoanStatus`, `Domain.Entities.Book`, `Domain.Entities.Customer`, `Domain.Entities.BookLoan`, `NotFoundException`, `BadRequestException`.

**7. Eksikler ve Gözlemler**
- İşlemler çok adımlı güncellemeler içeriyor (ödünç oluşturma/iade sırasında hem loan hem book güncelleniyor) ancak transaction/atomicity yönetimi görünmüyor; veri tutarsızlığı riski olabilir.
- `DeleteAsync` aktif bir ödünç kaydını silerse kitap stokunun düzeltilmesi ele alınmıyor; iş kuralı net değil.
- `RenewLoanAsync` için `AdditionalDays` değerinin doğrulanması (ör. pozitif olma) yapılmıyor.### Project Overview
- Proje adı: Library
- Amaç: Kitap rezervasyonları için uygulama katmanı hizmetleri sunmak; DTO dönüşümleri ve iş kuralları ile rezervasyon yaşam döngüsünü yönetmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari/Clean Architecture yaklaşımı. Domain katmanı (entity, enum, repository kontratları), Application katmanı (DTO, servisler, mapping, istisnalar). Application, Domain’a bağımlı; repository’ler arayüzlerle soyutlanmış.
- Projeler/Assembly’ler:
  - Library.Domain — Temel domain modelleri, `ReservationStatus`, repository arayüzleri (`IBookReservationRepository`, `IBookRepository`, `ICustomerRepository`).
  - Library.Application — Uygulama hizmetleri (`BookReservationService`), DTO’lar, mapping uzantıları, istisnalar ve uygulama arayüzleri (`IBookReservationService`).
- Dış bağımlılıklar: Koddan görünmüyor (EF Core vb. belirtilmemiş).
- Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Application

---

### `Library.Application/Services/BookReservationService.cs`

**1. Genel Bakış**
Kitap rezervasyonlarını listeleme, oluşturma, iptal etme, karşılama ve silme işlemlerini yürüten uygulama servisi. Domain repository arayüzlerine dayanarak iş kurallarını uygular ve DTO/entity dönüşümlerini gerçekleştirir. Application katmanına aittir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookReservationService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookReservationRepository` — Rezervasyon sorgu/komut işlemleri
- `IBookRepository` — Kitabın varlık kontrolü
- `ICustomerRepository` — Müşteri durumu ve varlık sorguları

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookReservationDto?> GetByIdAsync(Guid id)` | Rezervasyonu detaylarıyla getirir ve DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<BookReservationDto>> GetAllAsync()` | Tüm rezervasyonları döndürür. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşteri için rezervasyonları listeler. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)` | Belirli kitap için rezervasyonları listeler. |
| CreateAsync | `Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)` | İş kurallarıyla yeni rezervasyon oluşturur, kuyruk pozisyonunu atar. |
| CancelReservationAsync | `Task CancelReservationAsync(Guid id)` | Rezervasyon durumunu `Cancelled` yapar ve günceller. |
| FulfillReservationAsync | `Task FulfillReservationAsync(Guid id)` | Rezervasyon durumunu `Fulfilled` yapar ve günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Rezervasyonu siler (mevcudiyet kontrolü ile). |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`:
  - Kitap var mı (`IBookRepository.ExistsAsync`) kontrolü; yoksa `NotFoundException`.
  - Müşteri var mı ve `IsActive` mi; değilse `NotFoundException` veya `BadRequestException`.
  - Kuyruk sırası: ilgili kitap için `ReservationStatus.Pending` sayısı + 1.
  - `CreateBookReservationDto.ToEntity()` ile entity oluşturulur; `QueuePosition` atanır.
- `CancelReservationAsync` ve `FulfillReservationAsync`:
  - Rezervasyon var mı kontrolü; yoksa `NotFoundException`.
  - `Status` sırasıyla `Cancelled`/`Fulfilled` olarak ayarlanır.
  - `UpdatedAt = DateTime.UtcNow`.
- `DeleteAsync`: Mevcudiyet yoksa `NotFoundException`.
- Mapping: `ToDto()` ve `ToEntity()` uzantıları ile DTO/entity dönüşümü.
- İstisnalar: `NotFoundException`, `BadRequestException`.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; muhtemelen API/controller veya uygulama iş akışları çağırır.
- Aşağı akış: `IBookReservationRepository`, `IBookRepository`, `ICustomerRepository`.
- İlişkili tipler: `BookReservationDto`, `CreateBookReservationDto`, `ReservationStatus`, `Domain.Entities.BookReservation`, `Domain.Entities.Book`, `Domain.Entities.Customer`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` içinde kuyruk pozisyonu hesaplamasında yarış koşulu potansiyeli (eşzamanlı isteklerde çakışma); transaction/concurrency kontrolü görünmüyor.
- `CancelReservationAsync`/`FulfillReservationAsync` için durum geçişi doğrulaması yok (örn. zaten `Cancelled` ise).
- İşlem bazlı transaction yönetimi (çoklu okuma + yazma) belirtilmemiş. 
- Yetkilendirme/kimlik doğrulama görünmüyor (katman gereği beklenmez; ancak uçtan uca önemli). 

---

Genel Değerlendirme
- Katmanlı/Clean Architecture yaklaşımı tutarlı: Application, Domain arayüzlerine bağımlı ve DTO/mapping kullanıyor.
- Concurrency ve transaction yönetimi kritik nokta; özellikle kuyruk pozisyonu atamasında veri bütünlüğü riskli.
- Durum makineleri veya geçiş doğrulamaları eklenerek iş kuralları güçlendirilebilir.
- Altyapı, konfigürasyon ve dış paket kullanımı bu koddan görünmüyor; logging, validation (ör. FluentValidation) ve idempotency politikaları değerlendirilebilir.### Project Overview
Proje adı: Library. Amaç: Kitap incelemeleri (review) için uygulama katmanında iş kurallarını ve akışları yönetmek. Hedef framework: bu dosyadan anlaşılmıyor.

Mimari: Clean Architecture. Katmanlar:
- Domain: Entity’ler ve repository arayüzleri (`Library.Domain.Interfaces`).
- Application: Use case/servisler, DTO’lar, mapping ve özel istisnalar (`Library.Application.*`).
- Infrastructure ve API/Presentation: Bu dosyadan anlaşılmıyor.

Projeler/Assembly’ler:
- Library.Domain — Entity’ler ve `IBookRepository`, `ICustomerRepository`, `IBookReviewRepository` arayüzleri.
- Library.Application — Servisler (`BookReviewService`), DTO’lar, map’ler, özel exception’lar ve application katmanı arayüzleri (`IBookReviewService`).

Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain <- Application  
Infrastructure (muhtemel) -> Domain (uygulama, repository arayüzlerini kullanır)  
API/Presentation (muhtemel) -> Application

---

### `Library.Application/Services/BookReviewService.cs`

**1. Genel Bakış**
`BookReviewService`, kitap incelemeleriyle ilgili sorgulama ve komut işlemlerini yürütür: inceleme listeleme, oluşturma, güncelleme, onaylama ve silme. Uygulama katmanına aittir ve domain repository arayüzlerini kullanarak iş kurallarını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookReviewService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookReviewRepository` — İnceleme veri erişimi (getir, ekle, güncelle, sil, ortalama puan).
- `IBookRepository` — İlgili kitabın varlık kontrolü.
- `ICustomerRepository` — İlgili müşterinin varlık kontrolü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookReviewDto?> GetByIdAsync(Guid id)` | İncelemeyi ID ile çekip DTO’ya map eder. |
| GetByBookIdAsync | `Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)` | Kitaba ait onaylı incelemeleri DTO olarak döner. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)` | Müşterinin tüm incelemelerini DTO olarak döner. |
| GetAverageRatingAsync | `Task<double> GetAverageRatingAsync(Guid bookId)` | Kitap için ortalama puanı döner. |
| CreateAsync | `Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)` | Kitap ve müşteri varlığını doğrular, puanı 1–5 aralığında kontrol eder, oluşturur ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)` | İncelemeyi bulur, puanı 1–5 aralığında doğrular, günceller. |
| ApproveReviewAsync | `Task ApproveReviewAsync(Guid id)` | İncelemeyi onaylar, `UpdatedAt`’i UTC’ye set eder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varlık kontrolü sonrası incelemeyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Oluşturma ve güncellemede `Rating` 1–5 arasında değilse `BadRequestException` fırlatır.
- Oluşturmada kitap ve müşteri varlık kontrolü yapar; yoksa `NotFoundException`.
- Güncelleme/Onaylama’da inceleme yoksa `NotFoundException`.
- `ApproveReviewAsync` onay bayrağını `true` yapar ve `UpdatedAt = DateTime.UtcNow` set eder.
- `GetByBookIdAsync` yalnızca onaylı incelemeleri getirir (repository çağrısından anlaşılır).
- DTO mapping `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır.

**6. Bağlantılar**
- Yukarı akış: `IBookReviewService` üzerinden DI ile çözülür; muhtemel çağırıcılar Application katmanı tüketicileri veya API controller’ları.
- Aşağı akış: `IBookReviewRepository`, `IBookRepository`, `ICustomerRepository`; mapping uzantıları ve `NotFoundException`/`BadRequestException`.
- İlişkili tipler: `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`, `Domain.Entities.BookReview`, `Domain.Entities.Book`, `Domain.Entities.Customer`, `IBookReviewService`.

**7. Eksikler ve Gözlemler**
- `GetAverageRatingAsync`’in onaylı/onarısız incelemeleri dikkate alıp almadığı belirsiz; repository sözleşmesiyle netleştirilmeli.
- `ApproveReviewAsync` yetkilendirme/rol kontrolü uygulama dışı; API katmanında veya pipeline’da doğrulanmalıdır.

---

### Genel Değerlendirme
- Clean Architecture prensipleri uygulanmış: Application katmanı domain arayüzlerine bağımlı, mapping ve özel exception’lar ayrışmış.
- Validasyonlar servis seviyesinde tutarlı; özellikle varlık ve aralık kontrolleri net.
- Cross-cutting endişeler (transaction yönetimi, logging, yetkilendirme) bu dosyadan anlaşılmıyor; infrastructure/API katmanlarında ele alınmalıdır.
- DTO mapping uzantıları kullanımı anlaşılır ve tekrarı azaltıyor; mapping hataları compile-time’da yakalanması için kapsamlı test önerilir.### Proje Genel Bakış
- Proje adı: Library
- Amaç: Kütüphane içindeki kitaplara yönelik CRUD ve sorgulama işlemlerini uygulama katmanında iş kurallarıyla orkestre etmek ve yeni kitap eklemelerinde e-posta bildirimi göndermek.
- Hedef Framework: Bu dosyadan açıkça anlaşılmıyor. Modern .NET (Core) stiline uygun.
- Mimari Desen: Clean Architecture tarzı katmanlı yapı.
  - Domain: `Library.Domain.Entities`, `Library.Domain.Interfaces` — çekirdek varlıklar ve repository kontratları.
  - Application: `Library.Application.Services`, `Library.Application.DTOs`, `Library.Application.Mappings`, `Library.Application.Email`, `Library.Application.Common.Exceptions`, `Library.Application.Interfaces` — use case’ler, DTO’lar, mapping uzantıları, e-posta sözleşmeleri/ayarları ve uygulama-seviyesi istisnalar.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıkları ve repository arayüzleri.
  - Library.Application — Uygulama servisleri, DTO/mapping ve istisnalar.
- Dış bağımlılıklar: Bu dosyadan açıkça görünmüyor. E-posta servisi bir arayüz üzerinden tüketiliyor.
- Konfigürasyon gereksinimleri:
  - E-posta bildirimleri için `EmailSettings.NotificationTo` (boş/whitespace ise bildirim gönderilmez). Diğer anahtarlar bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application --> Library.Domain

---

### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik sorgu ve komut işlemlerini (listeleme, detay, oluşturma, güncelleme, silme) koordine eder ve yeni kitap eklendiğinde opsiyonel e-posta bildirimi gönderir. Uygulama katmanına aittir; domain repository arayüzünü ve e-posta servis sözleşmesini kullanır, DTO/Entity mapping uzantılarını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap veri erişimi (okuma/yazma, detay ve uygun kitap sorguları).
- `IEmailService` — E-posta gönderimi için soyut servis.
- `EmailSettings` — Bildirim alıcısı gibi e-posta yapılandırmaları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookService(IBookRepository bookRepository, IEmailService emailService, EmailSettings emailSettings)` | Gerekli repository, e-posta servisi ve ayarlarını enjekte eder. |
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Kitabı detaylarıyla getirir ve DTO’ya map eder; yoksa null döner. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları DTO olarak döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/erişilebilir kitapları DTO olarak döner. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | ISBN benzersizliğini doğrular, kitap oluşturur ve bildirim e-postası gönderir. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Mevcut kitabı bulur, DTO ile günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varlığı doğrular ve kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- ISBN benzersizliği: `CreateAsync` içinde mevcut ISBN için `ConflictException` fırlatılır.
- Varlık bulunamama: `UpdateAsync` ve `DeleteAsync` için `NotFoundException` fırlatılır.
- Mapping: `CreateBookDto.ToEntity()`, `Book.ToDto()`, `UpdateBookDto.UpdateEntity(...)` uzantılarıyla yapılır.
- Bildirim: `EmailSettings.NotificationTo` doluysa yeni kitap eklenince `_emailService.SendAsync(...)` çağrılır (HTML gövde).
- Potansiyel tutarlılık riski: E-posta gönderimi hata verirse, `AddAsync` sonrası işlem başarısız olabilir ve transaction/geri alma görünmüyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/controller veya uygulama katmanı handler’ları çağırır.
- **Aşağı akış:** `IBookRepository`, `IEmailService`, `EmailSettings`.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `Book` (entity), `ConflictException`, `NotFoundException`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`), `IBookService`.

**7. Eksikler ve Gözlemler**
- E-posta gönderiminde hata yönetimi yok; `CreateAsync` içinde başarısız bildirim toplam işlemi başarısız kılabilir. Transaction veya outbox/geri alma stratejisi görünmüyor.
- Girdi DTO’ları için ek iş kuralı/validasyon (ör. boş `Title`, geçersiz `ISBN`) servis seviyesinde görünmüyor; repository veya başka katmanda olabilir ancak bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Clean Architecture ilkelerine uygun bağımlılık yönü korunuyor: Application, Domain arayüzlerine ve entity’lerine bağımlı; altyapı detayı sızdırılmıyor.
- Mapping uzantıları ve DTO kullanımı tutarlı.
- Oluşturma akışında yan etki (e-posta) için dayanıklılık stratejisi (transactional outbox, retry, fire-and-forget kuyruk) belirtilmemiş; olası tutarsızlık riski var.
- Konfigürasyon anahtarları ve hedef framework sürümü netleştirilmeli; e-posta ayarları belgelendirilmeli.### Project Overview
- Proje adı: Library
- Amaç: Müşteri (customer) yönetimi için uygulama katmanında hizmet (service) sağlayarak Domain katmanındaki repository arayüzleri üzerinden CRUD ve sorgulama işlemleri yapmak; DTO <-> Entity dönüşümlerini yürütmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture göstergeleri mevcut.
  - Domain: `Library.Domain` — Entity’ler ve repository arayüzleri (`ICustomerRepository`).
  - Application: `Library.Application` — DTO’lar, mapping uzantıları ve iş kuralları barındıran servisler.
  - Infrastructure: Bu dosyadan anlaşılmıyor (muhtemelen Domain arayüzlerini implemente eder).
  - API/Presentation: Bu dosyadan anlaşılmıyor (muhtemelen Application servislerini çağırır).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - `Library.Application` — Uygulama servisleri, DTO’lar, mapping ve özel exception’lar.
  - `Library.Domain` — Repository arayüzleri ve entity referansları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya app settings anahtarları görülmedi).

### Architecture Diagram
Library.Presentation/API (bu dosyadan anlaşılmıyor)
        |
        v
Library.Application --> Library.Domain
        ^
        |
Library.Infrastructure (bu dosyadan anlaşılmıyor, Domain arayüzlerini uygular)

---
### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri verileri üzerinde CRUD ve sorgulama işlemlerini yürüten uygulama katmanı servisidir. Domain katmanındaki `ICustomerRepository` üzerinden erişim sağlar ve DTO <-> Entity dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri verilerine erişim için repository arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını enjekte eder. |
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Id’ye göre müşteriyi getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri getirir ve DTO listesine dönüştürür. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri getirir ve DTO listesine dönüştürür. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Email benzersizliğini kontrol ederek yeni müşteri oluşturur ve DTO döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Mevcut müşteriyi bulur, DTO ile günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteri mevcutsa siler; değilse hata fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByEmailAsync` ile email benzersizlik kontrolü; varsa `ConflictException` fırlatır.
- `UpdateAsync`: Id ile müşteri mevcut değilse `NotFoundException` fırlatır; `UpdateCustomerDto.UpdateEntity` ile alan bazlı güncelleme yapılır.
- `DeleteAsync`: Yoksa `NotFoundException` fırlatır; varsa `DeleteAsync` çağrılır.
- Tüm okuma/ yazma işlemlerinde mapping: `ToDto`, `ToEntity`, `UpdateEntity`.
- Exception türleri: `ConflictException`, `NotFoundException` (`Library.Application.Common.Exceptions`).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar Application katmanını kullanan API/Controller’lar (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** `ICustomerRepository`, mapping uzantıları (`Library.Application.Mappings`).
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `Domain.Entities.Customer`, `ICustomerService`, `ICustomerRepository`.

**7. Eksikler ve Gözlemler**
- `UpdateAsync` içinde email benzersizliği tekrar kontrol edilmiyor; email değişebiliyorsa çakışma riski olabilir.
- `CancellationToken` desteği yok; uzun süren IO işlemleri için iptal desteği eklenmesi faydalı olabilir. 

---
Genel Değerlendirme
- Mimari olarak Application → Domain bağımlılığı ve DTO/mapping kullanımı Clean Architecture ilkeleriyle uyumlu görünüyor.
- Exception tabanlı hata yönetimi tutarlı; ancak update senaryosunda benzersizlik kontrolü ve iptal belirteci desteği gözden geçirilebilir.
- Dış bağımlılıklar, hedef framework, Infrastructure ve API katmanlarının detayları bu dosyadan anlaşılamıyor.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane yönetimi için istatistik/toplam değerleri sağlayan uygulama katmanı servisi (dashboard metrikleri).  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı/Clean Architecture eğilimli yapı. Domain katmanında repository arayüzleri ve enum’lar, Application katmanında servis ve DTO’lar yer alıyor.  
Keşfedilen Projeler/Assembly’ler ve Rolleri:
- Library.Domain: `Interfaces` (repository arayüzleri), `Enums` (iş kuralları sabitleri).
- Library.Application: `Services` (iş mantığı), `DTOs` (veri aktarım nesneleri), `Interfaces` (uygulama servis sözleşmeleri).
Kullanılan Dış Paketler/Çatılar: Bu dosyadan anlaşılmıyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain.Interfaces  
Library.Application -> Library.Domain.Enums  
Library.Application.DTOs (iç kullanım)  
Akış: Presentation/API (görünmüyor) -> Application (DashboardService) -> Domain (Repository arayüzleri) -> Infrastructure (görünmüyor)

---
### `Library.Application/Services/DashboardService.cs`

**1. Genel Bakış**  
`DashboardService`, gösterge paneli (dashboard) için toplam kitap, müsait kitap, müşteri, personel, aktif/gecikmiş ödünçler, bekleyen rezervasyonlar, ödenmemiş ceza toplamı ve şube sayısı gibi metrikleri toplayıp `DashboardStatsDto` olarak döner. Uygulama katmanında yer alır ve Domain katmanındaki repository arayüzlerinden veri okur.

**2. Tip Bilgisi**  
- Tip: class  
- Miras: Yok  
- Uygular: `IDashboardService`  
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**  
- `IBookRepository` — Kitap sayımı ve filtreli sayım (`IsAvailable`)  
- `ICustomerRepository` — Toplam/aktif müşteri bilgileri  
- `IStaffRepository` — Personel sayımı  
- `IBookLoanRepository` — Aktif ve gecikmiş ödünç işlemleri  
- `IBookReservationRepository` — Rezervasyon durumuna göre sayım  
- `IFineRepository` — Bekleyen cezaların listesi/toplamı  
- `ILibraryBranchRepository` — Şube sayımı

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `DashboardService(IBookRepository, ICustomerRepository, IStaffRepository, IBookLoanRepository, IBookReservationRepository, IFineRepository, ILibraryBranchRepository)` | Gerekli tüm repository bağımlılıklarını alır. |
| GetStatsAsync | `Task<DashboardStatsDto> GetStatsAsync()` | Çeşitli repository’lerden metrikleri toplayıp tek DTO olarak döner. |

**5. Temel Davranışlar ve İş Kuralları**  
- Toplam ve müsait kitap sayıları `CountAsync` ile, aktif/gecikmiş ödünçler özel sorgularla alınır.  
- Bekleyen rezervasyonlar `ReservationStatus.Pending` filtresiyle sayılır.  
- Bekleyen cezalar listelenir ve `Amount` alanlarının toplamı `TotalUnpaidFines` olarak hesaplanır.  
- Tüm çağrılar asenkron yapılır; mevcut haliyle sıralı bekleme uygulanır.  
- DTO mapping: Toplanan metrikler `DashboardStatsDto` alanlarına birebir atanır.

**Mantık içermeyen basit DTO/model'ler için**  
> DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor (`DashboardStatsDto` içeriği görünmüyor).

**6. Bağlantılar**  
- Yukarı akış: DI üzerinden çözümlenir; muhtemelen Application/Presentation katmanı servis tüketicileri kullanır.  
- Aşağı akış: `IBookRepository`, `ICustomerRepository`, `IStaffRepository`, `IBookLoanRepository`, `IBookReservationRepository`, `IFineRepository`, `ILibraryBranchRepository`.  
- İlişkili tipler: `DashboardStatsDto`, `ReservationStatus`, `IDashboardService`.

**7. Eksikler ve Gözlemler**  
- Performans: Tüm asenkron çağrılar sıralı bekleniyor; bağımsız sorgular `Task.WhenAll` ile paralelleştirilebilir.  
- Hata yönetimi: Toplama operasyonlarında hata sarmalama/loglama görünmüyor; operasyonel güvenilirlik için eklenebilir.

---
Genel Değerlendirme
- Mimari katmanlaşma Domain (arayüzler/enums) ve Application (servis/DTO) arasında net.  
- Dış bağımlılıklar, konfigürasyon ve hedef framework bu dosyadan çıkarılamıyor.  
- Dashboard derlemeleri çoklu repository çağrılarına dayanıyor; paralelleştirme ve temel hata/loglama iyileştirmeleri düşünülebilir.### Project Overview
Proje adı: Library (katmanlı kütüphane yönetimi bağlamı). Amaç: para cezaları (Fine) ile ilgili uygulama mantığını sunmak; ceza kayıtlarını listeleme, ödeme/affetme, toplam borç hesaplama gibi operasyonlar. Hedef çatı: Bu dosyadan .NET sürümü kesinleşmiyor; C# async/await ve Task tabanlı asenkron desenler kullanılıyor.

Mimari: Clean Architecture/N‑Tier hibriti. Application katmanı, Domain’daki `Interfaces` ve `Enums`’a bağımlı; veri erişimi `IFineRepository` abstractions üzerinden yapılır. Mapping, DTO’lar ve uygulama servisleri Application’da; Domain, entity ve kontratları barındırır. Infrastructure (bu dosyada görülmüyor) muhtemelen `IFineRepository` implementasyonunu sağlar. API/Presentation katmanı (bu dosyada yok) DI üzerinden servisleri kullanır.

Projeler/Assembly’ler:
- Library.Application — Uygulama servisleri, DTO’lar, mapping ve özel istisnalar.
- Library.Domain — Domain entity’leri, `Enums`, `Interfaces` (örn. `IFineRepository`).

Kullanılan harici paketler: Bu dosyadan belirgin bir dış paket görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.API/Presentation (varsayılan)  
  ↓ uses  
Library.Application (Services, DTOs, Mappings, Exceptions)  
  ↓ depends on abstractions  
Library.Domain (Entities, Enums, Interfaces)  
  ↑ implemented by  
Library.Infrastructure (Repository implementations, Persistence)

---
### `Library.Application/Services/FineService.cs`

**1. Genel Bakış**
`FineService`, para cezaları için uygulama iş akışlarını sağlar: sorgulama, oluşturma, ödeme, affetme ve silme. Application katmanında yer alır ve veri erişimini Domain’de tanımlı `IFineRepository` üzerinden yapar. DTO–Entity dönüşümleri için mapping uzantılarını kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IFineService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IFineRepository` — Para cezası verilerine asenkron CRUD ve sorgulama erişimi sağlayan repository arabirimi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public FineService(IFineRepository fineRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<FineDto?> GetByIdAsync(Guid id)` | Belirtilen ceza kaydını DTO olarak döndürür; yoksa null. |
| GetAllAsync | `public Task<IEnumerable<FineDto>> GetAllAsync()` | Tüm ceza kayıtlarını DTO listesi olarak döndürür. |
| GetByCustomerIdAsync | `public Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait cezaları listeler. |
| GetPendingFinesAsync | `public Task<IEnumerable<FineDto>> GetPendingFinesAsync()` | Bekleyen/ödenmemiş cezaları listeler. |
| GetTotalUnpaidByCustomerAsync | `public Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)` | Müşterinin toplam ödenmemiş ceza tutarını döndürür. |
| CreateAsync | `public Task<FineDto> CreateAsync(CreateFineDto createDto)` | Yeni ceza oluşturur ve DTO olarak döndürür. |
| PayFineAsync | `public Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)` | Cezayı ödenmiş olarak işaretler; ödeme bilgilerini günceller. |
| WaiveFineAsync | `public Task WaiveFineAsync(Guid id)` | Cezayı affedilmiş (`Waived`) olarak işaretler. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Ceza kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByIdAsync`/listeleme operasyonları entity’leri `ToDto()` ile DTO’ya map’ler.
- `CreateAsync`: `CreateFineDto.ToEntity()` ile entity oluşturur; `AddAsync` sonrası DTO döner.
- `PayFineAsync`:
  - Ceza bulunamazsa `NotFoundException` fırlatır.
  - Zaten `FineStatus.Paid` ise `BadRequestException` fırlatır.
  - `Status = Paid`, `PaidDate = UtcNow`, `PaymentMethod = payDto.PaymentMethod`, `UpdatedAt = UtcNow` olarak günceller ve `UpdateAsync` çağırır.
- `WaiveFineAsync`:
  - Ceza bulunamazsa `NotFoundException`.
  - `Status = Waived`, `UpdatedAt = UtcNow`; `UpdateAsync` çağırır.
- `DeleteAsync`:
  - Kayıt yoksa `NotFoundException`.
  - Varsa `DeleteAsync` ile siler.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak API controller’ları veya application katmanı aracıları çağırır.
- Aşağı akış: `IFineRepository`.
- İlişkili tipler: `IFineService`, `FineDto`, `CreateFineDto`, `PayFineDto`, `Library.Domain.Entities.Fine`, `FineStatus`, `NotFoundException`, `BadRequestException`, mapping uzantıları (`ToDto`, `ToEntity`).

**7. Eksikler ve Gözlemler**
- `WaiveFineAsync` mevcut durum ne olursa olsun affediyor; örn. zaten ödenmiş bir cezanın affı iş kuralı gerektiriyorsa ek kontrol gerekebilir.
- `PayFineAsync` içinde ödeme tutarı/işlem doğrulaması yok; `PayFineDto` için ek validasyon gerekebilir.
- Eşzamanlı güncellemelerde yarış koşullarına karşı concurrency kontrolü (örn. `RowVersion`) görünmüyor.

### Genel Değerlendirme
Kod, Application katmanında repository abstractions ile düzgün ayrıştırılmış ve net iş kuralları içeriyor. DTO–Entity mapping uzantılarıyla dönüşümler tutarlı. İstisna kullanımı yerinde; ancak bazı iş kuralları (affedilmiş/ödenmiş durum geçişlerinin kısıtları), veri bütünlüğü (concurrency) ve girdi validasyonları (özellikle ödeme senaryosu) genişletilebilir. Dış bağımlılıklar ve konfigürasyon bu kesitte görünmüyor; tam mimaride Infrastructure ve API katmanlarında DI, kalıcılık ve ayar yönetimi gözden geçirilmeli.### Project Overview
Proje adı: Library. Amaç: Kütüphane şubeleri için uygulama katmanında iş mantığını sağlayan servisler ve DTO/mapping kullanarak Domain varlıklarını dış dünyaya aktarmak. Hedef framework: Bu dosyadan kesin olarak anlaşılmıyor; async/await kullanımı modern .NET (>= .NET 6) ile uyumlu.

Mimari: Katmanlı/Clean Architecture benzeri. Application katmanı, Domain arabirimlerine bağımlı; mapping ve DTO’lar aracılığıyla veriyi taşır. Repository desenine dayanarak veri erişimi Application’dan soyutlanır.

Projeler/Assembly’ler:
- Library.Application — Uygulama hizmetleri, DTO’lar, mapping ve ortak exception tipleri.
- Library.Domain — Domain arabirimleri (`Library.Domain.Interfaces`) ve varlıklar (`Domain.Entities.LibraryBranch`) referans olarak kullanılıyor.

Harici paketler: Bu dosyadan görünmüyor.

Konfigürasyon: Bu dosyada bağlantı string’i veya app settings anahtarı kullanılmıyor; konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] -> Library.Application -> Library.Domain

---

### `Library.Application/Services/LibraryBranchService.cs`

**1. Genel Bakış**
`LibraryBranchService`, kütüphane şubelerine ilişkin sorgu ve komut operasyonlarını sağlayan uygulama katmanı servisidir. Domain katmanındaki `ILibraryBranchRepository` aracılığıyla veri erişimini soyutlar ve DTO/mapping ile dış dünyaya veri sunar. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ILibraryBranchService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ILibraryBranchRepository` — Şubeler için repository; CRUD ve aktif şube sorguları sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public LibraryBranchService(ILibraryBranchRepository branchRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<LibraryBranchDto?> GetByIdAsync(Guid id)` | Id ile şube getirir, DTO’ya map eder; yoksa null döner. |
| GetAllAsync | `public Task<IEnumerable<LibraryBranchDto>> GetAllAsync()` | Tüm şubeleri listeler ve DTO’ya map eder. |
| GetActiveBranchesAsync | `public Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()` | Yalnızca aktif şubeleri listeler. |
| CreateAsync | `public Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)` | DTO’dan entity üretir, ekler ve DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)` | Şubeyi id ile bulur, yoksa `NotFoundException` fırlatır; entity’yi DTO ile güncelleyip kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Mevcudiyet kontrolü yapar; yoksa `NotFoundException` fırlatır; varsa siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantıları ile DTO-Entity dönüşümleri yapılır.
- `UpdateAsync`: Şube bulunamazsa `NotFoundException` fırlatır.
- `DeleteAsync`: `ExistsAsync` ile doğrulama yapar; yoksa `NotFoundException` fırlatır.
- `CreateAsync`: Doğrudan ekleme yapar; ek validasyon veya benzersizlik kontrolü bu dosyada yok.
- Tüm operasyonlar asenkron ve repository üzerinden yürütülür.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/Presentation katmanındaki controller’lar veya uygulama hizmetleri çağırır.
- **Aşağı akış:** `ILibraryBranchRepository`
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `NotFoundException`, mapping uzantıları (`Library.Application.Mappings`), `Domain.Entities.LibraryBranch`

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için giriş validasyonu (örn. zorunlu alanlar, alan uzunlukları) bu dosyada görünmüyor.
- İş kurallarına özel hata yönetimi yok; yalnızca bulunamama durumunda `NotFoundException` kullanılıyor.

---

Genel Değerlendirme
- Katmanlı/temiz ayrım uygulanmış: Application yalnızca Domain arabirimlerine bağımlı ve DTO/mapping ile çalışıyor.
- Servis mantığı net, NotFound senaryoları ele alınmış; ancak create/update için giriş doğrulaması ve alan bazlı kurallar bu dosyada görünmüyor.
- Harici paket ve konfigürasyon kullanımı bu dosyadan çıkarılamıyor; proje genelinde belgelendirme için ek dosyalar incelenmeli.
- Transaction yönetimi ve birimsel atomiklik ihtiyacı (birden çok repository çağrısı durumunda) bu sınıfta yok; daha karmaşık işlemler için ilgili desenler (Unit of Work) değerlendirilebilir.### Project Overview
- Proje adı: Library (isimlendirmeden çıkarım). Amacı: Bildirim yönetimi için Application katmanında servis sağlayarak `INotificationRepository` üzerinden bildirimlerin oluşturulması, okunma durumlarının güncellenmesi ve sorgulanması.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture benzeri katmanlı yapı. Application katmanı, Domain arayüzlerine bağımlı; DTO ve mapping kullanımıyla ayrık veri modelleri.
  - Domain: İş kuralları ve repository arayüzleri (`INotificationRepository`).
  - Application: Servisler, DTO’lar, mapping uzantıları, uygulama iş akışları (`NotificationService`).
  - Infrastructure/API: Bu dosyadan anlaşılmıyor (varsayım yapılmıyor).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama servisleri, DTO ve mapping katmanı.
  - Library.Domain — Domain arayüzleri (repository).
- Dış bağımlılıklar: Belirgin paket yok; LINQ kullanılmakta.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Services/NotificationService.cs`

**1. Genel Bakış**
`NotificationService`, bildirimlerin alınması, oluşturulması, okunma durumlarının güncellenmesi ve silinmesi işlemlerini koordine eden Application katmanı servisidir. Domain’deki `INotificationRepository`’ye dayanır ve `DTO`-Entity dönüşümlerini mapping uzantıları ile yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `INotificationService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `INotificationRepository` — Bildirimlerin veri erişimi, sorgular, ekleme, silme ve okunma durum güncellemeleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `NotificationService(INotificationRepository notificationRepository)` | Repository bağımlılığını alır. |
| GetByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)` | Müşteriye ait tüm bildirimleri döner. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)` | Müşterinin okunmamış bildirimlerini döner. |
| GetUnreadCountAsync | `Task<int> GetUnreadCountAsync(Guid customerId)` | Okunmamış bildirim sayısını döner. |
| CreateAsync | `Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)` | Yeni bildirim oluşturur ve DTO döner. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Belirtilen bildirimi okundu olarak işaretler. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm bildirimlerini okundu yapar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen bildirimi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `CreateNotificationDto` → Entity dönüşümü `ToEntity()` ile yapılır; ekleme sonrası `ToDto()` ile döndürülür.
- Sorgu metotları (`GetByCustomerIdAsync`, `GetUnreadByCustomerIdAsync`) repository’den alınan entity’leri `ToDto()` ile mapler.
- Okunma güncellemeleri (`MarkAsReadAsync`, `MarkAllAsReadAsync`) ve silme (`DeleteAsync`) doğrudan repository çağrılarıyla yapılır.
- Ek doğrulama, transaction veya hata yönetimi bu dosyadan görülmüyor; repository ve mapping katmanlarına güvenilir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak Application veya API katmanı tarafından çağrılır (bu dosyadan kesin değil).
- Aşağı akış: `INotificationRepository`, mapping uzantıları (`ToDto`, `ToEntity`).
- İlişkili tipler: `INotificationService`, `INotificationRepository`, `NotificationDto`, `CreateNotificationDto`, `Library.Application.Mappings` uzantıları.

**7. Eksikler ve Gözlemler**
- `CreateAsync` içinde input validasyonu veya alan bazlı doğrulama görünmüyor; tüm doğrulama muhtemelen başka katmanlara bırakılmış.

---
Genel Değerlendirme
- Clean Architecture’a uygun katman ayrımı sinyali güçlü: Application servisleri Domain arayüzlerine bağlı ve DTO/mapping kullanılıyor.
- Görünen kodda hata yönetimi, logging ve validasyon katmanı belirtilmemiş; çapraz kesen kaygılar için eklenmesi gerekebilir.
- Hedef framework ve konfigürasyon detayları belirsiz; projeler arası bağımlılıkların tam resmi için diğer katmanların (Infrastructure, API) incelenmesi gerekir.### Project Overview
- Proje adı: Library (ad alanlarından çıkarım). Amaç: yayınevleriyle (publisher) ilgili uygulama iş kurallarını sunmak; CRUD ve listeleme operasyonları. Hedef çatı: bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture benzeri katmanlama. Application katmanı iş kurallarını barındırır ve Domain katmanındaki repository arayüzlerine bağımlıdır. Mapping ve DTO’lar Application’da, entity ve repository sözleşmeleri Domain’dedir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application: Application hizmetleri, DTO’lar, eşlemeler, özel exception’lar.
  - Library.Domain: Entity’ler ve repository arayüzleri.
- Kullanılan dış paketler/çerçeveler: koddan anlaşılmıyor (EF Core, MediatR vb. görünmüyor).
- Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Services/PublisherService.cs`

**1. Genel Bakış**
`PublisherService`, yayınevleri için okuma ve CRUD odaklı uygulama servisidir. Application katmanında yer alır ve `IPublisherRepository` üzerinden Domain verilerine erişir. DTO-Entity dönüşümleri `Library.Application.Mappings` uzantılarıyla gerçekleştirilir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IPublisherService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IPublisherRepository` — Yayınevlerine ilişkin veri erişimi (getir, ekle, güncelle, sil ve özel sorgular)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<PublisherDto?> GetByIdAsync(Guid id)` | Verilen `id` için yayınevini kitaplarıyla birlikte getirir ve DTO’ya map eder. |
| GetAllAsync | `Task<IEnumerable<PublisherDto>> GetAllAsync()` | Tüm yayınevlerini getirir ve DTO listesine map eder. |
| GetActivePublishersAsync | `Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()` | Aktif yayınevlerini filtreleyip DTO listesi olarak döndürür. |
| CreateAsync | `Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)` | İsim bazlı çakışma kontrolü yaparak yeni yayınevi oluşturur ve DTO döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)` | Var olan yayınevini bulur; update DTO’su ile entity’yi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varlık mevcutsa siler; yoksa bulunamadı hatası fırlatır. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByNameAsync` ile ad bazlı tekillik kontrolü; varsa `ConflictException` fırlatılır.
- `GetByIdAsync`: Repository `GetWithBooksAsync` çağrılır; yoksa `null` dönebilir.
- `UpdateAsync`: `GetByIdAsync` ile varlık zorunlu; yoksa `NotFoundException` fırlatılır. Güncelleme `UpdatePublisherDto.UpdateEntity(...)` ile yapılır.
- `DeleteAsync`: Silme öncesi `ExistsAsync` ile varlık kontrolü; yoksa `NotFoundException` fırlatılır.
- DTO-Entity dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `IPublisherRepository`
- İlişkili tipler: `PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`, `Domain.Entities.Publisher`, `ConflictException`, `NotFoundException`, `Library.Application.Mappings` uzantıları.

---

### Genel Değerlendirme
- Application servisinde tutarlı şekilde DTO-Entity mapping uzantıları ve özel exception’lar kullanılıyor; domain erişimi repository arayüzü üzerinden soyutlanmış.
- İstek iptali ve zaman aşımları için `CancellationToken` desteği görünmüyor; eklenmesi dayanıklılığı artırabilir.
- Günlükleme ve denetimli hata yönetimi (ör. audit/log) bu dosyada görünmüyor; katmanlar arası çapraz kesen kaygılar için yer ayırmak faydalı olabilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane personel (“staff”) yönetimi için uygulama katmanında iş kurallarını ve veri erişim soyutlamalarını kullanarak CRUD ve sorgulama işlemlerini gerçekleştirmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean Architecture eğilimli. Application katmanı, Domain arayüzlerine (repository) bağımlı; mapping uzantıları ile DTO-Entity dönüşümleri yapıyor. Persistence ve API katmanları bu dosyadan görünmüyor.
- Proje/Assembly’ler:
  - Library.Application — Uygulama servisleri, DTO’lar, mapping ve özel exception’lar.
  - Library.Domain — Entity’ler ve repository arayüzleri (namespace referanslarından çıkarım).
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor (EF Core/MediatR vb. görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string, appsettings anahtarları görünmüyor).

### Architecture Diagram
Library.API (varsayım, görünmüyor)
    ↓
Library.Application
    ↓
Library.Domain (Entities, Interfaces)
    ↓
Library.Infrastructure (varsayım, görünmüyor; Domain arayüzlerinin implementasyonu)

---
### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel yönetimi için uygulama katmanında iş akışını koordine eder. Repository arayüzü üzerinden veri erişimini soyutlar, DTO-Entity mapping uzantılarını kullanır ve iş kuralı ihlallerinde uygulama-özel exception’lar üretir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel varlıkları için veri erişimi (getir, ekle, güncelle, sil, varlık kontrolü, e-posta ile sorgu).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personel döndürür; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personeli DTO olarak listeler. |
| GetActiveStaffAsync | `public Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personeli DTO olarak listeler. |
| CreateAsync | `public Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | E-posta benzersizliğini kontrol ederek yeni personel oluşturur. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut personeli günceller; bulunamazsa hata verir. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Personeli siler; yoksa hata verir. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `GetByEmailAsync` ile e-posta benzersizlik kontrolü yapar; mevcutsa `ConflictException` fırlatır. `CreateStaffDto.ToEntity()` ile entity oluşturur; `AddAsync` sonrası `ToDto()` döner.
- `UpdateAsync`: `GetByIdAsync` ile varlık aranır; yoksa `NotFoundException` fırlatır. `UpdateStaffDto.UpdateEntity(staff)` ile alanlar güncellenir; `UpdateAsync` çağrılır.
- `DeleteAsync`: `ExistsAsync` ile varlık doğrulanır; yoksa `NotFoundException` fırlatır; ardından `DeleteAsync` çalışır.
- Sorgular: `GetActiveStaffAsync` aktif filtreli repository çağrısı kullanır. Tüm dönüşler `ToDto()` mapping uzantısı ile yapılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/controller veya uygulama iş akışları çağırır.
- **Aşağı akış:** `IStaffRepository`; mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`); `ConflictException`, `NotFoundException`.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `Domain.Entities.Staff`, `IStaffService`, `IStaffRepository`.

**7. Eksikler ve Gözlemler**
- Yöntemlerde `CancellationToken` desteği yok; uzun süren IO işlemlerinde iptal desteği eklenebilir.
- `CreateAsync` için e-posta benzersizliği sadece uygulama seviyesinde kontrol ediliyor; veri katmanında benzersiz indeks/constraint ile yarış durumları engellenmeli.

---
### Genel Değerlendirme
- Uygulama katmanı, domain repository arayüzlerine bağımlı olacak şekilde temiz bir ayrım sergiliyor; DTO-Entity mapping uzantıları tutarlı kullanılıyor.
- İptal belirteci ve olası yarış koşullarına karşı kalıcılık katmanında benzersiz kısıtların teyidi önerilir.
- Hata yönetimi uygulama-özel exception’lar ile net; ancak global düzeyde bu exception’ların API katmanında doğru HTTP karşılıklarına dönüştürüldüğünün teyidi gerekir (bu depoda görünmüyor).### Project Overview
- Proje Adı: Library (namespace: `Library.Domain`)
- Amaç: Domain katmanında denetim/audit amaçlı kayıtları temsil eden entity tanımları sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Domain odaklı katmanlı mimari (Clean Architecture/N-Tier göstergesi). Bu dosyada sadece Domain katmanı görülebiliyor.
  - Domain: İş kuralları ve çekirdek modeller (entity’ler, value object’ler, base tipler).
  - Diğer katmanlar (Application/Infrastructure/API): Bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain entity ve muhtemelen base tipleri barındırır.
- Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  ↑ (Diğer katmanlar bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Entities/AuditLog.cs`

**1. Genel Bakış**
`AuditLog`, sistemdeki entity’ler üzerinde gerçekleşen işlemlerin (create/update/delete vb.) kim tarafından, ne zaman ve hangi değişikliklerle yapıldığını kaydetmek için tasarlanmış bir domain entity’sidir. Domain katmanına aittir ve kalıcılık katmanında audit kayıtlarının oluşturulması/okunması için temel veri modelini sağlar.

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
| EntityName | `public string EntityName { get; set; }` | İşlem yapılan entity’nin adı. Varsayılan `string.Empty`. |
| EntityId | `public Guid EntityId { get; set; }` | İşlem yapılan entity’nin benzersiz kimliği. |
| Action | `public string Action { get; set; }` | Gerçekleşen eylem türü (örn. Create/Update/Delete). Varsayılan `string.Empty`. |
| OldValues | `public string? OldValues { get; set; }` | Değişiklik öncesi değerlerin JSON/metin temsili. |
| NewValues | `public string? NewValues { get; set; }` | Değişiklik sonrası değerlerin JSON/metin temsili. |
| UserId | `public string? UserId { get; set; }` | İşlemi tetikleyen kullanıcının kimliği. |
| UserName | `public string? UserName { get; set; }` | İşlemi tetikleyen kullanıcının adı. |
| IpAddress | `public string? IpAddress { get; set; }` | İstek kaynağının IP adresi. |
| Timestamp | `public DateTime Timestamp { get; set; }` | İşlemin gerçekleştiği zaman damgası. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `EntityName = string.Empty`, `Action = string.Empty`; diğer `string?` alanlar `null` olabilir. `Timestamp` için default atama yapılmamış; set edilmezse `default(DateTime)` kalır. `EntityId` set edilmezse `Guid.Empty` olabilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BaseEntity` (tanımı bu dosyada yok).

**7. Eksikler ve Gözlemler**
- `Timestamp` için otomatik atama veya fabrikasyon mantığı yok; kayıt oluşturulurken set edilmezse `default(DateTime)` kalabilir.
- `Action`, `EntityName` gibi alanlar için değer kümesi/validasyon tanımlı değil; serbest metin olması tutarlılık riskleri doğurabilir.

---
Genel Değerlendirme
- Yalnızca Domain katmanından bir entity görülebiliyor; diğer katmanlar ve akışlar bu dosyadan çıkarılamıyor.
- Audit alanları serbest metin/nullable; uygulama katmanında standartlaştırma ve validasyon ihtiyacı var.
- Zaman damgası ve kimlik atamaları için oluşturma anında garanti sağlayacak bir mekanizma (factory, interceptor, EF Core save changes hook) projede gerekebilir; bu dosyada görünmüyor.### Proje Genel Bakış
- Proje adı: Library (ad alanlarından çıkarım)
- Amaç: Kütüphane alanındaki temel varlıkları (ör. yazarlar) tanımlayan domain modeli sağlamak.
- Hedef çatı/sürüm: Bu dosyadan kesin olarak anlaşılmıyor (modern C# özellikleri kullanımı mevcut).
- Mimari desen: Yalnızca Domain katmanı görünüyor; diğer katmanlar (Application/Infrastructure/API) bu girdiyle doğrulanamıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıklarını ve temel modelleri içerir.
- Kullanılan dış paketler/çatı: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Mimari Diyagram
Library.Domain (Entities)
  └─ içeride: Author → BaseEntity (miras), Book (ilişkili gezinim)

---
### `Library.Domain/Entities/Author.cs`

**1. Genel Bakış**
`Author` bir domain varlığıdır ve kütüphanedeki yazar bilgilerini temsil eder. Tipik olarak Domain katmanına aittir ve `Book` varlığı ile ilişki kurar.

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
| FirstName | `public string FirstName { get; set; }` | Yazarın adı. |
| LastName | `public string LastName { get; set; }` | Yazarın soyadı. |
| Biography | `public string? Biography { get; set; }` | Yazar biyografisi (opsiyonel). |
| BirthDate | `public DateTime? BirthDate { get; set; }` | Doğum tarihi (opsiyonel). |
| DeathDate | `public DateTime? DeathDate { get; set; }` | Ölüm tarihi (opsiyonel). |
| Nationality | `public string? Nationality { get; set; }` | Uyruk bilgisi (opsiyonel). |
| Website | `public string? Website { get; set; }` | Web sitesi (opsiyonel). |
| PhotoUrl | `public string? PhotoUrl { get; set; }` | Fotoğraf URL’si (opsiyonel). |
| Books | `public ICollection<Book> Books { get; set; }` | Yazara ait kitaplar koleksiyonu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Books` boş koleksiyon ile başlatılır, diğer metin alanları `null` olabilir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity` (miras), `Book` (gezginim koleksiyonu).
- **İlişkili tipler:** `Book`, `BaseEntity`.

**7. Eksikler ve Gözlemler**
- `FirstName` ve `LastName` için domain seviyesinde zorunluluk/validasyon bulunmuyor; iş kuralları varsa başka katmanda ele alınıyor olabilir.
- `Books` ilişkisinin yükleme stratejisi (lazy/eager) ve sahiplik kuralları bu dosyadan anlaşılmıyor.

---
Genel Değerlendirme
- Yalnızca Domain katmanından tek bir varlık görünmekte; Clean/katmanlı mimari kullanımı olası ancak diğer katmanlar doğrulanamıyor.
- Varlıkta davranış/iş kuralı bulunmuyor; validasyon ve bütünlük kurallarının nerede uygulandığı belirsiz.
- `BaseEntity` ve `Book` referansları mevcut ancak tanımları bu girdi kapsamında yok; ortak kimlik/zaman damgası gibi alanlar muhtemelen `BaseEntity`’de.### Proje Genel Bakış
- Ad: Library (çıkarım: `Library.Domain` namespace’inden)
- Amaç: Kütüphane alanındaki domain modelleri için ortak temel varlık altyapısı sağlamak (audit ve soft delete alanları).
- Hedef Framework: Bu dosyadan anlaşılmıyor. (C# dil özellikleri modern; net7/8 olabilir ancak doğrulanamıyor.)
- Mimari: Clean Architecture/N-Katmanlı bir düzeni ima ediyor. Bu katman dosyası Domain katmanına aittir.
  - Domain: Temel varlıklar, iş kuralları ve model tanımları.
  - Diğer katmanlar (Application/Infrastructure/API) bu depoda görünmüyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları ve ortak base tipler.
- Harici Paketler: Bu dosyadan anlaşılmıyor (görünür bağımlılık yok).
- Konfigürasyon: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarı yok).

### Mimari Diyagram
Library.Domain

---

### `Library.Domain/Entities/BaseEntity.cs`

**1. Genel Bakış**
`BaseEntity`, domain katmanındaki tüm varlıklar için ortak alanları sağlayan soyut bir temel sınıftır. Kimlik (`Id`), oluşturma/güncelleme zaman damgaları ve kullanıcı bilgileri ile yumuşak silme (`IsDeleted`) semantiğini merkezileştirir. Clean Architecture’da Domain katmanına aittir.

**2. Tip Bilgisi**
- Tip: abstract class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Varlığın benzersiz kimliği. |
| CreatedAt | `public DateTime CreatedAt { get; set; }` | Oluşturulma tarihi/zamanı. |
| CreatedBy | `public string? CreatedBy { get; set; }` | Oluşturan kullanıcı/işlem kimliği. |
| UpdatedAt | `public DateTime? UpdatedAt { get; set; }` | Son güncellenme tarihi/zamanı. |
| UpdatedBy | `public string? UpdatedBy { get; set; }` | Son güncelleyen kullanıcı/işlem kimliği. |
| IsDeleted | `public bool IsDeleted { get; set; }` | Yumuşak silme bayrağı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `IsDeleted = false` (bool için dil varsayılanı), `CreatedBy` ve `UpdatedBy` `null` olabilir, `UpdatedAt` `null` olabilir. `Id` için otomatik üretim veya atama stratejisi bu dosyadan anlaşılmıyor. Audit alanlarının set edilmesi uygulama/altyapı katmanına bırakılmış görünüyor.

**6. Bağlantılar**
- Yukarı akış: Domain varlıkları bu sınıftan türeyerek kullanır (özel çağırıcılar bu dosyadan anlaşılmıyor).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Türeyen entity tipleri (bu depoda görünmüyor).

---

### Genel Değerlendirme
- Yalnızca Domain katmanından bir temel varlık görülüyor; diğer katmanlar ve akışlar bu depoda yer almıyor.
- Audit ve soft delete alanları merkezileştirilmiş; ancak bu alanların yaşam döngüsünü yönetecek altyapı (ör. `DbContext` interceptor’ları, repository veya davranışsal base sınıf) görünmüyor.
- `Id` üretimi ve audit alanlarının doldurulması stratejisi belirtilmemiş; uygulama/altyapı tarafında tutarlı bir politika gerektirir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki temel varlıkları modellemek (ör. kitap, yazar, yayınevi). Hedef çatı: bu dosyadan anlaşılmıyor; ancak adlandırma ve katman isimleri Domain odaklı mimariyi ima ediyor.
Mimari: Clean Architecture/N‑Tier yaklaşımı izleri var. Domain katmanı, iş alanı varlıklarını ve enum’ları içerir; diğer katmanlar (Application/Infrastructure/API) bu dosyadan görünmüyor.
Projeler/Assembly’ler:
- Library.Domain — Domain varlıkları ve enum’lar (ör. `Book`, `BookCondition`).
Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor (EF Core veri ek açıklamaları veya paket kullanımı görünmüyor).
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)
^
[Diğer katmanlar — bu repoda görünmüyor]

---
### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book`, kütüphanedeki kitap varlığını temsil eder; başlık, ISBN, yayın yılı ve stok/uygunluk bilgilerini tutar. Domain katmanına aittir ve diğer varlıklarla (yazar, yayınevi, kategori, şube) ilişkileri içerir.

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
| Title | `public string Title { get; set; }` | Kitap başlığı. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. |
| Description | `public string Description { get; set; }` | Kitap açıklaması. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| PageCount | `public int PageCount { get; set; }` | Sayfa sayısı. |
| Language | `public string Language { get; set; }` | Dil. Varsayılan: "Turkish". |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik durumu. Varsayılan: true. |
| TotalCopies | `public int TotalCopies { get; set; }` | Toplam kopya. Varsayılan: 1. |
| AvailableCopies | `public int AvailableCopies { get; set; }` | Mevcut kopya. Varsayılan: 1. |
| Condition | `public BookCondition Condition { get; set; }` | Fiziksel durum. Varsayılan: `BookCondition.New`. |
| CoverImageUrl | `public string? CoverImageUrl { get; set; }` | Kapak görseli URL. |
| Price | `public decimal? Price { get; set; }` | Fiyat. |
| AuthorId | `public Guid AuthorId { get; set; }` | Yazar kimliği. |
| Author | `public Author Author { get; set; }` | Yazar navigasyonu. |
| PublisherId | `public Guid? PublisherId { get; set; }` | Yayınevi kimliği. |
| Publisher | `public Publisher? Publisher { get; set; }` | Yayınevi navigasyonu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği. |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | Kategori navigasyonu. |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | Şube kimliği. |
| LibraryBranch | `public LibraryBranch? LibraryBranch { get; set; }` | Şube navigasyonu. |
| BookLoans | `public ICollection<BookLoan> BookLoans { get; set; }` | Ödünç kayıtları. |
| BookReservations | `public ICollection<BookReservation> BookReservations { get; set; }` | Rezervasyonlar. |
| BookReviews | `public ICollection<BookReview> BookReviews { get; set; }` | Değerlendirmeler. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılanlar: `Title/ISBN/Description = string.Empty`, `Language = "Turkish"`, `IsAvailable = true`, `TotalCopies = 1`, `AvailableCopies = 1`, `Condition = BookCondition.New`.
- Navigasyon koleksiyonları boş koleksiyonla başlatılır.
- Zorunlu ilişki: `AuthorId` ve `Author` null olamaz; diğer ilişkiler opsiyonel.
- Bu dosyada validasyon, iş kuralı veya senkronizasyon (ör. `AvailableCopies <= TotalCopies`) uygulanmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** İlişkiler: `Author`, `Publisher`, `BookCategory`, `LibraryBranch`, `BookLoan`, `BookReservation`, `BookReview`; enum: `BookCondition`; temel sınıf: `BaseEntity`.
- **İlişkili tipler:** `Author`, `Publisher`, `BookCategory`, `LibraryBranch`, `BookLoan`, `BookReservation`, `BookReview`, `BookCondition`, `BaseEntity`.

**7. Eksikler ve Gözlemler**
- Stok alanları için tutarlılık garantisi yok (`AvailableCopies` değerinin `TotalCopies`’i aşmaması gibi).
- `IsAvailable` ile `AvailableCopies` arasında otomatik eşleme/kurgu yok (ör. `AvailableCopies == 0` iken `IsAvailable` hala true olabilir).### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane/katalog alanındaki temel varlıkları tanımlayan Domain katmanı; kitap kategorileri ve hiyerarşik ilişki modellemesi.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Tier benzeri; `Library.Domain` saf alan modeli içerir. Üst katmanlar (Application/Infrastructure/API) bu katmanı referans alarak iş kuralları, veri erişimi ve sunum sağlar.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıkları ve çekirdek modeller.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor (ORM izlenimi olsa da kesin değil).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  ↑ (diğer katmanlardan referanslanması beklenir; bu depodan yalnızca Domain görülebiliyor)

---
### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, kitap kategorilerini ve alt kategori hiyerarşisini temsil eden domain varlığıdır. Kategorilerin adı, açıklaması, görünüm sırası ve aktiflik durumunu tutar; kendi kendine referansla ebeveyn/alt kategori ilişkisini kurar. Mimari olarak Domain katmanına aittir.

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
| IconUrl | `public string? IconUrl { get; set; }` | Kategori ikonunun URL’si (opsiyonel). |
| DisplayOrder | `public int DisplayOrder { get; set; }` | Listeleme/görünüm sırası. |
| IsActive | `public bool IsActive { get; set; }` | Kategorinin aktiflik durumu. |
| ParentCategoryId | `public Guid? ParentCategoryId { get; set; }` | Ebeveyn kategori kimliği (opsiyonel). |
| ParentCategory | `public BookCategory? ParentCategory { get; set; }` | Ebeveyn kategoriye navigasyon (opsiyonel). |
| SubCategories | `public ICollection<BookCategory> SubCategories { get; set; }` | Alt kategoriler koleksiyonu. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye bağlı kitaplar. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `IconUrl = null`, `DisplayOrder = 0`, `IsActive = true`, `ParentCategoryId = null`, `ParentCategory = null`, `SubCategories = []`, `Books = []`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity`, `Book` (ilişkili tipler).
- **İlişkili tipler:** `Book`, `BaseEntity`, `BookCategory` (self-referans).

Genel Değerlendirme
- Kod yalnızca Domain katmanından bir varlık sunuyor; diğer katmanlar veya altyapı detayları bu depoda görünmüyor.
- Tüm özellikler set edilebilir ve doğrulama mantığı bulunmuyor; alan doğrulamalarının nerede yapıldığı bu dosyadan anlaşılmıyor.
- Hiyerarşik self-referans ve koleksiyon navigasyonları bir ORM kullanımına uygun görünüyor; ancak spesifik teknoloji bu dosyadan çıkarılamıyor.### Project Overview
Proje adı: Library (Domain katmanı). Amaç: Kütüphane alan modellerini (entity, enum) tanımlamak; ödünç verme süreçleri gibi temel iş kavramlarını temsil etmek. Hedef çerçeve: Bu dosyadan net değil, ancak modern C# sözdizimi (collection initializer []) kullanımı .NET 7+ olasılığına işaret eder; kesin sürüm bu dosyadan anlaşılmıyor.

Mimari desen: Clean Architecture/N‑katmanlı yaklaşım izleri; bu dosya Domain katmanına aittir ve yalnızca alan modellerini içerir. Domain katmanı iş kurallarının merkezidir ve diğer katmanlara bağımlı olmamalıdır.

Projeler/Assembly’ler:
- Library.Domain — Alan varlıkları, enum’lar ve temel tipler; veri erişim veya uygulama mantığı içermez.

Harici paketler/çerçeveler: Bu dosyada görünür bir harici paket kullanımı yok.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API/Application] -> Library.Domain

---
### `Library.Domain/Entities/BookLoan.cs`

**1. Genel Bakış**
`BookLoan`, bir kitabın bir müşteri tarafından ödünç alınmasını temsil eden alan varlığıdır. İlgili kitap, müşteri, işlemi yapan personel, tarihler, durum ve cezalar gibi bilgileri taşır. Domain katmanının bir parçasıdır.

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
| BookId | `public Guid BookId { get; set; }` | İlgili kitabın kimliği. |
| Book | `public Book Book { get; set; }` | İlgili kitap navigasyon nesnesi. |
| CustomerId | `public Guid CustomerId { get; set; }` | Ödünç alan müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | Müşteri navigasyon nesnesi. |
| ProcessedByStaffId | `public Guid? ProcessedByStaffId { get; set; }` | İşlemi yapan personelin kimliği (opsiyonel). |
| ProcessedByStaff | `public Staff? ProcessedByStaff { get; set; }` | Personel navigasyon nesnesi (opsiyonel). |
| LoanDate | `public DateTime LoanDate { get; set; }` | Ödünç alma tarihi. |
| DueDate | `public DateTime DueDate { get; set; }` | İade edilmesi gereken son tarih. |
| ReturnDate | `public DateTime? ReturnDate { get; set; }` | Gerçek iade tarihi (opsiyonel). |
| Status | `public LoanStatus Status { get; set; }` | Ödünç durum bilgisi. |
| Notes | `public string? Notes { get; set; }` | Notlar (opsiyonel). |
| RenewalCount | `public int RenewalCount { get; set; }` | Yenileme sayısı. |
| MaxRenewals | `public int MaxRenewals { get; set; }` | Maksimum yenileme sayısı. |
| Fines | `public ICollection<Fine> Fines { get; set; }` | Bu ödünç işlemine ilişkin cezalar. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Status = LoanStatus.Active`, `MaxRenewals = 2`, `Fines` boş koleksiyon ile başlar, `Book` ve `Customer` null olamaz (`null!` ataması), `ProcessedByStaff` ve `ReturnDate` opsiyoneldir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book`, `Customer`, `Staff`, `Fine`, `LoanStatus`.
- **İlişkili tipler:** `BaseEntity` (ortak kimlik/zaman damgası gibi alanları içerebilir, bu dosyadan detayı belirsiz).

Genel Değerlendirme
- Sadece Domain varlıkları görünür durumda; diğer katmanlar (Application, Infrastructure, API) bu girdiyle doğrulanamıyor.
- `BookLoan` içinde alan doğrulamaları ve iş kuralları uygulanmıyor; bu, Clean Architecture’da beklenen şekilde Application/Domain hizmetlerine bırakılmış olabilir, ancak bu dosyadan teyit edilemiyor.
- `BaseEntity` içeriği belirsiz; kimlik ve izleme alanlarının standardizasyonu için bu tipin tutarlı kullanımı önemli olacaktır.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” ve amacı bir kütüphane alan modelini (özellikle rezervasyonlar) temsil etmektir. Hedef framework bu dosyadan anlaşılmıyor. Yapı, `Library.Domain` ad alanı ile alan (domain) katmanını içerir; entity, ilişkili varlıklar ve enum’larla bir alan modeli kurar.

Mimari olarak, isimlendirme ve katman ayrımı, en azından bir Domain katmanının bulunduğu katmanlı/Clean Architecture yaklaşımına işaret ediyor; diğer katmanlar (Application, Infrastructure, API) bu dosyadan görülmüyor.

Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain katmanı; entity’ler, enum’lar ve muhtemel base entity tanımları.

Kullanılan harici paketler/framework’ler: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri (connection string, appsettings): Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)
  ↑ (diğer katmanlar bu dosyadan görülmüyor; tipik akış Application → Domain, Infrastructure → Domain olabilir ancak bu dosyadan kesinleşmiyor)

---
### `Library.Domain/Entities/BookReservation.cs`

**1. Genel Bakış**
`BookReservation`, bir kitabın bir müşteri tarafından belirli bir tarihte rezerve edilmesini temsil eden domain entity’sidir. Rezervasyon tarihi, bitiş tarihi, durum ve sıra bilgisi gibi alanları içerir. Domain katmanına aittir.

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
| Book | `public Book Book { get; set; }` | İlişkili `Book` navigasyon özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | Rezervasyonu yapan müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | İlişkili `Customer` navigasyon özelliği. |
| ReservationDate | `public DateTime ReservationDate { get; set; }` | Rezervasyonun oluşturulduğu tarih/saat. |
| ExpiryDate | `public DateTime ExpiryDate { get; set; }` | Rezervasyonun sona ereceği tarih/saat. |
| Status | `public ReservationStatus Status { get; set; }` | Rezervasyon durumu (varsayılan: `Pending`). |
| Notes | `public string? Notes { get; set; }` | İsteğe bağlı notlar. |
| QueuePosition | `public int QueuePosition { get; set; }` | Rezervasyon kuyruğundaki sıra. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Status = ReservationStatus.Pending`; `Book` ve `Customer` null-forgiving ile işaretlenmiş; `Notes` null olabilir; `QueuePosition` varsayılanı 0.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `Book`, `Customer`, `ReservationStatus`, `BaseEntity`.

Genel Değerlendirme
- Kod sadece Domain katmanından bir entity sunuyor; diğer katmanlar, veri erişimi, servisler ve API yüzeyleri bu repoda veya bu kesitte görünmüyor.
- Validasyon, durum geçiş kuralları ve tarih tutarlılıkları (`ReservationDate <= ExpiryDate` gibi) entity üzerinde tanımlı değil; muhtemelen başka katmanlara bırakılmış, ancak bu dosyadan teyit edilemiyor.
- `BaseEntity` içeriği belirsiz; kimlik, zaman damgaları veya concurrency alanları varsa burada görülmüyor.### Project Overview
- Proje Adı: Library
- Amaç: Kitaplara yönelik inceleme/puanlama verilerini modelleyen domain varlıkları sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Temiz Mimari (Clean Architecture) ipuçları — bu dosya Domain katmanını temsil ediyor. Domain katmanı iş kurallarını ve çekirdek modelleri barındırır; uygulama, altyapı ve sunum katmanları bu varlıklara bağımlıdır.
- Keşfedilen Proje/Assembly’ler:
  - Library.Domain — Domain varlıkları ve olası temel tipler (ör. `BaseEntity`).
- Kullanılan Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]
(tek katman keşfedildi; diğer katmanlara ilişkin bağımlılık akışı bu dosyadan anlaşılmıyor)

---

### `Library.Domain/Entities/BookReview.cs`

**1. Genel Bakış**
`BookReview`, bir kitaba ait müşteri incelemesini ve puanını temsil eden domain varlığıdır. Domain katmanında yer alır ve kitap, müşteri, puan ve onay durumu gibi temel inceleme özelliklerini taşır.

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
| BookId | `public Guid BookId { get; set; }` | İncelemenin ilişkilendirildiği kitabın kimliği. |
| Book | `public Book Book { get; set; }` | İlgili kitap navigasyon özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | İncelemeyi yapan müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | İlgili müşteri navigasyon özelliği. |
| Rating | `public int Rating { get; set; }` | İnceleme puanı (aralık validasyonu bu dosyada yok). |
| Title | `public string? Title { get; set; }` | İncelemenin başlığı (opsiyonel). |
| Comment | `public string? Comment { get; set; }` | İnceleme metni (opsiyonel). |
| IsApproved | `public bool IsApproved { get; set; }` | İncelemenin onay durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Book` ve `Customer` null bastırma ile atanmış (`null!`); `IsApproved` varsayılan `false`; `Title` ve `Comment` `null` olabilir. Puan aralığına dair validasyon veya onay akışı bu dosyada tanımlı değil.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `Book`, `Customer`, `BaseEntity` (tanımları bu dosyada yok).

---

### Genel Değerlendirme
- Domain katmanından yalnızca bir entity görülebiliyor; `BaseEntity`, `Book`, `Customer` tanımları ve diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Validasyon (ör. `Rating` aralığı), onay süreci ve iş kurallarına dair davranışlar entity içinde yer almıyor; bu kurallar muhtemelen başka katmanlarda ele alınmalıdır.### Project Overview
Proje adı: Library. Amaç: Kütüphane sisteminde müşteri (üye) bilgilerini ve ilişkili işlemleri (ödünç, rezervasyon, inceleme, ceza, bildirim) temsil etmek. Hedef çerçeve: Bu dosyadan kesin tespit edilemiyor; modern C# sözdizimi kullanımı (koleksiyon için [] başlatma) .NET 7+ olabileceğini düşündürür, ancak bu dosyadan anlaşılmıyor.

Mimari desen: Domain merkezli katmanlı yapı. Kod sadece Domain katmanını gösteriyor; varlıklar ve enum’lar burada tanımlı. Diğer katmanlar (Application, Infrastructure, API) bu depoda görünmüyor.

Bulunan projeler/assembly’ler:
- Library.Domain — Domain varlıkları ve enum’ları; iş kurallarının çekirdeği.

Kullanılan dış paketler/çerçeveler: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (çekirdek, bağımlılık yok)
  ↑
(diğer katmanlar muhtemelen buna referans verir; bu depoda görünmüyor)

---
### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer` kütüphane üyesini temsil eden domain varlığıdır; kimlik ve iletişim bilgileri, üyelik durumu ve kitap işlemleriyle ilişkili koleksiyonları tutar. Mimari olarak Domain katmanına aittir ve muhtemelen ORM eşlemeleriyle kalıcı hale getirilir.

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
| FirstName | `public string FirstName { get; set; }` | Üyenin adı. |
| LastName | `public string LastName { get; set; }` | Üyenin soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres. |
| City | `public string City { get; set; }` | Şehir. |
| PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| MembershipType | `public MembershipType MembershipType { get; set; }` | Üyelik tipi (`Library.Domain.Enums`). |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| MembershipExpiryDate | `public DateTime? MembershipExpiryDate { get; set; }` | Üyelik bitiş tarihi (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| MaxBooksAllowed | `public int MaxBooksAllowed { get; set; }` | Maksimum ödünç kitap sayısı. |
| ProfileImageUrl | `public string? ProfileImageUrl { get; set; }` | Profil resmi URL’si (opsiyonel). |
| DateOfBirth | `public DateTime? DateOfBirth { get; set; }` | Doğum tarihi (opsiyonel). |
| BookLoans | `public ICollection<BookLoan> BookLoans { get; set; }` | Üyenin ödünç aldığı kitaplar. |
| BookReservations | `public ICollection<BookReservation> BookReservations { get; set; }` | Üyenin rezervasyonları. |
| BookReviews | `public ICollection<BookReview> BookReviews { get; set; }` | Üyenin kitap incelemeleri. |
| Fines | `public ICollection<Fine> Fines { get; set; }` | Üyeye kesilen cezalar. |
| Notifications | `public ICollection<Notification> Notifications { get; set; }` | Üyeye gönderilen bildirimler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName/LastName/Email/Phone/Address/City/MembershipNumber = string.Empty`, `MembershipType = MembershipType.Basic`, `IsActive = true`, `MaxBooksAllowed = 5`, koleksiyonlar `[]` ile boş başlatılır, `PostalCode/ProfileImageUrl/DateOfBirth/MembershipExpiryDate = null`, `RegisteredDate` için varsayılan verilmemiş (DateTime default’u olabilir).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BookLoan`, `BookReservation`, `BookReview`, `Fine`, `Notification` (ilişkili entity’ler); `MembershipType` (enum).
- **İlişkili tipler:** `BaseEntity` (ortak kimlik/zaman damgası gibi üyeler barındırıyor olabilir; bu dosyadan içerik görülmüyor).

**7. Eksikler ve Gözlemler**
- Doğrulama kuralları (zorunlu alanlar, e-posta formatı, `MaxBooksAllowed > 0` gibi) kod üzerinde tanımlı değil.
- `RegisteredDate` için otomatik atama veya oluşturulma zamanı yönetimi görünmüyor.
- İlişkili entity tiplerinin tanımları bu depoda görünmediği için ilişki tarafı ve kısıtlar belirsiz.

---
Genel Değerlendirme
- Kod tabanı yalnızca Domain katmanından bir entity göstermektedir; diğer katmanlar ve altyapı detayları bu dosyadan çıkarılamıyor.
- Entity üzerinde doğrulama/koruyucu iş kuralları ve davranışlar tanımlı değil; tüm alanlar set edilebilir durumda.
- Varsayılan değerler mantıklı seçilmiş (aktif üye, temel üyelik, koleksiyonların boş başlatılması); ancak kayıt tarihi ve üyelik bitiş tarihi gibi alanlar için yaşam döngüsü yönetimi net değil.
- Güvenlik, yetkilendirme, veri erişim ve konfigürasyonla ilgili çıkarımlar bu dosyadan yapılamıyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı)
- Amaç: Kütüphane alan modelini tanımlamak; borç/ceza gibi temel domain varlıklarını temsil etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean-vari yapı; Domain katmanı mevcut. Diğer katmanlar (Application, Infrastructure, API) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıkları ve enum’ları.
- Kullanılan ana paketler/çerçeveler: Bu dosyadan anlaşılmıyor (harici paket referansı görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)

---

### `Library.Domain/Entities/Fine.cs`

**1. Genel Bakış**
`Fine` bir kütüphane cezası varlığıdır; bir kitap ödünç alma (`BookLoan`) ve müşteri (`Customer`) ile ilişkilidir, tutar ve durum gibi bilgileri taşır. Domain katmanına aittir ve muhtemelen veri katmanı tarafından kalıcı hale getirilmek üzere tasarlanmış bir entity’dir.

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
| BookLoanId | `public Guid BookLoanId { get; set; }` | İlişkili kitap ödünç alma kaydının kimliği. |
| BookLoan | `public BookLoan BookLoan { get; set; }` | İlişkili `BookLoan` gezinim özelliği. |
| CustomerId | `public Guid CustomerId { get; set; }` | İlişkili müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | İlişkili `Customer` gezinim özelliği. |
| Amount | `public decimal Amount { get; set; }` | Ceza tutarı. |
| Reason | `public string Reason { get; set; }` | Ceza nedeni. |
| Status | `public FineStatus Status { get; set; }` | Ceza durumu. |
| PaidDate | `public DateTime? PaidDate { get; set; }` | Ödendiği tarih (varsa). |
| PaymentMethod | `public string? PaymentMethod { get; set; }` | Ödeme yöntemi (varsa). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Reason = string.Empty`, `Status = FineStatus.Pending`. `BookLoan` ve `Customer` için null-bang (`= null!`) ile işaretlenmiş; değer ataması çalışma zamanında beklenir. `PaidDate` ve `PaymentMethod` isteğe bağlıdır (nullable).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BaseEntity`, `BookLoan`, `Customer`, `FineStatus`.
- **İlişkili tipler:** `Library.Domain.Enums.FineStatus`, `Library.Domain.Entities.BookLoan`, `Library.Domain.Entities.Customer`, `BaseEntity` (aynı assembly içi varsayılır).

**7. Eksikler ve Gözlemler**
- `Amount` için negatif değeri engelleyen bir validasyon bulunmuyor (bu dosyadan anlaşılabildiği kadarıyla).
- `BookLoan` ve `Customer` özellikleri `null!` ile işaretlenmiş; ORM dışında kullanımda atama yapılmazsa çalışma zamanı hatalarına yol açabilir.

---

Genel Değerlendirme
- Kod, Domain katmanındaki entity tanımını içeriyor; mimarinin geri kalan katmanları bu dosyadan görülemiyor.
- Varlık üzerinde iş kuralı/validasyon bulunmuyor; bu kuralların Application veya Domain hizmetlerinde ele alınması gerekebilir.
- Nullability yönetimi `null!` ile ertelenmiş; yükleme stratejileri (ORM mapping) net değil.### Project Overview
Proje adı: Library. Amaç: bir kütüphane alan modelini temsil etmek; şubeler, kitaplar ve personel gibi kavramların domain katmanında tanımlanması. Hedef çatı: en az .NET 6 (TimeOnly kullanımı bunu gerektirir).

Mimari: Katmanlı/Clean Architecture eğilimli. Bu depoda görülen katman Domain olup, davranış ve kuralların merkezi olan entity tanımlarını içerir. Uygulama, Altyapı ve Sunum katmanları bu dosyadan görülmüyor.

Projeler/Assembly’ler:
- Library.Domain: Domain entity’leri ve temel tipler (ör. `BaseEntity`).

Harici paketler/çerçeveler: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
[Library.Domain]
  ^ (diğer katmanlar bu domain katmanına bağımlı olur; bu depoda görünmüyor)

---
### `Library.Domain/Entities/LibraryBranch.cs`

**1. Genel Bakış**
`LibraryBranch`, bir kütüphane şubesinin temel alan özelliklerini (ad, adres, çalışma saatleri, iletişim ve konum bilgileri) ve ilişkilerini (`Books`, `Staff`) temsil eden domain entity’sidir. Domain katmanına aittir ve muhtemelen veri erişim/iş mantığı katmanlarınca persist ve işlenir.

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
| Name | `public string Name { get; set; }` | Şube adı. Varsayılan `string.Empty`. |
| Address | `public string Address { get; set; }` | Adres. Varsayılan `string.Empty`. |
| City | `public string City { get; set; }` | Şehrin adı. Varsayılan `string.Empty`. |
| PostalCode | `public string? PostalCode { get; set; }` | Posta kodu (opsiyonel). |
| Phone | `public string Phone { get; set; }` | Telefon numarası. Varsayılan `string.Empty`. |
| Email | `public string? Email { get; set; }` | E-posta (opsiyonel). |
| Description | `public string? Description { get; set; }` | Açıklama (opsiyonel). |
| OpeningTime | `public TimeOnly OpeningTime { get; set; }` | Açılış saati. |
| ClosingTime | `public TimeOnly ClosingTime { get; set; }` | Kapanış saati. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. Varsayılan `true`. |
| Latitude | `public double? Latitude { get; set; }` | Enlem (opsiyonel). |
| Longitude | `public double? Longitude { get; set; }` | Boylam (opsiyonel). |
| Books | `public ICollection<Book> Books { get; set; }` | İlişkili kitaplar koleksiyonu. Varsayılan boş koleksiyon. |
| Staff | `public ICollection<Staff> Staff { get; set; }` | İlişkili personel koleksiyonu. Varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Address = string.Empty`, `City = string.Empty`, `Phone = string.Empty`, `IsActive = true`, `Books` ve `Staff` boş koleksiyonla başlar. `PostalCode`, `Email`, `Description`, `Latitude`, `Longitude` opsiyoneldir. Zaman alanlarında (örn. `OpeningTime < ClosingTime`) bir tutarlılık kontrolü bu sınıfta uygulanmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Domain servisleri, repository’ler, uygulama/altyapı katmanları tarafından kullanılabilir (bu dosyadan kesin olarak anlaşılmıyor).
- **Aşağı akış:** Harici bağımlılık yok; ancak navigation olarak `Book`, `Staff` entity’leriyle ilişkilidir.
- **İlişkili tipler:** `Book`, `Staff`, `BaseEntity`.

**7. Eksikler ve Gözlemler**
- `OpeningTime` ve `ClosingTime` için mantıksal saat aralığı validasyonu bu seviyede yok.
- İletişim ve adres alanlarında biçim/doğrulama (ör. telefon/e-posta formatı) sınıf içinde tanımlı değil; muhtemelen üst katmanlarda bekleniyor.

---
### Genel Değerlendirme
Kod tabanında sadece Domain katmanından tek bir entity görülüyor. Clean/katmanlı mimariye uygun olarak entity sade tutulmuş; davranış ve validasyon üst katmanlara bırakılmış gibi duruyor. Diğer katmanlar (Application, Infrastructure, API) ve kalıplar (ör. repository, DbContext, configuration) bu girdiyle görünmediğinden, proje genelindeki bağımlılık akışı ve kurallar tam değerlendirilemiyor.### Project Overview
Proje adı: Library (çıkarım: `Library.Domain` ad alanı). Amaç: Kütüphane alan modelini temsil eden domain varlıklarını sağlamak; bildirime ilişkin temel veri yapıları burada tanımlanmış. Hedef çatı/framework bu dosyadan anlaşılmıyor.

Mimari: Katmanlı/Clean Architecture eğilimli yapı; görülen katman Domain. Domain katmanı, iş kurallarını ve entity tanımlarını barındırır; altyapı (persistans), uygulama servisleri ve sunum katmanı bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Domain — Domain katmanı; entity ve enum tanımları.

Dış paketler/çatı: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] (Domain)
  (Diğer katmanlar bu depoda/çekirdekte görünmüyor)

---
### `Library.Domain/Entities/Notification.cs`

**1. Genel Bakış**
`Notification`, bir müşteriye ait bildirim verisini temsil eden domain entity’sidir. Başlık, mesaj, tip, okunma ve gönderim zamanları gibi bildirim meta-verilerini tutar. Domain katmanına aittir.

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
| CustomerId | `public Guid CustomerId { get; set; }` | Bildirimin ait olduğu müşterinin kimliği. |
| Customer | `public Customer Customer { get; set; }` | Bildirimin ilişkili müşteri navigasyon özelliği. |
| Title | `public string Title { get; set; }` | Bildirimin başlığı. |
| Message | `public string Message { get; set; }` | Bildirimin metni. |
| Type | `public NotificationType Type { get; set; }` | Bildirim türü (enum). |
| IsRead | `public bool IsRead { get; set; }` | Bildirim okunma durumu. |
| ReadAt | `public DateTime? ReadAt { get; set; }` | Okunduğu tarih/zaman. |
| SentAt | `public DateTime? SentAt { get; set; }` | Gönderildiği tarih/zaman. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Message = string.Empty`, `Customer` için `null!` (zorunlu kabul edilmiş), `IsRead = false` (bool default), `Type = default(NotificationType)`, `ReadAt = null`, `SentAt = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor.
- **İlişkili tipler:** `Customer` (ilgili entity), `NotificationType` (enum), `BaseEntity` (temel sınıf).

Genel Değerlendirme
- Depoda yalnızca Domain’de bir entity görünür durumda; diğer katmanlar (Application/Infrastructure/API) ve kalıplar bu parçadan anlaşılamıyor.
- Entity’de doğrulama mantığı yok; başlık/mesaj uzunluğu veya zorunluluk kontrollerinin nerede yapıldığı belirsiz. Bu, genellikle Application katmanında veya ORM seviyesinde ele alınır, ancak bu depoda görünmüyor.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Kütüphane alanındaki temel varlıkları modellemek; bu parçada yayınevi (`Publisher`) bilgisini temsil eden domain entity tanımlı.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: En az bir Domain katmanı mevcut. İsimlendirme, katmanlı bir yapı kullandığını (ör. Domain katmanı) gösteriyor; diğer katmanlar bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları ve temel modelleri içerir.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]
  (başka katman/bağımlılık bu dosyadan görünmüyor)

---
### `Library.Domain/Entities/Publisher.cs`

**1. Genel Bakış**
`Publisher` domain katmanında bir yayınevini temsil eden entity’dir. Ad, iletişim ve kuruluş yılı gibi temel meta verileri ve yayınevine ait `Book` koleksiyonunu tutar. Veri erişim ve iş kuralları üst katmanlarda ele alınmak üzere saf model olarak konumlanmış.

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
| Name | `public string Name { get; set; }` | Yayınevinin adı; varsayılanı `string.Empty`. |
| Address | `public string? Address { get; set; }` | Adres bilgisi; opsiyonel. |
| City | `public string? City { get; set; }` | Şehir; opsiyonel. |
| Country | `public string? Country { get; set; }` | Ülke; opsiyonel. |
| Phone | `public string? Phone { get; set; }` | Telefon; opsiyonel. |
| Email | `public string? Email { get; set; }` | E-posta; opsiyonel. |
| Website | `public string? Website { get; set; }` | Web sitesi; opsiyonel. |
| FoundedYear | `public int? FoundedYear { get; set; }` | Kuruluş yılı; opsiyonel. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu; varsayılanı `true`. |
| Books | `public ICollection<Book> Books { get; set; }` | İlişkili kitaplar; varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılanlar: `Name = string.Empty`, `IsActive = true`, `Books` boş koleksiyonla başlar.
- Tüm iletişim ve konum alanları opsiyoneldir (nullable).
- İş kuralları ve validasyonlar bu sınıfta tanımlı değildir; bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Book` (navigasyon), `BaseEntity` (kalıtım).

**7. Eksikler ve Gözlemler**
- `Name` için zorunluluk/boş olamaz validasyonu yok; domain seviyesinde guard/validation beklenebilir.
- `Email` formatı, `Website` URL formatı ve `FoundedYear` aralık kontrolü gibi alan validasyonları tanımlı değil.

---
Genel Değerlendirme
- Kod, Domain katmanında yalın entity tanımı sunuyor; başka katmanlar görünür değil.
- Domain içi validasyon/koruyucu kurallar bulunmuyor; bu kuralların Application veya Domain seviyesinde eklenmesi düşünülebilir.
- `BaseEntity` ve `Book` tanımları görünmediğinden ilişki ve kimlik stratejileri (Id, audit vb.) bu dosyadan çıkarılamıyor.### Project Overview
Proje adı: Library. Bu dosyadan görüldüğü kadarıyla bir kütüphane yönetim sistemi için Domain katmanında yer alan entity’ler tanımlanıyor. Hedef framework bu dosyadan anlaşılmıyor. Mimari, adlandırmadan ve katman isminden Clean Architecture/N-Tier yaklaşımını çağrıştırıyor; burada Domain katmanı iş kurallarının merkezindeki entity ve değer tiplerini barındırır. Keşfedilen projeler/assembly’ler: Library.Domain — Domain entity’leri ve enum’ları. Görünen harici paket veya framework referansı yok. Yapılandırma gereksinimleri (connection string, appsettings) bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Enums)
  └─ (Bağımlılık yönü bu dosyadan anlaşılmıyor; Domain katmanı genelde diğer katmanlarca referans alınır)

---
### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff`, kütüphane personelini temsil eden bir domain entity’sidir. Personelin kimlik, iletişim, rol, istihdam ve ilişki bilgilerini taşır. Mimari olarak Domain katmanına aittir ve muhtemelen kalıcılık haritalaması Infrastructure tarafından yapılır.

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
| Position | `public string Position { get; set; }` | Pozisyon/unvan bilgisi. |
| Role | `public StaffRole Role { get; set; }` | Personel rolü (`StaffRole`). |
| Salary | `public decimal? Salary { get; set; }` | Maaş (opsiyonel). |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| TerminationDate | `public DateTime? TerminationDate { get; set; }` | İşten ayrılma tarihi (opsiyonel). |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |
| EmployeeNumber | `public string? EmployeeNumber { get; set; }` | Personel/çalışan numarası (opsiyonel). |
| LibraryBranchId | `public Guid? LibraryBranchId { get; set; }` | İlişkili şube kimliği (opsiyonel). |
| LibraryBranch | `public LibraryBranch? LibraryBranch { get; set; }` | Navigasyon: bağlı şube. |
| ProcessedLoans | `public ICollection<BookLoan> ProcessedLoans { get; set; }` | Navigasyon: personelin işlediği ödünç işlemleri. |

**5. Temel Davranışlar ve İş Kuralları**
- Varsayılanlar: `FirstName/LastName/Email/Phone/Position = string.Empty`, `Role = StaffRole.Librarian`, `IsActive = true`.
- `Salary`, `TerminationDate`, `EmployeeNumber`, `LibraryBranchId`, `LibraryBranch` opsiyoneldir.
- `ProcessedLoans` boş koleksiyonla başlatılır.
- Doğrulama ve iş kuralı uygulanmaz; sadece veri taşıma ve ilişki tanımı yapılır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `LibraryBranch`, `BookLoan`, `StaffRole` (enum).
- **İlişkili tipler:** `LibraryBranch`, `BookLoan`, `StaffRole`, `BaseEntity`.

**7. Eksikler ve Gözlemler**
- Email, Phone gibi alanlarda doğrulama yok; domain seviyesinde temel doğrulamalar düşünülebilir.
- Personel durum geçişleri (ör. `TerminationDate` set edilince `IsActive` otomatik false) gibi tutarlılık kuralları uygulanmıyor.

---
Genel Değerlendirme
- Kod yalnızca Domain katmanından tek bir entity içeriyor; Clean Architecture’a uygun bir ayrışımın parçası gibi görünüyor ancak diğer katmanlar görünmüyor.
- Domain entity’sinde doğrulama ve invariants eksik; temel kuralların (zorunlu alanlar, format, durum geçişleri) entity içinde veya domain servislerinde tanımlanması önerilir.
- Harici paket, konfigurasyon, hedef framework ve diğer projeler bu dosyadan çıkarılamıyor; tam mimari resmi görmek için diğer katmanların incelenmesi gerekir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına ait iş kurallarını destekleyen domain sabitlerini (durumlar, roller, tipler) tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture işaretleri mevcut; `Library.Domain` bir Domain katmanı olarak konumlanıyor. Diğer katmanlar bu dosyadan teyit edilemiyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain modelleri ve sabitleri (enum’lar).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  ↑ kullanılabilir (Application/Infrastructure/API) — bu dosyadan doğrulanmıyor

---
### `Library.Domain/Enums/Enums.cs`

**1. Genel Bakış**
Kütüphane iş alanına ait durum ve sınıflandırmaları temsil eden bir dizi `enum` tanımlar: ödünç, rezervasyon, ceza, bildirim, üyelik, kitap durumu ve personel rolü. Domain katmanına aittir ve tutarlı durum/akış modellemesi için sabit değerleri merkezileştirir.

**2. Tip Bilgisi**
- **Tip:** enum’lar (7 adet)
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Enums`

Tanımlı enum’lar:
- `LoanStatus` — `Active, Returned, Overdue, Lost`
- `ReservationStatus` — `Pending, Confirmed, Cancelled, Fulfilled, Expired`
- `FineStatus` — `Pending, Paid, Waived`
- `NotificationType` — `LoanDueReminder, LoanOverdue, ReservationReady, ReservationExpired, FineIssued, General`
- `MembershipType` — `Basic, Standard, Premium, Student, Senior`
- `BookCondition` — `New, Good, Fair, Poor, Damaged, Lost`
- `StaffRole` — `Librarian, SeniorLibrarian, AssistantManager, Manager, Director, ITSupport, Volunteer`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| LoanStatus | `public enum LoanStatus { Active, Returned, Overdue, Lost }` | Ödünç verme yaşam döngüsü durumları. |
| ReservationStatus | `public enum ReservationStatus { Pending, Confirmed, Cancelled, Fulfilled, Expired }` | Rezervasyon süreç durumları. |
| FineStatus | `public enum FineStatus { Pending, Paid, Waived }` | Ceza tahsilat durumları. |
| NotificationType | `public enum NotificationType { LoanDueReminder, LoanOverdue, ReservationReady, ReservationExpired, FineIssued, General }` | Bildirim kategorileri. |
| MembershipType | `public enum MembershipType { Basic, Standard, Premium, Student, Senior }` | Üyelik tipleri. |
| BookCondition | `public enum BookCondition { New, Good, Fair, Poor, Damaged, Lost }` | Kitap fiziksel durumları. |
| StaffRole | `public enum StaffRole { Librarian, SeniorLibrarian, AssistantManager, Manager, Director, ITSupport, Volunteer }` | Personel rol hiyerarşisi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: Her `enum` için temel değer alındığında ilk üye (`0`) seçilir (ör. `LoanStatus.Active`, `FineStatus.Pending`).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod yalnızca Domain katmanında enum sabitleri içeriyor; diğer katmanlar ve kullanım bağlamları bu dosyadan görülemiyor.
- Mimari işaretler Clean Architecture uyumlu; ancak Application/Infrastructure/API projeleri teyit edilmedi.
- Dış paket/konfigürasyon bağımlılığı bulunmuyor; isimlendirmeler alan modelinde tutarlı ve kapsamlı.### Project Overview
Proje adı: Library (çıkarım: `Library.Domain` namespace’i). Amaç: Kütüphane alan modeline ait denetim/audit günlükleri için repository sözleşmesi tanımlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor.
Mimari: Katmanlı/Clean benzeri ayrım; bu dosya Domain katmanında bir repository arayüzü barındırıyor. Uygulama akışında altyapı (Infrastructure) bu arayüzü implemente eder, üst katmanlar sözleşmeye göre çalışır.
Projeler/Assembly’ler:
- Library.Domain — Domain varlıkları ve arayüzleri (Entities, Interfaces)
Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---

### `Library.Domain/Interfaces/IAuditLogRepository.cs`

**1. Genel Bakış**
`IAuditLogRepository`, `AuditLog` varlığı için sorgu odaklı repository sözleşmesini tanımlar. Amaç, denetim günlüklerinin varlık, kullanıcı veya tarih aralığına göre okunmasını soyutlamaktır. Domain katmanına aittir; implementasyonu muhtemelen altyapı katmanında sağlanır.

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
| GetByEntityAsync | `Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId)` | Belirli bir varlık adı ve kimliği için audit log kayıtlarını döndürür. |
| GetByUserAsync | `Task<IEnumerable<AuditLog>> GetByUserAsync(string userId)` | Belirli bir kullanıcı için audit log kayıtlarını döndürür. |
| GetByDateRangeAsync | `Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)` | Verilen tarih aralığındaki audit log kayıtlarını döndürür. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz sözleşmesi; davranış implementasyona bırakılmıştır.
- Sorgular asenkron desenle tanımlıdır (`Task<IEnumerable<AuditLog>>`).
- Filtreleme kriterleri: varlık adı + `Guid` kimlik, kullanıcı kimliği (`string`), tarih aralığı (`DateTime`-`DateTime`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `AuditLog` (entity), `IRepository<AuditLog>` (genel repository sözleşmesi).
- **İlişkili tipler:** `Library.Domain.Entities.AuditLog`, `Library.Domain.Interfaces.IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `IRepository<AuditLog>` tanımı bu depoda gösterilmediğinden temel CRUD sözleşmesinin kapsamı bu dosyadan anlaşılamıyor.
- Metot adları yalnızca sorgu operasyonlarını kapsıyor; ek filtreler (ör. aksiyon tipi, kaynak IP) gerekiyorsa arayüz genişletilmesi gerekebilir.

---

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanından tek bir arayüz görünür durumda; diğer katmanlar ve implementasyonlar bu dosyadan anlaşılamıyor.
- Mimari olarak domain sözleşmesi ayrımı doğru; ancak tam resmi görmek için `AuditLog` varlığı, `IRepository<T>` ve Infrastructure/Application katmanı implementasyonları gerekir.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı)
- Amaç: Kütüphane alan modelini ve alan sözleşmelerini (repository arayüzleri vb.) tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli — Domain katmanı mevcut (entity ve repository sözleşmeleri).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain entity’leri ve repository arayüzleri (iş kurallarının merkezi sözleşmeleri).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Unknown consumers] -> Library.Domain (Entities, Interfaces)

---
### `Library.Domain/Interfaces/IAuthorRepository.cs`

**1. Genel Bakış**
`IAuthorRepository`, `Author` entity’si için repository sözleşmesini genişletir ve alan odaklı iki ek operasyon sunar: arama ve ilişkili kitaplarla birlikte getirme. Domain katmanında yer alır ve persistence/infrastructure katmanında uygulanmak üzere kontrat sağlar.

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
| SearchAsync | `Task<IEnumerable<Author>> SearchAsync(string searchTerm)` | Verilen arama terimine göre `Author` koleksiyonu döndürür. |
| GetWithBooksAsync | `Task<Author?> GetWithBooksAsync(Guid id)` | Belirtilen kimlikle `Author`’ı ilişkili kitaplarıyla birlikte getirir; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Arama işlemi için `searchTerm` kullanılır; eşleşme ölçütü ve büyük/küçük harf duyarlılığı bu dosyadan anlaşılmıyor.
- `GetWithBooksAsync` ilişkili “Books” navigasyonunu yüklemeyi amaçlar; yükleme stratejisi (eager/explicit) implementasyona bırakılmıştır.
- Dönüş tipleri asenkron desenleri izler (`Task`, `Task<T>`); iptal desteği bu dosyadan anlaşılmıyor.
- `IRepository<Author>` üzerinden temel CRUD sözleşmelerini de devralır; kapsamı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `IRepository<Author>` sözleşmesine dayanır.
- İlişkili tipler: `Author` (entity), `IRepository<T>` (genel repository arayüzü).

Genel Değerlendirme
- Sadece Domain katmanı görünür; diğer katmanlar ve bağımlılıklar bu dosyadan anlaşılamıyor.
- `IRepository<Author>` içeriği görünmediği için tam sözleşme kapsamı belirsiz.
- Metotlarda iptal belirteci (`CancellationToken`) bulunmuyor; geniş ölçekte asenkron IO operasyonlarında iptal desteği gerekebilir.### Project Overview
Proje adı: Library. Amaç: kütüphane etki alanında kategori yönetimi (kitap kategorileri) için sözleşmeler tanımlamak. Kod tabanında yalnızca Domain katmanına ait bir arayüz görünmektedir. Hedef çerçeve sürümü bu dosyadan anlaşılmıyor.

Mimari desen: Clean Architecture/N‑Katmanlı yaklaşıma uygun bir yapı sinyali var; Domain katmanı içinde `Entities` ve `Interfaces` ayrımı mevcut. Domain katmanı iş kuralları ve sözleşmeleri tanımlar, veri erişimi ve uygulama hizmetleri diğer katmanlarda beklenir (bu depoda gösterilmemiş).

Keşfedilen projeler/assembly’ler:
- Library.Domain — Etki alanı varlıkları (`Entities`) ve repository arayüzleri (`Interfaces`) içerir.

Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---
### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlıkları için depolama erişim sözleşmesini tanımlar. Kategori adıyla arama, ilişkili kitaplarla birlikte getirme ve hiyerarşik kategori sorguları için özel metotlar sağlar. Domain katmanına aittir ve Infrastructure katmanında somutlanması beklenir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** `IRepository<BookCategory>`
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre tek bir kategoriyi asenkron olarak getirir. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Belirli kategoriyi ilişkili kitaplarıyla birlikte yükler. |
| GetActiveCategoriesAsync | `Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync()` | Aktif durumdaki tüm kategorileri döndürür. |
| GetRootCategoriesAsync | `Task<IEnumerable<BookCategory>> GetRootCategoriesAsync()` | Üst kategorisi olmayan kök kategorileri listeler. |
| GetSubCategoriesAsync | `Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId)` | Belirli bir üst kategoriye bağlı alt kategorileri döndürür. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme, isimle tekil/benzersiz getirme beklentisi ima eder; bulunamazsa `null` döner.
- Hiyerarşik yapı desteği: kök ve alt kategori sorguları.
- `GetWithBooksAsync`, ilişkili koleksiyonun eager loading ile getirilmesine yönelik niyet bildirir.
- İade koleksiyonlarının sıralama veya sayfalama davranışı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama/Servis katmanı, domain hizmetleri veya API katmanı üzerinden çağrılır; DI üzerinden çözümlenir.
- **Aşağı akış:** `IRepository<BookCategory>` uygulaması ve veri erişim altyapısı.
- **İlişkili tipler:** `Library.Domain.Entities.BookCategory`, `Library.Domain.Interfaces.IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `IRepository<BookCategory>` tanımı bu depoda görünmüyor; kontratın ayrıntıları belirsiz.
- Filtreleme, sıralama ve sayfalama için parametrik metotlar yok; büyük veri setlerinde performans/ergonomi eksikliği olabilir.
- “Aktif” kriterinin neye göre belirlendiği (ör. `IsActive` alanı) Domain entity’sinde görülmediğinden net değil.

---

Genel Değerlendirme
- Yalnızca Domain katmanından bir arayüz mevcut; Application/Infrastructure/API katmanları ve somut implementasyonlar görünmüyor.
- Repository sözleşmesi hiyerarşi ve eager loading ihtiyacını iyi yansıtıyor, ancak sayfalama/sıralama gibi çapraz kesen endişeler için genişleme noktaları eksik.
- Çapraz kesen kaygılar (caching, transaction yönetimi, hata stratejisi) bu dosyadan anlaşılamıyor; üst katmanlarda ele alınması beklenir.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı)
- Amaç: Kütüphane ödünç verme alanına ait domain kontratlarını tanımlamak; özellikle kitap ödünçleme (`BookLoan`) için repository sözleşmesini sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Domain katmanı arayüz ve temel tipleri içerir; uygulama, altyapı ve sunum katmanları bu dosyadan görünmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain katmanı; entity’ler, enum’lar ve repository arayüzleri.
- Kullanılan ana paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  ↑ referenced by Application/Infrastructure/API (bu dosyadan anlaşılmıyor, tipik akış)

---

### `Library.Domain/Interfaces/IBookLoanRepository.cs`

**1. Genel Bakış**
`IBookLoanRepository`, `BookLoan` entity’si için domain odaklı veri erişim sözleşmesini tanımlar. Temel `IRepository<BookLoan>` kontratını genişleterek müşteri, kitap, durum, aktif/gecikmiş gibi iş kurallarına özgü sorgular sağlar. Domain katmanına aittir; implementasyonun Infrastructure katmanında olması beklenir.

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
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm ödünçlerini getirir. |
| GetByBookIdAsync | `Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın tüm ödünç kayıtlarını getirir. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoan>> GetActiveLoansAsync()` | Aktif (iade edilmemiş) ödünç kayıtlarını getirir. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()` | Vadesi geçmiş ödünç kayıtlarını getirir. |
| GetByStatusAsync | `Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)` | Verilen `LoanStatus` durumuna göre ödünçleri getirir. |
| GetWithDetailsAsync | `Task<BookLoan?> GetWithDetailsAsync(Guid id)` | Belirli ödünç kaydını ilişkili detaylarıyla birlikte getirir. |
| GetActiveLoanCountByCustomerAsync | `Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)` | Müşterinin aktif ödünç sayısını döner. |

Not: `IRepository<BookLoan>`’dan gelen üyeler bu dosyada görünmüyor.

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok. Beklenen iş mantığı sinyalleri: aktif/gecikmiş belirleme, durum bazlı filtreleme, müşteri/kitap kimliklerine göre sorgulama, detaylı yükleme (ilişkilerle birlikte).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/use-case’ler tarafından çağrılması beklenir.
- **Aşağı akış:** `IRepository<BookLoan>`, `Library.Domain.Entities.BookLoan`, `Library.Domain.Enums.LoanStatus`
- **İlişkili tipler:** `BookLoan` (entity), `LoanStatus` (enum), `IRepository<T>` (genel repository sözleşmesi)

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri eksik; uzun süren sorgularda faydalı olabilir.
- Büyük veri setleri için sayfalama/seçmeli yükleme parametreleri yok; performans için gözden geçirilebilir.

---

Genel Değerlendirme
- Kod, Domain katmanında repository kontratlarını tanımlayan Clean Architecture yaklaşımını işaret ediyor. Ancak tek dosya üzerinden hedef framework, kullanılan paketler, diğer katmanlar ve konfigürasyonlar belirlenemiyor. Repository metotlarında `CancellationToken` ve sayfalama desteği eklenmesi, altyapı implementasyonlarında performans ve dayanıklılık (ör. include stratejileri, indeksleme) konularına dikkat edilmesi önerilir.### Project Overview
- Proje adı: Library (çıkarım: namespace’lerden)
- Amaç: Kütüphane alan modelinde yer alan `Book` varlıkları için depo (repository) sözleşmesini tanımlamak; kitaplara yönelik sorguları soyutlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Katmanlı — bu dosya Domain katmanında yer alır; entity’ler ve repository arayüzleri gibi iş kurallarını içeren kontratları barındırır. Uygulama/Infrastructure katmanlarının varlığı bu dosyadan çıkarılamaz ancak domain bağımsızdır.
- Projeler/Assembly’ler:
  - Library.Domain — Domain katmanı; entity ve repository arayüzleri.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---

### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlıkları için okuma ve arama odaklı depo sözleşmesini genişletir. Domain katmanında yer alır ve kitapların mevcutluk, ISBN, yazar, kategori, şube ve yayınevi bazlı sorgularını soyutlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Book>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.
- `Book` — domain varlığı (namespace: `Library.Domain.Entities`)
- `IRepository<Book>` — generic repository kontratı (temel CRUD sözleşmesi; bu dosyada tanımı yok)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Mevcut (ödünçte olmayan vb.) kitapları döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre tek bir kitabı getirir; bulunamazsa `null`. |
| GetByAuthorIdAsync | `Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)` | Belirli yazara ait kitapları listeler. |
| GetByCategoryIdAsync | `Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)` | Kategoriye ait kitapları listeler. |
| GetByBranchIdAsync | `Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)` | Kütüphane şubesindeki kitapları listeler. |
| GetByPublisherIdAsync | `Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)` | Yayınevine göre kitapları listeler. |
| SearchAsync | `Task<IEnumerable<Book>> SearchAsync(string searchTerm)` | Serbest metin araması yapar. |
| GetWithDetailsAsync | `Task<Book?> GetWithDetailsAsync(Guid id)` | Kitabı ilişkili detaylarıyla getirir; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Interface — davranış tanımı yok, yalnızca sözleşme.
- Metotların asenkron çalışacağı ve koleksiyon döndüreceği öngörülür; boş sonuçlar için boş koleksiyon/`null` dönüşleri sözleşmede belirtilmiştir.
- `GetWithDetailsAsync` ilgili navigation/detayların eager loading ile getirilmesini ima eder; detay kapsamı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Service katmanı veya Handlers tarafından çağrılması muhtemeldir (bu dosyadan kesin değil).
- **Aşağı akış:** `IRepository<Book>` (temel CRUD), `Book` entity.
- **İlişkili tipler:** `Book`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- Sayfalama/sıralama parametreleri (özellikle `SearchAsync`, listeleme metotlarında) sözleşmede yok; yüksek hacimli veri senaryolarında ihtiyaç olabilir.
- İptal belirteci (`CancellationToken`) parametreleri yok; uzun süren sorgular için faydalı olabilir.

---

Genel Değerlendirme
- Kod, Domain katmanında repository sözleşmesine odaklı ve Clean Architecture ilkeleriyle uyumlu görünüyor.
- Asenkron imzalar doğru; ancak ölçeklenebilirlik için sayfalama/sıralama ve `CancellationToken` desteği eklenmesi düşünülebilir.
- Yalnızca Domain görülebildiğinden, Infrastructure ve Application katmanlarındaki uygulama detayları bu dosyadan anlaşılamıyor.### Project Overview
- Proje adı: Library (görülen ad alanlarına göre)
- Amaç: Kütüphane rezervasyon alanına ait domain sözleşmelerini tanımlamak; özellikle kitap rezervasyonları için repository sözleşmesi sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture benzeri yapı; bu depoda Domain katmanı görünür. Domain katmanı, entity’ler, enum’lar ve repository arayüzlerini içerir; uygulama/altyapı katmanları bu sözleşmeleri uygular ve kullanır (bu dosyadan yalnızca Domain görünür).
- Projeler/Assembly’ler:
  - Library.Domain — Domain entity’leri, enum’ları ve repository arayüzleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IBookReservationRepository.cs`

**1. Genel Bakış**
`IBookReservationRepository`, `BookReservation` varlıkları için sorgu odaklı repository operasyonlarını tanımlayan domain sözleşmesidir. Rezerve kayıtlarını müşteri, kitap, durum ve son kullanma kriterlerine göre getirmeyi sağlar. Domain katmanına aittir ve altyapı katmanında uygulanması beklenir.

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
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)` | Belirtilen müşteriye ait rezervasyonları döndürür. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)` | Belirtilen kitaba ait rezervasyonları döndürür. |
| GetByStatusAsync | `Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)` | Verilen `ReservationStatus` durumundaki rezervasyonları döndürür. |
| GetExpiredReservationsAsync | `Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()` | Süresi dolmuş (expired) rezervasyonları döndürür. |
| GetWithDetailsAsync | `Task<BookReservation?> GetWithDetailsAsync(Guid id)` | İlgili rezervasyonu ilişkili detaylarıyla birlikte (eager load) döndürür; yoksa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez; asenkron okuma/sorgu operasyonlarına yönelik sözleşme tanımlar.
- `GetWithDetailsAsync` ilişki/detay yükleme beklentisini ifade eder; detayların kapsamı bu dosyadan anlaşılmıyor.
- “Expired” kriterinin nasıl hesaplandığı uygulamada belirlenir; sözleşme sadece amacı belirtir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından çağrılması beklenir (bu dosyadan ayrıntı anlaşılmıyor).
- **Aşağı akış:** `IRepository<BookReservation>` temel CRUD sözleşmesi.
- **İlişkili tipler:** `BookReservation`, `ReservationStatus`, `IRepository<BookReservation>`.

Genel Değerlendirme
- Görünen kod yalnızca Domain katmanındaki bir repository arayüzünü içeriyor; altyapı implementasyonları ve uygulama katmanı bu dosyadan görülemiyor.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları belirlenemiyor.
- Sözleşme sorgu odaklıdır; filtreleme/paginasyon gibi gelişmiş erişim kalıpları bu arayüzde tanımlı değil (gereksinime bağlı olarak eklenebilir).### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki etki alanı (Domain) modelleri ve sözleşmelerini tanımlamak; özellikle kitap incelemeleri için repository sözleşmesini sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Domain katmanında `Repository` sözleşmeleriyle Clean Architecture/N‑Tier yaklaşımına uygun ayrışım izleniyor.

Katmanlar:
- Domain: Entity’ler ve interface sözleşmeleri (iş kurallarının merkezi, teknoloji‑agnostik).

Projeler/Assembly’ler:
- Library.Domain — Etki alanı entity’leri ve repository interface’leri.

Harici paketler/çatı: Bu dosyadan anlaşılmıyor.

Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/Application] -> [Library.Domain]

---

### `Library.Domain/Interfaces/IBookReviewRepository.cs`

**1. Genel Bakış**
`IBookReviewRepository`, `BookReview` entity’si için veri erişim sözleşmesini genişleterek kitap ve müşteri bazlı sorgular, onaylı incelemeler ve ortalama puan hesaplaması için metotlar tanımlar. Domain katmanında yer alır ve uygulama/servis katmanlarının veri erişimini soyutlar.

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
| GetByBookIdAsync | `Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)` | Belirli bir kitabın tüm incelemelerini getirir. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)` | Belirli bir müşterinin tüm incelemelerini getirir. |
| GetApprovedReviewsByBookAsync | `Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)` | Belirli bir kitabın onaylanmış incelemelerini getirir. |
| GetAverageRatingByBookAsync | `Task<double> GetAverageRatingByBookAsync(Guid bookId)` | Belirli bir kitabın ortalama puanını döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Interface — davranış içermez; veri erişim sözleşmesi tanımlar.
- `GetApprovedReviewsByBookAsync` onay durumuna göre filtreleme gerektirir (onaylılık ölçütü entity tarafında tanımlıdır; bu dosyadan anlaşılmıyor).
- `GetAverageRatingByBookAsync` için hiç inceleme yoksa dönüş değeri ve yuvarlama stratejisi bu dosyadan anlaşılmıyor (0, NaN veya exception kararı implementasyona bırakılmış görünüyor).

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; Application/Service katmanı bu interface’i kullanır (bu dosyadan anlaşılmıyor).
- Aşağı akış: `IRepository<BookReview>` sözleşmesi (genel CRUD operasyonları).
- İlişkili tipler: `BookReview` entity’si, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `IRepository<BookReview>` ve somut implementasyonlar bu dosyadan görünmüyor; ortalama puan hesaplamasında inceleme yokken davranış belirsiz.

---

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanına ait bir repository interface’i görülüyor. Clean Architecture yönelimli bir katmanlaşma izlenimi var, ancak Application/Infrastructure/Presentation katmanlarına dair kod görünmüyor.
- Ortalama puan, onay filtresi gibi iş kurallarının sözleşmeyle belirtilmesi iyi; yine de metot sözleşmelerinde “boş sonuç/hiç kayıt yok” durumlarının netleştirilmesi (ör. `double?` veya dokümantasyon) faydalı olur.
- Hata yönetimi, transaction, veri doğrulama gibi konular implementasyona bırakılmış; üst katmanlarda tutarlı politika belirlenmesi önerilir.### Project Overview
Proje adı: Library (çıkarım: `Library.*` ad alanları). Amaç: Kütüphane alanına ait müşteri (Customer) odaklı domain sözleşmeleri tanımlamak. Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı mimari (Domain katmanı). Bu katman, entity’ler ve repository sözleşmeleri gibi iş kurallarının merkezindeki soyutlamaları içerir. Uygulama, Altyapı ve Sunum katmanları bu dosyadan anlaşılmıyor ancak Domain’in üstüne inşa edilmeleri beklenir.

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri ve repository arayüzleri (bu depoda görünen tek katman).

Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Interfaces, Entities)
↑
Diğer katmanlar (Application/Infrastructure/API) — bu dosyadan anlaşılmıyor

---
### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` entity’si için depo (repository) sözleşmesini genişletir ve e-posta, üyelik numarası, aktif müşteri listesi, ödünçler ve rezervasyonlarla birlikte yükleme gibi müşteri odaklı sorguları tanımlar. Domain katmanına aittir ve veri erişim detaylarını soyutlayarak üst katmanların (uygulama/servisler) kullanımına yöneliktir.

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
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre müşteriyi asenkron olarak getirir; yoksa `null`. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre müşteriyi getirir; yoksa `null`. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif müşterileri listeler. |
| GetWithLoansAsync | `Task<Customer?> GetWithLoansAsync(Guid id)` | Verilen `id` için müşteriyi, ilişkili ödünçleriyle birlikte getirir. |
| GetWithReservationsAsync | `Task<Customer?> GetWithReservationsAsync(Guid id)` | Verilen `id` için müşteriyi, ilişkili rezervasyonlarıyla birlikte getirir. |
| SearchAsync | `Task<IEnumerable<Customer>> SearchAsync(string searchTerm)` | Arama terimine göre müşterileri arar. |

**5. Temel Davranışlar ve İş Kuralları**
- Null dönebilme: `GetByEmailAsync`, `GetByMembershipNumberAsync`, `GetWithLoansAsync`, `GetWithReservationsAsync` bulunamadığında `null` döner.
- “Aktif” kavramının kriterleri bu dosyadan anlaşılmıyor; implementasyona bırakılmıştır.
- “WithLoans/WithReservations” yöntemleri ilişkisel yüklemeyi (eager/explicit) ifade eder; detaylar altyapı implementasyonuna bağlıdır.
- Arama davranışının (case sensitivity, kısmi eşleşme) ayrıntıları belirtilmemiştir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** Yok (sözleşme).
- **İlişkili tipler:** `Customer` (entity), `IRepository<Customer>` (genel depo sözleşmesi).

### Genel Değerlendirme
- Yalnızca Domain katmanı görünür durumda; `IRepository<T>` ve `Customer` tanımları bu depoda mevcut değilse, projede başka dosyalarda/katmanlarda yer alıyor olmalıdır.
- Yöntemlerin davranış ayrıntıları (aktiflik kriteri, arama kuralları, yükleme stratejisi) implementasyona bırakılmış; dokümantasyon veya ad sözleşmeleriyle netleştirilmesi faydalı olabilir.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` namespace’inden)
- Amaç: Kütüphane alanındaki para cezalarına (`Fine`) yönelik veri erişim sözleşmelerini tanımlamak; domain merkezli repository kontratları sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı mimari (Domain katmanı görünür). Domain, entity’ler, enum’lar ve repository arayüzlerini barındırır. Uygulama/Altyapı/API katmanları bu dosyadan çıkarılamıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain modelleri (örn. `Fine`), enum’lar (`FineStatus`) ve repository arayüzleri (örn. `IFineRepository`).
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor; harici bağımlılık görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor; bağlantı dizesi veya app settings anahtarı referansı yok.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/IFineRepository.cs`

**1. Genel Bakış**
`IFineRepository`, `Fine` varlıkları için domain seviyesinde veri erişim kontratını tanımlar. Müşteri bazlı, durum bazlı ve ödenmemiş ceza toplamı gibi sorgular için sözleşmeler sağlar. Domain katmanına aittir ve uygulama/altyapı katmanlarınca implement edilmesi beklenir.

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
| GetByCustomerIdAsync | `Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)` | Belirli bir müşteriye ait tüm cezaları asenkron getirir. |
| GetByStatusAsync | `Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)` | Verilen `FineStatus` durumundaki cezaları getirir. |
| GetPendingFinesAsync | `Task<IEnumerable<Fine>> GetPendingFinesAsync()` | Bekleyen/ödenmemiş cezaları getirir. |
| GetTotalUnpaidFinesByCustomerAsync | `Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)` | Belirli müşteri için toplam ödenmemiş ceza tutarını hesaplar. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz, `Fine` varlıkları için filtreleme (müşteri, durum, bekleyen) ve toplam ödenmemiş tutar hesaplaması için kontrat sunar.
- İş kuralları ve veri erişim detayları implementasyon katmanında belirlenir; bu dosyada davranış tanımı yok.

**Mantık içermeyen basit DTO/model'ler için** bu bölüm uygulanmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından çağrılması muhtemeldir (bu dosyadan kesinleşmiyor).
- **Aşağı akış:** Bağımlılık yok (sadece sözleşme).
- **İlişkili tipler:** `Library.Domain.Entities.Fine`, `Library.Domain.Enums.FineStatus`, `Library.Domain.Interfaces.IRepository<Fine>`.

---

### Genel Değerlendirme
- Domain katmanında repository kontratı net ve amaca yönelik tanımlanmış.
- Uygulama, altyapı ve sunum katmanlarına dair görünürlük yok; toplam mimariyi bu dosyadan kesinleştirmek mümkün değil.
- Arayüz seviyesinde sorgu ihtiyaçları iyi ayrıştırılmış; implementasyonlarda performans, filtreleme ve hata yönetimi politikalarının belirlenmesi gerekecek.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alan modeli için repository sözleşmelerini tanımlamak; özellikle `LibraryBranch` ile ilgili veri erişim anlaşmalarını belirlemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari — Domain katmanı belirgin. Repository deseni kullanılıyor gibi görünüyor. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain katmanı; entity’ler ve repository arayüzleri barındırır.
- Harici paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)

---

### `Library.Domain/Interfaces/ILibraryBranchRepository.cs`

**1. Genel Bakış**
`ILibraryBranchRepository`, `LibraryBranch` varlıkları için repository sözleşmesini genişleterek özel sorgu ihtiyaçlarını tanımlar. Amaç, aktif şubeleri ve ilgili ilişkilerle (personel, kitaplar) birlikte şube verilerini asenkron olarak elde etmektir. Domain katmanında yer alır.

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
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()` | Aktif durumdaki tüm `LibraryBranch` kayıtlarını döndürür. |
| GetWithStaffAsync | `Task<LibraryBranch?> GetWithStaffAsync(Guid id)` | Belirtilen `id` için şubeyi, ilişkili personel bilgileriyle birlikte yükler. |
| GetWithBooksAsync | `Task<LibraryBranch?> GetWithBooksAsync(Guid id)` | Belirtilen `id` için şubeyi, ilişkili kitap bilgileriyle birlikte yükler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez; veri erişim sözleşmesini tanımlar.
- Metotların asenkron olması I/O tabanlı veri erişim (örn. DB) beklentisini ima eder.
- “Aktif” kavramının neye göre belirlendiği (ör. `IsActive` alanı) bu dosyadan anlaşılmıyor.
- “WithStaff” ve “WithBooks” metotları ilişkisel veri yüklemeyi (eager loading) hedefler; ilişki adları/senaryoları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Service katmanlarındaki iş mantığı tarafından çağrılması beklenir (bu dosyadan doğrudan görülemiyor).
- **Aşağı akış:** `IRepository<LibraryBranch>` taban sözleşmesi.
- **İlişkili tipler:** `Library.Domain.Entities.LibraryBranch`, `IRepository<T>`.

---

### Genel Değerlendirme
Kod tabanından yalnızca Domain katmanındaki bir repository arayüzü görünüyor. Bu, katmanlı/temiz mimari yaklaşımına işaret etse de diğer katmanlar (Application, Infrastructure, API) bu girdiyle doğrulanamıyor. Harici bağımlılıklar, konfigürasyon anahtarları ve hedef framework bilgisi bu dosyadan çıkarılamıyor. Arayüz, şube özelindeki sorgu ihtiyaçlarını açık biçimde ayırarak iyi bir sözleşme tanımı sunuyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` namespace’i)
- Amaç: Bildirim varlıkları (`Notification`) için depo sözleşmesini tanımlamak; domain katmanında persistance-agnostic bir arayüz sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Domain katmanı). Bu arayüz uygulama/altyapı katmanlarından somut implementasyonlarla doldurulmak üzere tasarlanmış.
- Projeler/assembly’ler:
  - Library.Domain — Domain modelleri ve repository arayüzleri (bu dosyadan görülen).
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/INotificationRepository.cs`

**1. Genel Bakış**
`INotificationRepository`, `Notification` varlıkları için özel sorgular ve durum güncellemeleri içeren depo sözleşmesini tanımlar. Domain katmanına aittir; kalıcılık detaylarını soyutlayarak altyapı katmanında implementasyon bekler.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Notification>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomerIdAsync | `Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşteri için tüm bildirimleri döndürür. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)` | Belirli müşteri için okunmamış bildirimleri döndürür. |
| GetUnreadCountByCustomerIdAsync | `Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)` | Belirli müşteri için okunmamış bildirim sayısını döndürür. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Belirli bildirimi okundu olarak işaretler. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşteriye ait tüm bildirimleri okundu olarak işaretler. |

**5. Temel Davranışlar ve İş Kuralları**
- `Notification` özelinde müşteri bazlı filtreleme ve okunma durumunun yönetimi için sözleşme sunar.
- Okunmamış bildirimlerin alınması ve sayılması için açık API sağlar.
- Okundu işaretleme işlemleri tekil ve toplu olarak ayrıştırılmıştır.
- DTO — davranış yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; bu dosyadan belirli çağırıcılara dair bilgi anlaşılmıyor.
- **Aşağı akış:** `IRepository<Notification>` (genel CRUD sözleşmesi).
- **İlişkili tipler:** `Notification` (`Library.Domain.Entities`), `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` desteği yok; uzun süren I/O işlemlerinde iptal desteği beklenebilir.
- Listeleme operasyonlarında sayfalama/paging yok; potansiyel büyük veri kümelerinde performans etkisi olabilir (implementasyon katmanında ele alınması önerilir).

---

Genel Değerlendirme
- Kod parçası domain katmanında repository sözleşmesini gösteriyor; diğer katmanlar ve somut implementasyonlar bu dosyadan görünmüyor.
- Asenkron API’lerde iptal belirteci eksikliği ve potansiyel paging ihtiyacı dikkat çekiyor.
- Hedef framework, konfigürasyon ve harici bağımlılıklar bu dosyadan belirlenemiyor.### Project Overview
Proje adı: Library (türetim: `Library.Domain` ad alanı). Amaç: Kütüphane alan modelini ve sözleşmelerini tanımlamak; özellikle yayınevi (`Publisher`) varlıkları için repository sözleşmesi sağlamak. Hedef çatı (.NET) bu dosyadan kesin belirlenemiyor; yalnızca async imzalar ve C# 10+ dosya üstü `namespace` söz dizimi kullanımı görülüyor.

Mimari: Katmanlı/Clean Architecture eğilimli yapı. Bu katmanda domain sözleşmeleri ve entity referansları yer alır; uygulama ve altyapı katmanları bu sözleşmeleri uygular/çağırır.

Projeler/Assembly’ler:
- Library.Domain — Domain katmanı; entity’ler ve repository arayüzleri (bu dosyada `IPublisherRepository`).

Dış paketler/çatı: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Interfaces, Entities)
  ↓ (uygulamada kullanılır, altyapıda uygulanır)
[Application/Services] → [Infrastructure/Data Access]
Not: Yalnızca Domain katmanı görüldü; diğerleri isimlendirme amaçlıdır ve bu dosyadan doğrulanamaz.

---
### `Library.Domain/Interfaces/IPublisherRepository.cs`

**1. Genel Bakış**
`IPublisherRepository`, `Publisher` varlığı için repository sözleşmesini genişletir ve alan-özel sorgular (isimle getirme, kitaplarıyla birlikte getirme, aktif yayınevleri) tanımlar. Domain katmanına aittir ve altyapı katmanında uygulanmak üzere kontrat sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Publisher>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
- `IRepository<Publisher>` — Temel CRUD operasyonları için genel repository kontratı
- `Publisher` — Hedef domain entity’si

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<Publisher?> GetByNameAsync(string name)` | Verilen ada göre tek bir `Publisher` döndürür (yoksa null). |
| GetWithBooksAsync | `Task<Publisher?> GetWithBooksAsync(Guid id)` | İlgili `Publisher` ve ilişkili kitaplarıyla birlikte getirir (yoksa null). |
| GetActivePublishersAsync | `Task<IEnumerable<Publisher>> GetActivePublishersAsync()` | Aktif durumdaki yayınevlerini listeler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış yok. Beklenen iş kuralları imzalardan türetilir: isim benzersizliği varsayımı olası; “aktif” kriteri entity alanlarına bağlıdır. İmzalarda `CancellationToken` bulunmaması dikkat çekicidir; uzun süren sorgularda iptal desteği olmayabilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/use-case’ler tarafından çağrılması beklenir.
- **Aşağı akış:** `IRepository<Publisher>`; `Publisher` entity’si.
- **İlişkili tipler:** `Publisher`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametreleri eksik; ölçeklenebilirlik ve iptal senaryolarında kısıt oluşturabilir.
- “Aktif” tanımı bu dosyadan anlaşılamıyor; sözleşmede kriterin belirsizliği uygulama genelinde tutarsızlıklara yol açabilir. 

Genel Değerlendirme
- Görünen yapı Clean/katmanlı mimari prensiplerine uygun; Domain katmanı yalnızca sözleşmeleri içeriyor.
- Kontrat düzeyinde `CancellationToken` eksikliği dikkat çekiyor; veri erişiminde iptal/timeout yönetimi zorlaşabilir.
- Yalnızca bir arayüz görüldüğünden, CRUD kapsamı ve hata yönetimi politikaları bu koddan anlaşılamıyor.### Project Overview
- Proje adı: Library (tahmin, `Library.Domain` ad alanından çıkarım). Amaç: domain katmanında generic repository sözleşmesi tanımlayarak kalıcı veri erişimi için soyutlama sağlamak. Hedef framework: bu dosyadan kesin olarak belirlenemiyor.
- Mimari desen: Katmanlı/Clean-Architecture-vari yaklaşım işareti (Domain katmanında `Interfaces`). Veri erişimi ayrımı için repository soyutlaması kullanılıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain sözleşmeleri (özellikle repository arayüzleri).
- Kullanılan dış paketler/çatı: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Interfaces)
  ↳ Harici bağımlılık yok; diğer katmanlar (ör. Infrastructure, Application) bu sözleşmeyi referans alır. Yön: Application/Infrastructure → Library.Domain

---
### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
Generic repository arayüzü `IRepository<T>`, veri erişimine ilişkin temel CRUD, sorgulama, sayfalama ve sayma operasyonlarını asenkron olarak tanımlar. Domain katmanındaki bir sözleşme olup, implementasyonu muhtemelen Infrastructure katmanında sağlanır ve Application katmanı tarafından tüketilir.

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
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı döndürür; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları getirir. |
| FindAsync | `Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)` | Verilen ifade ile filtrelenmiş varlıkları getirir. |
| GetPagedAsync | `Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)` | Sayfalama ile varlıkları ve toplam kayıt sayısını döndürür. |
| CountAsync | `Task<int> CountAsync()` | Toplam kayıt sayısını döndürür. |
| CountAsync | `Task<int> CountAsync(Expression<Func<T, bool>> predicate)` | Filtreye uyan kayıt sayısını döndürür. |
| ExistsAsync | `Task<bool> ExistsAsync(Guid id)` | Kimliğe göre varlık var mı kontrol eder. |
| AddAsync | `Task AddAsync(T entity)` | Yeni varlık ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut varlığı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kimliğe göre varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Asenkron sözleşme: Tüm işlemler `Task` tabanlıdır.
- Sorgulama esnekliği: `FindAsync` LINQ `Expression<Func<T,bool>>` ile sağlayıcıya taşınabilir filtreleme sunar.
- Sayfalama: `GetPagedAsync` hem sayfa verilerini hem toplam sayıyı döndürerek UI/grid senaryolarını destekler.
- Kimlik işlemleri: `Guid` tabanlı kimlik kabul edilir; ID türü bu sözleşmede sabittir.
- Silme semantiği (hard/soft) ve transaction kapsamı bu arayüzden anlaşılamaz; implementasyona bırakılmıştır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak Application servisleri veya handler’lar tarafından kullanılır.
- **Aşağı akış:** Implementasyon tarafında veri sağlayıcısına (ör. EF Core DbContext) bağlanması beklenir; bu dosyadan görünmüyor.
- **İlişkili tipler:** `Expression<Func<T, bool>>` (LINQ ifadeleri).

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanındaki generic repository sözleşmesi görülüyor; diğer katmanlar (Application, Infrastructure, API) bu dosyadan çıkarılamıyor.
- `Guid` zorunluluğu domain genelinde ID standardizasyonu ima ediyor; farklı ID türleri gerekli ise generic ID desteği (`TKey`) tasarlanabilir.
- Soft delete, sıralama, include/şemsiye yüklemeler ve transaction birimleri (Unit of Work) için ayrı sözleşmeler veya genişletmeler düşünülebilir.### Project Overview (required, once)
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanı içerisinde personel (`Staff`) varlıklarının depolanması ve sorgulanmasına yönelik repository sözleşmeleri tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari işaretleri var; bu dosya Domain katmanına ait (Interfaces, Entities).
- Keşfedilen projeler/assembly’ler:
  - `Library.Domain` — Domain katmanı: entity’ler ve repository arayüzleri.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram (required, once)
Library.Domain
  └─ Entities (`Library.Domain.Entities`)
  └─ Interfaces (`Library.Domain.Interfaces`)
      └─ `IStaffRepository` → `Staff` (entity)
      └─ `IRepository<T>` (genel sözleşme, tanımı bu dosyada yok)

---
### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` varlığı için özel sorguları tanımlayan repository arayüzüdür. Domain katmanında, genel `IRepository<Staff>` sözleşmesini genişleterek e-posta, şube ve sicil numarası gibi alanlara göre erişim sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Staff>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
- `Staff` — Domain entity türü (tip parametresi olarak)
- `IRepository<Staff>` — Genel CRUD sözleşmesi (tanımı bu dosyada yok)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | E-posta adresine göre tekil `Staff` döner. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki tüm `Staff` kayıtlarını döner. |
| GetByBranchIdAsync | `Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)` | Belirtilen şubeye bağlı `Staff` listesini döner. |
| GetByEmployeeNumberAsync | `Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)` | Çalışan numarasına göre tekil `Staff` döner. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımlamaz. Sözleşme, personeli e-posta, şube kimliği ve çalışan numarasına göre sorgulama ile “aktif” filtrelemesini destekler. Null dönebilme sözleşmesi (`Staff?`) tekil sorgularda bulunamama durumunu ifade eder.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama/Servis katmanındaki handler/service’ler tarafından DI üzerinden çözümlenir.
- **Aşağı akış:** `IRepository<Staff>` (genel CRUD), `Staff` entity.
- **İlişkili tipler:** `Staff` (`Library.Domain.Entities.Staff`), `IRepository<Staff>`.

**7. Eksikler ve Gözlemler**
- `IRepository<Staff>` tanımı bu depo içinde görünmüyor; sözleşmenin kapsamı bu dosyadan anlaşılmıyor.
- “Aktif” kavramının hangi alana dayandığı (ör. `IsActive`) belirsiz; isimden çıkarım yapılıyor ancak alan detayı bu dosyada yok.

---
Genel Değerlendirme
- Yalnızca Domain katmanına ait bir arayüz dosyası mevcut; mimarinin diğer katmanları ve uygulama ayrıntıları bu depoda görünmüyor.
- `IRepository<T>` genel sözleşmesinin eksikliği, tam API yüzeyini değerlendirmeyi kısıtlıyor.
- Harici paketler, konfigürasyon anahtarları ve hedef framework bilgisi bu dosyadan belirlenemiyor.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane yönetimi alanındaki varlıkları (kitap, yazar, yayınevi, şube, müşteri vb.) kalıcı katmanda yönetmek; ilişkiler, indeksler ve soft delete (global query filter) kurallarıyla veritabanı şemasını yapılandırmak.
- Hedef framework: .NET (tam sürüm bu dosyadan anlaşılmıyor); EF Core kullanımı mevcut.
- Mimari desen: Katmanlı (en azından Domain ve Infrastructure katmanları). Domain katmanı entity tanımlarını içerir; Infrastructure katmanı veri erişimi ve EF Core konfigürasyonunu sağlar.
- Projeler/Assembly’ler:
  - Library.Domain — Domain entity’leri (`Book`, `Author`, `Customer`, vb.)
  - Library.Infrastructure — EF Core `DbContext` ve model konfigürasyonları
- Dış bağımlılıklar:
  - Microsoft.EntityFrameworkCore (EF Core)
- Konfigürasyon gereksinimleri:
  - `LibraryDbContext` için bir veritabanı sağlayıcısı ve connection string gerekir; anahtar adı ve ayrıntılar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
`LibraryDbContext`, EF Core üzerinden kütüphane domain varlıklarının kalıcı hale getirilmesini sağlar. Soft delete için global query filter’lar, ilişkiler, indeksler ve alan kısıtları tanımlanır. Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlam seçenekleri ve bağlantı/sağlayıcı konfigürasyonu

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | EF Core bağlamını belirtilen seçeneklerle başlatır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlık kümesi. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlık kümesi. |
| Authors | `public DbSet<Author> Authors { get; }` | `Author` varlık kümesi. |
| Publishers | `public DbSet<Publisher> Publishers { get; }` | `Publisher` varlık kümesi. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlık kümesi. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlık kümesi. |
| BookLoans | `public DbSet<BookLoan> BookLoans { get; }` | `BookLoan` varlık kümesi. |
| BookReservations | `public DbSet<BookReservation> BookReservations { get; }` | `BookReservation` varlık kümesi. |
| Fines | `public DbSet<Fine> Fines { get; }` | `Fine` varlık kümesi. |
| LibraryBranches | `public DbSet<LibraryBranch> LibraryBranches { get; }` | `LibraryBranch` varlık kümesi. |
| BookReviews | `public DbSet<BookReview> BookReviews { get; }` | `BookReview` varlık kümesi. |
| Notifications | `public DbSet<Notification> Notifications { get; }` | `Notification` varlık kümesi. |
| AuditLogs | `public DbSet<AuditLog> AuditLogs { get; }` | `AuditLog` varlık kümesi. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Model yapılandırmaları, ilişkiler, indeksler ve filtreleri tanımlar. |

**5. Temel Davranışlar ve İş Kuralları**
- Soft delete: `Book`, `BookCategory`, `Author`, `Publisher`, `Staff`, `Customer`, `BookLoan`, `BookReservation`, `Fine`, `LibraryBranch`, `BookReview`, `Notification` için `HasQueryFilter(e => !e.IsDeleted)`. `AuditLog` için soft delete filtresi tanımlı değil (varsa bu dosyadan anlaşılmıyor).
- Benzersiz indeksler: `Book.ISBN` (unique), `BookCategory.Name` (unique), `Publisher.Name`, `Staff.Email` (unique), `Staff.EmployeeNumber` (nullable unique with filter), `Customer.Email` (unique), `Customer.MembershipNumber` (unique), `LibraryBranch.Name` (unique), `BookReview (BookId, CustomerId)` (unique).
- İlişkiler ve silme davranışları:
  - `Book` -> `Author` Restrict; `Publisher`, `BookCategory`, `LibraryBranch` SetNull.
  - `BookLoan` -> `Book`, `Customer` Restrict; `ProcessedByStaff` SetNull.
  - `BookReservation` -> `Book`, `Customer` Restrict.
  - `Fine` -> `BookLoan`, `Customer` Restrict.
  - `BookReview` -> `Book` Cascade; `Customer` Restrict.
  - `Notification` -> `Customer` Cascade.
  - `BookCategory` self-relation `ParentCategory` Restrict.
- Alan kısıtları: bir çok string alan için `IsRequired` ve `HasMaxLength`; parasal alanlarda `HasPrecision(10,2)`.
- Performans: Sık sorgulanan sütunlarda indeksler (`Status`, `DueDate`, `Timestamp`, bileşik indeksler).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; repository/service katmanları tarafından kullanılır (çağırıcıların ayrıntıları bu dosyadan anlaşılmıyor).
- **Aşağı akış:** EF Core (`Microsoft.EntityFrameworkCore`), `Library.Domain.Entities` içindeki entity tipleri.
- **İlişkili tipler:** `Book`, `BookCategory`, `Author`, `Publisher`, `Staff`, `Customer`, `BookLoan`, `BookReservation`, `Fine`, `LibraryBranch`, `BookReview`, `Notification`, `AuditLog`.

**7. Eksikler ve Gözlemler**
- Soft delete filtresi `AuditLog` için tanımlı değil; `AuditLog`’da `IsDeleted` alanı olup olmadığı bu dosyadan anlaşılmıyor. Audit kayıtları için soft delete yerine kalıcılık beklenebilir; bu tercih net değil.
- Connection string ve sağlayıcı konfigürasyonu bu dosyada yer almıyor; ortam bazlı ayar anahtarları belirsiz.

---

Genel Değerlendirme
- Katmanlı yapı net: Infrastructure, Domain’a bağımlı; diğer katmanlar bu dosyadan görülemiyor.
- EF Core konfigürasyonu ayrıntılı ve tutarlı; indeksler, ilişkiler ve silme davranışları düşünülmüş.
- Soft delete yaklaşımı geniş çapta uygulanmış; `AuditLog` istisnasının kasıtlı olup olmadığı net değil.
- Uygulama yapılandırması (connection string anahtarları, sağlayıcı) görünür değil; dağıtım/düğüm ayarları dokümantasyonda netleştirilmeli.### Project Overview
Proje adı: Library (katmanlar: Domain, Application, Infrastructure). Amaç: Kütüphane alanındaki repository arayüzlerini somutlayan veri erişim katmanını ve `DbContext` yapılandırmasını sağlamak. Hedef framework bu dosyadan anlaşılamıyor. Mimari, Clean Architecture prensipleriyle kurgulanmış görünüyor: Domain çekirdek modeller/arayüzler; Application iş kuralları ve use-case’ler; Infrastructure altyapı (EF Core, e-posta, veri erişimi); muhtemel bir API sunum katmanı.

Katmanlar/Projeler:
- Library.Domain: `Interfaces` (repository sözleşmeleri).
- Library.Application: `Email`, `Interfaces` (uygulama seviyesi servis sözleşmeleri).
- Library.Infrastructure: `Data` (EF `LibraryDbContext`), `Repositories` (EF tabanlı implementasyonlar), `Email` (e-posta altyapısı; bu dosyada referans var).

Dış bağımlılıklar:
- Entity Framework Core (SqlServer provider, retry politikası ve migration ayarları).
- Microsoft.Extensions.DependencyInjection / Configuration.

Konfigürasyon:
- Connection string anahtarı: `DefaultConnection` (IConfiguration üzerinden okunur).

### Architecture Diagram
API/Presentation --> Application --> Domain
API/Presentation --> Infrastructure --> (implements) Application.Interfaces, Domain.Interfaces
Infrastructure --uses--> EF Core (SqlServer), Configuration
Application --depends on--> Domain

---
### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Infrastructure katmanının DI (Dependency Injection) kayıtlarını merkezi olarak sağlar. EF Core `LibraryDbContext`’i SQL Server ile yapılandırır ve Domain katmanındaki repository arayüzlerini Infrastructure’daki somut repository sınıflarıyla eşler.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure`

**3. Bağımlılıklar**
- `IConfiguration` — `DefaultConnection` connection string’ini sağlar.
- `IServiceCollection` — DI kaydı için hedef koleksiyon.
- `LibraryDbContext` — EF Core bağlamı (SQL Server).
- Repository implementasyonları — EF tabanlı veri erişimi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | DbContext ve repository bağımlılıklarını DI konteynerine ekler; SQL Server ayarlarını ve EF retry/timeout politikalarını yapılandırır. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server ile kaydedilir; `EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: 10s)` ile temel transient hata tekrarı etkin.
- `CommandTimeout(30)` ile komut zaman aşımı 30 saniye.
- `MigrationsAssembly` olarak `LibraryDbContext`’in assembly adı kullanılır.
- Repository’ler `Scoped` yaşam süresiyle kaydedilir: `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`, `IAuthorRepository`, `IPublisherRepository`, `IBookLoanRepository`, `IBookReservationRepository`, `IFineRepository`, `ILibraryBranchRepository`, `IBookReviewRepository`, `INotificationRepository`, `IAuditLogRepository`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API veya Application katmanı `AddInfrastructure` çağırır.
- **Aşağı akış:** `IConfiguration`, EF Core SqlServer, `LibraryDbContext`, somut repository sınıfları.
- **İlişkili tipler:** `Library.Infrastructure.Data.LibraryDbContext`, `Library.Infrastructure.Repositories.*`, `Library.Domain.Interfaces.*`.

**7. Eksikler ve Gözlemler**
- `using Library.Application.Email;` ve `using Library.Infrastructure.Email;` referanslarına rağmen e-posta ile ilgili servislerin DI kaydı yapılmamış; ilgili implementasyonlar varsa eklenmesi gerekebilir.
- `using Library.Application.Interfaces;` kullanımı mevcut ancak bu arayüzlere ilişkin herhangi bir servis kaydı yapılmıyor; uygulama servislerinin altyapı bağımlılıkları eksik olabilir.

### Genel Değerlendirme
Kod tabanında Infrastructure katmanı net şekilde DI ve EF Core yapılandırmasını üstleniyor ve Clean Architecture ile uyumlu. Connection string anahtarı belirgin. E-posta/uygulama servisleri için `using` eklenmiş olmasına rağmen DI kayıtları yok; bu ya ileride eklenecek ya da eksik. Hedef framework ve API katmanı bu dosyadan çıkarılamıyor. EF Core için temel dayanıklılık ayarları (retry, timeout) yerinde; ek olarak bağlantı havuzu ve sağlık kontrolleri ayrı bir yerde düşünülebilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Uygulama katmanında tanımlı `IEmailService` sözleşmesini kullanarak SMTP üzerinden e-posta gönderimi sağlamak.
- Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor)
- Mimari desen: Clean Architecture eğilimi. Application katmanında kontratlar/ayarlar, Infrastructure katmanında somut dış kaynak entegrasyonu (SMTP).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Sözleşmeler (`IEmailService`) ve ayarlar (`EmailSettings`)
  - Library.Infrastructure — SMTP tabanlı e-posta gönderim implementasyonu
- Ana harici paketler/çerçeveler: .NET `System.Net.Mail`, `System.Net`
- Konfigürasyon gereksinimleri (EmailSettings):
  - `Host` (SMTP sunucusu)
  - `Port` (int)
  - `EnableSsl` (bool)
  - `Username`, `Password`
  - `From` (gönderen e-posta adresi)

### Architecture Diagram
Library.Infrastructure (Email) --> Library.Application (Interfaces, Settings)

---

### `Library.Infrastructure/Email/SmtpEmailService.cs`

**1. Genel Bakış**
`SmtpEmailService`, `IEmailService` sözleşmesini SMTP protokolü ile gerçekleştiren Infrastructure katmanı bileşenidir. `EmailSettings` üzerinden yapılandırılır ve .NET `SmtpClient` kullanarak e-posta gönderir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IEmailService`
- **Namespace:** `Library.Infrastructure.Email`

**3. Bağımlılıklar**
- `EmailSettings` — SMTP sunucusu ve kimlik bilgileri dâhil e-posta gönderimi için gerekli ayarları sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `SmtpEmailService(EmailSettings settings)` | SMTP ayarlarını alır ve servisi yapılandırır. |
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | Verilen alıcı, konu ve gövde ile e-postayı asenkron olarak gönderir. |

**5. Temel Davranışlar ve İş Kuralları**
- `MailMessage` `From` değeri `EmailSettings.From` üzerinden, alıcı `to`, konu `subject`, gövde `body` ile oluşturulur; `IsBodyHtml` `isHtml` parametresine göre ayarlanır.
- `SmtpClient`, `Host`, `Port`, `EnableSsl`, `Username`, `Password` ayarlarıyla yapılandırılır.
- `CancellationToken` `SendMailAsync` çağrısına iletilir.
- `MailMessage` ve `SmtpClient` `using` ile deterministik olarak dispose edilir.
- SMTP kaynaklı hatalar çalışma zamanında yüzeye fırlayabilir (ör. kimlik doğrulama/bağlantı hataları).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Presentation katmanındaki hizmetler veya iş akışları tarafından çağrılır.
- **Aşağı akış:** `System.Net.Mail.SmtpClient`, `System.Net.Mail.MailMessage`, `System.Net.NetworkCredential`
- **İlişkili tipler:** `Library.Application.Interfaces.IEmailService`, `Library.Application.Email.EmailSettings`

**7. Eksikler ve Gözlemler**
- Dayanıklılık (retry/policy), timeout ve hata günlüğe alma bulunmuyor; üretim ortamında gözlemlenebilirlik için logging/policy gerekebilir.
- Kimlik bilgileri ve `From` değerinin doğrulanmasına dair ek validasyon yok.
- `SmtpClient` modern senaryolarda sınırlı kabul edilebilir; bazı projelerde MailKit tercih edilir.

---

Genel Değerlendirme
- Clean Architecture yönelimi net: Application’da kontratlar/ayarlar, Infrastructure’da dış sistem implementasyonu.
- Yapılandırma yönetimi kritik; `EmailSettings`’in güvenli saklanması ve doğrulanması önerilir.
- Gözlemlenebilirlik (logging), politika tabanlı dayanıklılık ve hata yönetimi eksik; kurumsal ihtiyaçlarda eklenmelidir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kitaplık/iş alanına ait domain varlıkları için altyapı katmanında veri erişimi ve loglama (audit) operasyonları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor (muhtemelen modern .NET, EF Core kullanımı mevcut).
- Mimari desen: Katmanlı mimari / Clean Architecture varyantı. Katmanlar:
  - Domain: `Entities`, `Interfaces` (repository sözleşmeleri).
  - Infrastructure: EF Core tabanlı repository implementasyonları ve `DbContext`.
  - (Varsa) Application/Presentation: Bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları (`AuditLog`) ve kontratlar (`IAuditLogRepository`).
  - Library.Infrastructure — EF Core `DbContext` ve repository implementasyonları (`AuditLogRepository`, `BaseRepository<T>`).
- Harici paketler/çatı: Microsoft Entity Framework Core.
- Konfigürasyon gereksinimleri: Veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları muhtemel; bu dosyadan detaylar anlaşılmıyor.

### Architecture Diagram
Domain -> Infrastructure
Application/Presentation -> Domain
Application/Presentation -> Infrastructure

---
### `Library.Infrastructure/Repositories/AuditLogRepository.cs`

**1. Genel Bakış**
`AuditLogRepository`, `AuditLog` varlıkları için sorgu odaklı veri erişimi sağlar. Belirli entity, kullanıcı veya tarih aralığına göre denetim kayıtlarını getirir. Mimari olarak Infrastructure veri erişim/repository katmanındadır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<AuditLog>`
- **Uygular:** `IAuditLogRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `BaseRepository` aracılığıyla `_dbSet` üzerinde sorgulama yapılır.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `AuditLogRepository(LibraryDbContext context)` | Repository’yi verilen `DbContext` ile başlatır. |
| GetByEntityAsync | `Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityName, Guid entityId)` | Belirli varlık adı ve kimliği için audit kayıtlarını zaman damgasına göre azalan sırada döner. |
| GetByUserAsync | `Task<IEnumerable<AuditLog>> GetByUserAsync(string userId)` | Belirtilen kullanıcıya ait audit kayıtlarını zaman damgasına göre azalan sırada döner. |
| GetByDateRangeAsync | `Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)` | Verilen tarih aralığındaki (dahil) audit kayıtlarını zaman damgasına göre azalan sırada döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm sorgular asenkron çalışır ve EF Core `ToListAsync` kullanır.
- Sorgular, `Timestamp` alanına göre azalan sıralama uygular.
- `GetByDateRangeAsync` başlangıç ve bitiş tarihlerini dahil edecek şekilde filtreler (`>=`, `<=`).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’ları tarafından çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext` ve `BaseRepository<AuditLog>`; EF Core `DbSet<AuditLog>`.
- **İlişkili tipler:** `AuditLog` (entity), `IAuditLogRepository` (kontrat), `BaseRepository<T>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` parametresi yok; uzun sorgularda iptal desteği eklenebilir.
- Potansiyel büyük veri setlerinde sayfalama/paginasyon desteği bulunmuyor.

---
### Genel Değerlendirme
Kod, klasik repository deseniyle EF Core üzerinde odaklı sorgular sağlıyor ve katmanlı mimariye uyumlu görünüyor. DI ile kullanım ve ayrık kontratlar doğru. Geliştirilebilir alanlar: iptal belirteci desteği, sayfalama ve muhtemel indeksleme stratejileri (özellikle `EntityName`, `EntityId`, `UserId`, `Timestamp` üzerinde). Hedef framework, uygulama katmanları ve konfigürasyon detayları bu dosyadan netleşmiyor.### Project Overview
- Proje adı: Library
- Amaç: Kitap/author verilerini EF Core üzerinden yönetmek için repository katmanı sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture benzeri. Domain (entity ve interface’ler) ile Infrastructure (EF Core implementasyonları) katmanları gözlemleniyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain: `Entities` ve `Interfaces` (örn. `Author`, `IAuthorRepository`)
  - Library.Infrastructure: Repository implementasyonları ve EF Core `DbContext` (örn. `AuthorRepository`, `LibraryDbContext`)
- Kullanılan dış paketler/çatı: Microsoft.EntityFrameworkCore (EF Core)
- Konfigürasyon gereksinimleri: EF Core için veritabanı bağlantı dizesi gerekir; anahtar/ad bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API (muhtemel)
  ↓
Application (muhtemel, `IAuthorRepository`’yi kullanır)
  ↓           ↘
Domain (`Entities`, `Interfaces`) ← Infrastructure (`Repositories`, `LibraryDbContext`)

---

### `Library.Infrastructure/Repositories/AuthorRepository.cs`

**1. Genel Bakış**
`AuthorRepository`, `IAuthorRepository` kontratını EF Core ile implement eder. `Author` varlıkları üzerinde arama ve ilişkili `Books` navigasyonunu yükleme operasyonları sunar. Infrastructure katmanında yer alır ve `LibraryDbContext` üzerinden veri erişimi yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Author>`
- **Uygular:** `IAuthorRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core veritabanı bağlamı; `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public AuthorRepository(LibraryDbContext context)` | Bağlamı alır ve temel repository’i başlatır. |
| SearchAsync | `public Task<IEnumerable<Author>> SearchAsync(string searchTerm)` | Ad/soyad üzerinde `Contains` ile arama yapar. |
| GetWithBooksAsync | `public Task<Author?> GetWithBooksAsync(Guid id)` | İlgili `Author`’ı `Books` koleksiyonu ile birlikte getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- `SearchAsync`: `FirstName` veya `LastName` alanlarında `Contains` filtrelemesi yapar; büyük/küçük harf duyarlılığı veritabanı kolasyonuna bağlıdır. `searchTerm` için null/empty kontrolü yoktur.
- `GetWithBooksAsync`: `Include(a => a.Books)` ile eager loading yapar; eşleşme yoksa `null` döner.
- Sorgular `ToListAsync`/`FirstOrDefaultAsync` ile asenkron çalışır.

**6. Bağlantılar**
- Yukarı akış: Uygulama katmanındaki servis/handler’lar; genelde DI üzerinden çözümlenir.
- Aşağı akış: `LibraryDbContext`, EF Core (`DbSet<Author>`, `Include`, `Where`).
- İlişkili tipler: `Author` (Domain entity), `IAuthorRepository` (Domain interface), `BaseRepository<Author>`, `Author.Books` navigasyonu (ilgili `Book` entity’si bu dosyada yok).

**7. Eksikler ve Gözlemler**
- `SearchAsync` için `CancellationToken` desteği yok; uzun sorgularda yönetilebilirlik azalır.
- Aramada boş/çok kısa terimler için validasyon yok; tam tablo taraması ve performans riski oluşturabilir.
- Sayfalama (paging) yok; geniş sonuç setlerinde bellek ve performans etkilenebilir.

---

Genel Değerlendirme
- Kod, Domain arayüzlerini Infrastructure’da EF Core ile gerçekleştiren temiz bir ayrımı takip ediyor.
- İyileştirme alanları: yöntemlere `CancellationToken` eklenmesi, arama için input validasyonu ve sayfalama, potansiyel olarak `AsNoTracking` kullanımı (okuma senaryolarında), ve büyük veri setleri için uygun indeksleme/arama stratejileri.### Project Overview
Proje adı koddan “Library” olarak anlaşılıyor. Amaç: `Library.Domain` içindeki `BaseEntity` tabanlı varlıklar için genel amaçlı EF Core tabanlı repository altyapısı sağlamak. Hedef çatı bu dosyadan anlaşılmıyor. Mimari, Domain ve Infrastructure katmanlarının ayrıldığı bir N‑Katmanlı/Clean‑Architecture‑benzeri yapı izlenimi veriyor: Domain varlık ve kontratları, Infrastructure veri erişimi.

- Mimari desen: Clean Architecture eğilimli N‑Katmanlı
  - Domain: `Entities` ve `Interfaces` (ör. `BaseEntity`, `IRepository<T>`)
  - Infrastructure: EF Core veri erişimi ve `DbContext` (ör. `LibraryDbContext`, `BaseRepository<T>`)
- Projeler/Assembly’ler:
  - Library.Domain — Varlıklar (`BaseEntity`) ve repository kontratı (`IRepository<T>`).
  - Library.Infrastructure — EF Core ile repository implementasyonları ve `LibraryDbContext`.
- Kullanılan dış paketler/çatı: Microsoft Entity Framework Core (`Microsoft.EntityFrameworkCore`)
- Konfigürasyon gereksinimleri: `LibraryDbContext` için bağlantı dizesi ve EF Core sağlayıcı yapılandırması gerekir; anahtar/ad bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/BaseRepository.cs`

**1. Genel Bakış**
`BaseRepository<T>` generic repository, `BaseEntity` türevi varlıklar için temel CRUD ve sorgulama operasyonlarını EF Core ile sağlar. Infrastructure katmanında yer alır ve `IRepository<T>` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IRepository<T>`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; veri erişimi ve `SaveChangesAsync` için kullanılır.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BaseRepository(LibraryDbContext context)` | DbContext enjekte edilerek `DbSet<T>` başlatılır. |
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Birincil anahtarla varlığı getirir. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları listeler. |
| FindAsync | `Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)` | Predicate’e göre filtrelenmiş liste döner. |
| GetPagedAsync | `Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)` | `CreatedAt`’e göre azalan sıralı sayfalı sonuç ve toplam kayıt sayısı döner. |
| CountAsync | `Task<int> CountAsync()` | Toplam kayıt sayısını döner. |
| CountAsync | `Task<int> CountAsync(Expression<Func<T, bool>> predicate)` | Predicate’e göre sayım yapar. |
| ExistsAsync | `Task<bool> ExistsAsync(Guid id)` | Id’ye göre varlık var mı kontrol eder. |
| AddAsync | `Task AddAsync(T entity)` | `CreatedAt`’i UTC olarak ayarlayıp ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(T entity)` | `UpdatedAt`’i UTC olarak ayarlayıp günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Bulunursa soft delete yapar (`IsDeleted = true`) ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetPagedAsync`: `CreatedAt` alanına göre azalan sıralama yapar.
- `AddAsync`: `CreatedAt = DateTime.UtcNow` ayarlanır; anında `SaveChangesAsync` çağrılır.
- `UpdateAsync`: `UpdatedAt = DateTime.UtcNow` ayarlanır; anında `SaveChangesAsync` çağrılır.
- `DeleteAsync`: Hard delete yerine soft delete uygular (`IsDeleted = true`) ve `UpdatedAt` güncellenir.
- `ExistsAsync`: `Id` alanına göre varlık mevcudiyeti kontrol edilir.
- Sayfalama ve sayım işlemleri soft delete’li kayıtları hariç tutmaz; bu dosyadan anlaşılabildiği kadarıyla tüm kayıtları kapsar.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya API katmanı tarafından kullanılır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<T>` (EF Core).
- **İlişkili tipler:** `BaseEntity`, `IRepository<T>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Repository içinde `SaveChangesAsync` çağrıları Unit of Work desenini zorlaştırır ve çoklu işlemde atomikliği engelleyebilir.
- Soft delete uygulanmasına rağmen sorgular (`GetAllAsync`, `GetPagedAsync`, `CountAsync`) `IsDeleted` filtrelemesi yapmıyor; silinmiş kayıtlar sonuçlara dahil olabilir.
- `DeleteAsync` bulunamayan id için sessizce tamamlanıyor; çağıranın durum farkındalığı azalabilir.
- İptal desteği için `CancellationToken` parametreleri yok.
- Sorgular `AsNoTracking()` kullanmıyor; salt-okuma senaryolarında gereksiz takip maliyeti olabilir.

---

Genel Değerlendirme
- Katman ayrımı net: Domain kontratları ve entity’ler, Infrastructure’da EF Core implementasyonu. Ancak Unit of Work yokluğu ve repository içi `SaveChangesAsync` çağrıları transaction yönetimini zorlaştırabilir.
- Soft delete stratejisiyle tutarlı olabilmek için tüm okuma/sayım operasyonlarında `IsDeleted == false` filtresi beklenir; şu an tutarsız.
- İyileştirmeler: `CancellationToken` eklenmesi, okuma işlemlerinde `AsNoTracking()`, sayfalama/sayımda soft delete filtresi, hata/sonuç bildirimi (ör. `DeleteAsync` dönüş tipi), ve üst seviyede UoW/transaction yönetimi.### Project Overview
- Proje adı: Library (kod isimlendirmesine göre). Amacı: kitap kategorileri için veri erişimi sağlamak (Repository deseni ile). Hedef çatı sürümü bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture/N‑Katmanlı varyasyonu. Katmanlar:
  - Domain: Entity’ler (`BookCategory`) ve sözleşmeler (`IBookCategoryRepository`).
  - Infrastructure: EF Core üzerinden veri erişimi; generic `BaseRepository<T>` ve `LibraryDbContext`.
- Projeler/Assembly’ler:
  - Library.Domain — Entity ve interface sözleşmeleri.
  - Library.Infrastructure — EF Core tabanlı repository implementasyonları ve `LibraryDbContext`.
- Dış bağımlılıklar: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon: `LibraryDbContext` için bir bağlantı dizesi gerekli; adı/anahtar bu dosyadan anlaşılmıyor. EF Core için tipik appsettings bağlantı dizesi beklenir.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için özel sorgular sağlayan repository implementasyonudur. Infrastructure katmanında yer alır ve EF Core üzerinden kategori ve ilişkili verileri okur.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookCategory>`
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Kurucu | `BookCategoryRepository(LibraryDbContext context)` | DbContext’i alarak temel repository kurulumunu yapar. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşen kategoriyi döndürür; yoksa `null`. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili `Books` koleksiyonuyla birlikte kategoriyi döndürür; yoksa `null`. |
| GetActiveCategoriesAsync | `Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync()` | `IsActive` olan kategorileri listeler. |
| GetRootCategoriesAsync | `Task<IEnumerable<BookCategory>> GetRootCategoriesAsync()` | `ParentCategoryId == null` olan üst kategorileri `SubCategories` ile birlikte döndürür. |
| GetSubCategoriesAsync | `Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId)` | Verilen üst kategoriye bağlı alt kategorileri listeler. |

**5. Temel Davranışlar ve İş Kuralları**
- Ada göre arama `FirstOrDefaultAsync` ile tek kayıt getirir; bulunamazsa `null`.
- `GetWithBooksAsync` ilişkili `Books` koleksiyonunu `Include` ile yükler.
- `GetActiveCategoriesAsync` yalnızca `IsActive == true` olanları filtreler.
- `GetRootCategoriesAsync` kök kategorileri getirir ve `SubCategories` ilişkisini yükler.
- `GetSubCategoriesAsync` `ParentCategoryId` eşleşmesine göre alt kategorileri döndürür.
- Tüm yöntemler asenkron EF Core sorguları kullanır; iptal belirteci kullanımı bu dosyada yok.

**6. Bağlantılar**
- Yukarı akış: `IBookCategoryRepository`’yi kullanan service katmanı veya uygulama katmanı bileşenleri (DI üzerinden çözümlenir).
- Aşağı akış: `LibraryDbContext` (EF Core), `BaseRepository<BookCategory>` aracılığıyla `_dbSet`.
- İlişkili tipler: `BookCategory`, `IBookCategoryRepository`, `BaseRepository<T>`.

**7. Eksikler ve Gözlemler**
- Asenkron yöntemlerde `CancellationToken` desteği yok; uzun sorgularda iptal kabiliyeti eksik.
- Sadece okuma operasyonları görülüyor; create/update/delete bu sınıfta tanımlı değil (muhtemelen `BaseRepository` içinde).

---

Genel Değerlendirme
- Clean Architecture’a uygun katmanlaşma sinyalleri var: Domain sözleşmeleri Infrastructure’da uygulanıyor.
- EF Core ile repository deseni birlikte kullanılıyor; ilişkisel yüklemeler (`Include`) seçici biçimde tanımlanmış.
- İptal belirteci eksikliği ve konfigürasyon anahtarlarının görünmezliği dışında belirgin tutarsızlık yok; daha geniş bağlam (API/Application katmanları) bu dosyadan anlaşılmıyor.### Project Overview
- Proje adı: Library (çıkarım). Amaç: kütüphane ödünç alma süreçlerine ait veriye erişim ve sorgulama operasyonlarını sağlamak. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture/N‑Tier eğilimli. Domain (entity, enum, interface sözleşmeleri) ve Infrastructure (EF Core tabanlı repository implementasyonları, DbContext) katmanları gözleniyor. Uygulama ve API katmanları bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — `Entities`, `Enums`, `Interfaces` içerir; iş kuralları ve sözleşmeler.
  - Library.Infrastructure — `Data` (DbContext) ve `Repositories` (EF Core repository implementasyonları).
- Kullanılan dış paket/çerçeveler:
  - Microsoft.EntityFrameworkCore — ORM ve LINQ tabanlı veri erişimi.
- Konfigürasyon gereksinimleri:
  - `LibraryDbContext` için bir bağlantı dizesi gerekir; anahtar/ad bu dosyadan anlaşılmıyor. Ek app settings anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain (Entities, Enums, Interfaces)
  ^ 
  | uses
Infrastructure.Data (LibraryDbContext)
  ^
  | depends on
Infrastructure.Repositories (EF Core Repository’ler)
  -> depends on Domain (Entities, Enums, Interfaces)

---

### `Library.Infrastructure/Repositories/BookLoanRepository.cs`

**1. Genel Bakış**
`BookLoan` varlıkları için EF Core tabanlı repository implementasyonudur ve ödünç kayıtlarını farklı ölçütlere göre sorgular. Infrastructure katmanında, `IBookLoanRepository` sözleşmesini gerçekleştirir ve `BaseRepository<BookLoan>` üzerinden ortak veri erişim altyapısını kullanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookLoan>`
- **Uygular:** `IBookLoanRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookLoanRepository(LibraryDbContext context)` | DbContext’i alır ve temel repository altyapısını başlatır. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin ödünç kayıtlarını, kitap ve müşteri dahil, tarihine göre azalan sıralar. |
| GetByBookIdAsync | `Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)` | Belirli kitaba ait ödünçleri müşteri bilgisiyle döner. |
| GetActiveLoansAsync | `Task<IEnumerable<BookLoan>> GetActiveLoansAsync()` | Durumu `Active` olan ödünçleri kitap ve müşteri detaylarıyla döner. |
| GetOverdueLoansAsync | `Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()` | Vadesi geçmiş aktif ödünçleri (UTC bazlı) kitap ve müşteri detaylarıyla döner. |
| GetByStatusAsync | `Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)` | Verilen duruma göre ödünçleri ilgili navigasyonlarla döner. |
| GetWithDetailsAsync | `Task<BookLoan?> GetWithDetailsAsync(Guid id)` | Tek bir ödünç kaydını kitap, müşteri, işlemi yapan personel ve cezalar ile birlikte getirir. |
| GetActiveLoanCountByCustomerAsync | `Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)` | Müşterinin aktif ödünç sayısını döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgularda gerekli navigasyonlar `Include` ile yüklenir: kitap, müşteri, işleyen personel, cezalar.
- `GetByCustomerIdAsync` sonuçları `LoanDate`’e göre azalan sıralanır.
- Gecikmiş kabulü `Status == Active` ve `DueDate < DateTime.UtcNow` koşuluyla yapılır.
- Filtrelemeler `LoanStatus` enum değerleri üzerinden gerçekleştirilir.
- Sayfalama ve izleme modu (ör. `AsNoTracking`) açıkça tanımlı değildir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `LibraryDbContext`, EF Core `_dbSet<BookLoan>`, `LoanStatus` (Domain enum).
- İlişkili tipler: `BookLoan`, `LoanStatus`, `IBookLoanRepository`, `BaseRepository<BookLoan>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Büyük veri kümeleri için sayfalama/limitleme yok; özellikle liste dönen sorgularda performans/IO maliyeti artabilir.
- Okuma amaçlı sorgularda `AsNoTracking` tercih edilmemiş; takip maliyeti gereksiz olabilir.

---

Genel Değerlendirme
- Katman ayrımı Domain ve Infrastructure arasında net; repository deseni EF Core ile uygulanmış.
- Konfigürasyon ve hedef framework ayrıntıları görünen dosyadan çıkarılamıyor.
- Okuma ağırlıklı sorgularda `AsNoTracking` ve sayfalama stratejisi eklenmesi performansı iyileştirebilir.
- Tarih/zaman karşılaştırmalarında `DateTime.UtcNow` kullanımı doğru; ancak zaman dilimi ve saat farkı gereksinimleri varsa merkezi bir zaman sağlayıcısı ile soyutlama düşünülebilir.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane alanındaki `Book` varlıklarına yönelik kalıcı veri erişimini sağlamak; filtreleme, arama ve detaylı getirme işlemleri için altyapı katmanı repository implementasyonu sunmak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı mimari (Domain ve Infrastructure katmanları gözlemleniyor). Domain: entity ve repository sözleşmeleri. Infrastructure: EF Core tabanlı repository implementasyonları ve DbContext.
- Projeler/Assembly’ler:
  - Library.Domain — Entity’ler (`Book`, `Author`, `Publisher`, `BookCategory` vb. referanslar) ve repository arayüzleri (`IBookRepository`).
  - Library.Infrastructure — EF Core `LibraryDbContext` ve repository implementasyonları (ör. `BookRepository`).
- Harici Paketler/Çerçeveler: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon Gereksinimleri: Veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları muhtemel; bu dosyadan spesifik anahtarlar/ayarlar anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)
^
|
Library.Infrastructure (Data, Repositories) --> Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`Book` varlığı için EF Core tabanlı özel sorgular sağlayan repository implementasyonudur. Erişilebilir kitaplar, ISBN’e göre tekil kayıt, yazar/kategori/şube/yayıncı bazlı listeler ve metin arama ile detaylı getirme operasyonlarını sunar. Altyapı (Infrastructure) katmanına aittir.

**2. Tip Bilgisi**
- Tip: class
- Miras: `BaseRepository<Book>`
- Uygular: `IBookRepository`
- Namespace: `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookRepository(LibraryDbContext context)` | DbContext’i alır ve temel repository’i yapılandırır. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable` olan kitapları ilgili ilişkilerle döner. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre tek bir kitabı yazar bilgisiyle getirir. |
| GetByAuthorIdAsync | `Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)` | Verilen yazar kimliğine ait kitapları döner. |
| GetByCategoryIdAsync | `Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)` | Verilen kategori kimliğine ait kitapları döner. |
| GetByBranchIdAsync | `Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)` | Verilen şube kimliğine ait kitapları döner. |
| GetByPublisherIdAsync | `Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)` | Verilen yayınevi kimliğine ait kitapları döner. |
| SearchAsync | `Task<IEnumerable<Book>> SearchAsync(string searchTerm)` | Başlık, ISBN ve yazar ad/soyadına göre metin araması yapar. |
| GetWithDetailsAsync | `Task<Book?> GetWithDetailsAsync(Guid id)` | Kitabı yazar, yayınevi, kategori ve şube ilişkileriyle birlikte getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgularda ilgili navigation property’ler için `Include` kullanılır; böylece eager loading yapılır.
- `GetAvailableBooksAsync` yalnızca `IsAvailable == true` kayıtları döner.
- `SearchAsync` `Title`, `ISBN`, `Author.FirstName`, `Author.LastName` üzerinde `Contains` ile arar; null/boş `searchTerm` için özel validasyon yapılmaz.
- `GetByISBNAsync` ve `GetWithDetailsAsync` bulunamazsa `null` döner.
- Tüm sorgular asenkron ve `ToListAsync`/`FirstOrDefaultAsync` ile çalışır; izleme davranışı (`AsNoTracking`) belirtilmemiştir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; muhtemelen uygulama hizmetleri/use-case’ler tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, EF Core (`DbSet`, `Include`, LINQ).
- İlişkili tipler: `Book`, `Author`, `Publisher`, `BookCategory`, `LibraryBranch`, `IBookRepository`, `BaseRepository<Book>`.

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri yok.
- Okuma senaryolarında performans için `AsNoTracking` tercih edilebilir; şu an belirtilmemiş.
- `SearchAsync` üzerinde geniş `Contains` aramaları ve çoklu `Include` performans etkisi yaratabilir; indeksleme/arama stratejisi düşünülmeli.
- Giriş parametrelerine (örn. boş `isbn`) yönelik validasyon repository seviyesinde yapılmıyor; bu bilinçli bir katman tercihi olabilir.

---
Genel Değerlendirme
- Mevcut kod, Infrastructure katmanında EF Core ile iyi ayrışmış repository desenini izliyor ve Domain arayüzlerine uyuyor.
- Asenkron veri erişimi tutarlı; ancak iptal belirteci ve izleme stratejisi net değil.
- Arama ve listeleme yöntemlerinde pagination, sıralama ve `AsNoTracking` gibi üretim odaklı kaygılar eklenebilir.
- Dosyalardan hedef framework ve uygulamanın diğer katmanları (Application/API) çıkarılamıyor; konfigürasyon anahtarları belirsiz.### Project Overview
Proje adı: Library. Amaç: kütüphane rezervasyonlarını yönetmek; kitap ve müşteri bilgilerine bağlı rezervasyon verilerine erişim sağlamak. Hedef çatı: modern .NET (Core) ile EF Core tabanlı veri erişimi kullanımı bu dosyadan anlaşılıyor.

Mimari: Clean Architecture/N-Tier esintileri. Görünen katmanlar:
- Domain: `Entities`, `Enums`, `Interfaces` içerir; çekirdek iş kuralları ve sözleşmeler.
- Infrastructure: EF Core aracılığıyla veri erişimi; repository implementasyonları ve `DbContext`.

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri (`BookReservation`), enum’lar (`ReservationStatus`), repository arayüzleri (`IBookReservationRepository`).
- Library.Infrastructure — Veri erişimi (EF Core), `BaseRepository<T>` türevleri, `LibraryDbContext`.

Kullanılan dış paketler/çatı:
- Microsoft.EntityFrameworkCore (EF Core) — `DbContext`, `DbSet`, `Include`, `ToListAsync`, `FirstOrDefaultAsync`.

Yapılandırma gereksinimleri:
- `LibraryDbContext` için bir veritabanı bağlantı dizesi gereklidir (anahtar adı bu dosyadan anlaşılamıyor).

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/BookReservationRepository.cs`

**1. Genel Bakış**
`BookReservation` varlıkları için EF Core tabanlı repository implementasyonudur. Müşteri, kitap ve durum bazlı sorgular ile tarih/sıra mantığına göre sıralama sağlar. Mimari olarak Infrastructure veri erişim katmanına aittir ve `IBookReservationRepository` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookReservation>`
- **Uygular:** `IBookReservationRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `BaseRepository` üzerinden `_dbSet` erişimini sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookReservationRepository(LibraryDbContext context)` | Repository’i EF Core bağlamıyla kurar. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)` | Verilen müşteri için rezervasyonları kitabı dahil ederek, tarihe göre azalan sıralar. |
| GetByBookIdAsync | `Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)` | Verilen kitap için rezervasyonları müşteriyi dahil ederek, kuyruk sırasına göre artan sıralar. |
| GetByStatusAsync | `Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)` | Duruma göre rezervasyonları kitap ve müşteri ile birlikte getirir. |
| GetExpiredReservationsAsync | `Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()` | `Pending` durumunda olup `ExpiryDate` geçmiş rezervasyonları kitap ve müşteri ile getirir. |
| GetWithDetailsAsync | `Task<BookReservation?> GetWithDetailsAsync(Guid id)` | Id’ye göre tek rezervasyonu kitap ve müşteri ile birlikte getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgularda ihtiyaç duyulan navigasyonlar `Include` ile eager loading yapılır (kitap ve/veya müşteri).
- `GetByCustomerIdAsync`: `ReservationDate` azalan sıralama ile en güncel rezervasyonlar önce gelir.
- `GetByBookIdAsync`: `QueuePosition` artan sıralama ile bekleme sırası korunur.
- `GetExpiredReservationsAsync`: `Status == Pending` ve `ExpiryDate < DateTime.UtcNow` kriteriyle süresi dolmuş rezervasyonları döner.
- `GetWithDetailsAsync`: Bulunamazsa `null` döner.

**6. Bağlantılar**
- Yukarı akış: Uygulama servisi/komut-handleri veya Controller katmanı üzerinden çağrılır (DI üzerinden çözümlenir).
- Aşağı akış: `LibraryDbContext`, EF Core `DbSet<BookReservation>`, `BaseRepository<T>`.
- İlişkili tipler: `BookReservation`, `ReservationStatus`, `IBookReservationRepository`, `LibraryDbContext`, `BaseRepository<BookReservation>`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametresi yok; uzun sorgularda iptal desteği eksik.
- Sistem zamanı `DateTime.UtcNow` doğrudan kullanılıyor; test edilebilirlik için saat sağlayıcısı soyutlaması düşünülebilir.
- Her sorguda eager loading kullanımı performans açısından seçici olabilir; projeksiyon veya Only-needed `Include` gözden geçirilebilir.

---

Genel Değerlendirme
- Clean Architecture’a uygun Domain ve Infrastructure ayrımı görülüyor; Application ve API katmanları bu dosyadan anlaşılamıyor.
- Repository deseninde EF Core ile spesifik sorgular iyi ayrıştırılmış; iptal belirteci ve saat soyutlaması eklenirse dayanıklılık ve test edilebilirlik artar.
- Konfigürasyon anahtar isimleri ve connection string ayrıntıları görülmüyor; merkezi konfigürasyon belgelendirilmeli.### Project Overview
- Proje adı: Library (çıkarım). Amaç: Kitap incelemeleri için veri erişimi sağlamak; `BookReview` varlıklarına yönelik sorguların gerçekleştirilmesi. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean benzeri yapı. Domain katmanı (entity ve arayüzler) ile Infrastructure katmanı (EF Core tabanlı repository implementasyonları) ayrılmış. Repository deseni ve DI kullanımı mevcut.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — `Entities` ve `Interfaces` (ör. `BookReview`, `IBookReviewRepository`)
  - Library.Infrastructure — EF Core tabanlı repository’ler ve `LibraryDbContext`
- Harici paketler/çerçeveler: `Microsoft.EntityFrameworkCore` (EF Core)
- Konfigürasyon gereksinimleri: Veritabanı bağlantı dizesi ve EF Core `DbContext` yapılandırması muhtemelen gerekli; bu dosyadan detaylar anlaşılmıyor.

### Architecture Diagram
Library.Domain  <--  Library.Infrastructure (Repositories -> DbContext/EF Core)

---

### `Library.Infrastructure/Repositories/BookReviewRepository.cs`

**1. Genel Bakış**
`BookReview` varlığı için EF Core tabanlı repository implementasyonudur. Kitaba veya müşteriye göre inceleme sorguları ve ortalama puan hesaplaması sağlar. Infrastructure katmanında yer alır ve Domain’deki `IBookReviewRepository` arayüzünü uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<BookReview>`
- **Uygular:** `IBookReviewRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `BookReviewRepository(LibraryDbContext context)` | DbContext’i alarak temel repository’yi başlatır. |
| GetByBookIdAsync | `Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)` | Belirli kitabın incelemelerini müşteri bilgisi ile, oluşturulma tarihine göre azalan sıralı döner. |
| GetByCustomerIdAsync | `Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin yaptığı incelemeleri ilgili kitap bilgisi ile döner. |
| GetApprovedReviewsByBookAsync | `Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)` | Onaylanmış incelemeleri müşteri bilgisi ile, oluşturulma tarihine göre azalan sıralı döner. |
| GetAverageRatingByBookAsync | `Task<double> GetAverageRatingByBookAsync(Guid bookId)` | Onaylı incelemelerin ortalama puanını; yoksa 0 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByBookIdAsync`: `Customer` navigation’ı `Include` edilir; `BookId` eşleşen kayıtlar `CreatedAt` azalan sıralanır.
- `GetByCustomerIdAsync`: `Book` navigation’ı `Include` edilir; sıralama uygulanmaz.
- `GetApprovedReviewsByBookAsync`: Sadece `IsApproved == true` olanlar döner; `Customer` dahil, `CreatedAt` azalan sıralanır.
- `GetAverageRatingByBookAsync`: Sadece onaylı incelemeler üzerinden ortalama hesaplar; hiç yoksa `0` döner. Ortalama hesaplaması bellekte (`ToListAsync` sonrası) yapılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya handler’lar `IBookReviewRepository` üzerinden çağırır.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<BookReview>`, ilişkili navigations (`Customer`, `Book`).
- **İlişkili tipler:** `BookReview` (Entity), `IBookReviewRepository` (Arayüz), `BaseRepository<T>`, `LibraryDbContext`, `Book`, `Customer`.

**7. Eksikler ve Gözlemler**
- `GetAverageRatingByBookAsync` veriyi belleğe alıp sonra `Average` hesaplıyor; `AverageAsync` ile direkt veritabanında hesaplamak daha verimli olur.
- `GetByCustomerIdAsync` için sıralama veya filtreleme stratejisi diğer metotlarla tutarlı değil; ihtiyaç varsa sıralama eklenebilir.
- Sayfalama/paginasyon yok; potansiyel büyük sonuç setlerinde performans etkisi olabilir.

---

Genel Değerlendirme
- Kod, Domain ve Infrastructure ayrımını ve Repository desenini takip ediyor; EF Core ile sorgular açık ve anlaşılır.
- Ortalama ve listeleme sorgularında veritabanı tarafında agregasyon ve isteğe bağlı sayfalama eklenmesi performansı iyileştirebilir.
- Onaylı/Onaysız inceleme ayrımı bazı metotlarda var, bazılarında yok; çağıran tarafların gereksinimlerine göre tutarlı bir kontrat belirlenmesi faydalı olur.
- Hedef framework, konfigürasyon anahtarları ve diğer katmanlar (Application/API) bu dosyadan belirlenemiyor.### Project Overview
- Proje adı: Library (koddan türetilen namespace’ler)
- Amaç: Kütüphane alanındaki `Customer` varlıkları için veri erişimi ve sorgulama operasyonları; müşteri bilgisi, aktiflik durumu, ödünç alma ve rezervasyon ilişkileriyle birlikte getirme, arama.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı / Clean Architecture eğilimli. Katmanlar:
  - Domain: `Entities`, `Interfaces` (domain modelleri ve repository sözleşmeleri)
  - Infrastructure: `Data`, `Repositories` (EF Core tabanlı kalıcı hale getirme)
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Varlıklar ve repository arayüzleri
  - Library.Infrastructure — EF Core `DbContext` ve repository implementasyonları
- Kullanılan dış paketler/çatı:
  - Microsoft.EntityFrameworkCore (LINQ, `DbSet`, `Include/ThenInclude`, async sorgular)
- Konfigürasyon gereksinimleri:
  - Veritabanı bağlantı dizesi ve EF Core sağlayıcı yapılandırması bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure (Repositories, Data) --> Library.Domain (Entities, Interfaces)

---

### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`Customer` varlığı için EF Core tabanlı repository implementasyonudur. Müşteriyi email/üye numarası ile getirme, aktif müşterileri listeleme, ödünçler veya rezervasyonlarla birlikte yükleme ve metin arama sağlar. Infrastructure katmanında yer alır; Domain’deki `ICustomerRepository` sözleşmesini uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Customer>`
- **Uygular:** `ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı, `DbSet<Customer>` üzerinden veri erişimi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerRepository(LibraryDbContext context)` | Repository’i EF Core bağlamı ile oluşturur. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | Email’e göre ilk eşleşen müşteriyi getirir. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre ilk eşleşeni getirir. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive` olan tüm müşterileri döner. |
| GetWithLoansAsync | `Task<Customer?> GetWithLoansAsync(Guid id)` | Müşteriyi `BookLoans` ve her loan’ın `Book` navigasyonlarıyla birlikte yükler. |
| GetWithReservationsAsync | `Task<Customer?> GetWithReservationsAsync(Guid id)` | Müşteriyi `BookReservations` ve her rezervasyonun `Book` navigasyonuyla birlikte yükler. |
| SearchAsync | `Task<IEnumerable<Customer>> SearchAsync(string searchTerm)` | Ad, soyad, email veya üyelik numarasında `Contains` ile arama yapar. |

**5. Temel Davranışlar ve İş Kuralları**
- Eager loading: `GetWithLoansAsync` ve `GetWithReservationsAsync` ilgili `Book` navigasyonlarına kadar `Include/ThenInclude` ile yükler.
- `FirstOrDefaultAsync` kullanımı: Eşleşme yoksa `null` döner; exception fırlatmaz.
- Arama: `SearchAsync` metodu `FirstName`, `LastName`, `Email`, `MembershipNumber` üzerinde `Contains` filtre uygular; büyük/küçük harf duyarlılığı veritabanı sağlayıcısına bağlıdır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; servis katmanı veya application katmanı tarafından çağrılması beklenir.
- Aşağı akış: `LibraryDbContext`, EF Core `DbSet<Customer>` ve LINQ.
- İlişkili tipler: `Customer`, `ICustomerRepository`, `BaseRepository<Customer>`, `BookLoan`, `BookReservation`, `Book`.

**7. Eksikler ve Gözlemler**
- `SearchAsync` için `searchTerm` null/boş kontrolü yok; null ise çalışma zamanı hatasına yol açabilir.
- Okuma senaryolarında `AsNoTracking()` kullanılmıyor; yalnızca sorgu performansı/izleme yükü açısından düşünülebilir.
- Metotlarda `CancellationToken` desteği yok; uzun süren sorgular için iptal desteği eklenebilir.
- Email karşılaştırması veritabanı kolasyonuna bağlı; e-posta eşleştirmesinde küçük/büyük harf duyarlılığı net değil.

---

Genel Değerlendirme
- Katman ayrımı net: Infrastructure, Domain’a bağımlı ve EF Core kullanıyor; Clean Architecture yönelimi görülüyor.
- Repository metotları okunabilir ve odaklı; eager loading senaryoları ayrı metotlarla sunulmuş.
- İyileştirme alanları: null/boş parametre kontrolleri, `CancellationToken` desteği, okuma amaçlı sorgularda `AsNoTracking()`, potansiyel case-insensitive arama stratejisinin netleştirilmesi.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanına ait domain varlıkları üzerinde veri erişimi sağlamak; özellikle cezalar (`Fine`) için sorgulama işlemleri.
- Hedef framework: .NET (EF Core ve async/await kullanımından çıkarım; kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari desen: Katmanlı mimari (Domain ve Infrastructure katmanları görünür). Domain: varlıklar, enum’lar ve repository arayüzleri. Infrastructure: EF Core tabanlı repository implementasyonları ve DbContext.
- Projeler/Assembly’ler:
  - Library.Domain — `Entities`, `Enums`, `Interfaces` (repository kontratları)
  - Library.Infrastructure — `Data` (DbContext), `Repositories` (EF Core implementasyonları)
- Dış bağımlılıklar: Microsoft.EntityFrameworkCore (Include/ThenInclude, ToListAsync, SumAsync).
- Konfigürasyon: DbContext bağlantı dizesi vb. ayarlar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain <- Library.Infrastructure.Data  
Library.Domain <- Library.Infrastructure.Repositories  
Library.Infrastructure.Repositories -> Library.Infrastructure.Data  
Library.Infrastructure.* -> Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/FineRepository.cs`

**1. Genel Bakış**
`FineRepository`, `Fine` varlığı için EF Core tabanlı özel sorgular sağlayan repository implementasyonudur. Infrastructure katmanında yer alır ve `IFineRepository` kontratını uygular. Müşteri bazlı, durum bazlı, bekleyen cezalar ve toplam ödenmemiş ceza tutarı gibi sorgular sunar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Fine>`
- **Uygular:** `IFineRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public FineRepository(LibraryDbContext context)` | DbContext’i alarak temel repository altyapısını başlatır. |
| GetByCustomerIdAsync | `public Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm cezalarını, ilgili `BookLoan` ve `Book` ile birlikte döner. |
| GetByStatusAsync | `public Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)` | Verilen duruma sahip cezaları, ilgili `Customer` ile birlikte döner. |
| GetPendingFinesAsync | `public Task<IEnumerable<Fine>> GetPendingFinesAsync()` | `FineStatus.Pending` durumundaki tüm cezaları, `Customer` ve `BookLoan.Book` dahil ederek döner. |
| GetTotalUnpaidFinesByCustomerAsync | `public Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)` | İlgili müşterinin bekleyen (`Pending`) ceza tutarlarının toplamını döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Navigasyonlar: İhtiyaca göre `Include`/`ThenInclude` kullanılarak `Customer`, `BookLoan`, `Book` yüklenir.
- Filtreler:
  - Müşteri kimliğine göre (`CustomerId`) filtreleme.
  - Duruma göre (`FineStatus`) filtreleme.
  - Bekleyen cezalar için `FineStatus.Pending` sabiti kullanımı.
- Toplam tutar: Bekleyen cezaların `Amount` alanı üzerinden `SumAsync` ile hesaplanır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden `IFineRepository` olarak uygulama/servis katmanları veya API controller’ları tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, EF Core `DbSet<Fine>`; `Fine`, `Customer`, `BookLoan`, `Book` varlıkları.
- İlişkili tipler: `IFineRepository`, `BaseRepository<Fine>`, `Fine`, `FineStatus`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Async metotlarda `CancellationToken` parametresi yok; uzun sorgularda iptal desteği eksik.
- Okuma amaçlı sorgularda `AsNoTracking()` tercih edilmemiş; performans ve takip yükü açısından optimize edilebilir.

### Genel Değerlendirme
Kod, Domain ve Infrastructure ayrımını takip eden net bir katmanlı yapı sergiliyor. Repository, EF Core’un ilişki yükleme ve sorgulama yeteneklerini uygun şekilde kullanıyor. İyileştirme olarak iptal belirteci desteği ve okuma senaryolarında `AsNoTracking()` kullanımına yönelik optimizasyonlar önerilir. Daha geniş çözümde Application/API katmanları olasıdır; ancak bu dosyadan kesinleşmiyor. Bağlantı dizesi ve konfigürasyon ayrıntıları görünür değil.### Project Overview
Proje adı: Library (infer edilen). Amaç: Kütüphane alanına yönelik veri erişim katmanında şube (`LibraryBranch`) varlıkları için repository işlemlerini sağlamak. Hedef framework bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı/Clean Architecture eğilimli yapı. Domain katmanı varlıkları ve sözleşmeleri (entity/interface), Infrastructure katmanı ise EF Core tabanlı veri erişimini içeriyor. Infrastructure, Domain’e bağımlı.

Projeler/Assembly’ler:
- Library.Domain — Varlıklar (`Library.Domain.Entities`) ve sözleşmeler (`Library.Domain.Interfaces`).
- Library.Infrastructure — EF Core `DbContext`, generic `BaseRepository<>` ve somut repository’ler.

Kullanılan dış paketler/çerçeveler:
- Microsoft.EntityFrameworkCore (EF Core) — `DbContext`, `DbSet`, `Include`, async LINQ uzantıları.

Konfigürasyon gereksinimleri:
- Veritabanı bağlantı dizesi ve EF Core sağlayıcı yapılandırması bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure → Library.Domain

---

### `Library.Infrastructure/Repositories/LibraryBranchRepository.cs`

**1. Genel Bakış**
`LibraryBranch` varlığı için EF Core tabanlı repository işlemlerini gerçekleştiren somut sınıftır. Aktif şubeleri listeleme ve belirli bir şubenin ilişkili `Staff` veya `Books` koleksiyonlarıyla birlikte yüklenmesini sağlar. Mimari olarak Infrastructure/Repository katmanındadır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<LibraryBranch>`
- **Uygular:** `ILibraryBranchRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı, veri erişimi için.
- `BaseRepository<LibraryBranch>` — Ortak repository işlevleri ve `_dbSet` erişimi.
- `ILibraryBranchRepository` — Domain arayüz sözleşmesi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryBranchRepository(LibraryDbContext context)` | Repository’yi verilen EF Core bağlamıyla başlatır. |
| GetActiveBranchesAsync | `Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()` | `IsActive == true` olan şubeleri döner. |
| GetWithStaffAsync | `Task<LibraryBranch?> GetWithStaffAsync(Guid id)` | Verilen `id` için şubeyi `Staff` navigasyonuyla birlikte yükler. |
| GetWithBooksAsync | `Task<LibraryBranch?> GetWithBooksAsync(Guid id)` | Verilen `id` için şubeyi `Books` navigasyonuyla birlikte yükler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetActiveBranchesAsync` yalnızca `IsActive` bayrağı `true` olan şubeleri filtreler.
- `GetWithStaffAsync` ve `GetWithBooksAsync` ilgili navigasyon koleksiyonlarını `Include` ile eager load eder.
- Kayıt bulunamazsa `null` dönebilir (`FirstOrDefaultAsync`).
- Tüm sorgular EF Core’un async uzantılarını kullanır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya API katmanı tarafından çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext`, EF Core `DbSet<LibraryBranch>`, LINQ/`Include`.
- **İlişkili tipler:** `LibraryBranch` (entity), `ILibraryBranchRepository` (sözleşme), `BaseRepository<LibraryBranch>`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Async metodlarda `CancellationToken` parametresi yok; uzun süren sorgularda iptal desteği eksik.
- Salt-okuma sorgularında `AsNoTracking()` kullanılmıyor; performans/izleme yükü açısından iyileştirilebilir. 

---

### Genel Değerlendirme
Kod, Domain ve Infrastructure ayrımıyla Clean Architecture yönelimini işaret ediyor. Repository deseni ve EF Core kullanımı tutarlı. Gözle görülür eksikler: iptal belirteci desteği ve okuma senaryolarında `AsNoTracking()` kullanımının olmaması. Konfigürasyon, hedef framework ve diğer katmanlar (Application/API) bu parçadan tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: Bildirim verilerinin kalıcı katmanda yönetilmesi (sorgulama ve okundu işaretleme). Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı Mimari (Domain → Infrastructure). Domain katmanı entity ve repository sözleşmelerini içerir (`Library.Domain.Entities`, `Library.Domain.Interfaces`). Infrastructure katmanı EF Core tabanlı veri erişimi ve repository implementasyonlarını sağlar (`Library.Infrastructure`).

Projeler/assembly’ler:
- Library.Domain — Entity’ler ve repository arayüzleri.
- Library.Infrastructure — EF Core `DbContext`, `BaseRepository<T>` ve somut repository’ler.

Harici paket/çatı:
- Microsoft.EntityFrameworkCore — ORM ve asenkron LINQ sorguları.

Konfigürasyon gereksinimleri:
- `LibraryDbContext` için bağlantı dizesi ve sağlayıcı konfigürasyonu — bu dosyadan anlaşılmıyor (appsettings anahtarları belirtilmemiş).

### Architecture Diagram
Library.Domain  ←  Library.Infrastructure  
(Entities, Interfaces)    (DbContext, Repositories using EF Core)

Olası üst katmanlar (bu dosyadan anlaşılmıyor) tipik akışta Infrastructure’ı DI üzerinden tüketir:
[API/Application] → Library.Infrastructure → Library.Domain

---

### `Library.Infrastructure/Repositories/NotificationRepository.cs`

**1. Genel Bakış**
`NotificationRepository`, `Notification` entity’si için EF Core tabanlı sorgulama ve güncelleme işlemlerini sağlar. Domain’de tanımlı `INotificationRepository` sözleşmesini uygular ve Infrastructure katmanında konumlanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Notification>`
- **Uygular:** `INotificationRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `_context` ve `_dbSet` üzerinden veri erişimi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `NotificationRepository(LibraryDbContext context)` | DbContext enjeksiyonu ile repository’yi başlatır. |
| GetByCustomerIdAsync | `Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)` | Belirli müşterinin tüm bildirimlerini `CreatedAt` azalan sırada döner. |
| GetUnreadByCustomerIdAsync | `Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)` | Belirli müşterinin okunmamış bildirimlerini azalan tarihe göre döner. |
| GetUnreadCountByCustomerIdAsync | `Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)` | Belirli müşterinin okunmamış bildirim sayısını döner. |
| MarkAsReadAsync | `Task MarkAsReadAsync(Guid id)` | Bildirimi okundu olarak işaretler; `ReadAt` değerini UTC şimdi ile günceller. |
| MarkAllAsReadAsync | `Task MarkAllAsReadAsync(Guid customerId)` | Müşterinin tüm okunmamış bildirimlerini okundu yapar; `ReadAt` alanını UTC şimdi olarak ayarlar. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular `CustomerId` ve `IsRead` alanlarına göre filtrelenir; sonuçlar `CreatedAt` azalan sırada sıralanır.
- `MarkAsReadAsync` bildirim bulunamazsa sessizce hiçbir işlem yapmaz; bulunduğunda `IsRead = true`, `ReadAt = DateTime.UtcNow` ve `SaveChangesAsync` çağrılır.
- `MarkAllAsReadAsync` okunmamışları belleğe çeker, her birini günceller ve tek bir `SaveChangesAsync` ile kaydeder.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya handler’lar tarafından çağrılması muhtemel.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<Notification>`, `BaseRepository<Notification>`.
- **İlişkili tipler:** `Notification` (entity), `INotificationRepository` (sözleşme), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- `MarkAsReadAsync` bulunamayan `id` için geri bildirim sağlamıyor; gerekirse sonuç bilgisi (örn. bool/etkilenen satır) döndürülmesi düşünülebilir.
- `MarkAllAsReadAsync` büyük veri setlerinde satır-satır güncelleme yapar; toplu güncelleme desteği (EF Core 7+ ExecuteUpdate) performansı iyileştirebilir.

---

Genel Değerlendirme
- Katman ayrımı belirgin: Domain arayüzleri Infrastructure’da uygulanıyor; EF Core kullanımı tutarlı.
- Hata yönetimi ve geri bildirimlerde standardizasyon (ör. etkilenen kayıt sayısı döndürme) iyileştirilebilir.
- Konfigürasyon ve hedef framework bilgisi koddan çıkarılamıyor; dokümantasyonda açıkça tanımlanması önerilir.
- Toplu güncellemelerde performans optimizasyonları değerlendirilebilir.### Project Overview
- Proje adı: Library (infer edilen çözüm adı); amaç: kütüphane alanına ait entity’ler için veri erişimi; hedef framework: bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Tier izleri; Domain katmanı (`Library.Domain`) ve Infrastructure katmanı (`Library.Infrastructure`) gözleniyor. Domain: entity ve kontratlar. Infrastructure: EF Core tabanlı repository implementasyonları ve `DbContext`.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Entity’ler (`Publisher`) ve repository kontratı (`IPublisherRepository`).
  - Library.Infrastructure — EF Core `DbContext` (`LibraryDbContext`) ve repository implementasyonu (`PublisherRepository`).
- Kullanılan dış paket/çatı: Entity Framework Core (`Microsoft.EntityFrameworkCore`).
- Konfigürasyon gereksinimleri: `LibraryDbContext` için bağlantı dizesi ve sağlayıcı ayarları gerekir; anahtar adları ve detaylar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure → Library.Domain

---
### `Library.Infrastructure/Repositories/PublisherRepository.cs`

**1. Genel Bakış**
`Publisher` entity’si için EF Core tabanlı repository implementasyonudur. Yayıncıyı ada göre, ilişkili kitaplarıyla veya aktiflik durumuna göre sorgular. Mimari olarak Infrastructure veri erişim katmanına aittir ve Domain’deki `IPublisherRepository` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Publisher>`
- **Uygular:** `IPublisherRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `BaseRepository` aracılığıyla `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public PublisherRepository(LibraryDbContext context)` | `DbContext` alır ve temel repository’i başlatır. |
| GetByNameAsync | `public Task<Publisher?> GetByNameAsync(string name)` | Ada göre ilk eşleşen yayıncıyı döndürür; yoksa `null`. |
| GetWithBooksAsync | `public Task<Publisher?> GetWithBooksAsync(Guid id)` | Belirtilen `id` için yayıncıyı ilişkili `Books` koleksiyonu ile getirir; yoksa `null`. |
| GetActivePublishersAsync | `public Task<IEnumerable<Publisher>> GetActivePublishersAsync()` | `IsActive` olan tüm yayıncıları listeler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByNameAsync`: `Name == name` filtresi ile tek yayıncıyı seçer; bulunamazsa `null`.
- `GetWithBooksAsync`: `Include(p => p.Books)` ile eager loading yapar; bulunamazsa `null`.
- `GetActivePublishersAsync`: `IsActive == true` olan yayıncıları döndürür.
- Tüm sorgular EF Core üzerinden asenkron çalışır ve `FirstOrDefaultAsync`/`ToListAsync` kullanır.
- İsteklerde `CancellationToken` parametresi bulunmuyor; iptal desteklenmez.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; `IPublisherRepository` kullanan servisler/uygulama katmanı çağırır.
- **Aşağı akış:** `LibraryDbContext`, `Microsoft.EntityFrameworkCore`.
- **İlişkili tipler:** `Publisher`, `IPublisherRepository`, `BaseRepository<Publisher>`.

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` desteği yok.
- Okuma senaryolarında `AsNoTracking()` kullanılmıyor; yalnızca sorgu-performans/izleme maliyeti açısından not edilebilir.

### Genel Değerlendirme
Kod, Clean Architecture’a uygun olarak Infrastructure katmanında EF Core repository desenini uygular ve Domain kontratlarını referanslar. Mevcut görünürlükte yalnızca `Publisher` odağında sorgular bulunuyor. İptal belirteci ve olası `AsNoTracking` kullanımı gibi iyileştirmeler değerlendirilebilir. Çözümün diğer katmanları (Application/Presentation) bu girdiden anlaşılamıyor; yapı muhtemelen genişleyebilir ve DI, konfigürasyon ile tamlanmalıdır.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım). Amaç: kütüphane alanı için personel ve şubelerle ilişkili veri erişimi sağlamak. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Tier benzeri. Domain katmanı entity ve interface’leri barındırır; Infrastructure katmanı EF Core tabanlı veri erişimi (DbContext, Repository) sağlar.
- Projeler/Assembly’ler:
  - Library.Domain — `Entities`, `Interfaces` (ör. `Staff`, `IStaffRepository`)
  - Library.Infrastructure — `Data` (ör. `LibraryDbContext`), `Repositories` (ör. `StaffRepository`)
- Kullanılan ana paketler/çerçeveler:
  - Microsoft.EntityFrameworkCore (EF Core) — asenkron sorgular, `DbSet`, `Include`
- Konfigürasyon gereksinimleri:
  - `LibraryDbContext` için veritabanı bağlantı dizesi gerekli; anahtar adı ve sağlayıcı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`Staff` varlıkları için EF Core tabanlı repository implementasyonudur. Personeli e-posta, aktiflik durumu, şube ve sicil/çalışan numarasına göre sorgular. Mimari olarak Infrastructure/Data Access katmanına aittir ve `IStaffRepository` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `BaseRepository<Staff>`
- **Uygular:** `IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; temel `BaseRepository` üzerinden `_dbSet` erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Kurucu | `public StaffRepository(LibraryDbContext context)` | DbContext’i alarak temel repository’yi başlatır. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | E‑posta adresine göre ilk eşleşen personeli getirir. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive` olan tüm personeli listeler. |
| GetByBranchIdAsync | `public Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)` | Verilen şubeye bağlı personeli, `LibraryBranch` navigasyonu dahil edilerek getirir. |
| GetByEmployeeNumberAsync | `public Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)` | Çalışan numarasına göre ilk eşleşen personeli getirir. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular asenkron ve EF Core LINQ ifadeleriyle gerçekleştirilir.
- `GetByBranchIdAsync` ilgili `LibraryBranch` navigasyonunu `Include` ile eager load eder.
- E‑posta/çalışan numarası aramaları ilk eşleşeni döndürür; birden fazla eşleşme durumunda ilk kayıt alınır.
- Girdi validasyonu (null/boş email gibi) bu seviyede yapılmıyor; parametreler doğrudan sorguda kullanılıyor.

**6. Bağlantılar**
- Yukarı akış: `IStaffRepository` üzerinden DI ile çözümlenip uygulama hizmetleri veya API katmanı tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, EF Core `DbSet<Staff>`, `Include`/LINQ altyapısı.
- İlişkili tipler: `Staff` (Entity), `LibraryBranch` (navigasyon), `IStaffRepository` (kontrat), `BaseRepository<Staff>` (temel davranış), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok; uzun süren sorgular için iptal desteği eklenebilir.
- Parametre validasyonu (örn. boş `email` veya `employeeNumber`) yapılmıyor; üst katmanda doğrulanması gerekir.

---

Genel Değerlendirme
- Kod, Domain ve Infrastructure ayrımını tutarlı şekilde izliyor; repository deseni EF Core ile uygulanmış.
- İptal belirteçleri ve giriş validasyonu üst katmanlara bırakılmış; kritik sorgularda eklenmesi faydalı olabilir.
- Hedef framework, konfigürasyon anahtarları ve kalan katmanlar (Application/API) bu dosyadan görülemiyor; proje genelinde belgelenmesi önerilir.### Project Overview
- Proje adı: Library
- Amaç: Yazar yönetimi için HTTP tabanlı CRUD ve arama uç noktaları sağlayan bir ASP.NET Core Web API sunmak.
- Hedef framework: ASP.NET Core (kesin sürüm bu dosyadan anlaşılmıyor)
- Mimari desen: Katmanlı mimari (API/Presentation → Application). API katmanı controller’lar üzerinden Application katmanındaki servis arabirimlerine çağrı yapar. Application katmanı DTO’lar ve servis kontratlarını barındırır.
- Projeler/Assemblies:
  - Library (API/Presentation): HTTP endpoint’leri; controller’lar.
  - Library.Application (Application): `DTO` ve `Service` arabirimleri (görünen isimlere göre).
- Kullanılan dış paket/çerçeveler:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/AuthorsController.cs`

**1. Genel Bakış**
`AuthorsController`, yazarlar için listeleme, detay, arama, oluşturma, güncelleme ve silme uç noktalarını sağlayan API controller’ıdır. Presentation katmanında yer alır ve iş kurallarını `IAuthorService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IAuthorService` — Yazarların alınması, aranması, oluşturulması, güncellenmesi ve silinmesi için uygulama servis kontratı.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public AuthorsController(IAuthorService authorService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()` | Tüm yazarları döndürür; 200 OK. |
| GetById | `public async Task<ActionResult<AuthorDto>> GetById(Guid id)` | Id’ye göre yazarı döndürür; yoksa 404 NotFound. |
| Search | `public async Task<ActionResult<IEnumerable<AuthorDto>>> Search([FromQuery] string term)` | Sorgu parametresi ile arama yapar; 200 OK. |
| Create | `public async Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorDto createDto)` | Yeni yazar oluşturur; 201 Created ve `Location` başlığı ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto updateDto)` | Var olan yazarı günceller; 204 NoContent (404 için response type tanımlı). |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Yazarı siler; 204 NoContent (404 için response type tanımlı). |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound döner.
- `Create`: Başarılı oluşturma sonrasında `CreatedAtAction` ile 201 ve kaynak konumu döndürülür.
- `Update` ve `Delete`: Başarıda 204 NoContent; 404 durumunun nasıl tetikleneceği servis katmanındaki davranışa bağlıdır (bu dosyadan anlaşılmıyor).
- `Search`: `term` ile arama; boş/invalid `term` için validasyon bu dosyada yok, servis katmanına bırakılmış olabilir.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (mobil/web/entegrasyonlar).
- **Aşağı akış:** `IAuthorService`
- **İlişkili tipler:** `AuthorDto`, `CreateAuthorDto`, `UpdateAuthorDto`, `IAuthorService`

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme öznitelikleri (`[Authorize]`) yok; güvenlik gereksinimlerine göre eklenmesi gerekebilir.
- `Update`/`Delete` için 404 durumlarının nasıl üretildiği controller’da net değil; servis katmanının uygun exception/sonuç ürettiği varsayılıyor. Bu sözleşme belirsizliği dokümante edilmeli.

---
Genel Değerlendirme
- Mimari olarak API → Application katmanları net; Domain/Infrastructure katmanları bu dosyadan görünmüyor.
- Exception ve hata eşleme sözleşmeleri (ör. servis hataları → HTTP durum kodları) merkezi bir politika veya filtre ile standartlaştırılmalı.
- Giriş doğrulama için model validation öznitelikleri veya `FluentValidation` benzeri bir çözüm kullanılacaksa izleri bu dosyada yok; proje genelinde tutarlılık sağlanmalı.
- Yetkilendirme ve kimlik doğrulama stratejisi tanımlı değil; security gereksinimleri belirlenip uygulanmalı.### Project Overview
Proje adı: Library. Amaç: ASP.NET Core Web API üzerinden kitap kategorileri gibi kütüphane odaklı operasyonları sunmak. Hedef çatı: ASP.NET Core Web API; .NET sürümü bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı (API → Application). API katmanı `Controllers` üzerinden HTTP uç noktalarını sağlar. Application katmanı `Library.Application.DTOs` ve `Library.Application.Interfaces` ile sözleşmeler ve DTO’ları barındırır.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library (API/Presentation) — ASP.NET Core Web API, controller uç noktaları.
- Library.Application (Application) — Servis arabirimleri (`IBookCategoryService`) ve DTO’lar (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`).

Kullanılan ana dış çerçeveler/paketler:
- Microsoft.AspNetCore.Mvc (ASP.NET Core MVC/Web API).

Konfigürasyon gereksinimleri:
- Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Controllers) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorilerine yönelik CRUD uç noktalarını sağlayan ASP.NET Core API controller’ıdır. Presentation/API katmanında yer alır ve iş kurallarını `IBookCategoryService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori CRUD işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategorileri döner; 200 OK. |
| GetById | `public async Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID’ye göre kategori getirir; bulunamazsa 404 NotFound. |
| Create | `public async Task<ActionResult<BookCategoryDto>> Create([FromBody] CreateBookCategoryDto createDto)` | Yeni kategori oluşturur; 201 Created ve konum başlığıyla döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookCategoryDto updateDto)` | Var olan kategoriyi günceller; 204 NoContent. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Kategoriyi siler; 204 NoContent. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` ile 404.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile 201 ve `Location` header’ı üretir.
- `Update` ve `Delete`: Başarılı işlemde 204 NoContent döner.
- `ProducesResponseType` öznitelikleri ile beklenen durum kodları belgelidir; 409 Conflict olasılığı belirtilmiş ancak sebebi bu dosyadan anlaşılmıyor.
- Hata yönetimi ve validasyon istisnalarının HTTP durum kodlarına eşlenmesi muhtemelen global exception handling’e bırakılmış; bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; HTTP istemcileri (API tüketicileri) tarafından çağrılır.
- **Aşağı akış:** `IBookCategoryService`.
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `IBookCategoryService`.

**7. Eksikler ve Gözlemler**
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; güvenlik gerektiren senaryolarda eksik olabilir.
- `CancellationToken` desteği yok; uzun süren işlemlerde iptal desteği düşünülebilir.
- Girdi model validasyonuna dair `[FromBody]` dışında ek anotasyonlar görünmüyor; model hataları için tutarlı yanıt stratejisi bu dosyadan anlaşılmıyor.

---
Genel Değerlendirme
- Katman ayrımı net: API → Application. Domain/Infrastructure katmanları bu dosyalardan görünmüyor.
- Uç noktalar RESTful ilkelere uygun ve durum kodları tutarlı şekilde belirtilmiş.
- Yetkilendirme, global hata yönetimi, logging, model validasyonu ve iptal belirteçleri gibi çapraz kesen kaygılara dair uygulama bu dosyadan anlaşılmıyor; projede standartlaştırılması önerilir.### Project Overview
Proje adı: Library. Amaç: kütüphane ödünç alma işlemlerine yönelik HTTP API uç noktaları sunmak. Hedef çatı: ASP.NET Core Web API (tam sürüm bu dosyadan anlaşılmıyor).

Mimari: Katmanlı mimari. Katmanlar:
- Domain: İş kurallarına ait türler ve enum’lar (örn. `Library.Domain.Enums.LoanStatus`).
- Application: Uygulama servisleri ve DTO’lar (örn. `Library.Application.DTOs.*`, `Library.Application.Interfaces.IBookLoanService`).
- API/Presentation: HTTP controller’lar (örn. `Library.Controllers.BookLoansController`).

Projeler/assembly’ler:
- Library (API/Presentation) — Web API uç noktaları.
- Library.Application — Servis sözleşmeleri ve DTO’lar.
- Library.Domain — Temel domain türleri ve enum’lar.

Harici paketler/çerçeveler: `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC). Diğerleri bu dosyadan anlaşılmıyor.

Yapılandırma: Herhangi bir connection string veya app settings anahtarı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain <- Application <- API/Presentation (Library)

API/Presentation (Library) --> Library.Application.Interfaces, Library.Application.DTOs
Library.Application --> Library.Domain.Enums

---
### `Library/Controllers/BookLoansController.cs`

**1. Genel Bakış**
`BookLoansController`, kitap ödünç alma süreçlerine ilişkin sorgulama, oluşturma, iade ve yenileme gibi uç noktaları sağlar. Presentation katmanında yer alır ve iş mantığını `IBookLoanService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookLoanService` — Ödünç alma işlemlerinin iş kurallarını ve veri erişimini yöneten uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookLoansController(IBookLoanService loanService)` | Servis bağımlılığını DI ile alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetAll()` | Tüm ödünç kayıtlarını döner. |
| GetById | `public Task<ActionResult<BookLoanDto>> GetById(Guid id)` | Id’ye göre ödünç kaydı döner; yoksa 404. |
| GetByCustomer | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetByCustomer(Guid customerId)` | Müşteriye göre ödünç kayıtlarını döner. |
| GetActive | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetActive()` | Aktif ödünç kayıtlarını döner. |
| GetOverdue | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetOverdue()` | Geciken ödünç kayıtlarını döner. |
| GetByStatus | `public Task<ActionResult<IEnumerable<BookLoanDto>>> GetByStatus(LoanStatus status)` | Duruma göre ödünç kayıtlarını döner. |
| Create | `public Task<ActionResult<BookLoanDto>> Create([FromBody] CreateBookLoanDto createDto)` | Yeni ödünç kaydı oluşturur; 201 ve `Location` ile döner. |
| ReturnBook | `public Task<ActionResult<BookLoanDto>> ReturnBook(Guid id, [FromBody] ReturnBookLoanDto returnDto)` | İlgili ödünç kaydı için iade işlemi yapar. |
| RenewLoan | `public Task<ActionResult<BookLoanDto>> RenewLoan(Guid id, [FromBody] RenewBookLoanDto renewDto)` | Ödünç kaydını yeniler (süre uzatma). |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Ödünç kaydını siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- [ApiController] ile model doğrulama ve binding hatalarında otomatik 400 üretilir.
- `GetById` için servis `null` dönerse 404 verilir.
- `Create` işleminde `CreatedAtAction` ile yeni kaynağın adresi döndürülür.
- Listeleme uçları filtrelenmiş veri setlerini servis üzerinden getirir (`active`, `overdue`, `status`).
- `ReturnBook` ve `RenewLoan` servis çağrısının sonucunu 200 OK ile döner.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri).
- **Aşağı akış:** `IBookLoanService`.
- **İlişkili tipler:** `BookLoanDto`, `CreateBookLoanDto`, `ReturnBookLoanDto`, `RenewBookLoanDto`, `LoanStatus`, `IBookLoanService`.

**7. Eksikler ve Gözlemler**
- `Delete` aksiyonu `[ProducesResponseType(StatusCodes.Status404NotFound)]` belirtmesine rağmen metod içinde 404 dönüşü işlenmemiş; servis istisna fırlatıyorsa global hata işleme gerekli, aksi halde belge imzasıyla tutarsızlık var.
- Yetkilendirme/kimlik doğrulama öznitelikleri görülmüyor; erişim kontrolü yoksa güvenlik açısından değerlendirilmelidir.

---
Genel Değerlendirme
Kod, tipik bir katmanlı mimariyi izleyerek Controller’dan Application servislerine net ayrım yapıyor. Sözleşmeler (`IBookLoanService`) ve DTO kullanımı tutarlı. API yüzeyinde durum kodları çoğunlukla açık; ancak 404 dönüşlerinin bazı eylemlerde (özellikle Delete) somut işlenişi belirsiz. Yetkilendirme politikaları görünür değil; güvenlik gereksinimleri doğrultusunda eklenmesi önerilir. Global hata yönetimi ve problem detayları (ProblemDetails) açısından projede ortak bir yaklaşımın olup olmadığı bu dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library  
Amaç: Kitap rezervasyonlarını HTTP üzerinden yönetmek için bir ASP.NET Core Web API sunmak (listeleme, detay, oluşturma, iptal, tamamlama, silme).  
Hedef framework: Bu dosyadan kesin değil; ASP.NET Core Web API kullanımı görülüyor.  
Mimari: N‑Katmanlı mimari.  
- Presentation/API: `Library` (Controllers katmanı) — HTTP endpoint’leri, istek/yanıt sözleşmeleri ve yönlendirme.  
- Application: `Library.Application` — `DTO` ve `IBookReservationService` gibi servis sözleşmeleri; iş kuralları ve kullanım senaryoları burada konumlanır (bu dosyadan implementasyon görülmüyor).  
Projeler/Assembly’ler:  
- Library (API/Presentation)  
- Library.Application (Application katmanı: DTO’lar ve servis arayüzleri)  
Dış bağımlılıklar:  
- `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC/Web API)  
Konfigürasyon: Bu dosyadan belirgin bir appsettings anahtarı veya connection string gereksinimi görülmüyor.

### Architecture Diagram
Library (API/Controllers)
  ↓ depends on
Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookReservationsController.cs`

**1. Genel Bakış**  
`BookReservationsController`, kitap rezervasyonlarına yönelik REST tarzı uç noktaları sunar: listeleme, id’ye göre getirme, müşteri/kitaba göre filtreleme, oluşturma, iptal, tamamlama ve silme. Presentation/API katmanına aittir ve Application katmanındaki `IBookReservationService` üzerinden iş akışlarını tetikler.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `IBookReservationService` — Rezervasyonlara ilişkin uygulama hizmeti; okuma/yazma işlemlerini ve iş kurallarını yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookReservationsController(IBookReservationService reservationService)` | Servisi DI ile alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookReservationDto>>> GetAll()` | Tüm rezervasyonları döndürür. |
| GetById | `public Task<ActionResult<BookReservationDto>> GetById(Guid id)` | Id’ye göre rezervasyonu döndürür, yoksa 404. |
| GetByCustomer | `public Task<ActionResult<IEnumerable<BookReservationDto>>> GetByCustomer(Guid customerId)` | Müşteri id’sine göre rezervasyonları listeler. |
| GetByBook | `public Task<ActionResult<IEnumerable<BookReservationDto>>> GetByBook(Guid bookId)` | Kitap id’sine göre rezervasyonları listeler. |
| Create | `public Task<ActionResult<BookReservationDto>> Create([FromBody] CreateBookReservationDto createDto)` | Yeni rezervasyon oluşturur, 201 ve Location döner. |
| Cancel | `public Task<IActionResult> Cancel(Guid id)` | Rezervasyonu iptal eder, 204 döner. |
| Fulfill | `public Task<IActionResult> Fulfill(Guid id)` | Rezervasyonu tamamlama olarak işaretler, 204 döner. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Rezervasyonu siler, 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servisten `null` dönerse `NotFound (404)` üretir.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile `Location` header ve oluşturulan kaydı döner (201).
- `Cancel`, `Fulfill`, `Delete`: Başarılı işlemde `NoContent (204)` döner; hata durumlarının (ör. 404) servis tarafından exception/sonuçla sağlandığı varsayılır.
- Yönlendirme: `[Route("api/[controller]")]`, id ve filtreler için `guid` kısıtları kullanılmış.
- İçerik türü: `application/json` üretilir.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (frontend, entegrasyonlar) bu controller’ı çağırır.
- Aşağı akış: `IBookReservationService`.
- İlişkili tipler: `BookReservationDto`, `CreateBookReservationDto`, `IBookReservationService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: Endpoint’lerde `[Authorize]` veya benzeri yetkilendirme niteliği görülmüyor; kimlik doğrulama/yetkilendirme gereksinimi varsa eklenmeli.
- Hata yönetimi: `Create`, `Cancel`, `Fulfill`, `Delete` için 400/409 gibi durum kodlarına yönelik ayrık dönüşler tanımlı değil; servis katmanındaki hatalar HTTP seviyesine eşlenmiyor olabilir.

### Genel Değerlendirme
- Katmanlar arası bağımlılık yönü doğru: API sadece Application arayüzlerine dayanıyor.  
- DTO ve servis arayüzleri Application’da konumlanmış; ancak Domain/Infrastructure katmanları bu dosyadan görünmüyor.  
- API güvenliği ve hata eşleme politikaları (problem details, exception middleware, validation) belirsiz; standart bir global hata/yetkilendirme yaklaşımı eklenmesi önerilir.  
- Versiyonlama ve pagination/filtreleme parametreleri (özellikle liste uç noktaları için) tanımlı değil; ihtiyaç varsa eklenmeli.### Project Overview
Proje adı: Library. Amaç: Kitap incelemeleri için RESTful uç noktalar sağlayan bir ASP.NET Core Web API sunmak. Hedef çatı: .NET (ASP.NET Core) — tam sürüm bu dosyadan anlaşılmıyor.

Mimari: N-Tier. Katmanlar:
- API/Presentation: ASP.NET Core Controller’ları HTTP isteklerini alır ve Application katmanına delege eder.
- Application: `Library.Application` namespace’i altındaki servisler (`IBookReviewService`) ve DTO’lar (`BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`) iş kurallarını ve veri aktarımını temsil eder.
- Domain/Infrastructure: Bu dosyadan doğrudan görünmüyor.

Projeler/Assembly’ler:
- Library (API) — Controller’lar, HTTP uç noktaları.
- Library.Application (Application) — Servis kontratları ve DTO’lar.

Dış bağımlılıklar:
- ASP.NET Core MVC/Web API (`Microsoft.AspNetCore.Mvc`).

Yapılandırma:
- Bu dosyadan özel konfigürasyon anahtarları veya connection string gereksinimleri anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Services & DTOs)
Library.Application --> (Domain/Infrastructure) [bu dosyadan görülmüyor]

---
### `Library/Controllers/BookReviewsController.cs`

**1. Genel Bakış**
`BookReviewsController`, kitap incelemeleriyle ilgili okuma, oluşturma, güncelleme, onaylama ve silme işlemleri için HTTP uç noktaları sunar. API/Presentation katmanındadır ve tüm iş mantığını `IBookReviewService`’e delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookReviewService` — Kitap incelemeleri için iş mantığı ve veri erişim operasyonlarına aracılık eden uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookReviewsController(IBookReviewService reviewService)` | Servis bağımlılığını enjekte eder. |
| GetByBook | `Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(Guid bookId)` | Belirli kitabın tüm incelemelerini döndürür. |
| GetByCustomer | `Task<ActionResult<IEnumerable<BookReviewDto>>> GetByCustomer(Guid customerId)` | Belirli müşterinin tüm incelemelerini döndürür. |
| GetAverageRating | `Task<ActionResult<double>> GetAverageRating(Guid bookId)` | Belirli kitabın ortalama puanını döndürür. |
| GetById | `Task<ActionResult<BookReviewDto>> GetById(Guid id)` | İncelemeyi kimliğine göre getirir; yoksa 404 döner. |
| Create | `Task<ActionResult<BookReviewDto>> Create(CreateBookReviewDto createDto)` | Yeni inceleme oluşturur; 201 ve konum başlığı döner. |
| Update | `Task<IActionResult> Update(Guid id, UpdateBookReviewDto updateDto)` | Var olan incelemeyi günceller; 204 döner. |
| Approve | `Task<IActionResult> Approve(Guid id)` | İncelemeyi onaylar; 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | İncelemeyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretir.
- `Create`: Başarı durumunda `CreatedAtAction(nameof(GetById), new { id = review.Id }, review)` ile 201 döner.
- `Update`, `Approve`, `Delete`: Başarı durumunda `NoContent()` döner. 404 ve diğer hata durumları servis tarafından fırlatılan istisnalara bağlı; controller içinde özel yakalama yok.
- Rotalar GUID kısıtlarıyla tanımlıdır (`{id:guid}`, `{bookId:guid}`, `{customerId:guid}`).
- Yanıt içerik türü `application/json`.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (örn. Web/Mobil uygulamalar).
- Aşağı akış: `IBookReviewService`.
- İlişkili tipler: `BookReviewDto`, `CreateBookReviewDto`, `UpdateBookReviewDto`, `IBookReviewService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: Yetkilendirme/kimlik doğrulama öznitelikleri yok (`[Authorize]` vb.); korumalı olması beklenen işlemler (oluşturma, güncelleme, silme, onay) için risk.
- Hata yönetimi: `Update`, `Approve`, `Delete` için 404 dönebilir olarak belgelense de controller’da özel kontrol yok; bu durumun servis istisnalarına bırakılması tutarlı ancak açık değil.
- Girdi doğrulama: ModelState kontrolü veya DTO seviyesinde doğrulama görünmüyor; hatalar muhtemelen `ApiController` özniteliğinin otomatik model doğrulamasına bırakılmış.

---
Genel Değerlendirme
- Katman ayrımı net: Controller yalnızca Application servislerine delege ediyor; bu iyi bir uygulama.
- Güvenlik açıklığı: Yetkilendirme yok; özellikle mutasyon uç noktaları için rol/kimlik denetimleri eklenmeli.
- Gözlemlenebilirlik: Günlükleme, izleme veya problem detayları için standartlaştırılmış hata yanıtları görünmüyor.
- Sözleşme netliği: Servis istisna davranışları belgelenmemiş; 404/400 gibi durumların tutarlı yönetimi için hata eşleme stratejisi önerilir.### Project Overview
- Proje adı: Library (RESTful kitap yönetimi API’si). Amaç: kitapları listeleme, getirme, oluşturma, güncelleme ve silme işlemlerini HTTP üzerinden sunmak. Hedef çatı: ASP.NET Core Web API (modern .NET, >= .NET 6 tahmini; koddan net sürüm anlaşılmıyor).
- Mimari desen: N‑Katmanlı (API/Presentation → Application). Controller, `Library.Application.DTOs` ve `Library.Application.Interfaces` katmanlarına bağımlı; Domain/Infrastructure katmanları bu dosyadan görünmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library (API/Presentation): HTTP endpoint’leri barındırır.
  - Library.Application (referans): Uygulama sözleşmeleri (`IBookService`) ve DTO’lar (`BookDto`, `CreateBookDto`, `UpdateBookDto`).
- Dış bağımlılıklar: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). EF Core, MediatR vb. bu dosyadan anlaşılamıyor.
- Konfigürasyon: Bağlantı dizgileri veya app settings anahtarları bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplara yönelik CRUD ve durum bazlı listeleme endpoint’lerini sağlar. Presentation/API katmanında yer alır ve iş kurallarını `IBookService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplar için uygulama servisi; listeleme, getirme, oluşturma, güncelleme ve silme operasyonlarını yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BooksController(IBookService bookService)` | Servis bağımlılığını alır. |
| GetAll | `Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döner. |
| GetById | `Task<ActionResult<BookDto>> GetById(Guid id)` | Kimliğe göre kitabı döner; yoksa 404. |
| GetAvailable | `Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Müsait kitapları döner. |
| Create | `Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Yeni kitap oluşturur; 201 ve Location başlığı ile döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Kitabı günceller; 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Kitabı siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile 201 ve `Location` header’ı üretir.
- `Update`/`Delete`: Başarılı kabul edilip 204 NoContent döner; bulunamama ve çakışma durumlarının servisten exception/sonuçla yönetildiği varsayılır (controller düzeyinde kontrol yok).
- Model state/doğrulama controller’da özel mantıkla ele alınmıyor; `ApiController` özniteliği ile otomatik model doğrulama varsayılır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, entegrasyonlar); DI üzerinden çözümlenir.
- **Aşağı akış:** `IBookService`.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`.

**7. Eksikler ve Gözlemler**
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; tüm endpoint’ler açık görünüyor.
- `Update` ve `Delete` için 404 yanıt beyan edilmiş ancak controller içinde bulunamama kontrolü yok; servis tarafı exception eşlemesiyle çözülmesi gerekir. Bu eşleme middleware/filters ile yapılmıyorsa 500’e düşebilir.
- `Create` için 409 çatışma durumu beyanlı; controller içinde özel çatışma yönetimi görünmüyor. Servis veya global exception handling ile uyum kontrol edilmeli.

---
Genel Değerlendirme
- Mimari katmanlaşma net: API katmanı Application’a bağımlı. Domain/Infrastructure katmanları görünmediği için veri erişimi ve transaction yönetimi belirsiz.
- Hata yönetimi ve istisna-hata kodu eşlemesi controller dışına bırakılmış görünüyor; global exception handling/middleware veya action filters ile tutarlı yanıt sözleşmesi sağlanmalı.
- Güvenlik açısından Authorization eksik; uç noktaların korunması için `[Authorize]` veya politika bazlı yetkilendirme eklenmesi önerilir.
- API sözleşmesi tutarlılığı için 400/404/409 durumlarının servis istisnalarıyla sistematik haritalanması ve dokümantasyonu faydalı olacaktır.### Project Overview
- Proje adı: Library
- Amaç: Müşteri yönetimi için RESTful uç noktalar sağlayan bir ASP.NET Core Web API katmanı.
- Hedef framework: ASP.NET Core (çağdaş .NET, kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari: Katmanlı mimari (API/Presentation → Application). API katmanı `Library.Application` içindeki `DTO` ve `Service` arayüzlerini kullanır. Alan ayrımı: 
  - API/Presentation: Controllers, HTTP endpoint’leri ve HTTP yanıt sözleşmeleri.
  - Application: `DTO`lar ve `ICustomerService` gibi iş mantığı arayüzleri (uygulama mantığı burada).
- Projeler/assembly’ler:
  - Library (API/Presentation) — `Controllers` barındırır.
  - Library.Application (Application) — `DTO` ve `Interfaces` kullanımları görüldü.
- Harici paket/çatı:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon gereksinimleri: Bu dosyadan özel bir appsettings anahtarı veya connection string görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri varlıklarına yönelik CRUD ve filtreleme (aktif müşteriler) uç noktalarını sunan API denetleyicisidir. Presentation katmanında yer alır ve iş mantığını `ICustomerService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri verileri için uygulama düzeyi iş mantığı ve veri erişimi koordinasyonu.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public CustomersController(ICustomerService customerService)` | Hizmeti DI üzerinden alır. |
| GetAll | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döndürür (`200 OK`). |
| GetById | `public Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID ile müşteri getirir; yoksa `404 NotFound`. |
| GetActive | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döndürür (`200 OK`). |
| Create | `public Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Müşteri oluşturur; `201 Created` ve `Location` header ile. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Müşteriyi günceller; `204 NoContent`. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` bulunamayan kayıt için `NotFound()` döndürür.
- `Create` başarılı olduğunda `CreatedAtAction` ile kaynak konumunu ayarlar; `ProducesResponseType` ile `409 Conflict` olasılığı belirtilmiş ancak somut dönüş yok; muhtemelen service/exception middleware ile yönetilir.
- `Update` ve `Delete` `204 NoContent` döndürür; `404` belirtilmiş ancak controller içinde açık kontrol yok; bulunamama senaryosu için servis veya global hata işleme beklenir.
- Tüm işlemler asenkron `Task` tabanlıdır.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (frontend, entegrasyonlar).
- Aşağı akış: `ICustomerService`.
- İlişkili tipler: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme/authorization öznitelikleri yok; güvenlik ihtiyacı varsa eklenmeli.
- `Update`/`Delete` için `404` dönüş mantığı controller’da açık değil; global exception handling varsayılıyor. Middleware yoksa tutarsızlık olabilir.
- `Create` için `409 Conflict` üretilmesi controller seviyesinde ele alınmıyor; servis veya filtreye bağımlı.

---
Genel Değerlendirme
- Mimari, sade bir API → Application bağımlılığı ile katmanlı düzeni takip ediyor; Domain/Infrastructure katmanları bu dosyadan görünmüyor.
- Hata yönetimi ve bulunamayan kaynak akışı büyük ölçüde servis/exception middleware’e bırakılmış; proje genelinde tutarlı bir global hata işleme politikası olduğundan emin olunmalı.
- Güvenlik (örn. `[Authorize]`) görünmüyor; üretim senaryoları için rol/tabanlı yetkilendirme ve doğrulama eklenmesi önerilir.
- Model doğrulaması `ApiController` özniteliği sayesinde otomatik; ancak iş kuralları doğrulamalarının servis katmanında netleştirilmesi faydalı olacaktır.### Project Overview
Proje adı: Library. Amaç: Kütüphane alanına yönelik bir Web API’sinde dashboard istatistiklerini sunmak. Hedef çatı: ASP.NET Core Web API (kesin .NET sürümü bu dosyadan anlaşılmıyor).

Mimari: Katmanlı (N-Tier/Clean benzeri). API katmanı (`Library`) Application katmanındaki arayüz ve DTO’lara (`Library.Application.Interfaces`, `Library.Application.DTOs`) bağımlı.

Projeler/Assembly’ler:
- Library (API/Presentation) — HTTP endpoint’leri, controller’lar.
- Library.Application (Application) — `DTO` ve `Service` arayüzleri (bu dosyadan referanslar görülüyor).

Kullanılan dış çerçeveler/paketler:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).

Konfigürasyon gereksinimleri:
- Bu dosyadan konfigürasyon anahtarı veya connection string bilgisi anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/DashboardController.cs`

**1. Genel Bakış**
`DashboardController`, dashboard istatistiklerini HTTP üzerinden sunan API denetleyicisidir. Presentation/API katmanında yer alır ve Application katmanındaki `IDashboardService` üzerinden veriyi çeker.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IDashboardService` — Dashboard istatistiklerini uygulama katmanından sağlayan servis arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `DashboardController(IDashboardService dashboardService)` | Servis bağımlılığını DI üzerinden alır. |
| GetStats | `Task<ActionResult<DashboardStatsDto>> GetStats()` | `GET api/dashboard/stats` çağrısında dashboard istatistiklerini 200 ile döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GET api/[controller]/stats` route’u ile çalışır; JSON üretir (`[Produces("application/json")]`).
- `IDashboardService.GetStatsAsync()` çağrısının sonucunu `200 OK` olarak döner.
- Dönüş tipi `DashboardStatsDto` olarak tiplenmiş response schema üretir (`[ProducesResponseType]`).

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, entegrasyonlar) bu endpoint’i çağırır.
- **Aşağı akış:** `IDashboardService` (Application katmanı).
- **İlişkili tipler:** `DashboardStatsDto`, `IDashboardService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: Endpoint’te herhangi bir `[Authorize]` niteliği görülmüyor; istatistiklerin korunması gerekiyorsa yetkilendirme eklenmeli.
- Hata yönetimi: Servis hatalarında özel durum (ör. 4xx/5xx) eşlemesi yapılmıyor; global exception handling yoksa ayrıştırılmış hata yanıtları eklenmeli.

---
### Genel Değerlendirme
Kod, katmanlı mimariye uygun olarak API katmanının Application katmanına bağımlılığını gösteriyor. Controller temiz ve tek sorumluluğa odaklı. Yetkilendirme ve hata yönetimi stratejileri bu dosyada görünmüyor; proje genelinde global exception handling, problem details ve yetkilendirme politikalarının tanımlı olması önerilir. DTO ve servis arayüzlerinin bulunduğu `Library.Application` referansları doğru katman ayrımını işaret ediyor; ancak domain ve infrastructure katmanları bu girdiyle doğrulanamıyor.### Project Overview
- Proje adı: Library (ASP.NET Core Web API)
- Amaç: Kütüphane ceza (fine) yönetimi için REST API uç noktaları sağlamak; cezaların listelenmesi, müşteri bazlı sorgular, ceza oluşturma, ödeme ve silme işlemleri.
- Hedef framework: ASP.NET Core Web API (kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari desen: Katmanlı mimari/N-Tier benzeri yapı. API katmanı (`Library`) uygulama katmanına (`Library.Application`) bağımlı; DTO ve servis sözleşmeleri Application katmanında tanımlı.
- Projeler/Asssembly’ler:
  - Library (API/Presentation): HTTP endpoint’leri ve controller’lar.
  - Library.Application (Application): `DTO` ve `IFineService` gibi servis kontratları.
- Kullanılan dış çerçeveler/paketler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon gereksinimleri: Bu dosyadan görünen spesifik appsettings anahtarı veya connection string yok.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/FinesController.cs`

**1. Genel Bakış**
`FinesController`, kütüphane cezalarına yönelik CRUD-benzeri ve işleme (ödeme/mağfiret) uç noktalarını sağlar. API/Presentation katmanında yer alır ve iş mantığını `IFineService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IFineService` — Ceza sorgulama, oluşturma, ödeme, silme ve özel sorgular için uygulama hizmeti.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public FinesController(IFineService fineService)` | `IFineService` bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<FineDto>>> GetAll()` | Tüm cezaları döner. 200 OK. |
| GetById | `public Task<ActionResult<FineDto>> GetById(Guid id)` | ID ile ceza getirir; yoksa 404. |
| GetByCustomer | `public Task<ActionResult<IEnumerable<FineDto>>> GetByCustomer(Guid customerId)` | Müşteri ID’sine göre cezaları listeler. |
| GetTotalUnpaid | `public Task<ActionResult<decimal>> GetTotalUnpaid(Guid customerId)` | Müşteri için ödenmemiş toplam tutarı döner. |
| GetPending | `public Task<ActionResult<IEnumerable<FineDto>>> GetPending()` | Bekleyen (ödenmemiş vb.) cezaları döner. |
| Create | `public Task<ActionResult<FineDto>> Create([FromBody] CreateFineDto createDto)` | Yeni ceza oluşturur; 201 Created ve `Location` başlığı döner. |
| PayFine | `public Task<ActionResult<FineDto>> PayFine(Guid id, [FromBody] PayFineDto payDto)` | Cezayı öder; 200 OK. 400/404 üretebilir. |
| WaiveFine | `public Task<IActionResult> WaiveFine(Guid id)` | Cezayı affeder; 204 NoContent. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Cezayı siler; 204 NoContent. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: `IFineService.GetByIdAsync` null dönerse 404 NotFound.
- `Create`: `CreatedAtAction` ile oluşturulan kaynağın konumunu `GetById` üzerinden bildirir.
- `PayFine`: 400/404 durumları için `ProducesResponseType` tanımlı; controller seviyesinde özel hata yakalama yok, durum kodu üretimi servis/exception politikasına bırakılmış görünüyor.
- Rotalar: `api/fines`, müşteri bazlı ve toplam sorgular için alt rotalar (`customer/{customerId}/...`).
- İçerik tipi: `application/json`.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, Postman vb.).
- **Aşağı akış:** `IFineService`.
- **İlişkili tipler:** `FineDto`, `CreateFineDto`, `PayFineDto`, `IFineService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: Endpoint’lerde `Authorize` niteliği veya yetkilendirme belirtisi yok; yetkisiz erişime açık olabilir.
- Hata yönetimi: 400/404 için annotation var ancak controller içinde validasyon/hata dönüştürme yer almıyor; global exception/validation politikası varsayılmış.

---
### Genel Değerlendirme
- API katmanı Application katmanına arayüzler ve DTO’lar üzerinden temiz bir bağımlılık kuruyor; katmanlaşma belirgin.
- Yetkilendirme ve merkezi hata/validasyon politikası bu dosyada görünmüyor; projede global middleware/filters ile ele alınıyorsa belgelendirilmesi faydalı olur.
- Konfigürasyon ve altyapı (veritabanı, EF Core vb.) katmanlarına ilişkin hiçbir ipucu bu dosyada yok; proje genel dokümantasyonu bunları tamamlamalı.### Project Overview
- Proje adı: Library (API katmanı görülüyor)
- Amaç: Kütüphane şubelerine yönelik CRUD ve sorgulama uç noktaları sağlamak (şubeleri listeleme, tekil getirme, aktif şubeler, oluşturma, güncelleme, silme).
- Hedef framework: ASP.NET Core Web API (net sürümü bu dosyadan anlaşılmıyor).
- Mimari desen: Katmanlı (N‑Tier/Clean benzeri)
  - Presentation/API: ASP.NET Core Controller’ları; HTTP isteklerini alır ve Application servislerine yönlendirir.
  - Application: `ILibraryBranchService` ve DTO’lar; iş akışı ve veri aktarım sözleşmeleri.
  - Diğer katmanlar (Domain/Infrastructure) bu dosyadan doğrudan görülmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library: API/presentation katmanı.
  - Library.Application: Application servis ve DTO sözleşmeleri.
- Kullanılan dış paket/çerçeveler:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Controllers)
  ↓ uses
Library.Application (DTOs, Interfaces)

---

### `Library/Controllers/LibraryBranchesController.cs`

**1. Genel Bakış**
`LibraryBranchesController`, kütüphane şubeleri için RESTful uç noktaları sağlar: tümünü listeleme, tekil getirme, aktifleri getirme, oluşturma, güncelleme ve silme. Presentation/API katmanında yer alır ve istekleri `ILibraryBranchService` üzerinden Application katmanına yönlendirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ILibraryBranchService` — Şube verileri için iş mantığı ve veri erişimini soyutlayarak CRUD/sorgulama operasyonlarını yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public LibraryBranchesController(ILibraryBranchService branchService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetAll()` | Tüm şubeleri döner. |
| GetById | `public Task<ActionResult<LibraryBranchDto>> GetById(Guid id)` | ID ile şubeyi döner; yoksa 404. |
| GetActive | `public Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetActive()` | Aktif şubeleri döner. |
| Create | `public Task<ActionResult<LibraryBranchDto>> Create([FromBody] CreateLibraryBranchDto createDto)` | Yeni şube oluşturur; 201 ve Location header ile döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateLibraryBranchDto updateDto)` | Mevcut şubeyi günceller; 204 döner. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Şubeyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` ile 404 üretir.
- `Create`: `CreatedAtAction(nameof(GetById), new { id = branch.Id }, branch)` ile 201 ve konum başlığı döner.
- `Update`/`Delete`: Başarılıysa 204 No Content döner. 404 yanıtı, servisin uygun exception/sonuç üretmesine bağlıdır.
- Rotalar: `api/[controller]` tabanında; `GET /api/LibraryBranches`, `GET /api/LibraryBranches/{id}`, `GET /api/LibraryBranches/active`, `POST`, `PUT {id}`, `DELETE {id}`.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API çağrıcıları); DI üzerinden çözülür.
- **Aşağı akış:** `ILibraryBranchService`
- **İlişkili tipler:** `LibraryBranchDto`, `CreateLibraryBranchDto`, `UpdateLibraryBranchDto`, `ILibraryBranchService`

**7. Eksikler ve Gözlemler**
- Doğrulama ve hata yönetimi: `Update` ve `Delete` için 404 üretilmesi tamamen servis davranışına bırakılmış; controller seviyesinde spesifik exception eşlemesi görülmüyor.
- Güvenlik: Herhangi bir `[Authorize]` niteliği veya rol bazlı erişim kısıtlaması yok; potansiyel erişim kontrolü eksikliği.

---

Genel Değerlendirme
- Katman ayrımı net: API doğrudan Application arayüzlerine konuşuyor ve DTO’lar kullanılıyor.
- Hata yönetimi ve doğrulama stratejisi bu dosyada görünmüyor; özellikle `Update`/`Delete` için servis istisnalarının HTTP kodlarına eşlenmesi net değil.
- Yetkilendirme eksik; kurumsal senaryolarda endpoint bazlı `[Authorize]` ve politikalar eklenmeli.
- Konfigürasyon ve altyapı detayları (veritabanı, EF Core, logging, validation pipeline) bu kesitte görünmediğinden tam mimari resmi çıkarmak için diğer katman dosyaları incelenmeli.### Project Overview
- Ad: Library — Bildirim yönetimi uç noktaları sunan bir ASP.NET Core Web API sunum katmanı.
- Amaç: Müşteriye ait bildirimleri listeleme, okunmamışları getirme/sayma, bildirim oluşturma, okundu işaretleme ve silme işlemlerini HTTP üzerinden sağlamak.
- Hedef Framework: ASP.NET Core Web API (kesin .NET sürümü bu dosyadan anlaşılmıyor).
- Mimari: Katmanlı mimari (N-Tier benzeri)
  - Presentation/API: `Library` — HTTP endpoint’leri ve model bağlama.
  - Application: `Library.Application` — `DTO` ve `INotificationService` gibi uygulama sözleşmeleri ve iş mantığı.
- Proje/Assembly’ler:
  - Library (API/Presentation) — Controller’lar.
  - Library.Application (Application) — DTO’lar ve servis arayüzleri.
- Harici paketler/çatı:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon:
  - Bu dosyadan özel connection string veya app settings anahtarları anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/NotificationsController.cs`

**1. Genel Bakış**
`NotificationsController`, müşteri bazlı bildirim işlemleri için RESTful uç noktalar sağlar: listeleme, okunmamışları getirme/sayma, oluşturma, okundu işaretleme ve silme. Sunum (API) katmanında yer alır ve iş mantığını `INotificationService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `INotificationService` — Bildirimlerin sorgulanması, oluşturulması, okundu/silinmiş durumuna getirilmesi için uygulama katmanı servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByCustomer | `Task<ActionResult<IEnumerable<NotificationDto>>> GetByCustomer(Guid customerId)` | Belirli müşterinin tüm bildirimlerini döner. |
| GetUnread | `Task<ActionResult<IEnumerable<NotificationDto>>> GetUnread(Guid customerId)` | Müşterinin okunmamış bildirimlerini döner. |
| GetUnreadCount | `Task<ActionResult<int>> GetUnreadCount(Guid customerId)` | Müşterinin okunmamış bildirim sayısını döner. |
| Create | `Task<ActionResult<NotificationDto>> Create([FromBody] CreateNotificationDto createDto)` | Yeni bildirim oluşturur ve 201 döner. |
| MarkAsRead | `Task<IActionResult> MarkAsRead(Guid id)` | Bildirimi okundu işaretler, 204 döner. |
| MarkAllAsRead | `Task<IActionResult> MarkAllAsRead(Guid customerId)` | Müşterinin tüm bildirimlerini okundu işaretler, 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Bildirimi siler, 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm işlemler `INotificationService`’e delege edilir; controller tarafında ek validasyon veya dönüştürme yapılmaz.
- `Create` çağrısında `Created(string.Empty, notification)` ile Location başlığı boş bırakılır.
- `Guid` route kısıtları kullanılır (`{customerId:guid}`, `{id:guid}`).
- Başarı durumlarında 200/201/204 dönüşleri açıkça belirtilmiştir.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, entegrasyonlar); DI üzerinden çözümlenir.
- **Aşağı akış:** `INotificationService`
- **İlişkili tipler:** `NotificationDto`, `CreateNotificationDto`, `INotificationService`

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme/kimlik doğrulama niteliği yok (`[Authorize]` vb.) — güvenlik riski olabilir.
- Hata yönetimi ve durum kodu farklılaştırması servis istisnalarına göre yapılmıyor; ör. bulunamayan kaynak için 404 mantığı controller düzeyinde tanımlı değil.
- `Created` yanıtında Location başlığı boş; kaynak URI’si sağlanmıyor.

---
### Genel Değerlendirme
Kod düzeni temiz ve Application sözleşmelerine net şekilde bağlanıyor. Ancak API katmanında yetkilendirme, model doğrulama ve hata haritalama (ör. 400/404) eksik. `Created` yanıtında Location başlığının sağlanması ve olası hata durumlarının (geçersiz `Guid`, bulunamayan bildirim) uygun HTTP kodlarına dönüştürülmesi önerilir. Application katmanı dışında başka katmanlar (Domain/Infrastructure) bu girdiyle görünür değil.### Project Overview
Proje adı: Library. Amaç: Yayıncı (publisher) yönetimi için RESTful HTTP uç noktaları sağlayan bir ASP.NET Core Web API katmanı. Hedef çerçeve: ASP.NET Core (min. .NET 6/7, `Microsoft.AspNetCore.Mvc` kullanımıyla çıkarım).

Mimari: N‑Tier (Katmanlı). Katmanlar:
- Presentation/API: HTTP endpoint’leri, model binding, sonuç dönme.
- Application: `Library.Application.DTOs` ve `Library.Application.Interfaces` ile servis sözleşmeleri ve DTO’lar.

Keşfedilen projeler/assembly’ler:
- Library (API/Presentation): Controller’lar.
- Library.Application (Application): Servis arayüzleri ve DTO’lar (referans üzerinden görüldü).

Dış bağımlılıklar:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).

Konfigürasyon:
- Bu dosyadan anlaşılmıyor; bağlantı dizeleri veya app settings anahtarlarına dair doğrudan kullanım yok.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---

### `Library/Controllers/PublishersController.cs`

**1. Genel Bakış**
`PublishersController`, yayıncıları listeleme, tekil getirme, aktifleri filtreleme, oluşturma, güncelleme ve silme işlemleri için REST endpoint’leri sunar. Presentation/API katmanında yer alır ve tüm iş mantığını `IPublisherService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `IPublisherService` — Yayıncı CRUD ve sorgulama işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `PublishersController(IPublisherService publisherService)` | Servis bağımlılığını alır. |
| GetAll | `Task<ActionResult<IEnumerable<PublisherDto>>> GetAll()` | Tüm yayıncıları 200 ile döner. |
| GetById | `Task<ActionResult<PublisherDto>> GetById(Guid id)` | Bulunamazsa 404, aksi halde 200 döner. |
| GetActive | `Task<ActionResult<IEnumerable<PublisherDto>>> GetActive()` | Aktif yayıncıları 200 ile döner. |
| Create | `Task<ActionResult<PublisherDto>> Create([FromBody] CreatePublisherDto createDto)` | Oluşturur ve 201 + `Location` başlığı döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdatePublisherDto updateDto)` | Günceller ve 204 döner. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Siler ve 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretilir.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction(nameof(GetById), new { id = publisher.Id }, publisher)` ile kaynak konumu döner.
- `Update`/`Delete`: 404 üretimi için servis katmanının istisna fırlatmasına güvenildiği ima edilir; controller içinde özel hata yakalama yok.
- `GetActive`: Aktif filtreleme Application katmanına delege edilmiştir.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (API tüketicileri); DI üzerinden çözümlenir.
- Aşağı akış: `IPublisherService`, DTO’lar (`PublisherDto`, `CreatePublisherDto`, `UpdatePublisherDto`).
- İlişkili tipler: `Library.Application.DTOs.*`, `Library.Application.Interfaces.IPublisherService`.

**7. Eksikler ve Gözlemler**
- `Update` ve `Delete` için 404 cevap deklarasyonu var ancak controller seviyesinde hata yönetimi/exception mapping yok; servis istisnaları global exception middleware ile eşlenmiyorsa tutarsızlık olabilir.
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; güvenlik gereksinimleri olan ortamlarda eksiklik teşkil edebilir.

---

Genel Değerlendirme
- Katmanlı yapı net: API, Application’a bağımlı. Ancak sadece API controller görünür durumda; domain/infrastructure katmanları bu koddan belirlenemiyor.
- Hata yönetimi ve istisna eşleme için ya global middleware’e ya da action-level handling’e ihtiyaç olabilir; aksi takdirde deklaratif `ProducesResponseType(404)` ile gerçek davranış ayrışabilir.
- Güvenlik (authz/authn) öznitelikleri eksik; ihtiyaç varsa eklenmeli.
- Model validasyonu için `ApiController` özniteliği faydalı; ancak özel doğrulamalar Application katmanında teyit edilmelidir.### Project Overview (required, once)
- Proje adı: Library. Amaç: Kütüphane personel yönetimi için HTTP API uç noktaları sunmak. Hedef: ASP.NET Core Web API; spesifik .NET sürümü bu dosyadan anlaşılmıyor.
- Mimari desen: N‑Tier. Katmanlar:
  - Presentation/API: HTTP endpoint’leri ve request/response sözleşmeleri (`Library.Controllers`).
  - Application: İş kuralları ve servis sözleşmeleri (`Library.Application.Interfaces`, `Library.Application.DTOs`).
- Projeler/assembly’ler:
  - Library (API/Presentation): Controller’lar.
  - Library.Application (Application): DTO’lar ve servis arayüzleri.
- Kullanılan çerçeveler/paketler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram (required, once)
Library (API/Presentation) --> Library.Application (Application)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel (staff) ile ilgili CRUD ve listeleme işlemleri için HTTP endpoint’leri sağlar. Presentation/API katmanına aittir ve iş mantığını `IStaffService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel verileri üzerinde listeleme, oluşturma, güncelleme ve silme iş mantığını yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffController(IStaffService staffService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli listeler. |
| GetById | `public async Task<ActionResult<StaffDto>> GetById(Guid id)` | ID’ye göre personeli döner; yoksa 404. |
| GetActive | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döner. |
| Create | `public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; 201 ve Location header ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; 204 döner. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Personeli siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` (404) yanıtı verir.
- `Create`: `CreatedAtAction` ile 201 döner ve `Location` header’ında `GetById` endpoint’ine link oluşturur.
- `Update` ve `Delete`: Başarılı senaryoda 204 döner; 404 durumları için anotasyon var ancak kontrol doğrudan controller’da yapılmıyor (servisten fırlatılan exception’lara veya global middleware’e güveniliyor).
- Rota kısıtı: `id:guid` ile geçerli GUID zorunluluğu.
- Swagger/metadata: `ProducesResponseType` ile beklenen durum kodları ve dönüş tipleri belirtilmiş.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (ör. frontend, Postman) bu controller’ı çağırır; DI üzerinden çözümlenir.
- **Aşağı akış:** `IStaffService`.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: Herhangi bir `[Authorize]` niteliği yok; tüm endpoint’ler herkese açık olabilir.
- Hata yönetimi tutarlılığı: `Update`/`Delete` için 404 anotasyonu var ancak controller içinde açık kontrol yok; global exception handling’e bağımlılık olabilir. 409 için `Create`’ta anotasyon var ancak explicit dönüş yok.

---
Genel Değerlendirme
- Mimaride API katmanı Application katmanına doğru tek yönlü bağımlılık gösteriyor; sorumluluk ayrımı net.
- Controller, iş kurallarını doğru şekilde servise delege ediyor; ancak yetkilendirme ve hata yönetimi için açık strateji görünmüyor.
- DTO ve servis sözleşmeleri Application katmanında; Infrastructure veya Persistence katmanlarına dair iz bu dosyada yok.### Project Overview
- Proje Adı: Library
- Amaç: ASP.NET Core uygulaması için merkezi istisna yakalama ve tutarlı JSON hata yanıtı üretimi.
- Hedef Framework: ASP.NET Core (kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari Desen: Clean Architecture eğilimli katmanlama.
  - Presentation/API: `Library` (middleware ile HTTP istek/yanıt akışı).
  - Application: `Library.Application` (özel istisnalar ve `ApiResponse<T>` gibi ortak modeller).
- Keşfedilen Proje/Assembly’ler:
  - `Library` — API/Presentation katmanı, middleware içeriyor.
  - `Library.Application` — Uygulama katmanı, ortak modeller ve istisnalar.
- Kullanılan Dış Çerçeveler/Paketler:
  - ASP.NET Core (`RequestDelegate`, `HttpContext`, `ILogger`), `System.Text.Json`.
- Konfigürasyon Gereksinimleri:
  - Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Common.Models, Common.Exceptions)

---
### `Library/Middleware/GlobalExceptionHandlerMiddleware.cs`

**1. Genel Bakış**
HTTP pipeline’da global istisna yakalama yapar ve standart bir `ApiResponse<object>` ile JSON hata yanıtı döner. Presentation/API katmanına aittir ve uygulama katmanındaki özel istisnaları HTTP durum kodlarına map’ler.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Middleware`

**3. Bağımlılıklar**
- `RequestDelegate _next` — Middleware zincirinde bir sonraki bileşene delege.
- `ILogger<GlobalExceptionHandlerMiddleware>` — Hata/uyarı loglama.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)` | Middleware’ı zincire eklemek için bağımlılıkları alır. |
| InvokeAsync | `Task InvokeAsync(HttpContext context)` | İsteği işler; istisnaları yakalayıp uygun HTTP yanıtına dönüştürür. |

**5. Temel Davranışlar ve İş Kuralları**
- `NotFoundException` → 404, `BadRequestException` → 400 (hata listesi dahil), `ConflictException` → 409, `UnauthorizedAccessException` → 401, diğer tüm istisnalar → 500.
- 500 durumunda `LogError`, diğer eşleşen istisnalarda `LogWarning` yapılır.
- Yanıt `application/json` içerik tipinde, `System.Text.Json` ile camelCase property isimlendirmesi kullanılarak serileştirilir.
- 500 için güvenli genel mesaj (“An unexpected error occurred.”) döner; diğerlerinde istisna mesajı kullanılır.
- `ApiResponse<object>.FailResponse(...)` ile standart hata gövdesi oluşturulur.

**6. Bağlantılar**
- **Yukarı akış:** ASP.NET Core middleware pipeline (DI üzerinden çözümlenir).
- **Aşağı akış:** `Library.Application.Common.Exceptions` (`NotFoundException`, `BadRequestException`, `ConflictException`), `Library.Application.Common.Models.ApiResponse<T>`, `ILogger`, `System.Text.Json`.
- **İlişkili tipler:** `ApiResponse<object>`, özel istisna türleri.

**7. Eksikler ve Gözlemler**
- Üretim ortamında ayrıntılı mesaj sızıntısını önlemek için 400/404/409’da da daha genel mesajlar tercih edilebilir; mevcut hali istisna mesajlarını dışarı açar.
- RFC 7807 `ProblemDetails` yerine özel `ApiResponse` kullanılıyor; standardizasyon gerekirse `ProblemDetails` entegrasyonu değerlendirilebilir.

### Genel Değerlendirme
Kod, API katmanında Clean Architecture’a uygun şekilde uygulama istisnalarını HTTP yanıtlarına map’leyen net bir middleware sunuyor. Katmanlar arası bağımlılık yönü doğru: Presentation, Application’ın ortak tiplerini kullanıyor. Dış bağımlılıklar minimal ve çerçeveye uygun. Konfigürasyon, depolama veya ek paketlere dair bilgi bu örnekten çıkmıyor. Log seviyesi ayrımı yerinde; yanıt formatı tutarlı. Potansiyel geliştirme alanı, hata yanıt standardizasyonu ve mesaj içeriğinin ortam-temelli kontrolüdür.### Project Overview
- Proje adı: Library (namespace’tan çıkarım). Amaç: ASP.NET Core istek hattına takılabilen bir middleware ile HTTP istek/yanıt yaşam döngüsünü korelasyon kimliğiyle loglamak.
- Hedef framework: ASP.NET Core (.NET 6+ varsayımı; koddan net sürüm anlaşılmıyor).
- Mimari desen: Katmanlı/N-Tier içinde Sunum (API) katmanına takılan çapraz-kesim (cross-cutting) bir kütüphane bileşeni. Middleware, HTTP pipeline’da yer alır.
- Projeler/assembly’ler:
  - Library: Middleware ve altyapı yardımcıları sağlayan sınıf kitaplığı.
- Kullanılan dış paket/çerçeveler:
  - ASP.NET Core (`HttpContext`, `RequestDelegate`, `ILogger<T>`)
  - BCL (`System.Diagnostics.Stopwatch`)
- Konfigürasyon gereksinimleri:
  - `X-Correlation-ID` HTTP header’ı opsiyonel olarak okunur ve yanıt header’ına yazılır. Ek appsettings anahtarı veya connection string gereksinimi bu dosyadan anlaşılmıyor.

### Architecture Diagram
Sunum (ASP.NET Core Web Host/API) --> Library (Middleware)

---

### `Library/Middleware/RequestLoggingMiddleware.cs`

**1. Genel Bakış**
`RequestLoggingMiddleware`, gelen HTTP isteklerinin başlangıç ve tamamlanma anlarını, durum kodunu ve geçen süreyi bilgi seviyesinde (`Information`) loglar. Ayrıca korelasyon takibi için `X-Correlation-ID` header’ını okur/üretir ve hem `HttpContext.Items` hem de yanıt header’ına yazar. ASP.NET Core sunum katmanına takılan çapraz-kesim bir bileşendir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Middleware`

**3. Bağımlılıklar**
- `RequestDelegate` — Bir sonraki middleware’i çağırmak için pipeline devam temsilcisi
- `ILogger<RequestLoggingMiddleware>` — Başlangıç/bitiş ve süre loglaması için logger

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)` | Middleware’i bir sonraki adım ve logger ile başlatır. |
| InvokeAsync | `Task InvokeAsync(HttpContext context)` | Korelasyon kimliğini yönetir; isteğin başlangıcını ve tamamlanmasını süre ve durum kodu ile loglar. |

**5. Temel Davranışlar ve İş Kuralları**
- Korelasyon kimliği: `X-Correlation-ID` istekte varsa kullanılır, yoksa `Guid.NewGuid().ToString()` ile üretilir.
- Korelasyon kimliği `HttpContext.Items["CorrelationId"]` içine ve yanıt header’ı `X-Correlation-ID` olarak yazılır.
- Süre ölçümü `Stopwatch` ile ms cinsinden yapılır; başlangıç ve tamamlanma logları `Information` seviyesindedir.
- Log formatı: Metot, yol, (tamamlanmada) durum kodu ve geçen süre ile korelasyon kimliği.
- Exception durumlarında tamamlanma logu otomatik atılmaz; bu dosyada özel hata yakalama/ölçüm yok.

**6. Bağlantılar**
- Yukarı akış: ASP.NET Core middleware pipeline; DI üzerinden çözümlenir ve `UseMiddleware<RequestLoggingMiddleware>()` ile zincire eklenir (bu dosyadan ekleme yeri görülmüyor).
- Aşağı akış: `RequestDelegate`, `ILogger<RequestLoggingMiddleware>`.
- İlişkili tipler: `HttpContext`, `RequestDelegate`, `ILogger<T>`, `Stopwatch`.

**7. Eksikler ve Gözlemler**
- Exception’lar fırlatıldığında tamamlanma logu atlanabilir; hatalar için ayrı bir exception handling/logging middleware’i gerekebilir veya burada `try/finally` ile süre ve korelasyon loglaması garanti altına alınabilir.
- `Items["CorrelationId"]` anahtarı sabit/const olarak merkezi tanımlanmadığından tip güvenliği ve yazım hatalarına açık olabilir.

---

Genel Değerlendirme
- Kod net ve hedefe odaklı; korelasyon kimliği ve performans izlenebilirliği için faydalı.
- Üretim ortamlarında tutarlı log yapısı için structured logging alan adları ve sabit anahtarların merkezi tanımı önerilir.
- İstisna senaryolarında ölçüm ve korelasyonun kaybolmaması için `try/finally` kalıbı veya global exception middleware’i ile entegrasyon düşünülmeli.### Proje Genel Bakış
- Ad: Library Management API. Amaç: kurumsal kütüphane yönetimi için HTTP tabanlı API sunmak; denetleyiciler, sağlık kontrolleri, Swagger dokümantasyonu ve middleware tabanlı hataloglama/sunum sağlamak.
- Hedef framework: .NET 6+ (Minimal hosting, top-level statements kullanımı).
- Mimari desen: Clean Architecture benzeri katmanlı yapı.
  - API/Presentation: `Library` (ASP.NET Core Web API host, middleware ve endpoint haritalama).
  - Application: `Library.Application` (iş kuralları, CQRS/servisler — bu dosyadan detayları görülmüyor).
  - Infrastructure: `Library.Infrastructure` (harici kaynaklar, konfigurasyon tabanlı servisler — bu dosyadan detayları görülmüyor).
  - Middleware: `Library.Middleware` (özel istek loglama ve global hata yakalama).
- Projeler/Assembly’ler:
  - Library (API Host)
  - Library.Application (Uygulama katmanı)
  - Library.Infrastructure (Altyapı katmanı)
  - Library.Middleware (Özel middleware’ler; ayrı proje veya API içinde namespace olarak konumlanmış olabilir)
- Harici paket/çerçeveler:
  - ASP.NET Core (Controllers, CORS, HealthChecks, Response Caching)
  - Swashbuckle/Swagger (`Microsoft.OpenApi.Models`)
  - System.Text.Json
- Konfigürasyon gereksinimleri:
  - `AddInfrastructure(builder.Configuration)` üzerinden konfigürasyon kullanılır; spesifik anahtarlar/connection string’ler bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library (API/Presentation)
  -> Library.Application
    -> Library.Infrastructure
Library (API) -> Library.Middleware (RequestLoggingMiddleware, GlobalExceptionHandlerMiddleware)

---

### `Library/Program.cs`

**1. Genel Bakış**
Uygulamanın giriş noktasıdır; servis kayıtlarını ve HTTP pipeline’ını yapılandırır. API/Presentation katmanına aittir ve Application/Infrastructure katmanlarını DI ile sisteme ekler, CORS, Swagger, Health Checks ve Response Caching gibi yatay yetenekleri etkinleştirir.

**2. Tip Bilgisi**
- Tip: Program (top-level statements)
- Miras: Yok
- Uygular: Yok
- Namespace: Global (proje kökü; kodda özel namespace tanımı yok)

**3. Bağımlılıklar**
- `AddApplication()` — Uygulama katmanı servislerini DI’a ekler.
- `AddInfrastructure(IConfiguration)` — Altyapı katmanı servislerini konfigürasyonla DI’a ekler.
- `RequestLoggingMiddleware` — İstek loglama.
- `GlobalExceptionHandlerMiddleware` — Global hata işleme.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Yok | — | Giriş noktası top-level statements; public/protected üye tanımı yok. |

**5. Temel Davranışlar ve İş Kuralları**
- JSON serileştirme: `JsonStringEnumConverter`, `JsonIgnoreCondition.WhenWritingNull`.
- CORS politikası: `AllowAll` — tüm origin/metod/header serbest.
- Swagger: yalnızca Development ortamında UI ve endpoint etkin.
- Health Checks: `/health` endpoint’i haritalanır.
- Response Caching: etkinleştirilir ve middleware zincirine eklenir.
- HTTPS yönlendirme: etkin.
- Yetkilendirme middleware’i (`UseAuthorization`) ekli; kimlik doğrulama bu dosyadan anlaşılmıyor.
- Middleware sırası: İstek Loglama → Global Exception → Swagger (dev) → HTTPS → CORS → Response Caching → Authorization → Controllers.

**6. Bağlantılar**
- Yukarı akış: ASP.NET Core host tarafından çalıştırılır (`app.Run()`).
- Aşağı akış: `Library.Application`, `Library.Infrastructure`, `RequestLoggingMiddleware`, `GlobalExceptionHandlerMiddleware`, ASP.NET Core altyapı servisleri (Controllers, CORS, Swagger, HealthChecks, ResponseCaching).
- İlişkili tipler: `AddApplication`, `AddInfrastructure` uzantıları; `RequestLoggingMiddleware`, `GlobalExceptionHandlerMiddleware`.

**7. Eksikler ve Gözlemler**
- CORS `AllowAnyOrigin` üretim ortamları için güvenlik riski yaratabilir; kısıtlı origin’lerle sınırlandırılması önerilir.
- `UseAuthentication` çağrısı yok; yetkilendirme kullanılıyorsa kimlik doğrulama middleware’inin eklenmesi gerekebilir.
- `AddInfrastructure` konfigürasyonu kullanıyor; gerekli ayar anahtarları ve doğrulama bu dosyadan görülemiyor.

---

Genel Değerlendirme
- Katmanlı yapı net: API Application ve Infrastructure’a bağımlı. Middleware’ler merkezi loglama ve hata yönetimini sağlar.
- Güvenlik konuları gözden geçirilmeli: CORS’un gevşek yapılandırması ve muhtemel kimlik doğrulama eksikliği.
- Operasyonel özellikler iyi bütünleştirilmiş: Health Checks, Swagger (sadece dev), Response Caching ve JSON ayarları.