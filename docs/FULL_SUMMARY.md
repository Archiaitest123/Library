### Project Overview
Proje adı, koddaki namespace’ten “Library” olarak anlaşılmaktadır. Amaç, bir kütüphane alanına ait uygulama katmanında veri transfer nesneleri (DTO) sağlamaktır. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari olarak çok katmanlı/Clean-vari bir yapı işaret edilmektedir; `Library.Application` ad uzayı uygulama katmanını temsil eder. Keşfedilen proje/assembly: “Library.Application” — rolü: uygulama katmanında DTO’lar ve muhtemel uygulama hizmetlerine veri taşıma. Görünen harici paket veya framework referansı yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  (diğer katmanlara dair bağımlılık akışı bu dosyadan anlaşılmıyor)

---
### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisi bilgisini (Id, `Name`, `Description`) taşıyan basit bir veri transfer nesnesidir. Uygulama katmanında, alan modelleri ile sunum/taşıma katmanları arasında veri şekillendirmek için kullanılır.

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
| Id | `public Guid Id { get; set; }` | Kategori için benzersiz kimlik. |
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görünmektedir; diğer katmanlar (Domain, Infrastructure, API) bu örnekten çıkarılamıyor.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları belirsiz.
- DTO’larda temel default değerlerin verilmesi olumlu; ancak validasyon kuralları veya daha zengin sözleşmeler (ör. `required` üyeler, veri ek açıklamaları) görünmüyor.### Project Overview
Proje adı: Library (adlandırmadan çıkarım). Amaç: Kitap bilgilerini katmanlı bir yapıda taşımak ve sunmak için uygulama katmanında DTO sağlamak. Hedef framework: Bu dosyadan anlaşılmıyor. Mimari olarak “Application” isimli bir katman bulunduğundan çok katmanlı/Clean Architecture benzeri bir yapı ima ediliyor.

Mimari desen: Katmanlı/Clean Architecture benzeri.
- Application: İş kuralları, use-case’ler ve aktarım modelleri (DTO’lar). Bu dosya burada.
Diğer katmanlar (Domain, Infrastructure, API/Presentation) bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Application: Uygulama katmanı; DTO ve muhtemel servis/handler’lar.

Harici paketler/çatı: Bu dosyadan anlaşılmıyor (görünür bağımlılık yok).

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)

---
### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitapla ilgili temel bilgileri uygulama katmanında taşımak için kullanılan bir veri aktarım nesnesidir. Sunum ve uygulama katmanları arasında veri sözleşmesi sağlar. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygılar:** Yok
- **Namespace:** `Library.Application.DTOs`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Id | `public Guid Id { get; set; }` | Kitabın benzersiz kimliği. |
| Title | `public string Title { get; set; }` | Kitap başlığı. |
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcudiyet durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | Kategori adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`. Diğer alanlar tiplerinin default değerlerini alır (`Guid.Empty`, `0`, `false`, `null`).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sadece Application katmanındaki bir DTO görünür durumda; diğer katmanlar ve akışlar bu veriyle doğrulanamıyor.
- Doğrulama/iş kuralları DTO’da yer almıyor; beklenen şekilde davranışsız.
- Hedef framework, konfigürasyon anahtarları ve harici paket kullanımı bu dosyadan tespit edilemiyor.### Project Overview
Proje adı: Library  
Amaç: Uygulama katmanında veri aktarım nesneleri (DTO) sağlamak; özellikle kitap kategorisi oluşturma verilerini taşımak.  
Hedef framework: Bu dosyadan anlaşılmıyor.  
Mimari desen: Namespace yapısı “katmanlı/Clean Architecture” eğilimi gösteriyor (Application katmanı mevcut), ancak bu dosyadan kesin değildir.  
Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case’lere yönelik kontratlar için.
Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor.  
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Çağıranlar (UI/API/Service) — bilinmiyor] -> [Library.Application (DTOs)]

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, kitap kategorisi oluşturma senaryosunda istemciden alınacak veya katmanlar arasında taşınacak verileri temsil eden bir DTO’dur. Uygulama (Application) katmanına aittir ve komut/işlem giriş modelidir.

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
- **Yukarı akış:** API/Command handler gibi katmanlar tarafından istek verisi olarak kullanılması muhtemel (bu dosyadan kesin değil).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemel eşleşen domain entity’si (ör. `BookCategory`) — bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanına ait bir DTO görülüyor. Model üzerinde validasyon öznitelikleri veya ayrık bir validasyon mekanizması (ör. FluentValidation) görünmüyor; validasyonun nerede yapıldığı bu dosyadan anlaşılamıyor. Mimari, olası katmanlı/Clean Architecture düzenine işaret etse de Domain, Infrastructure veya API katmanlarına dair kanıt bulunmuyor.### Project Overview
- Proje adı: Library (namespace’ten çıkarım)
- Amaç: Kitap yönetimi alanında uygulama katmanında kullanılan veri aktarım nesnelerini (DTO) sağlamak.
- Hedef çatı: Bu dosyadan net değil; standart .NET (muhtemelen .NET 6+ veya .NET Standard/ .NET) — kesin değil.
- Mimari: Bu dosyadan kesinleşmiyor; ancak `Library.Application` ad alanı, katmanlı/Clean Architecture benzeri yapıda Application katmanı olarak konumlanır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve olası use case sözleşmeleri.
- Harici paketler/çatı: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
[Library.Application]  (diğer katmanlar bu dosyadan görünmüyor)

---
### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, bir kitabın oluşturma işlemi sırasında gerekli alanları taşımak için kullanılan basit bir DTO’dur. Uygulama (Application) katmanında, komut/işlem işleyicilerine veya API katmanına veri sözleşmesi sağlar.

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
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İsteğe bağlı kategori kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0` (int için .NET varsayılanı), `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (muhtemelen API istek modelleri veya uygulama komutları/işleyicileri).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
- Kod sadece bir DTO içerdiğinden mimari ve bağımlılıklar hakkında sınırlı bilgi mevcut.
- Validasyon kuralları (ör. boş başlık, geçerli ISBN formatı, yıl aralığı) DTO düzeyinde bulunmuyor; bu normal olabilir ancak ilgili katmanlarda doğrulama beklenir.
- Hedef framework, diğer katmanlar (Domain, Infrastructure, API) ve paket kullanımları bu dosyadan tespit edilemiyor.### Project Overview
- Proje adı: Library (isimlendirmeden çıkarım)
- Amaç: Uygulama katmanında müşteri oluşturma senaryosu için veri taşıma nesnesi (DTO) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: İsimlendirme, katmanlı/temiz mimari (Application katmanı) kullanımına işaret ediyor. Katman rolleri (çıkarım):
  - Application: Use case’ler, DTO’lar, iş kuralları koordinasyonu.
  - Diğer katmanlar (Domain, Infrastructure, API) bu dosyadan teyit edilemiyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve muhtemel use case’ler.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  └─ (DTO’lar)
Bağımlılık akışı bu dosyadan görünmüyor; `Library.Application` içinde tek başına DTO tanımı mevcut.

---
### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, yeni bir müşteri oluşturma işlemi için gerekli temel alanları taşıyan basit bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve API/handler gibi üst katmanlar ile domain/servis işlemleri arasında giriş verisini standartlaştırır.

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
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşterinin e‑posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adresi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod yalnızca bir DTO içeriyor; validasyon, mapping veya iş kuralları görünmüyor. 
- Mimari yapı isimlendirme ile Application katmanını ima ediyor; diğer katmanlar ve bağımlılıklar bu veriyle tespit edilemiyor.
- E‑posta/telefon gibi alanlar için format doğrulaması veya zorunluluk bilgisi kod seviyesinde bulunmuyor; bu doğrulamalar muhtemelen başka bir katmanda ele alınmalıdır.### Project Overview
Bu depo, `Library.Application` ad alanında konumlanan bir uygulama katmanı parçasını içerir. Gösterilen tek tip `CreateStaffDto` olup, personel oluşturma operasyonlarında kullanılacak veri taşıyıcı (DTO) olarak hizmet eder. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak en azından katmanlı bir yapı (Application katmanı) kullanıldığı anlaşılıyor; diğer katmanlar (Domain, Infrastructure, API) bu dosyadan çıkarılamıyor.

- Mimari desen: Katmanlı mimari (en azından Application katmanı). Application, dışa dönük sözleşmeler ve akışlar için DTO’ları tanımlar.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel hizmet sözleşmeleri.
- Kullanılan dış paketler/çatı yapıları: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]
  (tek katman görülebiliyor; diğer bağımlılıklar bu dosyadan anlaşılmıyor)

---
### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, yeni bir personel kaydı oluşturmak için gerekli temel alanları taşıyan basit bir DTO’dur. Uygulama katmanına aittir ve muhtemelen komut/handler veya API katmanındaki istek modelleri ile kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Personelin adı; varsayılan `string.Empty`. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı; varsayılan `string.Empty`. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi; varsayılan `string.Empty`. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası; varsayılan `string.Empty`. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu; varsayılan `string.Empty`. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi; `DateTime` default değeri başlangıçta `default(DateTime)`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `HireDate = default(DateTime)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- `HireDate` için default `DateTime` değeri anlamlı olmayabilir; `DateTime?` kullanımı veya zorunlu alan validasyonu gerekebilir.
- Email/Phone format validasyonu veya zorunluluk kuralları bu DTO üzerinde tanımlı değil; validasyon stratejisi (ör. FluentValidation, DataAnnotations) görünmüyor.

Genel Değerlendirme
- Kod tabanından yalnızca Application katmanındaki bir DTO görünüyor; mimarinin geri kalanı ve bağımlılıklar net değil.
- Validasyon stratejisi belirgin değil; DTO seviyesinde annotation veya ayrı validatörlerin tanımlanması önerilir.
- Tarih alanları için `DateTime` yerine `DateTimeOffset` veya `DateOnly` (hedef çatıya bağlı) düşünülerek zaman dilimi/semantik netleştirilebilir.
- Null/empty yönetimi tutarlı; ancak zorunlu alanlar için domain veya application seviyesinde kuralların varlığı teyit edilmeli.### Project Overview
- Proje adı: Library (isimlendirme ve namespace’lerden çıkarım)
- Amaç: Uygulamanın Application katmanında müşteri verilerini taşımak için DTO tanımı sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Temiz Mimari’yi çağrıştıran adlandırma (Application katmanı). Diğer katmanlar bu dosyadan kesinleşmiyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Application: Uygulama katmanı; DTO’lar ve muhtemel use-case/servis sözleşmeleri.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri bilgilerinin katmanlar arasında güvenli ve sade şekilde taşınması için kullanılan veri aktarım nesnesidir. Application katmanına aittir ve muhtemel use-case’ler ile sunum/arayüz katmanı arasında veri sözleşmesi görevi görür.

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
| Id | `public Guid Id { get; set; }` | Müşterinin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres bilgisi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Üyeliğin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `RegisteredDate = default`, `IsActive = default(false)`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanına dair görünürlük sınırlı; yalnızca Application katmanında bir DTO mevcut. Hedef framework, paketler, diğer katmanlar (Domain/Infrastructure/API) ve akışlar bu dosyadan doğrulanamıyor. DTO isimlendirmesi ve konumu Clean Architecture benzeri bir katmanlamayı işaret etse de, diğer katmanların kontratları ve kullanım bağlamları görülmediği için mimari tutarlılık ve bütünlük değerlendirilemiyor.### Proje Genel Bakış
- Proje adı: Library (ad, namespace’ten çıkarılmıştır)
- Amacı: Uygulama katmanında kütüphane personeline ait veri transferini sağlamak (DTO).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (uygulama katmanı). Görünen katman: Application. Bu katman, dış katmanlar ile domain/iş mantığı arasında veri aktarım nesnelerini ve uygulama-odaklı tipleri barındırır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama hizmetleri/iş akışları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (DTOs)

---

### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, kütüphane personeline ilişkin temel alanları taşıyan bir veri transfer nesnesidir. Uygulama katmanında, personel bilgilerinin katmanlar arası taşınması için kullanılır.

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
| Id | `public Guid Id { get; set; }` | Personelin benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Personelin adı. |
| LastName | `public string LastName { get; set; }` | Personelin soyadı. |
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanında yalnızca `Library.Application` altında bir DTO görünmektedir. Katmanlar arası model dönüşümü, validasyon veya mapping detayları bu dosyadan çıkarılamıyor. Ek dosyalar olmadan hedef framework, dış bağımlılıklar ve konfigürasyon gereksinimleri belirlenememektedir. DTO varsayılan string alanları boş dizeyle başlar; bu, null referansları önlemeye yardımcı olur.### Project Overview
- Proje Adı: Library
- Amaç: Uygulama katmanında kitap kategorisi güncelleme işlemlerine yönelik veri taşıma nesnesi (DTO) sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı/Clean benzeri ayrım; mevcut dosya `Application` katmanını temsil ediyor.
- Keşfedilen Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve muhtemel iş akışları için sözleşmeler.
- Kullanılan Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Application (Library.Application)]

---

### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisi güncelleme işlemi için istemci veya üst katmanlardan gelen veriyi taşımak amacıyla kullanılır. Uygulama (Application) katmanına aittir ve davranış içermez.

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
| Name | `public string Name { get; set; }` | Kategori adını taşır; varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklamasını taşır; varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanından bir DTO görülebiliyor. Mimari desen, adlandırmadan katmanlı/Clean ayrımı izlenimi verse de başka katmanlar (Domain, Infrastructure, API) bu dosyadan doğrulanamıyor. Doğrulama kuralları, mapping/handler katmanları ve kalıcı modele ilişkin detaylar görünmüyor; bu alanların varlığı ve tutarlılığı diğer dosyalara bağlıdır.### Project Overview
- Proje Adı: Library (namespace’ten çıkarım)
- Amaç: Kütüphane alanındaki uygulama mantığında kullanılan veri taşıma nesnelerini (DTO) sağlamak; özellikle kitap güncelleme senaryolarını desteklemek.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Örüntü: Katmanlı/Clean vari yaklaşım sinyali (Application katmanı mevcut). Application katmanı, UI/Presentation ve Domain/Infrastructure arasında sözleşme/aktarım modelleri sağlar.
- Keşfedilen Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanına ait DTO’lar ve muhtemel sözleşme tipleri.
- Dış Bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)

---

### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
`UpdateBookDto`, bir kitabın güncelleme operasyonu için gerekli alanları taşıyan basit bir DTO’dur. Application katmanında yer alır ve üst katmanlardan (örn. API) gelen veriyi iş kurallarına veya veri erişim katmanına iletmek için kullanılır.

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
| Title | `public string Title { get; set; }` | Kitabın başlığı. |
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN değeri. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Kitabın müsaitlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `IsAvailable = false`, `BookCategoryId = null`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (genellikle güncelleme komutları/endpoint’leri kullanır).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor (muhtemelen bir `Book` entity’si veya güncelleme komutu ile eşleşir).

---

### Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir DTO dosyasını içeriyor. Mimari bütünlük (Domain, Infrastructure, API katmanları, komut/sorgu işleyicileri) bu veriden doğrulanamıyor. Girdi doğrulama, iş kuralları veya hata yönetimi bu DTO’da doğal olarak bulunmuyor; bunların ilgili service/handler seviyelerinde ele alınması beklenir. Dış bağımlılıklar ve konfigürasyon anahtarları tespit edilemedi.### Project Overview
- Proje Adı: Library (isim, namespace’ten çıkarılmıştır)
- Amaç: Uygulama katmanında müşteri güncelleme işlemleri için veri taşıma nesnesi (DTO) sağlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Örüntü: Katmanlı mimari izlenimi (Application katmanı mevcut). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen Proje/Assembly: 
  - Library.Application — Uygulama katmanı; DTO tanımları içeriyor.
- Dış Bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTOs)
↑ (yukarıdan kimlerin kullandığı bu dosyadan anlaşılmıyor)
↓ (aşağı bağımlılık yok)

---
### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, müşteri güncelleme isteklerinde kullanılan alanları (ad, soyad, e-posta, telefon, adres, aktiflik) taşıyan bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve API ile uygulama hizmetleri arasında sözleşme görevi görür.

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
| FirstName | `public string FirstName { get; set; } = string.Empty` | Müşterinin adı. Boş string varsayılan. |
| LastName | `public string LastName { get; set; } = string.Empty` | Müşterinin soyadı. Boş string varsayılan. |
| Email | `public string Email { get; set; } = string.Empty` | Müşterinin e-posta adresi. Boş string varsayılan. |
| Phone | `public string Phone { get; set; } = string.Empty` | Müşterinin telefon numarası. Boş string varsayılan. |
| Address | `public string Address { get; set; } = string.Empty` | Müşterinin adresi. Boş string varsayılan. |
| IsActive | `public bool IsActive { get; set; }` | Müşterinin aktiflik durumu. Varsayılan: `false` (C# default). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `IsActive = false`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (genellikle API katmanı veya Application komut/handler’ları kullanır).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor (muhtemel eş entity: Customer).

Genel Değerlendirme
- Sadece bir DTO dosyası mevcut; mimari ve bağımlılık grafiği bu dosyadan net değil.
- Validasyon kuralları (ör. `Email` formatı, zorunlu alanlar) DTO üzerinde tanımlı değil; muhtemelen ayrı bir validasyon katmanı/araçla yönetilmelidir. Bu dosyadan doğrulanamıyor.
- Dış paketler, veri erişimi veya iş kuralları görünmüyor; daha geniş mimari resmi görmek için ek dosyalar gerekli.### Project Overview
- Proje adı: Library (çıkarım: `Library.Application` namespace’inden)
- Amaç: Kütüphane bağlamında uygulama katmanında DTO’lar/iş sözleşmeleri sağlamak; özellikle personel güncelleme senaryosu için veri taşıma.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı/Clean-vari yapı işareti mevcut; `Application` katmanı bulundu. Diğer katmanlar (Domain, Infrastructure, API) bu dosyadan kesinleşmiyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel kullanımlar (komut/sorgu, servis arayüzleri).
- Dış bağımlılıklar: Görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API (?) → Application (`Library.Application`)
Domain (?) → Application (belirsiz)
Infrastructure (?) → Application (belirsiz)

---
### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel güncelleme işlemi için kullanılan bir veri taşıma nesnesidir. Uygulama (Application) katmanına aittir ve istemciden gelen güncelleme verilerini servis/handler katmanına taşımayı amaçlar.

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
| Email | `public string Email { get; set; }` | Personelin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Personelin telefon numarası. |
| Position | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = false` (bool varsayılanı).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel karşılık gelen entity: Staff/Employee).

**7. Eksikler ve Gözlemler**
- Girdi doğrulama işaretleyicileri (ör. `Required`, `EmailAddress`, uzunluk kısıtları) tanımlı değil; geçersiz/veri bütünlüğünü bozan girişler üst katmanda kontrol edilmelidir.

---
### Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülebiliyor; diğer katmanlar ve akış belirsiz.
- DTO’larda veri anotasyonları/validasyon işaretleyicileri bulunmuyor; doğrulama yaklaşımı (FluentValidation, data annotations, domain validasyonu vb.) net değil.
- Hedef framework ve dış paketler görünmediği için çalıştırma/konfigürasyon gereksinimleri tespit edilemiyor.### Project Overview
Proje adı: Library.Application. Amaç: Uygulama katmanındaki servis arabirimleri ile implementasyonlarının DI konteynerine eklenmesini sağlar. Hedef framework bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı (Application katmanı). Application; iş mantığı servislerini içerir ve üst katman (API/Host) tarafından tüketilir.  
Projeler/Assembly’ler: 
- Library.Application — Uygulama servisleri ve DI uzantısı.  
Harici paketler/çerçeveler: 
- `Microsoft.Extensions.DependencyInjection` — DI kayıtlarını yapmak için kullanılır.  
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Host/API] → Library.Application  
Library.Application → Microsoft.Extensions.DependencyInjection

---
### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Application katmanındaki servisleri DI konteynerine ekleyen `AddApplication` uzantısını sağlar. Mimari olarak Application katmanında yer alır ve üst katmanların bu katmanı tek noktadan kaydetmesini kolaylaştırır.

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
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Application servislerini `IServiceCollection` üzerine Scoped olarak kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `IBookService` → `BookService`, `IBookCategoryService` → `BookCategoryService`, `IStaffService` → `StaffService`, `ICustomerService` → `CustomerService` kayıtları yapılır.
- Lifetime tüm servisler için `Scoped` olarak belirlenmiştir (request başına bir örnek).
- Yalnızca DI kayıtları içerir; ek validasyon veya hata yönetimi bulunmaz.

**6. Bağlantılar**
- **Yukarı akış:** Üst katman (ör. API/Host) `AddApplication` çağırarak servis kayıtlarını yapar.
- **Aşağı akış:** `Microsoft.Extensions.DependencyInjection` API’sini kullanır.
- **İlişkili tipler:** `IBookService`/`BookService`, `IBookCategoryService`/`BookCategoryService`, `IStaffService`/`StaffService`, `ICustomerService`/`CustomerService` (hepsi `Library.Application.Interfaces` ve `Library.Application.Services` altında referanslanır).

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait DI uzantısı görülüyor. Diğer katmanlar (Domain, Infrastructure, API) bu dosyadan çıkarılamıyor.
- Hedef framework ve konfigürasyon anahtarları görünür değil.
- Servis yaşam süresi tercihleri tutarlı (Scoped). İhtiyaca göre bazı servisler `Singleton`/`Transient` olmalıysa bu ayrım başka yerlerde ele alınmalıdır.### Project Overview
Bu repository’de görünen tek proje/katman `Library.Application` olup, uygulama katmanında kitap kategorilerine ilişkin servis sözleşmesini tanımlar. Amaç, `BookCategoryDto` tabanlı CRUD işlemleri için arayüz kontratı sağlayarak uygulama mantığını soyutlamak ve üst katmanların (ör. API) ve alt katmanların (ör. Infrastructure) gevşek bağlı çalışmasını kolaylaştırmaktır. Hedef framework bu dosyadan anlaşılmıyor. Mimari desen katmanlı yaklaşımı işaret eder: Application katmanı domain mantığını temsil eden sözleşmeleri yayınlar. Harici paket bilgisi ve yapılandırma gereksinimleri bu dosyadan çıkarılamıyor.

### Architecture Diagram
Library.Application (Interfaces, DTO kontratları)
  ↑ (muhtemel tüketiciler: API/Presentation)
  ↓ (muhtemel implementasyon: Infrastructure/Domain)
Not: Yalnızca `Library.Application` görülebildi; diğer katmanlar bu dosyadan kesin olarak doğrulanamıyor.

---
### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorilerine yönelik CRUD operasyonları için sözleşme tanımlar. Application katmanına aittir ve üst katmanlar ile altyapı implementasyonları arasında soyutlama sağlar.

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
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori DTO’larını listeler. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Var olan kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Interface — davranış yok. Beklenen semantik: CRUD operasyonları; `GetByIdAsync` null dönebilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar controller’lar veya application hizmetleri.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor (implementasyon belirtilmemiş).
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto` (`Library.Application.DTOs`).

Genel Değerlendirme
- Yalnızca Application katmanındaki bir arayüz görülebiliyor; DTO’lar referans verilmiş fakat içerikleri bu dosyada yok.
- Implementasyon sınıfları, Domain varlıkları, Infrastructure ayrıntıları ve konfigürasyon belirgin değil.
- Hata yönetimi, validasyon kuralları ve transaction davranışı interface seviyesinde tanımlı değil; bunlar implementasyonda ele alınmalıdır.### Project Overview
- Proje adı: Library (çıkarım: `Library.Application` isim alanı)
- Amaç: Kütüphane alanındaki kitap işlemleri için uygulama katmanında servis sözleşmeleri tanımlamak (CRUD ve listeleme senaryoları).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean mimarinin “Application” katmanı mevcut; arayüzler üzerinden iş mantığı sözleşmeleri tanımlanıyor. Diğer katmanlar bu dosyadan görülmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve servis arayüzleri.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)

---

### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara ilişkin temel CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Uygulama (Application) katmanında yer alır ve genellikle DI üzerinden bir implementasyonla kullanılmak üzere tasarlanmıştır.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Yalnızca `Library.Application.DTOs` tiplerine atıf yapar.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kitabı getirir; bulunamazsa `null` dönebilir. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait/ödünç verilebilir durumdaki kitapları listeler. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur ve oluşan kitabı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Mevcut kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış implementasyonu yok. Çıkarımlar:
- `GetByIdAsync` null dönebilir; bulunamama durumunun tüketen katmanda ele alınması gerekir.
- `UpdateAsync` ve `DeleteAsync` dönüş değeri yok; başarısızlık/“bulunamadı” durumlarının nasıl bildirileceği sözleşmede tanımlı değil.
- Asenkron imzalar mevcut ancak `CancellationToken` parametreleri yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/controller veya uygulama hizmetleri tarafından çağrılır.
- **Aşağı akış:** Harici hizmet bağımlılığı yok; `CreateBookDto`, `UpdateBookDto`, `BookDto` kullanır.
- **İlişkili tipler:** `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` parametreleri eksik.
- `UpdateAsync`/`DeleteAsync` için bulunamama veya doğrulama hataları nasıl iletilecek belirsiz; sözleşmede hata modeli tanımlı değil.
- Listeleme operasyonlarında sayfalama/sıralama/filtreleme parametreleri yok; geniş koleksiyonlar için ölçeklenebilirlik sorunu doğurabilir.

---

Genel Değerlendirme
- Yalnızca Application katmanından bir arayüz görülebiliyor; mimarinin tamamı bu dosyadan çıkarılamıyor.
- Sözleşme açık ve minimal; ancak iptal belirteci, hata modeli (ör. sonuç türleri, istisna sözleşmesi), sayfalama/sıralama gibi pratik ihtiyaçlara yönelik imzalar netleştirilebilir.
- DTO’lar referanslanmış ancak içerikleri bu girdide yok; doğrulama kurallarının nerede uygulanacağı belirgin değil.### Project Overview
- Proje adı: Library (adlar ve namespace’lerden çıkarım)
- Amaç: Müşteri yönetimi için uygulama katmanında sözleşmeler tanımlamak (müşteri CRUD ve listeleme işlemleri).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; `Application` katmanında servis sözleşmeleri ve DTO’lar tanımlanmış görünüyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Application — Uygulama katmanı; servis arayüzleri (`Interfaces`) ve veri aktarım nesneleri (`DTOs`).
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application.Interfaces -> Library.Application.DTOs

---

### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri varlıkları için uygulama katmanında kullanılacak CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Amaç, müşteri oluşturma, güncelleme, silme ve listeleme gibi işlemleri soyutlayarak üst katmanların (ör. API) uygulama mantığına karşı bağımlılığını azaltmaktır. Bu tip Application katmanına aittir.

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
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` ile müşteriyi getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri döndürür. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Yalnızca aktif müşterileri listeler. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Belirtilen müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme — davranış tanımlamaz; tüm operasyonlar asenkron `Task` tabanlıdır.
- `GetByIdAsync` sonuç olarak `null` dönebileceğini belirtir; diğer metotlar hata durumlarını tip imzasında belirtmez.
- `GetActiveCustomersAsync` aktiflik kavramının varlığını ima eder; kriter bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak API/controller veya uygulama işlemleri tarafından çağrılır (bu dosyadan spesifik çağırıcılar anlaşılmıyor).
- Aşağı akış: Harici bağımlılık yok (arayüz).
- İlişkili tipler: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Tüm metot imzalarında `CancellationToken` desteği yok; uzun süren IO işlemleri için önerilir.
- `UpdateAsync` ve `DeleteAsync` sonuç/etki bilgisi döndürmüyor (ör. bulunamadı/başarısız bilgisi); `bool`, `Result` tipi veya özel exception sözleşmesi düşünülmeli.
- Listeleme operasyonlarında sayfalama/sıralama parametreleri yok; büyük veri setlerinde performans ve kullanım açısından gerekebilir.

---

### Genel Değerlendirme
Kod, Application katmanında servis sözleşmesini net ve sade biçimde tanımlıyor. Ancak asenkron imzalar için `CancellationToken` ve listeleme için sayfalama/sıralama gibi çapraz kesen kaygılar henüz ele alınmamış. Güncelleme/silme operasyonlarının sonuç bildirimi için daha ifade edici dönüş tipleri veya istisna sözleşmeleri tanımlanması faydalı olabilir. Dış bağımlılıklar, hedef framework ve diğer katmanlar bu depodan görünmüyor.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” olup “Application” katmanı görünür durumdadır. Amaç, kütüphane alanındaki personel (staff) yönetimi için uygulama seviyesinde sözleşmeler (servis arayüzleri) ve DTO’lar üzerinden işlem akışlarını tanımlamaktır. Hedef çatı .NET (Core) sürümü bu dosyadan anlaşılamıyor. Mimari, adlandırmalardan Clean Architecture/N‑Katman yaklaşımını işaret ediyor: `Library.Application` katmanı domain mantığını orkestre eden sözleşmeleri ve DTO’ları içerir; veri erişimi ve API katmanları bu dosyadan görünmüyor. Keşfedilen proje/derleme: `Library.Application` — rolü: uygulama sözleşmeleri (service interface’leri) ve DTO tipleri. Harici paket/framework kullanımları, konfigürasyon gereksinimleri bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)
  └─ (Implementasyonlar ve dış katmanlar bu depoda görünmüyor)

---
### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (staff) varlıkları üzerinde uygulama katmanı işlemleri için sözleşme sunar: okuma, listeleme, aktif personeli getirme, oluşturma, güncelleme ve silme. Clean Architecture bağlamında Application katmanına aittir ve tipik olarak Infrastructure’daki implementasyonlarca DI üzerinden sağlanır.

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
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için personeli döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını döndürür. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif personel listesini döndürür. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşturulan kaydı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Var olan personeli günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış tanımlamaz; validasyon, hata yönetimi ve transaction kuralları implementasyonlara bırakılır.
- `GetByIdAsync` dönüşü `null` olabileceğini belirtir; bulunamayan kayıt senaryosu beklenir.
- `GetActiveStaffAsync` aktiflik kriterine göre filtreleme sözleşmesi sunar; aktiflik ölçütü bu dosyadan anlaşılmıyor.
- DTO — `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` tipleriyle veri aktarım sınırı belirlenmiştir; içerikleri bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** Harici bağımlılık belirtilmemiş (implementasyon katmanında olacaktır).
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Tüm async imzalarda `CancellationToken` desteği yok; ölçeklenebilirlik ve iptal senaryoları için eklenmesi faydalı olabilir.
- `GetAllAsync` için sayfalama/sıralama parametreleri yok; büyük veri kümelerinde performans sorunlarına yol açabilir.
- Silme işlemi “soft delete” mi “hard delete” mi belirsiz; sözleşmede netleştirilmesi faydalı olur.
- `UpdateAsync` ve `DeleteAsync` için bulunamayan kayıt/uygunsuz durumlar adına sözleşmesel sonuçlar (ör. bool dönüş, özel exception sözleşmesi) tanımlı değil.

---
Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir servis arayüzü görünüyor; Domain, Infrastructure ve API/presentation katmanları görünür değil.
- Sözleşmelerde `CancellationToken` eksikliği ve sayfalama/sıralama gibi ortak çapraz-kesimsel kaygıların adreslenmemesi dikkat çekiyor.
- Hata ve bulunamama durumlarının sözleşme düzeyinde netleştirilmesi (dönüş tipleri, exception politikası) tutarlılık ve tüketilebilirlik açısından iyileştirilebilir.### Project Overview
Proje Adı: Library  
Amaç: Kitap kategori bilgilerini Domain entity’leri ile Application DTO’ları arasında dönüştürmek (mapping).  
Hedef Framework: .NET (sürüm bu dosyadan anlaşılmıyor).

Mimari Desen: Clean Architecture tarzı katmanlı yapı  
- Domain: `Library.Domain.Entities` — Temel iş modelleri ve kurallar (ör. `BookCategory`).  
- Application: `Library.Application` — DTO’lar, mapping ve olası kullanım senaryolarının (handlers/services) bulunduğu katman.

Projeler/Assembly’ler:  
- Library.Domain — Domain entity’leri.  
- Library.Application — DTO’lar ve mapping yardımcıları.

Kullanılan Dış Paketler/Çatılar: Bu dosyadan anlaşılmıyor.

Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**  
`BookCategory` entity’si ile `BookCategoryDto`/`CreateBookCategoryDto`/`UpdateBookCategoryDto` arasında dönüşüm sağlayan extension method’ları içerir. Application katmanına aittir ve sunum/iş akışı katmanlarının domain modeline doğrudan bağımlılığını azaltır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Sadece `Library.Application.DTOs` ve `Library.Domain.Entities` tiplerini kullanır.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` entity’sini `BookCategoryDto`'ya map eder. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | Create DTO’dan yeni `BookCategory` entity’si oluşturur ve `Id` üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Update DTO değerlerini mevcut `BookCategory` entity’sine uygular. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir (auto-generated kimlik).
- Tüm mapping’ler doğrudan alan kopyalama yapar; null kontrolü veya validasyon içermez.
- İş kuralı içeren dönüşüm/koşul bulunmuyor.

**Mantık içermeyen basit DTO/model'ler için**  
DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor (DTO tanımları burada yok).

**6. Bağlantılar**
- **Yukarı akış:** Application katmanındaki service/handler/controller benzeri orchestrator’lar bu extension’ları çağırır.
- **Aşağı akış:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.
- **İlişkili tipler:** `Library.Domain.Entities.BookCategory`, `Library.Application.DTOs.*`.

**7. Eksikler ve Gözlemler**
- `ToEntity` içinde `Id` üretimi mapping’e yerleştirilmiş; bu sorumluluk bazı projelerde domain veya persistence katmanına taşınır.
- Null inputlar için koruma (guard) ve validasyon bulunmuyor; `category` veya `dto` null ise `NullReferenceException` oluşabilir.

---
Genel Değerlendirme
- Katman ayrımı net: Application, Domain. Mapping extension yaklaşımı sade ve anlaşılır.
- Validasyon ve null korumaları eksik; üretim kodlarında guard/contract kullanımına ihtiyaç var.
- Dış paket/altyapı bağımlılığı belirtilmemiş; proje ölçeklenecekse merkezi bir mapping (ör. AutoMapper) veya konsolide mapping stratejisi değerlendirilebilir.
- Kimlik üretimi sorumluluğunun konumu tekrar gözden geçirilebilir (domain/persistence).### Project Overview
- Proje adı: Library
- Amaç: Kitap varlıklarını DTO’lara dönüştürmek ve tersine çevirmek için mapping yardımcıları sağlayarak uygulama katmanında veri aktarımını kolaylaştırmak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; `Domain` (iş kuralları/entitiler) ve `Application` (DTO’lar, mapping) katmanları görünür.
- Keşfedilen projeler/assembly’ler:
  - `Library.Domain` — Domain entitileri (örn. `Book`)
  - `Library.Application` — DTO’lar ve mapping yardımcıları
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`BookMappings`, `Library.Domain.Entities.Book` ile `Library.Application.DTOs` arasındaki dönüşümleri sağlayan statik bir mapping yardımcı sınıfıdır. Application katmanına aittir ve CRUD akışlarında veri giriş/çıkışı için tipler arası projeksiyon ve güncelleme işlemlerini kolaylaştırır.

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
| ToDto | `public static BookDto ToDto(this Book book)` | Bir `Book` entity’sini `BookDto`'ya projekte eder; kategori adını null güvenli biçimde taşır. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | Bir `CreateBookDto`'yu yeni bir `Book` entity’sine dönüştürür; `Id` üretir ve `IsAvailable`'ı true olarak ayarlar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan bir `Book` entity’sini `UpdateBookDto` alanlarına göre yerinde günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToDto`: `BookCategoryName` için `book.BookCategory?.Name` kullanır; kategori yoksa null döner.
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir; `IsAvailable` varsayılan olarak `true` atanır.
- `UpdateEntity`: Hedef `Book` nesnesini yerinde günceller; `Title`, `Author`, `ISBN`, `PublishedYear`, `IsAvailable`, `BookCategoryId` alanlarını set eder.
- Validasyon veya hata fırlatma içermez; alanların doğruluğu bu katmanda kontrol edilmez.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `Library.Application.DTOs.CreateBookDto`, `Library.Application.DTOs.UpdateBookDto`
- **İlişkili tipler:** `Book`, `BookDto`, `CreateBookDto`, `UpdateBookDto`, `BookCategory` (dolaylı; `Book.BookCategory?.Name` üzerinden)

**7. Eksikler ve Gözlemler**
- `UpdateEntity` işleminde null referans veya alan validasyonu yok; eksik/uygunsuz değerlerin güncellenmesine açık olabilir.
- Mapping yalnızca düz kopyalama yapar; karmaşık dönüşüm veya koruyucu kontroller bulunmuyor.

Genel Değerlendirme
- Kod, Application ve Domain arasında net ayrım yapıyor ve extension method yaklaşımıyla sade, test edilebilir mapping sağlıyor.
- Validasyon, hata yönetimi ve authorization gibi endişeler bu katmanda ele alınmıyor; başka katmanlarda (örn. Application hizmetleri/handler’lar) ele alınması beklenir.
- Hedef framework, konfigürasyon ve dış bağımlılıklar görünmüyor; çözüm bütünlüğü için proje dosyaları ve ek katmanlar (Infrastructure, API) incelenmeli.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alanındaki müşteri varlıklarının Application katmanında DTO’larla dönüşümünü (mapping) sağlamak.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari: Clean Architecture’a işaret eden katmanlaşma (Application → Domain).  
Keşfedilen Katmanlar/Projeler:
- Library.Domain: Temel varlıklar (ör. `Customer`).
- Library.Application: DTO’lar ve mapping mantığı (ör. `CustomerMappings`).
Dış Bağımlılıklar: Görünmüyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Presentation/API (muhtemel) -> Library.Application -> Library.Domain

---
### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` varlığını `CustomerDto` ve ilgili create/update DTO’larıyla dönüştüren extension metodlarını sağlar. Application katmanına aittir ve Domain varlıkları ile Application DTO’ları arasındaki sınırı korur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Statik/extension metotlar; `Customer` ve DTO tipleri dışında DI yok)

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` varlığını `CustomerDto`’ya map eder. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`’dan yeni `Customer` varlığı üretir ve bazı alanları otomatik atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Mevcut `Customer` üzerinde update DTO’suna göre alanları günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: 
  - `Id` için `Guid.NewGuid()` üretir.
  - `MembershipNumber`’ı yeni GUID’in ilk 10 karakterini `ToUpper()` ile oluşturur.
  - `RegisteredDate`’i `DateTime.UtcNow` olarak atar.
  - `IsActive` varsayılan olarak `true` yapılır.
- `UpdateEntity`: `FirstName`, `LastName`, `Email`, `Phone`, `Address`, `IsActive` alanlarını DTO’dan hedef `Customer`’a kopyalar.
- `ToDto`: Varlıktaki alanları bire bir DTO’ya taşır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.Customer`, `Library.Application.DTOs.CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`
- **İlişkili tipler:** `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`

**7. Eksikler ve Gözlemler**
- `ToEntity` ve `UpdateEntity` metodlarında alan doğrulaması veya hata yönetimi yok; geçersiz/veri bütünlüğünü bozan girdi durumları ele alınmıyor. 

---
Genel Değerlendirme
- Mimari, Application → Domain bağımlılık yönüyle Clean Architecture’a uygun görünüyor, ancak sadece mapping katmanı görülüyor.
- Mapping’lerde alan doğrulaması ve hata yönetimi eksik; bu işlerin başka katmanlarda ele alınması beklenir, ancak bu dosyadan teyit edilemiyor.
- Hedef framework, konfigürasyon ve ek dış paket kullanımı bu koddan belirlenemiyor.### Project Overview
Proje adı: Library (türetilen ad). Amaç: Kütüphane personel yönetimiyle ilişkili veri dönüşümleri için Application katmanında DTO-Entity mapping sağlamak. Hedef çatı: .NET (tam sürüm bu dosyadan anlaşılmıyor), katmanlı/Clean Architecture tarzı isimlendirme mevcut.

Mimari desen: Clean Architecture eğilimli katmanlama.
- Domain: Temel iş nesneleri (`Library.Domain.Entities.Staff`).
- Application: DTO’lar ve mapping mantığı (`Library.Application.DTOs`, `Library.Application.Mappings`).
- API/Infrastructure: Bu dosyadan görülmüyor.

Projeler/Assembly’ler (çıkarım):
- Library.Domain — Entity tanımları (ör. `Staff`).
- Library.Application — DTO’lar ve mapping extension’ları.

Dış bağımlılıklar: Görünür paket yok.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` entity’si ile ilgili DTO’lar (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`) arasında dönüşüm sağlayan extension method’ları içerir. Application katmanında yer alır ve entity-DTO ayrımını koruyarak veri taşınmasını kolaylaştırır.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (DTO ve Entity tiplerini kullanır ancak DI ile enjekte edilen bir bağımlılık bulunmuyor.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` entity’sini `StaffDto`’ya dönüştürür. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni bir `Staff` entity’si oluşturur (Id üretir, `IsActive` varsayılan true). |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Var olan `Staff` entity’sini `UpdateStaffDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde `Id = Guid.NewGuid()` otomatik üretilir.
- `ToEntity` yeni personeli `IsActive = true` olarak başlatır.
- `UpdateEntity` `HireDate`’i değiştirmez; kimlik ve oluşturulma tarihi korunur.
- Validasyon veya hata fırlatma yok; tüm alanlar doğrudan atanır.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (tipik olarak Application servisleri/handler’ları kullanır).
- Aşağı akış: `Library.Domain.Entities.Staff`, `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.
- İlişkili tipler: `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- Mapping’de null/format validasyonu yok; hatalı/veri kaybı risk yönetimi görünmüyor.
- `UpdateEntity` işleminde alan bazlı kısmi güncelleme veya değişiklik algılama mantığı yok; tüm alanlar overwrite edilir.

---

Genel Değerlendirme
- Kod, Application ve Domain katmanlarını işaret eden Clean Architecture düzenini takip ediyor; ancak yalnızca mapping dosyası görülebiliyor.
- Validasyon, hata yönetimi, logging ve transaction/pipeline desenleri (ör. MediatR) bu kesitte görünmüyor.
- Hedef framework, konfigürasyon ve dış bağımlılıklar belirsiz; proje genelinde standartlaştırılmış mapping yaklaşımı (extension method) tutarlı.### Proje Genel Bakış
- Proje Adı: Library
- Amaç: Kitap kategorileri için uygulama katmanında servis mantığı sağlayarak, domain repository’leri üzerinden CRUD işlemlerini yürütmek; DTO/Entity mapping ile veri aktarımını yönetmek.
- Hedef Framework: Bu dosyadan kesin çıkarılamıyor; standart .NET 6/7/8 tabanlı katmanlı mimari izlenimi var.
- Mimari: Clean Architecture/N‑Katmanlı yaklaşım. Katmanlar:
  - Domain: `Library.Domain.Interfaces` içinde repository kontratları (ör. `IBookCategoryRepository`).
  - Application: `Library.Application` içinde servisler (`Services`), DTO’lar (`DTOs`), mapping extension’ları (`Mappings`), servis arayüzleri (`Interfaces`).
  - Infrastructure/API: Bu dosyadan görülmüyor.
- Keşfedilen Projeler/Assembly’ler:
  - Library.Application — Uygulama hizmetleri, DTO ve mapping’ler.
  - Library.Domain.Interfaces — Domain repository kontratları.
- Dış Bağımlılıklar: Koddan özel bir paket görünmüyor; async/await ve LINQ dışında çerçeve kullanımı belirsiz.
- Konfigürasyon: Bu dosyadan bağlantı stringi veya app settings gereksinimi görülmüyor.

### Mimari Diyagram
Domain.Interfaces <- Application (Services, DTOs, Mappings, Interfaces)
[Olası] Infrastructure (Repositories) -> Domain.Interfaces
[Olası] API/Presentation -> Application

---
### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD odaklı uygulama hizmetlerini sunar. Domain katmanındaki `IBookCategoryRepository` üzerinden çalışır, DTO/Entity dönüşümlerini `Mappings` ile gerçekleştirir. Clean Architecture bağlamında Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori varlıklarına yönelik veri erişim operasyonlarını sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını enjekte eder. |
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Id’ye göre kategoriyi getirir; yoksa `null` döner. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri listeler. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve DTO döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Mevcut kategoriyi günceller; yoksa hata fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id’ye göre kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync` içinde kategori bulunamazsa `KeyNotFoundException` fırlatılır.
- DTO ⇄ Entity dönüşümleri `Mappings` uzantılarıyla yapılır: `ToDto`, `ToEntity`, `UpdateEntity`.
- `CreateAsync` ekleme sonrası aynı entity’den DTO üretir; repository’nin ekleme sonrası kimlik ataması yapıp yapmadığı bu dosyadan anlaşılmıyor.
- `DeleteAsync` için varlık varlık kontrolü yapılmıyor; repository davranışına bağımlı.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar Application tüketicileri (API controller’ları, handler’lar).
- **Aşağı akış:** `IBookCategoryRepository`
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `IBookCategoryService`, mapping extension’ları (`ToDto`, `ToEntity`, `UpdateEntity`).

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için girdi validasyonu (ör. zorunlu alanlar, ad benzersizliği) görünmüyor.
- `DeleteAsync` varlık mevcut değilse davranış belirsiz; repository istisna/sonuç üretimi net değil.

---
Genel Değerlendirme
- Uygulama katmanı ile domain repository’leri arası ayrım net; mapping’ler extension olarak düzenlenmiş.
- Validasyon, hata yönetimi ve olası iş kuralları (benzersizlik, durum kontrolleri) Application seviyesinde açık değil; muhtemelen başka katmanlarda ele alınıyor ya da eksik.
- Hedef framework, altyapı ve konfigürasyon detayları görünmediğinden, proje bütününde izleme/loglama, transaction yönetimi ve yetkilendirme stratejileri bu dosyadan anlaşılamıyor.### Project Overview
Bu depo, bir kütüphane alanına yönelik katmanlı/Clean Architecture tarzı uygulama iskeletini işaret ediyor. Hedef çerçevenin modern .NET (Core) olduğu isimlendirme ve async kullanımıyla anlaşılabilir; net sürüm bu dosyadan anlaşılmıyor. Uygulama katmanı (`Library.Application`) içinde `BookService`, alan katmanındaki (`Library.Domain`) `IBookRepository` ile çalışır; DTO ve mapping’ler Application katmanında organize edilmiştir. Mimari, Domain (iş kuralları ve repository kontratları) → Application (servisler, DTO, mapping) → Infrastructure (somut veri erişimi, bu dosyada görünmüyor) → API/Presentation (bu dosyada görünmüyor) akışını ima eder.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Domain: `IBookRepository` gibi domain kontratları.
- Library.Application: `BookService`, DTO’lar, mapping extension’ları, application-level interface’ler.

Harici paketler: Bu dosyadan spesifik paket görünmüyor (EF Core, MediatR vb. tespit edilemedi).

Konfigürasyon: Bu dosyadan herhangi bir connection string veya app setting anahtarı tespit edilemiyor.

### Architecture Diagram
API/Presentation → Library.Application → Library.Domain  
Infrastructure (Data Access) → Library.Domain  
API/Presentation → Library.Application uses  
Library.Application depends on Library.Domain  
Infrastructure implements Library.Domain interfaces

---
### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik uygulama hizmetlerini sağlar: listeleme, getirme, oluşturma, güncelleme ve silme. Application katmanında yer alır ve domain katmanındaki `IBookRepository` ile çalışarak DTO–Entity dönüşümlerini mapping extension’larıyla gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `Library.Domain.Interfaces.IBookRepository` — Kitap varlıkları için repository erişimi sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookService(IBookRepository bookRepository)` | Repository bağımlılığını enjekte eder. |
| GetByIdAsync | `public Task<BookDto?> GetByIdAsync(Guid id)` | Kimliğe göre kitabı getirir; yoksa `null` döner. |
| GetAllAsync | `public Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları DTO olarak döner. |
| GetAvailableBooksAsync | `public Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Müsait (uygun) kitapları DTO olarak döner. |
| CreateAsync | `public Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur ve DTO’sunu döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller; bulunamazsa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO–Entity dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` mapping extension’larıyla yapılır.
- `UpdateAsync` içinde kitap bulunamazsa `KeyNotFoundException` fırlatılır.
- `CreateAsync` yeni entity’yi repository’e ekler ve eklenen entity’den DTO üretir.
- `GetAvailableBooksAsync` uygunluk kriterini repository uygular; servis tarafında ek filtre yok.
- `DeleteAsync` doğrudan silme çağrısı yapar; yoksa ne olacağı repository implementasyonuna bağlıdır (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar Application arabirimlerini kullanan API/Controller’lar veya diğer servisler.
- **Aşağı akış:** `IBookRepository`; `Library.Application.Mappings` extension’ları.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`, `IBookRepository`.

**7. Eksikler ve Gözlemler**
- `DeleteAsync` için “kayıt bulunamadı” durumuna özel bir geri bildirim/hata yönetimi yok; repository davranışına bırakılmış.
- Girdi validasyonları (`CreateBookDto`, `UpdateBookDto` alan kontrolleri) servis seviyesinde görünmüyor; validasyon başka katmanda ise bu dosyadan anlaşılamıyor.

---
Genel Değerlendirme
Kod, Clean Architecture’a uygun bağımlılık yönleriyle net bir ayrım sergiliyor: Application, Domain kontratlarına bağlı ve mapping extension’larını kullanıyor. Ancak servis seviyesinde açık validasyon ve hata yönetimi stratejisi (özellikle silme ve oluşturma senaryolarında) belirgin değil. Transaction, logging, caching, yetkilendirme gibi yatay kesen endişeler bu dosyada görünmüyor; proje genelinde ayrı katmanlarda ele alınıyor olabilir. Dış bağımlılıklar ve konfigürasyon anahtarları tespit edilemedi; Infrastructure ve API katmanlarının incelenmesiyle tamamlanmalıdır.### Project Overview
Proje adı: Library (çıkarım). Amaç: Müşteri işlemlerini Application katmanında servis aracılığıyla yönetmek; Domain katmanındaki repository arayüzünü kullanarak CRUD ve sorgulama yapmak. Hedef Framework: Bu dosyadan anlaşılmıyor.

Mimari: Clean Architecture/N‑Katmanlı bir düzenin işaretleri mevcut.
- Domain: `Library.Domain.Interfaces` altında repository sözleşmeleri.
- Application: `Library.Application.Services`, `Library.Application.DTOs`, `Library.Application.Mappings`, `Library.Application.Interfaces` ile use case/servis, DTO ve mapping mantığı.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Application — Uygulama mantığı, servisler, DTO’lar ve mapping.
- Library.Domain — Domain sözleşmeleri (repository arayüzleri).

Dış bağımlılıklar: Bu dosyadan anlaşılmıyor (EF Core, MediatR vb. görünmüyor).

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarı görünmüyor).

### Architecture Diagram
Library.Application (Services, DTOs, Mappings, Interfaces) --> Library.Domain (Interfaces)

---
### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri verileri için CRUD ve sorgulama operasyonlarını uygulayan Application katmanı servisidir. Domain katmanındaki `ICustomerRepository` ile haberleşir ve entity <-> DTO dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri varlıkları için veri erişim operasyonlarını sağlayan repository arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<CustomerDto?> GetByIdAsync(Guid id)` | ID ile müşteriyi getirir, DTO’ya map eder; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri getirir ve DTO listesine map eder. |
| GetActiveCustomersAsync | `public Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri getirip DTO listesine map eder. |
| CreateAsync | `public Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | DTO’dan entity oluşturup ekler ve oluşturulan kaydı DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi bulup DTO alanlarıyla günceller; yoksa istisna fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Müşteriyi ID’ye göre siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Entity <-> DTO dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır.
- `UpdateAsync` içinde müşteri bulunamazsa `KeyNotFoundException` fırlatılır.
- `CreateAsync` yeni entity’yi ekler; eklenen entity DTO olarak geri döner.
- `DeleteAsync` doğrulama yapmadan repository silme operasyonunu çağırır (silme öncesi varlık kontrolü bu seviyede yapılmıyor).
- Filtreli listeleme `GetActiveCustomersAsync` ile repository düzeyindeki “aktif” kriterine delege edilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/Handler katmanları bu servisi çağırır (bu dosyadan çağırıcılar net değil).
- **Aşağı akış:** `ICustomerRepository`
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `Library.Application.Mappings` uzantıları; Domain müşteri entity’si (tip adı bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- Metotlarda iptal desteği (CancellationToken) yok; uzun süren IO işlemlerinde faydalı olabilir.
- Girdi validasyonu (ör. `createDto`, `updateDto` null veya alan doğrulamaları) servis seviyesinde yapılmıyor; üst katmana bırakılmış görünüyor.### Project Overview
Proje adı: Library (görülen ad alanlarından). Amaç: Kütüphane personeli yönetimi için uygulama katmanında iş servisleri sağlamak. Hedef çatı sürümü bu dosyadan anlaşılamıyor.

Mimari: Katmanlı/Clean Architecture tarzı ayrım görülüyor. Domain katmanı (`Library.Domain`) depo arayüzlerini barındırıyor. Application katmanı (`Library.Application`) DTO’lar, servisler, mapping uzantıları ve uygulama arayüzlerini barındırıyor. Servis, Repository pattern üzerinden Domain’e erişiyor ve DTO/entity mapping ile sunum veya diğer katmanlara veri aktarıyor.

Projeler/Assembly’ler:
- Library.Application: Uygulama servisleri, DTO’lar, mapping uzantıları, uygulama arayüzleri.
- Library.Domain: Domain sözleşmeleri (ör. `IStaffRepository`). Varlıklar bu dosyadan görülmüyor.

Dış bağımlılıklar: Bu dosyadan tespit edilemiyor (EF Core, MediatR vb. görünmüyor).

Yapılandırma gereksinimleri: Bu dosyada bağlantı dizesi veya app settings anahtarı kullanılmıyor; gerekler bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application (Services, DTOs, Mappings, Interfaces)
        ↓
Library.Domain (Interfaces)

---
### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel yönetimi için uygulama katmanında yer alan bir servis implementasyonudur. Repository üzerinden personel verisine erişir, DTO–Entity dönüşümlerini gerçekleştirir ve temel CRUD işlemlerini sunar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel varlıklarının veri erişim işlemleri (getir, ekle, güncelle, sil).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir ve DTO’ya map eder. |
| GetAllAsync | `public Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personelleri listeler ve DTO’ya map eder. |
| GetActiveStaffAsync | `public Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personelleri listeler ve DTO’ya map eder. |
| CreateAsync | `public Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | DTO’dan entity oluşturur, kaydeder ve DTO döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut entity’yi bulur, DTO ile günceller ve kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync`: Personel bulunamazsa `KeyNotFoundException` fırlatır.
- DTO–Entity dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır; mapping kuralları bu dosyada detaylandırılmamış.
- `CreateAsync` ekleme sonrası oluşan entity DTO’ya çevrilir; kimlik üretimi/varsayılan değerler mapping veya repository tarafında olabilir, bu dosyadan anlaşılmıyor.
- `DeleteAsync` varlık varlık kontrolü yapmadan silme çağrısı yapar; varlık yoksa repository davranışı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** `IStaffService` üzerinden DI ile çözümlenir; muhtemel çağırıcılar API Controller’ları veya Application katmanındaki orkestrasyon bileşenleri.
- **Aşağı akış:** `IStaffRepository`, `Library.Application.Mappings` uzantıları.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`, `IStaffRepository`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için giriş validasyonu servis seviyesinde görünmüyor; hatalı/eksik DTO alanları repository’ye iletilebilir.
- `DeleteAsync` için varlık mevcut değilse hata davranışı belirsiz; tutarlı hata yönetimi eksik olabilir.

Genel Değerlendirme
- Mimari katman ayrımı net: Application servisleri Domain repository arayüzüne bağımlı. Ancak transaction yönetimi, validasyon ve hata işlemesi servis katmanında açıkça tanımlı değil.
- Mapping detayları ve domain kuralları uzantı metotlarda/Domain’de; bu dosyadan doğrulanamıyor.
- Dış bağımlılık ve konfigürasyon izleri yok; altyapı (Infrastructure) ve API katmanları bu girdide görünmüyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` ad alanı)
- Amaç: Kütüphane alan modelini (kitap ve ilişkili kategoriler) temsil eden domain varlıklarını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Domain katmanı mevcut; genel mimari bu dosyadan kesin belirlenmiyor. Domain tipleri büyük olasılıkla diğer katmanlar (Application/Infrastructure/API) tarafından kullanılmak üzere tanımlanmış.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain katmanı; çekirdek iş nesneleri ve ilişkileri.
- Kullanılan harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kütüphane kitabını temsil eden domain varlığıdır; kimlik, başlık, yazar, ISBN, basım yılı ve erişilebilirlik durumunu taşır. `BookCategory` ile isteğe bağlı ilişki içerir. Domain katmanına aittir.

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
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | İlişkili kategori navigasyonu (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `IsAvailable = true`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BookCategory` (aynı domain’de beklenen kategori varlığı).

**7. Eksikler ve Gözlemler**
- Alanlar tamamen set edilebilir; ISBN/başlık/yazar gibi domain invariant’ları kodda zorlanmıyor. Fabrika/metotlarla doğrulama veya immutable tasarım düşünülebilir.
- `BookCategory` tipi bu depoda gösterilmemiş; tanım eksik olabilir.

---

Genel Değerlendirme
- Kod yalnızca Domain katmanındaki bir varlığı içeriyor; diğer katmanlar (Application/Infrastructure/API) bu depodan anlaşılmıyor.
- Domain invariant’larını korumak için kapsülleme (private set, ctor doğrulaması) veya value object kullanımı değerlendirilebilir.
- Veri erişimi ve konfigürasyonla ilgili hiçbir bilgi görünmediğinden, altyapı bağımlılıkları ve paket kullanımı çıkarılamıyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` isim alanı)
- Amaç: Kütüphane alan modelini temsil eden domain varlıklarını barındırmak (ör. kitap kategorileri).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Domain katmanı tespit edildi). Domain katmanı, iş kurallarını ve çekirdek varlıkları içerir.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain varlıkları ve olası değer nesneleri.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Domain Katmanı)
  └── Entities: `BookCategory`
Bağımlılık akışı: Bu dosyadan anlaşılmıyor (yalnızca Domain katmanı görülebiliyor).

---
### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, kitapları kategoriler altında gruplayan bir domain varlığıdır. Domain katmanına aittir ve kitap-kategori ilişkisinde kategoriyi temsil eder.

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
| Oluşturucu | `public BookCategory()` | Varsayılan kurucu. |
| Id | `public Guid Id { get; set; }` | Kategorinin benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategori adı. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye bağlı kitap koleksiyonu (navigasyon). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Books = []` (boş koleksiyon), `Id = Guid.Empty` (atanana kadar).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `Book` (navigasyonla ilişkili; bu dosyada tanımlı değil).

**7. Eksikler ve Gözlemler**
- `Name` ve `Description` için domain seviyesinde invariant/validasyon bulunmuyor (boş değerler izinli).

---
Genel Değerlendirme
- Kod, belirgin şekilde Domain katmanına ait ve yalın bir entity içeriyor.
- Mimari katmanlar arasında yalnızca Domain görülebildiği için diğer katmanlar (Application, Infrastructure, API) hakkında çıkarım yapılamıyor.
- Entity üzerinde alan validasyonu veya davranışsal mantık yok; ileride domain kuralları gerektiriyorsa factory/metodlar veya koruyucu kurallar eklenmesi düşünülebilir.
- `Book` tipi referanslanıyor ancak bu depoda sunulmadığı için ilişki detayları (çoktan çoğa/çoka bir vs.) belirsiz.### Project Overview
Proje adı: Library (çıkarım: `Library.Domain` namespace’inden). Amaç: Kütüphane alanına ait temel domain varlıklarını tanımlamak (ör. `Customer`). Hedef çatı: .NET (kesin sürüm bu dosyadan anlaşılmıyor).

Mimari: Clean Architecture/N‑Katmanlı yaklaşıma uygun bir ayrışım işareti var; bu dosya Domain katmanını temsil ediyor. Domain katmanı, kurumsal kuralları ve varlıkları içerir; uygulama akışı, veri erişimi veya sunum bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Domain — Domain varlıkları ve kurallar (bu girdide yalnızca `Customer` var).

Dış bağımlılıklar: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Entities)
  └─(diğer katmanlar bu dosyadan görünmüyor)

---
### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer` kütüphane sistemindeki müşteri/üye bilgisini temsil eden domain varlığıdır. Temel kimlik ve iletişim bilgileri ile üyelik durumunu taşır. Domain katmanına aittir.

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
| Id | `public Guid Id { get; set; }` | Müşteri benzersiz kimliği. |
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `public string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `public string Address { get; set; }` | Müşterinin adresi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Üyeliğin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `IsActive = true`. `RegisteredDate` için varsayılan atanmaz; dışarıdan ayarlanması beklenir.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Doğrulama/iş kuralı bulunmuyor (ör. `Email` formatı, zorunlu alanlar); bu, doğrulamanın başka katmanlarda veya ORM/config aracılığıyla yapıldığını ima ediyor olabilir. 
- `RegisteredDate` ve `Id` üretimi/atanması bu sınıf içinde garanti edilmemiş; uygulama veya veri katmanında ele alınmalı.

Genel Değerlendirme
Kod, Domain katmanında yalın bir varlık sınıfı sunuyor. Mimari olarak Clean Architecture/N‑Katman izleri var ancak yalnızca Domain projesi görülebildiği için diğer katmanlar (Application, Infrastructure, API) ve bağımlılıklar doğrulanamıyor. Varlık üzerinde alan doğrulamaları ve davranışlar tanımlı değil; bu, sorumlulukların başka katmanlara bırakıldığını düşündürüyor. Id/RegisteredDate gibi alanların tutarlı atanması için uygulama veya veri katmanında kuralların netleştirilmesi önerilir.### Project Overview
Proje adı: Library (Domain katmanı). Amaç: Kütüphane alanına ait çekirdek varlıkların tanımlanması. Hedef çatı (Target Framework): bu dosyadan anlaşılmıyor.

Mimari desen: Clean Architecture/N-Tier eğilimli; görünen katman Domain:
- Domain: İş kurallarının ve varlıkların tanımı (ör. `Staff`).

Keşfedilen projeler/assembly’ler:
- Library.Domain — Alan (Domain) varlıkları ve olası değer nesneleri.

Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor (herhangi bir dış bağımlılık görünmüyor).

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor (bağlantı string’i veya app settings anahtarı görünmüyor).

### Architecture Diagram
[Consumers / Üst Katmanlar] → Library.Domain

---

### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff` kütüphane personelini temsil eden bir domain varlığıdır; kimlik, iletişim, pozisyon ve istihdam durumu bilgilerini tutar. Mimari olarak Domain katmanına aittir ve davranış içermeyen bir veri taşıyıcı/model gibidir.

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
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Position | `public string Position { get; set; }` | Kurumdaki pozisyonu/ünvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlangıç tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktif çalışma durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = true`. `HireDate` ve `Id` için özel bir varsayılan atama tanımlı değil (CLR default).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Domain katmanından tek bir varlık görünür durumda; diğer katmanlar (Application/Infrastructure/API) ve davranışlar bu dosyadan çıkarılamıyor.
- Varlıkta alan validasyonu veya iş kuralı uygulanmıyor; bu yaklaşım genelde Application/Infrastructure katmanlarına bırakılır, ancak nerede ele alındığı belirsiz.### Project Overview
- Proje adı: Library (yalnızca `Library.Domain` katmanı görülebiliyor)
- Amaç: Kütüphane alan modelini ve sözleşmelerini (özellikle repository arayüzlerini) tanımlamak.
- Hedef çatı: Bu dosyadan anlaşılmıyor; C# async imzalarından modern .NET (Core/5+) kullanımı ima edilse de kesin değil.
- Mimari: Katmanlı/Clean Architecture eğilimli. Domain katmanı içinde `Entities` ve `Interfaces` bulunuyor; repository sözleşmeleri Domain’de, implementasyonların başka bir katmanda (genellikle Infrastructure) olması beklenir.
- Proje/Assembly’ler:
  - Library.Domain — Domain varlıkları ve arayüzleri (repository sözleşmeleri).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)

---
### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlıkları için repository sözleşmesini genişleterek ada göre getirme ve ilişkili kitaplarla birlikte getirme gibi alan-özel sorguları tanımlar. Domain katmanında yer alır; veri erişiminin implementasyonu üst katmanlara sızmadan, arayüz üzerinden soyutlanmasını sağlar.

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
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Kategori adını kullanarak bir `BookCategory` döndürür (yoksa `null`). |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Verilen kimlikle kategoriyi ilişkili kitaplarıyla birlikte yükler (yoksa `null`). |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış içermez; asenkron veri erişim sözleşmesi tanımlar.
- `GetWithBooksAsync` ilişkili koleksiyonların yüklenmesini (eager loading) ima eder; ayrıntılar implementasyonda belirlenir.
- Dönüş tiplerinde `null` olasılığı, bulunamama durumunu ifade eder.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; uygulama/service katmanları tarafından çağrılması beklenir (bu dosyadan kesinleşmiyor).
- Aşağı akış: Harici bağımlılık yok (implementasyonunda veri kaynağına bağımlılık olabilir).
- İlişkili tipler: `BookCategory` (`Library.Domain.Entities`), `IRepository<BookCategory>`.

**7. Eksikler ve Gözlemler**
- Asenkron metotlarda `CancellationToken` parametresi bulunmuyor; uzun süren sorgularda iptal desteği eksik olabilir. 

Genel Değerlendirme
- Kod, Domain katmanında repository sözleşmesi yaklaşımını benimsiyor ve Clean Architecture’a uygun bir ayrım işareti taşıyor.
- Hedef framework, dış bağımlılıklar ve diğer katmanlar bu dosyadan belirlenemiyor.
- Asenkron imzalarda `CancellationToken` eksikliği dikkat çekiyor; ileride eklenmesi dayanıklılık ve iptal senaryoları için faydalı olacaktır.### Project Overview
- Proje adı: Library (bu isim `Library.Domain` namespace’inden çıkarılmıştır)
- Amaç: Kitaplarla ilgili domain sözleşmelerini tanımlamak; özellikle `Book` varlığı için repository kontratını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture/Layered (Domain katmanı tanımlı)
  - Domain: Entity’ler ve repository kontratları; iş kurallarının merkezi.
  - Diğer katmanlar (Application/Infrastructure/API): Bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain entity ve kontratlar (repository arayüzleri)
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor (harici bağımlılık görünmüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain (Library.Domain)
  ↑ (kullanır)
Application (bu dosyadan anlaşılmıyor)
  ↑
Infrastructure (bu dosyadan anlaşılmıyor)
  ↑
API/Presentation (bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlığı için repository sözleşmesini tanımlar. Temel `IRepository<Book>` kontratını genişleterek kullanılabilir kitapları listeleme ve ISBN’e göre tekil sorgu gibi domain-özel işlemleri ekler. Domain katmanına aittir.

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
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Kullanılabilir durumdaki tüm `Book` kayıtlarını döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen `isbn` ile eşleşen `Book` kaydını döndürür; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetAvailableBooksAsync`: “kullanılabilir” olma kriteri implementasyona bırakılmıştır; bu dosyadan anlaşılmıyor.
- `GetByISBNAsync`: ISBN benzersiz kabul edilir; bulunamazsa `null` döner. ISBN doğrulama kuralları bu dosyadan anlaşılmıyor.
- Asenkron sözleşme: I/O tabanlı veri erişimi beklentisi.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/use-case’ler tarafından çağrılması beklenir (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** `IRepository<Book>` (genel CRUD sözleşmesi), `Book` entity.
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `Library.Domain.Interfaces.IRepository<T>` (tanımı bu dosyada yok).

Genel Değerlendirme
- Domain katmanı var ve repository kontratı net; ancak diğer katmanlar görünmediği için tüm mimari akış teyit edilemiyor.
- `IRepository<Book>` detayları ve “kullanılabilirlik” ölçütü belirsiz; uygulamada tutarlı bir tanım gerektirir.
- Hedef framework, konfigürasyon ve harici paket kullanımı bu dosyadan tespit edilemiyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alan modelini ve sözleşmelerini (özellikle müşteri yönetimi) tanımlamak; repository arayüzleri üzerinden veri erişimi sözleşmesi sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli; görünen katman Domain (entity’ler ve repository arayüzleri). Domain, uygulama mantığı ve altyapı tarafından referans alınacak merkez katmandır. Keşfedilen proje/assembly: Library.Domain — rolü: `Entities` ve `Interfaces` ile alan modelini ve kalıcı depolama sözleşmelerini tanımlamak. Görünen harici paket yok. Konfigürasyon gereksinimleri: bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain

---

### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` varlıkları için veri erişim sözleşmesini tanımlar. Domain katmanına aittir ve uygulama/altyapı katmanları bu arayüzü implemente/çağırır. E-posta, üyelik numarası ve aktif müşteriler için sorgu operasyonlarını standardize eder.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<Customer>`
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
- Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre müşteriyi getirir; yoksa `null`. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre müşteriyi getirir; yoksa `null`. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif durumdaki tüm müşterileri döner. |

**5. Temel Davranışlar ve İş Kuralları**
- DTO — davranış yok. Default değerler: bu dosyadan anlaşılmıyor (sadece sözleşme).
- Null dönme sözleşmesi: Aranan müşteri bulunamazsa `Customer?` sonuçları `null` olabilir.
- Asenkron erişim sözleşmesi: Tüm metotlar `Task` tabanlıdır; IO-odaklı veri kaynağı beklenir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/use case’ler tarafından çağrılması beklenir.
- **Aşağı akış:** Yok (arayüz seviyesinde).
- **İlişkili tipler:** `Customer` (entity), `IRepository<Customer>` (genel repository sözleşmesi).

**7. Eksikler ve Gözlemler**
- Filtreleme/arama kapsamı e-posta ve üyelik numarası ile sınırlı; sayfalama/sıralama sözleşmesi yok (ihtiyaca göre eklenebilir).
- `IRepository<Customer>` implementasyonu bu depoda görünmüyor; genel CRUD sözleşmesinin detayları bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Kod, Clean/katmanlı mimaride Domain odaklı tasarım sinyali veriyor; ancak yalnızca bir arayüz ve entity referansı görünüyor. Diğer katmanlar (Application, Infrastructure, API) bu depoda yok veya gösterilmemiş.
- Bağımlılıklar ve konfigürasyon anahtarları görünmediğinden çalışma zamanı gereksinimleri belirsiz.
- Sözleşme açık ve odaklı; null-dönüş ve asenkron desen net. Genişlemeye açık alanlar: sayfalama/sıralama/soft-delete farkındalığı gibi standart repository yeteneklerinin sözleşmeye eklenmesi.### Project Overview
Proje adı: Library. Amaç: Domain katmanında generic bir repository sözleşmesi tanımlayarak entity erişimi için ortak bir CRUD sözleşmesi sağlamak. Hedef framework: Bu dosyadan anlaşılmıyor.

Mimari desen: Temel Clean Architecture/N‑Tier izleri. Bu katman Domain olarak konumlanmış ve sadece sözleşmeleri/interface’leri barındırıyor; uygulama, altyapı ve sunum katmanları bu dosyadan görünmüyor.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Domain: Domain sözleşmeleri (ör. `IRepository<T>`) ve muhtemel entity/aggregateler için çekirdek katman.

Kullanılan harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Interfaces)
  └─ (Bu dosyadan görülen dışa bağımlılık yok; diğer katmanlara doğru kullanım beklenir)

---
### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
Generic `IRepository<T>` arayüzü, domain varlıkları için asenkron CRUD operasyonlarının sözleşmesini tanımlar. Clean Architecture/N‑Tier içinde Domain katmanına aittir ve Infrastructure’daki somut veri erişim implementasyonları için kontrat sağlar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygılar:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı asenkron olarak getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm `T` varlıklarını asenkron olarak listeler. |
| AddAsync | `Task AddAsync(T entity)` | Yeni `T` varlığını ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Var olan `T` varlığını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (tipik olarak Application/Service katmanı tarafından kullanılır, DI üzerinden çözümlenir).
- **Aşağı akış:** Harici bağımlılık yok (somut implementasyonlar Infrastructure’da veri kaynağına bağlanır).
- **İlişkili tipler:** `T` generic parametresiyle temsil edilen domain entity’leri.

**7. Eksikler ve Gözlemler**
- İptal desteği için `CancellationToken` parametreleri yok; uzun süren I/O işlemlerinde gerekli olabilir.
- Listeleme için sayfalama/sıralama/filtreleme sözleşmesi bulunmuyor; `GetAllAsync` büyük veri kümelerinde verimsiz olabilir. 

---
Genel Değerlendirme
- Mevcut kod sadece Domain arayüzünü gösteriyor; Application/Infrastructure/API katmanları görünmüyor.
- Arayüz sade ve anlaşılır; ancak üretim senaryoları için `CancellationToken`, sayfalama ve belki `SaveChanges`/unit of work gibi desenlerin sözleşmeye eklenmesi değerlendirilebilir.
- Hata yönetimi sözleşme seviyesinde tanımlı değil; implementasyonlarda tutarlı exception politikası belirlenmeli.### Project Overview
- Proje adı: Library.Domain
- Amaç: Kütüphane alanına ait domain sözleşmelerini tanımlamak; özellikle `Staff` varlığı için repository arayüzünü sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean eğilimli yapı; yalnızca Domain katmanı (sözleşmeler) görülebiliyor. Repository arayüzleri, uygulama/altyapı katmanları tarafından uygulanmak üzere tanımlanmış.
- Proje/Assembly’ler:
  - Library.Domain — Domain katmanı; entity ve repository sözleşmeleri.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain]
  (Yalnızca domain sözleşmeleri görünür; başka katmanlara bağımlılık veya akış bu dosyadan çıkarılamıyor.)

---
### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` entity’si için repository sözleşmesini tanımlar. Genel `IRepository<Staff>`’i genişleterek e-posta ile arama ve aktif personel listeleme gibi `Staff`’a özgü sorguları ekler. Domain katmanına aittir ve altyapı katmanında uygulanması beklenir.

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
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | Verilen e-posta ile eşleşen personeli asenkron olarak getirir; bulunamazsa `null`. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki tüm personelleri asenkron olarak listeler. |

**5. Temel Davranışlar ve İş Kuralları**
Interface — davranış yok. Uygulama tarafında e-posta eşleşmesi ve “aktif” kriterinin nasıl belirlendiği bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama/servis katmanları tarafından çağrılır.
- **Aşağı akış:** Bu arayüzü uygulayan altyapı (örn. ORM/DB erişimi) bileşenleri.
- **İlişkili tipler:** `Library.Domain.Entities.Staff`, `IRepository<Staff>`

Genel Değerlendirme
- Sadece domain sözleşmesi mevcut; uygulama ve altyapı katmanları görünmüyor.
- `IRepository<Staff>` ve `Staff` tanımları bu depoda/dosyada yer almadığı için sözleşme kapsamının tamamı görülemiyor.
- Validasyon, hata yönetimi ve “aktif” olma kriterinin tanımı uygulama/altyapı seviyesinde netleştirilmeli.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alan varlıkları (`Book`, `BookCategory`, `Staff`, `Customer`) için kalıcı veri erişimini sağlamak ve EF Core ile ilişkisel şema yapılandırmasını yönetmek.
- Hedef framework: Bu dosyadan kesin değil. EF Core kullanımı .NET (Core/5+) ekosistemini işaret eder.
- Mimari desen: Katmanlı (Domain ↔ Infrastructure). Domain katmanı sadece varlıkları barındırır; Infrastructure katmanı EF Core tabanlı kalıcılık ve model eşlemesini içerir.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain: Alan varlıkları (`Entities`) tanımları.
  - Library.Infrastructure: Kalıcılık ve EF Core `DbContext` konfigürasyonu.
- Kullanılan dış paketler/çerçeveler:
  - Microsoft.EntityFrameworkCore (EF Core)
- Konfigürasyon gereksinimleri:
  - `DbContextOptions<LibraryDbContext>` ile sağlanan bağlantı yapılandırması gerekir (bağlantı dizesi anahtarı bu dosyadan anlaşılmıyor).

### Architecture Diagram
[Library.Infrastructure] --> [Library.Domain]

---

### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
`LibraryDbContext`, EF Core üzerinden kütüphane alan varlıklarının veritabanı eşlemesini ve kısıtlarını yapılandırır. Infrastructure katmanına aittir ve Domain varlıklarını kalıcı katmana map eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `Microsoft.EntityFrameworkCore.DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlamı ve sağlayıcı/bağlantı yapılandırması

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | DI aracılığıyla bağlam seçeneklerini alır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlıkları için sorgu ve komut kümesi. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlıkları için sorgu ve komut kümesi. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlıkları için sorgu ve komut kümesi. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlıkları için sorgu ve komut kümesi. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Varlık eşlemeleri, kısıtlar ve ilişkileri tanımlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book`:
  - Zorunlu alanlar: `Title` (max 200), `Author` (max 150), `ISBN` (max 20).
  - `ISBN` için tekil indeks.
  - `BookCategory` ile `HasOne`–`WithMany` ilişki; FK `BookCategoryId`; silmede `DeleteBehavior.SetNull` (kategori silinince kitapların FK’si null yapılır).
- `BookCategory`:
  - Zorunlu alan: `Name` (max 100); `Description` (max 500).
  - `Name` için tekil indeks.
- `Staff`:
  - Zorunlu alanlar: `FirstName`, `LastName` (max 100), `Email` (max 200), `Position` (max 100).
  - `Phone` (max 20).
  - `Email` için tekil indeks.
- `Customer`:
  - Zorunlu alanlar: `FirstName`, `LastName` (max 100), `Email` (max 200), `MembershipNumber` (max 50).
  - `Phone` (max 20), `Address` (max 500).
  - `Email` ve `MembershipNumber` için tekil indeksler.
- Tüm varlıklar için `Id` birincil anahtar olarak tanımlı.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; repository/Unit of Work, uygulama servisleri veya API katmanı tarafından kullanılır.
- **Aşağı akış:** `Microsoft.EntityFrameworkCore` API’leri ve `Library.Domain.Entities` (`Book`, `BookCategory`, `Staff`, `Customer`).
- **İlişkili tipler:** `Book`, `BookCategory`, `Staff`, `Customer`.

**7. Eksikler ve Gözlemler**
- `BookCategory` silmede `SetNull` kullanımı, `BookCategoryId`’nin nullable olması gerektiğini ima eder; varlık tanımında bu uyum bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Katman ayrımı net: Domain varlıkları, Infrastructure kalıcılık ve eşlemeler. Ek katmanlar (Application, API) bu depodan görünmüyor.
- EF Core konfigürasyonları alan doğrulamaları ve benzersizlik kısıtlarını kapsıyor. Eşzamanlılık belirteci (concurrency token) veya denetim (audit) alanları yapılandırması görünmüyor; ihtiyaçlara göre eklenebilir.
- Çalıştırma için uygun `DbContext` konfigürasyonu ve bağlantı dizesi sağlanması gerekir; appsettings anahtarları bu dosyada belirtilmemiş.### Project Overview
Bu depo, `Library` adında katmanlı bir mimariyi izleyen bir kütüphane yönetimi alanı için altyapı bileşenlerini barındırıyor. Amaç, veritabanı erişimi ve repository uygulamalarını DI üzerinden sunmaktır. Hedef çalışma zamanı .NET ve EF Core ekosistemidir; kesin .NET sürümü bu dosyadan anlaşılmıyor. 

Mimari desen: Clean Architecture benzeri. `Infrastructure` katmanı, `Domain` katmanındaki `Interfaces`’ları uygulayarak veri erişimini sağlar. Uygulama/başvuru kompozisyon kökü (muhtemelen API veya UI) DI ile `Infrastructure`’ı ekler.

Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain kontratları (`Interfaces`) (bu dosyada referanslandı)
- Library.Infrastructure — Veri erişimi, EF Core `DbContext` ve repository implementasyonları (bu dosya)

Kullanılan temel paket/çerçeveler:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Configuration

Konfigürasyon gereksinimleri:
- Connection string anahtarı: `DefaultConnection` (SQL Server için)

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, `Infrastructure` katmanının DI (Dependency Injection) kayıtlarını merkezi olarak sağlar. EF Core `DbContext` konfigürasyonunu ve repository implementasyonlarını ilgili domain interface’lerine bağlar. Mimari olarak Infrastructure katmanına aittir.

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
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core `LibraryDbContext`’i SQL Server ile ve repository implementasyonlarını DI konteynerine ekler. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server sağlayıcısıyla kaydedilir; connection string `configuration.GetConnectionString("DefaultConnection")` üzerinden okunur.
- Repository kayıtları `Scoped` yaşam süresiyle yapılır:
  - `IBookRepository` -> `BookRepository`
  - `IBookCategoryRepository` -> `BookCategoryRepository`
  - `IStaffRepository` -> `StaffRepository`
  - `ICustomerRepository` -> `CustomerRepository`
- `IServiceCollection` için extension pattern kullanılarak kompozisyon kökünde tek çağrıyla tüm altyapı kayıtları yapılabilir.

**6. Bağlantılar**
- Yukarı akış: Kompozisyon kökünden (örn. `Program.cs`/`Startup`) çağrılır.
- Aşağı akış: `LibraryDbContext`, EF Core SQL Server sağlayıcısı; repository implementasyonları (`BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`) ve karşılık gelen domain interface’leri.
- İlişkili tipler: `Library.Infrastructure.Data.LibraryDbContext`, `Library.Infrastructure.Repositories.*`, `Library.Domain.Interfaces.*`

**7. Eksikler ve Gözlemler**
- `DefaultConnection` değerinin varlığı/boşluğu için bir doğrulama veya hata mesajı bulunmuyor; yanlış konfigürasyonda çalışma zamanı hatası oluşabilir.

---

Genel Değerlendirme
- Clean Architecture’a uygun bağımlılık yönü (Infrastructure -> Domain) korunmuş görünüyor.
- DI kayıtları tek noktada toplanmış; bakım kolay.
- Konfigürasyon doğrulaması ve opsiyonel sağlık kontrolleri (örn. connection string doğrulama) eklenebilir.
- Sadece bu dosyadan uygulamanın diğer katmanları (Application, API) ve ek altyapı bileşenleri görünmüyor; kapsam sınırlı.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki entity’ler için kalıcı veri erişimi sağlamak (ör. kitap kategorileri). Hedef framework: bu dosyadan anlaşılmıyor. Mimari, Domain ve Infrastructure katmanlarının varlığına dayanarak katmanlı (Clean/N‑Tier benzeri) bir yapı izleniyor: Domain iş kuralları ve sözleşmeleri barındırır; Infrastructure bu sözleşmelerin somut veri erişim implementasyonlarını ve EF Core tabanlı persistence’ı sağlar. Keşfedilen projeler/assembly’ler: Library.Domain (entity’ler ve repository interface’leri), Library.Infrastructure (EF Core tabanlı repository implementasyonları). Harici paketler/çatı: Microsoft.EntityFrameworkCore (EF Core). Konfigürasyon: `LibraryDbContext` kullanımı, bir veritabanı bağlantı dizesi gerektireceğini ima eder; anahtar adları ve sağlayıcı bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <-- referenced by --  Library.Infrastructure (Repositories, EF Core)

---
### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategoryRepository`, `IBookCategoryRepository` sözleşmesini EF Core üzerinden gerçekleştirir ve `BookCategory` entity’si için temel CRUD ve sorgulama işlemlerini sağlar. Mimari olarak Infrastructure/Persistence katmanındadır ve Domain katmanındaki entity ve interface’lere bağımlıdır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `BookCategory` DbSet’i üzerinden veri işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Kurucu | `BookCategoryRepository(LibraryDbContext context)` | EF Core bağlamını enjekte eder. |
| GetByIdAsync | `Task<BookCategory?> GetByIdAsync(Guid id)` | ID’ye göre kategori döndürür. |
| GetAllAsync | `Task<IEnumerable<BookCategory>> GetAllAsync()` | Tüm kategorileri listeler. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşeni döndürür. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili `Books` koleksiyonuyla birlikte kategoriyi yükler. |
| AddAsync | `Task AddAsync(BookCategory entity)` | Yeni kategori ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(BookCategory entity)` | Kategori günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Varsa kategoriyi siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetWithBooksAsync` `Include(c => c.Books)` ile ilişkili kitapları eager load eder.
- `GetByNameAsync` doğrudan eşitlik kıyaslar; büyük/küçük harf duyarlılığı veritabanı kolasyonuna bağlıdır.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her işlemde `SaveChangesAsync` çağırır; birim-iş (Unit of Work) yerine işlem-başı kalıcılık uygulanır.
- `DeleteAsync` aranan kategori yoksa hiçbir işlem yapmadan döner.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya API katmanı çağırır.
- **Aşağı akış:** `LibraryDbContext`
- **İlişkili tipler:** `BookCategory`, `IBookCategoryRepository`, `LibraryDbContext`

**7. Eksikler ve Gözlemler**
- `CancellationToken` parametreleri yok; uzun süren DB işlemlerinde iptal desteği eksik.
- Her repository metodunda `SaveChangesAsync` çağrılması, çok-adımlı işlemlerde tutarlılık ve performans açısından Unit of Work ihtiyacını işaret ediyor.
- Hata/istisna yönetimi ve eşzamanlılık (concurrency) kontrolü bulunmuyor. 
- Sorgularda sayfalama/filtreleme desteği yok; `GetAllAsync` büyük veri setlerinde maliyetli olabilir.

### Genel Değerlendirme
Kod, Infrastructure katmanında EF Core ile temiz ve doğrudan bir repository uygulaması sunuyor. Domain ve Infrastructure ayrımı net. Geliştirilebilir alanlar: Unit of Work veya dışarıdan yönetilen `SaveChanges`, `CancellationToken` desteği, sayfalama/filtreleme, hata ve concurrency yönetimi. Konfigürasyon ve hedef framework bilgisi bu dosyadan belirlenemiyor; proje genelinde appsettings ve DbContext konfigürasyonunun gözden geçirilmesi önerilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kütüphane alanındaki `Book` varlıklarına yönelik veri erişimi sağlamak; repository üzerinden kalıcı katman operasyonlarını gerçekleştirmek.
- Hedef framework: Bu dosyadan anlaşılmıyor (modern .NET/EF Core kullanımı ima ediliyor).
- Mimari desen: Clean Architecture benzeri katmanlı yapı
  - Domain: Varlıklar (`Book`), kontratlar (`IBookRepository`)
  - Infrastructure: EF Core tabanlı veri erişim ve repository implementasyonları (`BookRepository`, `LibraryDbContext`)
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain varlıkları ve repository arayüzleri
  - Library.Infrastructure — EF Core DbContext ve repository implementasyonları
- Kullanılan ana paket/çatı:
  - Entity Framework Core (`Microsoft.EntityFrameworkCore`)
- Konfigürasyon gereksinimleri:
  - `LibraryDbContext` için bağlantı dizesi ve EF Core sağlayıcı konfigürasyonu gerekli; detaylar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <-  Library.Infrastructure (Repositories, Data/DbContext)

---

### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`BookRepository`, `IBookRepository` sözleşmesini EF Core ile gerçekleştiren bir repository’dir. `Book` varlıkları için kimlik, ISBN ve uygunluk durumuna göre sorgulama ile CRUD benzeri işlemler sunar. Mimari olarak Infrastructure katmanında yer alır ve `LibraryDbContext` üzerinden veri erişimi yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Book` DbSet’i üzerinden veri erişimi ve `SaveChangesAsync` çağrıları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookRepository(LibraryDbContext context)` | DbContext bağımlılığını alır. |
| GetByIdAsync | `public Task<Book?> GetByIdAsync(Guid id)` | Kimliğe göre tek `Book` döner; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<Book>> GetAllAsync()` | Tüm `Book` kayıtlarını listeler. |
| GetAvailableBooksAsync | `public Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable` true olan kitapları listeler. |
| GetByISBNAsync | `public Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre ilk eşleşen kitabı döner; yoksa `null`. |
| AddAsync | `public Task AddAsync(Book entity)` | Yeni kitabı ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Book entity)` | Verilen kitabı günceller ve değişiklikleri kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Bulunursa kitabı siler ve değişiklikleri kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetAvailableBooksAsync` yalnızca `IsAvailable == true` kayıtlarını getirir.
- `GetByISBNAsync` tekil sonuç bekler; birden fazla varsa ilkini döner.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` çalıştırır; işlem bazlı kayıt yaklaşımı.
- `DeleteAsync` kayıt bulunamazsa sessizce hiçbir işlem yapmaz.
- EF Core üzerinden çağrılar asenkron yapılır; izleme/gölge durumları ve eşzamanlılık bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Service katmanı veya API controller’ları tarafından çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext` ve onun `Books` DbSet’i.
- **İlişkili tipler:** `Book` (Domain entity), `IBookRepository` (Domain arayüzü), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` desteği yok; uzun süren DB işlemlerinde iptal desteği eklenebilir.
- Her operasyon `SaveChangesAsync` çağırıyor; birim-iş (Unit of Work) veya çok-adımlı işlemler için transaction yönetimi bu düzeyde yok.
- Eşzamanlılık (concurrency) ve optimistik kilitleme için bir strateji görünmüyor.
- `UpdateAsync` izleme durumunu varsayarak `Update` çağırıyor; kısmi güncellemelerde istenmeyen alan güncellemelerine yol açabilir.

---

### Genel Değerlendirme
Kod tabanı Clean Architecture yaklaşımına uygun olarak Domain ve Infrastructure ayrımını işaret ediyor. Repository, EF Core ile basit ve anlaşılır bir veri erişimi sağlıyor. İyileştirme alanları: iptal belirteçleri, birim-iş/transaction yönetimi, eşzamanlılık stratejisi, kısmi güncellemelerde izleme/durum yönetimi ve hata/istisna zenginleştirmesi. Bağlantı dizesi ve DbContext yapılandırması dışarıdan bekleniyor; konfigürasyon sözleşmesi dokümante edilmelidir.### Project Overview
- Proje adı: Library (koddan türetilen namespace’lere göre)
- Amaç: Kütüphane alanındaki `Customer` varlıkları için kalıcı veri erişimi sağlamak (repository deseni).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture eğilimli katmanlama.
  - Domain: `Library.Domain.Entities`, `Library.Domain.Interfaces` — temel varlıklar ve kontratlar.
  - Infrastructure: `Library.Infrastructure.*` — EF Core tabanlı veri erişimi ve repository implementasyonları.
- Projeler/Assembly’ler:
  - Library.Domain — Varlıklar (`Customer`) ve repository kontratları (`ICustomerRepository`).
  - Library.Infrastructure — EF Core `DbContext` ve repository implementasyonları.
- Kullanılan dış paketler/çerçeveler:
  - Microsoft Entity Framework Core (EF Core) — `DbContext`, `DbSet`, `ToListAsync`, `FindAsync` vb.
- Konfigürasyon gereksinimleri:
  - Bağlantı dizesi ve EF Core sağlayıcı konfigürasyonu bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)
↑
Library.Infrastructure (Data, Repositories)

---
### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`CustomerRepository`, `ICustomerRepository` kontratını EF Core ile gerçekleştiren bir repository’dir. `Customer` varlıkları için CRUD ve sorgulama operasyonları sağlar. Clean Architecture’da Infrastructure/Data Access katmanında yer alır.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `ICustomerRepository`
- Namespace: `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `Customer` varlıklarının sorgulanması ve kaydedilmesi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `CustomerRepository(LibraryDbContext context)` | EF Core bağlamını alır. |
| GetByIdAsync | `Task<Customer?> GetByIdAsync(Guid id)` | Id’ye göre müşteriyi getirir. |
| GetAllAsync | `Task<IEnumerable<Customer>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre tek kayıt getirir. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre tek kayıt getirir. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive` olan müşterileri listeler. |
| AddAsync | `Task AddAsync(Customer entity)` | Yeni müşteri ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(Customer entity)` | Müşteriyi günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteriyi bulup siler ve kaydeder (varsa). |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByEmailAsync` ve `GetByMembershipNumberAsync` tekil kayıt döndürür; eşleşme yoksa `null`.
- `GetActiveCustomersAsync` yalnızca `IsActive == true` olanları döndürür.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync()` ile anında kalıcılık sağlar.
- `DeleteAsync` ilgili kayıt yoksa sessizce hiçbir işlem yapmaz.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; `ICustomerRepository` tüketicileri (servisler/handler’lar).
- Aşağı akış: `LibraryDbContext` ve `DbSet<Customer>`.
- İlişkili tipler: `Customer`, `ICustomerRepository`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Yöntemlerde `CancellationToken` desteği yok.
- `GetAllAsync` için sayfalama/filtreleme yok; büyük veri kümelerinde maliyetli olabilir.
- Her işlemde `SaveChangesAsync` çağrısı Unit of Work desenine uygun toplu işlemleri zorlaştırabilir.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım). Amaç: Kitap varlıkları için depo (repository) işlemleri; Domain’deki `Book` varlığını `IBookRepository` sözleşmesiyle yönetmek. Hedef çatı bu dosyadan anlaşılmıyor (.NET sürümü belirtilmemiş).
- Mimari desen: Katmanlı (N-Tier). Domain katmanı (`Library.Domain`) varlık ve sözleşmeleri (entity, repository interface) içerir. Infrastructure katmanı (`Library.Infrastructure`) Domain sözleşmelerinin somut implementasyonlarını sağlar (ör. bellek içi repository).
- Projeler/Assembly’ler:
  - Library.Domain — `Book` entity ve `IBookRepository` arayüzü.
  - Library.Infrastructure — Repository implementasyonları (ör. `InMemoryBookRepository`).
- Kullanılan dış paketler/çatı: Bu dosyadan görünmüyor (yalnızca BCL/LINQ).
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor; bellek içi uygulama bağlantı veya ayar gerektirmiyor.

### Architecture Diagram
Library.Infrastructure → Library.Domain

---

### `Library.Infrastructure/Repositories/InMemoryBookRepository.cs`

**1. Genel Bakış**
`InMemoryBookRepository`, `IBookRepository` arayüzünü bellek içi bir `List<Book>` ile gerçekleştiren basit bir depo implementasyonudur. Geliştirme/test senaryoları için kalıcı depolama olmaksızın `Book` varlıklarını sorgulama ve değiştirme işlevi sağlar. Mimari olarak Infrastructure katmanına aittir ve Domain’deki sözleşmeyi uygular.

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
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Belirtilen `Id` ile eşleşen kitabı döndürür; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitapları döndürür. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre tek kitabı bulur; yoksa `null`. |
| AddAsync | `Task AddAsync(Book entity)` | Yeni kitabı listeye ekler. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Eşleşen `Id` bulunduysa öğeyi verilen entity ile değiştirir. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Eşleşen `Id` bulunduysa kitabı listeden siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Depolama bellek içi `List<Book>` ile yapılır; kalıcılık yok.
- `UpdateAsync`: `Id` bulunamazsa sessizce hiçbir işlem yapmaz (no-op).
- `DeleteAsync`: Kitap bulunamazsa sessizce no-op.
- `GetAvailableBooksAsync`: `Book.IsAvailable` alanına göre filtreleme yapar.
- Tüm metotlar senkron çalışıp `Task.FromResult`/`Task.CompletedTask` ile sarmalanır; gerçek asenkron I/O yok.
- Girdi validasyonu, benzersizlik (ör. ISBN) ve hata fırlatma mantığı yoktur.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; `IBookRepository` isteyen servisler/handler’lar tarafından çağrılır.
- **Aşağı akış:** `Library.Domain.Entities.Book` varlığına ve `Library.Domain.Interfaces.IBookRepository` arayüzüne bağımlıdır.
- **İlişkili tipler:** `Book`, `IBookRepository`.

**7. Eksikler ve Gözlemler**
- Thread-safety yok; çoklu eşzamanlı erişimde `List<T>` yarış koşullarına açık.
- Güncelleme/silmede varlık bulunamadığında geri bildirim yok; çağıran taraf başarısızlığı ayırt edemez.
- ISBN benzersizlik kontrolü ve giriş validasyonu eksik.
- Gerçek asenkron I/O ve kalıcı veri kaynağı entegrasyonu bulunmuyor (yalnızca test/dummy amaçlı uygun). 

---

Genel Değerlendirme
- Mevcut kod, Infrastructure içinde bellek içi bir repository ile sınırlı; Domain’deki arayüz ve entity’lere bağlı net bir katmanlaşma var.
- Üretim senaryoları için eşzamanlılık, hata yönetimi, validasyon ve kalıcı depolama (ör. EF Core) entegrasyonu eksik.
- Asenkron imzalar I/O yapmadığı için potansiyel olarak yanıltıcı; gerçek veri kaynağına geçişte uygunlama gerektirir.### Project Overview
Bu repository, bir kütüphane (Library) alanına ait katmanlı/Clean Architecture yaklaşımıyla yapılandırılmış gibi görünüyor. Görünen katmanlar: Domain (entity ve kontratlar) ve Infrastructure (EF Core tabanlı repository implementasyonları). Amaç, `Staff` varlığı için kalıcı veri erişimini EF Core üzerinden sağlamaktır. Hedef framework sürümü bu dosyadan anlaşılmıyor. Domain katmanı `Library.Domain.Entities` ve `Library.Domain.Interfaces` ad alanlarıyla varlık ve repository sözleşmelerini barındırır. Infrastructure katmanı `Library.Infrastructure` altında EF Core `DbContext` ve repository implementasyonlarını içerir.

Projeler/assembly’ler (çıkarılabilenler):
- Library.Domain — Varlıklar (`Staff`) ve arayüzler (`IStaffRepository`)
- Library.Infrastructure — EF Core `DbContext` (`LibraryDbContext`) ve repository implementasyonları

Kullanılan dış paket/çerçeveler:
- Entity Framework Core (`Microsoft.EntityFrameworkCore`)

Konfigürasyon gereksinimleri:
- Veritabanı bağlantı dizesi ve EF Core sağlayıcısı gerekli, ancak anahtar adları ve ayrıntılar bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

(Olası tipik akış, bu dosyadan tam teyit edilemese de, genellikle:)
API/Presentation -> Application -> Domain
Application -> Infrastructure -> Domain

---
### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`StaffRepository`, `IStaffRepository` sözleşmesini EF Core ile gerçekleştiren veri erişim katmanı (Infrastructure) sınıfıdır. `Staff` varlıkları için CRUD ve sorgulama operasyonlarını `LibraryDbContext` üzerinden asenkron sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `Staff` DbSet’i üzerinden veri erişimi

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffRepository(LibraryDbContext context)` | EF Core bağlamını DI ile alır. |
| GetByIdAsync | `public Task<Staff?> GetByIdAsync(Guid id)` | Birincil anahtarla `Staff` bulur. |
| GetAllAsync | `public Task<IEnumerable<Staff>> GetAllAsync()` | Tüm `Staff` kayıtlarını döner. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | E-posta eşleşen ilk `Staff` kaydını döner. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive = true` olan personelleri listeler. |
| AddAsync | `public Task AddAsync(Staff entity)` | Yeni `Staff` ekler ve kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Staff entity)` | Var olan `Staff` günceller ve kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | ID’ye göre `Staff` siler; yoksa işlem yapmaz. |

**5. Temel Davranışlar ve İş Kuralları**
- Yazma operasyonları (`AddAsync`, `UpdateAsync`, `DeleteAsync`) her çağrıda `SaveChangesAsync` ile transaction’ı bağlam düzeyinde tamamlar.
- `DeleteAsync` aranan kayıt bulunamazsa sessizce no-op yapar; exception fırlatılmaz.
- `GetActiveStaffAsync` yalnızca `IsActive` özelliği true olanları döner.
- `FindAsync` birincil anahtar üzerinden hızlı arama yapar.
- Sorgular default tracking ile çalışır (ayrıca `AsNoTracking` kullanılmamış).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak Application/Service katmanındaki iş akışları tarafından çağrılır.
- **Aşağı akış:** `LibraryDbContext`, EF Core (`Microsoft.EntityFrameworkCore`)
- **İlişkili tipler:** `Staff` (entity), `IStaffRepository` (kontrat), `LibraryDbContext` (EF Core bağlamı)

**7. Eksikler ve Gözlemler**
- CancellationToken desteği yok; uzun süren DB işlemlerinde iptal kabiliyeti eksik.
- Birim-iş (Unit of Work) deseni yok; her metotta ayrı `SaveChangesAsync` çağrısı yapılıyor, çoklu operasyon senaryolarında atomiklik zorlaşabilir.
- `DeleteAsync`’te kayıt bulunamadığında sessiz no-op iş kuralı olabilir; bazı durumlarda çağıranı bilgilendirmek gerekebilir.

---
Genel Değerlendirme
- Mimari Clean Architecture yönelimli; Domain ve Infrastructure katmanları net ayrılmış. Ancak Application ve API katmanları bu girdiyle görünmüyor.
- Repository uygulaması basit ve okunabilir, ancak iptal belirteci, hatalı durum bildirim stratejileri (ör. not-found) ve birim-iş deseni entegrasyonu açısından iyileştirilebilir.
- Konfigürasyon ve hedef framework bilgileri eksik; çözüm düzeyinde dokümantasyon önerilir.### Project Overview
- Proje adı: Library (ASP.NET Core Web API). Amaç: Kitap kategorileri için HTTP uç noktaları sağlamak. Hedef çatı: ASP.NET Core; spesifik .NET sürümü bu dosyadan anlaşılmıyor.
- Mimari desen: N‑Katmanlı. Katmanlar:
  - Sunum/API: `Library` — HTTP endpoint’leri ve istek/yanıt dönüşümü.
  - Uygulama: `Library.Application` — `DTO` ve `Service` sözleşmeleri (iş kuralları ve use‑case’ler).
- Keşfedilen projeler/assembly’ler:
  - Library — Web API (Controllers).
  - Library.Application — `DTO` ve `Interfaces` (servis kontratları).
- Kullanılan dış çerçeveler/paketler:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için HTTP GET uç noktaları sağlar. Sunum/API katmanında yer alır ve uygulama katmanındaki `IBookCategoryService` üzerinden veri okuma işlemlerini yürütür.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori verilerine erişim ve iş kuralları için uygulama katmanı servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `public BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategorileri döndürür; `200 OK` ile `IEnumerable<BookCategoryDto>`. |
| GetById | `public Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID ile tek kategoriyi döndürür; yoksa `404 NotFound`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GET /api/BookCategories`: Tüm kategoriler, `IBookCategoryService.GetAllAsync()` çağrısıyla elde edilir.
- `GET /api/BookCategories/{id}`: `Guid` kısıtlı rota parametresi; servis `null` dönerse `404 NotFound`, aksi halde `200 OK`.
- Controller `ApiController` özniteliği ile model bağlama ve otomatik hata yanıtları (varsa) etkinleşir; bu dosyada ek model doğrulaması gerekmiyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (örn. frontend, Postman) bu controller’ı çağırır; DI üzerinden çözülür.
- **Aşağı akış:** `IBookCategoryService`
- **İlişkili tipler:** `BookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- Tipik CRUD kapsamına göre Create/Update/Delete uç noktaları eksik.
- Güvenlik: Herhangi bir `Authorize` özniteliği veya yetkilendirme bulunmuyor; korumaya ihtiyaç olabilir.

### Genel Değerlendirme
Kod, sunum katmanında yalın ve sorumlulukları ayrıştırılmış bir yapı sergiliyor; Application katmanına doğrudan bağımlılık yalnızca sözleşmeler ve DTO’lar üzerinden. Ancak CRUD kapsamı tamamlanmamış ve yetkilendirme stratejisi görünmüyor. Altyapı/kalıcılık katmanına dair iz bulunmadığından veri erişimi ve konfigürasyon gereksinimleri bu koddan çıkarılamıyor.### Project Overview
Proje adı: Library (ASP.NET Core Web API). Amaç: Kitaplara yönelik CRUD ve sorgulama uç noktaları sağlamak. Hedef framework: ASP.NET Core (kesin sürüm bu dosyadan anlaşılmıyor).

Mimari: Katmanlı/Clean benzeri. Sunum (API) katmanı `Library` altında; Uygulama katmanı `Library.Application` (DTO’lar ve servis contract’ları). Controller, Application katmanındaki servis arayüzü ve DTO’ları üzerinden çalışır.

Projeler/Assembly’ler:
- Library (API/Presentation) — HTTP endpoint’leri (controller).
- Library.Application (Application) — `DTO` tipleri ve `IBookService` gibi arayüzler.

Dış bağımlılıklar:
- `Microsoft.AspNetCore.Mvc` (ASP.NET Core Web API özellikleri).

Yapılandırma gereksinimleri:
- Bu dosyadan özel bir appsettings veya connection string gereksinimi anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplarla ilgili CRUD ve listeleme işlemlerini HTTP üzerinden sunan API controller’dır. Uygulama katmanındaki `IBookService` aracılığıyla iş kurallarını çalıştırır ve API/Persistence ayrımını korur. Sunum (API) katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplar için uygulama servis sözleşmesi; CRUD ve sorgulama operasyonlarını sağlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BooksController(IBookService bookService)` | `IBookService` bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döndürür (`200 OK`). |
| GetById | `public async Task<ActionResult<BookDto>> GetById(Guid id)` | Id’ye göre kitabı getirir; yoksa `404 NotFound`. |
| GetAvailable | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Müsait/erişilebilir kitapları listeler. |
| Create | `public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Yeni kitap oluşturur; `201 Created` ve `Location` header’ı döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Var olan kitabı günceller; yoksa `404 NotFound`, başarılıysa `204 NoContent`. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Kitabı siler; `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` bulunamazsa `NotFound` döner.
- `Create` başarılı olursa `CreatedAtAction(nameof(GetById))` ile yeni kaynağın konumunu bildirir.
- `Update` sırasında `KeyNotFoundException` yakalanır ve `NotFound` döndürülür; aksi halde `NoContent`.
- `Delete` her durumda `NoContent` döndürür; bulunamama durumu bu seviyede ele alınmaz (servis katmanına bırakılmış olabilir).
- Girdi doğrulaması `[ApiController]` model binding hataları için otomatik 400 üretir; özel doğrulama mantığı bu dosyada yok.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri).
- **Aşağı akış:** `IBookService`.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`.

**7. Eksikler ve Gözlemler**
- `Delete` için bulunamayan kayıt durumunda özel hata dönüşü yok; servis istisna fırlatıyorsa burada ele alınmıyor olabilir.
- Yetkilendirme/authorization niteliği yok; hassas operasyonlar (Create/Update/Delete) için rol/kullanıcı bazlı koruma gerekebilir.
- Controller düzeyinde detaylı girdi validasyonu veya hata yönetimi (ör. domain doğrulama hataları için 400/422) tanımlı değil; Application katmanına bırakılmış görünüyor.

---
### Genel Değerlendirme
Kod, net bir API-Application ayrımıyla katmanlı/Clean benzeri mimariye işaret ediyor. Controller yalın tutulmuş ve iş kuralları servis katmanına delega edilmiş. Ancak uç noktalarda tutarlı hata yönetimi (özellikle Delete için NotFound senaryosu) ve güvenlik/authorization yönergeleri görünmüyor. Konfigürasyon ve diğer katmanlar (Domain/Infrastructure) bu örnekten çıkarılamıyor; proje genelini tamamlamak için Application ve olası Infrastructure detaylarının gözden geçirilmesi önerilir.### Project Overview
- Ad: Library — bir ASP.NET Core Web API projesi. Amaç: müşteri verilerine yönelik CRUD uç noktaları sunmak. Hedef framework bu dosyadan anlaşılmıyor (muhtemelen .NET 6+).
- Mimari: Katmanlı mimari (N-Tier). Presentation (API) katmanı `Library` içinde; Application katmanı `Library.Application` (DTO’lar, servis kontratları).
- Projeler/Assembly’ler:
  - Library (API/Presentation) — HTTP endpoint’leri, controller’lar.
  - Library.Application (Application) — `DTO` ve `Service` arayüzleri.
- Dış bağımlılıklar: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon: Bu dosyadan anlaşılmıyor; connection string veya app settings anahtarı görünmüyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri verileri için HTTP tabanlı CRUD ve sorgulama uç noktaları sunar. Presentation (API) katmanındadır ve iş kuralları için `ICustomerService`’e delegasyon yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşterilere yönelik okuma/yazma işlemlerini gerçekleştiren uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomersController(ICustomerService customerService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döner. |
| GetById | `public Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID ile müşteri getirir; yoksa 404. |
| GetActive | `public Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döner. |
| Create | `public Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Müşteri oluşturur; 201 ve konum başlığı döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Müşteri günceller; 204 ya da bulunamazsa 404. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Müşteri siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()`.
- `Create`: `CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer)` ile 201 ve kaynak konumu döner.
- `Update`: `KeyNotFoundException` yakalanır ve 404’e çevrilir; başarıda 204 döner.
- `Delete`: Başarıda 204 döner; özel hata eşlemesi yapılmaz.
- `[ApiController]` ile model bağlama/validasyon hataları otomatik 400 üretir.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri) tarafından çağrılır.
- **Aşağı akış:** `ICustomerService`
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`

**7. Eksikler ve Gözlemler**
- `Delete` için bulunamayan kayıt senaryosunda özel 404 eşlemesi yok; servis `KeyNotFoundException` fırlatırsa 500’e dönüşebilir.
- Yetkilendirme/kimlik doğrulama öznitelikleri yok; tüm uç noktalar herkese açık görünüyor (güvenlik riski).
- İsteklerde `CancellationToken` desteği yok; uzun süren işlemler için iptal edilebilirlik eksik.

---
### Genel Değerlendirme
Kod, API katmanında temiz bir delegasyon uygular ve `CreatedAtAction`, 404 eşlemesi gibi iyi pratikler içerir. Ancak güvenlik (authorization attribute’ları), hata eşlemesi tutarlılığı (özellikle Delete) ve iptal belirteci desteği geliştirilebilir. Uygulama ve domain katmanlarına ilişkin ayrıntılar bu depoda görünmüyor; DTO ve servis sözleşmeleri Application katmanında konumlanmış.### Project Overview
Proje adı: Library (ASP.NET Core Web API)
Amaç: Kütüphane personel yönetimi için RESTful uç noktalar sağlamak (listeleme, detay, oluşturma, güncelleme, silme ve aktif personel sorgusu).
Hedef framework: Bu dosyadan anlaşılmıyor (ASP.NET Core kullanımı açık).
Mimari: Katmanlı/Clean-like yapı. API katmanı `Library.Controllers` altında, uygulama sözleşmeleri ve DTO’lar `Library.Application` ad alanında konumlanmış görünüyor. Controller, iş kurallarını Application katmanına delege ediyor.
Projeler/Assembly’ler:
- Library (API/Presentation) — Web API uç noktaları
- Library.Application (Application) — `DTO` ve `Service` sözleşmeleri
Kullanılan dış çerçeveler/paketler:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
Library (API/Controllers)
  -> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, kütüphane personeline yönelik CRUD ve filtrelenmiş listeleme (aktif personel) uç noktalarını sunan Web API denetleyicisidir. Presentation/API katmanına aittir ve iş mantığını `IStaffService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel için uygulama servis sözleşmesi; veri alma, oluşturma, güncelleme ve silme operasyonlarını gerçekleştirir.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public StaffController(IStaffService staffService)` | Servis bağımlılığını alır. |
| GetAll | `public Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli döndürür. |
| GetById | `public Task<ActionResult<StaffDto>> GetById(Guid id)` | ID ile personel detayını döndürür; yoksa 404. |
| GetActive | `public Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döndürür. |
| Create | `public Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; 201 ve konum döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; yoksa 404, başarılıysa 204. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Personeli siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` sonuç `null` ise `NotFound (404)` döner.
- `Create` başarılı olduğunda `CreatedAtAction` ile konum başlığı ve oluşturulan `StaffDto` döner.
- `Update` sırasında `KeyNotFoundException` yakalanır ve `NotFound (404)` döner; aksi durumda `NoContent (204)`.
- `Delete` her zaman `NoContent (204)` döner; bulunamama senaryosu özel ele alınmıyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri).
- **Aşağı akış:** `IStaffService`.
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`.

**7. Eksikler ve Gözlemler**
- Authorization öznitelikleri yok; personel yönetimi uç noktaları kimlik doğrulama/rol tabanlı yetkilendirme gerektirebilir.
- `Delete` için bulunamayan kayıt senaryosunda tutarlı hata yönetimi yok (ör. `NotFound` dönmüyor); `Update` ile uyumsuz.

### Genel Değerlendirme
- Katman ayrımı belirgin: API, Application DTO ve servis sözleşmelerine bağımlı. Domain/Infrastructure katmanları bu dosyadan görülemiyor.
- Hata yönetimi kısmen tutarlı; `Update` 404 dönerken `Delete` için eksik. Uç noktalar geneli için yetkilendirme stratejisi belirsiz.
- Model doğrulama (`[ApiController]` ile otomatik) mevcut; ancak özel doğrulama kuralları bu dosyada yok.
- Operasyonel detaylar (transaction, logging, caching) Application/Infrastructure’da olabilir; bu dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: ASP.NET Core Web API uygulaması olarak HTTP isteklerini karşılamak, Application ve Infrastructure katmanlarını DI ile bağlayarak iş mantığı ve altyapı hizmetlerini sunmak. Hedef çerçeve: Minimal hosting modeli kullanıldığı için .NET 6 veya üzeri (kesin sürüm bu dosyadan anlaşılmıyor).

Mimari desen: Clean Architecture benzeri katmanlı yapı.
- Presentation/API (Library): Web host, middleware hattı, controller’lar ve Swagger.
- Application (Library.Application): Uygulama servisleri/iş kuralları (AddApplication ile ekleniyor).
- Infrastructure (Library.Infrastructure): Kalıcı veri/harici sistem entegrasyonları (AddInfrastructure ile IConfiguration üzerinden yapılandırılıyor).

Projeler/assembly’ler:
- Library (API/Presentation): Web giriş noktası, HTTP pipeline.
- Library.Application: Uygulama katmanı (servisler, use-case’ler).
- Library.Infrastructure: Altyapı (ör. veri erişimi, mesajlaşma, vb.; detay bu dosyadan anlaşılmıyor).

Dış bağımlılıklar:
- Swashbuckle (Swagger/OpenAPI) — `AddEndpointsApiExplorer`, `AddSwaggerGen`.

Yapılandırma gereklilikleri:
- `Library.Infrastructure` konfigürasyon alıyor (`AddInfrastructure(builder.Configuration)`); muhtemel connection string veya provider ayarları gerekli. Anahtar adları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  -> Library.Application
  -> Library.Infrastructure

Library.Application
  (iş kuralları; doğrudan API tarafından kullanılır)

Library.Infrastructure
  (uygulama tarafından DI ile tüketilir; IConfiguration gerektirir)

---
### `Library/Program.cs`

**1. Genel Bakış**
Uygulamanın giriş noktasıdır; servis kayıtlarını yapar, HTTP middleware hattını kurar ve controller’ları haritalar. Clean Architecture’ın Presentation/API katmanında yer alır.

**2. Tip Bilgisi**
- Tip: Top-level statements (örtük `Program` sınıfı)
- Miras: Yok
- Uygular: Yok
- Namespace: Bu dosyadan anlaşılmıyor (global usings ile üst seviye)

**3. Bağımlılıklar**
- `Library.Application` — `AddApplication()` ile uygulama katmanı servisleri eklenir.
- `Library.Infrastructure` — `AddInfrastructure(IConfiguration)` ile altyapı servisleri konfigürasyonla eklenir.
- ASP.NET Core middleware’leri — `AddControllers`, `AddEndpointsApiExplorer`, `AddSwaggerGen`.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Main (örtük) | `static void Main(string[] args)` | Host’u kurar, servisleri kaydeder ve uygulamayı çalıştırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Geliştirme ortamında Swagger UI aktif edilir; diğer ortamlarda kapalı.
- HTTPS yönlendirmesi etkindir (`UseHttpsRedirection`).
- Yetkilendirme middleware’i eklenmiştir (`UseAuthorization`); kimlik doğrulama bu dosyadan eklenmemiş görünüyor.
- Controller tabanlı endpoint’ler `MapControllers()` ile haritalanır.

**6. Bağlantılar**
- Yukarı akış: Uygulamanın çalışma zamanı tarafından giriş noktası olarak çağrılır.
- Aşağı akış: `Library.Application`, `Library.Infrastructure`, ASP.NET Core middleware ve controller’lar.
- İlişkili tipler: `AddApplication()`, `AddInfrastructure(IConfiguration)` extension method’ları.

**7. Eksikler ve Gözlemler**
- `UseAuthorization` kullanılmış ancak `UseAuthentication` ve ilgili kimlik doğrulama kayıtları görünmüyor; yetkilendirme kurallarının çalışması için kimlik doğrulama eklenmesi gerekebilir.
- `AddInfrastructure` konfigürasyonu gerektiriyor; gerekli appsettings anahtarları bu dosyadan belirsiz.

Genel Değerlendirme
- Katmanlar arası bağımlılık yönü Clean Architecture’a uygundur (API -> Application/Infrastructure).
- Güvenlik için kimlik doğrulama/authorization politikaları ve olası CORS yapılandırması net değil.
- Infrastructure’ın ihtiyaç duyduğu konfigürasyonların belgelenmesi faydalı olacaktır (ör. connection string adları).