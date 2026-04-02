### Project Overview
- Proje adı: Library (adlandırmadan çıkarım)
- Amaç: Kütüphane alanındaki kavramları temsil eden veri aktarım nesneleri (DTO) sağlamak; özellikle kitap kategorileriyle ilgili veriyi uygulama katmanında taşımak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N‑Katmanlı izlenimi (`.Application` ad alanı). Görünen katman: Application (use-case/DTO’lar, iş kurallarıyla etkileşen veri sözleşmeleri).
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case’ler/servisler için sözleşme/veri şekilleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Application (Library.Application)
  ↑
[Diğer katmanlar bu dosyadan anlaşılmıyor; tipik olarak API/Presentation → Application → Domain → Infrastructure akışı beklenir, ancak sadece Application katmanı görünür.]

---

### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisi verisini uygulama sınırları arasında taşımak için kullanılan basit bir veri aktarım nesnesidir. Mimari olarak Application katmanına aittir ve muhtemel sorgu/komut işleyicileri veya API controller’ları ile domain/entity modelleri arasında veri sözleşmesi görevi görür.

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
| Id | `public Guid Id { get; set; }` | Kategori için benzersiz tanımlayıcı. |
| Name | `public string Name { get; set; }` | Kategori adı; varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklaması; varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`. `Id` için varsayılan değer `default(Guid)` (ayarlanıncaya kadar boş GUID).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel karşılık gelen domain entity’si veya komut/sorgu modelleri belirtilmemiş).

---

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanında bir DTO görünüyor; diğer katmanlar (Domain, Infrastructure, API/Presentation) bu veriyle doğrulanamıyor.
- Hedef .NET sürümü, harici paket kullanımı ve konfigürasyon ayrıntıları belirsiz.
- DTO’larda validasyon anotasyonları veya sözleşme düzeyinde kısıtlar bulunmuyor; ihtiyaç halinde `Name` gibi alanlar için doğrulama stratejisi (ör. FluentValidation veya DataAnnotations) eklenmesi değerlendirilebilir.### Project Overview
- Proje adı: Library (namespace’den çıkarım)
- Amaç: Uygulama katmanında kitap verilerini taşıyan DTO’ları sağlamak; katmanlar arası veri aktarımını düzenlemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean benzeri yapı işaretleri (Application katmanı görünüyor). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama hizmetlerine veri sözleşmeleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Application)

---

### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitapla ilgili verilerin katmanlar arasında (özellikle uygulama/presentasyon) taşınması için kullanılan bir veri transfer nesnesidir. Application katmanına aittir ve iş mantığı içermez, sadece veri sözleşmesi sunar.

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
| Title | `public string Title { get; set; }` | Kitap adı. |
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcut/ödünç verilebilirlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | Kategori adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`. `IsAvailable` varsayılanı `false` (CLR default), `PublishedYear = 0`, `BookCategoryId = null`, `BookCategoryName = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanının yalnızca Application katmanındaki bir DTO görünür durumda; diğer katmanlar ve akışlar bu veriden çıkarılamıyor.
- İş kuralları, validasyon veya mapping detayları bu dosyada tanımlı değil; bu da DTO için beklenen bir durumdur.
- Hedef framework, paketler ve konfigürasyon anahtarları tespit edilemedi; daha geniş bağlam için ek dosyalar gereklidir.### Project Overview
Proje adı: Library (ad, namespace’ten çıkarılmış). Amaç: Uygulama katmanında kitap kategorisi oluşturma senaryosu için giriş veri modelini (DTO) sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Sadece `Library.Application` katmanına ait bir DTO görüldüğü için çok katmanlı/layered bir kurgu ima ediliyor; diğer katmanlar bu dosyadan anlaşılamıyor. Keşfedilen proje/assembly: Library.Application — Uygulama katmanında DTO’lar ve muhtemel iş akışları için modeller. Harici paket/çatı: bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, bir kitap kategorisi oluşturma işlemi için giriş verilerini taşıyan basit bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve genellikle üst katmanlardan (ör. API) iş mantığına veri taşımak için kullanılır.

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
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO dosyası görülebiliyor; Domain, Infrastructure veya API katmanlarına dair kanıt yok.
- Doğrulama (ör. boş isim kontrolü) DTO üzerinde değil; muhtemelen başka katmanlara bırakılmalı. Mevcut dosyada ek iş kuralı veya validasyon bulunmuyor.
- Hedef çatı, paketler ve yapılandırma anahtarları bu tek dosyadan çıkarılamıyor.### Project Overview
- Proje adı: Library (namespace’ten çıkarım)
- Amaç: Uygulama katmanında kitap oluşturma isteği için veri taşıma nesneleri (DTO) sağlamak.
- Hedef çatı (target framework): Bu dosyadan anlaşılmıyor.
- Mimari desen: Uygulama, en azından Application katmanına sahip. Bu, tipik olarak Clean Architecture veya N‑Katmanlı mimarinin Application katmanına karşılık gelir; diğer katmanlar bu dosyadan görülemiyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar içerir.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)

---

### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, bir kitabın oluşturulması sırasında gereken alanları (başlık, yazar, ISBN, yayımlanma yılı, isteğe bağlı kategori) taşımak için kullanılan basit bir veri taşıma nesnesidir. Uygulama katmanına aittir ve muhtemelen komut/handler veya controller giriş modeli olarak kullanılır.

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
| Title | `public string Title { get; set; }` | Kitap başlığı. Varsayılanı `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adı. Varsayılanı `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | ISBN değeri. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayımlanma yılı. Varsayılanı `0`. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İsteğe bağlı kategori kimliği. Varsayılanı `null`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanından yalnızca Application katmanındaki bir DTO görünüyor; diğer katmanlar (Domain, Infrastructure, API) bu girdiyle doğrulanamıyor.
- Doğrulama kuralları (ör. `Title` zorunluluğu, `PublishedYear` aralığı, `ISBN` formatı) DTO üzerinde tanımlı değil; muhtemelen üst katmanlarda veya validator’larda ele alınmalıdır.### Project Overview
- Proje adı: Library (isimlendirmeden çıkarım)
- Amaç: Kütüphane bağlamında müşteri oluşturma akışında kullanılan veri transferi; Application katmanında istemciden gelen veriyi taşıyan DTO’lar sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/bağımsız Application katmanı (Clean Architecture/N‑Tier esintisi); yalnızca Application katmanı görülebiliyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama hizmetleri/iş akışları.
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]
  └─ DTOs

---

### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, yeni bir müşteri oluşturma isteğinde gerekli temel alanları taşıyan bir veri transfer nesnesidir. Application katmanına aittir ve sunum katmanından gelen veriyi iş kurallarına/komutlarına aktarmak için kullanılır.

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
| FirstName | `string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `string Address { get; set; }` | Müşterinin adresi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: tüm string özellikler `string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Girdi doğrulaması için `DataAnnotations` (ör. `Required`, `EmailAddress`, `MaxLength`) kullanılmamış; minimum alan doğrulaması görünmüyor.

---

### Genel Değerlendirme
Kod tabanı görünürlüğü yalnızca Application katmanındaki bir DTO ile sınırlı. Mimari, isimlendirme itibarıyla katmanlı bir yapıya işaret etse de diğer katmanlar bu girdiyle doğrulanamıyor. DTO üzerinde alan doğrulama öznitelikleri bulunmaması, validasyonun başka bir katmanda/ara katmanda yapıldığına işaret edebilir; aksi halde eksik validasyon riski vardır. Harici paketler, konfigürasyon anahtarları ve hedef framework versiyonu bu dosyadan tespit edilemiyor.### Project Overview
Proje adı: Library (uygulama katmanı: Library.Application). Amaç: Personel oluşturma verilerini taşımak için bir DTO sunar; büyük olasılıkla uygulama katmanında komut/sorgu işleyicileri veya API uç noktaları tarafından kullanılır. Hedef framework bu dosyadan anlaşılmıyor.

Mimari: Katmanlı/Clean Architecture eğilimli yapı izlenimi var. Application katmanı içinde DTO’lar tanımlanmış; domain veya infrastructure katmanları bu dosyadan görünmüyor. Application katmanı, dış katmanlar (API/Presentation) ile domain/infrastructure arasında sözleşme/taşıyıcı tipler sağlar.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar (ve muhtemelen komut/sorgu/servisler) barındırır.

Dış bağımlılıklar: Bu dosyadan görülmüyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] → [Library.Application (DTOs)]
(Not: Sadece Application katmanı gözlemlendi; diğer katmanlar bu depodan görünmüyor.)

---

### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, yeni bir personel oluşturma isteğinde gerekli alanları taşımak için kullanılan basit bir veri taşıyıcıdır. Uygulama katmanına aittir ve giriş verilerini API veya uygulama hizmetlerinden domain/infrastructure katmanlarına iletmek için kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | İletişim e-postası. |
| Phone | `public string Phone { get; set; }` | İletişim telefonu. |
| Position | `public string Position { get; set; }` | Pozisyon/ünvan bilgisi. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe alınma tarihi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`. `HireDate` için .NET varsayılanı (`default(DateTime)`) geçerli.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Bağımlılığı yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında sadece Application katmanına ait bir DTO görülebiliyor; diğer katmanlar veya akışlar görünmediğinden mimari bütünlük doğrulanamıyor.
- Doğrulama öznitelikleri (`[Required]`, `[EmailAddress]` vb.) veya minimal validation işaretleri bulunmuyor; API yüzeyinde model doğrulaması hedefleniyorsa eklenmesi düşünülebilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanına yönelik uygulama katmanında veri taşıma nesneleri (DTO) sağlamak; özellikle müşteri verilerinin katmanlar arasında taşınması.
- Hedef çerçeve: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli yapı (Application katmanı mevcut). Diğer katmanların varlığı bu dosyadan kesinleşmiyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO tanımları içerir.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  [Diğer katmanlar bu dosyadan anlaşılmıyor]

---

### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri bilgilerini katmanlar arasında taşımak için kullanılan düz veri taşıma nesnesidir. Uygulama katmanına aittir ve API, uygulama servisleri veya mapping katmanları arasında veri şekillendirmeyi kolaylaştırır.

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
| Id | `public Guid Id { get; set; }` | Müşterinin benzersiz tanımlayıcısı. |
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adres bilgisi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Müşterinin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`. `RegisteredDate` ve `IsActive` varsayılan CLR değerleri alır.

**6. Bağlantılar**
- **Yukarı akış:** API controller’lar veya uygulama servisleri tarafından kullanılabilir (bu dosyadan kesinleşmiyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Potansiyel eşleşik domain entity’si: `Customer` (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO gözüküyor; mimarinin geri kalanı (Domain, Infrastructure, API) bu dosyadan doğrulanamıyor.
- Doğrulama, mapping profilleri ve kullanım bağlamı görünmüyor; muhtemelen ayrı katmanlarda tanımlanmıştır.### Project Overview
Proje adı: Library  
Amaç: Kütüphane alanındaki personel bilgilerini temsil eden uygulama katmanı DTO’larını sağlamak.  
Hedef framework: Bu dosyadan anlaşılmıyor.  
Mimari yaklaşım: Katmanlı/Clean Architecture eğilimi. Görünen “Application” katmanında yalnızca DTO tanımı mevcut; domain, infrastructure veya API katmanları bu girdiyle doğrulanamıyor.  
Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; dışa/üste aktarım için DTO’lar içerir.

Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.  
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)
  ↑
  (Diğer katmanlar/çağırıcılar — bu dosyadan anlaşılmıyor)

---

### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**  
`StaffDto`, personel bilgilerini (ad, soyad, e-posta, telefon, pozisyon, işe giriş tarihi, aktiflik) taşımak için kullanılan basit bir veri transfer nesnesidir. Uygulama katmanına aittir ve genellikle API veya uygulama servisleri ile üst katmanlar arasında veri taşımak için kullanılır.

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
| Id | `public Guid Id { get; set; }` | Personel benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe giriş tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**  
DTO — davranış yok. Default değerler:  
- `FirstName = string.Empty`  
- `LastName = string.Empty`  
- `Email = string.Empty`  
- `Phone = string.Empty`  
- `Position = string.Empty`  
- `HireDate` ve `IsActive` için default atama yok (CLR varsayılanları geçerli).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (muhtemelen uygulama servisleri/handler’lar ve API katmanı).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanına dair yalnızca bir DTO görülebiliyor; mimari katmanların tamamı, hedef framework, konfigürasyon ve paket bağımlılıkları bu girdiden çıkarılamıyor. DTO sade ve amacına uygun; ancak doğrulama/biçimlendirme kuralları uygulama veya API katmanında ele alınmalı. Tüm mimariyi değerlendirebilmek için en azından domain modelleri, uygulama servisleri/handler’lar ve API uç noktaları incelenmelidir.### Project Overview
- Proje adı: Library (isimlendirme `Library.Application` namespace’inden çıkarılmıştır)
- Amaç: Uygulama katmanında kitap kategorilerinin güncellenmesi senaryosunda kullanılacak veri transferini temsil eden DTO’ları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/N-Tier izlenimi; bu dosya Application katmanında yer alan bir DTO’dur. Katman rolleri:
  - Application: Use case/iş akışı mantığı, DTO’lar, arayüzler.
  - Domain/Infrastructure/API: Bu dosyadan anlaşılmıyor (gözlemlenmedi).
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, DTO ve muhtemel use case bileşenleri.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisinin güncellenmesi sırasında istemciden alınan verileri temsil eden bir DTO’dur. Uygulama (Application) katmanına aittir ve genellikle komut/handler veya controller ile domain model arasında veri taşıma amacıyla kullanılır.

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
| Name | `public string Name { get; set; }` | Kategori adının yeni değeri. |
| Description | `public string Description { get; set; }` | Kategori açıklamasının yeni değeri. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
- Sadece Application katmanında bir DTO görülebiliyor; diğer katmanlar ve akışlar bu veriden anlaşılamıyor.
- Validasyon, mapping veya iş kuralı içermiyor; bu sorumlulukların muhtemelen handler/service veya validation katmanında ele alınması beklenir.### Project Overview
- Proje adı: Library
- Amaç: Uygulama katmanında kitap güncelleme işlemleri için veri taşıma nesnesi (DTO) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture göstergesi (Application katmanı mevcut). Application katmanı, domain/iş mantığını yöneten use-case’lere yönelik DTO’ları içerir.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case iş akışları.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
`UpdateBookDto`, bir kitabın güncellenmesi için gerekli alanları taşıyan veri transfer nesnesidir. Uygulama (Application) katmanında, komut/handler veya servislerin giriş modeli olarak kullanılması amaçlanır.

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
| Title | `string Title { get; set; }` | Kitabın başlığı. |
| Author | `string Author { get; set; }` | Yazar adı. |
| ISBN | `string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `bool IsAvailable { get; set; }` | Mevcut olup olmadığı. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | İsteğe bağlı kategori kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `IsAvailable = false`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (muhtemelen komut/handler veya servisler tarafından kullanılır).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel `Book` entity’si, kategori ile ilişkili tipler).

---

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanından bir DTO görünüyor. Bu nedenle hedef framework, domain/infrastructure katmanları, persistence ve dış bağımlılıklar hakkında çıkarım yapılamıyor. Doğrulama kuralları, mapping profilleri (ör. AutoMapper), komut/sorgu işleyicileri veya controller katmanı görünmüyor; bu alanlarda standartların ve sözleşmelerin belirlendiğinden emin olunması önerilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım). Amaç: müşteri güncelleme işlemlerinde kullanılacak uygulama katmanı DTO’larını sağlamak. Hedef framework: bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture izlenimi (Application katmanı ve DTO isimlendirmesi). Görülebilen katman: Application. Diğer katmanlar (Domain, Infrastructure, API/Presentation) bu dosyadan doğrulanmıyor.
- Projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; komut/sorgu iş akışları için DTO’lar içerir.
- Harici paketler/çerçeveler: Bu dosyada görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyada görünmüyor.

### Architecture Diagram
[Library.Application]
  └─ DTOs

---
### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
Müşteri güncelleme operasyonu için gerekli alanları taşıyan bir DTO’dur. Uygulama katmanında veri taşıma amacıyla kullanılır; doğrulama veya iş kuralı içermez.

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
| Email | `public string Email { get; set; }` | Müşterinin e‑posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adresi. |
| IsActive | `public bool IsActive { get; set; }` | Müşterinin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `IsActive = false` (bool varsayılan).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görünmekte; diğer katmanlar ve akışlar bu dosyadan çıkarılamıyor.
- Doğrulama, eşleme (mapping) ve iş kuralları katmanlarının konumu ve kullanımı belirsiz.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları görünmüyor; çözüm seviyesinde ek dosyalarla tamamlanması önerilir.### Project Overview
Proje adı “Library” olarak görünüyor. Bu depo parçası, uygulama katmanında personel güncelleme işlemleri için bir DTO tanımı içerir. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen, `Library.Application` ad alanı ve `DTOs` klasöründen katmanlı (N-Tier) bir yaklaşımı işaret eder; bu dosya Application katmanındaki sözleşme/taşıyıcı tiplerdendir.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanına ait DTO’ları ve muhtemel kullanım sözleşmelerini barındırır.

Kullanılan dış paketler: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)
  └─ Diğer katman/bağımlılıklar: bu dosyadan anlaşılmıyor

---
### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel (`Staff`) bilgilerinin güncellenmesi sırasında kullanılan veri taşıyıcıdır. Uygulama (Application) katmanında, komut/sorgu işleyicileri ile sunum/transport katmanı arasında veri sözleşmesi görevi görür.

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
| FirstName | `string FirstName { get; set; }` | Personelin adı. |
| LastName | `string LastName { get; set; }` | Personelin soyadı. |
| Email | `string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| IsActive | `bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = false` (bool için CLR varsayılanı).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Validation öznitelikleri (`[Required]`, `[EmailAddress]` vb.) bulunmuyor; giriş doğrulaması başka bir katmana bırakılmış olabilir.
- Tüm `string` alanların `string.Empty` ile başlatılması, “alan gönderilmedi” ile “boş değer gönderildi” ayrımını zorlaştırabilir; kısmi güncellemelerde belirsizlik yaratabilir.
- Nullability/nullable referans tipleri etkin değil; niyet (zorunlu/opsiyonel) belirsiz.

---
### Genel Değerlendirme
Kod tabanı yalnızca bir Application DTO’su içeriyor. Mimari ve bağımlılık akışı hakkında kapsamlı çıkarım yapmak mümkün değil. DTO seviyesinde alan doğrulaması ve nullability açıklığı eksik; kısmi güncelleme senaryoları için opsiyonel alan modellemesi (nullable referanslar veya ayrı patch modelleri) değerlendirilebilir. Ayrıca, sözleşme tutarlılığı için isimlendirme/alan kapsamı netleştirilmeli ve validasyon stratejisi (fluent validation veya data annotations) belirlenmelidir.### Project Overview
Proje adı: Library. Amaç: Uygulamanın “Application” katmanında yer alan servislerin IoC/DI kaydını merkezileştirmek. Hedef framework bu dosyadan anlaşılmıyor; ancak `Microsoft.Extensions.DependencyInjection` kullanımı .NET Core/5+ ekosistemini işaret eder.

Mimari desen: Katmanlı (N-Tier / Clean Architecture’a uygun). Bu katman, uygulama servislerini (business use-case mantığı) barındırır ve DI üzerinden üst katmanlara sunar. Domain ve Infrastructure katmanları bu dosyadan görülmüyor.

Projeler/Assembly’ler:
- Library.Application — Uygulama servisleri ve bunların DI kaydı.

Harici paketler/çatı:
- `Microsoft.Extensions.DependencyInjection` — DI kabiliyeti.

Konfigürasyon gereksinimleri:
- Bu dosyada konfigürasyon anahtarı veya connection string gereksinimi görünmüyor.

### Architecture Diagram
[Consumer (API/UI/Worker)] -> Library.Application

---

### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Application katmanındaki servislerin DI konteynerine kayıt edilmesini sağlayan bir uzantı metodu sunar. Amaç, IoC yapılandırmasını tek bir noktadan yapıp üst katmanların basit bir çağrıyla Application servislerini ekleyebilmesini sağlamaktır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application`

**3. Bağımlılıklar**
- Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Application servislerini `Scoped` yaşam süresiyle DI konteynerine ekler ve zincir çağrılar için `IServiceCollection` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `IBookService` -> `BookService`, `IBookCategoryService` -> `BookCategoryService`, `IStaffService` -> `StaffService`, `ICustomerService` -> `CustomerService` `Scoped` olarak eklenir.
- Kayıtlar Application katmanı servislerinin dışarıdan DI ile çözülmesini sağlar.
- Yaşam süresi tercihi: Web istek başına tek örnek (Scoped). Farklı yaşam süreleri bu dosyada tanımlı değil.

**Mantık içermeyen basit DTO/model'ler için** bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak kompozisyon kökünde (ör. `Program`/`Startup`) `services.AddApplication()` çağrılır.
- **Aşağı akış:** `IBookService`, `IBookCategoryService`, `IStaffService`, `ICustomerService` arayüzleri ve karşılık gelen implementasyon sınıfları (`BookService`, `BookCategoryService`, `StaffService`, `CustomerService`).
- **İlişkili tipler:** `Library.Application.Interfaces.*`, `Library.Application.Services.*` (bu dosyada sadece adları referanslanıyor).

**7. Eksikler ve Gözlemler**
- Yalnızca Application servisleri kaydediliyor; validasyon, pipeline davranışları (ör. MediatR, FluentValidation) veya cross-cutting kayıtlar bu dosyada mevcut değil ya da görünmüyor. Bu, projede yok anlamına gelmez; sadece bu dosyadan tespit edilemiyor.

---

### Genel Değerlendirme
Kod tabanı görünürlüğü Library.Application katmanıyla sınırlı ve yalnızca DI kayıtlarına odaklı. Mimari olarak katmanlı bir yapı ima ediliyor; ancak Domain, Infrastructure veya API projeleri bu girdiyle doğrulanamıyor. DI kayıtlarında `Scoped` yaşam süresi tutarlı. Genişletilebilirlik açısından ek servisler için tek noktadan kayıt iyi bir uygulama. Cross-cutting concern’lerin (ör. logging, validation, caching, pipeline) entegrasyonu bu dosyadan anlaşılmıyor; ilgili kayıtlar varsa diğer katman/dosyalarda olmalıdır.### Project Overview
- Proje adı: Library (çıkarım: `Library.Application` ad alanı)
- Amaç: Uygulamanın e-posta gönderimiyle ilgili yapılandırma ayarlarını temsil eden uygulama katmanı tipi sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (uygulama katmanı mevcut). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama mantığı ve yapılandırma sözleşmeleri (ör. `EmailSettings`)
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: E-posta için `Host`, `Port`, `Username`, `Password`, `From`, `NotificationTo`, `EnableSsl` ayarları (anahtar adları uygulama konfigürasyon eşlemesine göre belirlenir; bu dosyadan kesin adlar anlaşılmıyor).

### Architecture Diagram
Library.Application

---

### `Library.Application/Email/EmailSettings.cs`

**1. Genel Bakış**
`EmailSettings`, e-posta gönderimi için gerekli sunucu ve kimlik bilgisi ayarlarını taşıyan bir konfigürasyon DTO’sudur. Uygulama katmanına aittir ve genellikle yapılandırmadan (ör. appsettings) bağlanarak e-posta altyapısına iletilir.

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
| Username | `public string Username { get; set; }` | SMTP kullanıcı adı. |
| Password | `public string Password { get; set; }` | SMTP parolası. |
| From | `public string From { get; set; }` | Gönderen e-posta adresi. |
| NotificationTo | `public string NotificationTo { get; set; }` | Bildirimlerin gideceği e-posta adresi. |
| EnableSsl | `public bool EnableSsl { get; set; }` | SSL kullanım bayrağı (varsayılan true). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Host = string.Empty`, `Port = 587`, `Username = string.Empty`, `Password = string.Empty`, `From = string.Empty`, `NotificationTo = string.Empty`, `EnableSsl = true`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir veya konfigürasyondan bağlanır.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanında yalnızca uygulama katmanında bir konfigürasyon DTO’su görülüyor. E-posta gönderim servisi, konfigürasyon bağlama (IOptions) veya altyapı implementasyonları bu dosyadan anlaşılmıyor. Hedef framework, dış paketler ve diğer katman/projeler hakkında çıkarım yapmak için ek dosyalara ihtiyaç var.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanında “kitap kategorisi” yönetimi için uygulama katmanında servis sözleşmeleri tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture benzeri. Bu dosya Application katmanında bir servis sözleşmesi (port) tanımlar. Uygulama katmanı, domain kurallarını ve use-case’leri barındıran sözleşmeleri sağlar; altyapı (Infrastructure) bunları uygular; sunum (API/Presentation) bu sözleşmeleri kullanır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis arayüzleri ve DTO referansları içerir.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API -> Application (Library.Application)

---

### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorileri için CRUD operasyonlarını tanımlayan uygulama katmanı servis arayüzüdür. Sunum katmanı bu arayüzü kullanarak kategori verileriyle çalışır; gerçek implementasyon genellikle Infrastructure katmanında sağlanır.

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
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kategori DTO’sunu döner; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori DTO’larını döner. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni bir kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Belirtilen kategoriyi verilen bilgilerle günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`’deki kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Bu dosya yalnızca sözleşme sağlar; validasyon, hata yönetimi ve transaction davranışı implementasyona bırakılmıştır.
- `GetByIdAsync` için bulunamama durumunda `null` dönme semantiği sözleşmede belirtilmiştir.

**Mantık içermeyen basit DTO/model'ler için**
> DTO — davranış yok. `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto` detayları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API controller’ları veya uygulama hizmetleri tarafından çağrılır.
- **Aşağı akış:** Bu arayüzün implementasyonu muhtemelen repository/DB erişimi gibi altyapı bileşenlerine bağımlı olacaktır (bu dosyadan anlaşılmıyor).
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

Genel Değerlendirme
- Sadece Application katmanı arayüzü mevcut; implementasyon, DTO tanımları, domain modelleri ve sunum katmanı görülmüyor.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları bu dosyadan çıkarılamıyor.
- Sözleşme anlamlı ve minimal; null-dönüş semantiği (`GetByIdAsync`) belirgin. Implementasyonlarda validasyon, hata yönetimi ve idempotency gibi konuların netleştirilmesi önerilir.### Project Overview
Proje adı: Library.Application. Amaç: Bir kütüphane yönetim senaryosunda kitaplara yönelik uygulama hizmet sözleşmelerini tanımlamak (CRUD ve listeleme operasyonları). Hedef framework bu dosyadan anlaşılmıyor.
Mimari: Katmanlı/Clean Architecture eğilimli. Bu katman, domain ve altyapıdan bağımsız sözleşmeler ve DTO’larla Application katmanını temsil eder.
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; servis interface’leri ve DTO’ları içerir.
Harici paketler: Bu dosyadan anlaşılmıyor.
Konfigürasyon: Bu dosyadan anlaşılmıyor (bağlantı string’i veya app settings anahtarı görünmüyor).

### Architecture Diagram
Library.Application

---

### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitap nesnelerine ilişkin uygulama seviyesi operasyonların sözleşmesini tanımlar: tekil sorgu, listeleme, uygun/ödünç verilebilir kitapların sorgulanması, oluşturma, güncelleme ve silme. Application katmanına aittir ve controller’lar veya diğer uygulama bileşenleri için bağımlılık noktası sağlar.

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
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kitabı getirir; bulunamazsa `null` dönebilir. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları listeler. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/ödünç verilebilir durumdaki kitapları listeler. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni bir kitabı oluşturur ve oluşturulan kaydı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Belirtilen kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme düzeyinde davranış tanımı yok; iş kuralları implementasyon sınıflarında belirlenir.
- `GetByIdAsync` dönüş tipi `BookDto?` olduğundan, bulunamayan kayıt senaryosunu sözleşme düzeyinde ifade eder.
- Asenkron desen `Task` tabanlıdır; iptal desteği (`CancellationToken`) tanımlı değildir.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Bu dosyadan anlaşılmıyor.
- İlişkili tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto` (`Library.Application.DTOs` içinde beklenir).

**7. Eksikler ve Gözlemler**
- Asenkron metodlarda `CancellationToken` parametresi bulunmuyor; uzun süren işlemler için iptal desteği eklenmesi faydalı olabilir.
- Hata yönetimi sözleşmede tanımlı değil; bulunamayan/güncellenemeyen/silinmeyen kaynaklar için beklenen exception veya sonuç modeli netleştirilebilir.

---

Genel Değerlendirme
- Kod tabanında yalnızca bir uygulama katmanı interface’i görünüyor; implementasyon sınıfları, DTO tanımları ve diğer katmanlar (Domain/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Sözleşme net ve minimal; ancak iptal belirteci ve tutarlı hata modeli (nullable dönüş vs. exception) konularında rehberlik eksik.
- Clean Architecture yaklaşımına uygun olarak bağımlılık yönü korunuyor; yine de katmanlar arası sınırlar ve bağımlılıklar tam olarak değerlendirilemedi.### Project Overview
- Proje Adı: Library
- Amaç: Uygulama katmanında müşteri yönetimi için kontratlar (servis arayüzleri) ve DTO’lar üzerinden uygulama mantığını soyutlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı mimari (N-Tier/Clean benzeri). Application katmanı, domain iş kurallarını ve veri erişimini soyutlayan servis kontratlarını ve DTO’ları barındırır; üst katmanlar (ör. API) bu katmanı tüketir.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; servis arayüzleri ve DTO’lar.
- Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] --> Library.Application

---

### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri verileri üzerinde okuma (tekil/tüm/aktifler), oluşturma, güncelleme ve silme işlemleri için uygulama katmanında bir servis sözleşmesi tanımlar. Amaç, üst katmanların (örn. API) müşteri işlemlerini uygulama mantığına bağlı ama altyapıdan bağımsız şekilde çağırabilmesini sağlamaktır. Bu tip Application katmanına aittir.

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
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Verilen `id` için müşteriyi döner; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri döner. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri döner. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Verilen `id`’li müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’li müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Bu dosyadan anlaşılmıyor; arayüz yalnızca sözleşme tanımlar. DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `Library.Application.DTOs` tiplerine (örn. `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`) tür bağımlılığı.
- İlişkili tipler: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- Metot imzalarında `CancellationToken` desteği yok; ölçeklenebilirlik ve iptal desteği için eklenmesi faydalı olabilir.
- Listeleme operasyonlarında sayfalama/filtreleme parametreleri tanımlı değil; geniş veri setlerinde performans/IO maliyeti artabilir.

---

### Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir servis arayüzünü içeriyor. Katmanlı yapı sinyalleri mevcut olsa da diğer katmanlar (Domain, Infrastructure, API) ve hedef framework belirsiz. Sözleşmeler net; ancak iptal belirteci ve sayfalama gibi üretim senaryolarında yaygın yetenekler arayüz seviyesinde tanımlı değil. DTO paketinin varlığı, altyapıdan bağımsız aktarım amacını destekliyor. Implementasyonlar, validasyon ve hata yönetimi bu dosyadan görülemiyor.### Project Overview
- Proje adı: Library (koddan görülen ad alanlarına göre)
- Amaç: Uygulama katmanında e‑posta gönderimi için altyapıdan bağımsız bir sözleşme (`IEmailService`) tanımlamak.
- Hedef çatı/TFM: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean‑Architecture eğilimli yapı; Application katmanı altyapı bağımlılıklarını arayüzlerle ters çevirir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; arayüz/sözleşme tanımları.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
(Keşfedilen tek katman: Application)

Library.Application (Interfaces)
  └─ Arayüz tanımlarını içerir; uygulamaları muhtemelen Infrastructure’da yapılır

---

### `Library.Application/Interfaces/IEmailService.cs`

**1. Genel Bakış**
`IEmailService`, e‑posta gönderimini soyutlayan bir arayüzdür. Application katmanında tanımlanarak e‑posta sağlayıcılarına olan bağımlılıkları ters çevirir ve altyapı detaylarını uygulamadan izole eder.

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
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | Belirtilen alıcıya konu ve içerikle asenkron e‑posta gönderimi; HTML içerik seçeneği ve iptal desteği içerir. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış yok. Parametreler: `isHtml` varsayılan `true`; `cancellationToken` varsayılan `default`.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; çağırıcılar bu arayüzü kullanır.
- **Aşağı akış:** Uygulaması tipik olarak altyapıdaki e‑posta sağlayıcısına bağlanır (bu dosyadan uygulama görünmüyor).
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
- Kod tabanında sadece Application katmanında bir arayüz görülebiliyor; diğer katmanlar (Domain/Infrastructure/API) bu dosyadan tespit edilemiyor.
- Mimari olarak bağımlılıkların ters çevrildiği izlenimi var; ancak uygulama sınıfları ve konfigürasyon ayrıntıları görünmediğinden bütünlük doğrulanamıyor.### Project Overview
Proje adı: Library (namespace’lerden çıkarım). Amaç: Personel (staff) yönetimine yönelik uygulama katmanı sözleşmeleri ve DTO’lar üzerinden CRUD benzeri operasyonları tanımlamak. Hedef çatı/TFM: Bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture’a işaret eden “Application” katmanı mevcut; iş kuralları ve kullanım senaryolarına ait servis sözleşmeleri burada tanımlanmış görünüyor. Keşfedilen projeler/assembly’ler: 
- Library.Application — Uygulama katmanı; servis arayüzleri ve DTO’lar.

Harici paketler: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)

---
### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (staff) varlıklarına ilişkin temel CRUD ve sorgulama operasyonlarının uygulama katmanındaki sözleşmesini tanımlar. Amaç, üst katmanların (ör. API veya Use Case orchestrator’ları) personel yönetimi için uygulama servislerine arayüz üzerinden erişmesini sağlamaktır. Mimari olarak Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygılar:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Verilen `id` için personel kaydını döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını listeler. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif durumdaki personelleri listeler. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşturulan kaydı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Belirtilen `id`’li personel kaydını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`’li personel kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış bu arayüzde tanımlı değil. İş kuralları, validasyonlar, hata yönetimi ve filtreleme detayları implementasyonda belirlenecektir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; üst katman tüketicileri bu arayüzü kullanır.
- **Aşağı akış:** Harici bağımlılık yok (arayüz seviyesinde).
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Tüm async imzalarında `CancellationToken` bulunmuyor; uzun süren işlemler ve iptal senaryoları için eklenmesi faydalı olabilir.
- `GetAllAsync` için potansiyel sayfalama/sıralama parametreleri tanımlı değil; büyük veri setlerinde performans sorunu doğurabilir.

---
Genel Değerlendirme
- Mimari izler Application katmanına işaret ediyor; diğer katmanlar (Domain, Infrastructure, API) bu depoda/dosyada görünmüyor.
- Arayüz odaklı tasarım uygun; ancak iptal belirteçleri ve sayfalama gibi sözleşme düzeyinde genellikle beklenen parametreler eksik.
- Dönüş tiplerinde `UpdateAsync`/`DeleteAsync` için sonuç bilgisi (ör. etkilenen kayıt sayısı, bulunamadı bilgisi) veya domain-odaklı sonuç tipi düşünülerek sözleşme zenginleştirilebilir.### Project Overview
- Proje adı: Library (koddan çıkarılan namespace’lere göre)
- Amaç: Kütüphane alanındaki `Category` varlıkları için DTO <-> Entity dönüşümlerini sağlamak (özellikle kitap kategorileri).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture (gözlenen katmanlar: Application ve Domain). Application katmanı DTO’lar ve mapping’leri tutar, Domain katmanı entity’leri içerir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve mapping uzantıları.
  - Library.Domain — Domain katmanı; entity tanımları (ör. `BookCategory`).
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/UI (gözlemlenmedi)
  ↓
Library.Application (DTO’lar, mapping uzantıları)
  ↓
Library.Domain (entity’ler)

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` entity’si ile ilgili DTO’lar (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`) arasında dönüşüm yapan extension method’lar sağlar. Clean Architecture’ın Application katmanında, veri aktarımını ve model dönüşümlerini kolaylaştırmak için yer alır.

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
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` entity’sini `BookCategoryDto`’ya dönüştürür. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`’dan yeni bir `BookCategory` entity’si oluşturur ve `Id`’yi `Guid.NewGuid()` ile üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Var olan `BookCategory` entity’sinin ad ve açıklamasını `UpdateBookCategoryDto` değerleriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` yeni bir `Guid` üretir; ID ataması mapping içinde yapılır.
- Alan eşlemeleri birebir: `Name` ve `Description` DTO ↔ Entity.
- Validasyon veya null kontrolü yok; `null` referanslar çağrıldığında `NullReferenceException` oluşabilir.

**Mantık içermeyen basit DTO/model'ler için**
> DTO — davranış yok. Default değerler: bu dosyadan anlaşılmıyor (DTO tanımları burada yer almıyor).

**6. Bağlantılar**
- **Yukarı akış:** DTO-Entity dönüşümüne ihtiyaç duyan Application katmanı bileşenleri (çağıranlar bu dosyadan anlaşılmıyor).
- **Aşağı akış:** `Library.Domain.Entities.BookCategory`, `Library.Application.DTOs.*`.
- **İlişkili tipler:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- `category` veya `dto` için null kontrolü yok; çağrım tarafında güvenli kullanım gerektirir.
- ID üretiminin mapping içinde yapılması bazı mimarilerde domain tarafına taşınmalıdır (tutarlılık açısından değerlendirilmeli). 

### Genel Değerlendirme
Kod, Application katmanında sade bir mapping uzantısı sunuyor ve Domain entity’lerine doğrudan bağımlı. Clean Architecture izlenimi tutarlı; ancak validasyon ve null güvenliği eksik. Hedef framework, konfigürasyon ve dış bağımlılıklar bu örnekten belirlenemiyor. ID üretim sorumluluğunun yeri mimari karara göre netleştirilmeli.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanındaki kitap varlıklarını DTO’lara dönüştürmek, create/update taleplerini domain entity’lerine map etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli. Katmanlar:
  - Domain: `Library.Domain` — Temel entity’ler (ör. `Book`) ve ilişkilendirmeler.
  - Application: `Library.Application` — DTO’lar ve mapping/uygulama mantığı (bu dosyada sadece mapping).
  - Diğer katmanlar (Infrastructure, API/Presentation): Bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain entity’leri.
  - Library.Application — DTO’lar ve mapping yardımcıları.
- Dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` domain entity’si ile `BookDto`, `CreateBookDto`, `UpdateBookDto` arasında iki yönlü map işlemlerini sağlayan extension method’lar içerir. Application katmanına aittir ve sunum/servis katmanının domain ile veri alışverişini basitleştirir.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs.*` — DTO tipleri için mapping hedef/kaynakları.
- `Library.Domain.Entities.Book` — Domain entity’si.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` entity’sini `BookDto`’ya map eder; kategori adını `BookCategory?.Name` üzerinden taşır. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto`’dan yeni `Book` entity’si oluşturur; `Id` için `Guid.NewGuid()` üretir ve `IsAvailable`’ı `true` yapar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan `Book` entity’sini `UpdateBookDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — Entity mapping kuralları:
  - `ToDto`: `BookCategoryName`, `BookCategory?.Name` ile null-safe okunur.
  - `ToEntity`: `Id` otomatik `Guid.NewGuid()` ile üretilir; `IsAvailable` varsayılan olarak `true` atanır.
  - `UpdateEntity`: Kimlik (`Id`) değiştirilmez; temel alanlar ve `BookCategoryId` güncellenir.
- Validasyon/exception mantığı bu dosyada yok; parametre null kontrolleri yapılmıyor.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.
- İlişkili tipler: `Book`, `BookCategory` (entity üzerinden dolaylı), `BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- `ToEntity` ve `UpdateEntity` içinde null parametre kontrolü yok; null girilmesi `NullReferenceException` riski oluşturabilir.
- `ToDto` içinde `book` için null kontrolü yok; null’da hata oluşur.

---

Genel Değerlendirme
- Kod, katmanlı/Clean Architecture yaklaşımına uygun mapping’ler sunuyor; `Application` katmanı `Domain`’a bağımlı.
- Null güvenliği ve temel validasyon eksik; extension method’lar parametre null durumda korumalı değil.
- Hedef framework, dış paketler ve diğer katmanlar (Infrastructure, API) bu dosyadan çıkarılamıyor; proje genel mimarisini doğrulamak için ek dosyalar gerekli.### Project Overview
Proje adı: Library. Amaç: kütüphane müşteri verilerini temsil eden entity ve DTO’lar arasında dönüşüm sağlamak (uygulama katmanında mapping). Hedef framework bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı mimari (en azından Domain ve Application katmanları). Application katmanı, Domain entity’leri ile dış dünyaya sunulan DTO’lar arasında dönüşümler yapar. Domain katmanı temel iş nesnelerini içerir.  
Keşfedilen projeler/assembly’ler:
- Library.Application — DTO’lar ve mapping yardımcıları; uygulama akışındaki veri dönüşümlerini barındırır.
- Library.Domain — Temel entity’ler (ör. `Customer`).  
Kullanılan dış paketler: Bu dosyadan anlaşılmıyor (görünür harici paket yok).  
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**  
`Customer` entity’si ile `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` arasında dönüşüm sağlayan extension method’ları içerir. Uygulama (Application) katmanında, komut/sorgu akışlarında ve controller seviyesinde veri alışverişini kolaylaştırmak için kullanılır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
- `Library.Application.DTOs` — DTO tipleri (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`)
- `Library.Domain.Entities` — Domain entity’si (`Customer`)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` entity’sini `CustomerDto`’ya dönüştürür. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`’dan yeni bir `Customer` entity’si oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` üzerinde `UpdateCustomerDto` değerlerine göre alanları günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde `Id` için `Guid.NewGuid()` üretilir.
- `MembershipNumber` için `Guid.NewGuid().ToString("N")[..10].ToUpper()` ile 10 karakterlik büyük harfli bir değer üretilir.
- `RegisteredDate` UTC olarak `DateTime.UtcNow` ile atanır.
- `IsActive` oluşturma sırasında varsayılan olarak `true` set edilir.
- `UpdateEntity` yalnızca temel alanları ve `IsActive` durumunu günceller; `MembershipNumber`, `RegisteredDate` ve `Id` değişmez.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genellikle Application hizmetleri/handler’lar veya API katmanı çağırır).
- **Aşağı akış:** `Customer` entity’si (Domain), `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` (Application DTO’ları).
- **İlişkili tipler:** `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- `CreateCustomerDto` ve `UpdateCustomerDto` alanları için null/boş kontrolü veya normalizasyon yok; geçersiz veri mapping aşamasında engellenmiyor.
- `MembershipNumber` rastgele üretiliyor; benzersizlik garantisi/çakışma kontrolü yok.

---
Genel Değerlendirme
- Mimari olarak Application ve Domain katmanları net ayrılmış; mapping’ler extension method olarak düzenli.
- Validasyon ve benzersizlik gibi iş kuralları mapping içinde ele alınmıyor; bu kuralların nerede uygulandığı belirsiz. Uygulamada ayrı bir validasyon katmanı veya pipeline kullanılması önerilir.
- Hedef framework ve dış bağımlılıklar bu dosyadan çıkarılamıyor; çözüm genelinde paket yönetimi ve konfigürasyonun belgelenmesi faydalı olacaktır.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane personel (“Staff”) verilerini DTO’lar ile domain entity’leri arasında dönüştürmek; uygulama katmanında mapping işlevleri sağlamak.
- Hedef framework: .NET (spesifik sürüm bu dosyadan anlaşılmıyor).
- Mimari desen: Katmanlı mimari/Clean Architecture eğilimli. Domain katmanı: `Library.Domain` (entity’ler). Application katmanı: `Library.Application` (DTO’lar, mapping).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Entity tanımları (`Staff`).
  - Library.Application — DTO’lar ve mapping uzantıları (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `StaffMappings`).
- Harici paketler/çatı teknolojiler: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Application -> Library.Domain

---

### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` entity’si ile `StaffDto`/`CreateStaffDto`/`UpdateStaffDto` arasında iki yönlü dönüşüm sağlayan extension metodlarını içerir. Application katmanında yer alır ve veri aktarımı ile komut/sorgu işleyicilerinde kullanılacak sade mapping mantığını sağlar.

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
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` entity’sini `StaffDto`’ya dönüştürür. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni bir `Staff` entity’si oluşturur ve `Id` üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Mevcut `Staff` entity’sini `UpdateStaffDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` yeni `Guid` ile `Id` atar ve `IsActive = true` set eder.
- `ToDto` tüm temel alanları birebir map eder.
- `UpdateEntity` `FirstName`, `LastName`, `Email`, `Phone`, `Position`, `IsActive` alanlarını günceller; `HireDate` ve `Id` dokunulmaz.
- Null kontrolü/validasyon yok; null parametrelerde `NullReferenceException` olasılığı vardır.

**6. Bağlantılar**
- **Yukarı akış:** Application katmanı içindeki servisler/komut-sorgu işleyicileri tarafından kullanılabilir (bu dosyadan kesin olarak anlaşılmıyor).
- **Aşağı akış:** `Library.Domain.Entities.Staff`, `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.
- **İlişkili tipler:** `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- Parametre null kontrolleri yok; güvenli kullanım için guard/validasyon eklenebilir.
- `UpdateEntity` `HireDate`’i güncellemez; tasarımsal olabilir ancak ihtiyaçsa eklenmelidir.

---

Genel Değerlendirme
- Mimari olarak Application katmanının Domain’e bağımlılığı net; Clean Architecture ilkeleriyle uyumlu görünüyor.
- Mapping basit ve anlaşılır; ancak null/validasyon kontrolleri eksik.
- Harici paket ve konfigürasyon görünürlüğü yok; proje genelini anlamak için diğer katman dosyaları (API/Infrastructure) incelenmeli.### Project Overview
Proje adı: Library. Amaç: kitap kategorileri için uygulama hizmetleri sağlayarak CRUD operasyonlarını yönetmek. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor). Mimari katmanlar, `Library.Application` (uygulama hizmetleri, DTO/Mapping) ve `Library.Domain` (repository sözleşmeleri) olarak ayrışıyor.

Mimari desen: Katmanlı mimari (Clean Architecture’a yakın). Application katmanı domain arayüzlerine bağımlı ve mapping üzerinden DTO-Entity dönüşümleri yapıyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama hizmetleri, DTO’lar, mapping uzantıları, uygulama arayüzleri.
- Library.Domain — Repository arayüzleri (ör. `IBookCategoryRepository`).

Dış paketler/çatı: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Presentation/API (varsayım) -> Library.Application -> Library.Domain

---

### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD odaklı uygulama servisidir; `Library.Application` katmanında yer alır. Domain katmanındaki `IBookCategoryRepository` aracılığıyla veri erişimini soyutlar ve DTO-Entity dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygılar:** `IBookCategoryService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori varlıkları için veri erişim operasyonları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<BookCategoryDto?> GetByIdAsync(Guid id)` | ID ile kategoriyi getirir ve DTO’ya dönüştürür; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri getirir ve DTO listesine dönüştürür. |
| CreateAsync | `public Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | DTO’dan entity oluşturur, ekler ve oluşanı DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Mevcut kategoriyi ID ile bulur, DTO değerleriyle günceller; yoksa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | ID ile kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByIdAsync`: Bulunamazsa `null` döner.
- `CreateAsync`: `CreateBookCategoryDto.ToEntity()` ile entity üretir; kimlik/varsayılanlar entity tarafında belirleniyor olabilir (bu dosyadan anlaşılmıyor).
- `UpdateAsync`: Kayıt bulunamazsa `KeyNotFoundException` fırlatır; `UpdateBookCategoryDto.UpdateEntity(entity)` ile alan bazlı güncelleme yapar.
- `DeleteAsync`: Doğrudan silme çağrısı; varlık yoksa repository davranışına bağlı sonuç (bu dosyadan anlaşılmıyor).
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantıları üzerinden tek yönlü/dönüşümlü mapping.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API controller’ları veya application arayüz çağrıcıları.
- **Aşağı akış:** `IBookCategoryRepository`.
- **İlişkili tipler:** `IBookCategoryService`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`).

**7. Eksikler ve Gözlemler**
- `CreateAsync` için herhangi bir input validasyonu görünmüyor.
- `DeleteAsync` varlık mevcut değilse davranış belirsiz; repository tarafında hata üretmiyorsa sessiz başarısızlık olabilir.
- `GetByIdAsync` null döndürüyor; üst katman null kontrolünü yapmalı, aksi halde 404 dönüşü garanti değil. 

---

Genel Değerlendirme
- Katman ayrımı net: Application servisleri domain repository arayüzlerine bağımlı.
- Mapping uzantılarının kullanımı tutarlı; ancak validasyon stratejisi görünmüyor. FluentValidation veya benzeri bir yaklaşım entegrasyonu değerlendirilebilir.
- Hata yönetimi kısmi: Update için bulunamadı kontrolü var; Delete ve Create için tutarlı validasyon/hata modeli eklenebilir.
- Transaction ve birim çalışması (Unit of Work) işaretleri yok; birden fazla repository işlemi gereken senaryolarda eklenmesi gerekebilir.### Project Overview
Proje adı: Library (tahmini). Amaç: Kitap yönetimi için uygulama katmanında kitap CRUD ve bildirim işlemlerini koordine etmek. Hedef framework bu dosyadan anlaşılamıyor.

Mimari: Clean Architecture benzeri katmanlama. Domain katmanı alan varlıkları ve repository kontratlarını barındırır (`Library.Domain.Entities`, `Library.Domain.Interfaces`). Application katmanı iş kurallarını servisler aracılığıyla uygular, DTO/mapping ve harici servis portlarını içerir (`Library.Application.Services`, `Library.Application.DTOs`, `Library.Application.Mappings`, `Library.Application.Email`, `Library.Application.Interfaces`).

Projeler/Assembly’ler:
- Library.Domain — Entity ve repository arayüzleri.
- Library.Application — Uygulama servisleri, DTO’lar, mapping ve e‑posta servisi arayüzleri.

Harici paketler/çatı: Doğrudan görünmüyor. LINQ kullanımı mevcut; veri erişim altyapısı bu dosyadan anlaşılamıyor.

Yapılandırma: `EmailSettings.NotificationTo` uygulama yapılandırmasından gelmelidir. Başka app settings veya connection string bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application -> Library.Domain

Library.Application.Services.BookService
  -> Library.Domain.Interfaces.IBookRepository
  -> Library.Application.Email.IEmailService
  -> Library.Application.Email.EmailSettings
  -> Library.Application.DTOs / Library.Application.Mappings
  -> Library.Domain.Entities.Book

---
### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik CRUD ve sorgulama işlemlerini yürüten uygulama katmanı servisidir. Repository ve mapping katmanlarını kullanarak `Book` varlıklarını DTO’lara dönüştürür, ayrıca yeni kitap eklendiğinde e‑posta bildirimi gönderebilir. Clean Architecture’da Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap verisi için veri erişim/kalıcılık operasyonları
- `IEmailService` — E‑posta gönderimi için soyut servis
- `EmailSettings` — Bildirim alıcısı gibi e‑posta yapılandırma ayarları

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookService(IBookRepository bookRepository, IEmailService emailService, EmailSettings emailSettings)` | Servisin repository, e‑posta servisi ve ayarlarıyla yapılandırılması |
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirtilen kimliğe sahip kitabı DTO olarak döner |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları DTO listesi olarak döner |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait kitapları DTO listesi olarak döner |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur, bildirim e‑postası gönderebilir, DTO döner |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller; yoksa istisna fırlatır |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kitabı kimliğe göre siler |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `CreateBookDto` -> `Book` mapping (`ToEntity`), ekleme sonrası `NotificationTo` doluysa HTML e‑posta gönderimi.
- `UpdateAsync`: Kayıt yoksa `KeyNotFoundException` fırlatır; `UpdateBookDto.UpdateEntity` ile alanları günceller.
- `GetAvailableBooksAsync`: Uygunluk filtresi repository seviyesinde yapılır.
- DTO mapping: `ToDto`, `ToEntity`, `UpdateEntity` extension’ları kullanılır.
- Silme işleminde varlık var/yok kontrolü repository’ye bırakılmıştır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar uygulama/ API katmanı bileşenleri.
- **Aşağı akış:** `IBookRepository`, `IEmailService`, `EmailSettings`, mapping extension’ları, `Book` entity.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `Book`, `IBookService`, `IBookRepository`, `EmailSettings`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için girdi validasyonu servis düzeyinde görünmüyor; hatalı/eksik alanlar mapping’ten geçebilir.
- `DeleteAsync` varlık yoksa davranış belirsiz; repository’nin istisna/başarı bilgisi servis katmanında ele alınmıyor.
- E‑posta gönderiminde hata yönetimi yok; gönderim başarısızlığı iş akışını etkilemeyebilir veya istisna yüzeye çıkabilir.

### Genel Değerlendirme
Kod, Application katmanında servis odaklı, arayüzlere bağımlı temiz bir ayrım sunuyor. Mapping extension’ları ile DTO-entity dönüşümü tutarlı. E‑posta bildirimi isteğe bağlı yapılandırma ile tetikleniyor. Servis düzeyinde girdi validasyonu ve hata yönetimi (özellikle silme ve e‑posta gönderimi için) güçlendirilebilir. Katmanlar arası bağımlılık yönleri doğru; veri erişim ve altyapı ayrıntıları bu dosyadan belirgin değil.### Project Overview
- Proje adı: Library
- Amaç: Müşteri verileriyle ilgili uygulama iş mantığını sunmak (CRUD ve filtreleme) ve domain katmanındaki repository’lerle çalışmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı (N-Tier). 
  - Domain: Repository kontratları (`Library.Domain.Interfaces`).
  - Application: Servisler, DTO’lar, mapping uzantıları ve uygulama kontratları (`Library.Application.*`).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Application: Uygulama iş mantığı (`Services`), DTO’lar, mapping uzantıları, uygulama arayüzleri.
  - Library.Domain: Repository arayüzleri.
- Kullanılan harici paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Services, DTOs, Mappings, Interfaces) --> Library.Domain (Interfaces)

---
### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri varlıkları için uygulama katmanı iş mantığını uygular. Repository aracılığıyla veri erişimini soyutlar, DTO-entity dönüşümlerini yapar ve CRUD/filtreleme operasyonlarını sunar. Application katmanında konumlanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri verilerine erişim için repository kontratı.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını enjekte eder. |
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Kimliğe göre müşteriyi getirir ve DTO’ya map eder; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri listeler ve DTO’ya map eder. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri listeler ve DTO’ya map eder. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | DTO’dan entity oluşturur, ekler ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Mevcut entity’yi bulur, DTO ile günceller; yoksa `KeyNotFoundException` atar. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kimliğe göre müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `CreateCustomerDto.ToEntity()`, `customer.ToDto()`, `UpdateCustomerDto.UpdateEntity(entity)` uzantıları kullanılır.
- `UpdateAsync` içinde, müşteri bulunamazsa `KeyNotFoundException` fırlatılır.
- `CreateAsync` ekleme sonrası entity’den DTO üretilir; ID ve zaman damgası gibi alanların üretimi repository/entity tarafında olabilir (bu dosyadan anlaşılmıyor).
- Filtreleme: Aktif müşteriler `ICustomerRepository.GetActiveCustomersAsync()` üzerinden sağlanır.

DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir.
- Aşağı akış: `ICustomerRepository`; mapping uzantıları (`Library.Application.Mappings`).
- İlişkili tipler: `ICustomerService`, `ICustomerRepository`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- Servis metodlarında girdi validasyonu (ör. `createDto`, `updateDto` null/alan kontrolleri) servis seviyesinde görünmüyor; validasyon başka katmanda olabilir ancak bu dosyadan anlaşılmıyor.
- `DeleteAsync` için “kayıt bulunamadı” durumunda davranış belirgin değil; repository implementasyonuna bağlı.

---
Genel Değerlendirme
- Katmanlar arası ayrım net: Application servisi Domain repository arayüzüne bağımlı.
- Mapping işlemleri uzantı metotlarıyla merkezi hale getirilmiş, okunabilirlik iyi.
- Servis içinde kapsamlı validasyon ve hata yönetimi görünmüyor; muhtemelen başka katmanlara (ör. API validasyonu, domain kuralları) bırakılmış. Bu yaklaşım tutarlıysa sorun değil; aksi halde veri bütünlüğü riskleri doğabilir.
- Transaction yönetimi ve birimsel işlemler (Unit of Work) görünmüyor; repository veya daha dış katmanda ele alınıyor olabilir. Bu dosyadan kesinleşmiyor.### Project Overview
Proje adı: Library  
Amaç: Kütüphane personel (staff) bilgilerinin uygulama katmanında işlenmesi, domain repository’leri üzerinden veri erişimi ve DTO/Entity mapping’leri ile veri aktarımı.  
Hedef framework: Bu dosyadan kesin olarak anlaşılamıyor; .NET (modern async/await kullanımı).  
Mimari: Katmanlı/Clean Architecture yaklaşımı. Application katmanı, Domain arayüzlerine bağımlı; mapping’ler ve DTO’lar Application’da. Veri erişimi Infrastructure’da (bu dosyadan görülmüyor) varsayılır.  
Projeler/Assembly’ler:  
- Library.Application — Uygulama hizmetleri (`Services`), DTO’lar, mapping uzantıları ve uygulama arayüzleri  
- Library.Domain — Domain sözleşmeleri (`Interfaces`) ve muhtemel entity’ler (bu dosyadan yalnızca arayüzler görünüyor)  
Harici paketler: Bu dosyadan anlaşılamıyor.  
Konfigürasyon: Bu dosyadan anlaşılamıyor (connection string veya app settings anahtarları görünmüyor).

### Architecture Diagram
Domain (Library.Domain)
  ↑ (sözleşmeler)
Application (Library.Application: Services, DTOs, Mappings)
  ↑ (muhtemel)
Infrastructure (Library.Infrastructure: Repositories, Data Access) — bu dosyadan görünmüyor

---
### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel yönetimi için uygulama katmanı servisini uygular ve `IStaffService` sözleşmesini gerçekleştirir. `IStaffRepository` üzerinden domain verilerine erişir ve `DTO` ↔ `Entity` dönüşümlerini mapping uzantıları ile yapar. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel verileri için domain repository erişimi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir ve `StaffDto`ya map eder. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personelleri getirir ve `StaffDto` koleksiyonuna map eder. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personelleri getirir ve `StaffDto` koleksiyonuna map eder. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur; entity’yi ekleyip DTO olarak döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Var olan personeli günceller; yoksa `KeyNotFoundException` fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `ToDto`, `ToEntity`, `UpdateEntity` uzantıları ile DTO/Entity dönüşümü yapılır.
- `UpdateAsync`: ID’ye karşılık kayıt yoksa `KeyNotFoundException` fırlatır.
- `CreateAsync`: `CreateStaffDto`’dan entity üretilir ve repository’e eklenir; ekleme sonrası DTO döner.
- `DeleteAsync`: Varlık yoksa davranış repository implementasyonuna bağlı; bu dosyadan anlaşılmıyor.
- Filtreleme: `GetActiveStaffAsync` aktif kayıtları döndürür; aktiflik kriteri domain tarafında uygulanır.

**6. Bağlantılar**
- Yukarı akış: `IStaffService` tüketicileri (ör. Controller’lar, diğer application hizmetleri) — DI üzerinden çözümlenir.
- Aşağı akış: `IStaffRepository` (veri erişimi); mapping uzantıları (`Library.Application.Mappings`).
- İlişkili tipler: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`, `IStaffRepository`.

**7. Eksikler ve Gözlemler**
- `DeleteAsync` içinde silinecek kaydın mevcut olup olmadığına dair açık bir kontrol ve anlamlı hata dönüşü yok; davranış repository’e bırakılmış.

---
Genel Değerlendirme
- Katman ayrımı net: Application servisi domain repository sözleşmesine bağımlı ve mapping uzantılarıyla çalışıyor; Clean Architecture ilkeleriyle uyumlu.
- Validasyon ve hata yönetimi sınırlı; yalnızca `UpdateAsync`’te not-found kontrolü var. `CreateAsync` ve `DeleteAsync` için giriş/doğrulama ve anlamlı hata dönüşleri genişletilebilir.
- Harici paketler ve yapılandırmalar bu dosyadan görülemiyor; proje genelinde DI, logging ve transaction yönetimi stratejilerinin tutarlılığı kontrol edilmeli.### Project Overview
Proje adı: Library (çıkarım: namespace ve klasör yapısından). Amaç: Kütüphane alanındaki temel varlıkları temsil etmek; bu girdi özelinde kitap bilgisini modellemek. Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı/Clean Architecture eğilimli; `Library.Domain` alan katmanı olarak konumlanmış, iş kurallarına temel olan entity’leri barındırır. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri ve alan modelleri.

Harici paketler/çerçeveler: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Entities)
  ↑ referenced by (muhtemel): Application → Infrastructure → API
Yalnızca `Library.Domain` görülebiliyor; diğer katmanlar bu dosyadan çıkarımsal ve kesin değil.

---
### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kitap varlığını temsil eder; kimlik, bibliyografik bilgiler ve erişilebilirlik durumunu tutar. Domain katmanına aittir ve olası `BookCategory` ilişkisini içerir.

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
| Id | `public Guid Id { get; set; }` | Kitap benzersiz kimliği. |
| Title | `public string Title { get; set; }` | Kitap başlığı. Varsayılan `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adı. Varsayılan `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. Varsayılan `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik durumu; varsayılan `true`. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | Navigasyon özelliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `IsAvailable = true`. İlişki opsiyoneldir (`BookCategoryId` ve `BookCategory` null olabilir).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel kullanımlar: Application/Infrastructure katmanları.
- **Aşağı akış:** Harici bağımlılık yok; opsiyonel `BookCategory` ilişkisi.
- **İlişkili tipler:** `BookCategory` (aynı domain içinde beklenir; bu dosyada tanımı yok).

**7. Eksikler ve Gözlemler**
- Validasyon (ör. `Title`, `Author`, `ISBN` zorunlulukları, `PublishedYear` aralığı) entity düzeyinde tanımlı değil; başka katmanlarda ele alınması gerekebilir.

---
Genel Değerlendirme
Kod tabanı yalnızca domain katmanından bir entity gösteriyor. Mimari düzen Clean/katmanlı yapıya işaret ediyor ancak diğer katmanlar görünmüyor. Domain entity’sinde veri doğrulama ve iş kuralları bulunmuyor; bu, üst katmanlarda ele alınmalı veya domain modeline eklenmeli. İlişkili `BookCategory` tipi tanımlı değil; repository’de mevcutsa ilişki bütünlüğü ve gezinti özelliklerinin yükleme stratejileri (lazy/explicit/eager) uygulama tarafında netleştirilmeli. Target framework, paketler ve konfigürasyonlar bu dosyadan çıkarılamıyor.### Project Overview
- Proje Adı ve Amaç: Library — kütüphane alan modelini tanımlayan domain varlıklarını içerir. Kitap ve kategorilere ilişkin temel veri yapıları amaçlanmaktadır.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı/Clean Architecture göstergesi mevcut; `Library.Domain` alan katmanı olarak konumlanmış.
- Keşfedilen Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları ve temel modeller.
- Harici Paketler/Çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  ↓ (tüketilmesi beklenen, ancak bu depoda görünmüyor)
Application/Infrastructure/API (bu dosyadan anlaşılmıyor)

---

### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, kitap kategorilerini temsil eden domain varlığıdır; kategorinin kimliği, adı, açıklaması ve kategoriye bağlı kitapların koleksiyonunu tutar. Domain katmanına aittir ve muhtemel `Book` varlığı ile ilişki kurar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
- Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kategorinin benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategorinin adı. |
| Description | `public string Description { get; set; }` | Kategorinin açıklaması. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye ait kitapların koleksiyonu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Books = []`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `ICollection<Book>` — kategoriye bağlı kitapları temsil eder.
- **İlişkili tipler:** `Book` (aynı domain içinde olması beklenir; bu dosyada tanımlı değil).

---

### Genel Değerlendirme
- Kod sadece domain katmanından tek bir entity sunuyor; diğer katmanlar ve kullanım bağlamı bu depodan anlaşılmıyor.
- Domain varlığında davranış/iş kuralı bulunmuyor; tüm üyeler set edilebilir. İleride kapsülleme veya fabrika/metot bazlı oluşturma düşünülüyorsa salt-okunur koleksiyonlar ve constructor tabanlı zorunlu alanlar değerlendirilebilir.### Project Overview
- Proje adı: Library (Namespace’lerden çıkarım)
- Amaç: Kütüphane alanına ait müşteri bilgisini temsil eden domain entity tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (en azından Domain katmanı mevcut). Domain katmanı, iş alanı varlıklarını içerir. Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıkları (Entities)
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer`, kütüphane sistemindeki bir müşteriyi temsil eden domain entity’dir. Kimlik, iletişim ve üyelik bilgilerini tutar. Domain katmanına aittir ve veri erişimi veya uygulama mantığı içermez.

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
| Id | `Guid Id { get; set; }` | Müşterinin benzersiz kimliği. |
| FirstName | `string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `string Email { get; set; }` | E-posta adresi. |
| Phone | `string Phone { get; set; }` | Telefon numarası. |
| Address | `string Address { get; set; }` | Adres bilgisi. |
| MembershipNumber | `string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `bool IsActive { get; set; }` | Aktif olup olmadığını belirtir. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `IsActive = true`. `RegisteredDate` ve `Id` için default atanmış bir başlangıç değeri yok.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Domain katmanından tek bir entity mevcut; diğer katmanlara dair iz yok. 
- Entity üzerinde validasyon, kapsülleme veya davranış bulunmuyor; tüm alanlar set edilebilir durumda. İleride domain kuralları gerekiyorsa korumalı setter’lar, factory metotları veya value object’ler tercih edilebilir.
- `RegisteredDate` ve `Id` için otomatik atama yapılmıyor; üst katmanlarda üretim/atanma stratejisi netleştirilmeli (ör. DB tarafında GUID, uygulama tarafında `DateTime.UtcNow`).### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` isim alanı)
- Amaç: Kütüphane alan modelindeki varlıkları tanımlamak (ör. personel bilgileri).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean-Architecture eğilimli yapı; görünen katman Domain (iş kuralları ve temel modeller).
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain varlıkları ve temel iş kuralları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain)
  └─ Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılmıyor

---
### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff` bir kütüphane personelini temsil eden domain varlığıdır. Personelin kimlik, iletişim, pozisyon ve durum bilgilerini tutar. Domain katmanına aittir ve muhtemel iş kurallarının temel veri taşıyıcısıdır.

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
| Id | `public Guid Id { get; set; }` | Personel benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe giriş tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = true`. `HireDate` ve `Id` için default atama yapılmıyor (tiplerin varsayılanları geçerli).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir veya Application/Infrastructure katmanları tarafından kullanılabilir (bu dosyadan kesin değil).
- **Aşağı akış:** Yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Yalnızca Domain katmanından tek bir varlık görülüyor; mimarinin geri kalanı (Application/Infrastructure/API) bu repo kesitinde görünmüyor.
- `Staff` üzerinde veri doğrulama (ör. `Email` formatı, zorunlu alanlar) uygulanmamış; bu doğrulamaların başka katmanlarda ele alınması gerekebilir.
- Varlık, sadece veri taşıyor; davranış/iş kuralları entity içinde tanımlı değil. Bu, zengin domain yerine anemik model yaklaşımını işaret ediyor.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanındaki `BookCategory` varlıkları için depo (repository) sözleşmelerini tanımlamak; domain katmanında kalıcı depolama soyutlaması sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Domain katmanı mevcut). Domain katmanı, entity ve repository arayüzlerini barındırır; uygulama/altyapı katmanları bu sözleşmeleri uygular/kullanır.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları ve arayüzler (bu dosyada görülen).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)
  ↑
(geri kalan katmanlar bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlıkları için depo işlemlerini tanımlayan domain arayüzüdür. Temel `IRepository<BookCategory>` sözleşmesini genişletir ve kategori adına göre getirme ile ilişkili kitaplarla birlikte getirme gibi alan-özel sorgular ekler. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `Yok`
- **Uygular:** `Yok` (genişletir: `IRepository<BookCategory>`)
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre tek bir `BookCategory` varlığını asenkron olarak getirir; yoksa `null`. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Verilen `id` için kategoriyi ilişkili kitaplarıyla birlikte asenkron olarak getirir; yoksa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- `IRepository<BookCategory>` üzerinden temel CRUD sözleşmesini devralır (detaylar bu dosyada yok).
- `GetByNameAsync` ada göre benzersiz/tekil bir kategori bekler; bulunamazsa `null` döner.
- `GetWithBooksAsync` ilişkili kitap koleksiyonunun birlikte yüklenmesini (eager loading/include) amaçlayan bir sözleşmedir; bulunamazsa `null` döner.
- İstisna fırlatma veya validasyon kuralları bu dosyadan anlaşılmıyor; implementasyona bağlıdır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BookCategory` (entity), `IRepository<T>` (genel depo sözleşmesi)

Genel Değerlendirme
- Sadece domain sözleşmesi görülebiliyor; diğer katmanlar ve uygulamalar bu depoyu nasıl kullandığı bu dosyadan anlaşılmıyor.
- `IRepository<BookCategory>` tanımı görünmediği için temel CRUD kapsamı belirsiz.
- Hedef framework, harici paket kullanımı ve konfigürasyon ayrıntıları mevcut koddaki bilgilerle belirlenemiyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanından)
- Amaç: Kitap yönetimi alanına ait entity ve sözleşmeleri tanımlamak; özellikle `Book` için repository sözleşmesi sağlamak.
- Hedef framework: Bu dosyadan kesin değil; modern .NET (>= .NET 6) kullanıldığı varsayılabilir, ancak doğrulanmıyor.
- Mimari desen: Katmanlı/Temiz Mimari yönelimli — bu katman Domain. Repository arayüzleri ve entity’ler burada yer alır; uygulama, altyapı ve sunum katmanları bu katmana bağımlı olur.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain entity’leri ve repository arayüzleri.
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain

(Bu dosyada yalnızca Domain katmanı görünür; başka katman/proje bağımlılığı bu depoda gösterilmemiştir.)

---

### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` entity’si için repository sözleşmesini tanımlar. Mevcut kitapları listelemek ve ISBN’e göre tekil sorgu yapmak için ek operasyonlar sunar. Domain katmanına aittir ve implementasyonun Infrastructure katmanında sağlanması beklenir.

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
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Müsait/ödünç verilebilir kitapları asenkron olarak döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen `isbn` ile eşleşen kitabı bulur; bulunamazsa `null` dönebilir. |

**5. Temel Davranışlar ve İş Kuralları**
- ISBN’e göre arama `null` dönebilir; çağıran tarafın null kontrolü yapması gerekir.
- “Müsait kitaplar” kavramı için bir filtreleme beklentisi vardır; gerçek kriter implementasyona bırakılmıştır.
- Kalıcılaştırma ve sorgulama stratejileri (ör. takip/track, transaction) bu sözleşmede tanımlanmaz; implementasyona aittir.

**Mantık içermeyen basit DTO/model'ler için** bu bölüm uygulanmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Service katmanları tarafından tüketilmesi beklenir (bu dosyadan çağırıcılar net değil).
- **Aşağı akış:** Yok (sadece sözleşme).
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `IRepository<Book>`.

**7. Eksikler ve Gözlemler**
- `IRepository<Book>` sözleşmesinin tanımı bu depoda gösterilmediği için temel CRUD operasyonları belirsiz.
- `GetAvailableBooksAsync` için “müsaitlik” kriteri sözleşmede belgelenmemiş; ortak bir alan/flag (`IsAvailable` vb.) varlığı bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanına ait bir repository arayüzü görülüyor; uygulama, altyapı ve sunum katmanları ile ilişkiler bu dosyadan doğrulanamıyor.
- `IRepository<T>` ve `Book` entity tanımları eksik olduğundan tam API yüzeyi ve iş kuralları netleşmiyor.
- Konfigürasyon, dış bağımlılık ve hata yönetimi politikaları bu seviyede tanımlı değil; beklenen şekilde implementasyon katmanına bırakılmış olmalı.### Project Overview
- Proje adı: Library (görünen ad alanlarından çıkarım)
- Amaç: Kütüphane alanındaki müşteri (üye) varlıklarını saklama katmanından soyutlamak için repository kontratlarını tanımlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Muhtemelen katmanlı/Clean Architecture yaklaşımı. Görünen katman Domain; repository arayüzleri ve entity referansları burada tanımlanmış.
- Keşfedilen projeler/assemblies:
  - Library.Domain — Domain katmanı; entity ve repository kontratları.
- Kullanılan dış paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Interfaces, Entities)

---

### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` varlıkları için okuma/filtreleme odaklı ek sorguları tanımlayan repository sözleşmesidir. Domain katmanına aittir ve temel CRUD operasyonlarını muhtemelen `IRepository<Customer>`’dan devralır.

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
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E‑posta adresine göre tek bir `Customer` döner (yoksa `null`). |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre tek bir `Customer` döner (yoksa `null`). |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif durumdaki tüm `Customer` listesini döner. |

**5. Temel Davranışlar ve İş Kuralları**
- Domain sözleşmesi düzeyinde yalnızca sorgu imzaları tanımlıdır; davranışın ayrıntıları implementasyona bırakılır.
- `GetByEmailAsync` ve `GetByMembershipNumberAsync` tekil sonuç veya `null` dönecek şekilde tasarlanmıştır.
- `GetActiveCustomersAsync` iş kuralı olarak “aktif” müşterileri filtrelemeyi işaret eder; aktiflik ölçütü entity tarafında tanımlıdır (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen Application/Infrastructure katmanındaki servisler tarafından çağrılır (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** Harici bağımlılık yok; implementasyonlar veri kaynağına bağımlı olacaktır.
- **İlişkili tipler:** `Customer` (Entity), `IRepository<Customer>` (genel repository sözleşmesi).

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametresi bulunmuyor; uzun süren I/O işlemleri için iptal desteği gerekebilir.

---

### Genel Değerlendirme
- Görünen kod Domain katmanında repository kontratlarını gösteriyor; bu, Clean Architecture/Katmanlı mimariyle uyumlu.
- Sadece bir dosya mevcut olduğundan diğer katmanlar (Application, Infrastructure, API) ve hedef framework belirlenemiyor.
- Asenkron method imzalarına `CancellationToken` eklenmesi ve sözleşmelerde iptal/timeout politikalarının netleştirilmesi faydalı olabilir.### Project Overview
- Proje adı: Library (çıkarım: `Library.*` namespace’lerinden)
- Amaç: Domain katmanında generic repository sözleşmesi sağlayarak entity’ler için standart CRUD operasyonlarını soyutlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture yaklaşımı (çıkarım). Bu dosyada yalnızca Domain katmanı gözüküyor; kalıcılaştırma ve uygulama hizmetleri bu arayüzü uygulayarak/çağırarak çalışır.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain katmanı; temel sözleşmeler ve muhtemel domain tipleri.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
(İlişki yönleri çıkarımsaldır; yalnızca görünen Domain katmanına göre gösterilmiştir.)
[API/Presentation] → [Application] → [Infrastructure] → [Domain (Library.Domain)]

---

### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
`IRepository<T>` generic repository sözleşmesini tanımlar; entity’ler üzerinde asenkron CRUD işlemleri için standart bir arayüz sağlar. Domain katmanına aittir ve uygulama/altyapı katmanlarının veri erişimini soyutlamasını amaçlar.

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
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `Guid` kimliğe sahip entity’yi asenkron olarak getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm entity koleksiyonunu asenkron olarak döner. |
| AddAsync | `Task AddAsync(T entity)` | Yeni entity ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut entity’yi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kimliğe göre entity’yi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama servisleri veya komut/işlem işleyicileri tarafından çağrılması beklenir (bu dosyadan doğrudan anlaşılmıyor).
- **Aşağı akış:** Uygulama/Infrastructure katmanındaki somut repository implementasyonları bu arayüzü uygular.
- **İlişkili tipler:** `T` generic parametresi ile temsil edilen domain entity’leri.

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanındaki repository sözleşmesi görünüyor; somut implementasyonlar, entity tanımları, Application/Infrastructure/API katmanları bu dosyadan anlaşılmıyor.
- Hata yönetimi, transaction sınırları ve sorgu/filtreleme stratejileri arayüz seviyesinde tanımlı değil; bunlar muhtemelen implementasyonlara bırakılacaktır.### Project Overview
- Proje adı: Library (bu isim namespace ve klasör yapısından çıkarılmıştır). Amaç: Kütüphane alanındaki personel (`Staff`) varlıkları için depolama sözleşmesini tanımlamak. Hedef framework: bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı mimari (Domain katmanı görünür). Domain katmanı, entity ve repository sözleşmelerini içerir; uygulama ve altyapı katmanları bu dosyadan görünmüyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain modelleri ve repository arayüzleri (sözleşmeler).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain sözleşmeleri ve varlıklar)
  ↑ (uygulamada DI ile tüketilmesi beklenir; diğer katmanlar bu dosyadan görünmüyor)

---
### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` varlığı için repository sözleşmesini tanımlar. Temel CRUD işlemlerini sağlayan `IRepository<Staff>` üzerine, e-posta ile sorgulama ve aktif personel filtrelemesi gibi alan-özel ek sorgular ekler. Domain katmanına aittir.

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
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | Verilen e-posta ile eşleşen `Staff` kaydını asenkron olarak getirir; yoksa `null`. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki tüm `Staff` kayıtlarını asenkron olarak listeler. |

Not: `IRepository<Staff>` aracılığıyla kalıtılan genel CRUD üyeleri bu dosyada tanımlı değildir.

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez; implementasyon detayları altyapı katmanında sağlanır.
- `GetByEmailAsync`: E-posta üzerinde tekil eşleşme beklentisi ima edilir; bulunamazsa `null` döner.
- `GetActiveStaffAsync`: Aktiflik kriterinin `Staff` varlığındaki uygun bir işaret/alan üzerinden filtreleneceği ima edilir (bu dosyadan alan adı anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/servis katmanları tarafından kullanılmak üzere tasarlanır.
- **Aşağı akış:** `IRepository<Staff>` (genel CRUD sözleşmesi), `Library.Domain.Entities.Staff`.
- **İlişkili tipler:** `Staff`, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `IRepository<Staff>` tanımı bu dosyada yok; çözümde mevcut olmalı. Implementasyon sınıfları (ör. EF Core repository) görünmüyor. Bu, altyapı katmanının eksik olduğuna işaret edebilir veya sadece bu girdiyle sağlanmamış olabilir.

---
Genel Değerlendirme
- Mevcut kod Domain katmanında repository sözleşmesini doğru şekilde tanımlıyor. Ancak yalnızca bir arayüz verildiğinden, uygulama/altyapı katmanlarının varlığı ve detayları bu dosyadan anlaşılmıyor.
- Hedef framework, konfigürasyon anahtarları ve harici bağımlılıklar görünür değil.
- Çözüm genelinde Clean/katmanlı bir düzen ima ediliyor; diğer katmanların dosyaları sağlanırsa bağımlılık akışı ve paket kullanımları netleştirilebilir.### Proje Genel Bakış
- Ad: Library (çıkarım)
- Amaç: Kütüphane alanındaki `Book`, `BookCategory`, `Staff`, `Customer` varlıklarını Entity Framework Core ile kalıcı katmanda modellemek ve veri erişimini sağlamak.
- Hedef Framework: .NET (EF Core tabanlı). Spesifik sürüm bu dosyadan anlaşılmıyor.
- Mimari: N‑Katmanlı yaklaşım. 
  - Domain: `Library.Domain.Entities` altında POCO varlıklar.
  - Infrastructure: `Library.Infrastructure.Data` altında EF Core `DbContext` ve kalıcılık yapılandırmaları.
  - API/Application katmanları bu dosyadan görünmüyor.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları (entity’ler).
  - Library.Infrastructure — Kalıcılık (EF Core `DbContext` ve mapping).
- Dış Bağımlılıklar: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon: EF Core için bağlantı dizesi gereklidir (örn. `ConnectionStrings:DefaultConnection` gibi). Tam anahtar adı ve sağlayıcı bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Domain (Library.Domain)
  ↑
Infrastructure (Library.Infrastructure.Data)

---

### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
`LibraryDbContext`, EF Core üzerinden kütüphane domain varlıklarının veritabanı eşlemesini ve kısıtlarını tanımlar. Infrastructure katmanında yer alır ve `Book`, `BookCategory`, `Staff`, `Customer` için tablo ve ilişkileri yapılandırır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlamı için çalışma zamanı konfigürasyonu (sağlayıcı, bağlantı dizesi, vb.).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | EF Core bağlamını verilen seçeneklerle başlatır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlıkları için sorgulama ve CRUD erişimi. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlıkları için erişim. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlıkları için erişim. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlıkları için erişim. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Varlık eşlemeleri, kısıtlar ve indeksleri yapılandırır. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book`:
  - `Id` birincil anahtar.
  - `Title` zorunlu, max 200.
  - `Author` zorunlu, max 150.
  - `ISBN` zorunlu, max 20; benzersiz indeks.
  - `BookCategory` ile ilişki: `BookCategoryId` üzerinden çok‑tan‑bire; silmede `SetNull` (FK alanının nullable olmasını gerektirir).
- `BookCategory`:
  - `Id` birincil anahtar.
  - `Name` zorunlu, max 100; benzersiz indeks.
  - `Description` opsiyonel, max 500.
- `Staff`:
  - `Id` birincil anahtar.
  - `FirstName`, `LastName`, `Email`, `Position` zorunlu; uzunluk sınırları: 100/100/200/100.
  - `Phone` opsiyonel, max 20.
  - `Email` benzersiz indeks.
- `Customer`:
  - `Id` birincil anahtar.
  - `FirstName`, `LastName`, `Email`, `MembershipNumber` zorunlu; uzunluk sınırları: 100/100/200/50.
  - `Phone` opsiyonel, max 20; `Address` opsiyonel, max 500.
  - `Email` ve `MembershipNumber` benzersiz indeksler.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; Application/Repository katmanları ve API katmanı bu bağlamı kullanabilir.
- Aşağı akış: `Library.Domain.Entities` içindeki `Book`, `BookCategory`, `Staff`, `Customer` varlıkları.
- İlişkili tipler: Söz konusu domain entity’leri ve olası repository/service implementasyonları (bu dosyadan görünmüyor).

**7. Eksikler ve Gözlemler**
- `BookCategory` silindiğinde `SetNull` uygulanır; buna uygun olarak `Book.BookCategoryId` alanının nullable tanımlanması gerekir. Domain tarafında bu uyum bu dosyadan anlaşılmıyor.
- Sağlayıcı, bağlantı dizesi anahtarı ve migration konfigürasyonu bu dosyadan belirlenemiyor.

---

Genel Değerlendirme
- Mimari katmanlaşma Domain ve Infrastructure arasında net; ancak Application ve API katmanları görünmüyor.
- EF Core eşlemeleri ayrıntılı ve indekslerle veri bütünlüğü sağlanmış. Silme davranışı (`SetNull`) seçimi domain modelleriyle uyumlu olmalı.
- Konfigürasyon anahtarları ve hedef framework sürümü belirsiz; dağıtım/dışı yapılandırma belgelenmeli.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım). Amaç: kütüphane alanındaki varlıklar (kitap, kategori, personel, müşteri) için veri erişimi ve e-posta bildirim altyapısını sağlamak. Hedef çerçeve sürümü bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean Architecture esintili yapı. Katmanlar:
  - Domain: `Library.Domain` — alan arayüzleri ve muhtemel domain modelleri.
  - Application: `Library.Application` — uygulama servis sözleşmeleri ve e-posta ayar modeli.
  - Infrastructure: `Library.Infrastructure` — EF Core DbContext, repository implementasyonları ve SMTP e-posta servisi, DI kompozisyonu.
- Projeler/Assembly’ler:
  - Library.Domain — Domain arayüzleri (`IBookRepository`, vb.).
  - Library.Application — Uygulama arayüzleri (`IEmailService`) ve `EmailSettings`.
  - Library.Infrastructure — `LibraryDbContext`, `BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`, `SmtpEmailService`, DI uzantısı.
- Harici paketler/çerçeveler: Entity Framework Core (`Microsoft.EntityFrameworkCore`, `UseSqlServer`), `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Configuration`.
- Konfigürasyon gereksinimleri:
  - Connection string: `DefaultConnection`
  - Email ayarları: `Email:Host`, `Email:Port`, `Email:Username`, `Email:Password`, `Email:From`, `Email:NotificationTo`, `Email:EnableSsl`

### Architecture Diagram
Domain <- Application <- Infrastructure
- Infrastructure -> Application (`Library.Application.Email`, `Library.Application.Interfaces`)
- Infrastructure -> Domain (`Library.Domain.Interfaces`)
- Infrastructure -> Infrastructure.Data/Repositories/Email (iç bileşenler)
- Infrastructure -> EF Core (SQL Server sağlayıcısı)

---

### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Infrastructure katmanının DI kayıtlarını tek noktadan yapılandırır. EF Core `DbContext`’ini, e-posta ayarlarını ve repository/servis implementasyonlarını servis koleksiyonuna ekler; Infrastructure katmanının Application ve Domain sözleşmelerine bağlanmasını sağlar.

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
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core, e-posta ayarları ve repository/servislerini DI konteynerine kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server ile `DefaultConnection` üzerinden kaydedilir.
- `EmailSettings` konfigürasyondan okunur; bulunamazsa varsayılanlar kullanılır:
  - `Port` varsayılanı `587`
  - `EnableSsl` varsayılanı `true`
  - Diğer alanlar bulunamazsa `string.Empty`
- `EmailSettings` `Singleton` olarak, repository ve servisler `Scoped` olarak kaydedilir.
- Arayüz-uygulama eşlemeleri:
  - `IBookRepository` → `BookRepository`
  - `IBookCategoryRepository` → `BookCategoryRepository`
  - `IStaffRepository` → `StaffRepository`
  - `ICustomerRepository` → `CustomerRepository`
  - `IEmailService` → `SmtpEmailService`

**Mantık içermeyen basit DTO/model'ler için**
DTO — davranış yok. Default değerler: Bu dosyadan DTO yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak kompozisyon kökünden çağrılır.
- **Aşağı akış:** `LibraryDbContext`, `EmailSettings`, `BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`, `SmtpEmailService`, EF Core SQL Server sağlayıcısı, `IConfiguration`.
- **İlişkili tipler:** `IEmailService`, `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`, `EmailSettings`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Infrastructure katmanı `Library.Application` içinden hem arayüz (`IEmailService`) hem de model (`EmailSettings`) referanslıyor; Clean Architecture’da genellikle Application’ın Domain’e, Infrastructure’ın ise yalnızca Application sözleşmelerine referans vermesi beklenir. `EmailSettings`’in Application’da tutulması katman bağımlılıklarını artırıyor olabilir.
- E-posta ve veritabanı konfigürasyon anahtarlarının yokluğunda sessizce varsayılanlara dönülmesi üretimde yanlış yapılandırmaları gizleyebilir; doğrulama veya başlangıçta hata vermek tercih edilebilir.

---

### Genel Değerlendirme
- Katmanlar belirgin; Infrastructure, EF Core ve SMTP entegrasyonunu DI ile sunuyor.
- Infrastructure’ın Application’a hem sözleşme hem de model düzeyinde bağımlılığı, katman sınırlarını bulanıklaştırıyor; ayar modelleri Infrastructure’a taşınabilir veya `IOptions<T>` deseni benimsenebilir.
- Konfigürasyon değerleri için doğrulama/bağlama (`Options` + `ValidateDataAnnotations`) eklenmesi önerilir.### Project Overview
Proje adı: Library. Amaç: Uygulama katmanında tanımlanan `IEmailService` sözleşmesini SMTP üzerinden gerçekleştiren e‑posta gönderim altyapısı sağlamak. Hedef çatı: Bu dosyadan anlaşılmıyor. Mimari: Clean Architecture eğilimli; Application katmanında arayüz/kontrat, Infrastructure katmanında dış bağımlılıklara (SMTP) erişen implementasyon.

Keşfedilen projeler/assembly’ler:
- Library.Application — `IEmailService`, `EmailSettings` gibi sözleşmeler ve ayar nesneleri.
- Library.Infrastructure — Altyapı implementasyonları; bu dosyada SMTP e‑posta gönderimi.

Kullanılan çerçeveler/paketler:
- .NET BCL `System.Net.Mail` (`SmtpClient`, `MailMessage`), `System.Net`.

Yapılandırma gereksinimleri (EmailSettings):
- `From`, `Host`, `Port`, `EnableSsl`, `Username`, `Password` — SMTP sunucusu ve kimlik bilgileri. Anahtar adları bu dosyadan anlaşılmıyor; `EmailSettings` üzerinden sağlanmalı.

### Architecture Diagram
Library.Application (Contracts: IEmailService, EmailSettings)
^
| implements
|
Library.Infrastructure (Email: SmtpEmailService)

---

### `Library.Infrastructure/Email/SmtpEmailService.cs`

**1. Genel Bakış**
`SmtpEmailService`, `IEmailService` arayüzünü SMTP ile e‑posta göndermek için uygular. Clean Architecture’da Infrastructure katmanına aittir ve dış sistem (SMTP sunucusu) entegrasyonunu kapsüller.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IEmailService`
- **Namespace:** `Library.Infrastructure.Email`

**3. Bağımlılıklar**
- `EmailSettings` — SMTP sunucusu, kimlik bilgileri ve gönderen adresi gibi konfigürasyonları sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `SmtpEmailService(EmailSettings settings)` | SMTP ayarlarını alır ve servis konfigüre edilir. |
| SendAsync | `Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)` | Verilen alıcıya, konuya ve gövdeye sahip e‑postayı SMTP üzerinden asenkron gönderir. |

**5. Temel Davranışlar ve İş Kuralları**
- `MailMessage` `IsBodyHtml` özelliği `isHtml` parametresine göre ayarlanır.
- `SmtpClient` `Host`, `Port`, `EnableSsl` ve `Credentials` değerleri `EmailSettings`’ten alınır.
- İptal desteği: `SendMailAsync` çağrısına `CancellationToken` iletilir.
- Olası istisnalar: SMTP katmanından kaynaklı `SmtpException` vb. fırlatılabilir; burada yakalanmıyor.
- Kaynak yönetimi: `MailMessage` ve `SmtpClient` `using` ile dispose edilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; `IEmailService`’i kullanan uygulama bileşenleri çağırır.
- **Aşağı akış:** `EmailSettings`, `System.Net.Mail.SmtpClient`.
- **İlişkili tipler:** `IEmailService`, `EmailSettings`.

**7. Eksikler ve Gözlemler**
- Girdi doğrulaması yok (`to`, `subject`, `body` için boş/geçersiz e‑posta kontrolü yapılmıyor).
- Hata yönetimi/loglama yok; SMTP hataları doğrudan yukarı taşınır.
- Kimlik bilgileri ve SSL ayarları doğru yapılandırılmadığında güvenlik riski oluşabilir; güvenli saklama ve TLS doğrulaması şart.

---

### Genel Değerlendirme
Kod, Clean Architecture prensipleriyle uyumlu bir ayrımı yansıtıyor: Application’da kontrat, Infrastructure’da SMTP implementasyonu. Görünürde harici paket bağımlılığı yok; yalnızca BCL kullanılmış. Gözle görülür eksikler: giriş doğrulaması ve merkezi hata/loglama stratejisi. Yapılandırma anahtar adları ve hedef çatı belirsiz; dokümante edilmesi faydalı olur. DI kayıtları ve `EmailSettings` bağlaması (özellikle güvenli gizli yönetimi) netleştirilmeli.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanındaki `BookCategory` veri erişimini EF Core üzerinden sağlamak (CRUD ve sorgular).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean-vari mimari işaretleri mevcut.
  - Domain: `Library.Domain` — Entity’ler (`BookCategory`) ve kontratlar (`IBookCategoryRepository`).
  - Infrastructure: `Library.Infrastructure` — EF Core `DbContext` ve repository implementasyonları.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain entity’leri ve repository arayüzleri.
  - Library.Infrastructure — Veri erişimi (EF Core), repository implementasyonları, `LibraryDbContext`.
- Dış bağımlılıklar:
  - Microsoft.EntityFrameworkCore — ORM ve sorgulama.
- Konfigürasyon gereksinimleri:
  - EF Core `LibraryDbContext` için bağlantı dizesi ve sağlayıcı konfigürasyonu bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için EF Core tabanlı repository implementasyonudur. `IBookCategoryRepository`’yi uygular ve kategori üzerinde CRUD ile isim ve ilişkili kitaplar üzerinden sorgular sağlar. Mimari olarak Infrastructure veri erişim katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core üzerinden `BookCategory` DbSet’ine erişim ve kalıcılık işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `BookCategoryRepository(LibraryDbContext context)` | Repository için `DbContext` bağımlılığını alır. |
| GetByIdAsync | `Task<BookCategory?> GetByIdAsync(Guid id)` | Id ile kategori bulur. |
| GetAllAsync | `Task<IEnumerable<BookCategory>> GetAllAsync()` | Tüm kategorileri listeler. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşen kategoriyi döner. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlişkili `Books` koleksiyonu ile birlikte kategori getirir. |
| AddAsync | `Task AddAsync(BookCategory entity)` | Yeni kategori ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(BookCategory entity)` | Kategoriyi günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kategori varsa siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetWithBooksAsync` ilişkili `Books` koleksiyonunu `Include` ile eager load eder.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` çalıştırır; işlem bazlı toplu kaydetme veya Unit of Work kullanılmaz.
- `DeleteAsync` id bulunamazsa sessizce hiçbir işlem yapmaz; exception fırlatmaz.
- Hiçbir metotta `CancellationToken` alınmaz; iptal semantiği yok.
- Varsayılan EF Core izleme davranışları kullanılır; özel validasyon veya domain kuralı uygulanmaz (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; `IBookCategoryRepository` bekleyen servisler/kontrolcüler tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, `DbSet<BookCategory>`, EF Core sorgulama API’leri.
- İlişkili tipler: `BookCategory`, `IBookCategoryRepository`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Asenkron metodlarda `CancellationToken` desteği yok.
- Her repository operasyonunda `SaveChangesAsync` çağrılması, çoklu işlem senaryolarında verimsizlik ve transaction kapsamı kontrolünün kaybına yol açabilir; Unit of Work yaklaşımı tercih edilebilir. 

---

Genel Değerlendirme
- Katmanlı yapı net: Domain kontratı ve Infrastructure implementasyonu ayrılmış.
- EF Core bağımlılığı doğrudan repository’ye yerleştirilmiş; bağlam yaşam döngüsü ve transaction yönetimi bu katmanda ele alınıyor.
- İptal belirteci ve birim-of-iş (UoW) eksikliği ölçeklenebilirlik ve tutarlılık açısından iyileştirilebilir alanlar.
- Konfigürasyon, hedef framework ve diğer projeler (Application/API) bu dosyadan görülemiyor; proje genelinde belgelendirme için ek kaynaklar gerekli.### Project Overview
- Proje adı: Library (çıkarım: namespace’lerden)
- Amaç: Kitap varlıkları için kalıcı veri erişimi sağlamak (Repository deseni üzerinden).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari örüntü: Katmanlı mimari (N‑Tier)
  - Domain: `Library.Domain.Entities`, `Library.Domain.Interfaces` — çekirdek varlıklar ve sözleşmeler.
  - Infrastructure: `Library.Infrastructure` — veri erişimi (EF Core, DbContext, repository implementasyonları).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — domain entity ve repository interface’leri.
  - Library.Infrastructure — EF Core tabanlı repository ve `DbContext` (namespace’ten çıkarım: `Library.Infrastructure.Data`).
- Kullanılan dış paket/çatı: Microsoft.EntityFrameworkCore (EF Core).
- Konfigürasyon gereksinimleri: `LibraryDbContext` için bağlantı dizesi tanımı gerekli; anahtar adları ve sağlayıcı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain (Entities, Interfaces)  <-- referenced by --  Infrastructure (Repositories, Data/DbContext)

---

### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`BookRepository`, `IBookRepository` sözleşmesini EF Core ile uygulayan veri erişim bileşenidir. Kitap varlığı (`Book`) üzerinde temel CRUD ve sorgulama işlemlerini gerçekleştirir. Mimari olarak Infrastructure veri erişim katmanında yer alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `Book` varlıkları için veri erişimi ve kalıcılık.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookRepository(LibraryDbContext context)` | `DbContext` bağımlılığını alır. |
| GetByIdAsync | `public Task<Book?> GetByIdAsync(Guid id)` | Bir kitabı birincil anahtarıyla getirir. |
| GetAllAsync | `public Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitapları listeler. |
| GetAvailableBooksAsync | `public Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable` true olan kitapları listeler. |
| GetByISBNAsync | `public Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre ilk eşleşen kitabı getirir. |
| AddAsync | `public Task AddAsync(Book entity)` | Yeni kitabı ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Book entity)` | Kitabı günceller ve değişiklikleri kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kitap varsa siler ve değişiklikleri kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Okuma işlemleri: `GetAvailableBooksAsync` `IsAvailable == true` filtresi uygular; `GetByISBNAsync` ISBN eşitliğine göre ilk kaydı getirir.
- Yazma işlemleri: `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` çalıştırarak kalıcılığı sağlar.
- `DeleteAsync` aranan kitap yoksa hiçbir işlem yapmaz; hata fırlatmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden `IBookRepository` olarak çözülüp application/service katmanından çağrılır.
- **Aşağı akış:** `LibraryDbContext` ve onun `Books` `DbSet<Book>` koleksiyonu.
- **İlişkili tipler:** `Book` (entity), `IBookRepository` (interface), `LibraryDbContext` (DbContext).

**7. Eksikler ve Gözlemler**
- İstek iptali için `CancellationToken` parametreleri yok.
- Okuma sorgularında `AsNoTracking()` kullanılmıyor; yalnızca okuma senaryolarında gereksiz izleme maliyeti oluşturabilir.
- Yazma işlemlerinde her metotta ayrı `SaveChangesAsync` çağrısı var; birim-iş (Unit of Work) ihtiyacı olan çoklu işlemlerde verimsiz ve dağınık olabilir.
- Eşzamanlılık (concurrency) için bir mekanizma gözükmüyor (ör. `RowVersion` veya `ConcurrencyToken` kullanımı bu dosyadan anlaşılmıyor).

---

Genel Değerlendirme
- Mimari, Domain ve Infrastructure arasında klasik katmanlı ayrımı izliyor; Repository deseni EF Core ile uygulanmış.
- DI ve interface tabanlı soyutlama doğru konumlandırılmış.
- Gözlemlenen iyileştirme alanları: CancellationToken desteği, okuma sorgularında `AsNoTracking()`, birim-iş ile toplu değişikliklerin tek seferde kaydı ve potansiyel eşzamanlılık kontrolleri. Konfigürasyon ve hedef framework detayları bu dosyadan çıkarılamıyor.### Project Overview
- Proje adı: Library
- Amaç: Müşteri varlıkları üzerinde veri erişim işlemlerini (CRUD ve sorgular) gerçekleştirmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture / N-Katmanlı yaklaşıma yakın. Domain katmanı (entity ve interface’ler) ile Infrastructure katmanı (EF Core tabanlı repository ve DbContext) ayrıştırılmış.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain: `Customer` entity’si ve `ICustomerRepository` kontratı.
  - Library.Infrastructure: `LibraryDbContext` ve EF Core tabanlı repository implementasyonları.
- Katman rolleri:
  - Domain: İş kuralları, entity’ler, repository kontratları.
  - Infrastructure: Kalıcı katman; EF Core ile veri erişimi ve repository implementasyonları.
- Kullanılan dış paketler/çerçeveler:
  - Microsoft.EntityFrameworkCore (EF Core)
- Konfigürasyon gereksinimleri:
  - Olası veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları mevcut olabilir; bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`Customer` varlığı için EF Core tabanlı repository implementasyonudur. Müşteri kaydı CRUD işlemleri ve çeşitli sorgular (e-posta, üyelik numarası, aktif müşteriler) sağlar. Infrastructure katmanında yer alır ve Domain’de tanımlı `ICustomerRepository` kontratını uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Customer` DbSet’i üzerinden veri erişimi ve `SaveChangesAsync` çağrıları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerRepository(LibraryDbContext context)` | DbContext’i enjekte eder. |
| GetByIdAsync | `Task<Customer?> GetByIdAsync(Guid id)` | Kimliğe göre müşteri döndürür; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<Customer>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre ilk eşleşeni döndürür; yoksa `null`. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre ilk eşleşeni döndürür; yoksa `null`. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive == true` olan müşterileri listeler. |
| AddAsync | `Task AddAsync(Customer entity)` | Yeni müşteri ekler ve `SaveChangesAsync` çağırır. |
| UpdateAsync | `Task UpdateAsync(Customer entity)` | Müşteriyi günceller ve `SaveChangesAsync` çağırır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kimliğe göre bulup müşteriyi siler; bulunduysa `SaveChangesAsync` çağırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular EF Core `FindAsync`, `FirstOrDefaultAsync`, `Where`, `ToListAsync` ile yapılır.
- Yazma operasyonları (`AddAsync`, `UpdateAsync`, `DeleteAsync`) içinde anında `SaveChangesAsync` çağrılır.
- `DeleteAsync` yalnızca kayıt bulunduğunda siler; bulunamazsa sessizce döner.
- Eşleşmeyen sorgular `null` döndürür (tekil getiriciler).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya handler’lar tarafından çağrılır.
- **Aşağı akış:** `LibraryDbContext`, `DbSet<Customer>`, EF Core uzantıları.
- **İlişkili tipler:** `Customer` (Domain entity), `ICustomerRepository` (Domain kontratı), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Repository yazma işlemlerinde her çağrıda `SaveChangesAsync` kullanımı, ünite-of-work desenini zorlaştırabilir ve çoklu yazma senaryolarında gereksiz transaction/parça parça commit’e yol açabilir. Bu, tutarlılık veya performans açısından gözden geçirilebilir. 

---

### Genel Değerlendirme
- Katmanlama net: Domain kontratları Infrastructure’da EF Core ile uygulanmış.
- Bağımlılık yönü doğru: Infrastructure, Domain’e bağımlı.
- Birim işlem ve transaction yönetimi repository içinde `SaveChangesAsync` ile yerel yapılmış; kapsamlı süreçlerde merkezi Unit of Work tercih edilebilir.
- Hata yönetimi ve iptal belirteci (`CancellationToken`) desteği görünmüyor; uzun süren işlemler veya iptal senaryoları için eklenmesi faydalı olabilir.
- Konfigürasyon ve DbContext ayarları bu parçadan görülemiyor; bağlantı dizesi ve sağlayıcı yapılandırmasının tutarlı olduğundan emin olunmalıdır.### Project Overview
Proje adı: Library. Amaç: kitap varlıklarını yönetmek için depo (repository) soyutlamalarının bir bellek içi (in-memory) uygulamasını sağlamak. Hedef çatı: .NET 8 (C# 12 koleksiyon kısayolu `[]` kullanımından çıkarım). Mimari olarak katmanlı yapı kullanılmıştır: Domain katmanı temel varlık ve arayüzleri barındırır; Infrastructure katmanı bu arayüzlerin somutlamalarını içerir.

Mimari desen: N‑Tier / Clean Architecture eğilimli
- Domain: `Book` gibi varlıklar ve `IBookRepository` gibi sözleşmeler.
- Infrastructure: Domain sözleşmelerinin in-memory implementasyonları (kalıcı olmayan depolama).
- (Varsayılan/öngörülen) Application/API: Bu depoyu tüketerek iş akışlarını ve uç noktaları sağlar; bu raporda kodu görünmüyor.

Projeler/Assembly’ler:
- Library.Domain — Varlıklar (`Book`) ve arayüzler (`IBookRepository`).
- Library.Infrastructure — Repository implementasyonları (ör. `InMemoryBookRepository`).

Harici paketler/çerçeveler: Bu dosyadan görünür bir dış bağımlılık yok.

Yapılandırma gereksinimleri: In‑memory uygulama olduğundan konfigürasyon/connection string gerektirmez (bu dosyadan çıkarım).

### Architecture Diagram
Presentation/API → Application → Infrastructure → Domain

Infrastructure → Domain (bağımlılık)
Application ↔ Domain (sözleşmeler üzerinden)
Presentation → Application

---

### `Library.Infrastructure/Repositories/InMemoryBookRepository.cs`

**1. Genel Bakış**
`InMemoryBookRepository`, `IBookRepository` sözleşmesini bellek içi bir `List<Book>` üzerinde uygular. Testler, prototip veya kalıcı depolama katmanı olmadan hızlı geliştirme senaryoları için tasarlanmıştır. Mimari olarak Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookRepository`
- Namespace: `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Verilen `Id` ile eşleşen kitabı döndürür. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitap koleksiyonunu döndürür. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları filtreleyerek döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen ISBN ile eşleşen ilk kitabı döndürür. |
| AddAsync | `Task AddAsync(Book entity)` | Kitabı listeye ekler. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Eşleşen `Id` bulunursa ilgili kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Eşleşen `Id` bulunursa kitabı listeden kaldırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm işlemler bellek içi `List<Book>` üzerinde çalışır; kalıcılık yoktur.
- `UpdateAsync`: `Id` bulunamazsa sessizce hiçbir işlem yapmaz; istisna fırlatmaz.
- `DeleteAsync`: Kayıt yoksa sessizce yok sayar; istisna fırlatmaz.
- `GetAvailableBooksAsync`: `Book.IsAvailable` alanına göre filtreler.
- Eşzamanlılık/iş parçacığı güvenliği sağlanmaz; `List<T>` paylaşımlı kullanımda yarış koşullarına açık olabilir.
- Doğrulama veya benzersizlik kontrolü (ör. ISBN) uygulanmaz.
- Task döndüren metotlar senkron çalışıp `Task.FromResult`/`Task.CompletedTask` ile sonuçlanır.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; Application servisleri veya testlerce çağrılır.
- Aşağı akış: `Library.Domain.Entities.Book`, `Library.Domain.Interfaces.IBookRepository`.
- İlişkili tipler: `Book`, `IBookRepository`.

**7. Eksikler ve Gözlemler**
- Eşzamanlı erişimde thread-safety eksik; paylaşımlı senaryolarda kilitleme gerekebilir.
- Kayıt bulunamadığında sessizce devam etme, hata yönetimini zorlaştırabilir; en azından geri bildirim döndürülmesi düşünülebilir.
- `CancellationToken` desteği yok; asenkron API’lerde iptal modeli eklenebilir.
- ISBN benzersizlik kontrolü ve temel doğrulamalar yok; veri tutarlılığı riskli olabilir.

---

Genel Değerlendirme
- Katmanlar arası bağımlılık yönü doğru: Infrastructure → Domain. Kod, Clean/N‑Tier mimariye uyuyor.
- Altyapı katmanı yalnızca in-memory uygulama sunuyor; üretim için kalıcı bir veri sağlayıcısı (ör. EF Core) eklenmesi beklenir.
- Hata yönetimi ve doğrulama minimal; Application katmanında veya repository implementasyonunda geliştirilmesi önerilir.
- Asenkron imzalar gerçek I/O içermiyor; gerçek veri kaynağına geçildiğinde `CancellationToken` ve istisna stratejileri eklenmeli.### Project Overview
Proje adı: Library. Amaç: Kütüphane personel verilerinin kalıcı katmanda yönetimi (CRUD ve sorgular). Hedef framework: Bu dosyadan anlaşılmıyor.

Mimari: Katmanlı/Clean Architecture eğilimli yapı. Domain katmanı (`Library.Domain`) entity ve sözleşmeleri barındırır; Infrastructure katmanı (`Library.Infrastructure`) kalıcılık/EF Core erişimini gerçekleştirir. Görünen katmanlar: Domain, Infrastructure.

Projeler/Assembly’ler:
- Library.Domain — Entity’ler (`Staff`) ve repository arayüzleri (`IStaffRepository`).
- Library.Infrastructure — EF Core `DbContext` (`LibraryDbContext`) ve repository implementasyonları (`StaffRepository`).

Harici paketler/çerçeveler:
- Microsoft.EntityFrameworkCore — Asenkron EF Core sorguları ve `DbContext` kullanımı.

Konfigürasyon gereksinimleri:
- `LibraryDbContext` için veritabanı sağlayıcısı ve bağlantı dizesi konfigürasyonu (appsettings ve DI üzerinden). Detaylar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`StaffRepository`, `IStaffRepository` arayüzünü EF Core ile gerçekleştiren kalıcılık katmanı bileşenidir. `Staff` entity’si üzerinde kimlik, e-posta ve aktiflik durumuna göre okuma, ekleme, güncelleme ve silme işlemleri sağlar. Altyapı (Infrastructure) katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Domain.Interfaces.IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `Staff` DbSet’i üzerinden CRUD ve sorgular.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffRepository(LibraryDbContext context)` | `LibraryDbContext` bağımlılığını alır. |
| GetByIdAsync | `public Task<Staff?> GetByIdAsync(Guid id)` | `Id` ile tek personeli getirir. |
| GetAllAsync | `public Task<IEnumerable<Staff>> GetAllAsync()` | Tüm personel listesini döner. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | E-postaya göre ilk eşleşeni getirir. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive` olan personelleri listeler. |
| AddAsync | `public Task AddAsync(Staff entity)` | Yeni personeli ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Staff entity)` | Personeli günceller ve değişiklikleri kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Varsa personeli siler ve değişiklikleri kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Ekleme, güncelleme ve silme işlemlerinde `SaveChangesAsync()` çağrılır; her çağrı kendi başına persist eder.
- `DeleteAsync` belirtilen `id` bulunamazsa hiçbir işlem yapmaz; exception fırlatmaz.
- `GetByEmailAsync` ilk eşleşeni döner; birden çok kayıt varsa deterministik olarak ilkini seçer.
- `GetActiveStaffAsync` yalnızca `IsActive == true` olanları döner.
- İyileştirme alanı: İptal belirteci (CancellationToken) desteği yok; eşzamanlılık/versiyonlama ele alınmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak uygulama hizmetleri/komut işleyicileri çağırır.
- Aşağı akış: `LibraryDbContext` ve `DbSet<Staff>`.
- İlişkili tipler: `Library.Domain.Entities.Staff`, `Library.Domain.Interfaces.IStaffRepository`, `Library.Infrastructure.Data.LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` eksik.
- Repository içinden `SaveChangesAsync` çağrısı, Unit of Work yaklaşımıyla çelişebilir; çok adımlı işlemlerde transaction yönetimi zorlaşır.
- Hata/istisna sarmalama veya logging yok; başarısızlık durumlarında üst katmana zengin bağlam aktarılmıyor.
- Sorgularda sayfalama/filtreleme genişletilebilirlik kısıtlı; `GetAllAsync` potansiyel olarak büyük veri döndürebilir.

---

### Genel Değerlendirme
Kod, net bir Infrastructure/Repository uygulaması sunuyor ve EF Core’u asenkron kullanıyor. Bununla birlikte, Unit of Work deseninin ayrıştırılmaması, `CancellationToken` eksikliği ve büyük veri setlerinde sayfalama/filtreleme yokluğu mimari olgunluk açısından geliştirme alanlarıdır. Eşzamanlılık ve alan bazlı güncelleme (partial update) stratejileri, hata yönetimi ve logging ile desteklenirse daha üretim-odaklı hale gelir.### Project Overview
- Ad: Library (ASP.NET Core Web API). Amaç: Kitap kategori verilerini HTTP üzerinden sunmak. Hedef çerçeve: .NET 6+ (ASP.NET Core), koddan anlaşılan.
- Mimari: Katmanlı (N-Tier/Clean benzeri). Presentation (API/Controllers) katmanı `Library.Application` katmanındaki servis ve DTO’ları kullanıyor.
- Projeler/Assembly’ler:
  - Library: API/Presentation; HTTP endpoint’lerini barındırır.
  - Library.Application: Uygulama katmanı; `DTO` ve `IBookCategoryService` arayüzü sağlanır.
- Harici paket/çerçeveler: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon: Bu dosyadan anlaşılan bir connection string veya app settings anahtarı yok.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için HTTP endpoint’leri sağlar. API/Presentation katmanında yer alır ve uygulama katmanındaki `IBookCategoryService` üzerinden veri erişimini soyutlar. Şu an listeme ve tekil getirme işlemlerini destekler.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori verileri için uygulama katmanı servisi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını enjekte eder. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategori listesini döndürür; `200 OK` ile sonuçları gönderir. |
| GetById | `public async Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID ile kategori getirir; bulunamazsa `404 NotFound`, varsa `200 OK` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GET /api/BookCategories`: Uygulama servisi üzerinden tüm kategorileri getirir, sonuçları `Ok(...)` ile döndürür.
- `GET /api/BookCategories/{id:guid}`: `Guid` route kısıtı ile geçerli format zorlanır; servis `null` dönerse `NotFound()` üretir.
- Controller `ApiController` özniteliği ile model bağlama ve otomatik 400 davranışları etkin (bu dosyada ek model giriş yok).

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (frontend, Postman vb.) bu controller’ı çağırır.
- **Aşağı akış:** `IBookCategoryService`
- **İlişkili tipler:** `BookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- CRUD’a kıyasla `POST/PUT/DELETE` endpoint’leri eksik.
- Endpoint’lerde yetkilendirme/authorization öznitelikleri yok; güvenlik ihtiyacı varsa eklenmeli.
- Servis çağrılarında hata yönetimi/loglama görünmüyor; beklenmedik istisnalar için global exception handling veya filtre önerilir.

---
### Genel Değerlendirme
Kod, API katmanının uygulama katmanındaki servis ve DTO’lara bağımlı olduğu net bir katmanlı yapı sergiliyor. Mevcut kapsam sadece listeleme ve tekil getirme ile sınırlı; tipik CRUD tam değil. Güvenlik (authorization) ve kapsamlı hata yönetimi görünmüyor; üretim senaryolarında policy tabanlı yetkilendirme, global exception middleware ve loglama eklenmesi önerilir.### Project Overview
- Proje adı: Library
- Amaç: Kitaplara yönelik CRUD ve sorgulama işlemlerini HTTP API üzerinden sunmak.
- Hedef framework: ASP.NET Core Web API üzerinde .NET; kesin sürüm bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (N‑Tier). Katmanlar:
  - API/Presentation: HTTP endpoint’leri, istek/yanıt sözleşmeleri ve durum kodlarını yönetir.
  - Application: İş kuralları ve kullanım senaryoları; `IBookService` ile servis sözleşmesi ve `DTO`’lar.
- Keşfedilen projeler/assembly’ler:
  - Library (API/Presentation) — `Library.Controllers`
  - Library.Application (Application) — `Library.Application.DTOs`, `Library.Application.Interfaces`
- Kullanılan dış paket/çerçeveler:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`). Diğerleri bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string, appsettings anahtarları görünmüyor).

### Architecture Diagram
API/Presentation (Library.Controllers)
  ↓ depends on
Application (Library.Application.DTOs, Library.Application.Interfaces)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplar için HTTP tabanlı CRUD ve sorgulama endpoint’leri sağlar. API/Presentation katmanına aittir ve `IBookService` üzerinden Application katmanındaki iş mantığına delegasyon yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplara yönelik iş operasyonlarını yürütür (listeleme, getirme, oluşturma, güncelleme, silme).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BooksController(IBookService bookService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döner. 200 OK. |
| GetById | `public async Task<ActionResult<BookDto>> GetById(Guid id)` | Id’ye göre kitabı döner; yoksa 404. |
| GetAvailable | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Müsait kitapları döner. 200 OK. |
| Create | `public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Kitap oluşturur; 201 Created ve Location header ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Günceller; başarıda 204, bulunamazsa 404. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Siler; 204 döner. Hata eşlemesi bu dosyada yok. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction(nameof(GetById), new { id = book.Id }, book)` ile 201 ve konum başlığı.
- `Update`: `IBookService.UpdateAsync` içinde fırlatılan `KeyNotFoundException` 404’e çevrilir; diğer hatalar ele alınmıyor.
- `Delete`: Servis çağrılır ve 204 NoContent döner; bulunamama veya hata durumları özel olarak eşlenmiyor.
- `[ApiController]`: Model binding/validation hatalarında otomatik 400 üretimi (DTO üzerindeki validasyonlar bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (ör. front-end, Postman).
- Aşağı akış: `IBookService`.
- İlişkili tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde `[Authorize]` veya benzeri yetkilendirme görünmüyor; güvenlik gereksinimleri varsa eksik olabilir.
- `Delete` için bulunamayan kaynak durumda 404 eşleme yapılmıyor; servis katmanındaki hata sinyali API seviyesine yansıtılmıyor olabilir.

---
Genel Değerlendirme
- Katman ayrımı net: API katmanı Application’a bağımlı, domain/infrastructure görünmüyor.
- Hata eşleme kısmen tutarlı: `Update` 404 eşliyor, `Delete` eşlemiyor; tutarlılık artırılabilir.
- Güvenlik/Yetkilendirme anotasyonları görünmüyor; ihtiyaç varsa eklenmeli.
- Konfigürasyon ve altyapı bağımlılıkları bu örnekten çıkarılamıyor; belgelendirme için appsettings ve Application/Infrastructure detayları eklenmeli.### Project Overview
- Proje adı: Library (ASP.NET Core Web API). Amaç: müşteri yönetimi için HTTP API uç noktaları sağlamak (listeleme, detay, aktif müşteriler, oluşturma, güncelleme, silme). Hedef framework bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı (N-Tier). Sunum katmanı (`Library.Controllers`) Application katmanındaki servis arayüzlerine (`Library.Application.Interfaces`) ve DTO’lara (`Library.Application.DTOs`) bağımlı.
- Projeler/Assembly’ler:
  - Library (API/Presentation): Controller’ları barındırır.
  - Library.Application (Application): DTO’lar ve servis arayüzleri (koddan anlaşıldığı kadarıyla).
- Dış bağımlılıklar:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon: Bu dosyadan spesifik ayar anahtarları veya connection string bilgisi anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  -> Library.Application.Interfaces
  -> Library.Application.DTOs

---

### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri ile ilgili CRUD benzeri işlemler ve filtreleme (aktif müşteriler) için HTTP uç noktaları sunar. Sunum katmanındadır ve `ICustomerService` üzerinden Application katmanına çağrı yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri verileri için listeleme, sorgulama ve CRUD işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public CustomersController(ICustomerService customerService)` | `ICustomerService` bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döndürür. |
| GetById | `public Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID ile müşteri getirir; yoksa 404 döner. |
| GetActive | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döndürür. |
| Create | `public Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Yeni müşteri oluşturur; 201 ve konum başlığı ile döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Mevcut müşteriyi günceller; yoksa 404, başarılıysa 204 döner. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretir.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer)` ile 201 ve kaynak konumu döner.
- `Update`: `KeyNotFoundException` yakalanır ve 404 döndürülür; diğer hatalar üst katmana yükselir.
- `Delete`: Her durumda `NoContent()` döner; servis tarafında fırlatılabilecek istisnalar burada ele alınmıyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri); DI üzerinden çözümlenir.
- **Aşağı akış:** `ICustomerService`; DTO’lar: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.
- **İlişkili tipler:** `ICustomerService` (Application), ilgili DTO’lar (Application).

**7. Eksikler ve Gözlemler**
- Güvenlik: Yetkilendirme/kimlik doğrulama öznitelikleri yok (`[Authorize]` vb.); tüm uç noktalar herkese açık görünüyor.
- Hata yönetimi: `Delete` ve `Create` için özel hata yakalama yok; servis `KeyNotFoundException` fırlatırsa global middleware yoksa 500’e dönebilir.
- Validasyon: Model state kontrolü yapılmıyor (`ModelState.IsValid` veya `ApiController` otomatik validasyonuna güveniliyor); özel doğrulama/iş kuralı kontrolleri görünmüyor.

---

### Genel Değerlendirme
- Katmanlaşma net: API, Application arayüz ve DTO’larına bağımlı. Domain/Infrastructure katmanları bu dosyadan görülemiyor.
- Controller eylemleri REST ilkelerine genel olarak uygun (200/201/204/404). Hata haritalaması kısmen tutarlı; `Update` için var, `Delete` için yok.
- Güvenlik ve yetkilendirme görünmüyor; üretim ortamında endpoint’ler için `[Authorize]` ve kapsam bazlı kontrol önerilir.
- Tutarlı bir global hata işleme/exception mapping stratejisi (ör. middleware) önerilir; controller bazlı parça parça try-catch yerine merkezi yaklaşım tercih edilebilir.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane personel yönetimi için HTTP API uç noktaları sağlamak (CRUD ve aktif personel sorgulama).
- Hedef Framework: ASP.NET Core Web API (modern .NET, tam sürüm bu dosyadan anlaşılmıyor).
- Mimari Desen: Katmanlı mimari (API/Presentation → Application). Controller, `Library.Application.DTOs` ve `Library.Application.Interfaces` üzerinden Application katmanına bağlanıyor.
- Projeler/Assembly’ler:
  - Library (API/Presentation): HTTP endpoint’leri, controller’lar.
  - Library.Application (Application): `DTO`’lar ve `IStaffService` servis kontratı (iş kuralları ve uygulama servisleri).
- Harici Paket/Çatılar: ASP.NET Core MVC (`ApiController`, routing, `ControllerBase`). Diğer bağımlılıklar (ör. EF Core, MediatR) bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan herhangi bir connection string veya app settings anahtarı görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---

### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel varlıkları için RESTful uç noktalar sağlar: listeleme, ID ile getirme, aktifleri getirme, oluşturma, güncelleme ve silme. Presentation/API katmanındadır ve uygulama servislerine `IStaffService` aracılığıyla delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel için uygulama servis katmanı; CRUD ve filtreli sorguları yürütür.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetAll | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli döndürür. |
| GetById | `public async Task<ActionResult<StaffDto>> GetById(Guid id)` | ID ile personeli getirir; yoksa 404 döner. |
| GetActive | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döndürür. |
| Create | `public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; 201 ve konum başlığı döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; bulunamazsa 404, aksi halde 204 döner. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Personeli siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse 404 NotFound.
- `Create`: `CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff)` ile 201 ve kaynak konumu üretir.
- `Update`: `KeyNotFoundException` yakalanır ve 404 döner; başarıda 204 NoContent.
- `Delete`: 204 NoContent döner; bulunamama durumu bu düzeyde ele alınmıyor (servis tarafına bırakılmış).
- Model doğrulama, yetkilendirme ve iptal belirteci kullanımı bu dosyada tanımlı değil.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (API tüketicileri); DI üzerinden çözülür.
- Aşağı akış: `IStaffService`
- İlişkili tipler: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`

**7. Eksikler ve Gözlemler**
- Yetkilendirme öznitelikleri yok; tüm endpoint’ler herkese açık görünüyor (güvenlik riski olabilir).
- `Delete` için bulunamama durumunda hata eşlemesi yok; servis istisnası API katmanında 404’e çevrilmiyor olabilir.
- ModelState doğrulaması açıkça kontrol edilmiyor; geçersiz `DTO`’lar için davranış belirsiz.
- İptal belirteci (`CancellationToken`) desteklenmiyor.
- Liste uç noktalarında sayfalama/sıralama/filtreleme yok; yüksek veri hacminde performans etkisi olabilir.

---

### Genel Değerlendirme
Kod tabanı katmanlı bir yapı izliyor: Controller yalnızca Application katmanındaki servis arayüzüne ve DTO’lara bağımlı. API düzeyinde tutarlı hata eşlemesi kısmen var (`Update` için 404), ancak `Delete` ve diğer operasyonlarda bulunamama/iş kuralı ihlallerine yönelik standartlaştırma eksik. Yetkilendirme ve model doğrulama görünmüyor; güvenlik ve doğruluk açısından eklenmeli. İptal belirteçleri ve listeleme için sayfalama/sıralama gibi çapraz kesen endişeler adreslenmemiş. Diğer katmanlar (Domain/Infrastructure) bu girdiden görülmediği için tam mimari resmi sınırlı.### Project Overview
Proje adı muhtemelen “Library” ve bir ASP.NET Core Web API ana sunucu projesi olarak çalışır. Amaç, `Application` ve `Infrastructure` katmanlarını DI yoluyla başlatıp HTTP endpoint’leri üzerinden servis etmektir. Hedef framework, minimal hosting modeli ve `Swagger` entegrasyonundan ötürü .NET 6+ (ASP.NET Core) olarak çıkarılabilir.

Mimari desen, katmanlı ve Clean Architecture’a yakın bir düzen izler: API (sunum) katmanı, `Application` ve `Infrastructure` katmanlarını başlatır. İş kuralları ve uygulama servislere `Application`, dış bağımlılıklar ve veri erişimi `Infrastructure` içindedir.

Keşfedilen projeler/assemblies:
- Library (API/Host): Web API giriş noktası, middleware ve endpoint haritalama.
- Library.Application: Uygulama hizmetleri ve iş kuralları için DI kayıtları (detaylar bu dosyadan görülmüyor).
- Library.Infrastructure: Kalıcılaştırma, dış kaynaklar ve teknik altyapı DI kayıtları (detaylar bu dosyadan görülmüyor).

Dış bağımlılıklar:
- Swashbuckle/Swagger (OpenAPI dokümantasyonu)

Yapılandırma gereksinimleri:
- `AddInfrastructure(builder.Configuration)` çağrısı yapılandırma kullanır; spesifik anahtarlar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Host)
  ├─> Library.Application
  └─> Library.Infrastructure

Not: `Application` ile `Infrastructure` arasındaki olası bağımlılık yönü bu dosyadan anlaşılmıyor.

---
### `Library/Program.cs`

**1. Genel Bakış**
Uygulamanın giriş noktası ve composition root’tur. ASP.NET Core hizmet kayıtlarını, `Application` ve `Infrastructure` katmanlarının DI entegrasyonunu, middleware hattını ve controller eşlemelerini yapılandırır. Sunum/API katmanına aittir.

**2. Tip Bilgisi**
- Tip: top-level program (global statements)
- Miras: Yok
- Uygular: Yok
- Namespace: bu dosyada açık bir namespace bildirilmemiş

**3. Bağımlılıklar**
- Harici bağımlılık yok.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Yok | — | Top-level program; public/protected üye tanımı içermez. |

**5. Temel Davranışlar ve İş Kuralları**
- `builder.Services.AddApplication()` ve `builder.Services.AddInfrastructure(builder.Configuration)` ile uygulama ve altyapı katmanları DI’a eklenir.
- `AddControllers`, `AddEndpointsApiExplorer`, `AddSwaggerGen` ile Web API ve Swagger bileşenleri yapılandırılır.
- Geliştirme ortamında `UseSwagger` ve `UseSwaggerUI` etkinleştirilir.
- `UseHttpsRedirection` ile HTTP’den HTTPS’e yönlendirme yapılır.
- `UseAuthorization` middleware’i eklenir (policy/handler detayları bu dosyadan anlaşılmıyor).
- `MapControllers()` ile attribute-routed controller endpoint’leri haritalanır.
- `app.Run()` uygulamayı başlatır.

**6. Bağlantılar**
- Yukarı akış: Process giriş noktası; DI üzerinden çözümlenir.
- Aşağı akış: `Library.Application` ve `Library.Infrastructure` (DI kayıtları), Swagger/Endpoints/Middleware.
- İlişkili tipler: `ServiceCollectionExtensions` benzeri `AddApplication`/`AddInfrastructure` genişletme metodları (detaylar bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- `UseAuthentication` yok; sadece `UseAuthorization` var. Kimlik doğrulama gerekiyorsa middleware sırası eksik olabilir.
- Üretim ortamında Swagger kapalı; bu bilinçli olabilir ancak belirsiz.

---
Genel Değerlendirme
- Katmanlar net biçimde ayrılmış; API katmanı DI üzerinden `Application` ve `Infrastructure`’ı başlatıyor.
- Güvenlik hattında yalnızca authorization kullanımı görünüyor; kimlik doğrulama ihtiyacı varsa ek middleware ve konfigürasyon gerekli.
- `Infrastructure` konfigürasyon anahtarları belirsiz; dokümantasyonda bağlantı dizeleri ve gerekli appsettings anahtarlarının belirtilmesi önerilir.
- Uygulama ve altyapı katmanlarının içerikleri bu depodan görülemiyor; DI kayıtlarının kapsamı ve dış bağımlılıklar (ör. EF Core) teyit edilemez.