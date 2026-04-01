### Project Overview
- Proje adı: Library
- Amaç: Uygulama katmanında kitap kategorilerine ilişkin veri transferini gerçekleştiren DTO’ları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor (sadece C# dil özellikleri görülüyor).
- Mimari desen: Büyük olasılıkla katmanlı/Clean Architecture; bu dosya `Application` katmanında yer alan DTO’yu gösteriyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama hizmetleri/iş akışları.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application] (DTO’lar)
(Şu an yalnızca Application katmanı görünür durumda; diğer katmanlar bu dosyadan çıkarılamıyor.)

---

### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**
`BookCategoryDto`, kitap kategorisine ait temel bilgileri (kimlik, ad, açıklama) katmanlar arasında taşımak için kullanılan basit bir veri transfer objesidir. Uygulama (Application) katmanına aittir ve sunum/altyapı ile domain arasında veri taşımayı amaçlar.

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
| Name | `public string Name { get; set; } = string.Empty` | Kategori adı. |
| Description | `public string Description { get; set; } = string.Empty` | Kategori açıklaması. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Id = default(Guid)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanına ait tek bir DTO görülüyor. Mimari desen ve katmanlar muhtemelen Clean Architecture yönünde, ancak doğrulamak için Domain, Infrastructure ve Presentation/API projeleri görünmüyor. Dış bağımlılıklar, konfigürasyon anahtarları veya iş kuralları bu veri ile tespit edilemiyor. DTO’larda boş string varsayılanları belirlenmiş; `Guid` için ayrıca doğrulama veya üretim mantığı (ör. atama sırasında) tanımlı değil.### Project Overview
- Proje Adı: Library (çıkarım: `Library.Application` isim alanı)
- Amaç: Uygulama katmanında kitap verilerini katmanlar arası taşımak için DTO tanımlamak.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Örüntü: Katmanlı/Clean Architecture eğilimli (çıkarım). Bu katmanda sunulan tip, Application katmanında yer alan bir DTO’dur.
  - Application: DTO’lar, muhtemel komut/sorgu işleyicileri ve servis kontratları (bu dosyada yalnızca DTO görülüyor).
  - Diğer katmanlar (Domain/Infrastructure/API): Bu dosyadan anlaşılmıyor.
- Keşfedilen Proje/Bileşenler:
  - Library.Application — Uygulama katmanı; DTO tanımı içeriyor.
- Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
(API/Presentation) → Library.Application
Diğer katman bağımlılıkları bu dosyadan anlaşılmıyor.

---
### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitapla ilgili temel bilgileri (kimlik, başlık, yazar, ISBN, yıl, uygunluk ve kategori) katmanlar arasında taşımak için kullanılan bir veri aktarım nesnesidir. Uygulama (Application) katmanına aittir ve sunum/altyapı ile domain arasındaki veri şekillendirmeyi basitleştirir.

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
| Title | `public string Title { get; set; }` | Kitap başlığı. |
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarası. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcut/ödünç verilebilirlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İsteğe bağlı kategori kimliği. |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | İsteğe bağlı kategori adı. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`; `PublishedYear = 0`, `IsAvailable = false`, `BookCategoryId = null`, `BookCategoryName = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanı yalnızca bir DTO sunuyor; mimari katmanların geri kalanı, kullanılan paketler ve yapılandırmalar bu dosyadan tespit edilemiyor. DTO üzerinde doğrulama/annotasyon bulunmuyor; doğrulama ihtiyacı varsa bunu Application veya API katmanında ele almak gerekebilir.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kitap kategorileri vb. alanlarda uygulama katmanında veri taşıma nesneleri (DTO) sağlamak. Hedef çatı: Bu dosyadan kesin olarak anlaşılamıyor; adlandırma ve yapı, .NET modern uygulamalarında görülen katmanlı/Clean Architecture tarzına işaret ediyor.

Mimari desen: Uygulama katmanı (Application) odaklı katmanlı mimari. Application katmanı; use case’ler, DTO’lar ve iş akışlarının merkezidir. Bu depoda yalnızca Application projesi görülebilmektedir.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemel komut/sorgu iş akışlarının kontratları.

Harici paketler/çatı: Bu dosyadan anlaşılamıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
[Library.Application] (DTOs)
(Diğer katmanlar bu depodan anlaşılamıyor.)

---
### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, yeni bir kitap kategorisi oluşturma senaryosu için istemciden alınacak veya katmanlar arasında taşınacak veriyi temsil eden bir DTO’dur. Uygulama (Application) katmanına aittir ve komut/handler veya servis sınırlarında kullanılır.

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
- Sadece Application katmanında bir DTO görülebiliyor; diğer katmanlar veya akışlar hakkında çıkarım sınırlı.
- Validasyon kuralları veya kullanım bağlamı bu dosyadan anlaşılamıyor; muhtemel validasyon (ör. `Name` zorunluluğu) başka yerde ele alınmalıdır.
- Harici paket/altyapı izine rastlanmıyor; çözümün geri kalanı görünmediği için mimari bağımlılıklar ve konfigürasyonlar değerlendirilemiyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Application` ad alanından)
- Amaç: Kütüphane alanına ait uygulama katmanında kitap oluşturma isteğini taşımak için DTO sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari örüntü: Uygulama katmanı ve DTO isimlendirmeleri Clean Architecture/N‑Katmanlı yaklaşıma işaret ediyor; ancak diğer katmanlar bu dosyadan doğrulanamıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; istek/yanıt modelleri (DTO) ve muhtemel kullanım senaryoları/handler’lar için sözleşmeler.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor (görünür bağımlılık yok).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Application)
  ↓
(bağımlılık akışı bu dosyadan çıkarılamıyor)

---
### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, yeni bir kitabın oluşturulması için gerekli alanları taşıyan bir veri transfer nesnesidir. Uygulama katmanında, komut/handler veya API katmanları arasında veri taşımak amacıyla kullanılır.

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
| Title | `public string Title { get; set; }` | Kitap başlığını tutar. Varsayılanı `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adını tutar. Varsayılanı `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN numarasını tutar. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayınlanma yılını tutar. Varsayılanı `0` (int varsayılanı). |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kitap kategorisinin kimliği; opsiyoneldir. Varsayılanı `null`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca bir DTO bulundu; mimari katmanlar, akışlar ve dış bağımlılıklar hakkında kapsamlı çıkarım yapılamıyor.
- Validasyon kuralları (boş/format kontrolleri, yıl aralığı, ISBN doğrulaması) bu DTO içinde tanımlı değil; bu normaldir ancak ilgili katmanlarda (API model doğrulama veya Application komut doğrulama) ele alınmalıdır.
- Hedef çatı/framework ve konfigürasyonlara dair bilgi yok.### Project Overview
Proje adı muhtemelen “Library”. Koddan çıkarıma göre amaç, müşteri/okuyucu bilgileri gibi temel verileri işlemek için uygulama katmanında DTO’lar sağlamaktır. Hedef çerçeve (target framework) bu dosyadan anlaşılmıyor. Mimari olarak katmanlı veya Clean Architecture yaklaşımı ima ediliyor; `Library.Application` içinde DTO’lar bulunuyor ve muhtemelen Domain/Infrastructure/API gibi diğer katmanlar vardır, ancak bu dosyadan doğrulanamıyor.

- Mimari desen: Clean Architecture/N-Tier (uygulama katmanı tespit edildi)
  - Application: Use-case mantığı, DTO’lar, komut/sorgu modelleri (bu dosyada yalnız DTO var)
  - Diğer katmanlar (Domain/Infrastructure/API): Bu dosyadan anlaşılmıyor
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel hizmet arayüzleri
- Dış paketler/çatı: Bu dosyada görünmüyor
- Konfigürasyon gereksinimleri: Bu dosyada görünmüyor

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**
`CreateCustomerDto`, bir müşteri oluşturma isteğinde taşınan verileri temsil eden basit bir DTO’dur. Uygulama katmanına aittir ve API/uygulama sınırında veri taşıma amacıyla kullanılır.

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
DTO — davranış yok. Default değerler: tüm `string` özellikler `string.Empty` ile başlatılır.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanı görünürlüğü şu an yalnızca bir DTO ile sınırlı. Mimari desen ve diğer katmanlar/bağımlılıklar bu dosyadan teyit edilemiyor. Doğrulama, eşleme (mapping), iş kuralları, kalıcılık katmanı ve hata yönetimi gibi konular bu DTO’da doğal olarak yer almaz; ilgili servis/handler katmanlarında beklenir ancak mevcut girdide görülmemektedir.### Project Overview
- Proje adı: Library (isimlendirme `Library.Application` namespace’inden çıkarılmıştır)
- Amaç: Uygulama katmanında kullanılan veri transfer nesnelerini (DTO) sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari işaretleri mevcut (en azından Application katmanı). Diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar ve muhtemel uygulama hizmetleri için.
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, personel oluşturma senaryolarında kullanılan bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve giriş verilerini taşıyarak üst katmanlar (ör. API) ile alt katmanlar (ör. domain/servisler) arasındaki sınırı sadeleştirir.

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
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `HireDate = default(DateTime)`.

**6. Bağlantılar**
- **Yukarı akış:** Muhtemelen API katmanındaki komut/endpoint’ler tarafından kullanılır (bu dosyadan kesin değil).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Personel oluşturma komutları/servisleri ve olası `Staff` domain entity’si (bu dosyadan kesin değil).

Genel Değerlendirme
- Mevcut kod yalnızca Application katmanındaki bir DTO’yu içeriyor. Diğer katmanlar (Domain, Infrastructure, API) ve iş kuralları bu dosyadan anlaşılamıyor.
- Girdi validasyonu (zorunlu alanlar, format kontrolleri) DTO üzerinde tanımlı değil; muhtemelen üst katmanda veya iş mantığında ele alınmalı.### Project Overview
- Proje adı: Library (uygulama katmanı: `Library.Application`)
- Amaç: Uygulama katmanında katmanlar arası veri taşıma için DTO tanımlamak (müşteri verileri).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Klasik katmanlı mimari (Application katmanı belirgin). Application, Domain ve Infrastructure katmanları olası; ancak bu dosyadan diğer katmanlar doğrulanmıyor.
- Keşfedilen projeler/assembly’ler:
  - `Library.Application` — Uygulama sözleşmeleri/DTO’ları.
- Harici paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri bilgilerini katmanlar arasında taşımak için kullanılan basit bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve API, servisler veya diğer katmanlar arasında müşteri verisinin taşınmasını kolaylaştırır.

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
| Id | `Guid Id { get; set; }` | Müşterinin benzersiz kimliği. |
| FirstName | `string FirstName { get; set; }` | Müşterinin adı. |
| LastName | `string LastName { get; set; }` | Müşterinin soyadı. |
| Email | `string Email { get; set; }` | Müşterinin e-posta adresi. |
| Phone | `string Phone { get; set; }` | Müşterinin telefon numarası. |
| Address | `string Address { get; set; }` | Müşterinin adresi. |
| MembershipNumber | `string MembershipNumber { get; set; }` | Müşteri üyelik numarası. |
| RegisteredDate | `DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `bool IsActive { get; set; }` | Müşteri aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `RegisteredDate = default(DateTime)`, `IsActive = default(bool)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanı, yalnızca Application katmanında bir DTO içerdiği için mimari görüntü sınırlı; diğer katmanlar ve akışlar bu dosyadan çıkarılamıyor.
- Doğrulama/annotasyon bulunmuyor; ihtiyaç halinde `Email`, `Phone`, `MembershipNumber` için format/doğrulama stratejileri üst katmanlarda sağlanmalıdır.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alanındaki personel bilgisini taşımak için kullanılan uygulama katmanı DTO’su sağlar.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari: Muhtemelen katmanlı/Clean Architecture yaklaşımı; görünen katman Application (DTO’lar).  
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO, muhtemelen use case’ler ve mapping’ler (bu dosyada yalnızca DTO görülüyor).

Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  ↑ (kullanılması muhtemel)
API/Presentation, Domain, Infrastructure — bu dosyadan anlaşılmıyor

---
### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, personel bilgilerini (ad, soyad, iletişim, pozisyon, işe başlama tarihi, aktiflik) taşıyan veri transfer nesnesidir. Uygulama katmanında, API ile domain/servis katmanları arasında veri alışverişini sadeleştirmek amacıyla yer alır.

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
| Position | `public string Position { get; set; }` | Personelin pozisyonu/unvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`; `Id = default(Guid)`, `HireDate = default(DateTime)`, `IsActive = false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanından bir DTO görünmekte; Domain, Infrastructure ve API/Persistence katmanlarına dair bilgi yok.
- Hedef framework, kullanılan paketler ve konfigürasyon anahtarları bu dosyadan tespit edilemiyor.
- Validasyon/mapping stratejisi (ör. FluentValidation, AutoMapper) görünmüyor; ileride eklenmesi beklenebilir.### Project Overview
- Proje adı: Library (keşfedilen proje/assembly: `Library.Application`)
- Amaç: Uygulama katmanında veri taşıma nesneleri (DTO) sağlamak; özellikle kitap kategori güncelleme işlemleri için istek modelini temsil etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı bir yapı izlenimi var (`.Application` adlandırması). Tam mimari deseni (ör. Clean Architecture) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - `Library.Application`: Uygulama katmanı; DTO’lar ve muhtemel uygulama mantığı sözleşmeleri.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  [tek katman keşfedildi — başka bağımlılık görünmüyor]

---
### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, bir kitap kategorisinin güncellenmesi sırasında gerekli alanları (`Name`, `Description`) taşıyan basit bir DTO’dur. Uygulama katmanına (`Library.Application`) aittir ve muhtemel komut/handler veya controller’lara giriş modeli sağlar.

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
- Sadece `Application` katmanından bir DTO görülebiliyor; domain, infrastructure veya API katmanlarına dair kanıt yok.
- Validasyon, eşleme (mapping) veya iş kuralları görünmüyor; bu, DTO için normaldir ancak çağıran katmanlarda doğrulama gerekecektir.
- Hedef çerçeve, paketler ve konfigürasyon anahtarları bu koddan çıkarılamıyor.### Project Overview
Proje adı: Library (çıkarım: `Library.Application` ad alanı)
Amaç: Kütüphane kitap yönetimi için uygulama katmanında veri taşıma nesneleri (DTO) sağlamak.
Hedef framework: Bu dosyadan anlaşılmıyor.
Mimari desen: Katmanlı/Clean Architecture eğilimli (çıkarım: `Library.Application` ad alanı). Bu katman, use-case/iş mantığına yakın veri sözleşmelerini taşır.
Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar, muhtemel komut/sorgu modelleri ve servis sözleşmeleri.
Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
(Keşfedilen tek katman)
Library.Application

---

### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**
`UpdateBookDto`, bir kitabın güncellenmesi için gereken alanları taşıyan veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve API/servis ile domain/model katmanı arasında veri sözleşmesi olarak kullanılması amaçlanır.

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
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN bilgisi. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Kitabın mevcut/ödünç verilebilir olup olmadığı. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`. Diğer alanlarda varsayılan anlam belirtilmemiş.

**6. Bağlantılar**
- **Yukarı akış:** Controller’lar veya uygulama servisleri tarafından güncelleme işlemlerinde kullanılır (bu dosyadan net değil).
- **Aşağı akış:** Domain/entity güncelleme mantığına veya persistance katmanına map edilir (bu dosyadan net değil).
- **İlişkili tipler:** Olası karşılığı domain tarafında bir `Book` entity’sidir (bu dosyadan anlaşılmıyor).

---

### Genel Değerlendirme
Kod tabanı görünürlüğü yalnızca Application katmanında bir DTO ile sınırlı. Diğer katmanlar (Domain, Infrastructure, API) ve iş kuralları, validasyon, mapping profilleri (ör. AutoMapper) veya komut/sorgu akışları bu dosyadan tespit edilemiyor. Girdi validasyonu (örn. `Title`, `Author`, `ISBN` zorunluluğu, `PublishedYear` aralığı) ve alan kuralları DTO içinde tanımlı değil; muhtemelen başka katmanlarda ele alınmalıdır.### Project Overview
Proje adı bu dosyadan “Library” olarak okunuyor ve “Application” katmanında yer alan bir DTO içeriyor. Amaç, müşteri güncelleme işlemleri için uygulama katmanında veri taşıma nesnesi sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari olarak en azından katmanlı bir yapı (Application katmanı) işaret ediliyor; daha geniş desen (Clean Architecture, N‑Tier vb.) bu dosyadan kesinleştirilemiyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use case/iş akışları için sözleşmeler.

Dış bağımlılıklar: Bu dosyada herhangi bir paket veya framework kullanımı görünmüyor.

Yapılandırma gereksinimleri: Bu dosyada yapılandırma/ayarlara ilişkin bir gösterge yok.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, müşteri güncelleme operasyonlarında taşınacak alanları temsil eden bir veri transfer nesnesidir. Uygulama (Application) katmanına aittir ve API katmanından gelen girişleri domain/iş mantığına aktarmak için kullanılır.

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
| FirstName | `public string FirstName { get; set; }` | Müşterinin adı; varsayılanı `string.Empty`. |
| LastName | `public string LastName { get; set; }` | Müşterinin soyadı; varsayılanı `string.Empty`. |
| Email | `public string Email { get; set; }` | Müşterinin e‑postası; varsayılanı `string.Empty`. |
| Phone | `public string Phone { get; set; }` | Müşterinin telefonu; varsayılanı `string.Empty`. |
| Address | `public string Address { get; set; }` | Müşterinin adresi; varsayılanı `string.Empty`. |
| IsActive | `public bool IsActive { get; set; }` | Müşteri aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`. `IsActive` için varsayılan değer C# tür varsayılanı olarak `false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor (muhtemel `Customer` entity/DTO eşleşmeleri belirtilmemiş).

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülüyor; mimari desen ve diğer katmanlar bu dosyadan teyit edilemiyor.
- Validasyon kuralları (ör. e‑posta formatı, zorunlu alanlar) DTO düzeyinde tanımlı değil; muhtemelen başka katmanlarda ele alınmalıdır.### Project Overview
- Proje adı: Library (bu dosyadaki namespace’ten çıkarım)
- Amaç: Kütüphane bağlamında personel (staff) bilgilerinin güncellenmesinde kullanılacak uygulama katmanı DTO’larını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari/Clean Architecture eğilimli. Bu dosya Application katmanında bir DTO sunuyor. Diğer katmanlar (Domain/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Projeler/Assembly’ler:
  - Library.Application — Uygulama katmanı; komut/sorgu contract’ları, DTO’lar vb. barındırır.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  └─ Bağımlılık akışı: Bu dosyada dış bağımlılık görünmüyor; diğer katmanlara ilişkin bağlantılar bu dosyadan anlaşılmıyor.

---
### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel güncelleme işlemlerinde kullanılan veri taşıma nesnesidir. Uygulama (Application) katmanında, istemciden gelen güncelleme verilerini servis/handler’lara taşımak için kullanılır.

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
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = false` (bool default).

**6. Bağlantılar**
- **Yukarı akış:** Controller/Handler/Service katmanları tarafından güncelleme isteklerinde kullanılır (bu dosyadan spesifik çağırıcılar anlaşılmıyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Muhtemel `Staff` entity/aggregate veya ilgili komut/handler tipleri (bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Sadece Application katmanına ait bir DTO sağlanmış; diğer katmanlar ve akışlar bu dosyadan görülemiyor.
- Validasyon, mapping stratejisi (ör. AutoMapper profilleri) ve güncelleme işleminin hangi alanları zorunlu kıldığı belirtilmemiş.
- Hedef framework, konfigürasyonlar ve harici bağımlılıklar tespit edilemiyor.### Project Overview
Proje adı: Library.Application. Amaç: Uygulama katmanındaki servis sözleşmelerini ve implementasyonlarını .NET bağımlılık enjeksiyonu (DI) konteynerine kaydetmek için bir genişletme metodu sağlar. Hedef framework: Bu dosyadan kesinleşmiyor.

Mimari: Katmanlı (Application katmanı belirgin). Bu katman, alanla ilgili uygulama servislerini (`IBookService`, `IBookCategoryService`, `IStaffService`, `ICustomerService`) DI üzerinden kullanılabilir hale getirir. Diğer katmanlar (Domain, Infrastructure, API/Presentation) bu dosyadan anlaşılmıyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama servislerinin kontrat ve/veya implementasyonlarının DI kaydı.

Harici paketler/çatı:
- Microsoft.Extensions.DependencyInjection — DI kayıtları için.

Yapılandırma gereksinimleri:
- Bu dosyadan yapılandırma anahtarı veya connection string gereksinimi görünmüyor.

### Architecture Diagram
[Caller (API/Composition Root?)] -> Library.Application (DependencyInjection.AddApplication)
Not: Çağıran katman(lar) bu dosyadan kesinleşmiyor; `AddApplication` tipik olarak Composition Root’ta çağrılır.

---
### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` sınıfı, uygulama servislerini DI konteynerine topluca eklemek için bir `IServiceCollection` genişletmesi sağlar. Uygulama katmanında yer alır ve üst katmanların (örn. API) servisleri kolayca kaydetmesini amaçlar.

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
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Uygulama servislerini `Scoped` yaşam döngüsüyle DI konteynerine ekler ve zincirleme kullanım için `IServiceCollection` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `IBookService` -> `BookService`, `IBookCategoryService` -> `BookCategoryService`, `IStaffService` -> `StaffService`, `ICustomerService` -> `CustomerService` eşlemeleri `Scoped` olarak kaydedilir.
- Kayıtların tümü Application katmanı ad alanlarından (`Library.Application.Interfaces`, `Library.Application.Services`) yapılır.
- Kayıtların kapsamı (Scoped) tipik web istek bazlı kullanım için uygundur; alternatif yaşam döngüleri bu dosyada tanımlı değildir.

**6. Bağlantılar**
- **Yukarı akış:** Composition Root/Startup tarafından çağrılır (örn. `builder.Services.AddApplication()`).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `IBookService`/`BookService`, `IBookCategoryService`/`BookCategoryService`, `IStaffService`/`StaffService`, `ICustomerService`/`CustomerService`.

**7. Eksikler ve Gözlemler**
- Kayıt edilen interface ve implementasyonların tanımları bu dosyada bulunmadığından, kontrat-uygulama tutarlılığı bu koddan doğrulanamıyor.

### Genel Değerlendirme
Kod, Application katmanı için DI kayıt noktasını açık ve sade biçimde sağlar. Katmanlar arası bağımlılık yönü ve diğer projeler bu tek dosyadan çıkarılamıyor. İleride genişleyebilirlik için: koşullu kayıtlar, dekoratör/girişim (pipeline) yaklaşımları veya modüler kayıt yöntemleri (feature-based) eklenebilir; ancak mevcut ihtiyaç bu dosyadan anlaşılmıyor.### Project Overview
Projenin adı koddan “Library” olarak anlaşılıyor. Amaç, kütüphane alanına yönelik uygulama mantığını Application katmanında tanımlamak; burada servis sözleşmeleri ve DTO’lar üzerinden kategori yönetimi yapılır. Hedeflenen .NET sürümü bu dosyadan anlaşılmıyor.

Mimari olarak katmanlı/Clean Architecture yaklaşımı işaret ediliyor: Application katmanı DTO’lar ve servis arayüzleriyle iş kurallarını ve kullanım sözleşmelerini barındırır; uygulamanın diğer katmanları (API/Infrastructure/Domain) bu dosyadan çıkarılamıyor.

Keşfedilen proje/assembly:
- Library.Application — Uygulama katmanı; `DTO` tipleri ve servis arayüzlerini içerir.

Görünen dış bağımlılıklar: Bu dosyadan dış paket/framework bilgisi anlaşılamıyor.

Yapılandırma gereksinimleri: Bu dosyada herhangi bir konfigürasyon anahtarı veya connection string gereksinimi görünmüyor.

### Architecture Diagram
Library.Application

---
### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategori yönetimi için Application katmanında tanımlanmış servis sözleşmesidir. Kategori CRUD işlemleri için asenkron imzalar sunar ve üst katmanların (ör. API) uygulama mantığına arayüz üzerinden erişmesini sağlar.

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
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Belirtilen `id`’ye sahip kategoriyi döner; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori kayıtlarını döner. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Var olan kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz sözleşmesi; davranış tanımlamaz. İş kuralları implementasyonlarda belirlenir.
- `GetByIdAsync` bulunamadığında `null` dönebileceğini belirtir; diğer metotların hata/başarı sözleşmeleri bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API/Presentation katmanı çağırır.
- **Aşağı akış:** `Library.Application.DTOs` içindeki `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametreleri yok; ölçeklenebilirlik ve iptal senaryoları için eklenmesi önerilir.
- `UpdateAsync` ve `DeleteAsync` sonuç/başarı bilgisi döndürmüyor; bulunamayan kayıt senaryolarının sözleşmesi belirsiz.

### Genel Değerlendirme
Kod, Application katmanında net bir servis sözleşmesi tanımlar ancak yalnızca arayüz mevcut olduğundan mimarinin diğer katmanları çıkarılamıyor. İptal belirteci (`CancellationToken`) ve hata/başarı sözleşmelerinin (ör. not found durumları için sonuç türleri veya domain-specifik istisnalar) netleştirilmesi, tutarlılık ve sağlamlık açısından faydalı olacaktır.### Project Overview
- Proje adı: Library (ad, namespace’lerden çıkarılmıştır)
- Amaç: Uygulama katmanında kitap yönetimi için servis sözleşmeleri tanımlamak (CRUD ve durum bazlı sorgular).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari (Application katmanı görülüyor). Application katmanı, domain/model DTO’larıyla servis sözleşmeleri sunar ve üst katmanlar (API/Presentation) tarafından kullanılır; alt katman (Infrastructure) tarafından uygulanır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis arayüzleri ve DTO referansları içerir.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTO referansları)
  ↑ used by
[Üst katmanlar: API/Presentation] — bu dosyadan anlaşılmıyor
  ↓ implemented by
[Alt katman: Infrastructure] — bu dosyadan anlaşılmıyor

---
### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara yönelik CRUD ve kullanılabilirlik bazlı listeleme işlemleri için uygulama katmanı servis sözleşmesini tanımlar. Application katmanına aittir ve tipik olarak Infrastructure katmanında uygulanır, API/Presentation tarafından çağrılır.

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
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Verilen `id` ile kitabı getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Mevcut/kullanılabilir kitapları döner. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur ve oluşturulan kaydı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Verilen `id`’li kitabı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id`’li kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
Arayüz — davranış tanımı içermez. İş kuralları ve validasyonlar implementasyonlarda belirlenir. Dönüş tipleri asenkron `Task` tabanlıdır; `GetByIdAsync` için bulunamama durumunda `null` sözleşmesi belirtilmiştir.

**6. Bağlantılar**
- Yukarı akış: API/Presentation katmanındaki controller/handler’lar tarafından çağrılır (genellikle DI üzerinden).
- Aşağı akış: Implementasyon, veri erişimi (repository/DbContext) ve mapper’lara bağlı olabilir (bu dosyadan anlaşılmıyor).
- İlişkili tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Asenkron operasyonlarda `CancellationToken` parametreleri yok; uzun süren işlemler için iptal desteği eklenmesi faydalı olabilir.
- `GetAllAsync` ve `GetAvailableBooksAsync` için sayfalama/sıralama parametreleri yok; büyük veri setlerinde performans ve taşınan veri miktarı açısından sınırlı olabilir.

Genel Değerlendirme
- Yalnızca Application katmanına ait bir servis arayüzü görülebiliyor; diğer katmanlar (Domain, Infrastructure, API) bu depodan anlaşılamıyor.
- Sözleşme net ve minimal; ancak iptal belirteci ve sayfalama gibi çapraz kesen endişeler için genişletme alanı mevcut.
- DTO referansları mevcut fakat DTO tanımları bu girdi içinde yok; tip tutarlılığı ve mapping stratejisi gözlemlenemiyor.### Project Overview
- Proje adı: Library (ad uzayına göre)
- Amaç: Müşteri yönetimi (okuma, listeleme, aktif filtreleme, oluşturma, güncelleme, silme) için uygulama katmanında servis sözleşmeleri tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean-vari yaklaşım; Application katmanında `Interfaces` ve `DTOs` ayrımı mevcut. Uygulama servis sözleşmeleri, veri aktarım tiplerinden bağımlılık alıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis arayüzleri ve DTO’lar.
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
- Katman/iç modül bağımlılıkları (keşfedilenler):
  Library.Application.Interfaces --> Library.Application.DTOs

---
### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri varlıklarına yönelik uygulama-tabanlı işlemler için asenkron servis sözleşmesini tanımlar. Application katmanına aittir ve controller’lar ya da üst katmanlar tarafından DI üzerinden tüketilecek bir arayüz sunar.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
- `Library.Application.DTOs.CustomerDto` — Müşteri görüntüleme DTO’su
- `Library.Application.DTOs.CreateCustomerDto` — Müşteri oluşturma girdi DTO’su
- `Library.Application.DTOs.UpdateCustomerDto` — Müşteri güncelleme girdi DTO’su

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için müşteriyi getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri döndürür. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Yalnızca aktif müşterileri döndürür. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış belirtmez; asenkron CRUD sözleşmesi ve “aktif müşteriler” için filtreleme operasyonu içerir.
- `GetByIdAsync` dönüşünde `CustomerDto?` kullanımı, bulunamama durumunu `null` ile temsil eder.
- `UpdateAsync` ve `DeleteAsync` operasyonları sonucunda değer döndürmez; hata/suçlu durum yönetimi implementasyona bırakılmıştır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar API/Presentation katmanı bileşenleri (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- `CancellationToken` desteği yok; uzun süren işlemler veya iptal senaryoları için sınırlı.
- Listeleme operasyonlarında sayfalama/sıralama parametreleri yok.
- `UpdateAsync`/`DeleteAsync` sonuç veya “bulunamadı” sinyali döndürmüyor; durum iletişimi implementasyona bırakılmış.

---

Genel Değerlendirme
- Kod, Application katmanında net bir servis sözleşmesi sunuyor ancak yalnızca arayüz görülebiliyor; domain, altyapı ve API katmanlarına dair kanıt yok.
- İptal belirteci, sayfalama ve sonuç-tabanlı güncelleme/silme geri bildirimleri eklenirse sözleşme daha sağlam ve ölçeklenebilir olur.
- Hata ve bulunamama durumlarının (ör. özel exception tipleri veya sonuç sarmalayıcıları) sözleşmede standardize edilmesi faydalı olacaktır.### Project Overview
- Proje adı: Library (adı ve amaç, namespace’lerden çıkarım)
- Amaç: Kütüphane uygulamasında personel (staff) yönetimi için Application katmanında servis sözleşmeleri sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı (Application katmanı keşfedildi). Application, domain mantığını orkestre eden servis sözleşmelerini barındırır; veri erişimi ve sunum katmanları bu dosyadan görünmüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, servis arayüzleri ve DTO’lar (namespace referansına göre).
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces, DTOs)
  └─ (Diğer katmanlar bu dosyadan görünmüyor)

---
### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
Kütüphane personeline ilişkin CRUD ve listeleme operasyonları için uygulama katmanı servis sözleşmesini tanımlar. Sunum katmanı (ör. API) ile altyapı/iş kuralları arasındaki sınırı belirler ve DI üzerinden uygulanması beklenir.

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
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için personel kaydını döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını listeler. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif durumdaki personelleri listeler. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşturulan kaydı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut personel kaydını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`'deki personel kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış tanımlamaz. Anlam çıkarımları: 
- `GetActiveStaffAsync` aktiflik durumuna göre filtreleme beklentisi yaratır.
- `CreateAsync` oluşturulan varlığı geri döndürerek tüketiciye son hali sağlar.
- `UpdateAsync` ve `DeleteAsync` dönüş değeri içermez; varlık bulunamama veya doğrulama hataları için istisna fırlatma beklenebilir (bu dosyadan net değil).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir (ör. Controller’lar veya Application hizmet tüketicileri).
- **Aşağı akış:** Harici bağımlılık yok (uygulama sınıfları implementasyonda veri erişimine bağlanacaktır).
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` (`Library.Application.DTOs`).

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` desteği yok.
- Listeleme için sayfalama/sıralama/filtreleme parametreleri (özellikle `GetAllAsync`) tanımlı değil.
- `UpdateAsync`/`DeleteAsync` sonuç bildirimi (ör. bulunamadı bilgisi veya concurrency) için sözleşmede dönüş tipi/sonuç modeli yok.

---
Genel Değerlendirme
- Mevcut kod sadece Application katmanında bir servis arayüzü sunuyor; diğer katmanlar görünmüyor.
- Sözleşme tutarlı asenkron imzalara sahip, DTO kullanımı ile sunum-bağımsızlık sağlanmış.
- İptal belirteci, sayfalama ve sonuç modellemesi (ör. hata/başarı ayrımı) gibi üretim senaryolarında faydalı olacak sözleşme ayrıntıları eklenebilir.### Project Overview
Proje adı: Library. Amaç: Kitap kategorilerine ait Domain entity’leri ile Application katmanındaki DTO’lar arasında mapping sağlamak. Hedef çatı/framework: Bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı/Clean Architecture eğilimli yapı. `Library.Application` katmanı, `Library.Domain` varlıklarına bağımlı olup, DTO-Entity dönüştürmeleri yapıyor.

Katmanlar ve roller:
- Library.Domain: Çekirdek domain varlıkları (`BookCategory`).
- Library.Application: DTO’lar ve mapping/uygulama mantığı (bu dosyada extension mapper’lar).

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri.
- Library.Application — DTO’lar ve mapping yardımcıları.

Dış bağımlılıklar/paketler: Koddan görünmüyor.  
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` entity’si ile `BookCategoryDto`/`CreateBookCategoryDto`/`UpdateBookCategoryDto` arasındaki dönüşümleri sağlayan extension yöntemleri içerir. Application katmanında yer alır ve DTO-Entity eşlemelerini merkezi ve tekrarsız şekilde sunar.

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
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` nesnesini `BookCategoryDto`’ya map eder. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`’dan yeni bir `BookCategory` entity’si üretir ve `Id` için `Guid.NewGuid()` atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Var olan `BookCategory` entity’sinin `Name` ve `Description` alanlarını DTO’dan günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` yeni `BookCategory` oluştururken `Id` alanını `Guid.NewGuid()` ile otomatik üretir.
- `ToDto` ve `UpdateEntity` alanları doğrudan kopyalar; null/boş değer kontrolü veya iş kuralı validasyonu yapmaz.
- Güncellemede sadece `Name` ve `Description` alanları set edilir; diğer olası alanlar (varsa) korunur veya bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Uygulama servisleri/komut işleyicileri veya controller’lar tarafından çağrılır (bu dosyadan anlaşılmıyor).
- **Aşağı akış:** `Library.Application.DTOs` (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`); `Library.Domain.Entities` (`BookCategory`).
- **İlişkili tipler:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- `Id` üretiminin mapper içinde yapılması, kimlik yönetimi sorumluluğunu persistence/Domain katmanından Application’a taşıyabilir; mimari olarak tartışmalı olabilir.
- Null kontrolleri ve alan bazlı validasyonlar yok; geçersiz girişlerde `NullReferenceException` riski bulunabilir.

---
Genel Değerlendirme
- Katmanlar arası bağımlılık yönü doğru (Application -> Domain) ve mapping’ler extension olarak sade.  
- Validasyon ve null korumaları eksik; özellikle update senaryolarında güvenilirlik için kontrol eklenmesi faydalı olur.  
- Kimlik üretimi sorumluluğu netleştirilmeli; tercihen Domain veya veri erişim katmanında ele alınması daha tutarlı olabilir.  
- Dış bağımlılıklar ve konfigürasyon görünmüyor; proje genelinde standart bir mapping kütüphanesi (ör. AutoMapper) kullanılıyorsa dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki `Book` varlıklarını DTO’larla map’lemek ve uygulama ile domain katmanları arasındaki veri aktarımını kolaylaştırmak. Hedef framework: bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı (N-Tier/Clean benzeri). Domain katmanı `Library.Domain` altında varlıkları tutar. Application katmanı `Library.Application` altında DTO’lar ve mapping mantığını barındırır. Application, Domain’a bağımlıdır; ters bağımlılık yoktur.

Projeler/Assembly’ler:
- Library.Domain — Domain varlıkları (`Book`, `BookCategory` vb.)
- Library.Application — Uygulama seviyesi DTO’lar ve mapping yardımcıları.

Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` varlıkları ile `BookDto`/`CreateBookDto`/`UpdateBookDto` DTO’ları arasında iki yönlü dönüşüm sağlayan statik uzantı metotları içerir. Uygulama (Application) katmanına aittir; controller/handler/service katmanlarının domain-agnostik çalışmasını kolaylaştırır.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygılar:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.
- `Library.Application.DTOs` — DTO tanımları
- `Library.Domain.Entities` — `Book` ve ilişkili varlıklar

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` varlığını `BookDto`’ya map eder; kategori adını `BookCategory?.Name` ile taşır. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto` bilgisinden yeni `Book` varlığı üretir; `Id`’yi `Guid.NewGuid()` ile atar, `IsAvailable`’ı `true` yapar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan `Book` üzerinde `UpdateBookDto` alanlarını günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` yeni `Book.Id` değerini `Guid.NewGuid()` ile otomatik üretir.
- `ToEntity` oluşturma sırasında `IsAvailable = true` varsayımı uygular.
- `ToDto` kategori adını `BookCategory?.Name` ile güvenli şekilde map eder (kategori null olabilir).
- Null kontrolü ve alan validasyonları bu seviyede yapılmıyor; parametrelerin geçerli olduğu varsayılıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genellikle application service’leri, handler’lar veya controller’lar).
- **Aşağı akış:** `Book` (Domain), `BookCategory` (Domain), `BookDto`/`CreateBookDto`/`UpdateBookDto` (Application DTO’ları).
- **İlişkili tipler:** `Book`, `BookCategory`, `BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- Parametre null kontrolleri yok; `book` veya `dto` null ise `ToDto`/`UpdateEntity` potansiyel hata üretebilir.
- `ToEntity` içinde `IsAvailable`’ın zorunlu olarak `true` atanması, belirli iş kurallarına bağlı olabilir; ihtiyaç duyuluyorsa konfigüre edilebilir hale getirilmeli.

### Genel Değerlendirme
Kod, Application ve Domain katmanları arasında net bir mapping sınırı kuruyor. Mimari katmanlar arası bağımlılık yönü doğru (Application → Domain). Validasyon ve null güvenliği mapping seviyesinde ele alınmamış; bu bilinçli bir tercih olabilir ancak üst katmanlarda garanti altına alınmalıdır. Hedef framework, dış bağımlılıklar ve diğer katmanların (Infrastructure/API) varlığı bu dosyadan doğrulanamıyor.### Project Overview (required, once)
- Proje adı: Library
- Amaç: Uygulama katmanında `Customer` varlıkları ile ilgili DTO-Entity dönüşümlerini sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari pattern: Clean Architecture (çıkarım). Katmanlar:
  - Domain: Temel iş varlıkları (`Library.Domain.Entities.Customer`).
  - Application: DTO’lar ve mapping/iş mantığı yardımcıları (`Library.Application.DTOs`, `Library.Application.Mappings`).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Çekirdek domain varlıkları.
  - Library.Application — DTO’lar ve mapping yardımcıları.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram (required, once)
Library.Application (DTOs, Mappings) --> Library.Domain (Entities)

---
### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` varlığı ile ilgili DTO dönüşümlerini sağlayan genişletme metotlarını içerir. Oluşturma, okuma ve güncelleme senaryolarında DTO <-> Entity map’leri yapar. Clean Architecture içinde Application katmanına aittir ve Domain varlıklarına bağımlıdır.

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
| ToDto | `public static CustomerDto ToDto(this Customer customer)` | `Customer` varlığını `CustomerDto`'ya dönüştürür. |
| ToEntity | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`'dan yeni bir `Customer` varlığı üretir. |
| UpdateEntity | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` üzerinde `UpdateCustomerDto` alanlarına göre güncelleme yapar. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir.
- `ToEntity`: `MembershipNumber` için `Guid.NewGuid().ToString("N")[..10].ToUpper()` ile 10 karakterlik büyük harfli benzersiz bir değer üretir.
- `ToEntity`: `RegisteredDate = DateTime.UtcNow` atar.
- `ToEntity`: `IsActive = true` varsayılan durumunu atar.
- `UpdateEntity`: Ad, soyad, e-posta, telefon, adres ve `IsActive` alanlarını doğrudan gelen DTO değerleriyle set eder.
- Null kontrolü veya validasyon yapılmaz; metotlar verilen değerleri olduğu gibi map eder.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Library.Domain.Entities.Customer`, `Library.Application.DTOs.CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.
- **İlişkili tipler:** `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.

**7. Eksikler ve Gözlemler**
- Null girişler için koruma/validasyon yok; `customer` veya `dto` null ise `NullReferenceException` riski var.
- `MembershipNumber` üretimi olası (düşük olasılıklı) çakışmaları ele almıyor; benzersizlik garantisi dışsal kontrole bırakılmış.
- `DateTime.UtcNow` kullanımı test edilebilirlik açısından zaman sağlayıcısı soyutlamasıyla iyileştirilebilir. 

---
Genel Değerlendirme
- Kod, Application katmanında yalın mapping mantığı sunuyor ve Domain’e bağımlılık yönü doğru. 
- Validasyon, hata yönetimi ve benzersizlik kontrolü Application/Domain servislerinde ele alınmalı; bu dosyada bulunmaması normal ancak null korumaları eklenebilir.
- Zaman ve kimlik üretimi için soyutlamalar (ör. `IClock`, `IIdentifierGenerator`) eklenirse test edilebilirlik ve tutarlılık artar.### Project Overview
Proje adı: Library. Amaç: Kütüphane alanına ilişkin entity’ler ile DTO’lar arasında dönüştürme (mapping) işlemlerini Application katmanında sağlamak. Hedef framework: Bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture eğilimli yapı; en azından `Domain` ve `Application` katmanları mevcut.

Katmanlar:
- Domain: İş kuralları ve entity’ler (`Library.Domain.Entities.Staff`).
- Application: DTO’lar ve mapping/servis mantığı (`Library.Application.DTOs`, `Library.Application.Mappings`).

Projeler/Assembly’ler:
- Library.Domain — Entity ve domain modeli.
- Library.Application — DTO’lar ve mapping mantığı.

Harici paketler/çatı: Bu dosyadan anlaşılmıyor (EF Core, MediatR vb. iz yok).
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application --> Library.Domain

---
### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` entity’si ile çeşitli `Staff` DTO’ları (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`) arasında dönüşümler sağlayan extension metodlarını içerir. Application katmanında yer alır ve veri alışverişinde model-DTO ayrımını korur.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok.
- Kullanılan türler: `Library.Domain.Entities.Staff`, `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` entity’sini `StaffDto`’ya map eder. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni `Staff` entity’si oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Var olan `Staff` entity’sini `UpdateStaffDto` değerleri ile günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id = Guid.NewGuid()` ile yeni kimlik üretir; `IsActive = true` varsayılanı atar; `HireDate` değerini DTO’dan alır.
- `UpdateEntity`: İsim, iletişim ve `Position` alanlarını günceller; `IsActive` alanını DTO’dan gelen değere set eder.
- `ToDto`: Tüm temel alanları bire bir map eder.
- Null veya veri doğrulama kontrolü yapılmaz; null argümanlar için koruma/exception fırlatma yok.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genellikle Application servisleri/handler’lar veya controller’lar çağırır).
- **Aşağı akış:** `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`
- **İlişkili tipler:** `Library.Domain.Entities.Staff`; `Library.Application.DTOs.*`

**7. Eksikler ve Gözlemler**
- Null argümanlar için koruma/guard yok; `staff` veya `dto` null ise `NullReferenceException` riski var.
- `Id` üretimi Application katmanında yapılıyor; bazı projelerde bu sorumluluk Domain’e veya veri katmanına bırakılır. Bu tercih tutarlı olmalı.

---
Genel Değerlendirme
- Mimari katmanlaşma Domain ve Application ile uyumlu gözüküyor, ancak yalnızca mapping kodu görülebiliyor.
- Validation ve null güvenliği eksik; özellikle extension metodlarında guard pattern önerilir.
- Hedef framework, konfigürasyon ve harici bağımlılıklar belirsiz; proje genelinde standartların belirlenmesi (ör. mapping için AutoMapper kullanımı veya manuel mapping politikası) faydalı olur.### Project Overview
- Proje adı: Library (ad alanlarından çıkarım)
- Amaç: Uygulama katmanında kitap kategorileri için iş mantığını sağlamak; Domain katmanındaki repository arayüzü üzerinden CRUD işlemlerini orkestre etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture tarzı katmanlama. Application katmanı (DTO, servisler, mapping) Domain katmanındaki arayüzlere bağımlı; Application iş mantığı ve mapping’i taşır, Domain ise repository kontratlarını içerir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama servisleri, DTO’lar, mapping uzantıları, uygulama arayüzleri.
  - Library.Domain — Domain arayüzleri (ör. `IBookCategoryRepository`).
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor (mapping uzantıları proje içi görünüyor).
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (bağlantı stringleri veya app settings anahtarları görünmüyor).

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**
`BookCategoryService`, kitap kategorileri için CRUD iş akışını yöneten Application katmanı servisidir. Domain katmanındaki `IBookCategoryRepository` ile iletişim kurar, DTO-Entity dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookCategoryService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori varlıkları için veri erişim operasyonları.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | ID ile kategoriyi getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri listeler ve DTO’ya dönüştürür. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşturulan kaydı DTO olarak döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Mevcut kategoriyi günceller; yoksa hata fırlatır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync`: Kategori bulunamazsa `KeyNotFoundException` fırlatır.
- `CreateAsync`: `CreateBookCategoryDto` üzerinden `ToEntity()` ile entity oluşturur; ekleme sonrası `ToDto()` döner.
- `GetByIdAsync` ve `GetAllAsync`: `ToDto()` ile mapping yapar.
- `DeleteAsync`: Doğrudan repository’ye delege eder; varlık yokluğu durumunda davranış repository implementasyonuna bağlı.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; muhtemel çağırıcılar Controller’lar veya Application katmanı arayüz tüketicileri.
- Aşağı akış: `IBookCategoryRepository`
- İlişkili tipler: `IBookCategoryService`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`).

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için input validasyonu görünmüyor (ör. zorunlu alan kontrolleri).
- `DeleteAsync` varlık bulunamadığında verilecek cevaba dair açık bir hata yönetimi yok; repository davranışına bırakılmış.

---

### Genel Değerlendirme
Kod, Application→Domain bağımlılık yönünü koruyan temiz bir katman ayrımı sunuyor. DTO-Entity mapping uzantılarıyla ayrık bir dönüşüm katmanı kullanılıyor. Ancak servis düzeyinde input validasyonu ve bazı operasyonlarda (özellikle silme) tutarlı hata yönetimi net değil. Hedef framework, konfigürasyon ve dış paket kullanımı bu dosyadan belirlenemiyor; proje genelinde belgeleme ve istisna stratejisinin standartlaştırılması önerilir.### Project Overview
Proje adı: Library. Amaç: Kitap yönetimine yönelik uygulama katmanı servisleri (CRUD ve sorgular) sağlamak. Hedef framework: Bu dosyadan anlaşılmıyor. Mimari olarak Application katmanı, Domain arayüzlerine bağımlı çalışır; DTO ve mapping uzantılarıyla entity-DTO dönüşümleri yapılır.

Mimari desen: Clean Architecture (kısmi görünürlük). Application, Domain’a bağımlıdır; Infrastructure ve Presentation katmanları bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Application — Uygulama servisleri, DTO’lar ve mapping uzantıları.
- Library.Domain — Repository arayüzleri (ör. `IBookRepository`).

Dış bağımlılıklar:
- Bu dosyada doğrudan harici paket görünmüyor. Mapping, `Library.Application.Mappings` uzantılarıyla proje içi yapılıyor.

Konfigürasyon:
- Bu dosyada bağlantı dizesi veya app settings anahtarı görünmüyor.

### Architecture Diagram
Library.Presentation/API (bu dosyadan görünmüyor)
  ↓
Library.Application (Services, DTOs, Mappings)
  ↓
Library.Domain (Interfaces/Repositories)

---

### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik CRUD ve sorgu işlemlerini yürüten uygulama katmanı servisidir. Domain katmanındaki `IBookRepository` aracılığıyla veri erişimini soyutlar ve DTO-Entity dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookService`
- Namespace: `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap verilerine erişim için repository arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public BookService(IBookRepository bookRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<BookDto?> GetByIdAsync(Guid id)` | Kimliğe göre kitabı getirir ve DTO’ya dönüştürür. |
| GetAllAsync | `public Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları listeler ve DTO olarak döner. |
| GetAvailableBooksAsync | `public Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/uygunluk kriterine göre filtrelenmiş kitapları döner. |
| CreateAsync | `public Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur, ekler ve DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı günceller; yoksa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre kitabı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Entity-DTO dönüşümleri `ToDto`, `ToEntity`, `UpdateEntity` uzantılarıyla yapılır.
- `UpdateAsync` içinde kitap bulunamazsa `KeyNotFoundException` fırlatılır.
- `DeleteAsync` varlık mevcudiyetini kontrol etmeden silme talebi iletir.
- Tüm operasyonlar asenkron `Task` tabanlıdır; `CancellationToken` kullanılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; tipik olarak Controller veya Application içi orchestrator’lar tarafından çağrılır.
- Aşağı akış: `IBookRepository`, `Library.Application.Mappings` uzantıları.
- İlişkili tipler: `IBookService`, `IBookRepository`, `BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için input validasyonu (ör. zorunlu alanlar) görünmüyor.
- `DeleteAsync` yoksa ne olacağına dair davranış tanımlı değil (sessiz geçiş veya hata).
- `CancellationToken` desteği yok; uzun süren işlemlerde iptal edilebilirlik eksik.
- Hata yönetimi sınırlı; yalnızca `UpdateAsync` için not found senaryosu ele alınmış.

---

Genel Değerlendirme
- Mimari olarak Application → Domain bağımlılığı doğru konumlandırılmış ve repository deseni kullanılıyor.
- DTO ve mapping uzantılarıyla katmanlar arası ayrım korunuyor; ancak mapping detayları bu dosyadan görülemiyor.
- Girdi validasyonu, hata yönetimi ve `CancellationToken` desteği genel olarak eksik.
- Transactionel davranış ve birimsel çalışma (Unit of Work) izi yok; gereksinime göre Infrastructure katmanında ele alınmalı.### Project Overview
Proje adı: Library (ad alanlarından çıkarım). Amaç: Müşteri yönetimi etrafında Application katmanında iş mantığını sağlayarak Domain’de tanımlı depolar üzerinden CRUD ve sorgulama operasyonlarını gerçekleştirmek. Hedef çatı: Bu dosyadan kesin olarak anlaşılamıyor (.NET sürümü belirtilmemiş).

Mimari desen: Katmanlı/Clean Architecture yaklaşımı. Application katmanı, Domain arayüzlerine bağımlı; DTO ve Mapping ile sunum/altyapıdan ayrıştırılmış.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Application: Uygulama hizmetleri, DTO’lar ve Mapping uzantıları.
- Library.Domain: Repository arayüzleri (iş kurallarının merkezi ve soyutlamalar).

Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılamıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılamıyor (connection string veya appsettings anahtarı görülmüyor).

### Architecture Diagram
Library.Application (Services, DTOs, Mappings)
  └── depends on → Library.Domain (Interfaces)

---

### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**
`CustomerService`, müşteri verileri için CRUD ve sorgulama işlemlerini sağlayan uygulama hizmetidir. Application katmanında yer alır ve `ICustomerRepository` üzerinden Domain’e erişir; DTO/Entity dönüşümlerini `Mappings` uzantılarıyla yapar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri varlıkları için veri erişim işlemleri (okuma/yazma).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | ID’ye göre müşteriyi getirir ve DTO’ya dönüştürür; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri DTO listesi olarak döndürür. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri DTO listesi olarak döndürür. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | DTO’dan entity oluşturur, ekler ve oluşanı DTO olarak döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi bulur, DTO güncellemelerini uygular ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | ID’ye göre müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Entity ↔ DTO dönüşümleri `Mappings` uzantıları ile yapılır: `ToDto`, `ToEntity`, `UpdateEntity`.
- `UpdateAsync` içinde müşteri bulunamazsa `KeyNotFoundException` fırlatılır.
- `CreateAsync` ekleme sonrası dönen DTO, repository’den yeniden okunmadan, bellekteki entity’den üretilir.
- Listeleme işlemleri sonuçları `Select(...ToDto())` ile projekte edilir.
- Girdi validasyonu, yetkilendirme veya transaction yönetimi bu seviyede uygulanmamış (bu dosyadan görüldüğü kadarıyla).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `ICustomerRepository`
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, mapping uzantıları (`ToDto`, `ToEntity`, `UpdateEntity`).

**7. Eksikler ve Gözlemler**
- Metotlarda `CancellationToken` desteği yok.
- Girdi validasyonu (ör. `createDto`, `updateDto` null/kuralsal kontroller) bu seviyede yapılmıyor.
- `DeleteAsync` ve `GetByIdAsync` için “bulunamadı” durumunda tutarlı hata modeli yok; `DeleteAsync` sessiz geçebilir (repository implementasyonuna bağlı).

---

### Genel Değerlendirme
Kod, Application → Domain bağımlılığı ile temiz bir ayrımı koruyor; DTO ve Mapping kullanımı net. Ancak kapsamlı bir projede beklenen iptal belirteci (`CancellationToken`), validasyon katmanı, tutarlı hata modeli ve olası transaction/yakalama politikaları görünmüyor. Keşfedilen dosyalara göre altyapı ve sunum katmanları bu depoda yer almıyor veya gösterilmemiş; bu nedenle uçtan uca akış ve konfigürasyon gereksinimleri bu dosyadan çıkarılamıyor.### Project Overview
Proje adı: Library (isimlendirme ve namespace’lerden çıkarım). Amaç: Kütüphane personel yönetimi için uygulama katmanında iş servisleri sunmak (CRUD ve filtreleme). Hedef çatı sürümü: bu dosyadan anlaşılmıyor.  
Mimari: Clean Architecture/N-Tier eğilimli; `Application` katmanı iş kurallarını ve DTO/Mapping’i barındırıyor, `Domain` katmanı repository kontratlarını sağlıyor.  
Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Application — Uygulama servisleri (`StaffService`), DTO’lar ve mapping uzantıları.
- Library.Domain — Repository arayüzleri (`IStaffRepository`).
Kullanılan dış paket/çatı: Bu dosyadan belirgin bir harici paket görünmüyor; mapping, dahili extension yöntemleriyle yapılmış.  
Konfigürasyon gereksinimleri: Bu dosyada herhangi bir connection string veya app settings anahtarı görünmüyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**  
`StaffService`, personel verileri için CRUD ve durum bazlı listeleme işlemlerini sağlayan uygulama katmanı servisidir. Repository aracılığıyla domain’e erişir, DTO ↔ entity dönüşümlerini mapping uzantılarıyla gerçekleştirir. Clean Architecture’da Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Application.Interfaces.IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel entity’leri için veri erişim işlemlerini soyutlayan repository.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirip DTO’ya dönüştürür. |
| GetAllAsync | `public Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personeli listeler ve DTO’ya dönüştürür. |
| GetActiveStaffAsync | `public Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personel listesini döner (DTO). |
| CreateAsync | `public Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur, ekler ve DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Var olan personeli günceller; yoksa hata fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync`: Personel bulunamazsa `KeyNotFoundException` fırlatır.
- DTO ↔ Entity dönüşümleri `Library.Application.Mappings` içindeki extension yöntemleri (`ToDto`, `ToEntity`, `UpdateEntity`) ile yapılır.
- `CreateAsync`: DTO’dan entity oluşturur, repository’e ekler ve oluşturulan entity’yi DTO olarak döner.
- Listeleme metodları repository’den gelen koleksiyonları proje DTO’larına map’ler (`Select(s => s.ToDto())`).

**Mantık içermeyen basit DTO/model'ler için** bu servis DTO’ları tüketir; DTO davranışları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; muhtemel çağırıcılar Application/Presentation katmanı (controller/handler) — bu dosyadan kesin değil.
- Aşağı akış: `IStaffRepository`; `Library.Application.Mappings` uzantıları; `CreateStaffDto`, `UpdateStaffDto`, `StaffDto`.
- İlişkili tipler: `IStaffService`, `IStaffRepository`, DTO’lar ve ilgili domain entity’si (adı bu dosyadan anlaşılmıyor).

**7. Eksikler ve Gözlemler**
- `DeleteAsync` ve `CreateAsync` için varlık mevcudiyet kontrolü veya hata yönetimi görünmüyor; silme sırasında yoksa davranış repository implementasyonuna bırakılmış.
- Girdi DTO’ları için validasyon bu seviyede yapılmıyor; varsa başka katmanda olmalı, bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Uygulama katmanı, repository aracılığıyla domain’e bağımlı ve DTO/Mapping uzantılarıyla ayrışmış; Clean Architecture’a uygun. Hata yönetimi sınırlı; özellikle silme/oluşturma akışlarında mevcudiyet ve iş kuralı validasyonları bu serviste görünmüyor. Dış paket bağımlılığı belirtilmemiş; konfigürasyon izleri yok. Genişlerken input validasyonunun merkezi bir yerde ele alınması ve hata senaryoları için tutarlı bir istisna/sonuç modeli kullanılması önerilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane alanındaki temel kavramları (ör. kitap) temsil eden domain modellerini tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture yaklaşımlı yapı işaretleri mevcut; bu dosya Domain katmanına ait entity içeriyor.
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain — Domain katmanı; çekirdek iş kurallarını ve entity’leri barındırır.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor; harici paket kullanımına dair iz yok.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] (Domain)
  ↑ (başka katmanlar bu katmana bağımlı olmalıdır; bu depoda sadece Domain katmanı tespit edildi)

---
### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kütüphane içindeki kitabı temsil eden domain entity’sidir. Kimlik, başlık, yazar, ISBN, basım yılı ve erişilebilirlik gibi temel nitelikleri taşır; ayrıca isteğe bağlı bir `BookCategory` ilişkisi içerir. Clean Architecture bağlamında Domain katmanında konumlanır.

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
| Title | `public string Title { get; set; }` | Kitabın başlığı; varsayılanı `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adı; varsayılanı `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası; varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Basım yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç alınabilirlik durumu; varsayılanı `true`. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | İlişkili kategori navigasyon özelliği (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `IsAvailable = true`. `BookCategoryId` ve `BookCategory` opsiyonel referans/ilişkiyi temsil eder.

**6. Bağlantılar**
- **Yukarı akış:** Repository/Service katmanları veya ORM bağlamları tarafından kullanılabilir (bu dosyadan spesifik çağırıcılar anlaşılmıyor).
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `BookCategory` (aynı domain’de olması beklenir; bu depoda gösterilmemiş).

**7. Eksikler ve Gözlemler**
- `Title`, `Author`, `ISBN` için domain düzeyinde validasyon yok (boş/format kontrolü).
- `PublishedYear` için aralık/doğruluk kontrolü tanımlı değil.
- `BookCategory` tipi bu depoda yer almıyor; ilişki hedefi görünmüyor.

---
### Genel Değerlendirme
Kod tabanında yalnızca Domain katmanına ait tek bir entity tespit edildi. Domain modelinde temel alanlar mevcut ancak doğrulama, kurallar ve davranışlar tanımlı değil. İlişkili `BookCategory` tipi ve diğer katmanlar (Application/Infrastructure/API) görünmüyor; bu nedenle tam mimari akış ve bağımlılıklar bu depodan anlaşılamıyor. Domain seviyesinde asgari doğrulama kurallarının eklenmesi ve ilişkili tiplerin tanımlanması önerilir.### Project Overview
- Proje adı: Library (tahmin, `Library.Domain` ad alanından)
- Amaç: Kütüphane alan modellerini (Entity) tanımlamak; bu dosya özelinde kitap kategorilerini temsil etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture/N-Tier yönelimli; bu dosya Domain katmanını gösteriyor.
  - Domain: Temel iş kavramları ve entity tanımları (`Library.Domain`).
  - Diğer katmanlar: Bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - `Library.Domain` — Domain entity ve muhtemel value object’ler.
- Harici paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Domain (`Library.Domain`)
  └─ (bu dosyadan başka katman bağımlılığı görünmüyor)

---
### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, bir kitap kategorisini temsil eden domain entity’sidir. Kategori kimliğini, adını ve açıklamasını taşır; ayrıca ilgili `Book` koleksiyonunu tutar. Clean Architecture’ın Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Domain.Entities`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Navigasyon olarak `Book` tipiyle ilişki)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookCategory()` | Varsayılan oluşturucu. |
| Id | `public Guid Id { get; set; }` | Kategorinin benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategori adı. Varsayılanı boş string. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. Varsayılanı boş string. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye ait kitaplar koleksiyonu. Varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Books = []`. `Id` için özel bir üretim/ata­ma mantığı bu dosyada yok (dışarıdan set edileceği varsayılır).

**6. Bağlantılar**
- **Yukarı akış:** Repository/DbContext veya Application/Service katmanı tarafından kullanılması beklenir (bu dosyadan doğrudan anlaşılmıyor).
- **Aşağı akış:** `Book` entity’siyle navigasyon ilişkisi.
- **İlişkili tipler:** `Book` (aynı namespace’de olması muhtemel; bu dosyada tanımı yok).

Genel Değerlendirme
- Domain katmanında yalın bir entity sunulmuş; validasyon, invariant koruması, factory metotları veya encapsulation bulunmuyor. İleride `Name` için boş/uzunluk validasyonu ve `Books` koleksiyonunun dışarıdan değiştirilmesini sınırlayan kapsülleme (ör. read-only koleksiyon, ekleme metodu) düşünülebilir.
- `Book` tipi referanslanıyor ancak bu depoda gösterilmedi; proje genelinde ilişki bütünlüğü ve mapping için (örn. EF Core) konfigürasyon dosyaları beklenir.
- Katmanlar, hedef framework ve dış bağımlılıklar bu dosyadan netleşmiyor; ek projeler (Application/Infrastructure/API) mevcutsa bağımlılık yönleri ve konfigürasyonlar belgelenmelidir.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” ve görülen katman “Library.Domain”. Amaç, bir kütüphane (library) alan modelinin parçası olarak müşteri bilgisini temsil etmektir. Hedef çatı çerçevesi .NET (tam sürüm bu dosyadan anlaşılamıyor). Görülen yapı, katmanlı/Clean Architecture tarzı bir ayrımı işaret eden Domain katmanını içeriyor.

- Mimari desen: Katmanlı/Clean Architecture temelli; Domain katmanı görülebilir.
- Projeler/Assembly’ler:
  - Library.Domain: Alan varlıkları ve temel domain tipleri.
- Dış bağımlılıklar: Bu dosyadan görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain (Entities)

---
### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**
`Customer`, bir kütüphane sistemindeki müşteriyi temsil eden domain varlığıdır. Kimlik, iletişim bilgileri, üyelik numarası ve durum gibi temel bilgileri taşır. Mimari olarak Domain katmanına aittir ve davranış içermeyen basit bir veri taşıyıcı/varlık rolündedir.

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
| MembershipNumber | `public string MembershipNumber { get; set; }` | Müşterinin üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Müşteri aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`, `IsActive = true`. `RegisteredDate` ve `Id` için otomatik atama/üretim bu dosyada tanımlı değil.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Domain seviyesinde doğrulama/invariant bulunmuyor (ör. `Email` formatı, `MembershipNumber` zorunluluğu).
- `Id` ve `RegisteredDate` ataması için fabrika/metot yok; dış katmanlarda doğru atama yapılmasına bağımlı.

---

Genel Değerlendirme
- Yalnızca bir domain varlığı sağlanmış; başka katmanlar (Application/Infrastructure/API) bu dosyadan görülemiyor.
- Varlık mutable ve doğrulama içermiyor; daha zengin domain kuralları gerekiyorsa factory/metotlar veya value object’ler (ör. `Email`) düşünülebilir.
- Kimlik ve zaman damgası üretimi konsolide edilmemiş; tutarlılık için entity oluşturma akışında standart bir yaklaşım (ör. constructor/factory) faydalı olur.### Project Overview
Proje adı: Library (çıkarılan ad alanlarından). Amaç: Kütüphane alan modelinde personel bilgisini temsil eden domain entity’leri tanımlamak. Hedef framework: Bu dosyadan anlaşılmıyor.

Mimari: Clean Architecture/N-Tier esintili katmanlama; görünen katman Domain. Domain katmanı, iş kurallarını ve temel entity tanımlarını içerir; başka katmanlara referans vermez.

Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain entity’leri ve çekirdek model.

Harici paket/çatı: Bu dosyadan anlaşılmıyor (görünür bağımlılık yok).

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  ↳ (başka katmanlara dair bağımlılık bu dosyadan görünmüyor)

---
### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff`, kütüphane personeline ait temel kimlik ve iletişim bilgilerini, pozisyonunu ve istihdam durumunu tutan bir domain entity’sidir. Domain katmanına aittir ve muhtemelen diğer katmanlar (ör. Application/Infrastructure) tarafından persist ve iş kuralları için kullanılır.

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
| Position | `public string Position { get; set; }` | Görev/pozisyon bilgisi. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktif çalışma durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = true`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
- Sadece Domain katmanı görünür; diğer katmanlar (Application, Infrastructure, API) bu depoda veya girdide yer almıyor.
- Entity’de validasyon, invariant veya davranış yok; tüm alanlar set edilebilir. İleride domain kuralları (ör. zorunlu alanlar, e-posta formatı, aktiflik değişim kuralları) eklenmesi düşünülebilir.
- Varsayılan `string.Empty` ve `IsActive = true` başlangıçları net; `HireDate` ve `Id` için atama sorumluluğu dış katmanlara bırakılmış görünüyor.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” çözümü içinde “Library.Domain” katmanıdır. Amaç, kütüphane alanına ait domain varlıkları ve repository sözleşmelerini tanımlamak; burada özellikle `BookCategory` için repository kontratı sağlanmıştır. Hedef framework bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı/Clean-Architecture benzeri bir ayrım ima ediliyor; yalnızca Domain katmanı görülebiliyor. Domain, iş kuralları, entity’ler ve kontratları (repository arayüzleri) barındırır. Uygulama, Altyapı veya API katmanlarına dair somut dosya bulunmuyor.

Keşfedilen proje/assembly’ler:
- Library.Domain — Domain katmanı: entity tanımları ve repository arayüzleri.

Harici paket/çatı: Bu dosyadan görünür bir harici bağımlılık yok.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
[Library.Domain]

---

### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlığı için repository sözleşmesini genişletir ve isimle arama ile ilişkili kitaplarıyla birlikte getirme operasyonlarını tanımlar. Domain katmanında yer alır ve altyapı katmanındaki somut repository implementasyonları için kontrat sağlar.

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
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Kategori adını kullanarak bir `BookCategory` örneğini asenkron olarak getirir. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Verilen `id` için `BookCategory` varlığını ilişkili kitaplarıyla birlikte asenkron olarak getirir. |

**5. Temel Davranışlar ve İş Kuralları**
Kontrat — davranış yok. Uygulama ayrıntıları (ör. ada göre aramada büyük/küçük harf duyarlılığı, ilişkili kitapların yüklenme şekli) bu arayüzden anlaşılamaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağıranlar uygulama/servis katmanı bileşenleridir (bu dosyadan kesin değil).
- **Aşağı akış:** `IRepository<BookCategory>` kontratı; `BookCategory` entity’si.
- **İlişkili tipler:** `BookCategory`, `IRepository<T>`

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametresi bulunmuyor; uzun sürebilecek veri erişimi için iptal desteği genellikle beklenir.
- `GetByNameAsync` için ad aramasının kültür/büyük-küçük harf duyarlılığı sözleşmede belirtilemiyor; uygulamada tutarlılık önemli.

---

Genel Değerlendirme
- Yalnızca Domain katmanına ait bir arayüz dosyası mevcut; çözümün diğer katmanları görünmüyor.
- Repository kontratında iptal belirteci (`CancellationToken`) eksikliği dikkat çekiyor.
- Taban `IRepository<T>` sözleşmesi ve `BookCategory` entity’si bu girdi içinde sağlanmamış; uygulamanın tam resmi için bu tiplerin görülmesi faydalı olur.### Project Overview
Proje adı: Library (Library.Domain). Amaç: Kütüphane alan modelini ve repository sözleşmelerini tanımlamak; uygulama katmanlarına bağımlılık yaratmadan çekirdek domain anlaşmalarını sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean-vari yapı; görünen Domain katmanı sözleşmeleri içeriyor, başka katmanlar bu dosyadan çıkarılamıyor. Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain varlıkları ve repository arayüzleri (iş kurallarına yakın sözleşmeler).
Görünen harici paket/çatı: Bu dosyadan anlaşılmıyor. Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (bağımsız sözleşmeler ve varlıklar)

---
### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlığı için repository sözleşmesini tanımlar ve genel `IRepository<Book>` yeteneklerini kitaplara özgü sorgularla genişletir. Domain katmanına aittir ve uygulama/infrastructure katmanlarında somut implementasyonlar için sözleşme sağlar.

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
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Mevcut/ödünç verilebilir `Book` kayıtlarını asenkron olarak döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen `isbn` değeriyle eşleşen kitabı asenkron olarak getirir; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış implementasyonu yok. İş anlamı: “mevcut” kitapları listeleme ve ISBN’e göre tekil getirme operasyonlarını bekler. `GetByISBNAsync` null dönebilir; bulunamama durumunun normal kabul edildiği ima edilir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri ve API katmanı bu arayüzü kullanarak kitap erişimi gerçekleştirir (bu dosyadan doğrudan çağırıcılar görülemez).
- **Aşağı akış:** `IRepository<Book>` (genel CRUD sözleşmesi), `Library.Domain.Entities.Book`.
- **İlişkili tipler:** `Book`, `IRepository<T>`.

### Genel Değerlendirme
Kod tabanında yalnızca Domain katmanına ait bir repository arayüzü görülüyor. Mimari katmanlaşma Domain odaklı ve sözleşme-temelli; ancak Application/Infrastructure/API katmanları, dış paketler ve konfigürasyon gereksinimleri bu girdiyle doğrulanamıyor. Implementasyon sınıfları ve birim testleri görülmediği için hata yönetimi, sorgu kriterleri ve performans/paginasyon stratejileri belirsiz.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane alanındaki müşteri varlıkları için domain sözleşmeleri tanımlamak (özelleşmiş müşteri sorguları).
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Clean Architecture (türevi) işaretleri; mevcut katman Domain. Domain katmanı, varlıklar ve repository sözleşmeleri içeriyor.
- Keşfedilen Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları ve repository arayüzleri.
- Kullanılan Dış Paketler/Framework’ler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] (Entities, Interfaces)

---
### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, müşteri varlıkları (`Customer`) için temel `IRepository<Customer>` kontratını genişleterek e‑posta, üyelik numarası ve aktiflik durumuna göre sorgu operasyonları sunar. Domain katmanında yer alır ve Infrastructure katmanında somutlanması beklenen bir sözleşmedir.

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
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E‑posta adresine göre tek bir müşteriyi getirir (yoksa `null`). |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre tek bir müşteriyi getirir (yoksa `null`). |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif müşterilerin tamamını döner. |

**5. Temel Behaviors ve İş Kuralları**
- Asenkron sorgu sözleşmeleri tanımlıdır; null dönebilme (`Customer?`) olasılığı ile bulunamama durumu ifade edilir.
- `GetActiveCustomersAsync` aktiflik filtresini öngörür; aktiflik kriteri `Customer` içindeki bir özelliğe dayanmalıdır (bu dosyadan tam kriter anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** Uygulama servisleri/kullanım yerleri DI üzerinden çözümlenir (bu dosyadan somut çağırıcılar anlaşılmıyor).
- **Aşağı akış:** `IRepository<Customer>`, `Customer`.
- **İlişkili tipler:** `Library.Domain.Entities.Customer`, `IRepository<Customer>`.

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` desteği yok; yüksek hacimli/IO bağlamlarında iptal desteği faydalı olabilir.
- `IRepository<Customer>` detayları bu dosyada görünmediğinden, sözleşme bütünlüğü (CRUD kapsamı) doğrulanamıyor.

### Genel Değerlendirme
Kod, Domain katmanında sade ve amaç odaklı bir repository sözleşmesi ortaya koyuyor. Clean Architecture yaklaşımıyla uyumlu olarak, altyapı bağımlılıkları sızdırılmıyor. İyileştirme olarak asenkron metodlara `CancellationToken` eklenmesi ve aktiflik kriterinin domain modelinde netleştirilmesi (adlandırma/yorum) önerilebilir. Ek katmanlar ve projeler görünmediği için mimari bağımlılık akışının geri kalanı bu veriyle çıkarılamıyor.### Project Overview
Projenin adı koddan “Library” olarak anlaşılıyor; amaç, alan (Domain) katmanında generic depo (repository) sözleşmesiyle veri erişim soyutlaması sağlamak. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari yaklaşım katmanlı/Clean Architecture eğilimli: `Domain` katmanı bağımlılıkları tanımlar, uygulama/altyapı katmanları bu sözleşmeleri uygular. Keşfedilen proje/assembly: `Library.Domain` — domain sözleşmeleri ve tiplerini barındırır. Görünen harici paket yok. Konfigürasyon gereksinimleri bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Interfaces)
  ↑ (uygulayan/bağımlı katmanlar bu dosyadan anlaşılmıyor)

---
### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
`IRepository<T>` generic depo sözleşmesi, temel CRUD benzeri işlemler için asenkron metotlar sunar. Amaç, veri erişim detaylarını soyutlayarak uygulama katmanlarının altyapıya bağımlılığını azaltmaktır. Domain katmanına aittir.

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
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları asenkron olarak listeler. |
| AddAsync | `Task AddAsync(T entity)` | Yeni varlık ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut varlığı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- CRUD benzeri temel operasyonlar için asenkron sözleşme tanımlar.
- `GetByIdAsync` bulunamama durumunda `null` dönebileceğini ifade eder.
- Kimlik türü `Guid` olarak sabitlenmiştir (silme ve tekil getirme için).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** `T` generic parametresi (domain entity/aggregate türleri olması beklenir, bu dosyadan kesin değil).

**7. Eksikler ve Gözlemler**
- `CancellationToken` desteği yok; uzun süren IO işlemlerinde iptal yönetimi eksik olabilir.
- Sayfalama/sıralama veya filtreleme için yöntemler yok; `GetAllAsync` büyük veri setlerinde maliyetli olabilir.
- Ek olarak `ExistsAsync`, `CountAsync` gibi yardımcı metotlar bulunmuyor; kullanım senaryolarına göre ihtiyaç doğabilir.

---
Genel Değerlendirme
Kod tabanında yalnızca domain katmanındaki bir repository sözleşmesi görülüyor. Bu, Clean/katmanlı mimariye uygun bir başlangıç. Asenkron imzalar yerinde; ancak iptal belirteci ve sayfalama/filtreleme yetenekleri eklenirse daha üretim-dostu olur. Diğer katmanlar (Application/Infrastructure/API) ve konfigürasyon ayrıntıları bu depodan görünmüyor; çözüme eklendikçe bağımlılık akışı ve paket kullanımları netleşmelidir.### Project Overview
- Proje adı: Library (Domain katmanı)
- Amaç: Kütüphane alan modelleri ve sözleşmelerini (repository arayüzleri) tanımlamak; iş kurallarının merkezde tutulacağı çekirdek katman.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture eğilimli; görünen katman Domain. Diğer katmanlar bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain entity’leri ve repository arayüzleri.
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities, Interfaces)
  • Harici bağımlılık görünmüyor

---
### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` entity’si için repository sözleşmesini tanımlar ve `IRepository<Staff>`’i genişleterek personele özgü sorguları ekler. Domain katmanına aittir ve veri erişiminin arayüzünü belirleyerek Infrastructure katmanındaki implementasyonlardan bağımsızlık sağlar.

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
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | E-posta adresine göre tek bir `Staff` kaydını (yoksa `null`) asenkron döndürür. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif olan tüm `Staff` kayıtlarını asenkron döndürür. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetByEmailAsync` benzersiz e-posta ile kişiyi bulma sözleşmesi sunar; bulunamazsa `null` dönebilir.
- `GetActiveStaffAsync` “aktif” durumuna göre filtrelenmiş `Staff` koleksiyonu döndürmelidir; “aktif” tanımı entity tarafındaki duruma/alanlara dayanır (bu dosyadan anlaşılmıyor).
- Arayüz davranış tanımlamaz; doğrulama ve hata yönetimi implementasyona bırakılır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; Application/Domain servisleri tarafından kullanılmak üzere tasarlanmıştır (çağıranlar bu dosyadan anlaşılmıyor).
- **Aşağı akış:** Implementasyonlar veri erişim teknolojilerine bağımlı olacaktır (bu dosyadan anlaşılmıyor).
- **İlişkili tipler:** `Library.Domain.Entities.Staff`, `IRepository<Staff>`

**7. Eksikler ve Gözlemler**
- Async imzalarda `CancellationToken` parametresi yok; uzun süren sorgularda iptal desteği eksik olabilir.
- `GetActiveStaffAsync` için sayfalama/sıralama seçenekleri bulunmuyor; büyük veri setlerinde performans ve bellek kullanımı etkilenebilir.

### Genel Değerlendirme
Kod tabanı, Domain katmanında repository sözleşmesi üzerinden veri erişimini soyutlamaya odaklanıyor. Görünen tek dosyada Clean Architecture’a uygun bağımlılık yönü korunuyor. Geliştirme sırasında asenkron imzalara `CancellationToken` eklenmesi ve geniş koleksiyon döndüren metotlar için sayfalama/sıralama sözleşmelerinin düşünülmesi faydalı olacaktır. Diğer katmanlar (Application/Infrastructure/API) bu girdide görünmediğinden genel mimari bütünlük bu dosyadan değerlendirilemiyor.### Proje Genel Bakış
Proje, bir kütüphane alanına ait domain varlıklarını Entity Framework Core ile kalıcı hale getiren bir altyapı katmanı içerir. `Library.Infrastructure` projesi, `Library.Domain.Entities` içindeki varlıkları `DbContext` üzerinden ilişkilendirir ve kısıtlar. Hedef framework bu dosyadan anlaşılmıyor. Mimari, en azından Domain ve Infrastructure katmanlarından oluşan katmanlı bir yapı izlenimini vermektedir.

Keşfedilen projeler/assembly’ler:
- Library.Domain — Domain varlıkları (`Book`, `BookCategory`, `Staff`, `Customer`)
- Library.Infrastructure — EF Core tabanlı veri erişimi ve `DbContext` tanımı

Kullanılan ana dış paket/çerçeve:
- Microsoft.EntityFrameworkCore

Yapılandırma gereksinimleri:
- `LibraryDbContext` için bir veritabanı bağlantı dizesi gereklidir (anahtar adı ve sağlayıcı bu dosyadan anlaşılmıyor).

### Mimari Diyagram
Library.Infrastructure.Data (EF Core)
  ↘ depends on
Library.Domain.Entities

Not: Üst katman(lar) (ör. API/Application) bu dosyadan anlaşılmıyor; ancak tipik akışta üst katmanlar Infrastructure’ı kullanır.

---
### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**
`LibraryDbContext`, EF Core `DbContext`’i olarak kütüphane domain varlıklarını (kitaplar, kategoriler, personel, müşteriler) haritalar ve kısıtlarını tanımlar. Altyapı (Infrastructure) katmanına aittir ve veri erişiminin merkezidir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlamı için konfigürasyon ve sağlayıcı ayarları

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | EF Core bağlamını verilen seçeneklerle başlatır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlıkları için sorgu ve komut erişimi sağlar. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlıklarına erişim sağlar. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlıklarına erişim sağlar. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlıklarına erişim sağlar. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Varlık haritalama kurallarını ve kısıtlarını yapılandırır. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book`:
  - `Id` birincil anahtar.
  - `Title` (max 200), `Author` (max 150), `ISBN` (max 20) zorunlu.
  - `ISBN` benzersiz indeks.
  - `BookCategory` ile ilişki: çok–bir; `BookCategoryId` FK, silmede `SetNull`.
- `BookCategory`:
  - `Id` birincil anahtar.
  - `Name` zorunlu (max 100), benzersiz indeks.
  - `Description` (max 500) opsiyonel.
- `Staff`:
  - `Id` birincil anahtar.
  - `FirstName`, `LastName`, `Email`, `Position` zorunlu; uzunluk kısıtları (100/200).
  - `Email` benzersiz indeks; `Phone` opsiyonel (max 20).
- `Customer`:
  - `Id` birincil anahtar.
  - `FirstName`, `LastName`, `Email`, `MembershipNumber` zorunlu; uzunluk kısıtları.
  - `Email` ve `MembershipNumber` için benzersiz indeksler.
  - `Phone` (max 20) ve `Address` (max 500) opsiyonel.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; veri erişimi gerektiren üst katman servisleri/handler’lar tarafından kullanılır (bu dosyadan detaylar anlaşılmıyor).
- **Aşağı akış:** EF Core API’leri ve `Library.Domain.Entities` tipleri.
- **İlişkili tipler:** `Book`, `BookCategory`, `Staff`, `Customer`.

**7. Eksikler ve Gözlemler**
- `OnDelete(DeleteBehavior.SetNull)` için `BookCategoryId`’nin nullable olması gerekir; varlık tanımında bu uyumun sağlanıp sağlanmadığı bu dosyadan anlaşılmıyor.
- Ayrı `IEntityTypeConfiguration<>` sınıfları yerine inline konfigurasyon kullanılmış; büyük ölçekli projelerde modüler konfigurasyon tercih edilebilir.

---
Genel Değerlendirme
Kod, EF Core ile temiz ve kurallı bir veri modeli tanımlar; zorunlu alanlar, uzunluk kısıtları ve benzersiz indeksler net şekilde belirtilmiş. Altyapı ve domain ayrımı görülebilir düzeyde. Üst katman (Application/API), sağlayıcı konfigürasyonu, bağlantı dizesi adı ve migration yönetimi bu dosyadan görünmüyor. İlişkiler ve kısıtlar tutarlı; ancak FK nullability ve olası ek cross-entity kurallar domain tarafında doğrulanmalıdır. Modüler konfigurasyon (ayrı mapping sınıfları) ileride bakım kolaylığı sağlayabilir.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” ekosisteminin “Infrastructure” katmanıdır. Amaç: veri erişimi ve altyapı bağımlılıklarının DI konteynerine eklenmesi. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak Domain ve Infrastructure ayrımı görülüyor; Infrastructure katmanı EF Core temelli veri erişimi ve repository implementasyonlarını sağlar, Domain ise arayüzleri tanımlar.

Mimari desen: N-Tier/Clean-Architecture eğilimli ayrım
- Domain: `Library.Domain` (özellikle `Library.Domain.Interfaces`) — repository arayüz sözleşmeleri
- Infrastructure: `Library.Infrastructure` — EF Core `DbContext` ve repository implementasyonları ile DI kurulum

Keşfedilen projeler/assembly’ler:
- Library.Infrastructure — DI uzantısı, EF Core `DbContext`, repository implementasyonları
- Library.Domain (inferred) — `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository` sözleşmeleri

Dış bağımlılıklar:
- Entity Framework Core (`Microsoft.EntityFrameworkCore`, SQL Server sağlayıcısı)
- `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Configuration`

Konfigürasyon gereksinimleri:
- Connection string: `DefaultConnection` (SQL Server)

### Architecture Diagram
Domain (Interfaces)
  ↑
Infrastructure (EF Core, Repositories, DI)
  ↑
Composition Root (API/Worker) — AddInfrastructure çağırır

---
### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik uzantı sınıfı, Infrastructure katmanının DI kaydını merkezileştirir. EF Core `DbContext` kurulumunu ve repository arayüz–implementasyon eşleştirmelerini `IServiceCollection` üzerine ekler; Infrastructure’ın kompozisyon köküne entegrasyon noktasını oluşturur.

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
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core `LibraryDbContext` ve repository servislerini DI konteynerine ekler. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server sağlayıcısıyla `UseSqlServer` üzerinden kaydedilir; bağlantı `configuration.GetConnectionString("DefaultConnection")` ile okunur.
- Repository sözleşmeleri scoped ömürle implementasyonlara bağlanır: `IBookRepository`→`BookRepository`, `IBookCategoryRepository`→`BookCategoryRepository`, `IStaffRepository`→`StaffRepository`, `ICustomerRepository`→`CustomerRepository`.
- `IServiceCollection` zincirlenebilir şekilde geri döndürülür.

**6. Bağlantılar**
- **Yukarı akış:** Kompozisyon kökü (ör. API/Worker) bu uzantıyı çağırır.
- **Aşağı akış:** `Library.Infrastructure.Data.LibraryDbContext`, `Library.Infrastructure.Repositories.*`, `Library.Domain.Interfaces.*`, EF Core SQL Server sağlayıcısı.
- **İlişkili tipler:** `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository`; `BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`; `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- `DefaultConnection` connection string’i zorunlu; yoksa başlangıçta hata oluşabilir. Uygun konfigürasyon doğrulaması bu dosyadan görülmüyor.

---
Genel Değerlendirme
- Katman ayrımı net: Domain arayüzleri, Infrastructure implementasyon ve DI. Kompozisyon kökü (API/Worker) bu dosyadan görünmüyor.
- Hedef framework ve ayrıntılı konfigürasyon (örn. EF Core seçenekleri, migration stratejisi) bu dosyadan anlaşılamıyor.
- Konfigürasyon hatalarına karşı (eksik/bozuk connection string) başlangıçta doğrulama veya fail-fast yaklaşımı eklenmesi faydalı olabilir.### Project Overview
Proje adı: Library (çıkarım). Amaç: Kitap kategorileri için kalıcı veri erişimini EF Core üzerinden sağlamak. Hedef framework: bu dosyadan anlaşılmıyor. Mimari: Katmanlı/Clean Architecture izleri — `Infrastructure` katmanı `Domain` üzerine bağımlı ve repository kalıbını uygular. Keşfedilen projeler/assembly’ler:
- Library.Domain — Entity’ler ve repository arayüzleri (`BookCategory`, `IBookCategoryRepository`)
- Library.Infrastructure — EF Core tabanlı kalıcılık ve repository implementasyonları (`LibraryDbContext`, `BookCategoryRepository`)
Harici paket/çatı: Microsoft.EntityFrameworkCore (EF Core). Konfigürasyon: `LibraryDbContext` için bir veritabanı bağlantı dizesi gerekir (adı/anahtarı bu dosyadan anlaşılmıyor).

### Architecture Diagram
Library.Infrastructure.Repositories -> Library.Infrastructure.Data (LibraryDbContext)
Library.Infrastructure -> Library.Domain.Entities
Library.Infrastructure -> Library.Domain.Interfaces

---
### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için EF Core tabanlı repository uygulamasıdır. `Infrastructure` katmanında yer alır ve `IBookCategoryRepository` sözleşmesini gerçekleştirir; temel CRUD ve sorgu operasyonlarını sağlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext üzerinden `BookCategories` setine erişim ve kalıcılık.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookCategoryRepository(LibraryDbContext context)` | DbContext bağımlılığını alır. |
| GetByIdAsync | `public async Task<BookCategory?> GetByIdAsync(Guid id)` | Kimliğe göre kategori getirir. |
| GetAllAsync | `public async Task<IEnumerable<BookCategory>> GetAllAsync()` | Tüm kategorileri listeler. |
| GetByNameAsync | `public async Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşen kategoriyi döner. |
| GetWithBooksAsync | `public async Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlişkili `Books` ile birlikte kategoriyi yükler. |
| AddAsync | `public async Task AddAsync(BookCategory entity)` | Yeni kategori ekler ve kaydeder. |
| UpdateAsync | `public async Task UpdateAsync(BookCategory entity)` | Kategoriyi günceller ve kaydeder. |
| DeleteAsync | `public async Task DeleteAsync(Guid id)` | Kategori varsa siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Okuma işlemleri: `GetWithBooksAsync` ilişkili `Books` koleksiyonunu `Include` ile eager load eder; diğer okumalar basit sorgudur.
- Ekleme/güncelleme/silme işlemleri her çağrıda `SaveChangesAsync` ile kalıcı hale getirilir.
- `DeleteAsync` hedef bulunamazsa sessizce no-op yapar (exception fırlatmaz).
- `GetByNameAsync` ada tam eşitlik ile filtreler (kültür/büyük-küçük harf duyarlılığı veritabanına/sağlayıcıya bağlıdır).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama hizmetleri/handler’lar tarafından çağrılır (bu dosyadan çağırıcılar detaylı görünmüyor).
- **Aşağı akış:** `LibraryDbContext` ve EF Core API’leri (`DbSet`, `Include`, `FindAsync`, `SaveChangesAsync`).
- **İlişkili tipler:** `BookCategory` (entity), `IBookCategoryRepository` (sözleşme), `LibraryDbContext` (altyapı).

**7. Eksikler ve Gözlemler**
- Okuma senaryolarında `AsNoTracking` kullanılmıyor; performans ve gereksiz değişiklik izleme açısından değerlendirilebilir.
- Metot imzalarında `CancellationToken` desteği yok.
- `DeleteAsync` bulunamayan kayıt için geri bildirim vermez; çağıran tarafın davranışı açısından netlik gerektirebilir.
- Her repository metodunda `SaveChangesAsync` çağrısı birim-iş (Unit of Work) deseninden sapma yaratabilir; çoklu değişikliklerin atomikliği için dış bir UoW tercih edilebilir.

---
Genel Değerlendirme
Kod, EF Core ile temel repository desenini temiz ve anlaşılır şekilde uygular. Katman ayrımı net: `Infrastructure` Domain’e bağımlı. İyileştirme alanları: okuma işlemlerinde `AsNoTracking`, iptal belirteci desteği, silme/güncelleme sonuçlarının daha belirgin geri bildirimi ve birim-iş deseninin düşünülmesi. Hedef framework, konfigürasyon anahtarları ve diğer katmanlar (Application/API) bu dosyadan anlaşılamıyor.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alanındaki `Book` varlıkları için veri erişim operasyonlarını EF Core üzerinden sağlamak.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari Örüntü: Katmanlı/Clean Architecture eğilimli yapı. Domain (entity ve interface’ler) ile Infrastructure (EF Core implementasyonları) katmanları ayrılmış.  
Projeler/Assembly’ler:
- Library.Domain — Varlıklar (`Book`) ve sözleşmeler (`IBookRepository`).
- Library.Infrastructure — Veri erişimi, EF Core `DbContext` (`LibraryDbContext`) ve repository implementasyonu.
Kullanılan Dış Paketler/Çatılar: Microsoft.EntityFrameworkCore (EF Core).  
Konfigürasyon Gereksinimleri: `LibraryDbContext` için connection string ve EF Core sağlayıcı ayarları — bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain  <-used by-  Library.Infrastructure
Library.Infrastructure -> Microsoft.EntityFrameworkCore

---
### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`BookRepository`, `IBookRepository` sözleşmesini EF Core ile gerçekleştiren veri erişim sınıfıdır. `Book` varlıkları için temel CRUD ve sorgulama operasyonlarını sunar. Mimari olarak Infrastructure veri erişim katmanında yer alır ve Domain katmanındaki entity/sözleşmelere bağımlıdır.

**2. Tip Bilgisi**
- Tip: class
- Miras: Yok
- Uygular: `IBookRepository`
- Namespace: `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core bağlamı; `Book` DbSet’i üzerinden veri işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookRepository(Library.Infrastructure.Data.LibraryDbContext context)` | Repository için EF Core bağlamını enjekte eder. |
| GetByIdAsync | `public Task<Library.Domain.Entities.Book?> GetByIdAsync(Guid id)` | Id ile tek kitabı döner. |
| GetAllAsync | `public Task<IEnumerable<Library.Domain.Entities.Book>> GetAllAsync()` | Tüm kitapları listeler. |
| GetAvailableBooksAsync | `public Task<IEnumerable<Library.Domain.Entities.Book>> GetAvailableBooksAsync()` | `IsAvailable` olan kitapları listeler. |
| GetByISBNAsync | `public Task<Library.Domain.Entities.Book?> GetByISBNAsync(string isbn)` | ISBN’e göre tek kitabı döner. |
| AddAsync | `public Task AddAsync(Library.Domain.Entities.Book entity)` | Yeni kitabı ekler ve `SaveChangesAsync` çağırır. |
| UpdateAsync | `public Task UpdateAsync(Library.Domain.Entities.Book entity)` | Kitabı günceller ve `SaveChangesAsync` çağırır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Id bulunan kitabı siler; yoksa işlem yapmaz. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetAvailableBooksAsync` yalnızca `b.IsAvailable == true` olan kayıtları döndürür.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` ile kalıcılaştırır; her operasyon kendi kısa işlemini tamamlar.
- `DeleteAsync` aranan kitap yoksa sessizce çıkış yapar; exception fırlatmaz.
- Sorgular EF Core asenkron uzantılarıyla çalışır; izleme ve include davranışları varsayılan EF ayarlarına bağlıdır (bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- Yukarı akış: `IBookRepository` üzerinden Application/Service katmanı; DI üzerinden çözümlenir.
- Aşağı akış: `LibraryDbContext` ve `Microsoft.EntityFrameworkCore` LINQ uzantıları.
- İlişkili tipler: `Book`, `IBookRepository`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Her repository çağrısında `SaveChangesAsync` yapılması, birim-iş (Unit of Work) desenine ihtiyaç duyulan senaryolarda çoklu transaction’a yol açabilir.
- Metotlarda `CancellationToken` desteği yok.
- `GetAllAsync` için sayfalama/filtreleme bulunmuyor; büyük veri setlerinde performans etkisi olabilir.

---
Genel Değerlendirme
Kod, Domain ile Infrastructure ayrımını koruyan sade bir repository implementasyonu sunuyor ve EF Core’u doğru şekilde kullanıyor. Transaction yönetimi ve birim-iş koordinasyonu repository yerine üst katmanda düşünülmeli; aksi halde çoklu kaydetme çağrıları istenmeyen yan etkilere neden olabilir. İleride iptal belirteci desteği, tutarlı hata yönetimi ve ölçeklenebilirlik için sayfalama/filtreleme gibi iyileştirmeler önerilir.### Project Overview
- Proje adı: Library (çıkarım: namespace’lerden)
- Amaç: Kütüphane alanındaki müşteri varlıklarını depolamak ve erişmek için repository katmanı sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture eğilimli yapı. Görülen katmanlar:
  - Domain: `Library.Domain.Entities`, `Library.Domain.Interfaces` — çekirdek modeller ve sözleşmeler.
  - Infrastructure: `Library.Infrastructure.*` — veri erişimi ve kalıcılık detayları (EF Core).
- Keşfedilen projeler/assembly’ler:
  - `Library.Domain` — entity ve repository interface’leri.
  - `Library.Infrastructure` — EF Core tabanlı repository ve `DbContext`.
- Kullanılan dış paket/çatı: `Microsoft.EntityFrameworkCore` (EF Core).
- Konfigürasyon gereksinimleri: `LibraryDbContext` için veritabanı bağlantı dizesi (adı ve sağlayıcı bu dosyadan anlaşılmıyor).

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---
### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`CustomerRepository`, `ICustomerRepository` sözleşmesini EF Core kullanarak uygular ve `Customer` varlıkları üzerinde CRUD ve sorgulama işlemlerini gerçekleştirir. Clean Architecture’da Infrastructure veri erişim katmanında yer alır ve Domain’in `ICustomerRepository` arayüzünü somutlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `Customer` DbSet’i üzerinden veritabanı işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `CustomerRepository(LibraryDbContext context)` | `DbContext` bağımlılığını alır. |
| GetByIdAsync | `Task<Customer?> GetByIdAsync(Guid id)` | Bir müşteriyi `Id` ile arar. |
| GetAllAsync | `Task<IEnumerable<Customer>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre ilk eşleşen müşteriyi döner. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre ilk eşleşeni döner. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive` olan müşterileri listeler. |
| AddAsync | `Task AddAsync(Customer entity)` | Yeni müşteri ekler ve `SaveChangesAsync` çağırır. |
| UpdateAsync | `Task UpdateAsync(Customer entity)` | Müşteriyi günceller ve `SaveChangesAsync` çağırır. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteri varsa siler ve `SaveChangesAsync` çağırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Sorgular EF Core üzerinden yürütülür; `FindAsync`, `FirstOrDefaultAsync`, `ToListAsync` kullanılır.
- `GetActiveCustomersAsync` yalnızca `IsActive == true` olan kayıtları döner.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her işlem sonunda `SaveChangesAsync` çağırır; birim iş (Unit of Work) kapsamı bu sınıf içinde sonlandırılır.
- `DeleteAsync`, kayıt bulunamazsa sessizce hiçbir işlem yapmadan döner; exception fırlatmaz.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; `ICustomerRepository` tüketen uygulama servisleri/handler’lar kullanır.
- Aşağı akış: `LibraryDbContext`, EF Core (`Microsoft.EntityFrameworkCore`).
- İlişkili tipler: `Customer` (entity), `ICustomerRepository` (sözleşme), `LibraryDbContext` (veri erişimi).

**7. Eksikler ve Gözlemler**
- Sorgularda değişiklik yapılmayan okumalar için `AsNoTracking()` kullanılmıyor; performans/izleme maliyeti olabilir.
- İstek bazlı iptal desteği için `CancellationToken` parametreleri yok.
- Repository içinde `SaveChangesAsync` çağrıları, çoklu repository işlemlerinde atomiklik/transaction yönetimini zorlaştırabilir; ayrı bir Unit of Work desenine ihtiyaç duyulabilir.
- Listeleme operasyonlarında sayfalama yok; büyük veri setlerinde maliyetli olabilir.

---
### Genel Değerlendirme
Kod, Clean Architecture’a uygun olarak Domain arayüzlerini Infrastructure’da EF Core ile somutluyor. Repository, temel CRUD ve basit sorguları kapsıyor. İyileştirme alanları: okuma sorgularında `AsNoTracking`, metotlara `CancellationToken` eklenmesi, çoklu işlem senaryolarında `SaveChangesAsync` çağrılarını merkezi bir Unit of Work’e taşımak ve listelemelerde sayfalama/filtreleme stratejileri belirlemek. Hedef framework ve konfigürasyon ayrıntıları (bağlantı dizesi adı/sağlayıcı) bu dosyadan çıkarılamıyor.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım); amaç: kitap varlıklarını depolamak/erişmek için depo (repository) altyapısı sağlamak; hedef çatı/.NET sürümü bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı Mimari (Domain → Infrastructure). Domain katmanı entity ve sözleşmeleri içerir (`Book`, `IBookRepository`), Infrastructure katmanı bu sözleşmelerin somut implementasyonlarını sağlar (InMemory).
- Keşfedilen projeler/assembly’ler ve rolleri:
  - Library.Domain: Domain entity’leri (`Book`) ve sözleşmeleri (`IBookRepository`).
  - Library.Infrastructure: Repository implementasyonları ve altyapı detayları.
- Kullanılan dış paketler/çerçeveler: Görünmüyor; yalnızca BCL koleksiyonları ve LINQ.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (InMemory implementasyonda konfigürasyon gereksinimi yok).

### Architecture Diagram
Domain (Entities, Interfaces) ← Infrastructure (Repositories)

---
### `Library.Infrastructure/Repositories/InMemoryBookRepository.cs`

**1. Genel Bakış**
`InMemoryBookRepository`, `IBookRepository` sözleşmesini bellek içi bir `List<Book>` ile uygular. Geliştirme/test senaryoları için hızlı ve kalıcı olmayan veri erişimi sağlar. Mimari olarak Infrastructure katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Domain.Interfaces.IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Id’ye göre kitabı döndürür; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitapları döndürür. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre kitabı döndürür; yoksa `null`. |
| AddAsync | `Task AddAsync(Book entity)` | Yeni kitabı listeye ekler. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Id eşleşirse liste öğesini günceller; bulunamazsa sessizce geçer. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id’ye göre kitabı bulup listeden çıkarır; yoksa sessizce geçer. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm işlemler bellek içi `List<Book>` üzerinde çalışır; kalıcılık yok.
- `GetAllAsync` ve sorgular `IEnumerable<Book>` döner; altta yatan listeye referans verir (kopya değil).
- `UpdateAsync`/`DeleteAsync` hedef bulunamazsa hata fırlatmaz; no-op yapar.
- Filtreleme: `GetAvailableBooksAsync` yalnızca `IsAvailable` true olanları döndürür.
- Eşzamanlılık/iş parçacığı güvenliği sağlanmaz.
- Validasyon ve benzersizlik (ör. ISBN) kontrolü yapılmaz.

**6. Bağlantılar**
- **Yukarı akış:** `IBookRepository` kullanan servisler/handler’lar; genelde DI üzerinden çözümlenir.
- **Aşağı akış:** `Library.Domain.Entities.Book`, `System.Linq` işlemleri.
- **İlişkili tipler:** `IBookRepository`, `Book`.

**7. Eksikler ve Gözlemler**
- Thread-safety yok; çoklu iş parçacığında veri tutarsızlığı olabilir.
- `GetAllAsync` iç listeyi sızdırabilir (modifiye edilebilir referans).
- Güncelleme/silmede bulunamama durumunda geribildirim/hata yönetimi yok.
- ISBN benzersizlik kontrolü ve giriş validasyonları eksik.

### Genel Değerlendirme
Kod tabanı Domain ve Infrastructure katmanları arasında net bir ayrım ima ediyor; ancak yalnızca InMemory altyapı implementasyonu mevcut. Kalıcılık, hata yönetimi, eşzamanlılık ve validasyon eksikleri üretim senaryolarına uygun değil; test/POC amaçlarıyla uyumlu. Daha sağlam bir çözüm için kalıcı bir repository (ör. EF Core), DTO/mapper katmanı, thread-safe koleksiyonlar veya kilitleme, ve tutarlı hata/validasyon politikaları eklenmeli.### Project Overview
Bu depo, bir kütüphane yönetim alanı için katmanlı/temiz mimari yaklaşımıyla inşa edilmiş görünüyor. Görünen katmanlar: `Library.Domain` (varlıklar ve sözleşmeler) ve `Library.Infrastructure` (veri erişimi). Altyapı katmanı, Entity Framework Core ile `LibraryDbContext` üzerinden kalıcı veri erişimi sağlar. Hedef çatı sürümü bu dosyadan kesin değil; modern .NET (Core) ve EF Core kullanımı ima ediliyor. Amaç, `Staff` (personel) varlığı için depo (repository) kalıbıyla CRUD ve sorgulama operasyonlarını sunmaktır.

Mimari desen: Clean Architecture/N-Tier benzeri.
- Domain: `Entities` ve `Interfaces` (ör. `Staff`, `IStaffRepository`).
- Infrastructure: `Repositories` ve `Data` (ör. `StaffRepository`, `LibraryDbContext`) — Domain’e bağımlı, EF Core ile veri erişimi.

Projeler/Assembly’ler:
- Library.Domain — Varlık ve arayüz sözleşmeleri.
- Library.Infrastructure — EF Core tabanlı repository ve DbContext.

Harici paketler/çerçeveler:
- Microsoft.EntityFrameworkCore (EF Core, `DbContext`, `DbSet`, async LINQ uzantıları).

Konfigürasyon:
- `LibraryDbContext` için bağlantı dizesi ve sağlayıcı ayarları gerekir; anahtar/isim bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Infrastructure] --> [Library.Domain]

---

### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`StaffRepository`, `Staff` varlığı için EF Core tabanlı veri erişimi sağlar ve `IStaffRepository` sözleşmesini uygular. Infrastructure katmanında yer alır ve `LibraryDbContext` üzerinden CRUD ve basit sorgulamalar gerçekleştirir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Domain.Interfaces.IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core `DbContext`; `Staff` verilerine erişim ve `SaveChangesAsync` yönetimi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffRepository(LibraryDbContext context)` | DbContext bağımlılığını DI ile alır. |
| GetByIdAsync | `public Task<Staff?> GetByIdAsync(Guid id)` | Bir `Staff` kaydını birincil anahtarla getirir. |
| GetAllAsync | `public Task<IEnumerable<Staff>> GetAllAsync()` | Tüm `Staff` kayıtlarını döner. |
| GetByEmailAsync | `public Task<Staff?> GetByEmailAsync(string email)` | `Email` eşleşen ilk `Staff` kaydını döner. |
| GetActiveStaffAsync | `public Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive` true olan personelleri listeler. |
| AddAsync | `public Task AddAsync(Staff entity)` | Yeni `Staff` ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Staff entity)` | Var olan `Staff` kaydını günceller ve kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Id ile `Staff` bulursa siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetActiveStaffAsync` yalnızca `IsActive == true` filtreli kayıtları döner.
- `GetByEmailAsync` bire bir eşitlik karşılaştırması yapar; kültür/büyük-küçük harf duyarlılığı veritabanı/kolasyon ayarlarına bağlıdır.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` tetikler; işlem (transaction) kapsamı tek işlemle sınırlıdır.
- `DeleteAsync` kayıt bulunamazsa sessizce hiçbir işlem yapmaz (exception fırlatmaz).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak Application/Service katmanları veya API controller’ları çağırır.
- **Aşağı akış:** `LibraryDbContext` (EF Core), `DbSet<Staff>`.
- **İlişkili tipler:** `Library.Domain.Entities.Staff`, `Library.Domain.Interfaces.IStaffRepository`, `Library.Infrastructure.Data.LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- `UpdateAsync` ve `DeleteAsync` için eşzamanlılık (concurrency) kontrolü veya varlık izleme durumuna dair doğrulama yok; olası çakışmalar sessiz geçebilir.
- `GetByEmailAsync` benzersizliği varsayıyor gibi; benzersiz kısıt olup olmadığı bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Mimari katmanlar net: Domain ve Infrastructure. Uygulama/Api katmanları bu örnekte görünmüyor.
- Repository yöntemleri basit ve doğrudan EF Core çağrılarına dayanıyor; tek işlem-tek kayıt odaklı.
- Birim çalışma (Unit of Work) veya toplu işlem (transaction) koordinasyonu görünmüyor; her method kendi `SaveChangesAsync` çağrısını yapıyor.
- Eşzamanlılık, hata yönetimi ve domain doğrulamaları bu katmanda ele alınmamış; üst katmanlarda veya EF yapılandırmalarında ele alınması önerilir.### Project Overview
Proje adı Library. Amaç: Kitap kategorileri için HTTP API uç noktaları sağlamak. Hedef çatı ASP.NET Core Web API (Controller tabanlı). Katmanlar koddan anlaşıldığı kadarıyla Application (DTO’lar ve servis kontratları) ve API/Presentation (Controllers). API katmanı `Library.Application.DTOs` ve `Library.Application.Interfaces` ad alanlarına bağımlı.

Mimari desen: N-Tier benzeri ayrım. 
- API/Presentation: ASP.NET Core Controller’ları, HTTP yönlendirme ve sonuç dönüşleri.
- Application: DTO’lar ve servis arayüzleri (iş kuralları ve use case’ler burada beklenir).
- (Varsayılan) Infrastructure/Domain katmanları bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library (API/Presentation) — Web API uç noktaları.
- Library.Application (Application) — DTO ve servis arayüzleri (referanslardan çıkarım).

Kullanılan dış paket/çatı:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).

Yapılandırma gereksinimleri:
- Bu dosyadan bir yapılandırma anahtarı veya bağlantı dizesi gereksinimi anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için listeleme ve tekil sorgulama uç noktalarını sağlayan ASP.NET Core API Controller’ıdır. Presentation katmanına aittir ve iş mantığını `IBookCategoryService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori verileri için application katmanı servis kontratı.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `public BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını DI üzerinden alır. |
| GetAll | `public Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategori DTO’larını döner; `200 OK`. |
| GetById | `public Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID ile kategori getirir; bulunamazsa `404 NotFound`, aksi halde `200 OK`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servisten `null` dönerse `NotFound()` döner; aksi halde `Ok(category)`.
- `GetAll`: Servisten dönen koleksiyon doğrudan `Ok(...)` ile sonuçlanır.
- Girdi validasyonu framework’ün route kısıtıyla (`{id:guid}`) sınırlıdır; ek doğrulama yok.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri; ASP.NET Core routing tarafından çağrılır.
- Aşağı akış: `IBookCategoryService`
- İlişkili tipler: `BookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- CRUD açısından Create/Update/Delete uç noktaları eksik; yalnızca Read (GetAll, GetById) mevcut.
- Yetkilendirme/authorization öznitelikleri yok; erişim kontrolü bu dosyada görünmüyor.### Project Overview
Proje adı: Library. Amaç: Kitaplara yönelik CRUD ve sorgulama işlemlerini HTTP üzerinden sunan bir ASP.NET Core Web API. Hedef çatı: .NET (ASP.NET Core). Kesin sürüm bu dosyadan anlaşılmıyor.

Mimari: N-Tier/Layered yaklaşımı. Sunum katmanı (`Library` – Controllers) Application katmanına (`Library.Application`) bağımlı. Uygulama katmanı DTO’lar ve servis sözleşmeleri (interfaces) içeriyor. Domain/Infrastructure katmanları bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library: API/Presentation; HTTP endpoint’leri, controller’lar.
- Library.Application: DTO’lar (`BookDto`, `CreateBookDto`, `UpdateBookDto`) ve servis arayüzü (`IBookService`).

Harici paket/çerçeveler:
- `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC/Web API).

Konfigürasyon gereksinimleri:
- Bu dosyadan spesifik appsettings/connection string bilgisi anlaşılmıyor.

### Architecture Diagram
Library (API/Controllers) --> Library.Application (DTOs & Service Interfaces)

---

### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitap kaynakları için RESTful HTTP endpoint’leri sağlar. API/Presentation katmanındadır ve iş mantığını `IBookService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplara ilişkin iş operasyonlarını sağlar (listeleme, getirme, oluşturma, güncelleme, silme).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BooksController(IBookService bookService)` | Servis bağımlılığını enjekte eder. |
| GetAll | `Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döndürür (`200 OK`). |
| GetById | `Task<ActionResult<BookDto>> GetById(Guid id)` | ID’ye göre kitabı döndürür; yoksa `404 NotFound`. |
| GetAvailable | `Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Müsait kitapları listeler (`200 OK`). |
| Create | `Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Yeni kitap oluşturur; `201 Created` ve `Location` başlığı ile döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Kitabı günceller; başarıda `204 NoContent`, yoksa `404 NotFound`. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Kitabı siler; `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servisten `null` gelirse `404 NotFound`.
- `Create`: Başarıda `CreatedAtAction(nameof(GetById), new { id = book.Id }, book)` ile kaynak konumunu bildirir.
- `Update`: `KeyNotFoundException` yakalanır ve `404 NotFound` döndürülür.
- `Delete`: Hata yönetimi bu seviyede yapılmaz; her durumda `204 NoContent` döner (servis tarafı hataları yüzeye çıkabilir).
- Model validasyonu için yalnızca `[ApiController]` özniteliğinin otomatik mekanizmalarına dayanır.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (REST çağrıları); DI üzerinden çözümlenir.
- Aşağı akış: `IBookService` (`GetAllAsync`, `GetByIdAsync`, `GetAvailableBooksAsync`, `CreateAsync`, `UpdateAsync`, `DeleteAsync`).
- İlişkili tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`.

**7. Eksikler ve Gözlemler**
- Endpoint’lerde `[Authorize]` bulunmuyor; yetkilendirme ihtiyacı varsa güvenlik açığı oluşturabilir.
- `Delete` için bulunamayan kayıt senaryosunda özel hata eşlemesi yok; servis bir istisna fırlatırsa HTTP durum kodu tutarsız olabilir.
- `Update` yalnızca `KeyNotFoundException`’ı ele alıyor; geçersiz girişler veya iş kuralı ihlalleri için farklı hata kodları/yanıtları tanımlanmamış.

---

Genel Değerlendirme
- Katmanlar arası bağımlılıklar temiz: Controller sadece Application katmanı arayüzlerine bağlı.
- Hata yönetimi temel düzeyde; silme ve güncelleme için daha zengin durum kodları ve problem detay yanıtları (RFC 7807) eklenebilir.
- Yetkilendirme/kimlik doğrulama belirgin değil; güvenlik gereksinimlerine göre `[Authorize]` ve politika bazlı kontroller eklenmeli.
- Validation, `[ApiController]` model state’e dayanıyor; domain/application seviyesinde ek doğrulamalar ve tutarlı hata yanıtlama faydalı olur.
- Genişletilebilirlik için versiyonlama (API Versioning) ve kapsamlı yanıt sözleşmeleri (ör. hata şemaları) düşünülmeli.### Project Overview
Proje adı: Library (ASP.NET Core Web API). Amaç: Müşteri verileri için CRUD ve sorgulama uç noktaları sağlamak. Hedef çatı ve sürüm bu dosyadan anlaşılmıyor. Mimari, sunum katmanının `Library.Application` içindeki arayüz ve DTO’lara bağımlı olduğu katmanlı bir yapıdadır. En azından API/Presentation ve Application katmanları gözlemlenmektedir.

Mimari desen: Katmanlı mimari (N‑Tier benzeri).
- Presentation/API: ASP.NET Core Controller’lar (ör. `CustomersController`) HTTP isteklerini karşılar ve Application servislerine delege eder.
- Application: `ICustomerService` ve `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` gibi sözleşmeler/DTO’lar. İş kuralları ve use case’ler burada beklenir. Diğer katmanlar bu dosyadan anlaşılmıyor.

Projeler/Assembly’ler:
- Library: Web API sunumu (Controller’lar).
- Library.Application: DTO ve servis sözleşmeleri (referans edilen).

Harici paket/çerçeveler:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).

Yapılandırma gereksinimleri:
- Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  ↓
Library.Application (Contracts, DTO’lar)

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteriler için listeleme, id ile getirme, aktifleri getirme, oluşturma, güncelleme ve silme uç noktalarını sağlayan ASP.NET Core API controller’ıdır. Sunum katmanında yer alır ve iş akışını `ICustomerService` aracılığıyla Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri verilerine yönelik iş operasyonlarını yürütür (listeleme, getirme, oluşturma, güncelleme, silme).

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `CustomersController(ICustomerService customerService)` | Servis bağımlılığını alır. |
| GetAll | `Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döndürür (`200 OK`). |
| GetById | `Task<ActionResult<CustomerDto>> GetById(Guid id)` | Id’ye göre müşteriyi döndürür; yoksa `404 NotFound`. |
| GetActive | `Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döndürür (`200 OK`). |
| Create | `Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Yeni müşteri oluşturur; `201 Created` ve `Location` header ile döner. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Müşteriyi günceller; başarıda `204 NoContent`, bulunamazsa `404 NotFound`. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` bulunamayan kayıt için `NotFound` döner.
- `Create` başarılı oluşturma sonrası `CreatedAtAction(nameof(GetById))` ile konum başlığı üretir.
- `Update` işlemi `KeyNotFoundException` fırlatıldığında `NotFound`’a çevrilir.
- `Delete` hata çevirimi yapmaz; servis katmanından dönebilecek “bulunamadı” gibi durumlar HTTP koda çevrilmemiş.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (ör. frontend, Postman).
- Aşağı akış: `ICustomerService`.
- İlişkili tipler: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`.

**7. Eksikler ve Gözlemler**
- `Delete` için bulunamayan kayıt senaryosunda `404` dönüşü uygulanmamış; hata yönetimi `Update` ile tutarsız.
- Yetkilendirme/kimlik doğrulama öznitelikleri görünmüyor; güvenlik gereksinimleri bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Sunum katmanı ile Application sözleşmeleri arasında net ayrım var; iyi bir katmanlaştırma sinyali.
- Hata çeviriminde tutarlılık geliştirilebilir (özellikle `Delete` için).
- Versiyonlama, doğrulama öznitelikleri ve yetkilendirme stratejisi görünmüyor; proje genelinde netlik sağlanmalı.### Project Overview
Bu depo, `Library` adında bir ASP.NET Core Web API projesini gösteriyor. Amaç, kütüphane personeline (staff) yönelik CRUD ve listeleme uç noktaları sunmaktır. Hedef çatı, görünen koddan ASP.NET Core (muhtemelen .NET 6/7+) Web API’dir. Mimari, sunum (API) katmanının Application katmanına bağımlı olduğu N-Tier/Clean Architecture benzeri bir düzeni işaret eder.

- Mimari Katmanlar:
  - Presentation (API): `Library` projesi; HTTP endpoint’leri.
  - Application: `Library.Application`; `DTO` ve `IStaffService` gibi kontratlar ve iş mantığı.
- Projeler/Assembly’ler:
  - `Library` — API/Presentation.
  - `Library.Application` — Application kontratları ve DTO’lar.
- Kullanılan dış paket/çerçeveler:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`).
- Konfigürasyon:
  - Bu dosyadan bağlantı dizgileri veya app settings anahtarları anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Services, DTOs)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel (staff) varlığı için CRUD ve sorgulama uç noktalarını sağlayan ASP.NET Core API denetleyicisidir. Presentation katmanında yer alır ve iş mantığını `IStaffService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- Tip: class
- Miras: `ControllerBase`
- Uygular: Yok
- Namespace: `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel verileri üzerinde CRUD ve sorgulama operasyonlarını gerçekleştiren uygulama servisi.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffController(IStaffService staffService)` | Servis bağımlılığını DI ile alır. |
| GetAll | `public Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personeli döner. |
| GetById | `public Task<ActionResult<StaffDto>> GetById(Guid id)` | ID ile personeli getirir; yoksa `NotFound`. |
| GetActive | `public Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döner. |
| Create | `public Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Personel oluşturur; `CreatedAtAction` ile döner. |
| Update | `public Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personel günceller; yoksa `NotFound`, başarılıysa `NoContent`. |
| Delete | `public Task<IActionResult> Delete(Guid id)` | Personeli siler; `NoContent` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` için null sonuçta `404 NotFound`.
- `Create` başarılı olursa `201 Created` ve `Location` başlığı `GetById`’a işaret eder.
- `Update` sırasında `KeyNotFoundException` yakalanır ve `404 NotFound` döner; aksi halde `204 NoContent`.
- `Delete` her zaman `204 NoContent` döner; bulunamama durumu bu dosyada ele alınmıyor.
- `GetActive` aktif kayıtları döndürür; aktiflik kriteri Application katmanında belirlenir.

**6. Bağlantılar**
- Yukarı akış: HTTP istemcileri (API tüketicileri).
- Aşağı akış: `IStaffService`.
- İlişkili tipler: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`.

**7. Eksikler ve Gözlemler**
- Güvenlik: `[Authorize]` niteliği yok; korumalı uç noktalar ise yetkilendirme eksik olabilir.
- Hata yönetimi: `Delete` için bulunamama durumu özel olarak ele alınmıyor; servis `KeyNotFoundException` atarsa tutarlı bir 404 dönmek için try-catch düşünülebilir.
- Girdi doğrulama: DTO seviyesinde `ModelState`/data annotation kontrolü bu dosyada görünmüyor; FluentValidation vb. yoksa eksik olabilir.

---
### Genel Değerlendirme
Kod, API katmanının Application’a bağımlı olduğu net bir katmanlı mimariyi işaret ediyor. Controller düzeyinde temel REST yanıtları tutarlı. Yetkilendirme nitelikleri ve hata yönetimi (özellikle `Delete`) iyileştirilebilir. Konfigürasyon, veri erişim ve altyapı detayları bu dosyadan görülemiyor; proje genelinde Clean Architecture hedefleniyorsa Infrastructure ve Domain katmanlarının varlığı/ayrımı doğrulanmalıdır. DTO doğrulaması için tutarlı bir strateji (data annotations veya FluentValidation) önerilir.### Project Overview
- Proje Adı ve Amaç: Library — ASP.NET Core Web API giriş noktası; uygulama ve altyapı katmanlarını başlatır ve HTTP pipeline’ı yapılandırır.
- Hedef Framework: .NET 6+ minimal hosting modeli (tam sürüm bu dosyadan anlaşılmıyor).
- Mimari Desen: Clean Architecture
  - Presentation/API: `Library` (bu proje) — HTTP endpoint’leri, middleware ve DI kompozisyonu.
  - Application: `Library.Application` — uygulama iş kuralları ve servis kayıtları (detaylar bu dosyadan görünmüyor).
  - Infrastructure: `Library.Infrastructure` — dış kaynak/altyapı entegrasyonları ve konfigürasyonla kayıt (detaylar bu dosyadan görünmüyor).
- Projeler/Assembly’ler:
  - Library (API/Presentation)
  - Library.Application (Application)
  - Library.Infrastructure (Infrastructure)
- Dış Bağımlılıklar:
  - Swagger/OpenAPI: `AddEndpointsApiExplorer`, `AddSwaggerGen`
- Konfigürasyon Gereksinimleri:
  - `AddInfrastructure(builder.Configuration)` üzerinden altyapı yapılandırması bekleniyor; gerekli anahtar/connection string’ler bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  -> Library.Application (Application)
     <- Library.Infrastructure (Infrastructure registered via API)

API depends on Application and Infrastructure for DI registration; Infrastructure likely references Application for implementations.

---
### `Library/Program.cs`

**1. Genel Bakış**
API giriş noktası ve host yapılandırmasıdır. DI konteynerine Application ve Infrastructure katmanlarını ekler, controller’ları ve Swagger/OpenAPI’yi kurar, HTTP middleware hattını (HTTPS, Swagger UI dev’de, Authorization) yapılandırır. Clean Architecture’ın Presentation katmanına aittir.

**2. Tip Bilgisi**
- Tip: top-level statements (program giriş noktası)
- Miras: Yok
- Uygular: Yok
- Namespace: Bu dosyadan anlaşılmıyor (global usings/top-level).

**3. Bağımlılıklar**
- `Library.Application` — Uygulama servis kayıtlarını ekler (`AddApplication()`).
- `Library.Infrastructure` — Altyapı servislerini konfigürasyonla ekler (`AddInfrastructure(IConfiguration)`).
- `Controllers` — MVC Controller desteği.
- `Swagger/OpenAPI` — API keşfi ve dokümantasyon.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Yok | Yok | Top-level giriş noktası; dışa açık üye tanımlı değil. |

**5. Temel Davranışlar ve İş Kuralları**
- Geliştirme ortamında Swagger ve SwaggerUI etkinleştirilir.
- `UseHttpsRedirection()` ile HTTP’den HTTPS’e yönlendirme yapılır.
- `UseAuthorization()` eklenmiştir; yetkilendirme politikaları bu dosyadan görülmüyor.
- `MapControllers()` ile attribute-based routing etkinleştirilir.
- `AddInfrastructure(builder.Configuration)` çağrısı, konfigürasyona bağlı kayıtlar gerektirir (örn. connection string); ayrıntılar görünmüyor.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; HTTP pipeline tarafından tetiklenir.
- Aşağı akış: `Library.Application`, `Library.Infrastructure`, MVC, Swagger.
- İlişkili tipler: `AddApplication()`, `AddInfrastructure(IConfiguration)` extension metodları (ilgili assembly’lerde).

**7. Eksikler ve Gözlemler**
- Yetkilendirme middleware’i var ancak authentication middleware’i (`UseAuthentication()`) yok; kimlik doğrulama gerekiyorsa eksik olabilir.
- Production ortamında Swagger kapalı; bu beklenen olabilir, ancak dokümantasyona erişim ihtiyacına göre gözden geçirilmeli.

---
Genel Değerlendirme
- Clean Architecture katmanları belirgin: API/Application/Infrastructure. Ancak yalnızca giriş noktası görülebildiğinden iş kuralları ve altyapı ayrıntıları belirsiz.
- `UseAuthentication()` eksikliği, güvenlik gerektiren senaryolarda sorun yaratabilir.
- `AddInfrastructure(IConfiguration)` konfigürasyon bağımlılıkları net değil; örnek appsettings anahtarları belgelendirilmeli.
- Hedef .NET sürümü kod stilinden 6+; proje dosyasından doğrulanması önerilir.