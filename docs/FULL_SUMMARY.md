### Project Overview
- Proje adı: Library (isim, namespace’lerden çıkarım)
- Amaç: Uygulama katmanında kitap kategorilerine ilişkin veri transferini sağlamak için DTO tanımı sunmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı mimari (en azından Application katmanı mevcut). Application katmanı, domain/iş modellerini dış dünyaya veya diğer katmanlara aktarırken kullanılacak DTO’ları barındırır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama mantığına ait tipler.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisi verilerini taşımak için kullanılan basit bir DTO’dur. Uygulama katmanına aittir ve üst katmanlarla (ör. API) veya diğer servislerle veri alışverişinde kullanılır.

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
| Name | `public string Name { get; set; }` | Kategori adı; varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklaması; varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`. `Id` için default `Guid.Empty` olabilir; bu dosyada oluşturma mantığı tanımlı değil.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir veya controller/service katmanlarınca kullanılır (bu dosyadan spesifik çağırıcılar anlaşılamıyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemel domain entity’si `BookCategory` veya benzeri (bu dosyadan kesin değil).

Genel Değerlendirme
- Şu an yalnızca Application katmanında bir DTO görülüyor; domain, infrastructure, API katmanlarına dair kanıt yok.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları bu koddan çıkarılamıyor.
- Validasyon anotasyonları (`[Required]`, uzunluk sınırları vb.) bulunmuyor; ihtiyaç varsa üst katmanlarda veya ayrı validasyon katmanında ele alınmalı.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kitap bilgilerini uygulama katmanında taşımak için DTO tanımları sağlamak. Hedef çatı: Bu dosyadan anlaşılmıyor; yalnızca Application katmanı görülüyor. Mimari desen: Katmanlı/Clean Architecture eğilimli bir yapı işareti mevcut (namespace `Library.Application.DTOs`), fakat diğer katmanlar bu girdiyle doğrulanamıyor. Keşfedilen proje/assembly: Library.Application — Uygulama katmanı için DTO’lar. Harici paket/çatı: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
└─ (başka katman/bağımlılık görünmüyor)

---
### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitap verilerini uygulama sınırları arasında taşımak için kullanılan bir veri aktarım nesnesidir. Uygulama (Application) katmanına aittir ve sunum/servis katmanları ile domain/infrastructure arasında şekilsiz veri taşımayı kolaylaştırır.

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
| Id | `Guid Id { get; set; }` | Kitabın benzersiz tanımlayıcısı. |
| Title | `string Title { get; set; }` | Kitap adı. |
| Author | `string Author { get; set; }` | Yazar adı. |
| ISBN | `string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `bool IsAvailable { get; set; }` | Mevcut/ödünç verilebilirlik durumu. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | İlgili kategori kimliği (opsiyonel). |
| BookCategoryName | `string? BookCategoryName { get; set; }` | İlgili kategori adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`; `PublishedYear = 0`, `IsAvailable = false` (C# varsayılanı), `BookCategoryId = null`, `BookCategoryName = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (kategori alanları olası bir kategori varlığı/DTO’suna işaret eder).

Genel Değerlendirme
- Yalnızca Application katmanında bir DTO dosyası görülebiliyor; diğer katmanlar (Domain, Infrastructure, API) bu girdide yer almıyor.
- Mimari üzerinde kesin yargı için servisler, handler’lar, entity’ler veya persistence katmanı gibi ek dosyalar gereklidir.
- Konfigürasyon, paket bağımlılıkları ve hedef çatı hakkında çıkarım yapacak yeterli gösterge yok.### Project Overview
- Proje adı: Library (adlandırmadan çıkarım)
- Amaç: Kitap kategorisi oluşturma akışında kullanılacak veri transfer nesnelerini tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean Architecture tarzı bir düzeni ima ediyor; `Application` katmanı, use case/DTO tanımlarını içerir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO, muhtemel komut/sorgu ve iş akışı tanımları.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, yeni bir kitap kategorisi oluşturmak için istemci tarafından gönderilen veriyi temsil eden basit bir DTO’dur. Uygulama (Application) katmanına aittir ve istek modelini domain/entity’den izole etmeyi amaçlar.

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
| Description | `public string Description { get; set; }` | Kategoriye ilişkin açıklamayı taşır. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülüyor; diğer katmanlar (Domain, Infrastructure, API) bu bağlamda gözlemlenemiyor.
- Validasyon, eşleme (mapping) veya iş kuralları bu DTO içinde tanımlı değil; muhtemelen handler/service katmanında ele alınacaktır. Bu yaklaşım DTO’ları sade tutma prensibiyle uyumludur.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Uygulama katmanında kitap oluşturma işlemleri için giriş verilerini taşımak (DTO).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli yapı (Application katmanı mevcut). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case/handler sözleşmeleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, bir kitabın oluşturulması için gerekli alanları taşıyan basit bir veri aktarım nesnesidir. Uygulama katmanına aittir ve giriş verilerini üst katmanlardan (ör. API) domain/use-case mantığına taşımayı amaçlar.

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
| Title | `public string Title { get; set; }` | Kitabın başlığı (varsayılan: `string.Empty`). |
| Author | `public string Author { get; set; }` | Yazar adı (varsayılan: `string.Empty`). |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarası (varsayılan: `string.Empty`). |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
- Sadece Application katmanından bir DTO görülebiliyor; diğer katmanlar ve akışlar bu dosyadan belirlenemiyor.
- Doğrulama kuralları (zorunlu alanlar, format kontrolü, yıl aralığı vb.) bu DTO içinde tanımlı değil; muhtemelen üst/alt katmanlarda ele alınmalı.### Project Overview
Bu depo, `Library.Application` adında bir uygulama katmanı projesi içeriyor ve müşteri oluşturma senaryosu için bir DTO tanımlıyor. Koddan hedef framework açıkça anlaşılamıyor. Ama isimlendirme ve namespace yapısı, katmanlı/temiz mimari yaklaşımına uygun bir Application katmanının varlığına işaret ediyor. Bu katman, muhtemelen API veya UI’dan gelen istekleri işleyen komut/sorgu işleyicilerine veri taşıma görevini üstlenir.

- Mimari desen: Katmanlı/Clean Architecture eğilimi (yalnızca Application katmanı görülebiliyor).
- Keşfedilen projeler/assembly’ler:
  - `Library.Application`: Uygulama altyapısı; DTO’lar, muhtemel komut/sorgu işleyicileri ve arayüzler barındırır.
- Dış paketler/çerçeveler: Bu dosyadan anlaşılamıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, yeni bir müşteri oluşturma isteğinde kullanılan veri taşıma nesnesidir. Uygulama (Application) katmanına aittir ve üst katmanlardan gelen giriş verilerini domain/işlemlerine iletmek için kullanılır.

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
| Address | `public string Address { get; set; }` | Müşterinin adresi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Giriş doğrulaması için `DataAnnotations` (`[Required]`, `[EmailAddress]`, vb.) veya ayrı bir validasyon mekanizması belirtilmemiş; create senaryosunda doğrulama eksik olabilir.

---

Genel Değerlendirme
- Yalnızca Application katmanından bir DTO dosyası sunulmuş; mimari ve bağımlılık detayları bu kapsamda sınırlı görünüyor.
- DTO’da doğrulama/kontrat güvencesi yok; veri bütünlüğü için ek validasyon (ör. FluentValidation veya DataAnnotations) önerilir.
- Hedef framework, dış bağımlılıklar ve diğer katmanlar (Domain, Infrastructure, API) görünmediğinden genel mimari akış ve konfigürasyon gereksinimleri doğrulanamıyor.### Project Overview
- Proje adı: Library (namespace’ten çıkarım). Amaç: Application katmanında veri aktarım nesneleri (DTO) sağlamak. Hedef çerçeve bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (en azından Application katmanı mevcut). Diğer katmanlar (Domain/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO tanımları içeriyor.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)

---

### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, bir personel oluşturma işlemi için gerekli alanları taşıyan veri aktarım nesnesidir. Uygulama katmanına aittir ve dış katmanlardan (örn. API) gelen girdi verilerini uygulama mantığına taşımak için kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Personelin adı. Varsayılanı `string.Empty`. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. Varsayılanı `string.Empty`. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. Varsayılanı `string.Empty`. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. Varsayılanı `string.Empty`. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. Varsayılanı `string.Empty`. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe alınma tarihi. Varsayılanı `default(DateTime)`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName`, `LastName`, `Email`, `Phone`, `Position` = `string.Empty`; `HireDate` = `default(DateTime)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Zorunlu alanlar ve formatlar için herhangi bir validasyon (ör. `[Required]`, e-posta formatı) tanımlı değil.

---

### Genel Değerlendirme
Kod tabanı, en azından Application katmanındaki DTO tanımlarıyla katmanlı bir yapıya işaret ediyor. Sadece bir DTO görülebildiği için mimari bağımlılıklar, hedef çerçeve, kullanılan paketler ve konfigürasyon hakkında ek çıkarım yapılamıyor. Girdi validasyonu şu an DTO seviyesinde görünmüyor; doğrulama ihtiyaçları varsa veri anotasyonları veya FluentValidation gibi bir yaklaşım eklenmesi değerlendirilebilir.### Project Overview
- Proje adı: Library
- Amaç: Uygulama katmanında müşteri verilerini taşımak için DTO tanımları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı (N-Tier) — Bu dosyadan yalnızca Application katmanı (DTO) görünüyor; diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama mantığı.
- Kullanılan harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri bilgilerini uygulama katmanında taşımak için kullanılan basit bir veri transfer nesnesidir. Genellikle Application → Presentation/Infrastructure sınırlarında veri alışverişini temsil eder ve Application katmanına aittir.

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
| Id | `public Guid Id { get; set; }` | Müşterinin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşteri e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşteri telefon numarası. |
| Address | `public string Address { get; set; }` | Müşteri adresi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Üyeliğin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `RegisteredDate = default(DateTime)`, `IsActive = default(bool)`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülebiliyor; diğer katmanlar (Domain, Infrastructure, API) ve akış bu dosyadan çıkarılamıyor.
- Validasyon, mapping profilleri ve kullanım bağlamı (ör. CQRS komut/sorgu modelleri) görünmüyor; muhtemelen başka dosyalarda tanımlı veya eksik.### Project Overview
Proje adı: Library (çıkarım). Amaç: Uygulama katmanında kullanılan veri taşıma nesnelerini (DTO) tanımlamak. Hedef çatı: Bu dosyadan net değil; yalnızca C# 10+ özelliklerine uygun modern .NET kullanımı izleniyor.
Mimari: Katmanlı/Clean Architecture eğilimli yapı (çıkarım), çünkü `Library.Application` ad alanı içinde `DTOs` yer alıyor. Ancak diğer katmanlar bu dosyadan görülemiyor.
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; istek/yanıt modelleri ve muhtemelen servis sözleşmeleri (bu dosyada yalnızca DTO var).
Dış bağımlılıklar: Bu dosyadan görünmüyor.
Yapılandırma gereksinimleri: Bu dosyada konfigürasyon anahtarları veya bağlantı stringleri bulunmuyor.

### Architecture Diagram
Library.Application (DTOs)

---
### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, personel bilgisini uygulama katmanında taşıyan bir veri nesnesidir. Sunum, uygulama servisleri veya dış katmanlar arasında personel verisini taşımak için kullanılır. Mimari olarak Application katmanına aittir.

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
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`. `HireDate`, `Id`, `IsActive` için default .NET tür varsayılanları uygulanır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir veya controller/handler katmanları tarafından kullanılır (bu dosyadan net değil).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemelen bir `Staff` domain entity’siyle eşleşir (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görünüyor; diğer katmanlar (Domain, Infrastructure, API) bu girdiyle doğrulanamıyor.
- Validasyon, eşleme (mapping) veya sözleşme anotasyonları (ör. data annotations) yok; bu, validasyonun başka bir katmanda yapıldığını veya henüz eklenmediğini düşündürür.
- Hedef framework ve paket bağımlılıkları çıkarılamıyor; projedeki diğer dosyalar bu bilgiyi netleştirebilir.### Project Overview (required, once)
Proje adı, namespace’lerden çıkarımla “Library” olarak görünmektedir. Amaç, bir kütüphane alanına yönelik uygulamada kitap kategorileri gibi kavramlar için uygulama katmanı DTO’larını sağlamak olabilir. Hedef çatı .NET sürümü bu dosyadan anlaşılamıyor. Mimari olarak en azından `Library.Application` katmanı mevcut; bu da katmanlı/Clean Architecture benzeri bir yapılanmaya işaret eder (Application katmanı: use case’ler, DTO’lar, validasyon).

Keşfedilen proje/assembly:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case/handler’ları barındırır.

Dış paket/kütüphane kullanımları bu dosyadan anlaşılamıyor. Konfigürasyon gereksinimleri (connection string, appsettings anahtarları vb.) bu dosyadan anlaşılamıyor.

### Architecture Diagram (required, once)
Metin bağımlılık diyagramı (çıkarıma dayalı, bu dosyadan görülenlerle sınırlı):

Library.Application (DTO’lar)
  ↑ Tüketenler: API/Presentation, Application Use-Case’leri (bu dosyadan doğrudan doğrulanmıyor)

---

### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisi güncelleme işlemi için istemciden/üst katmandan alınan verileri taşıyan bir DTO’dur. Uygulama (Application) katmanına aittir ve komut/handler veya controller’lar ile domain/infrastructure arasındaki veri sözleşmesini sadeleştirir.

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
| Name | `public string Name { get; set; }` | Kategori adını temsil eder. |
| Description | `public string Description { get; set; }` | Kategori açıklamasını temsil eder. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** API/controller veya Application katmanı komutları tarafından kullanılır (bu dosyadan doğrudan doğrulanmıyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemel `BookCategory` entity’si veya `UpdateBookCategory` komutu/handler’ı (bu dosyadan anlaşılamıyor).

Genel Değerlendirme
- Mevcut kod sadece bir DTO içeriyor; doğrulama attributeleri veya kurallar (ör. boş geçilemezlik) tanımlı değil. Validasyonun nerede yapıldığı bu dosyadan anlaşılamıyor.
- Mimarinin geri kalanı (Domain, Infrastructure, API) görünmediği için katmanlar arası bağımlılık yönleri ve paket kullanımları belirlenemiyor.### Project Overview
- Proje adı: Library (koddan çıkarılan namespace’lere göre)
- Amaç: Kütüphane alanına ilişkin uygulama katmanında veri transferini sağlamak; özellikle kitap güncelleme işlemleri için DTO sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; görülen katman Application (DTO’lar). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve muhtemel use-case’lere hizmet eden sözleşmeler.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor (harici paket kullanımı görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
`UpdateBookDto`, bir kitabın güncellenmesi için gerekli alanları taşıyan veri transfer nesnesidir. Uygulama katmanında, komut/sorgu işleyicileri veya controller’lar ile domain/infrastructure arasındaki veri geçişini sadeleştirir.

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
| Title | `public string Title { get; set; }` | Kitap başlığı; varsayılan `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adı; varsayılan `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | ISBN değeri; varsayılan `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı; varsayılan `0`. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Kitabın müsaitlik durumu; bool varsayılanı `false`. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği; boş olabilir. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `IsAvailable = false`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (muhtemelen controller/handler’lar).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel `Book` entity’si veya komut/handler tipleri).

**7. Eksikler ve Gözlemler**
- Giriş validasyonu (ör. `Title`, `Author`, `ISBN` zorunluluğu, `PublishedYear` aralık kontrolü) DTO seviyesinde yok; bu beklenebilir ancak servis/handler tarafında doğrulanması gerekir.
- `null`/boş string ayrımı ve `ISBN` format kontrolüne dair herhangi bir sözleşme/öznitelik bulunmuyor.

---

Genel Değerlendirme
- Kod tabanı sadece Application katmanındaki bir DTO’yu gösteriyor; diğer katmanlar (Domain, Infrastructure, API) görünmüyor.
- Tip güvenliği ve amaç net; ancak validasyon stratejisi belirsiz. FluentValidation veya data annotation izleri yok.
- Varsayılan boş string kullanımının, güncelleme senaryolarında istenmeyen “değerin sıfırlanması” etkisine yol açmaması için handler tarafında dikkatli bir eşleme/patch mantığı önerilir.### Project Overview
Proje adı, Library.Application ad alanından anlaşıldığı üzere bir “Library” (kütüphane) alanına ait uygulamanın Application katmanını ifade ediyor. Amaç, uygulama katmanında kullanılan DTO’lar ve olası komut/sorgu modellerini barındırmak. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen tam olarak belirgin değil; dosya yolu ve ad alanı, katmanlı mimari (N-Tier veya Clean Architecture benzeri) kullanıldığına işaret ediyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve olası uygulama mantığı için sözleşmeler/taşıyıcılar.

Harici paketler/çatı framework’ler: Bu dosyadan görülmüyor.  
Konfigürasyon gereksinimleri: Bu dosyadan görülmüyor.

### Architecture Diagram
[Library.Application] (Application)

---

### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, müşteri güncelleme senaryosunda kullanılan veri taşıyıcı nesnedir. Application katmanında yer alır ve istemciden gelen güncelleme verilerini üst katmanlardan domain/infrastructure’a iletmek amacıyla kullanılır.

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
| Address | `public string Address { get; set; }` | Müşterinin adresi. |
| IsActive | `public bool IsActive { get; set; }` | Müşteri durum bilgisi (aktif/pasif). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `IsActive = false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Sadece Application katmanından bir DTO görülebiliyor; diğer katmanlar (Domain, Infrastructure, API/Presentation) bu girdiyle doğrulanamıyor.
- Doğrulama (ör. `Email` formatı, zorunlu alanlar) bu DTO içinde yok; muhtemelen üst katmanlarda veya FluentValidation benzeri bir mekanizma ile ele alınmalıdır, ancak bu dosyadan anlaşılmıyor.
- Hedef çerçeve, bağımlılıklar ve konfigürasyon hakkında çıkarım yapılamıyor.### Project Overview
- Proje adı: Library (namespace kökünden çıkarım)
- Amaç: Kütüphane alanına yönelik uygulama katmanında veri aktarımını (DTO) sağlamak; özellikle personel güncelleme işlemleri için istek/girdi modelini temsil etmek.
- Hedef framework: Bu dosyadan tespit edilemiyor.
- Mimari desen: Katmanlı/Clean benzeri yapı ima ediliyor; yalnızca Application katmanı gözlemleniyor (DTO’lar).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO tanımları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan tespit edilemiyor.
- Konfigürasyon gereksinimleri: Bu dosyadan tespit edilemiyor.

### Architecture Diagram
Library.Application (DTOs)
^
| (üst katmanlar muhtemel: API/Presentation ve/veya Application Services)
Bu dosyadan başka katman bağımlılığı tespit edilemiyor.

---
### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel (staff) bilgilerinin güncellenmesine yönelik girdi/veri aktarım nesnesidir. Application katmanında yer alır ve API veya uygulama servislerine gelen update isteklerinin modelini taşımak için kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Personelin adı; varsayılanı `string.Empty`. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı; varsayılanı `string.Empty`. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi; varsayılanı `string.Empty`. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası; varsayılanı `string.Empty`. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı; varsayılanı `string.Empty`. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive` için varsayılan `false` (C# bool default).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (muhtemelen API endpoint’leri veya Application servisleri).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
- Sadece Application katmanında bir DTO dosyası görülebiliyor; diğer katmanlar ve akışlar bu veriden çıkarılamıyor.
- Modelde validasyon nitelikleri/kuralları (ör. `Required`, format kontrolleri) tanımlı değil; validasyonun nerede yapıldığı bu dosyadan anlaşılmıyor.### Project Overview
- Proje adı: Library.Application (uygulama katmanı). Amaç: Kütüphane alanına yönelik uygulama servislerinin IoC/DI kayıtlarını merkezileştirmek ve tüketicilere tek uzantı noktası sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Application katmanı). Application katmanı domain odaklı servis arabirimlerini ve implementasyonlarını DI üzerinden sunar.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama servislerinin bulunduğu ve DI kayıtlarını yapan katman.
- Kullanılan dış paketler/çerçeveler:
  - Microsoft.Extensions.DependencyInjection — DI kayıtları için.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  (Application Layer)

---

### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` sınıfı, Application katmanındaki servislerin DI konteynerine kayıt edilmesi için `IServiceCollection` üzerinde bir genişletme metodu sağlar. Mimari içinde Application katmanına aittir ve tüketici projelerin (örn. API veya Worker) tek çağrıyla Application bağımlılıklarını eklemesini kolaylaştırır.

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
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Application katmanındaki servisleri Scoped yaşam döngüsü ile DI konteynerine ekler ve `IServiceCollection` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `IBookService` → `BookService`, `IBookCategoryService` → `BookCategoryService`, `IStaffService` → `StaffService`, `ICustomerService` → `CustomerService` Scoped olarak kaydedilir.
- Kayıtlar idempotent kabul edilir; aynı metot birden çok kez çağrılsa da DI, son kayıtları korur.
- Yalnızca interface-implementation eşlemesi yapar; ek konfigürasyon veya middleware/behavior eklemez.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/Composition Root içinde `services.AddApplication()` çağrılır.
- **Aşağı akış:** Yok (sadece DI kayıtlarını yapar).
- **İlişkili tipler:** `IBookService`/`BookService`, `IBookCategoryService`/`BookCategoryService`, `IStaffService`/`StaffService`, `ICustomerService`/`CustomerService` (bu dosyada tanımlı değil).

**7. Eksikler ve Gözlemler**
- Sadece dört servis kayıtlı; başka servisler varsa bu uzantıya eklenmemiş olabilir.
- Yaşam döngüsü tercihlerinin (Scoped) gerekçesi bu dosyadan anlaşılmıyor; bazı servisler Singleton/Transient gerektirebilir.

---

Genel Değerlendirme
- Kod, Application katmanında tek sorumluluğa odaklanan bir DI kompozisyon noktası sunuyor ve tüketimi basitleştiriyor.
- Diğer katmanlar (Domain, Infrastructure, API) ve ek yapı taşları bu depoda/örnekte görünür değil; hedef framework ve ek konfigürasyon anahtarları belirlenemiyor.
- Servis kayıtlarının kapsamı artırıldıkça, yapının korunması için modüler AddXxx metotlarına bölme veya `Scrutor` benzeri paketlerle assembly tarama yaklaşımı değerlendirilebilir.### Project Overview
- Proje adı: Library (gözlenen derleme: `Library.Application`)
- Amaç: Uygulama katmanında kitap kategori işlemlerine yönelik servis sözleşmelerini tanımlamak; DTO tabanlı CRUD akışlarını düzenlemek.
- Hedef çatı (target framework): Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı (N‑Tier) — bu dosya `Application` katmanını temsil ediyor ve domain kurallarını taşıyan servis sözleşmelerini, DTO’larla birlikte dışa açıyor. Veri erişimi ve sunum katmanları bu dosyadan anlaşılmıyor.
- Projeler/Assemblies:
  - `Library.Application`: Uygulama sözleşmeleri ve DTO’lar.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)
  ↑ consumed by other layers (ör. API/Infrastructure) — bu dosyadan kesin bağımlılık yönleri anlaşılmıyor

---
### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorilerine yönelik CRUD operasyonları için uygulama katmanı servis sözleşmesini tanımlar. Amaç, kategori verilerini DTO’lar üzerinden almak/üretmek ve üst katmanlara bağımlılığı azaltmaktır. Mimari olarak Application katmanında yer alır.

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
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Verilen `id` için kategori DTO’sunu döner; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori DTO’larını döner. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni bir kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Belirtilen `id`’li kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`’li kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor (DTO içerikleri burada tanımlı değil).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/Command-Handler katmanları çağırır (bu dosyadan kesin çağırıcılar anlaşılmıyor).
- **Aşağı akış:** `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `BookCategoryDto` (hepsi `Library.Application.DTOs` içinde).
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` desteği yok; uzun süren işlemler ve iptal senaryoları için eksik olabilir.
- `GetAllAsync` için sayfalama/sıralama imkânı yok; büyük veri setlerinde performans ve aktarım maliyeti doğurabilir.
- `UpdateAsync` ve `DeleteAsync` dönüş değerleri yok; bulunamayan kayıt veya değişiklik sonucu bilgisini iletmek için sonuç türü/geri bildirim eksik olabilir.

### Genel Değerlendirme
Kod tabanında yalnızca `Application` katmanına ait bir servis arayüzü görülüyor. Sözleşmeler net ve minimal; ancak iptal belirteci, hata/sonuç modellemesi (ör. Result/OneOf), ve koleksiyon sonuçları için sayfalama gibi uygulama çapında standartların belirlenmesi faydalı olabilir. Diğer katmanlar (Domain, Infrastructure, API) bu girdiyle gözlemlenemediğinden katmanlar arası bağımlılık yönleri ve validasyon stratejileri hakkında çıkarım yapılamıyor.### Proje Genel Bakış
- Ad: Library (çıkarım: `Library.Application` ad alanı)
- Amaç: Kitap varlıkları için uygulama katmanında servis sözleşmeleri tanımlamak (CRUD ve erişim operasyonları).
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean odaklı bir yapı işaretleri mevcut (Application katmanı). Application katmanı, domain mantığını işleyen servis sözleşmelerini tanımlar; implementasyon ve kalıcılaştırma detayları başka katmanlarda olur.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve servis arayüzleri.
- Dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (Interfaces, DTOs)
  ↑ tüketir
[Diğer katmanlar — bu dosyadan kesin değil, tipik olarak: API/Presentation ve Infrastructure uygulamaları]

---
### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara yönelik temel CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Uygulama (Application) katmanına aittir ve implementasyonlarının başka bir katmanda (genelde Infrastructure) sağlanması beklenir.

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
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Verilen `id` ile kitabı getirir; bulunamazsa `null` döner. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/müsait kitapları döner. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitabı oluşturur ve oluşturulan kaydı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Belirtilen kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış içermez; iş kuralları implementasyonlara bırakılmıştır. Dönüş tipleri async pattern izler; `GetByIdAsync` için bulunamama durumunda `null` sözleşmesi vardır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak API/Handlers tarafından çağrılır (bu dosyadan kesin değil).
- Aşağı akış: `BookDto`, `CreateBookDto`, `UpdateBookDto` (DTO bağımlılıkları).
- İlişkili tipler: `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- Async metotlarda `CancellationToken` parametresi bulunmuyor; uzun süren işlemler için iptal desteği eklenmesi faydalı olabilir.

### Genel Değerlendirme
Kod, Application katmanında net bir servis sözleşmesi ortaya koyuyor ve DTO tabanlı sınırları belirgin. Ancak yalnızca bir arayüz görülebildiğinden mimarinin tamamı çıkarılamıyor. Genişletilebilirlik ve sağlamlık için iptal belirteçleri ve hata senaryoları için sözleşme düzeyinde daha açık sonuç modelleri (ör. sonuç/sonuç-kodları) düşünülebilir.### Project Overview
- Proje adı: Library
- Amaç: Uygulamanın müşteri yönetimi akışlarını (okuma/listeleme/oluşturma/güncelleme/silme) Application katmanında tanımlamak.
- Hedef çerçeve: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; bu dosya Application katmanında sözleşmeleri (service interface) tanımlar.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama sözleşmeleri ve DTO’lar (bu dosyadan görülebildiği kadarıyla).
- Dış bağımlılıklar: Görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)

---

### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri verilerine ilişkin temel CRUD ve sorgulama işlemleri için uygulama katmanı sözleşmesini tanımlar. Presentation/Infrastructure katmanları bu arayüzü implement ederek veya tüketerek müşteri yönetimini gerçekleştirir.

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
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` ile müşteri bilgisini döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri döndürür. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Sadece aktif müşterileri döndürür. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Belirtilen müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok; arayüz iş kurallarını belirtmez.
- `GetByIdAsync` için bulunamama durumunda `null` dönebilir; diğer metotların hata/sonuç sözleşmesi bu dosyadan anlaşılmıyor.
- `GetActiveCustomersAsync` aktiflik kriteri uygulanacağını ima eder; kriterin nasıl belirlendiği bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar Presentation (API/Controllers) veya Application içi diğer hizmetler.
- **Aşağı akış:** Harici bağımlılık yok (sözleşme).
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto` (hepsi `Library.Application.DTOs` içinde).

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametresi yok; uzun süren işlemler için iptal desteği eklenebilir.
- Listeleme operasyonlarında sayfalama/filtreleme sözleşmesi yok; `GetAllAsync` potansiyel olarak büyük veri setleri için riskli olabilir.
- `UpdateAsync` ve `DeleteAsync` işlemlerinde sonuç/başarı bilgisi (ör. bulunamadı, etkilenen kayıt sayısı) geri dönmüyor; çağıran taraf için belirsizlik yaratabilir.

---

Genel Değerlendirme
- Kod parçası, Application katmanında müşteri yönetimi için net bir sözleşme sağlar ancak hedef framework, veri erişimi veya altyapı detayları görünmüyor.
- İptal belirteci, sayfalama ve daha ayrıntılı sonuç tipleri (ör. Result/Outcome desenleri) eklenmesi sözleşmeyi güçlendirebilir.
- Clean Architecture yaklaşımıyla uyumlu; ancak diğer katmanlar (Domain, Infrastructure, API) bu dosyadan doğrulanamıyor.### Project Overview
Proje adı: Library (namespace’ten çıkarım). Amaç: kütüphane personeliyle ilgili uygulama işlemlerini uygulama katmanında soyutlamak; `IStaffService` ile CRUD ve listeleme sözleşmelerini tanımlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor.

Mimari: Katmanlı/Clean Architecture benzeri bir yapı izleniyor gibi görünüyor; bu dosya Application katmanında hizmet sözleşmesi ve DTO referansları içeriyor. Domain, Infrastructure veya API katmanları bu depoda görünmüyor.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı. Servis arayüzleri (`Interfaces`) ve DTO referansları (`Library.Application.DTOs`) barındırır.

Dış bağımlılıklar: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)

---

### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (`Staff`) ile ilgili uygulama işlemlerinin sözleşmesini tanımlar: tekil/sorgulama, aktif personel listeleme, oluşturma, güncelleme ve silme. Application katmanına aittir ve üst katmanlar (ör. API) tarafından çağrılması, alt katmanlarda (ör. Infrastructure) uygulanması amaçlanır.

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
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Verilen `id` ile personeli getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını listeler. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif personel kayıtlarını listeler. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşturulan `StaffDto`yu döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut personel kaydını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’deki personel kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok. Anlam çıkarımı: Aktif personel için bir filtreleme beklentisi vardır (`GetActiveStaffAsync`). `CreateAsync` sonrası oluşturulan kaydın geri döndürülmesi beklenir. Hata ve validasyon sözleşmesi bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar API/Presentation katmanı servisleri veya handler’lar.
- **Aşağı akış:** Uygulama detayları bu dosyadan görünmüyor.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Tüm async imzalarda `CancellationToken` eksik; uzun süren I/O işlemlerinde iptal desteği sağlanamaz.
- Listeleme operasyonlarında sayfalama/sıralama parametreleri bulunmuyor; büyük veri kümelerinde performans/bant genişliği etkilenebilir.

---

Genel Değerlendirme
- Görünen kod, Application katmanında net bir servis sözleşmesi sunuyor ancak mimarinin geri kalanı (Domain/Infrastructure/API) bu depoda görünmüyor.
- Async API’lerde `CancellationToken` desteği eklenmesi önerilir.
- Listeleme uçları için sayfalama/sıralama/filtreleme parametreleri düşünülmeli.
- Hata yönetimi, validasyon ve yetkilendirme sözleşmeleri (ör. özel exception tipleri, sonuç tipleri) arayüzde tanımlı değil; proje genelinde tutarlı bir yaklaşım belirlenmesi faydalı olur.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Kitap kategorileri için Application katmanında DTO-Entity dönüşümleri sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Application → Domain). Application katmanı, Domain entity’lerini DTO’lara map’ler ve tersini yapar.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve mapping uzantıları.
  - Library.Domain — Domain katmanı; entity tanımları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` entity’si ile ilgili DTO’lar (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`) arasında çift yönlü map işlemlerini sağlayan uzantı metodlarını içerir. Application katmanı içinde yer alır ve Domain entity’leri ile Application DTO’ları arasında veri aktarımını düzenler.

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
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` entity’sini `BookCategoryDto`’ya map eder. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`’dan yeni bir `BookCategory` entity’si oluşturur ve `Id` için `Guid.NewGuid()` atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Var olan `BookCategory` entity’sinin `Name` ve `Description` alanlarını DTO’dan gelen değerlerle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` çağrısında `Id` otomatik olarak `Guid.NewGuid()` ile üretilir.
- `UpdateEntity` yalın alan güncellemesi yapar; kısmi güncellemeler veya null kontrolü içermez.
- Hiçbir metotta null kontrolü veya validasyon yok; `category` veya `dto` null ise `NullReferenceException` oluşabilir.
- Map işlemleri birebir alan eşlemesi şeklindedir; dönüşüm/normalizasyon (ör. trim, case) yapılmaz.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.BookCategory`, `Library.Application.DTOs.BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`
- **İlişkili tipler:** İlgili DTO’lar ve `BookCategory` entity’si.

**7. Eksikler ve Gözlemler**
- Null ve input validasyonu eksik; özellikle `UpdateEntity` ve `ToDto` çağrılarında NRE riski var.
- `UpdateEntity` kısmi güncellemeyi desteklemez; null değerlerin mevcut alanları yanlışlıkla ezmesi olasıdır. 

---

Genel Değerlendirme
- Kod, Application ve Domain katmanları arasında net bir bağımlılık yönü sergiliyor (Application → Domain).
- Mapping uzantıları temiz ve amaç odaklı; ancak null/validasyon kontrolleri yokluğu ileride NRE ve veri bütünlüğü sorunlarına yol açabilir.
- Mimari ve konfigürasyonla ilgili daha geniş resim bu tek dosyadan çıkarılamıyor; ek dosyalarda servis/handler ve konfigürasyon detaylarına bakılması faydalı olacaktır.### Project Overview
- Proje adı: Library (koddan çıkarılan adlandırma)
- Amaç: Kütüphane alanındaki `Book` varlığını Application katmanındaki DTO’larla eşleyerek veri aktarımını kolaylaştırmak; yaratma, okuma ve güncelleme senaryolarında mapleme sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture eğilimli (katmanlar arası bağımlılık yönü Application → Domain). Application katmanı DTO/Mapping gibi kullanıma dönük tipleri içerir; Domain katmanı kurumsal varlıkları içerir.
- Projeler/Assembly’ler:
  - Library.Application — DTO’lar ve mapleme mantığı
  - Library.Domain — Domain entity’leri (ör. `Book`)
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain ← Library.Application

---

### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` domain varlığı ile Application katmanındaki DTO’lar (`BookDto`, `CreateBookDto`, `UpdateBookDto`) arasında iki yönlü mapleme sağlar. Clean Architecture’da Application katmanına aittir ve entity <-> DTO dönüştürme sorumluluğunu üstlenir.

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
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` entity’sini `BookDto`’ya dönüştürür; kategori adı varsa `BookCategoryName` doldurulur. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto`’dan yeni bir `Book` entity’si üretir; `Id` için `Guid.NewGuid()` oluşturur ve `IsAvailable`’ı `true` yapar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan `Book` entity’sini `UpdateBookDto` alanlarına göre günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `BookCategory?.Name` ile null güvenli kategori adı aktarımı.
- `ToEntity`: Yeni `Id` otomatik üretilir (`Guid.NewGuid()`); `IsAvailable` varsayılan olarak `true` atanır.
- `UpdateEntity`: Tüm temel alanlar (`Title`, `Author`, `ISBN`, `PublishedYear`, `IsAvailable`, `BookCategoryId`) DTO’dan entity’ye kopyalanır.
- Null argümanlar veya alan validasyonları bu dosyada yapılmıyor; doğrulama bu katmanın dışında olabilir (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** Çağırıcılar bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.
- **İlişkili tipler:** `Book`, `BookDto`, `CreateBookDto`, `UpdateBookDto`, `BookCategory` (adı `BookCategoryName` için kullanılır).

**7. Eksikler ve Gözlemler**
- Metotlarda null kontrolü yok; `book` veya `dto` null ise `NullReferenceException` oluşabilir. Özellikle extension metotlar için çağrı öncesi validasyon gerekebilir.

---

### Genel Değerlendirme
- Application katmanında mapleme mantığı net ve basit; DTO ↔ Entity dönüşümleri açık.
- Varsayılan `IsAvailable = true` ve `Guid.NewGuid()` ile ID üretimi iş kuralı olarak belirgin; bu kuralların belge veya testlerle pekiştirilmesi faydalı olur.
- Null güvenliği ve temel input validasyonları görünür değil; çağıran katmanlarda garanti altına alınmalı veya bu metotlar savunmacı programlama ile güçlendirilmeli.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane müşterilerine ait verileri temsil eden entity ve DTO’lar arasında dönüşüm sağlamak (Application katmanında mapping).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture’ya yakın ayrım. Domain (entity’ler) ve Application (DTO ve mapping) katmanları belirgin. Sunum/API ve Infrastructure katmanları bu dosyadan görülmüyor.
- Projeler/Assembly’ler:
  - Library.Domain — Çekirdek entity’ler (`Customer`)
  - Library.Application — Uygulama katmanı, DTO’lar ve mapping uzantıları
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor (görünür harici bağımlılık yok).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API (görünmüyor)
  ↓
Library.Application
  ↓
Library.Domain

---
### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` entity’si ile ilgili DTO’lar (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`) arasında dönüşüm sağlayan statik uzantı sınıfıdır. Application katmanında yer alır ve entity-DTO ayrımını koruyarak veri aktarımını basitleştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. DTO ve entity türlerine derleme zamanı bağımlılığı vardır:
- `Library.Application.DTOs` — DTO tipleri
- `Library.Domain.Entities` — `Customer` entity’si

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` entity’sini `CustomerDto`ya dönüştürür. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`’dan yeni `Customer` entity’si oluşturur; bazı alanları otomatik üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` entity’sini `UpdateCustomerDto` değerleriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde:
  - `Id = Guid.NewGuid()` otomatik atanır.
  - `MembershipNumber = Guid.NewGuid().ToString("N")[..10].ToUpper()` ile 10 karakterlik, büyük harfli bir üyelik numarası üretilir.
  - `RegisteredDate = DateTime.UtcNow` atanır.
  - `IsActive = true` varsayılan aktiflik.
- `UpdateEntity` mutasyon yapar; `FirstName`, `LastName`, `Email`, `Phone`, `Address`, `IsActive` alanlarını günceller.
- Validasyon, null kontrolü veya benzersizlik kontrolü yapılmaz; bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Application servisleri/handler’ları tarafından çağrılır; DI üzerinden çözümlenmez (statik uzantılar).
- **Aşağı akış:** `Customer` entity’si ve `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` tiplerine bağımlıdır.
- **İlişkili tipler:** `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- `MembershipNumber` üretiminde benzersizlik garantisi yok; çakışma riski varsa ek kontrol gerekebilir.
- Girdi validasyonu ve null kontrolleri yok; üst katmanlarda ele alınmıyorsa hatalara yol açabilir. 

### Genel Değerlendirme
Kod, Application ve Domain katmanları arasında temiz bir mapping sınırı sunuyor. Validasyon, hata yönetimi ve benzersizlik kontrolleri bu katmanda yapılmıyor; bunlar ayrı katmanlarda ele alınmalı. Hedef framework, konfigürasyon ve olası API/Infrastructure katmanları bu dosyadan çıkarılamıyor. Mapping kuralları açık ve tutarlı, otomatik alan üretimi net şekilde izole edilmiş.### Project Overview
- Proje adı: Library
- Amaç: `Domain` katmanındaki `Staff` varlığını Application katmanındaki DTO’lara dönüştürmek ve tersine eşlemeleri sağlamak (oluşturma ve güncelleme senaryoları).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture türevi; `Application` katmanı `Domain` katmanını referans alır ve mapping mantığını içerir.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Application — Uygulama katmanı, DTO’lar ve mapping uzantıları.
  - Library.Domain — Alan (domain) varlıkları.
- Kullanılan harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application -> Library.Domain

---
### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` varlığı ile `StaffDto`/`CreateStaffDto`/`UpdateStaffDto` arasında dönüşüm yapan extension method’lar sağlar. Uygulama katmanında mapping sorumluluğunu merkezileştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`) için.
- `Library.Domain.Entities` — Domain varlığı `Staff` için.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` varlığını `StaffDto`'ya dönüştürür. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto` bilgisinden yeni bir `Staff` varlığı oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Mevcut `Staff` varlığını `UpdateStaffDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde `Id` otomatik `Guid.NewGuid()` ile üretilir.
- `ToEntity` yeni personel için `IsActive = true` default set edilir.
- `ToDto` alanları birebir kopyalar; iş kuralı içermez.
- `UpdateEntity` güncellenebilir alanları (`FirstName`, `LastName`, `Email`, `Phone`, `Position`, `IsActive`) set eder; `HireDate` ve `Id` korunur.

**Mantık içermeyen basit DTO/model'ler için**
> DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Staff` (Domain), `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (Application DTO’ları).
- **İlişkili tipler:** `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- `UpdateEntity` `HireDate` gibi tarih alanını güncellemiyor; bu bilinçli olabilir ancak gereksinime göre eksik sayılabilir.
- Null/format validasyonu yapılmıyor; geçersiz veri mapping sırasında yakalanmaz.

---
Genel Değerlendirme
- Kod, Application -> Domain bağımlılığına uygun ilerliyor; mapping’ler extension method olarak sade ve odaklı.
- Validasyon ve hata yönetimi mapping’lerde yok; bu sorumluluk muhtemelen başka katmanlarda olmalı. 
- Hedef framework, konfigürasyon ve harici bağımlılıklar bu dosyadan çıkarsanamıyor.### Project Overview
- Proje adı: Library
- Amaç: Kitap kategorileriyle ilgili uygulama hizmetlerini sunmak; domain katmanındaki repository arayüzleri üzerinden CRUD işlemleri yapıp DTO’lara maplemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture esintili. Application katmanı, Domain arayüzlerine bağımlı; mapping ile DTO-Entity dönüşümü sağlanıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama hizmetleri, DTO ve mapping kullanımı
  - Library.Domain — Repository arayüzleri (örn. `IBookCategoryRepository`)
- Kullanılan harici paket/çatı: Bu dosyadan anlaşılmıyor (EF Core/MediatR vb. görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD operasyonlarını sağlayan uygulama servisi olup Application katmanında konumlanır. Domain katmanındaki `IBookCategoryRepository` üzerinden veri erişimini soyutlayarak DTO-Entity dönüşümlerini mapping uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookCategoryService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kitap kategorileri için veri erişim işlemlerini gerçekleştirir.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | ID ile kategoriyi getirir ve DTO’ya mapler; yoksa null döner. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri getirip DTO listesine mapler. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Oluşturma DTO’sunu entity’ye çevirip ekler, oluşan kategoriyi DTO olarak döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | ID ile kategoriyi bulur, yoksa `KeyNotFoundException` fırlatır; entity’yi DTO’dan günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | ID’ye göre kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync` mevcut olmayan ID’de `KeyNotFoundException` fırlatır.
- Mapping uzantıları kullanılır: `ToDto`, `ToEntity`, `UpdateEntity` (detaylar bu dosyadan anlaşılmıyor).
- `CreateAsync` ekleme sonrası DTO döndürür; ID üretimi ve persist davranışı repository’ye bırakılmıştır.
- `DeleteAsync` için varlık varlık kontrolü/geri bildirim bu dosyadan anlaşılmıyor (repository implementasyonuna bağlı).

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir (muhtemelen API Controller veya Application katmanı tüketicileri).
- Aşağı akış: `IBookCategoryRepository`, mapping extension’ları (`Library.Application.Mappings`).
- İlişkili tipler: `IBookCategoryService`, `IBookCategoryRepository`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto` (ilgili entity bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- `DeleteAsync` içinde varlık yoksa ne olacağı belirsiz; repository sessizce yok sayıyorsa tüketiciye geri bildirim eksik olabilir.
- Giriş doğrulama (ör. `createDto`, `updateDto` null/alan validasyonları) servis düzeyinde görünmüyor; muhtemelen üst katmanda veya FluentValidation-benzeri bir yerde bekleniyor, ancak bu dosyadan anlaşılmıyor.

---
Genel Değerlendirme
- Mimari bağımlılık yönü tutarlı: Application → Domain (aracılığıyla repository arayüzleri).
- DTO ve mapping kullanımı servis ile domain modelini ayrıştırıyor; mapping implementasyonları görülmediği için dönüşümlerin doğruluğu teyit edilemiyor.
- Hata yönetimi kısmen mevcut (`UpdateAsync` için not-found); silme ve oluşturma senaryolarında geri bildirim stratejisi belirsiz.
- Katmanlar arası ayrım net; ancak hedef framework, altyapı (EF Core vb.) ve konfigürasyon detayları bu dosyadan belirlenemiyor.### Project Overview
- Proje adı: Library (Namespace’lerden çıkarım)
- Amaç: Kitap yönetimi için uygulama katmanında servis mantığı; DTO–Entity mapping ve repository üzerinden veri erişimi koordinasyonu.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture benzeri katmanlama.
  - Domain: `Library.Domain.Interfaces` altında repository kontratları.
  - Application: `Library.Application` altında DTO’lar, mapping extension’ları ve servisler (iş akışı).
- Projeler/Assembly’ler:
  - Library.Application — Uygulama servisleri, DTO’lar, mapping.
  - Library.Domain — Domain arayüzleri (repository).
- Dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Services, DTOs, Mappings)
  ↓ depends on
Library.Domain (Interfaces: Repositories)

---
### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik CRUD ve sorgulama operasyonlarını sağlayan uygulama katmanı servisidir. Domain’deki `IBookRepository` üzerinden veri erişimini orkestre eder ve DTO–Entity dönüşümlerini `Mappings` ile yapar. Clean Architecture’ın Application katmanında konumlanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap varlıkları için veri erişim operasyonlarını sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookService(IBookRepository bookRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<BookDto?> GetByIdAsync(Guid id)` | ID’ye göre kitabı getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `public Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları listeler ve DTO’ya dönüştürür. |
| GetAvailableBooksAsync | `public Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait kitapları listeler ve DTO’ya dönüştürür. |
| CreateAsync | `public Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur, kaydeder ve DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller; bulunamazsa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kitabı ID’ye göre siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync` içinde kitap bulunamazsa `KeyNotFoundException` fırlatılır.
- DTO–Entity dönüşümleri `createBookDto.ToEntity()`, `book.ToDto()`, `updateBookDto.UpdateEntity(book)` extension metodlarıyla yapılır.
- `CreateAsync` akışında repository `AddAsync` sonrası dönen entity DTO’ya çevrilip iade edilir.
- Filtreli listeleme `GetAvailableBooksAsync` ile repository seviyesinde yapılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API katmanındaki controller’lar veya başka application servisleri çağırır (bu dosyadan kesin değil).
- **Aşağı akış:** `IBookRepository`
- **İlişkili tipler:** `IBookService`, `BookDto`, `CreateBookDto`, `UpdateBookDto`, `Library.Application.Mappings` extension metodları, `IBookRepository`

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için girdi validasyonu görünmüyor; null/boş alan kontrolleri application seviyesinde eksik olabilir.
- `DeleteAsync` başarısız/olmayan ID senaryosu için özel bir geri bildirim yok; repository implementasyonuna bağımlı.

---
Genel Değerlendirme
- Katmanlar arası bağımlılık yönü doğru: Application, Domain arayüzlerine bağımlı.
- DTO ve mapping kullanımı net; ancak validasyon ve hata yönetimi stratejisi görünmüyor.
- Transaction yönetimi, logging ve yetkilendirme işaretleri yok; bunlar proje genelinde eklenmesi gereken çapraz kesen kaygılar olabilir.
- Hedef framework ve dış bağımlılıklar bu dosyadan belirlenemiyor; çözüm seviyesi dosyalarla tamamlanmalı.### Project Overview
- Proje adı: Library (ad alanlarından çıkarım). Amaç: Müşteri yönetimi için uygulama katmanında servis mantığı; DTO–Entity dönüşümleri ve repository aracılığıyla veri erişimi. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Application ↔ Domain). Application katmanı DTO/mapping ve servisleri barındırır; Domain katmanı repository sözleşmelerini içerir.
- Proje/Assembly’ler:
  - Library.Application: Uygulama servisi, DTO’lar, mapping uzantıları, service arayüzleri.
  - Library.Domain: Repository arayüzleri (ör. `ICustomerRepository`).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor (EF Core, MediatR vb. görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
Library.Application.Services.CustomerService
  ↓ uses
Library.Domain.Interfaces.ICustomerRepository

---

### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri varlıkları için uygulama düzeyinde CRUD ve sorgu işlemlerini koordine eder. DTO–Entity dönüşümlerini `Mappings` üzerinden yapar ve veriye `ICustomerRepository` aracılığıyla erişir. Application katmanına aittir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `Library.Application.Interfaces.ICustomerService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri verilerine erişim için domain repository sözleşmesi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için müşteriyi DTO olarak döner; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri DTO listesi olarak döner. |
| GetActiveCustomersAsync | `public Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri DTO listesi olarak döner. |
| CreateAsync | `public Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller; müşteri yoksa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Belirtilen `id`’deki müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `CreateCustomerDto.ToEntity()`, `UpdateCustomerDto.UpdateEntity(...)`, `Entity.ToDto()` uzantılarıyla dönüşüm yapar.
- `UpdateAsync` müşteriyi bulamazsa `KeyNotFoundException` fırlatır.
- `GetAllAsync` ve `GetActiveCustomersAsync` sonuçları `Select(c => c.ToDto())` ile DTO’ya projekte edilir.
- `CreateAsync` oluşturma sonrası oluşan entity anında DTO’ya çevrilip döndürülür.
- `DeleteAsync` varlık varlık kontrolü yapmaz; repository’nin davranışına güvenir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir (muhtemelen API/controller veya başka application servisleri çağırır).
- Aşağı akış: `ICustomerRepository`
- İlişkili tipler: `ICustomerService`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`), `ICustomerRepository`.

**7. Eksikler ve Gözlemler**
- `DeleteAsync`’te varlık yoksa davranış tanımlı değil; `UpdateAsync`’teki bulunamadı istisnasıyla tutarsızlık olabilir. Silmede de benzer kontrol/geri bildirim beklenebilir.
- Giriş DTO’ları için null/iş kuralı validasyonu servis seviyesinde görünmüyor; validasyonun nerede yapıldığı bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanında Application ve Domain katmanları net ayrılmış; servis katmanı repository ve mapping uzantılarını kullanarak DTO tabanlı akışı sağlıyor. Exception yönetimi kısmen tutarlı (güncellemede varlık bulunamazsa hata) ancak silme operasyonunda geri bildirim belirsiz. Dış bağımlılıklar ve altyapı detayları (ORM, transaction, context) bu dosyadan görünmüyor; projede standartlaştırılmış hata/validasyon stratejisi ve silme/güncelleme için tutarlı bulunamayan-kaynak davranışlarının belgelenmesi önerilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım). Amaç: Kütüphane personeline yönelik uygulama işlemlerini Application katmanında servisler ve DTO/mapping’ler aracılığıyla yürütmek; veri erişimi Domain katmanındaki repository arayüzleriyle soyutlamak. Hedef framework bu dosyadan anlaşılmıyor.
- Mimari desen: N‑Katmanlı/Clean benzeri. Domain katmanı repository arayüzlerini barındırır; Application katmanı DTO’lar, mapping uzantıları ve servisler ile iş akışını koordine eder ve Domain’e bağımlıdır.
- Projeler/Assembly’ler:
  - Library.Domain — Repository arayüzleri ve domain kontratları.
  - Library.Application — Servisler (`StaffService`), DTO’lar, mapping uzantıları.
- Kullanılan dış paketler/çerçeveler: Görünmüyor (bu dosyadan anlaşılmıyor). Mapping işlemleri `Library.Application.Mappings` içindeki extension’larla yapılmış.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarı görünmüyor).

### Architecture Diagram
Library.Application --> Library.Domain

---

### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel (staff) ile ilgili uygulama seviyesindeki işlemleri koordine eden Application katmanı servisidir. Domain katmanındaki `IStaffRepository` üzerinden veri erişimini gerçekleştirir ve `DTO`/entity dönüşümlerini `Mappings` uzantılarıyla yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel varlıkları için veri erişim işlemlerini sağlar (getir, ekle, güncelle, sil).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını enjekte eder. |
| GetByIdAsync | `public Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir ve DTO’ya map eder. |
| GetAllAsync | `public Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel listesini getirir ve DTO koleksiyonuna map eder. |
| GetActiveStaffAsync | `public Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personel listesini getirir ve DTO’lara map eder. |
| CreateAsync | `public Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | DTO’dan entity oluşturur, ekler ve oluşan kaydı DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Kimliğe göre personeli bulur, DTO değerleriyle günceller. Bulunamazsa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Entity/DTO dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır.
- `UpdateAsync` içinde kayıt bulunamazsa `KeyNotFoundException` fırlatılır.
- `CreateAsync` ekleme sonrası dönen DTO, repository’nin oluşturduğu değerleri (ör. Id) yansıtmayı amaçlar; detaylar repository/Entity’den anlaşılır.
- `DeleteAsync` için id’nin varlığı doğrulanmaz; repository davranışına bağlıdır.
- Servis içinde ek validasyon veya transaction yönetimi görünmüyor; sorumluluk repository veya üst katmanlarda olabilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/controllers veya uygulama komut/işleyicileri çağırır (bu dosyadan net değil).
- **Aşağı akış:** `IStaffRepository`
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `Library.Application.Mappings` uzantıları, `IStaffService`, `IStaffRepository`

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için giriş DTO validasyonları servis seviyesinde yok; null/boş alanlar veya iş kuralları üst katmanlara bırakılmış görünüyor.
- `DeleteAsync` var olmayan id için davranış belirsiz; `UpdateAsync` ile kıyaslandığında tutarsız hata yönetimi olabilir.

---

Genel Değerlendirme
- Katmanlar arası bağımlılıklar temiz ve Application -> Domain yönünde; Repository Pattern kullanımı açık.
- DTO/mapping yaklaşımı tutarlı; ancak validasyon ve hata yönetimi stratejisi netleştirilmeli (ör. tüm CRUD işlemlerinde tutarlı istisna/hata dönüşleri).
- Transaction, logging ve yetkilendirme gibi kesme noktaları görünmüyor; ihtiyaç varsa çapraz kesen endişeler için politika belirlenmeli.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane alan modelini temsil eden entity’leri tanımlamak (ör. kitap ve kategorisi).
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı mimari (Domain katmanı gözüküyor). Domain katmanı: iş kurallarının merkezi, entity ve value object’ler.
- Projeler/Assembly’ler:
  - Library.Domain — Domain entity’leri (ör. `Book`) ve ilişkileri.
- Kullanılan Dış Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kitap varlığını temsil eder; kimlik, başlık, yazar, ISBN, yayın yılı ve uygunluk bilgisini tutar. Domain katmanına aittir ve olası `BookCategory` ilişkisini içerir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kitabın benzersiz kimliği. |
| Title | `public string Title { get; set; }` | Kitabın başlığı. |
| Author | `public string Author { get; set; }` | Kitabın yazarı. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Kitabın ödünç verilebilirlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | İlişkili kategori navigasyon özelliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `IsAvailable = true`. `BookCategoryId` ve `BookCategory` opsiyoneldir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `BookCategory` (navigasyon).
- **İlişkili tipler:** `BookCategory` (muhtemel kategori entity’si).

---

### Genel Değerlendirme
- Sadece Domain katmanı görülebiliyor; diğer katmanlar (Application, Infrastructure, API) bu girdiyle tespit edilemiyor.
- Entity üzerinde doğrulama veya iş kuralı metodu bulunmuyor; tüm kontrol ve kuralların muhtemelen üst katmanlarda veya ORM yapılandırmasında ele alınması beklenir.### Project Overview
Proje adı: Library. Amaç: kitaplarla ilgili alan modelini tanımlamak (ör. kategoriler). Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak Domain katmanına ait bir entity sunulmuş, bu da genellikle Clean Architecture veya N‑Katmanlı mimaride Domain katmanını temsil eder. Bu katman saf C# tiplerinden oluşur ve iş kurallarının merkezidir.

Keşfedilen projeler/assemblies:
- Library.Domain — Domain katmanı; entity ve temel tipleri içerir.

Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

Mimari desen: Büyük olasılıkla Clean Architecture/N‑Katmanlı yapı; Domain katmanı bağımsızdır ve diğer katmanlar (Application/Infrastructure/API) buna bağımlı olur. Ancak diğer katmanlar bu dosyadan görülmüyor.

### Architecture Diagram
Library.Domain (Entities)
  ↑
Diğer katmanlar (Application/Infrastructure/API) — bu dosyadan anlaşılmıyor; tipik akışta Domain’a bağımlı olurlar.

---
### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, kitap kategorilerini temsil eden bir domain entity’sidir. Kategori meta verilerini ve kategoriye ait `Book` koleksiyonunu tutar. Mimari olarak Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
- `ICollection<Book> Books` — Kategoriye bağlı kitapların gezilebilir koleksiyonu (ilişkili `Book` entity’sine işaret eder).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kategorinin benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye ait kitaplar koleksiyonu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Books = []` (boş koleksiyon).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book` (ilişkili entity) — koleksiyon navigasyonu.
- **İlişkili tipler:** `Book` (aynı domain içinde varsayılan ilişki).

**7. Eksikler ve Gözlemler**
- `Book` tipi bu depoda görünmüyor; ilişki tamamlayıcı entity eksik olabilir.

Genel Değerlendirme
- Kod, yalnızca Domain katmanından tek bir entity içeriyor; diğer katmanlar görünmüyor. Hedef framework, dış bağımlılıklar ve yapılandırma anahtarları bu dosyadan anlaşılamıyor.
- Entity üzerinde iş kuralı/validasyon yok; ad ve açıklama için boş dize varsayılanı kullanılmış. Genişletme planlanıyorsa alan validasyonu (ör. `Name` zorunluluğu) eklenebilir.
- İlişkili `Book` entity’si bulunmadığı için navigasyon ilişkisi tek taraflı görünüyor. Entegrasyon için tamamlayıcı tiplerin eklenmesi gerekebilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanında müşteri bilgisini temsil eden domain entity’lerini barındırmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture yönünde işaretler (Domain katmanı mevcut). Diğer katmanlar (Application, Infrastructure, API) bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain modellerini barındırır (entity’ler).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)

---

### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer` bir kütüphane müşterisini temsil eden domain entity’sidir. Müşteri kimliği, iletişim bilgileri, üyelik numarası ve aktiflik durumunu taşır. Domain katmanına aittir ve muhtemelen kalıcı depolama için Infrastructure katmanında haritalanacaktır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Müşterinin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adresi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Üyelik/kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Müşterinin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `IsActive = true`. `RegisteredDate` ve `Id` için otomatik atama yok; dışarıdan set edilmesi beklenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Tüm setter’lar public; domain kuralları (ör. e-posta formatı, boş ad/soyad engeli) uygulanmıyor.
- `Id` ve `RegisteredDate` için oluşturma anında değer atama/koruma yok; yanlış/eksik veri riskine açık.

---

### Genel Değerlendirme
Kod tabanında yalnızca Domain katmanına ait bir entity görülebiliyor; diğer katmanlar ve bağımlılıklar bu dosyadan belirlenemiyor. Domain modelinde davranış/validasyon eksik; veri bütünlüğü için constructor tabanlı atama, value object’ler veya korumalı setter’lar değerlendirilebilir. Hedef framework, konfigürasyon ve dış paket kullanımı belirsiz.### Project Overview
Proje adı: Library. Amaç: Kütüphane alan modelini temsil etmek (ör. personel bilgileri). Hedef çerçeve: Bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Domain-odaklı mimari; yalnızca Domain katmanı görülebiliyor. Diğer katmanların (Application, Infrastructure, API) varlığı bu dosyadan anlaşılmıyor. Keşfedilen projeler/assembly’ler: 
- Library.Domain — Alan varlıkları (entities) ve temel domain tipleri.

Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff`, kütüphane personelini temsil eden bir domain varlığıdır. Temel kimlik ve iletişim bilgileri ile istihdam durumunu taşır. Domain katmanına aittir ve muhtemel veri erişim/iş mantığı katmanları tarafından kullanılmak üzere sade bir model sunar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

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
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktif çalışma durumunu belirtir. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = true`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanında yalnızca Domain katmanından bir entity görülüyor. Doğrulama, veri açıklama (ör. `Required`, uzunluk sınırları) ve ilişki/navigation özellikleri bu dosyada tanımlı değil; bu, projenin tasarım tercihine bağlı olabilir veya diğer katmanlarda ele alınıyor olabilir. Diğer katmanlar, persistence stratejisi ve dış bağımlılıklar bu dosyadan tespit edilemiyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` namespace)
- Amaç: Kütüphane alan modelini ve repository sözleşmelerini tanımlamak; özellikle `BookCategory` için depolama erişim kontratlarını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli — Domain katmanı (entity’ler ve repository arayüzleri). Uygulama/Infrastructure katmanları bu dosyadan görünmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain entity’leri ve repository arayüzleri (çekirdek iş kuralları ve sözleşmeler).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` entity’si için repository sözleşmesini genişletir ve kategori adına göre sorgulama ile ilişkili kitaplarla birlikte yükleme operasyonları için ek kontratlar sağlar. Domain katmanına aittir ve veri erişiminin arayüzünü tanımlar.

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
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Kategori adını kullanarak tek bir `BookCategory` döndürür; yoksa `null`. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Verilen `id` için ilişkili kitaplarıyla birlikte `BookCategory` döndürür; yoksa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByNameAsync` benzersiz/örnek isimle eşleşen kategoriyi getirir; bulunamazsa `null` beklenir.
- `GetWithBooksAsync` kategoriyle ilişkili kitap koleksiyonunun eager loading/explicit loading ile getirileceğini sözleşme düzeyinde ima eder; bulunamazsa `null` beklenir.
- Asenkron sözleşmeler I/O tabanlı veri erişimini hedefler; iptal belirteci parametresi tanımlı değildir.

**Mantık içermeyen basit DTO/model'ler için** bu tip bir arayüz olup davranış tanımlamaz; uygulama sınıfları iş kurallarını somutlar.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `IRepository<BookCategory>` (genel repository sözleşmesi), `BookCategory` (domain entity).
- **İlişkili tipler:** `BookCategory`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- İptal desteği (CancellationToken) bulunmuyor; uzun süren veri erişimi çağrıları için eklenmesi düşünülebilir. 

---

Genel Değerlendirme
- Kod, Domain katmanında repository sözleşmelerini tanımlar; bu, Clean Architecture’a uygun bir ayrımı işaret eder.
- Çözümde yalnızca `Library.Domain` görülebiliyor; Application/Infrastructure/API katmanları bu girdiden anlaşılamıyor.
- Sözleşmeler net, ancak iptal belirteci ve çoklu sonuç döndürebilecek sorgular için (ör. sayfalama, sıralama) genişletme fırsatı mevcut.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı ve yolundan)
- Amaç: Kütüphane alan modelini ve etki alanı sözleşmelerini (özellikle kitap depolama erişimi için repository arayüzünü) tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı (Domain katmanı görülebiliyor). Domain: `Entities` ve `Interfaces` ile temel sözleşmeler. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Etki alanı varlıkları ve repository arayüzleri.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]
  └─ Entities
  └─ Interfaces

---

### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlıkları için repository sözleşmesini genişleterek mevcut kitapların listelenmesi ve ISBN’e göre tekil sorgu operasyonlarını tanımlar. Domain katmanında, veri erişim ayrıntılarından bağımsız bir kontrat sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Book>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Mevcut/ödünç verilebilir durumdaki kitapları asenkron olarak döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen `isbn` ile eşleşen tek bir kitabı asenkron olarak getirir; yoksa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış tanımlamaz; veri erişim mantığı implementasyonlara bırakılır.
- `GetAvailableBooksAsync`: “mevcut” olma kriteri implementasyona göre belirlenir (bu dosyadan anlaşılmıyor).
- `GetByISBNAsync`: ISBN’in benzersiz olduğu varsayımı muhtemeldir, ancak doğrulama/format kuralları bu dosyadan anlaşılmıyor.
- Null dönüş olasılığı (`Book?`) çağıran tarafın null kontrolü yapmasını gerektirir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir (kullanıcıları muhtemelen uygulama servisleri/handler’lar; bu dosyadan anlaşılmıyor).
- **Aşağı akış:** Yok (arayüz).
- **İlişkili tipler:** `Book` (Domain entity), `IRepository<T>` (genel repository sözleşmesi).

**7. Eksikler ve Gözlemler**
- `IRepository<Book>` ve `Book` tanımları bu girdide bulunmuyor; metotların tam kapsamı ve temel CRUD kontratları bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Sadece Domain katmanından bir arayüz görülebiliyor; altyapı, uygulama veya sunum katmanlarına dair kanıt yok.
- ISBN doğrulama, hata yönetimi, filtreleme kriterleri gibi iş kuralları arayüz seviyesinde belirtilmemiş; implementasyonlara bırakılmış.
- Proje hedef framework’ü, kullanılan paketler ve yapılandırma anahtarları bu dosyadan tespit edilemiyor.### Project Overview
- Proje adı: Library (çıkarım: namespace’lerden)
- Amaç: Kütüphane alan modeline ait sözleşmeleri tanımlamak; özellikle `Customer` varlığı için repository kontratını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Domain katmanında entity ve repository sözleşmeleri tanımlanmış; uygulama ve altyapı katmanlarının bu sözleşmeleri sırasıyla kullanması/uygulaması beklenir.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Alan (Domain) model ve sözleşmeler (ör. `IRepository<T>`, `ICustomerRepository`).
- Kullanılan harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` varlığına özgü veri erişim işlemleri için sözleşme tanımlar. Domain katmanında yer alır ve genel `IRepository<Customer>` sözleşmesini genişleterek müşteri özelinde sorgular sunar.

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
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-posta adresine göre müşteriyi asenkron olarak getirir; yoksa `null`. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre müşteriyi asenkron olarak getirir; yoksa `null`. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif müşterileri asenkron olarak döner. |

**5. Temel Davranışlar ve İş Kuralları**
Interface — davranış yok. İmzalar asenkron ve null dönebilme olasılığını ifade eder (`Customer?`) ki bulunamama durumunu yansıtır. `GetActiveCustomersAsync` aktiflik kriterine göre filtreleme beklentisi oluşturur; kriter tanımı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/servis katmanları ve handler’lar tarafından kullanılması beklenir.
- **Aşağı akış:** `IRepository<Customer>` (genel CRUD sözleşmesi), `Customer` (entity).
- **İlişkili tipler:** `Customer`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametreleri yok; yoğun isteklerde iptal desteği ve zaman aşımı yönetimi için eklenmesi faydalı olabilir. 

---

Genel Değerlendirme
- Kod, Clean/Layered Architecture yönelimini gösteren Domain sözleşmesine odaklı. Yalnızca Domain katmanı görülebildiğinden diğer katmanların (Application/Infrastructure/API) varlığı ve bağımlılık akışı bu dosyadan kesinleşmiyor.
- Asenkron metotlarda `CancellationToken` desteği yok; ölçeklenebilirlik ve dayanıklılık için eklenmesi önerilir.
- `IRepository<Customer>` içeriği görünmediği için sözleşme kapsamı (CRUD, sayfalama, sıralama) belirsiz.### Project Overview
- Proje adı: Library (bu dosya adlandırmasından çıkarım)
- Amaç: Domain katmanında generic CRUD sözleşmesi sağlayan bir `Repository` arayüzü tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari/temiz mimari eğilimi; Domain katmanında soyutlama (Repository) sunuluyor. Uygulama/Infrastructure katmanlarının bu arayüzü uygulaması beklenir.
- Projeler/Assembly’ler:
  - Library.Domain — Domain soyutlamaları (interfaces) içerir.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  └─ Interfaces (IRepository<T>)
[Başka katmanlara bağımlılık veya akış bu dosyadan anlaşılmıyor; tipik akış Domain → Infrastructure (implementasyon) → Application/Presentation (kullanım) olabilir, ancak kanıt yok.]

---
### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
Generic `Repository` arayüzü, `T` tipi için temel asenkron CRUD operasyonlarının sözleşmesini tanımlar. Domain katmanına aittir ve veri erişim detaylarını soyutlamak için kullanılır.

**2. Tip Bilgisi**
- Tip: interface
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `id` için tekil varlığı asenkron olarak döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları asenkron olarak döndürür. |
| AddAsync | `Task AddAsync(T entity)` | Yeni varlığı ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut varlığı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’ye sahip varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış tanımlamaz; implementasyon veri kaynağına göre değişir.
- Tüm operasyonlar asenkron `Task` döner; `CancellationToken` parametresi yok.
- `GetByIdAsync` bulunamayan kayıt için `null` dönebilir.
- `DeleteAsync` ve `GetByIdAsync` `Guid` tabanlı kimlik varsayar.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Bu dosyadan anlaşılmıyor (implementasyonlar veri erişim teknolojisine bağlıdır).
- İlişkili tipler: `T` (class kısıtlı generic varlık tipi).

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` desteği bulunmuyor; uzun süren I/O işlemlerinde iptal desteği eksik olabilir.
- `UpdateAsync` ve `AddAsync` dönüş değeri yok; oluşturulan/güncellenen varlığı veya etkilenen kayıt sayısını döndürmek bazı senaryolarda faydalı olabilir.

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanında bir `Repository` arayüzü görülüyor; diğer katmanlar ve implementasyonlar bu dosyadan belirlenemiyor.
- İptal belirteci (`CancellationToken`) ve potansiyel hata/sonuç iletimine yönelik dönüş tipleri (ör. `bool`, etkilenen satır sayısı veya `T`) iyileştirilebilir.
- Varlık kimliğinin `Guid` olarak sabitlenmesi esneklik kısıtı oluşturabilir; generic anahtar tipi (`TKey`) düşünülerek genişletilebilir.### Project Overview
Proje adı, amaç ve hedef çatı: Kod, `Library.Domain` isim alanı altında bir kütüphane sistemi için Domain katmanını temsil eder. Amaç, personel (`Staff`) varlığına yönelik repository sözleşmelerini tanımlamaktır. Hedef çatı (target framework) bu dosyadan anlaşılmıyor.
Mimari desen: Katmanlı mimari (N‑Tier) işaretleri mevcut. Bu dosya Domain katmanı içinde repository arayüzlerini tanımlar; uygulama ve altyapı katmanları bu sözleşmeleri kullanıp uygular.
Projeler/assembly’ler: 
- Library.Domain — Domain modelleri ve repository arayüzleri.
Harici paket/çatı: Bu dosyadan anlaşılmıyor.
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` varlıkları için repository kontratını genişleterek e‑posta ile arama ve aktif personeli listeleme operasyonlarını tanımlar. Domain katmanına aittir ve altyapı katmanındaki somut repository implementasyonları tarafından uygulanması beklenir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Staff>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
- `IRepository<Staff>` — Temel CRUD sözleşmesini sağlar.
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | E‑posta adresine göre tek bir `Staff` kaydını döndürür (yoksa `null`). |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki tüm `Staff` kayıtlarını döndürür. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByEmailAsync` tekil eşleşme varsayımı ima eder; e‑posta benzersiz olmalıdır (iş kuralı uygulama/altyapıda doğrulanır).
- `GetActiveStaffAsync` “aktif” kriterini altyapı katmanındaki filtre ile uygular; kriter tanımı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Service katmanı tarafından çağrılması beklenir.
- **Aşağı akış:** `IRepository<Staff>`
- **İlişkili tipler:** `Library.Domain.Entities.Staff`, `IRepository<Staff>`

**7. Eksikler ve Gözlemler**
- Async metodlarda `CancellationToken` parametresi yok; yoğun sorgularda iptal desteği gerekebilir.

---

Genel Değerlendirme
- Yalnızca Domain katmanı görünür; uygulama, altyapı ve sunum katmanları bu depodan anlaşılamıyor.
- Repository kontratı net ve amaca uygun; ancak iptal belirteci (`CancellationToken`) eksikliği ve e‑posta benzersizliği gibi iş kuralları için belgelenmiş sözleşmeler faydalı olabilir.### Project Overview
- Proje adı: Library (adlandırma ve namespace’lerden çıkarım)
- Amaç: Kütüphane alan varlıklarını (`Book`, `BookCategory`, `Staff`, `Customer`) EF Core ile kalıcı hale getiren altyapı erişimi sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean türevi — Domain (varlıklar) ve Infrastructure (kalıcılık/EF Core) katmanları görülüyor. Infrastructure, Domain’a bağımlı.
- Projeler/Assembly’ler:
  - Library.Domain — Varlıkların tanımı (entity’ler)
  - Library.Infrastructure — EF Core `DbContext` ve veritabanı eşlemeleri
- Dış bağımlılıklar:
  - Microsoft.EntityFrameworkCore (EF Core)
- Konfigürasyon gereksinimleri: Connection string ve `DbContext` kayıt/konfigürasyonu muhtemel; bu dosyada açıkça belirtilmemiş.

### Architecture Diagram
Library.Infrastructure → Library.Domain

---

### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
EF Core tabanlı `DbContext` implementasyonu; `Book`, `BookCategory`, `Staff`, `Customer` varlıklarının tablo eşlemelerini ve kısıtlarını yapılandırır. Altyapı (Infrastructure) katmanında yer alır ve Domain varlıklarını kalıcılığa bağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `Microsoft.EntityFrameworkCore.DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core `DbContext` yapılandırma seçenekleri (bağlantı/sağlayıcı vs.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | `DbContext` için konfigürasyon seçeneklerini alır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlıkları için sorgu/küme erişimi. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlıkları için sorgu/küme erişimi. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlıkları için sorgu/küme erişimi. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlıkları için sorgu/küme erişimi. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Varlık eşlemeleri, indeksler ve ilişkileri tanımlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book`:
  - `Title` zorunlu, max 200; `Author` zorunlu, max 150; `ISBN` zorunlu, max 20 ve benzersiz indeks.
  - `BookCategory` ile ilişki: `HasOne`/`WithMany`, FK `BookCategoryId`, silmede `SetNull`.
- `BookCategory`:
  - `Name` zorunlu, max 100 ve benzersiz indeks; `Description` opsiyonel, max 500.
- `Staff`:
  - `FirstName`, `LastName`, `Email`, `Position` zorunlu; uzunluk kısıtları sırasıyla 100/100/200/100.
  - `Phone` opsiyonel, max 20; `Email` benzersiz indeks.
- `Customer`:
  - `FirstName`, `LastName`, `Email`, `MembershipNumber` zorunlu; uzunluk kısıtları 100/100/200/50.
  - `Phone` opsiyonel, max 20; `Address` opsiyonel, max 500.
  - `Email` ve `MembershipNumber` için benzersiz indeksler.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir (typik olarak uygulama başlatımında `AddDbContext` ile).
- Aşağı akış: `Library.Domain.Entities` (entity tipleri), `Microsoft.EntityFrameworkCore` (EF Core API’leri).
- İlişkili tipler: `Book`, `BookCategory`, `Staff`, `Customer`.

**7. Eksikler ve Gözlemler**
- `OnDelete(DeleteBehavior.SetNull)` kullanımı, `BookCategoryId`’nin nullable olmasını gerektirir; Domain tarafında karşılık gelen property’nin nullable tanımlandığı doğrulanmalıdır.
- Connection string ve sağlayıcı konfigürasyonu bu dosyada yer almıyor; uygulama başlatımında doğru kayıt zorunlu.

---

Genel Değerlendirme
- Mimari olarak Domain ve Infrastructure ayrımı net; EF Core konfigürasyonları Infrastructure’da toplanmış.
- Eşleme kuralları detaylı ve indeksler anlamlı belirlenmiş (özellikle `ISBN`, `Email`, `MembershipNumber`).
- Uygulama katmanı, migration’lar veya API katmanı bu girdiyle görünmüyor; validasyonların sadece veri katmanı kısıtlarıyla sınırlı kalma riski var. Domain veya Application seviyesinde ilave iş kuralları/validasyonlar gerekiyorsa tutarlı şekilde eklenmelidir.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane alanına yönelik domain arayüzlerinin altyapı implementasyonlarını ve veri erişimini sağlamak.
- Hedef Framework: Bu dosyadan kesin değil; .NET Core/ASP.NET Core ekosistemine uygun DI ve EF Core kullanımı mevcut.
- Mimari Desen: N‑Katmanlı mimari. Görülen katmanlar:
  - Domain: `Library.Domain.Interfaces` — repository arayüzleri.
  - Infrastructure: `Library.Infrastructure.*` — EF Core `DbContext` ve repository implementasyonları ile DI kompozisyonu.
- Proje/Assembly’ler:
  - Library.Domain — Domain arayüzleri (görülen: `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`).
  - Library.Infrastructure — Altyapı ve veri erişimi (görülen: `LibraryDbContext`, repository implementasyonları ve DI uzantısı).
- Dış Bağımlılıklar:
  - Entity Framework Core (`Microsoft.EntityFrameworkCore`) ve SQL Server sağlayıcısı (`UseSqlServer`).
  - `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Configuration`.
- Konfigürasyon Gereksinimleri:
  - Connection string: `DefaultConnection` (appsettings veya çevresel değişkenlerde tanımlı olmalı).

### Architecture Diagram
Domain (Library.Domain.Interfaces)
        ↑
Infrastructure (Library.Infrastructure.Data, .Repositories, .DependencyInjection)

---

### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Infrastructure katmanının DI kayıtlarını tek noktadan sağlayan genişletme metodunu sunar. EF Core `DbContext` konfigürasyonunu ve repository implementasyonlarının `Scoped` olarak kaydını yapar. Altyapı katmanının kompozisyon kökünden kolayca eklenmesini amaçlar.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Infrastructure`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core `LibraryDbContext`’i ve repository implementasyonlarını DI konteynerine kaydeder, zincirleme için `IServiceCollection` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server ile `UseSqlServer(configuration.GetConnectionString("DefaultConnection"))` üzerinden yapılandırılır.
- Repository’ler `Scoped` yaşam süresi ile kaydedilir: `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`.
- `DefaultConnection` bulunamaz veya hatalı ise çalışma zamanında EF Core başlatma/bağlantı hataları oluşabilir.

**6. Bağlantılar**
- Yukarı akış: Kompozisyon kökü (ör. API `Program.cs` veya host builder) üzerinden çağrılır.
- Aşağı akış: `LibraryDbContext`, `BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`.
- İlişkili tipler: `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`, `LibraryDbContext`.

Genel Değerlendirme
- Mimari ayrım net: Domain arayüzleri ile Infrastructure implementasyonları ayrılmış.
- Konfigürasyon anahtarı sabit adla (`DefaultConnection`) bekleniyor; farklı ortamlar için ad esnekliği veya doğrulama eklenebilir.
- Görünür kısımda sadece Infrastructure katmanı mevcut; Application/API katmanları bu dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: Kitap kategorileri ve ilişkili kitaplar için veri erişim katmanı sağlamak. Hedef çatı: .NET (EF Core kullandığı için modern .NET; kesin sürüm bu dosyadan anlaşılmıyor).
Mimari: Clean Architecture/N‑Katmanlı yaklaşım izleri. Domain katmanı (entitiy ve interface’ler) ile Infrastructure katmanı (EF Core tabanlı repository ve DbContext) ayrışmış.
Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Domain — `Entities`, `Interfaces` içerir; çekirdek iş kuralları ve sözleşmeler.
- Library.Infrastructure — `Data` (DbContext) ve `Repositories` (EF Core implementasyonları).
Kullanılan başlıca paket/çatı: Microsoft.EntityFrameworkCore (EF Core).
Konfigürasyon gereksinimleri: Veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları muhtemel; bu dosyadan bağlantı anahtarları görülmüyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)
        ↑
        | (IBookCategoryRepository)
Library.Infrastructure (Data: LibraryDbContext, Repositories: BookCategoryRepository)

---
### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için EF Core tabanlı repository implementasyonudur. Kategori sorgulama ve CRUD işlemlerini gerçekleştirir. Mimari olarak Infrastructure veri erişim katmanına aittir ve `IBookCategoryRepository` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BookCategory` DbSet’i üzerinden veri işlemleri

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryRepository(LibraryDbContext context)` | DbContext’i DI ile alır. |
| GetByIdAsync | `Task<BookCategory?> GetByIdAsync(Guid id)` | Id’ye göre kategori döndürür. |
| GetAllAsync | `Task<IEnumerable<BookCategory>> GetAllAsync()` | Tüm kategorileri listeler. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk kategoriyi bulur. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili `Books` navigasyonu ile kategoriyi getirir. |
| AddAsync | `Task AddAsync(BookCategory entity)` | Yeni kategori ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(BookCategory entity)` | Kategoriyi günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varsa kategoriyi siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular async EF Core yöntemleri (`FindAsync`, `ToListAsync`, `FirstOrDefaultAsync`) ile çalışır.
- `GetWithBooksAsync` ilişkili `Books` koleksiyonunu `Include` ile eager load eder.
- Yazma işlemleri (`AddAsync`, `UpdateAsync`, `DeleteAsync`) her çağrıda `SaveChangesAsync` tetikler.
- `DeleteAsync` bulunamadığında sessizce no-op yapar; exception fırlatmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden `IBookCategoryRepository` olarak çözülür; uygulama servisleri/handler’lar tarafından çağrılır.
- **Aşağı akış:** `LibraryDbContext`
- **İlişkili tipler:** `BookCategory`, `IBookCategoryRepository`, `LibraryDbContext`

**7. Eksikler ve Gözlemler**
- İmzalarda `CancellationToken` desteği yok.
- Yazma işlemlerinde her metodda ayrı `SaveChangesAsync` çağrısı, birim-iş (Unit of Work) veya toplu işlem senaryolarında verimsiz olabilir.
- Eşzamanlılık/versiyon kontrolü (concurrency) ve domain düzeyinde validasyon görünmüyor; bu dosyadan anlaşılmıyor.

---
Genel Değerlendirme
- Domain ve Infrastructure ayrımı net; repository EF Core ile uygulanmış.
- Birim-iş (Unit of Work) veya transaction koordinasyonu katmanı görünmüyor; her operasyonda `SaveChangesAsync` kullanımı performans ve tutarlılık açısından senaryo bazlı gözden geçirilmeli.
- İptal belirteci (`CancellationToken`) ve hata yönetimi politikaları (ör. not-found davranışı) tutarlı hale getirilebilir.
- Konfigürasyon ve sağlayıcı seçimi (EF Core provider) bu kesitte görünmüyor; proje genelinde standartlaştırılması önerilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanındaki `Book` varlıkları için kalıcı veri erişimi sağlamak (Repository deseni ile).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı mimari (Domain ve Infrastructure). Domain katmanı etki alanı modelleri ve sözleşmeleri tanımlar; Infrastructure katmanı veri erişimi ve dış bağımlılıkların somutlamasını içerir.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Etki alanı entity’leri (`Book`) ve sözleşmeler (`IBookRepository`).
  - Library.Infrastructure — EF Core tabanlı repository implementasyonları ve `LibraryDbContext`.
- Dış paket/çatı: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon gereksinimleri: `LibraryDbContext` için bağlantı dizesi/appsettings anahtarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---
### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`BookRepository`, `IBookRepository` sözleşmesini EF Core ile gerçekleştiren repository implementasyonudur. `Book` entity’si için temel CRUD ve sorgulama operasyonlarını sağlar. Infrastructure katmanında yer alır ve `LibraryDbContext` üzerinden veri erişimi yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Book` verilerinin sorgulanması ve kalıcılığından sorumlu.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookRepository(LibraryDbContext context)` | DbContext bağımlılığını alır. |
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Id ile tek `Book` kaydını getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm `Book` kayıtlarını listeler. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları listeler. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre ilk eşleşen kitabı getirir; yoksa `null`. |
| AddAsync | `Task AddAsync(Book entity)` | Yeni kitabı ekler ve `SaveChangesAsync` çağırır. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Mevcut kitabı günceller ve `SaveChangesAsync` çağırır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id ile kitabı bulur, varsa siler ve `SaveChangesAsync` çağırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgulamalar EF Core üzerinden gerçekleştirilir; `GetAvailableBooksAsync` `IsAvailable` filtresi uygular.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` ile kalıcılık sağlar; işlem sınırı repository düzeyindedir.
- `DeleteAsync` hedef bulunamazsa sessizce hiçbir işlem yapmaz.
- `GetByIdAsync` ve `GetByISBNAsync` bulunamazsa `null` döner.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; `IBookRepository`’yi kullanan uygulama servisleri/handler’lar tarafından çağrılır.
- Aşağı akış: `LibraryDbContext` (EF Core).
- İlişkili tipler: `Book` (entity), `IBookRepository` (sözleşme), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Repository içinde her operasyonda `SaveChangesAsync` çağrılması, birim-iş (Unit of Work) yaklaşımını zorlaştırabilir.
- Sorgularda `AsNoTracking()` kullanılmıyor; yalnızca okuma senaryolarında performans için düşünülmeli.
- `GetAllAsync` için sayfalama yok; büyük veri kümelerinde performans/IO maliyeti artabilir.
- İptal belirteci (`CancellationToken`) desteği yok.### Project Overview
- Proje adı: Library (koddan çıkarım). Amaç: Kütüphane alanı için müşteri yönetimi; müşteri verilerine erişim ve persistans işlemleri.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Tier varyasyonu. Katmanlar:
  - Domain: `Library.Domain` — entity ve repository sözleşmeleri.
  - Infrastructure: `Library.Infrastructure` — EF Core ile kalıcılaştırma, repository implementasyonları ve `DbContext`.
- Keşfedilen projeler/assembly’ler:
  - `Library.Domain` — `Customer` entity’si ve `ICustomerRepository` sözleşmesi.
  - `Library.Infrastructure` — `LibraryDbContext` ve `CustomerRepository` implementasyonu.
- Harici paket/çatı: Entity Framework Core (`Microsoft.EntityFrameworkCore`).
- Konfigürasyon gereksinimleri: `LibraryDbContext` için bir veritabanı bağlantı dizesi gerekir; anahtar adı ve sağlayıcı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain (`Library.Domain`)
  ^ 
  | (references interfaces/entities)
Infrastructure (`Library.Infrastructure`) --> depends on Domain

---
### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`CustomerRepository`, `ICustomerRepository`’yi EF Core üzerinden implemente ederek `Customer` entity’lerine CRUD ve sorgulama operasyonları sağlar. Clean Architecture’da Infrastructure katmanına aittir ve kalıcılık (persistence) sorumluluğunu üstlenir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Customer` set’i üzerinden veri erişimi ve `SaveChangesAsync` çağrıları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `CustomerRepository(LibraryDbContext context)` | DbContext’i DI ile alır. |
| GetByIdAsync | `Task<Customer?> GetByIdAsync(Guid id)` | Id ile müşteri döner; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<Customer>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E‑posta ile tek müşteri arar. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasıyla müşteri arar. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive == true` müşterileri getirir. |
| AddAsync | `Task AddAsync(Customer entity)` | Yeni müşteri ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(Customer entity)` | Var olan müşteriyi günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id ile müşteriyi siler; yoksa sessizce geçer. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgulamalar EF Core üzerinden asenkron yapılır.
- `GetBy*` metotları bulunamazsa `null` döner; exception fırlatmaz.
- `GetActiveCustomersAsync` yalnızca `IsActive` olan kayıtları filtreler.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` ile hemen kalıcılaştırır (transaction kapsamı bu seviyede parçalıdır).
- `DeleteAsync` bulunamayan id için no-op davranır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden `ICustomerRepository`’yi tüketen application servisleri/handler’lar.
- Aşağı akış: `LibraryDbContext` ve EF Core.
- İlişkili tipler: `Customer`, `ICustomerRepository`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- İptal belirteci (`CancellationToken`) desteği yok.
- Repository içinde `SaveChangesAsync` çağrıları Unit of Work kullanımını zorlaştırır; transaction koordinasyonu sınırlı kalabilir.
- Sorgularda izleme ayarı (`AsNoTracking`) tercihleri belirtilmemiş; okuma senaryolarında gereksiz izleme yükü olabilir.
- Sayfalama/sıralama desteği yok; `GetAllAsync` büyük veri setlerinde maliyetli olabilir.

---
Genel Değerlendirme
- Katman ayrımı Domain ve Infrastructure arasında net; EF Core kullanımı belirgin.
- Transaction/Unit of Work deseni yok veya bu dosyadan görünmüyor; save işlemleri metot bazlı.
- İyileştirmeler: `CancellationToken` eklenmesi, okuma sorgularında `AsNoTracking`, toplu değişikliklerde UoW, sayfalama/sıralama, hata/istisna stratejisinin standardize edilmesi ve potansiyel soft-delete deseni değerlendirmesi.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kitap yönetimi için domain ve altyapı katmanları; `InMemoryBookRepository` ile bellek içi kitap depolama. Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı Mimari. Domain katmanı (`Library.Domain`) entity ve repository sözleşmelerini barındırır. Infrastructure katmanı (`Library.Infrastructure`) domain arayüzlerinin somut implementasyonlarını sağlar (ör. bellek içi repository).

Projeler/Assembly’ler:
- Library.Domain — `Entities` (örn. `Book`), `Interfaces` (örn. `IBookRepository`)
- Library.Infrastructure — `Repositories` (örn. `InMemoryBookRepository`)

Kullanılan dış paketler/frameworkler: bu dosyadan anlaşılmıyor (standart .NET koleksiyonları ve `Task` kullanımı dışında görünür bağımlılık yok).

Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor (in-memory implementasyon olduğu için bağlantı dizesi gerektirmez).

### Architecture Diagram
Library.Infrastructure.Repositories -> Library.Domain.Interfaces  
Library.Infrastructure.Repositories -> Library.Domain.Entities

---

### `Library.Infrastructure/Repositories/InMemoryBookRepository.cs`

**1. Genel Bakış**
`InMemoryBookRepository`, `IBookRepository`’nin bellek içi implementasyonudur. Amaç, `Book` entity’leri üzerinde CRUD benzeri işlemleri senkron olmayan API ile hafızada sağlamaktır. Altyapı (Infrastructure) katmanına aittir; tipik olarak testler veya basit demo senaryolarında kullanılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Verilen `id` ile eşleşen kitabı döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitapları döndürür. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre kitabı bulur; bulunamazsa `null`. |
| AddAsync | `Task AddAsync(Book entity)` | Yeni kitabı listeye ekler. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Eşleşen `Id` bulunduğunda kitabı günceller; bulunamazsa sessizce geçer. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | `Id` eşleşirse kitabı listeden kaldırır; bulunamazsa sessizce geçer. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Default değerler: bu dosyadan anlaşılmıyor (entity `Book` ayrıntıları görünmüyor).
- `UpdateAsync` ve `DeleteAsync` bulunamadığında hata fırlatmaz, sessizce tamamlanır.
- `GetAllAsync` ve `GetAvailableBooksAsync` mevcut liste referansını/sorgusunu döndürür; derin kopya yapmaz.
- Ekleme sırasında ISBN veya Id benzersizliği doğrulaması yapılmaz.
- Thread-safe değildir; `_books` üzerinde eşzamanlı erişim için senkronizasyon yoktur.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok; dahili `_books: List<Book>`.
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `Library.Domain.Interfaces.IBookRepository`.

**7. Eksikler ve Gözlemler**
- Eşzamanlılık için thread-safety yok; çok iş parçacıklı kullanımda veri tutarsızlığı oluşabilir.
- `UpdateAsync`/`DeleteAsync` bulunamadığında geribildirim yok; hata yönetimi veya sonuç bilgisi (ör. boolean/exception) eksik.
- Eklemede benzersizlik kontrolü (özellikle `ISBN`) yok; veri bütünlüğü ihlallerine yol açabilir.

---

Genel Değerlendirme
- Katman ayrımı net: Infrastructure, Domain’e bağımlı. Ancak Application/Presentation katmanları görünmüyor.
- Repository in-memory olduğundan kalıcılık, transaction ve hata yönetimi sınırlı.
- Sözleşme tarafı (`IBookRepository`, `Book`) görünmediğinden kapsamlı iş kuralları ve validasyon akışı değerlendirilemiyor.
- Üretim senaryoları için eşzamanlılık, benzersizlik ve hata işleme stratejileri tanımlanmalı; kalıcı bir veri sağlayıcısı eklenmeli.### Project Overview
- Proje adı: Library (namespace kökünden çıkarım)
- Amaç: Kütüphane alanındaki personel (`Staff`) verilerine erişim sağlamak; depo (repository) aracılığıyla CRUD ve sorgulama işlemleri yürütmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: N‑Katmanlı + Repository deseni. Domain katmanı (entity ve kontratlar) ile Infrastructure katmanı (EF Core tabanlı veri erişimi) ayrışmış.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain: `Entities` (ör. `Staff`) ve `Interfaces` (ör. `IStaffRepository`) barındırır.
  - Library.Infrastructure: EF Core `DbContext` ve repository implementasyonlarını içerir.
- Kullanılan harici paketler/çatı:
  - Microsoft.EntityFrameworkCore (EF Core) — asenkron sorgular ve `DbContext` işlemleri.
- Konfigürasyon gereksinimleri:
  - `LibraryDbContext` için bağlantı dizesi ve sağlayıcı ayarları gerekir; anahtar adları ve formatı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`StaffRepository`, `IStaffRepository` kontratını EF Core ile gerçekleştiren depo sınıfıdır. `Staff` varlıkları için temel CRUD ve yaygın sorguları sağlar. Infrastructure katmanına aittir ve `LibraryDbContext` üzerinden veri erişimi yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `Staff` `DbSet`’i üzerinden veri işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffRepository(LibraryDbContext context)` | Repository’i verilen `LibraryDbContext` ile başlatır. |
| GetByIdAsync | `public Task<Staff?> GetByIdAsync(Guid id)` | Birincil anahtara göre `Staff` döndürür. |
| GetAllAsync | `public Task<IEnumerable<Staff>> GetAllAsync()` | Tüm `Staff` kayıtlarını listeler. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | E-posta eşleşmesine göre ilk `Staff`’ı döndürür. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive == true` olan personeli listeler. |
| AddAsync | `public Task AddAsync(Staff entity)` | Yeni `Staff` ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Staff entity)` | Var olan `Staff`’ı günceller ve değişiklikleri kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | ID’ye göre `Staff` bulursa siler ve değişiklikleri kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular ve CRUD işlemleri EF Core asenkron API’leri ile yapılır.
- `GetActiveStaffAsync` yalnızca `IsActive` true olan kayıtları döndürür.
- `GetByEmailAsync` tam eşleşme ile ilk uygun kaydı getirir; bulunamazsa `null`.
- `DeleteAsync` ilgili kayıt yoksa hiçbir işlem yapmadan döner; bulunursa siler.
- Her yazma işlemi (`AddAsync`, `UpdateAsync`, `DeleteAsync`) sonunda `SaveChangesAsync` çağrılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya controller’lar tarafından çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<Staff>`, EF Core.
- **İlişkili tipler:** `IStaffRepository`, `LibraryDbContext`, `Library.Domain.Entities.Staff`.

**7. Eksikler ve Gözlemler**
- Yüksek hacimli/çoklu değişiklik senaryolarında her method içinde `SaveChangesAsync` çağrısı birimsel işlem (Unit of Work) kompozisyonunu zorlaştırabilir.
- Metotlarda `CancellationToken` desteği yok.

---

Genel Değerlendirme
- Domain ve Infrastructure ayrımı net; repository deseni uygulanmış.
- EF Core kullanımı tutarlı; temel sorgular sağlanmış.
- İyileştirme fırsatları: `CancellationToken` parametreleri, yazma işlemlerinde Unit of Work yaklaşımı, e-posta aramalarında kültür/karşılaştırma seçeneklerinin belirginleştirilmesi ve olası indeks gereksinimlerinin ele alınması (bu dosyadan doğrulanamıyor).### Project Overview (required, once)
Proje adı: Library. Amaç: Kitap kategorileri için HTTP API uç noktaları sunmak ve Application katmanındaki servisler üzerinden veri erişimi/iş mantığını yürütmek. Hedef çatı: .NET (ASP.NET Core Web API). Mimari yaklaşım, Application ve Presentation (API) katmanlarını ayıran katmanlı bir yapıdadır.
Keşfedilen katmanlar ve roller:
- Library (API/Presentation): ASP.NET Core controller’ları; HTTP isteklerini alır, Application servislerini çağırır, HTTP yanıtları üretir.
- Library.Application: DTO’lar ve servis sözleşmeleri; iş kurallarını ve Use Case’leri temsil eden arabirimler.
Kullanılan dış çatı/paketler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). EF Core, MediatR vb. bu dosyadan anlaşılmıyor.
Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram (required, once)
Library (API/Presentation) --> Library.Application (DTOs, Service Interfaces)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için listeleme ve tekil sorgulama uç noktalarını sağlayan ASP.NET Core API controller’ıdır. Presentation katmanında yer alır ve iş mantığını `Library.Application` katmanındaki `IBookCategoryService` aracılığıyla çağırır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori verilerini almak için Application katmanında tanımlı servis sözleşmesi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategori kayıtlarını döndürür; `200 OK` ile koleksiyon. |
| GetById | `public async Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID ile kategori getirir; bulunamazsa `404 NotFound`, aksi halde `200 OK`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GET api/BookCategories` tüm kategorileri `IBookCategoryService.GetAllAsync()` ile döndürür.
- `GET api/BookCategories/{id:guid}` istenen GUID formatında olmalıdır; bulunamazsa `NotFound()` döner.
- Controller düzeyinde `[ApiController]` özniteliği model bağlama ve hata yanıtlarını standartlaştırır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (ör. frontend, Postman) bu controller’ı çağırır.
- **Aşağı akış:** `IBookCategoryService`
- **İlişkili tipler:** `BookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- Kategori için `POST/PUT/DELETE` uç noktaları eksik; yalnızca okuma operasyonları mevcut.
- Yetkilendirme öznitelikleri (`[Authorize]`) yok; erişim kontrolü bu dosyadan anlaşılmıyor.### Project Overview
- Ad: Library (API) — Amaç: Kitap kaynakları için RESTful CRUD uç noktaları sağlamak; Application katmanındaki servis ve DTO’larla çalışır. Hedef: ASP.NET Core Web API (kesin sürüm bu dosyadan anlaşılmıyor).
- Mimari: Clean Architecture/N‑Tier eğilimli. Bu dosyada görülen katmanlar:
  - Presentation/API: Controller’lar (`Library.Controllers`), HTTP isteklerini karşılar.
  - Application: Servis sözleşmeleri ve DTO’lar (`Library.Application.Interfaces`, `Library.Application.DTOs`).
- Projeler/Assembly’ler:
  - Library (API) — Web sunumu, controller uç noktaları.
  - Library.Application — Uygulama sözleşmeleri (`IBookService`) ve DTO’lar (`BookDto`, `CreateBookDto`, `UpdateBookDto`).
- Dış paketler/çatı: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon: Bu dosyada özel konfigürasyon anahtarı/connection string görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplara yönelik CRUD ve listeleme uç noktalarını sunan ASP.NET Core Web API controller’ıdır. Application katmanındaki `IBookService` ile konuşur ve DTO’larla veri taşır. Mimari olarak Presentation/API katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplar için uygulama servis sözleşmesi; CRUD ve filtreli listeleme işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BooksController(IBookService bookService)` | Servis bağımlılığını DI ile alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döner. |
| GetById | `public Task<ActionResult<BookDto>> GetById(Guid id)` | Id ile kitabı getirir; yoksa 404 döner. |
| GetAvailable | `public Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Müsait kitapları listeler. |
| Create | `public Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Yeni kitap oluşturur; 201 ve konum döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Kitabı günceller; yoksa 404, başarıda 204. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Kitabı siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretir.
- `Create`: `CreatedAtAction(nameof(GetById), new { id = book.Id }, book)` ile 201 ve Location header döner.
- `Update`: Sadece `KeyNotFoundException` yakalanır; bu durumda 404 döner, aksi halde 204.
- `Delete`: Her durumda 204 döner; yokluk durumuna özel işlem bu dosyadan anlaşılmıyor.
- Tüm aksiyonlar asenkron çalışır ve `IBookService`e delege eder.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; HTTP istemcileri (API tüketicileri) çağırır.
- Aşağı akış: `IBookService`
- İlişkili tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`

**7. Eksikler ve Gözlemler**
- `Delete` için bulunamayan kaynak senaryosunda özel hata işleme açık değil; 204 dönebilir.
- Yetkilendirme/kimlik doğrulama niteliği yok (`[Authorize]` yok); güvenlik gereksinimleri varsa eklenmeli.
- `Update` yalnızca `KeyNotFoundException` yakalıyor; diğer hata türleri yayılacaktır. Gerekirse merkezi hata yönetimi veya daha kapsamlı eşleme düşünülmeli.
- İptal belirteci (`CancellationToken`) desteği yok; uzun süren işlemlerde faydalı olabilir.

---
Genel Değerlendirme
- Katman ayrımı net: API, Application sözleşmeleri ve DTO’lara dayanıyor. Domain/Infrastructure bu dosyadan görünmüyor.
- Controller yalın ve sorumlulukları uygun; iş kuralları serviste tutuluyor.
- Hata/yetkilendirme ve bulunamayan silme senaryosu için davranışların netleştirilmesi, iptal belirteci desteği ve olası model doğrulama stratejilerinin (filter/attribute) belirlenmesi önerilir.### Project Overview
- Proje adı: Library (ASP.NET Core Web API)
- Amaç: Müşteri yönetimi için HTTP endpoint’leri sağlamak (listeleme, detay, oluşturma, güncelleme, silme). Uygulama katmanındaki `ICustomerService` aracılığıyla iş kurallarını çalıştırır ve DTO’larla veri alışverişi yapar.
- Hedef framework: ASP.NET Core Web API (tam .NET sürümü bu dosyadan anlaşılmıyor).
- Mimari desen: N-Tier/Layered Architecture
  - Presentation/API: `Library` (Controllers)
  - Application: `Library.Application` (DTO’lar ve `ICustomerService` gibi servis sözleşmeleri)
  - Diğer katmanlar (Domain, Infrastructure) bu dosyadan anlaşılmıyor.
- Projeler/assemblies:
  - Library: Web API sunum katmanı
  - Library.Application: Uygulama servis sözleşmeleri ve DTO’lar
- Harici paket/çatı: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Service Contracts, DTOs)

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri ile ilgili HTTP endpoint’lerini sunan API katmanı denetleyicisidir. CRUD ve “aktif müşteriler” sorgusunu `ICustomerService` üzerinden delege eder. Sunum (API) katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygılar:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri CRUD ve sorgulama işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomersController(ICustomerService customerService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döner. |
| GetById | `public async Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID’ye göre müşteri döner; yoksa 404. |
| GetActive | `public async Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döner. |
| Create | `public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Yeni müşteri oluşturur; 201 ve konum header’ı ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Mevcut müşteriyi günceller; yoksa 404, başarıda 204. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; başarıda 204. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Sonuç null ise 404 NotFound döner.
- `Update`: `ICustomerService.UpdateAsync` `KeyNotFoundException` fırlatırsa 404 döner; başarıda 204 NoContent.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile 201 ve `Location` header set edilir.
- `Delete`: Her zaman 204 NoContent döner; servis hataları üst katmana kabarcıklanabilir.
- Model state doğrulaması için özel kontrol yok; varsayılan ASP.NET Core model binding/validation davranışına dayanır.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (REST tüketicileri).
- Aşağı akış: `ICustomerService`.
- İlişkili tipler: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme/izin kontrollerine dair bir öznitelik yok; güvenlik gereksinimleri için `[Authorize]` değerlendirilmelidir.
- `Delete` ve `Create` için hata yönetimi standardize edilmemiş; servis hatalarında tutarlı HTTP durum kodları için ek yakalama/haritalama düşünülebilir.
- Listeleme uçlarında sayfalama/filtreleme parametreleri yok; büyük veri setlerinde performans ve yanıt boyutu için gerekebilir.

---
### Genel Değerlendirme
Kod, katmanlı mimari ile API’nin uygulama servisine bağımlı olduğu net bir ayrımı gösteriyor. DTO kullanımı ve servis aracılığıyla iş kurallarının delege edilmesi olumlu. Güvenlik (yetkilendirme), hata yönetiminin standardizasyonu ve listeleme operasyonlarında sayfalama eksikleri dikkat çekiyor. Hedef .NET sürümü ve altyapı/dış bağımlılıklar bu dosyadan belirlenemiyor; proje genelinde konsolide edilmesi önerilir.### Project Overview
Proje adı: Library. Amaç: Kütüphane personel yönetimi için HTTP API uç noktaları sağlamak. Hedef çatı: ASP.NET Core Web API (C#), katmanlı bir yapı üzerinden Application katmanındaki servis ve DTO’ları kullanır.

Mimari desen: N‑Tier / Clean benzeri. Presentation (API) katmanı, Application katmanındaki servis arayüzlerine (`IStaffService`) ve DTO’lara bağımlıdır. İş kuralları ve veri erişimi API katmanında bulunmaz; servisler üzerinden yürütülür.

Projeler/Assembly’ler:
- Library (API/Presentation): HTTP endpoint’leri (`Controllers`).
- Library.Application (Application): Servis arayüzleri ve DTO’lar. (Koddan görüldüğü kadarıyla)

Harici paketler/çatı:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).

Konfigürasyon gereksinimleri:
- Bu dosyadan konfigürasyon anahtarı veya connection string gereksinimi görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel yönetimi için CRUD ve filtrelenmiş listeleme endpoint’leri sunan API denetleyicisidir. Presentation/API katmanına aittir ve iş kurallarını Application katmanındaki `IStaffService` aracılığıyla yürütür.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel varlıklarına yönelik iş operasyonlarını sağlar (listeleme, getirme, oluşturma, güncelleme, silme).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffController(IStaffService staffService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli döndürür. |
| GetById | `public async Task<ActionResult<StaffDto>> GetById(Guid id)` | Id’ye göre personel döndürür; yoksa `404`. |
| GetActive | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döndürür. |
| Create | `public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; `201 Created` ve konum döndürür. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; yoksa `404`, başarılıysa `204`. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Personeli siler; başarılıysa `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretir.
- `Create`: Başarıyla oluşturulduğunda `CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff)` ile konum başlığı döndürür.
- `Update`: `KeyNotFoundException` yakalanırsa `NotFound()` döndürür; aksi halde `NoContent()`.
- `Delete`: Her zaman `NoContent()` döndürür; servis tarafındaki hata/varlık yokluğu bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (REST çağrıları).
- **Aşağı akış:** `IStaffService`.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde yetkilendirme/authorization öznitelikleri görünmüyor; güvenlik gereksinimleri varsa eklenmeli.
- `Delete` operasyonunda varlık bulunamaması durumunun açık yönetimi (ör. `404`) yok; servis tarafındaki davranışa bağımlı.

---
Genel Değerlendirme
- API katmanı Application’a düzgün şekilde bağımlı; controller iş kurallarını doğrudan içermiyor.
- Hata yönetimi kısmen tutarlı: `Update` için `KeyNotFoundException` yakalanıyor; `Delete` için benzer bir durum belirtilmemiş.
- Güvenlik açısından `[Authorize]` ve rol tabanlı kontroller görünmüyor; ihtiyaç varsa eklenmeli.
- Versiyonlama, model doğrulama filtreleri ve problem details standardizasyonu gibi çapraz kesen kaygılar bu dosyada görünmüyor; projede merkezi olarak ele alınması önerilir.### Project Overview
Bu repository, ASP.NET Core tabanlı bir Web API sunucusudur. Amaç, `Library.Application` ve `Library.Infrastructure` katmanlarını DI üzerinden bağlayarak HTTP tabanlı uç noktalar sunmaktır. Hedef çatı olarak .NET 6+ minimal hosting modeli (top-level statements) kullanıldığı anlaşılmaktadır. Mimari, uygulama kuralları ve altyapının ayrıldığı katmanlı bir yapıyı benimsiyor.

- Mimari desen: N-Tier/Clean Architecture karması
  - API/Presentation: HTTP pipeline, controller’lar, Swagger ve host yaşam döngüsü.
  - Application: İş kuralları ve use case servisleri (AddApplication ile ekleniyor).
  - Infrastructure: Kalıcı veri, dış sistemler ve konfigürasyona bağlı sağlayıcılar (AddInfrastructure ile ekleniyor).

- Projeler/Assembly’ler:
  - Library (Web API; composition root)
  - Library.Application (iş mantığı; DI ile ekleniyor)
  - Library.Infrastructure (altyapı sağlayıcıları; DI ile ekleniyor)

- Kullanılan ana framework/paketler:
  - ASP.NET Core (Controllers, Authorization, Minimal hosting)
  - Swashbuckle (Swagger) — `AddEndpointsApiExplorer`, `AddSwaggerGen`

- Konfigürasyon:
  - `AddInfrastructure(builder.Configuration)` çağrısı konfigürasyona ihtiyaç olduğunu gösteriyor; spesifik anahtarlar/connection string’ler bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  ├─> Library.Application
  └─> Library.Infrastructure

---

### `Library/Program.cs`

**1. Genel Bakış**
Uygulamanın composition root’u olarak HTTP pipeline’ı ve bağımlılık enjeksiyonunu yapılandırır. `Application` ve `Infrastructure` katmanlarını servis koleksiyonuna ekler, Swagger’ı geliştirme ortamında etkinleştirir ve controller endpoint’lerini haritalar. API/Presentation katmanına aittir.

**2. Tip Bilgisi**
- Tip: top-level statements (program entry point)
- Miras: Yok
- Uygular: Yok
- Namespace: Bu dosyadan anlaşılmıyor (global program alanı)

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
|  |  |  |

**5. Temel Davranışlar ve İş Kuralları**
- DI kaydı: `builder.Services.AddApplication()` ile uygulama servisleri eklenir.
- DI kaydı: `builder.Services.AddInfrastructure(builder.Configuration)` ile altyapı servisleri konfigürasyonla eklenir.
- HTTP: `AddControllers()` ile MVC controller’ları etkinleştirilir.
- Geliştirme ortamında Swagger: `app.UseSwagger()` ve `app.UseSwaggerUI()` etkinleştirilir.
- Güvenlik: `app.UseHttpsRedirection()` ile HTTPS yönlendirme; `app.UseAuthorization()` ile yetkilendirme middleware’i eklenir.
- Uç noktalar: `app.MapControllers()` ile controller route’ları haritalanır.
- Uygulama yaşam döngüsü: `app.Run()` ile host başlatılır.

**6. Bağlantılar**
- Yukarı akış: Host tarafından giriş noktası olarak çağrılır (ASP.NET Core).
- Aşağı akış: `Library.Application` ve `Library.Infrastructure` kayıtları; ASP.NET Core Middleware ve Swagger.
- İlişkili tipler: `AddApplication` ve `AddInfrastructure` extension method’larını barındıran servis kayıt sınıfları (bu dosyada tanımlı değil).

**7. Eksikler ve Gözlemler**
- `UseAuthentication()` middleware’i tanımlı değil; eğer yetkilendirme kullanılıyorsa kimlik doğrulama da eklenmelidir.
- `AddInfrastructure` konfigürasyon anahtarları belirsiz; gerekli ayarlar README veya appsettings’te belgelenmeli.

---

Genel Değerlendirme
- Mimari katmanlar net ayrılmış, ancak API katmanı `Infrastructure`’a doğrudan referans veriyor; katı Clean Architecture tercih ediliyorsa bu bağımlılık sadece `Application` üzerinden orkestre edilmelidir.
- Güvenlik hattı tamamlanmamış olabilir: `UseAuthorization` var, fakat `UseAuthentication` ve ilgili `AddAuthentication`/`AddAuthorization` politikaları görünmüyor.
- Konfigürasyon gereksinimleri belirsiz; `Infrastructure` için gerekli connection string ve anahtarlar dokümante edilmelidir.