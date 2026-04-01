### Project Overview
Proje Adı: Library  
Amaç: Uygulama katmanında kitap kategorileri için veri transferi sağlamak (DTO).  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari Desen: İsimlendirmeden “katmanlı/Clean Architecture” benzeri bir yapı izleniyor gibi görünüyor; bu dosya Application katmanına aittir.  
Keşfedilen Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar ve muhtemel use-case’lere hizmet eder.

Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Consumer Katmanları (ör. API/Infrastructure)] → Library.Application

---
### `Library.Application/DTOs/BookCategoryDto.cs`

**1. Genel Bakış**  
`BookCategoryDto`, kitap kategorilerine ait temel bilgileri (Id, Name, Description) katmanlar arası taşımak için kullanılan basit bir DTO’dur. Uygulama (Application) katmanına aittir ve muhtemel istek/yanıt modellerinde kullanılır.

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
| Name | `public string Name { get; set; }` | Kategori adı. Varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklaması. Varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**  
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanında bir DTO dosyası görülebiliyor; diğer katmanlar (Domain, Infrastructure, API) ve use-case/handler/controller yapıları bu dosyadan anlaşılmıyor.
- Doğrulama, eşleme (mapping) ve hata yönetimi görünür değil; muhtemelen başka katmanlarda ele alınmalıdır.### Proje Genel Bakış
- Proje adı: Library
- Amaç: Kütüphane alanına ait veri taşıma nesneleri (DTO) sağlayarak uygulama katmanındaki veri alışverişini düzenlemek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı (N-Tier) yaklaşım izleniyor gibi görünüyor; bu dosya `Application` katmanındaki DTO’yu temsil ediyor. Diğer katmanlar bu dosyadan çıkarılamıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar, muhtemel use-case/handler sözleşmeleri.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (Application)

---

### `Library.Application/DTOs/BookDto.cs`

**1. Genel Bakış**
`BookDto`, kitap verilerini uygulama katmanında taşımak için kullanılan basit bir veri aktarım nesnesidir. Sunum ve/veya servis katmanları arasında kitap bilgilerini iletmede kullanılır. Mimari olarak Application katmanına aittir.

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
| Id | `public Guid Id { get; set; }` | Kitabın benzersiz kimliği. |
| Title | `public string Title { get; set; }` | Kitabın başlığı. Varsayılanı `string.Empty`. |
| Author | `public string Author { get; set; }` | Yazar adı. Varsayılanı `string.Empty`. |
| ISBN | `public string ISBN { get; set; }` | ISBN numarası. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcudiyet durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). |
| BookCategoryName | `public string? BookCategoryName { get; set; }` | Kategori adı (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `IsAvailable = false`, `Id = default(Guid)`, `BookCategoryId = null`, `BookCategoryName = null`.

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor (muhtemelen uygulama servisleri/handler’lar ve API katmanı).
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanı yalnızca bir DTO dosyası içeriyor; mimari katmanlar, akışlar ve kurallar hakkında sınırlı çıkarım yapılabiliyor. Validasyon, mapping profilleri, entity/komut-sorgu yapıları veya kalıcı katman göstergeleri bu kapsamda görünmüyor. Daha kapsamlı değerlendirme için Application, Domain, Infrastructure ve API katmanlarından ek dosyalar gerekli.### Project Overview
- Proje adı: Library (çıkarım: `Library.Application` ad alanı ve proje yolu)
- Amaç: Kütüphane alanına yönelik uygulama katmanında kullanılan veri transfer nesneleri (DTO) sağlamak; özellikle kitap kategorisi oluşturma isteği için giriş modelini temsil etmek.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı mimari/Clean Architecture eğilimi. Bu dosya Application katmanına aittir; diğer katmanlar (Domain/Infrastructure/API) bu dosyadan anlaşılmıyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar, muhtemel komut/sorgu sözleşmeleri ve iş akışı sınırları.
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] → Library.Application

---

### `Library.Application/DTOs/CreateBookCategoryDto.cs`

**1. Genel Bakış**
`CreateBookCategoryDto`, kitap kategorisi oluşturma işlemi için gerekli temel alanları (ad ve açıklama) taşıyan bir DTO’dur. Uygulama (Application) katmanında, dış katmanlardan gelen veriyi use case/handler’lara iletmek için kullanılır.

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
| Name | `public string Name { get; set; }` | Kategori adı; varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategori açıklaması; varsayılanı `string.Empty`. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

**7. Eksikler ve Gözlemler**
- Doğrulama niteliği/kuralları (ör. zorunlu alanlar, uzunluk sınırı) tanımlı değil; doğrulama başka katmanda ele alınıyorsa sorun değil, ancak bu dosyadan anlaşılmıyor.

---

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülebiliyor; mimarinin tamamı bu dosyadan çıkarsanamıyor.
- Harici paket kullanımı ve konfigürasyon gereksinimleri görünmüyor.
- DTO üzerinde alan doğrulamaları yok; bu yaklaşım, doğrulamanın handler/validator katmanında yapılması durumunda tutarlıdır, aksi halde eksik olabilir.### Project Overview (required, once)
- Proje adı: Library (çıkarım: `Library.Application` ad alanı)
- Amaç: Kütüphane alanında kitaplarla ilgili uygulama işlemlerini destekleyen uygulama katmanı DTO’ları sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Büyük olasılıkla katmanlı mimari/Clean Architecture varyantı; görülen proje Application katmanı olup istek/cevap modelleri ve iş kurallarına yakın tipleri barındırır.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; DTO’lar, muhtemel komut/sorgu modelleri ve iş akışlarını destekleyen tipler.
- Dış bağımlılıklar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram (required, once)
Library.Application

Katmanlar arası bağımlılık akışı bu depodan çıkarılamıyor; yalnızca `Library.Application` görülebiliyor.

---
### `Library.Application/DTOs/CreateBookDto.cs`

**1. Genel Bakış**
`CreateBookDto`, yeni bir kitabın oluşturulması için gerekli alanları taşıyan basit bir veri transfer nesnesidir. Uygulama (Application) katmanında, kitap oluşturma iş akışına giriş modeli olarak konumlanır.

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
| `Title` | `public string Title { get; set; }` | Kitap başlığı. |
| `Author` | `public string Author { get; set; }` | Yazar adı. |
| `ISBN` | `public string ISBN { get; set; }` | ISBN numarası. |
| `PublishedYear` | `public int PublishedYear { get; set; }` | Yayın yılı. |
| `BookCategoryId` | `public Guid? BookCategoryId { get; set; }` | İsteğe bağlı kategori kimliği. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanından bir DTO görülüyor; domain, infrastructure veya API katmanlarına dair kanıt yok.
- Validasyon, mapping veya iş kurallarına dair herhangi bir gösterge bulunmuyor; muhtemelen ayrı katmanlarda/handler’larda ele alınmalı.
- Hedef framework, paket bağımlılıkları ve konfigürasyon anahtarları bu içerikten çıkarılamıyor.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alanına yönelik uygulama katmanında kullanılan veri aktarım nesnelerini (DTO) tanımlamak.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari Desen: Katmanlı mimari (N-Tier/Clean benzeri). `Application` katmanında DTO tanımı yer alıyor; muhtemel diğer katmanlar (Domain, Infrastructure, API) bu dosyadan görünmüyor.  
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; komut/sorgu akışlarında kullanılacak DTO’lar içerir.
Dış Bağımlılıklar: Bu dosyadan anlaşılmıyor (harici paket referansı görülmüyor).  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (DTO’lar)
  ↑
(Çağıran katmanlar bu dosyadan anlaşılmıyor; tipik olarak API veya Application içindeki handler’lar)

---
### `Library.Application/DTOs/CreateCustomerDto.cs`

**1. Genel Bakış**  
`CreateCustomerDto`, müşteri oluşturma işlemleri için gerekli giriş verilerini (ad, soyad, e-posta, telefon, adres) taşıyan bir DTO’dur. Uygulama (Application) katmanına aittir ve dış katmanlar ile domain arasındaki veri sözleşmesini sadeleştirir.

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
DTO — davranış yok. Default değerler: tüm `string` property’ler `string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanından bir DTO görülüyor; mimari katmanlar, iş kuralları, validasyon ve kalıcılık ayrıntıları bu veriyle tespit edilemiyor.
- DTO üzerinde doğrulama (ör. e-posta formatı, zorunlu alanlar) kod seviyesinde bulunmuyor; muhtemelen başka katmanlarda ele alınmalı.### Project Overview
Bu depo, `Library.Application` ad alanı altında kütüphane alanına yönelik uygulama katmanı tiplerini içeriyor. Mevcut koddaki tek tip bir oluşturma DTO’sudur ve tipik olarak istek/cevap modellemesi ve use case’ler arasında veri taşıma amacıyla kullanılır. Hedef framework, proje dosyası gösterilmediği için bu dosyadan anlaşılmıyor. Mimari yaklaşım, ad alanı ve klasörleme itibarıyla katmanlı/temiz mimariye işaret eder; ancak diğer katmanlar bu depoda görünmüyor.

- Mimari katmanlar (gözlemlenen): Application — Use case’ler ve DTO’lar; UI/Infrastructure bağımlılığı içermez.
- Keşfedilen projeler/assembly’ler: Library.Application — Uygulama katmanı veri sözleşmeleri (DTO).
- Harici paket/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Textual bağımlılık akışı (gözlemlenene dayalı):

[Presentation/API] → Library.Application

Diğer katmanlar (Domain/Infrastructure) bu dosyadan anlaşılmıyor.

---

### `Library.Application/DTOs/CreateStaffDto.cs`

**1. Genel Bakış**
`CreateStaffDto`, personel oluşturma senaryosunda gerekli alanları taşıyan bir veri aktarım nesnesidir. Uygulama (Application) katmanına aittir ve genellikle API istek gövdelerinden veya komut nesnelerine mapping amacıyla kullanılır.

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
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName`, `LastName`, `Email`, `Phone`, `Position` için `string.Empty`. `HireDate` için `default(DateTime)`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
- Sadece Application katmanında bir DTO görülüyor; diğer katmanlar (Domain, Infrastructure, API) bu depoda/çıktıda yer almıyor.
- Validasyon, mapping profilleri veya handler/servis kullanımları görünmediği için uçtan uca akış belirsiz.
- Null güvenliği için string alanlarda `string.Empty` varsayılanı tutarlı; tarih alanı için iş kuralları (örn. geçmiş tarih zorunluluğu) belirtilmemiş.### Project Overview
Proje adı, Library.Application ad alanından hareketle “Library” olarak görünüyor. Bu dosya, Application katmanında yer alan bir DTO tanımı içerir. Amaç, müşteri bilgilerini katmanlar arasında taşımaktır. Hedef framework, çalışma zamanı yapılandırmaları ve yürütme modeli bu dosyadan anlaşılmıyor. Mimari olarak en azından bir Application katmanının bulunduğu ve burada DTO’ların tanımlandığı görülüyor; diğer katmanlar (Domain, Infrastructure, API) bu dosyadan çıkarılamıyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanına ait DTO tanımları.

Kullanılan dış paketler/çatı: Bu dosyada görünmüyor.

Yapılandırma gereksinimleri (connection string, app settings): Bu dosyada görünmüyor.

### Architecture Diagram
[Library.Application] (DTO’lar)
(başka bağımlılık akışları bu dosyadan anlaşılmıyor)

---
### `Library.Application/DTOs/CustomerDto.cs`

**1. Genel Bakış**
`CustomerDto`, müşteri verilerini katmanlar arasında taşımak için kullanılan basit bir veri transfer nesnesidir. Application katmanında yer alır ve muhtemelen okuma/yazma işlemlerinde API veya servisler ile veri alışverişini kolaylaştırır.

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
| Address | `public string Address { get; set; }` | Müşterinin adresi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Üyeliğin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `MembershipNumber = string.Empty`. `RegisteredDate` varsayılanı `default(DateTime)`. `IsActive` varsayılanı `false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülüyor; diğer katmanlar ve akışlar bu veriyle belirlenemiyor.
- Validasyon, mapping profilleri (ör. AutoMapper) veya kullanım bağlamı görünmediğinden, veri bütünlüğü ve dönüştürme sorumluluklarının nerede ele alındığı belirsiz.
- `RegisteredDate` ve `IsActive` için iş kuralları (ör. otomatik atama, varsayılan etkinlik) net değil; bu değerlerin nerede yönetildiği belirtilmeli.### Proje Genel Bakış
- Proje Adı: Library
- Amaç: Uygulamanın katmanları arasında veri aktarımı için DTO’lar sağlayan bir uygulama katmanı bileşeni.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari Desen: Katmanlı yapı (Application katmanı görünür). Application katmanı, alan modelleri ve/veya dış katmanlar (API/Infrastructure) arasındaki veri sözleşmelerini taşımayı amaçlar.
- Keşfedilen Proje/Assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar içerir.
- Kullanılan Dış Paketler/Çatılar: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Mimari Diyagram
Library.Application (Application Katmanı)

---

### `Library.Application/DTOs/StaffDto.cs`

**1. Genel Bakış**
`StaffDto`, personel bilgilerini üst katmanlar arasında taşımak için kullanılan bir veri aktarım nesnesidir. Application katmanında yer alır ve muhtemelen API istek/yanıtlarında veya servis sonuçlarında kullanılır.

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
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `Id = Guid.Empty` (atanmadıysa), `HireDate = default(DateTime)` (atanmadıysa), `IsActive = false` (atanmadıysa).

**6. Bağlantılar**
- Yukarı akış: Bu dosyadan anlaşılmıyor.
- Aşağı akış: Harici bağımlılık yok.
- İlişkili tipler: Bu dosyadan anlaşılmıyor.

---

### Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir DTO dosyasını içeriyor. Mimari, katmanlı bir düzeni ima ediyor ancak Domain/Infrastructure/API katmanlarına dair kanıt yok. Validasyon, mapping profilleri (ör. AutoMapper), veya kullanım bağlamı görünmüyor; bu nedenle veri bütünlüğü ve dönüştürme mantıkları başka yerde ele alınıyor olmalı. DTO’larda null güvenliği için `string.Empty` başlangıçları tutarlı.### Project Overview
Proje adı: Library (isim, namespace’ten çıkarılmıştır). Amaç: Uygulama katmanında kitap kategorisi güncelleme işlemleri için veri taşıma nesneleri (DTO) sağlamak. Hedef çerçeve: Bu dosyadan anlaşılmıyor.

Mimari: Katmanlı bir yapı işaretleri var (Application katmanı). Diğer katmanlar ve kesin desen (Clean Architecture/N-Tier) bu dosyadan anlaşılmıyor.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar içerir.

Dış bağımlılıklar: Bu dosyadan anlaşılmıyor (herhangi bir paket kullanımı görünmüyor).

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarları görünmüyor).

### Architecture Diagram
[Library.Application] (DTOs)

---
### `Library.Application/DTOs/UpdateBookCategoryDto.cs`

**1. Genel Bakış**
`UpdateBookCategoryDto`, kitap kategorisi güncelleme işlemlerinde kullanılan basit bir veri taşıma nesnesidir. Application katmanına aittir ve dış katmanlar ile domain arasındaki veri alışverişini sadeleştirir.

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
| Name | `public string Name { get; set; }` | Kategori adı; varsayılanı boş stringdir. |
| Description | `public string Description { get; set; }` | Kategori açıklaması; varsayılanı boş stringdir. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanı yalnızca Application katmanındaki bir DTO’yu içerdiği için mimari, bağımlılıklar ve konfigürasyon hakkında kapsamlı çıkarım yapılamıyor. Doğrulama (ör. `Name` boş olamaz) gibi iş kuralları DTO içinde yer almıyor; bu validasyonların nerede yapıldığı bu dosyadan anlaşılmıyor. DTO’ların amaçlarına uygun olarak yalın tutulduğu görülüyor.### Project Overview
Proje Adı: Library  
Amaç: Kitaplara ait verileri taşıyan uygulama katmanı DTO’larını sağlamak (ör. güncelleme işlemleri).  
Hedef Framework: Bu dosyadan anlaşılamıyor.  
Mimari: Uygulama katmanını işaret eden bir yapı mevcut. Clean Architecture/N‑Katmanlı mimariye işaret edebilir; ancak diğer katmanlar bu dosyadan anlaşılamıyor.  
Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar içerir.

Harici Paketler/Çatılar: Bu dosyadan anlaşılamıyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
Library.Application (DTOs)

---
### `Library.Application/DTOs/UpdateBookDto.cs`

**1. Genel Bakış**  
Kitap güncelleme operasyonları için veri taşıyan bir DTO’dur. Uygulama katmanında istek/cevap modelleri arasında kullanılması amaçlanmıştır. İş mantığı içermez, yalnızca alanları taşır.

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
| ISBN | `public string ISBN { get; set; }` | Kitabın ISBN değeri. Varsayılanı `string.Empty`. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. Varsayılanı `0`. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Mevcut/ödünç verilebilirlik durumu. Varsayılanı `false`. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | Kategori kimliği (opsiyonel). Varsayılanı `null`. |

**5. Temel Davranışlar ve İş Kuralları**  
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `PublishedYear = 0`, `IsAvailable = false`, `BookCategoryId = null`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanında yalnızca Application katmanına ait bir DTO görülebiliyor; diğer katmanlar (Domain/Infrastructure/API) ve akışlar bu dosyadan tespit edilemiyor.
- Doğrulama kuralları veya sözleşmeler (ör. `ISBN` formatı, yıl aralığı) DTO içinde tanımlı değil; muhtemelen başka katmanlarda ele alınmalıdır, ancak bu dosyadan teyit edilemiyor.### Project Overview
Proje adı, `Library` ad uzayından hareketle bir kütüphane yönetimi bağlamını ima etmektedir; bu dosyadan net amaç sınırlı olarak “müşteri güncelleme işlemleri için veri taşıma”dır. Hedef framework bu dosyadan belirlenemiyor. Mimari olarak `Library.Application.DTOs` ad uzayı, katmanlı/Clean Architecture yaklaşımında Application katmanını işaret eder ve UI/API ile Domain/Service mantığı arasında veri taşıyan tipleri barındırır.

Mimari desen: Katmanlı/Clean eğilimi
- Application: DTO’lar ve muhtemel use-case odaklı sözleşmeler. Bu repo kesitinde sadece DTO görülüyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar içerir.

Harici paketler/çatı: Bu dosyadan görünmüyor.

Konfigürasyon gereksinimleri: Bu dosyada konfigürasyon kullanılmıyor; görünür gereksinim yok.

### Architecture Diagram
Library.Application (DTOs)
  ↳ (Bu dosyadan başka katman/bağımlılık akışı belirlenemiyor)

---
### `Library.Application/DTOs/UpdateCustomerDto.cs`

**1. Genel Bakış**
`UpdateCustomerDto`, müşteri güncelleme operasyonlarında istenen/alınan alanları taşımak için kullanılan basit bir veri taşıma nesnesidir. Uygulama (Application) katmanına aittir ve sunum katmanı ile iş mantığı arasında sınır veri modelini temsil eder.

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
| IsActive | `public bool IsActive { get; set; }` | Müşterinin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Address = string.Empty`, `IsActive = false`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Kod tabanından yalnızca Application katmanında bir DTO görünüyor; diğer katmanlar (Domain, Infrastructure, API) bu kesitte yer almıyor ve bağımlılık akışı doğrulanamıyor.
- Validasyon, eşleme (mapping) ve iş kuralları DTO dışında ele alınmalı; bu dosyada böyle mekanizmalar görünmüyor.
- `string.Empty` varsayılanları null referans riskini azaltır; ancak alan düzeyi validasyon anotasyonları veya sözleşmeleri yok, bu da doğrulamanın başka yerde yapıldığını/ yapılması gerektiğini gösterir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanına yönelik uygulama katmanında veri aktarım nesneleri (DTO) tanımlamak. Hedef çatı: .NET (sürüm bu dosyadan anlaşılmıyor).

Mimari desen: Katmanlı/Clean Architecture eğilimli yapı; bu depodan yalnızca Application katmanı görünüyor. Application katmanı, kullanım senaryolarına ve akışlara hizmet edecek sözleşmeler/DTO’lar sağlar. Diğer katmanlar (Domain, Infrastructure, API/Presentation) bu dosyadan anlaşılamıyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; DTO’lar içerir.

Dış bağımlılıklar: Bu dosyadan görünmüyor.

Yapılandırma gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
[Library.Application]

---

### `Library.Application/DTOs/UpdateStaffDto.cs`

**1. Genel Bakış**
`UpdateStaffDto`, personel güncelleme işlemlerinde taşınacak alanları temsil eden bir DTO’dur. Uygulama (Application) katmanında bulunur ve katmanlar arası veri aktarımını sade bir sözleşme ile sağlar.

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
| `FirstName` | `public string FirstName { get; set; }` | Personelin adı. |
| `LastName` | `public string LastName { get; set; }` | Personelin soyadı. |
| `Email` | `public string Email { get; set; }` | Personelin e-posta adresi. |
| `Phone` | `public string Phone { get; set; }` | Personelin telefon numarası. |
| `Position` | `public string Position { get; set; }` | Personelin pozisyonu/ünvanı. |
| `IsActive` | `public bool IsActive { get; set; }` | Personelin aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = false` (bool için varsayılan).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

### Genel Değerlendirme
Kod tabanında yalnızca Application katmanında bir DTO görünmektedir. İş kuralları, doğrulama, veri erişimi ve uç noktalar hakkında çıkarım yapılamıyor. Projenin tam mimari resmini doğrulamak için Domain/Infrastructure/API katmanlarının ve olası harici paketlerin incelenmesi gerekir. DTO’da veri validasyonu (örneğin e-posta formatı) uygulama seviyesi veya daha dış katmanlarda ele alınmalıdır; bu sınıfta yer almaması uygundur.### Project Overview
Proje adı: Library (katmandan çıkarım). Amaç: Uygulama katmanındaki servis sözleşmelerini ve implementasyonlarını DI konteynerine eklemek. Hedef çerçeve: Modern .NET (Microsoft.Extensions.DependencyInjection kullanıldığı için .NET Core/5+); kesin sürüm bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı (N-Tier). Bu dosya Application katmanına ait ve servis arabirimlerini uygulamalarına bağlayarak üst katmanların (örn. API) işlevleri DI üzerinden tüketmesini sağlar.

Projeler/Assembly’ler:
- Library.Application — Uygulama katmanı; servis arayüzleri ve implementasyonlarının DI kaydı.

Dış paket/çerçeveler:
- Microsoft.Extensions.DependencyInjection — DI konteyner entegrasyonu.

Konfigürasyon gereksinimleri: Bu dosyadan bir konfigürasyon anahtarı veya connection string gereksinimi anlaşılmıyor.

### Architecture Diagram
[API/Presentation] → Library.Application (Interfaces, Services, DI)
Library.Application.Services ↔ Library.Application.Interfaces

---
### `Library.Application/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, uygulama katmanı servislerini DI konteynerine eklemek için bir extension metodu sağlar. Üst katmanlar (örn. Web API) `AddApplication()` çağırarak `IBookService`, `IBookCategoryService`, `IStaffService`, `ICustomerService` eşleştirmelerini kaydeder. Mimari olarak Application katmanında konumlanır.

**2. Tip Bilgisi**
- Tip: static class
- Miras: Yok
- Uygular: Yok
- Namespace: `Library.Application`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Application servislerini scoped yaşam döngüsüyle DI konteynerine ekler ve `IServiceCollection` döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `IBookService` → `BookService`, `IBookCategoryService` → `BookCategoryService`, `IStaffService` → `StaffService`, `ICustomerService` → `CustomerService` scoped olarak kaydedilir.
- Scoped yaşam döngüsü, tipik olarak web istek başına bir örnek sağlar; farklı yaşam döngüsü tercihleri bu dosyada tanımlı değildir.
- Metot akışını zincirleme (fluent) kolaylaştırmak için `IServiceCollection` geri döndürür.

**6. Bağlantılar**
- Yukarı akış: API/Composition Root içinde `IServiceCollection` üzerinden çağrılır (ör. `builder.Services.AddApplication()`).
- Aşağı akış: `Microsoft.Extensions.DependencyInjection` API’sı; `Library.Application.Interfaces` ve `Library.Application.Services` tipleri.
- İlişkili tipler: `IBookService`, `BookService`, `IBookCategoryService`, `BookCategoryService`, `IStaffService`, `StaffService`, `ICustomerService`, `CustomerService`.

**7. Eksikler ve Gözlemler**
- Sadece belirli servisler kaydedilmiş; diğer potansiyel Application bileşenleri (örn. validator, pipeline behavior) bu dosyada yok veya kaydedilmemiş olabilir; bu durum bu dosyadan netleştirilemiyor.

Genel Değerlendirme
- Kod, Application katmanı için minimal ve net bir DI kompozisyon noktası sunuyor. Hedef framework ve diğer katmanlar bu dosyadan çıkarılamıyor. Katmanlar arası bağımlılık yönü doğru: API’nin Application’a bağımlı olması beklenir. Genişleme için modüler kayıt desenleri (ör. feature-based extension’lar) eklenebilir; ayrıca yaşam döngüsü ihtiyaçları gözden geçirilerek singleton/transient tercihleri değerlendirilebilir.### Project Overview
Proje adı “Library” olarak görünüyor. Amaç: kütüphane alanına ait uygulama katmanında kitap kategorileriyle ilgili sözleşmeleri (servis arayüzlerini) tanımlamak. Hedef çerçeve bu dosyadan anlaşılmıyor; ancak .NET modern Task tabanlı async imzalar kullanılıyor.

Mimari: Katmanlı/Clean Architecture esintili. Bu dosya `Library.Application` içinde “Application” katmanındaki bir servis sözleşmesini gösteriyor. Domain/Infrastructure/API katmanları bu dosyadan doğrulanamıyor.

Keşfedilen projeler/assembly’ler ve rolleri:
- Library.Application: Uygulama katmanı; DTO’lar ve servis arayüzleri barındırır.

Harici paketler/çatı: Bu dosyadan anlaşılmıyor.

Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Interfaces) -> Library.Application (DTOs)

---

### `Library.Application/Interfaces/IBookCategoryService.cs`

**1. Genel Bakış**
`IBookCategoryService`, kitap kategorileri için CRUD operasyonlarının sözleşmesini tanımlar. Application katmanına aittir ve üst katmanların (ör. API) kategori işlemlerini soyut bir servis üzerinden gerçekleştirmesine imkan verir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Arayüz; sadece DTO türlerine referans verir.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kategori bilgisini getirir; yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategori kayıtlarını döndürür. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşan DTO’yu döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Belirtilen `id`’li kategoriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen `id`’li kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
Sözleşme — davranış tanımlamaz. Uygulama sınıfları; varlık mevcudiyeti kontrolü, benzersizlik, doğrulama ve hata yönetimini üstlenmelidir.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar üst katmanlar (ör. API/Handlers) — bu dosyadan kesinleşmiyor.
- **Aşağı akış:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.
- **İlişkili tipler:** Aynı isimli DTO’lar (`Library.Application.DTOs` altında).

**7. Eksikler ve Gözlemler**
- Uzun süren işlemler için `CancellationToken` parametreleri yok.
- `GetAllAsync` için sayfalama/filtreleme desteği belirtilmemiş. 

---

Genel Değerlendirme
- Yalnızca Application katmanındaki bir servis arayüzü görülebiliyor; diğer katmanlar ve somut implementasyonlar bu depo kesitinde görünmüyor.
- Sözleşmede iptal belirteci ve sayfalama/filtreleme gibi ölçeklenebilirlik unsurları eksik.
- Hata sözleşmeleri (ör. bulunamadı, çakışma) ve validasyon beklentileri arayüz seviyesinde belirsiz.### Project Overview
Proje adı, ad alanlarından “Library” olarak anlaşılıyor. Amaç, bir kütüphane alanına yönelik uygulama katmanında kitap işlemleri için servis sözleşmesi tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Kod, Application katmanı altında `Interfaces` klasöründe yer alan bir servis kontratını içeriyor; bu, tipik katmanlı veya Clean Architecture düzenini işaret eder, ancak depoda yalnızca Application katmanı görülebiliyor.

Mimari desen: İsimlendirme Clean Architecture’ı çağrıştırıyor (Application katmanı ve DTO kullanımı). Görülebilen katman: Application. Diğer olası katmanlar (Domain, Infrastructure, API/Presentation) bu depodan teyit edilemiyor.

Keşfedilen projeler/assembly’ler:
- Library.Application — Uygulama katmanı; servis sözleşmeleri ve DTO’lar (ad alanlarından) içerir.

Kullanılan dış paket/çerçeveler: Bu dosyadan anlaşılmıyor.

Yapılandırma gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  └─ Interfaces
       └─ IBookService
  └─ DTOs
       └─ BookDto, CreateBookDto, UpdateBookDto

Bağımlılık akışı: Library.Application.Interfaces -> Library.Application.DTOs

---
### `Library.Application/Interfaces/IBookService.cs`

**1. Genel Bakış**
`IBookService`, kitaplara ilişkin okuma ve yazma işlemleri için uygulama katmanında bir servis sözleşmesi tanımlar. Amaç, kitap verisinin alınması, oluşturulması, güncellenmesi ve silinmesine dair asenkron operasyonları standartlaştırmaktır. Clean/Application katmanında yer alır ve üst katmanlarca (ör. API veya Use Case’ler) DI üzerinden tüketilmesi beklenir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Sadece `Library.Application.DTOs` tiplerine başvuru yapar.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için kitabı döndürür; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları döndürür. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/mevcut durumdaki kitapları döndürür. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni bir kitap oluşturur ve oluşan kitabı döndürür. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Verilen `id` kitabını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `id` kitabını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arama: `GetByIdAsync` null dönebilir; çağıran tarafın null kontrolü yapması gerekir.
- Listeleme: `GetAllAsync` ve `GetAvailableBooksAsync` sıralama/sayfalama sözleşmesi içermez; bu dosyadan böyle bir davranış anlaşılmıyor.
- Yazma işlemleri: `CreateAsync` oluşturulan kaydı döndürürken `UpdateAsync` ve `DeleteAsync` değer döndürmez; hata durumları bu arayüzden anlaşılmıyor.
- DTO — davranış yok; taşıyıcı tipler: `BookDto`, `CreateBookDto`, `UpdateBookDto` (içerikleri bu dosyadan anlaşılmıyor).

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar API Controller’ları veya Application Use Case/Handler’ları (bu dosyadan kesin değil).
- **Aşağı akış:** `Library.Application.DTOs` tiplerine bağımlı.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`.

**7. Eksikler ve Gözlemler**
- İptal desteği yok: Asenkron imzalar `CancellationToken` almıyor.
- Toplu listelemelerde sayfalama/filtreleme/sıralama sözleşmesi tanımlı değil (`GetAllAsync`).
- Güncelleme/silme operasyonları sonuç veya durum bilgisi döndürmüyor; tutarlılık açısından bir dönüş tipi veya sonuç modeli düşünülebilir.
- Hata sözleşmesi (ör. bulunamadı, doğrulama hatası) belirtimi yok; istisna türleri veya sonuç kalıpları tanımlanmamış.

### Genel Değerlendirme
Kod, Application katmanında net bir servis sözleşmesi sunuyor ve DTO tabanlı iletişimi benimsiyor. Ancak tek dosyaya dayanarak mimari bütünlük doğrulanamıyor. İyileştirme alanları: iptal belirteci desteği, listelemelerde sayfalama/sıralama sözleşmesi, yazma operasyonları için tutarlı dönüş tipleri veya sonuç modeli, hata/istisna sözleşmesinin netleştirilmesi. Dış bağımlılıklar, hedef framework ve konfigürasyon gereksinimleri bu depodan anlaşılamıyor.### Project Overview
- Proje adı: Library
- Amaç: Müşteri yönetimi için uygulama katmanında servis sözleşmeleri ve DTO’lar üzerinden CRUD ve sorgulama operasyonlarını tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture (çıkarım). Bu dosyada Application katmanında servis arayüzü ve DTO kullanımı görülüyor.
  - Domain: Bu dosyadan anlaşılmıyor (görülmedi).
  - Application: İş mantığı sözleşmeleri ve DTO’lar.
  - Infrastructure: Bu dosyadan anlaşılmıyor (görülmedi).
  - API/Presentation: Bu dosyadan anlaşılmıyor (görülmedi).
- Projeler/Assembly’ler:
  - Library.Application — Application katmanı; servis arayüzleri (`Interfaces`) ve DTO’lar (`DTOs`).
- Dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.API/Presentation (görülmedi)
  ↓
Library.Application
  ↓
Library.Infrastructure (görülmedi)
  ↓
Library.Domain (görülmedi)

---
### `Library.Application/Interfaces/ICustomerService.cs`

**1. Genel Bakış**
`ICustomerService`, müşteri varlığına yönelik CRUD ve sorgulama operasyonlarının sözleşmesini tanımlar. Application katmanına aittir ve üst katmanların (örn. API) kullanacağı servis davranışlarını arayüz üzerinden soyutlar.

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
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Belirtilen `id` için müşteriyi getirir; bulunamazsa `null`. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri döner. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif durumdaki müşterileri döner. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur ve oluşturulan müşteriyi döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Müşteriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz bir sözleşme tanımlar; doğrulama, hata yönetimi ve iş kuralları implementasyonlarda belirlenir.
- `GetByIdAsync` bulunamadığında `null` dönebileceğini ifade eder.
- `CreateAsync`, `UpdateAsync`, `DeleteAsync` operasyonlarının yan etkileri (kalıcılık, transaction) bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar API controller’ları veya Application katmanı handler’ları.
- **Aşağı akış:** Harici bağımlılık tanımlı değil; implementasyonlar veri erişimi vb. katmanlara bağlanır.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto` (`Library.Application.DTOs`).

Genel Değerlendirme
- Yalnızca Application katmanında bir servis arayüzü görülüyor; implementasyonlar, Domain ve Infrastructure katmanları bu veri kümesinde yok.
- Hedef framework, konfigürasyon anahtarları ve dış bağımlılıklar bu dosyadan çıkarılamıyor.
- Arayüz seviyesinde metin imzaları tutarlı; null-dönebilir dönüş (`CustomerDto?`) semantiği açıkça belirtilmiş.### Project Overview
- Proje adı: Library (isimlendirmeden çıkarım)
- Amaç: Kütüphane personel yönetimi için uygulama katmanında personel işlemlerine yönelik bir servis sözleşmesi tanımlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: İsimlendirme ve katman adlarından Clean Architecture/N-Tier izlenimi; bu dosyada yalnızca Application katmanı görünüyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı; servis sözleşmeleri (`Interfaces`) ve DTO referansları (`DTOs`).
- Harici paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application

---

### `Library.Application/Interfaces/IStaffService.cs`

**1. Genel Bakış**
`IStaffService`, personel (staff) varlıklarına yönelik temel CRUD ve aktif personel listeleme operasyonlarının sözleşmesini tanımlar. Uygulama katmanına aittir ve sunum/iş akışı katmanlarının, altyapı detaylarına bağlı kalmadan personel işlemlerini kullanmasını sağlar.

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
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir; bulunamazsa `null` dönebilir. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personel kayıtlarını listeler. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Yalnızca aktif statüdeki personeli listeler. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Yeni personel oluşturur ve oluşan kaydı döner. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Belirtilen personel kaydını günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Belirtilen personel kaydını siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış tanımı yok; uygulamalarında validasyon, hata yönetimi ve yetkilendirme beklenir.
- `GetByIdAsync` null dönebilecek şekilde tasarlanmıştır; bulunamama durumunu çağırana yansıtır.
- `GetActiveStaffAsync`, aktiflik durumuna göre filtreleme sözleşmesi içerir; aktiflik ölçütünün ne olduğu bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar sunum katmanı veya uygulama hizmetleri.
- **Aşağı akış:** Harici bağımlılık tanımı yok (uygulamalarında repository/DB vb. olabilir).
- **İlişkili tipler:** `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- Async imzalarda `CancellationToken` parametreleri yok; uzun sürebilecek I/O operasyonları için eklenmesi faydalı olabilir.
- Listeleme operasyonlarında sayfalama/sıralama/arama parametreleri yok; geniş veri setlerinde performans ve kullanım için düşünülmeli. 

---

Genel Değerlendirme
- Kod tabanında sadece Application katmanından bir arayüz görülüyor; diğer katmanlar (Domain, Infrastructure, API) bu dosyadan çıkarılamıyor.
- Sözleşme net ve minimal; ancak ölçeklenebilirlik için `CancellationToken` ve sayfalama/sıralama kriterleri eklenmesi önerilir.
- DTO ve validasyon kuralları bu dosyada görünmüyor; uygulamalarda tutarlı hata modeli ve validasyon stratejisi belirlenmeli.### Project Overview
- Proje adı: Library (namespace’lerden çıkarım)
- Amaç: Kitap kategorisiyle ilgili DTO-Entity dönüşümlerini sağlayan uygulama katmanı eşlemeleri.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Katmanlı/Clean Architecture benzeri yapı. Domain (çekirdek varlıklar) ve Application (DTO’lar, eşlemeler) katmanları ayrık.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama katmanı, DTO’lar ve mapping mantığı.
  - Library.Domain — Etki alanı varlıkları (ör. `BookCategory`).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor; herhangi bir NuGet paketi referansı görünmüyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor; connection string veya app settings anahtarları yok.

### Architecture Diagram
Library.Application → Library.Domain

---
### `Library.Application/Mappings/BookCategoryMappings.cs`

**1. Genel Bakış**
`BookCategory` varlığı ile ilgili DTO tipleri (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`) arasında dönüşüm sağlayan uzantı metodlarını içerir. Uygulama katmanında yer alır ve veri alışverişinde mapping sorumluluğunu merkezileştirir.

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
| ToDto | `public static BookCategoryDto ToDto(this BookCategory category)` | `BookCategory` varlığını `BookCategoryDto`’ya dönüştürür. |
| ToEntity | `public static BookCategory ToEntity(this CreateBookCategoryDto dto)` | `CreateBookCategoryDto`’dan yeni bir `BookCategory` varlığı oluşturur. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Mevcut `BookCategory` varlığını `UpdateBookCategoryDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde `Id` alanı `Guid.NewGuid()` ile otomatik üretilir.
- `ToDto` ve `UpdateEntity`, alanları doğrudan kopyalar; null/boş değer validasyonu yok.
- `UpdateEntity` yan etkili bir işlemdir; verilen `category` nesnesini yerinde günceller.

**6. Bağlantılar**
- **Yukarı akış:** Application içi servisler/handler’lar ve API katmanı bu mapping’i çağırabilir.
- **Aşağı akış:** `Library.Application.DTOs` (DTO tipleri), `Library.Domain.Entities` (`BookCategory`).
- **İlişkili tipler:** `BookCategory`, `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.

**7. Eksikler ve Gözlemler**
- Null referanslardan kaçınmak için `category` ve `dto` için guard/validasyon yok.
- `UpdateEntity` tüm alanları koşulsuz overwrite eder; kısmi güncellemeler veya değişmeyen alanların korunması desteklenmiyor. 

---
Genel Değerlendirme
- Katman ayrımı net: Application katmanı DTO ve mapping’leri barındırırken Domain varlıkları ayrı. Ancak yalnızca mapping dosyası görülebildiği için akışın geri kalanı (servisler, handler’lar, persistence) bu depodan anlaşılamıyor.
- Mapping’lerde validasyon ve null korumaları eksik; özellikle dış girdilere maruz kalan katmanlarda guard kullanımı önerilir.
- `Guid.NewGuid()` ile ID üretimi Domain tarafında veya bir factory üzerinden merkezi olarak ele alınırsa tutarlılık artar.### Project Overview
- Proje adı: Library
- Amaç: Domain `Book` varlıkları ile Application katmanındaki DTO’lar arasında dönüşüm sağlamak (mapping).
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari desen: Clean Architecture eğilimi. Application katmanı Domain’e bağımlı, DTO-Entity mapping Application’da konumlanmış.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama mantığı, DTO’lar ve mapping’ler.
  - Library.Domain — Temel iş varlıkları (`Book`, `BookCategory` vb.).
- Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] -> Library.Application -> Library.Domain

---

### `Library.Application/Mappings/BookMappings.cs`

**1. Genel Bakış**
`Book` domain varlığı ile `BookDto`, `CreateBookDto`, `UpdateBookDto` arasında dönüşüm yapan extension method’ları içerir. Clean Architecture içinde Application katmanına aittir ve veri aktarımını basitleştirir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygular:** Yok
- **Namespace:** `Library.Application.Mappings`

**3. Bağımlılıklar**
Harici bağımlılık yok. (Yalnızca `Library.Application.DTOs` ve `Library.Domain.Entities` tiplerini kullanır.)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| ToDto | `public static BookDto ToDto(this Book book)` | `Book` varlığını `BookDto`'ya map eder; kategori adını varsa doldurur. |
| ToEntity | `public static Book ToEntity(this CreateBookDto dto)` | `CreateBookDto`’dan yeni `Book` oluşturur; `Id`’yi `Guid.NewGuid()` ile üretir, `IsAvailable = true` atar. |
| UpdateEntity | `public static void UpdateEntity(this UpdateBookDto dto, Book book)` | Var olan `Book` alanlarını `UpdateBookDto` değerleriyle günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: Yeni `Book.Id` otomatik `Guid.NewGuid()` ile üretilir.
- `ToEntity`: `IsAvailable` varsayılan olarak `true` atanır (yaratma senaryosunda kitap mevcut kabul edilir).
- `ToDto`: `BookCategoryName`, `BookCategory` null ise null kalır.
- `UpdateEntity`: Hedef `Book` nesnesini yerinde (in-place) günceller; geri dönüş değeri yoktur.
- Null kontrolleri veya validasyon yok; geçersiz/null girişler için koruma bu dosyadan sağlanmıyor.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor (genellikle Application servisleri/handler’ları çağırır).
- **Aşağı akış:** `Library.Domain.Entities.Book`, `Library.Application.DTOs.BookDto`, `CreateBookDto`, `UpdateBookDto`
- **İlişkili tipler:** `Book`, `BookCategory` (kategori adı için), ilgili DTO’lar.

**7. Eksikler ve Gözlemler**
- Null güvenliği yok: `book` veya `dto` null ise `NullReferenceException` olası.
- `Id`’nin uygulama katmanında üretilmesi, kalıcılık katmanında alternatif kimlik üretim stratejileriyle çakışabilir; tasarım kararının tutarlılığı önemli.
- Validasyon yok: `ISBN`, `Title`, `Author` gibi alanlar için format/boşluk kontrolleri yapılmıyor.

---

### Genel Değerlendirme
- Application katmanı Domain’e bağımlı; Clean Architecture ilkeleriyle uyumlu görünüyor.
- Mapping’lerde null/validasyon kontrolleri bulunmuyor; sağlamlık için guard’lar veya FluentValidation gibi bir yaklaşım düşünülebilir.
- Kimlik üretimi Application’da yapılıyor; persistence stratejisiyle tutarlılık kontrolü önerilir.
- Dış bağımlılıklar, konfigürasyonlar ve diğer katmanlar bu girdiyle görülemiyor; bütünsel değerlendirme için ek dosyalar gerekir.### Project Overview
- Proje Adı: Library
- Amaç: Kütüphane alanındaki müşteri bilgilerinin Application katmanında DTO–Entity dönüşümlerini gerçekleştirmek.
- Hedef Framework: Bu dosyadan anlaşılmıyor.
- Mimari: Katmanlı mimari (en azından Domain ve Application katmanları gözüküyor).
  - Domain: `Library.Domain.Entities` içinde çekirdek varlıklar (ör. `Customer`).
  - Application: `Library.Application.DTOs` ve `Library.Application.Mappings` ile DTO’lar ve mapping mantığı.
- Projeler/Assembly’ler:
  - Library.Domain — Domain varlıkları (ör. `Customer`)
  - Library.Application — DTO’lar ve mapping yardımcıları
- Kullanılan Dış Paketler: Bu dosyadan anlaşılmıyor.
- Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/CustomerMappings.cs`

**1. Genel Bakış**
`Customer` varlığı ile `CustomerDto`/`CreateCustomerDto`/`UpdateCustomerDto` arasında dönüşüm sağlayan extension metotlarını içerir. Application katmanında DTO–Entity mapping sorumluluğunu üstlenir.

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
| Sınıf | `public static class CustomerMappings` | Mapping için extension metotlarını barındırır. |
| Metot | `public static CustomerDto ToDto(this Customer customer)` | `Customer` varlığını `CustomerDto`’ya projekte eder. |
| Metot | `public static Customer ToEntity(this CreateCustomerDto dto)` | `CreateCustomerDto`’dan yeni bir `Customer` varlığı oluşturur. |
| Metot | `public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Var olan `Customer` üzerinde güncelleme uygular. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity` içinde:
  - `Id` otomatik `Guid.NewGuid()` ile üretilir.
  - `MembershipNumber` `Guid`’dan türetilen 10 karakterlik büyük harfli dize ile atanır (`ToString("N")[..10].ToUpper()`).
  - `RegisteredDate` `DateTime.UtcNow` ile atanır.
  - `IsActive` varsayılan olarak `true` yapılır.
- `UpdateEntity` yan etki olarak parametre verilen `Customer` nesnesini yerinde (in-place) günceller.
- Null kontrolleri yok; parametreler `null` ise çalışma zamanında `NullReferenceException` oluşabilir.
- `ToDto` sadece alan kopyalaması yapar, ek iş kuralı içermez.

**6. Bağlantılar**
- **Yukarı akış:** Çağıranlar bu dosyadan anlaşılmıyor (muhtemelen Application servisleri/handler’ları veya API katmanı).
- **Aşağı akış:** `Library.Domain.Entities.Customer`
- **İlişkili tipler:** `Customer`, `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`

**7. Eksikler ve Gözlemler**
- Parametre null kontrolleri eksik; extension metotlar `null` girdi ile hata fırlatabilir.
- `MembershipNumber` benzersizlik kontrolü yapılmıyor; olası çakışmalar dış katmanda ele alınmalı.

---

### Genel Değerlendirme
- Mimari olarak Application → Domain bağımlılığı net; ancak Infrastructure/API katmanları bu repo kesitinde görünmüyor.
- Mapping mantığı sade ve anlaşılır; fakat girdi validasyonları ve benzersizlik kontrolleri Application seviyesinde ele alınmamış.
- Zaman damgası için UTC kullanımı tutarlı; yine de zaman sağlayıcısı soyutlaması (örn. `IDateTimeProvider`) test edilebilirlik için düşünülebilir.### Project Overview
Proje adı, amaç ve hedef çerçeve: Kod parçası “Library” isimli bir çözümde “Application” ve “Domain” katmanlarını işaret ediyor. Amaç, `Staff` varlığını DTO’lara dönüştürmek ve tersine haritalamak. Hedef framework bu dosyadan anlaşılmıyor.

Mimari desen: Clean Architecture (çıkarım). “Domain” katmanı kalıcı iş kurallarını/varlıkları barındırır; “Application” katmanı DTO’lar, mapping ve iş akışlarını barındırır. Application, Domain’e bağımlıdır.

Projeler/Assembly’ler ve rolleri:
- Library.Domain — Varlıklar (`Staff`) ve alan modeli.
- Library.Application — DTO’lar ve mapping’ler (`StaffMappings`).

Kullanılan dış paketler/çerçeveler: Bu dosyadan görünmüyor.

Konfigürasyon gerekleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application → Library.Domain

---

### `Library.Application/Mappings/StaffMappings.cs`

**1. Genel Bakış**
`Staff` varlığı ile ilgili DTO’lar (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`) arasında iki yönlü dönüşüm sağlayan extension method’ları içerir. Clean Architecture’da Application katmanına aittir ve entity-DTO ayrımını koruyarak veri taşımayı kolaylaştırır.

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
| ToDto | `public static StaffDto ToDto(this Staff staff)` | `Staff` varlığını alan `StaffDto` örneği üretir. |
| ToEntity | `public static Staff ToEntity(this CreateStaffDto dto)` | `CreateStaffDto`’dan yeni `Staff` varlığı oluşturur; `Id` ve `IsActive`’i set eder. |
| UpdateEntity | `public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Var olan `Staff` varlığını `UpdateStaffDto` alanlarıyla günceller. |

**5. Temel Davranışlar ve İş Kuralları**
- `ToEntity`: `Id` için `Guid.NewGuid()` üretir; `IsActive` değeri varsayılan olarak `true` atanır.
- `ToDto`: Tüm temel alanları birebir map eder; hesaplamalı alan yoktur.
- `UpdateEntity`: `HireDate` ve `Id` değişmez; kimlik ve işe alım tarihi korunur.
- Null kontrolü/validasyon yok; `staff` veya `dto` null ise çağıran tarafta `NullReferenceException` riski vardır.
- Email/telefon format validasyonu yapılmaz; sadece atama yapılır.

**6. Bağlantılar**
- Yukarı akış: Genellikle Application katmanındaki service/handler/controller mantıkları tarafından çağrılır (spesifik çağırıcılar bu dosyadan anlaşılmıyor).
- Aşağı akış: `Library.Domain.Entities.Staff`, `Library.Application.DTOs.StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.
- İlişkili tipler: `Staff`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- Null guard ve temel input validasyonları (ör. boş `FirstName/Email`) yok; çağıranlar tarafından sağlanması gerekir.
- `UpdateEntity` işe alım tarihini güncellemez; bu bilinçli olabilir ancak ihtiyaca göre netleştirilmeli.

---

### Genel Değerlendirme
Kod, Application ve Domain arasında temiz bir ayrım yaparak basit ve anlaşılır mapping sağlar. Görünürde sadece mapping katmanı mevcut; servis/handler/infra katmanları bu girdiyle tespit edilemiyor. Validasyon ve null kontrollerinin mapping yerine üst katmanlarda ele alınması beklenir; mevcut haliyle null referans riski bulunur. Dış bağımlılık ve konfigürasyon gereksinimi görünmüyor. Naming ve alan eşlemeleri tutarlı; oluşturma sırasında `Id` üretimi ve `IsActive = true` varsayılanı net olarak tanımlanmış.### Project Overview
Proje Adı: Library  
Amaç: Kitap kategorileri için uygulama katmanında iş mantığını sağlayan servisler; domain arayüzlerine dayanarak CRUD operasyonlarını yürütür ve DTO/Entity dönüşümleri yapar.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari Örüntü: Clean Architecture benzeri katmanlı yaklaşım. Application katmanı domain arayüzlerine bağımlı, DTO ve mapping ile sınırlandırılmış; veri erişimi Domain arayüzleri üzerinden soyutlanmış.

Projeler/Assembly’ler:
- Library.Application — Uygulama hizmetleri, DTO’lar ve mapping uzantıları.
- Library.Domain — Repository arayüzleri ve domain model sözleşmeleri.

Kullanılan Dış Paketler/Framework’ler: Bu dosyadan anlaşılmıyor.  
Yapılandırma Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application
  ↳ uses DTOs and Mappings (Library.Application.DTOs, Library.Application.Mappings)
  ↳ depends on Library.Domain.Interfaces (IBookCategoryRepository)

---

### `Library.Application/Services/BookCategoryService.cs`

**1. Genel Bakış**  
`BookCategoryService`, kitap kategorileri için CRUD odaklı uygulama hizmetidir; DTO <-> Entity dönüşümleri ile `IBookCategoryRepository` üzerinden veri işlemlerini yürütür. Clean Architecture içinde Application katmanında konumlanır ve domain arayüzlerine bağımlıdır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookCategoryRepository` — Kategori varlıkları için veri erişim operasyonlarını soyutlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `public BookCategoryService(IBookCategoryRepository categoryRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Verilen `id` ile kategoriyi getirir; yoksa `null` döner. |
| GetAllAsync | `public Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Tüm kategorileri DTO listesi olarak döner. |
| CreateAsync | `public Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Yeni kategori oluşturur ve oluşturulan DTO’yu döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Var olan kategoriyi günceller; bulunamazsa istisna fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Verilen `id`’deki kategoriyi siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `CreateAsync`: `CreateBookCategoryDto` üzerinden `ToEntity()` ile entity oluşturur; ekledikten sonra `ToDto()` döner.
- `UpdateAsync`: `GetByIdAsync` sonucu `null` ise `KeyNotFoundException` fırlatır; `UpdateEntity()` ile alanları günceller.
- `GetByIdAsync`/`GetAllAsync`: `ToDto()` mapping uzantılarını kullanır.
- `DeleteAsync`: Varlığın mevcut olup olmadığını kontrol etmeden silme çağrısı yapar.
- Tüm işlemler asenkron; `CancellationToken` kullanılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemel çağırıcılar `IBookCategoryService`’i kullanan controller’lar veya application katmanı orchestrator’ları.
- **Aşağı akış:** `IBookCategoryRepository`; `Library.Application.Mappings` içindeki `ToDto`, `ToEntity`, `UpdateEntity`.
- **İlişkili tipler:** `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`, `IBookCategoryService`, `IBookCategoryRepository`.

**7. Eksikler ve Gözlemler**
- `DeleteAsync` varlık yoksa davranış belirsiz; repository uygulamasına bırakılmış. Net hata yönetimi eklenebilir.
- Girdi validasyonu (ör. boş/ad geçersiz) görülmüyor; `Create`/`Update` için kontrol eklenmesi gerekebilir.
- `CancellationToken` desteği yok; uzun süren işlemlerde iptal kabiliyeti eklenebilir.

---

Genel Değerlendirme
- Uygulama katmanı domain’e doğru bağımlı; mapping uzantılarıyla DTO/Entity ayrımı net.  
- Hata yönetimi seçici: Sadece `UpdateAsync` bulunamayan kayıt için istisna fırlatıyor; `DeleteAsync` ve `GetByIdAsync` için tutarlı bir strateji belirlenebilir.  
- Girdi validasyonu ve `CancellationToken` desteği eklenirse dayanıklılık artar.  
- Çapraz kesen konular (logging, authorization, transaction kapsamı) bu dosyadan görülemiyor; proje genelinde standardize edilmeli.### Project Overview
- Proje adı: Library (isimlendirmeden çıkarım)
- Amaç: Kitap yönetimi için uygulama servis katmanı; kitap CRUD ve durum sorgulamalarını sağlar.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture/N‑Katmanlı yaklaşım. Application katmanı (`Library.Application`) iş akışını ve DTO/Mapping’i içerir; Domain katmanı (`Library.Domain`) repository kontratlarını barındırır. Infrastructure ve API katmanları bu dosyadan anlaşılmıyor ancak repository implementasyonlarının Infrastructure’da olması beklenir.
- Keşfedilen projeler/assembly’ler:
  - Library.Application — Uygulama servisleri, DTO’lar ve mapping uzantıları.
  - Library.Domain — Repository arayüzleri.
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Presentation/API] -> Library.Application (Services, DTOs, Mappings) -> Library.Domain (Interfaces)  
Infrastructure (Repositories) -> implements Library.Domain.Interfaces  
Data Store <- Infrastructure

---
### `Library.Application/Services/BookService.cs`

**1. Genel Bakış**
`BookService`, kitaplara yönelik uygulama servisidir; kitap sorgulama, oluşturma, güncelleme ve silme işlemlerini yönetir. Application katmanında yer alır ve `IBookRepository` üzerinden Domain’e erişir; DTO-Entity dönüşümleri `Mappings` uzantılarıyla yapılır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IBookRepository` — Kitap veri erişim işlemlerini soyutlayan repository arayüzü.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookService(IBookRepository bookRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<BookDto?> GetByIdAsync(Guid id)` | Id’ye göre kitabı getirir ve `BookDto`ya map eder. |
| GetAllAsync | `public Task<IEnumerable<BookDto>> GetAllAsync()` | Tüm kitapları getirir ve `BookDto` listesine map eder. |
| GetAvailableBooksAsync | `public Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Uygun/erişilebilir kitapları listeler ve map eder. |
| CreateAsync | `public Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Yeni kitap oluşturur (DTO’dan entity’e map) ve oluşturulanı `BookDto` olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Var olan kitabı id ile bulur, DTO’dan entity’e alan güncellemelerini uygular ve kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kitabı id’ye göre siler. |

**5. Temel Davranışlar ve İş Kuralları**
- `UpdateAsync` içinde kitap bulunamazsa `KeyNotFoundException` fırlatılır.
- Mapping: `CreateBookDto.ToEntity()`, `UpdateBookDto.UpdateEntity(entity)`, `entity.ToDto()` uzantıları kullanılır; mapping detayları bu dosyada yok.
- Filtreleme: `GetAvailableBooksAsync` uygunluk filtrelemesini repository seviyesine deleg eder.
- `CreateAsync` sonrası dönen DTO, eklenen entity’nin anlık durumunu yansıtır; kimlik üretimi/varsayılanlar bu dosyadan anlaşılmıyor.
- Girdi validasyonu (ör. null/boş alan kontrolleri) servis katmanında yapılmıyor; varsa DTO veya alttaki katmanlara bırakılmış.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; tipik olarak API Controller’lar veya Application orchestrator’ları `IBookService`’i çağırır.
- **Aşağı akış:** `IBookRepository`; mapping uzantıları (`Library.Application.Mappings`).
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookRepository` (ve olası `Book` entity’si).

**7. Eksikler ve Gözlemler**
- `DeleteAsync` için bulunamayan id senaryosunda davranış belirsiz; repository implementasyonuna bağımlı.
- Girdi validasyonu servis düzeyinde yok; hatalı/veri bütünlüğü bozuk isteklerin DTO seviyesinde veya repository/domain kurallarıyla yönetilmesi gerekir.

---
Genel Değerlendirme
- Katman ayrımı temiz: Application, Domain arayüzlerine bağımlı ve mapping uzantılarıyla sınırları koruyor.
- Transaction, logging, caching, yetkilendirme gibi enine kesen kaygılar görünür değil; ihtiyaç varsa eklenmeli.
- Validasyon stratejisi net değil; Application seviyesinde FluentValidation benzeri bir yaklaşım veya Domain kurallarıyla tutarlılık önerilir.
- Hata yönetimi bazı akışlarda (özellikle silme) repository’ye bırakılmış; sözleşme düzeyinde beklenen davranışlar (bulunamadı, concurrency) netleştirilmeli.### Project Overview
Proje Adı: Library  
Amaç: Müşteri varlıkları için uygulama katmanında servis işlemlerini (CRUD ve filtreleme) gerçekleştirmek; domain repository’leri üzerinden veri erişimini soyutlamak ve DTO map’leri ile sunum katmanına uygun modeller sağlamak.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı (N-Tier/Clean-vari). Application katmanı; DTO, mapping ve servis mantığını içerir. Domain katmanı; repository kontratlarını (ve muhtemelen entity’leri) barındırır.  
Projeler/Assembly’ler:
- Library.Application — Uygulama servisi, DTO’lar ve mapping uzantıları.
- Library.Domain — Repository arayüzleri (ve muhtemelen domain entity’leri).
Dış Bağımlılıklar: Bu dosyadan görünmüyor (EF Core, MediatR vb. referans tespit edilmedi).  
Konfigürasyon: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarı görünmüyor).

### Architecture Diagram
Library.Application (Services, DTOs, Mappings)
  ↓ depends on
Library.Domain (Interfaces, Entities)

---
### `Library.Application/Services/CustomerService.cs`

**1. Genel Bakış**  
`CustomerService`, müşteri verileri için uygulama düzeyinde CRUD ve listeleme operasyonlarını sağlar. Domain katmanındaki `ICustomerRepository` ile çalışır ve `DTO`-Entity dönüşümlerini `Mappings` uzantılarıyla gerçekleştirir. Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `ICustomerService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `ICustomerRepository` — Müşteri verilerine erişim için domain repository soyutlaması.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public CustomerService(ICustomerRepository customerRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<CustomerDto?> GetByIdAsync(Guid id)` | ID ile müşteriyi getirir, DTO’ya dönüştürür. |
| GetAllAsync | `public Task<IEnumerable<CustomerDto>> GetAllAsync()` | Tüm müşterileri DTO listesi olarak döner. |
| GetActiveCustomersAsync | `public Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Aktif müşterileri filtreleyip DTO listesi olarak döner. |
| CreateAsync | `public Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Yeni müşteri oluşturur, DTO’dan entity’ye map eder ve kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Var olan müşteriyi günceller; bulunamazsa exception fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Müşteriyi ID’ye göre siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping: `CreateCustomerDto.ToEntity()`, `Customer.ToDto()`, `UpdateCustomerDto.UpdateEntity(...)` uzantıları kullanılır.
- `UpdateAsync` içinde, verilen `id` ile müşteri bulunamazsa `KeyNotFoundException` fırlatılır.
- Listeleme operasyonlarında repository’den dönen koleksiyonlar `Select(...).ToDto()` ile projekte edilir.
- Transaction, cache veya yeniden deneme mantığı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** `ICustomerService` tüketicileri (DI üzerinden çözümlenir).
- **Aşağı akış:** `ICustomerRepository`; `Library.Application.Mappings` uzantıları.
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, muhtemel domain entity `Customer`, `ICustomerService`, `ICustomerRepository`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için açık bir girdi validasyonu veya iş kuralı kontrolü yok; validasyonun nerede yapıldığı bu dosyadan anlaşılmıyor.
- `DeleteAsync` için silinecek kayıt bulunamadığında ne olacağı repository implementasyonuna bırakılmış; servis seviyesinde özel hata işleme yok.

---
Genel Değerlendirme
- Kod, Application → Domain bağımlılığıyla katmanlı mimariye uygundur; DTO ve mapping uzantıları ayrışmayı destekler.
- Hata yönetimi asgari düzeydedir (`UpdateAsync` dışında özel durumlar ele alınmıyor); tutarlı bir hata politikası (ör. not-found, concurrency) belirlenmesi faydalı olabilir.
- Validasyonun nerede yapıldığı belirsiz; merkezi bir validasyon katmanı veya fluent validation entegrasyonu düşünülebilir.
- Transaction yönetimi ve altyapı detayları (EF Core vb.) bu dosyadan görünmüyor; Infrastructure ve API katmanlarının varlığı/bağımlılıkları sağlanırsa belgede genişletilebilir.### Project Overview
- Proje adı: Library
- Amaç: Kütüphane personel yönetimi için uygulama katmanı servisleri; personel verilerini depolama katmanından alıp DTO’lara maplemek ve CRUD operasyonlarını sağlamak.
- Hedef framework: Bu dosyadan anlaşılmıyor.
- Mimari: Clean Architecture (katmanlar arası bağımlılıklar arayüzler üzerinden). Uygulama katmanı (`Library.Application`) domain arayüzlerine bağımlı, mapping ile DTO-Entity dönüşümleri yapıyor. Domain katmanı (`Library.Domain`) repository arayüzlerini içeriyor.
- Keşfedilen projeler/assembly’ler:
  - Library.Application: Uygulama servisleri, DTO’lar, mapping uzantıları, uygulama arayüzleri.
  - Library.Domain: Domain arayüzleri (ör. `IStaffRepository`).
- Kullanılan dış paketler/çatı: Bu dosyadan anlaşılmıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Application (Services, DTOs, Mappings)
  ↓ depends on (interfaces, mappings)
Library.Domain (Interfaces)
  ↓ implemented by (muhtemel)
Infrastructure.Data (Repositories) — bu dosyadan anlaşılmıyor
  ↓ used by
API/Presentation — bu dosyadan anlaşılmıyor

---
### `Library.Application/Services/StaffService.cs`

**1. Genel Bakış**
`StaffService`, personel yönetimi için uygulama katmanı servisidir. Domain repository arayüzü üzerinden personel verilerini alır, DTO–Entity mapping işlemlerini yapar ve CRUD benzeri işlemleri sunar. Clean Architecture içinde Application katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffService`
- **Namespace:** `Library.Application.Services`

**3. Bağımlılıklar**
- `IStaffRepository` — Personel varlıkları için veri erişim işlemlerini soyutlar.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `public StaffService(IStaffRepository staffRepository)` | Repository bağımlılığını alır. |
| GetByIdAsync | `public Task<StaffDto?> GetByIdAsync(Guid id)` | Kimliğe göre personeli getirir ve DTO’ya mapler; bulunamazsa `null`. |
| GetAllAsync | `public Task<IEnumerable<StaffDto>> GetAllAsync()` | Tüm personeli getirir ve DTO listesine mapler. |
| GetActiveStaffAsync | `public Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Aktif personeli getirir ve DTO listesine mapler. |
| CreateAsync | `public Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Create DTO’dan entity üretir, ekler ve DTO olarak döner. |
| UpdateAsync | `public Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Mevcut entity’yi bulur, update DTO ile günceller, kaydeder; yoksa `KeyNotFoundException` fırlatır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre personeli siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Mapping uzantıları: `ToDto`, `ToEntity`, `UpdateEntity` dönüşümleri Application katmanında yapılır.
- `UpdateAsync` içinde personel bulunamazsa `KeyNotFoundException` fırlatılır.
- `GetByIdAsync` bulunamayan durumda `null` döner; silmede yokluk kontrolü yapılmaz.
- Girdi validasyonu ve transaction yönetimi bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; muhtemelen API/controller veya diğer application iş akışları çağırır.
- **Aşağı akış:** `IStaffRepository`; `Library.Application.Mappings` uzantıları.
- **İlişkili tipler:** `IStaffService`, `IStaffRepository`, `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.

**7. Eksikler ve Gözlemler**
- `CreateAsync` ve `UpdateAsync` için giriş DTO validasyonları servis seviyesinde yok.
- Silme işleminde (DeleteAsync) varlık yokluğu açıkça ele alınmıyor; tutarlı hata modeli açısından net değil.
- `GetByIdAsync` `null`, `UpdateAsync` exception döndürüyor; uçtan uca hata/boş durum stratejisi tutarlı değil.

### Genel Değerlendirme
Kod, Clean Architecture prensiplerine uygun bir Application servisi sergiliyor ve repository ile mapping katmanlarını ayrıştırıyor. Hata ve boş veri stratejisinin tüm metotlarda tutarlı hale getirilmesi, servis seviyesinde temel validasyonların eklenmesi önerilir. Dış bağımlılıklar, hedef framework ve konfigürasyon gereksinimleri bu örnekten çıkarılamıyor; tam dokümantasyon için diğer katmanların (Infrastructure, API) incelenmesi gerekli.### Project Overview
Proje adı (çıkarım): Library; amaç: kütüphane alan modelini temsil eden domain varlıklarını tanımlamak. Hedef framework bu dosyadan anlaşılmıyor. Mimari katmanlama işaretleri `Library.Domain` ad alanıyla Domain katmanını gösteriyor; bu katman kalıcı veri modeli ve ilişki navigasyonlarını içerir. Keşfedilen projeler/assemblies: 
- Library.Domain — Domain varlıkları (Entity) ve ilişkileri.

Görünen harici paket/çerçeve: Bu dosyadan anlaşılmıyor (EF Core izleri olası, ancak doğrudan referans yok). Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  [hiçbir dış bağımlılık görünmüyor]

---
### `Library.Domain/Entities/Book.cs`

**1. Genel Bakış**
`Book` bir kütüphane kitabını temsil eden domain varlığıdır. Kimlik, başlık, yazar, ISBN, yayımlanma yılı, erişilebilirlik ve kategori ilişkisinden oluşur. Clean/N‑Tier mimaride Domain katmanına aittir.

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
| Title | `public string Title { get; set; }` | Kitap başlığı. |
| Author | `public string Author { get; set; }` | Yazar adı. |
| ISBN | `public string ISBN { get; set; }` | ISBN kodu. |
| PublishedYear | `public int PublishedYear { get; set; }` | Yayın yılı. |
| IsAvailable | `public bool IsAvailable { get; set; }` | Ödünç verilebilirlik durumu. |
| BookCategoryId | `public Guid? BookCategoryId { get; set; }` | İlişkili kategori kimliği (opsiyonel). |
| BookCategory | `public BookCategory? BookCategory { get; set; }` | İlişkili kategori navigasyonu (opsiyonel). |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Title = string.Empty`, `Author = string.Empty`, `ISBN = string.Empty`, `IsAvailable = true`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Bu dosyadan anlaşılmıyor (yalnızca `BookCategory` navigasyonu mevcut).
- **İlişkili tipler:** `BookCategory` (aynı domain içinde kategori varlığı; bu dosyada tanımlı değil).

Genel Değerlendirme
- Kod sadece domain varlığını içeriyor; doğrulama, iş kuralları ve kalıcılık haritası görünmüyor.
- Hedef framework, veri erişim teknolojisi ve konfigürasyonlar bu dosyadan tespit edilemiyor.
- İlişki navigasyonları EF Core kullanımını ima etse de doğrudan bağımlılık belirtilmemiş.### Project Overview
Proje adı (çıkarım): Library. Amaç: Kütüphane alanındaki çekirdek domain varlıklarını tanımlamak (ör. kitap, kategori). Hedef çatılar: Kod sadece domain katmanını gösteriyor; hedef framework ve .NET sürümü bu dosyadan anlaşılmıyor.

Mimari desen: Katmanlı mimari (Domain odaklı). Domain katmanı, iş kurallarını ve entity tanımlarını içerir. Uygulama, Altyapı ve API katmanlarına dair dosya görülmüyor; ancak `Library.Domain` ayrı bir assembly olarak konumlanmış.

Projeler/Assembly’ler:
- Library.Domain — Domain entity’leri ve olası değer nesneleri/arayüzleri.

Dış bağımlılıklar:
- Bu dosyada harici paket kullanımı görünmüyor.

Konfigürasyon gereksinimleri:
- Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  [Diğer katmanlar bu dosyadan görünmüyor; tipik akış: Application → Domain, Infrastructure → Domain referanslayabilir]

---

### `Library.Domain/Entities/BookCategory.cs`

**1. Genel Bakış**
`BookCategory`, kitapların ait olduğu kategori bilgisini temsil eden domain entity’sidir. Domain katmanında yer alır ve kitap-kategori ilişkisinde kategoriyi merkeze alır.

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
| Id | `public Guid Id { get; set; }` | Kategorinin benzersiz kimliği. |
| Name | `public string Name { get; set; }` | Kategori adı. Varsayılanı `string.Empty`. |
| Description | `public string Description { get; set; }` | Kategorinin açıklaması. Varsayılanı `string.Empty`. |
| Books | `public ICollection<Book> Books { get; set; }` | Bu kategoriye bağlı kitapların koleksiyonu; varsayılan boş koleksiyon. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `Name = string.Empty`, `Description = string.Empty`, `Books = []`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** `Book` (navigasyon türü).
- **İlişkili tipler:** `Book` (muhtemel karşılıklı ilişki).

**7. Eksikler ve Gözlemler**
- Domain düzeyinde `Name` için boşluk/uzunluk validasyonu veya zorunluluk kuralı uygulanmamış; invariants kod içinde ifade edilmemiş.### Project Overview
Proje Adı: Library  
Amaç: Kütüphane alan modelindeki müşteri bilgisini temsil eden domain varlıklarını tanımlamak.  
Hedef Framework: Bu dosyadan anlaşılmıyor.  
Mimari: Büyük olasılıkla katmanlı/Clean Architecture (bu dosya `Domain` katmanına işaret ediyor).  
Katmanlar:
- Domain: Temel iş kavramları ve varlıklar (ör. `Customer`).

Projeler/Assembly’ler:
- Library.Domain: Domain varlıkları ve olası değer nesneleri.

Harici Paketler/Çatılar: Bu dosyadan görünmüyor.  
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain (Entities)
  ↑ (tüketilir)
Application / Infrastructure / API
Not: Bu akış yönü, domain varlıklarının genellikle üst katmanlarca tüketildiği varsayımına dayanır; bu dosyadan kesin bağımlılık görünmüyor.

---
### `Library.Domain/Entities/Customer.cs`

**1. Genel Bakış**  
`Customer`, kütüphane sistemindeki bir müşterinin temel kimlik ve iletişim bilgilerini tutan domain varlığıdır. Basit veri taşıma/kalıcılık odaklıdır ve Domain katmanına aittir.

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
| FirstName | `public string FirstName { get; set; }` | Müşteri adı. |
| LastName | `public string LastName { get; set; }` | Müşteri soyadı. |
| Email | `public string Email { get; set; }` | E-posta adresi. |
| Phone | `public string Phone { get; set; }` | Telefon numarası. |
| Address | `public string Address { get; set; }` | Adres bilgisi. |
| MembershipNumber | `public string MembershipNumber { get; set; }` | Üyelik numarası. |
| RegisteredDate | `public DateTime RegisteredDate { get; set; }` | Kayıt tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**  
DTO — davranış yok. Default değerler:  
- `FirstName = string.Empty`  
- `LastName = string.Empty`  
- `Email = string.Empty`  
- `Phone = string.Empty`  
- `Address = string.Empty`  
- `MembershipNumber = string.Empty`  
- `IsActive = true`  
- `RegisteredDate` için default belirtilmemiş (tipin default’u).

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Domain varlığı yalın; kapsülleme ve invariant koruması (ör. `Email` formatı, boş ad/soyad engeli) kodda görünmüyor.
- Değer nesneleri (ör. `Email`, `Phone`, `Address`) ile modelin zenginleştirilmesi düşünülebilir.
- `RegisteredDate` için otomatik atama veya fabrika yöntemi yok; oluşturma anında bütünlük kontrolü dış katmanlara bırakılmış görünüyor.### Project Overview
Proje Adı: Library
Amaç: Kütüphane alan modelini temsil eden domain varlıklarını tanımlamak.
Hedef Framework: Bu dosyadan anlaşılmıyor (muhtemelen .NET/ASP.NET tabanlı bir çözüm).
Mimari Desen: Clean Architecture (muhtemel) — yalnızca Domain katmanı görünür.
Katmanlar/Roller:
- Library.Domain: Domain katmanı; temel varlıklar ve iş kurallarının merkezi (bu dosyada sadece entity mevcut).
Keşfedilen Projeler/Assembly’ler:
- Library.Domain — Domain varlıklarını barındırır.
Kullanılan Harici Paketler/Çatılar: Bu dosyadan anlaşılmıyor (görünür bağımlılık yok).
Konfigürasyon Gereksinimleri: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Domain] (Entities)

---
### `Library.Domain/Entities/Staff.cs`

**1. Genel Bakış**
`Staff` bir kütüphane personelini temsil eden domain varlığıdır. Personelin kimlik, iletişim, pozisyon ve işe alım bilgilerini taşır. Domain katmanına aittir ve muhtemelen kalıcı katmanda karşılık gelen tabloya/aggregate’e map edilecektir.

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
| Position | `public string Position { get; set; }` | Personelin pozisyonu/unvanı. |
| HireDate | `public DateTime HireDate { get; set; }` | İşe başlama tarihi. |
| IsActive | `public bool IsActive { get; set; }` | Aktiflik durumu. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: `FirstName = string.Empty`, `LastName = string.Empty`, `Email = string.Empty`, `Phone = string.Empty`, `Position = string.Empty`, `IsActive = true`.

**6. Bağlantılar**
- **Yukarı akış:** Bu dosyadan anlaşılmıyor.
- **Aşağı akış:** Harici bağımlılık yok.
- **İlişkili tipler:** Bu dosyadan anlaşılmıyor.

Genel Değerlendirme
- Şu an yalnızca domain katmanında tek bir entity mevcut; validasyon, değer nesneleri veya aggregate kökleri görünmüyor.
- Veri açıklamaları (ör. `Required`, uzunluk kısıtları), domain olayları veya koruyucu kurallar tanımlı değil; bu ihtiyaçlar varsa ileride eklenmelidir.
- Diğer katmanlar (Application/Infrastructure/API) bu dosyadan anlaşılamıyor; proje genel mimarisini doğrulamak için diğer projeler incelenmeli.### Project Overview
Proje adı: Library (çıkarım: `Library.Domain` namespace’inden). Amaç: Kitap kategorileri için domain sözleşmeleri tanımlamak; repository kontratları ile kalıcı katmandan bağımsız bir alan modeli oluşturmak. Hedef çatı: Bu dosyadan hedef framework net değil.

Mimari: Katmanlı mimari (Domain katmanı). Domain katmanı; entity’ler ve repository arayüzleri gibi iş kurallarını ve sözleşmeleri barındırır. Uygulama/Altyapı katmanları bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library.Domain — Domain tipleri (entity, repository arayüzleri). Diğer projeler (Application/Infrastructure/API) bu dosyadan anlaşılamıyor.

Harici paketler/çatı: Görünmüyor.

Konfigürasyon: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Domain] Library.Domain
  └─ Arayüzler: `IRepository<T>`, `IBookCategoryRepository`
     └─ Varlıklar: `BookCategory`

Beklenen bağımlılık akışı (çıkarım, bu dosyadan): Application → Domain; Infrastructure → Domain; API → Application/Domain. Bu depoda yalnızca Domain görünür.

---
### `Library.Domain/Interfaces/IBookCategoryRepository.cs`

**1. Genel Bakış**
`IBookCategoryRepository`, `BookCategory` varlıkları için repository sözleşmesini tanımlar. Genel CRUD davranışlarını `IRepository<BookCategory>` üzerinden devralır ve kategori adına göre arama ile ilişki dahil yükleme (kitaplarla birlikte) gibi domain-özel sorguları ekler. Domain katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** interface
- **Miras:** `IRepository<BookCategory>`
- **Uygılar:** Yok
- **Namespace:** `Library.Domain.Interfaces`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Kategori adından tekil `BookCategory` döndürür; bulunamazsa `null`. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Verilen `id` için kategoriyle ilişkili kitapları dahil ederek döndürür; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Arayüz — davranış yok. Uygulama altyapısında, isim bazlı tekilleştirme varsayılır (adı benzersiz kabul edilebilir, bu dosyadan garanti edilmez).
- `GetWithBooksAsync` ilişki yüklemeyi (eager/explicit) ima eder; gerçek yükleme stratejisi implementasyona bağlıdır.
- Her iki metod da bulunamadığında `null` döndürmeyi sözleşme olarak belirtir; exception davranışı bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- Yukarı akış: Application servisleri, domain servisleri veya handler’lar tarafından çağrılır; DI üzerinden çözümlenir.
- Aşağı akış: `BookCategory` entity’si; `IRepository<BookCategory>` temel CRUD sözleşmesi.
- İlişkili tipler: `BookCategory`, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- `IRepository<BookCategory>` tanımı bu depoda görünmüyor; implementasyon ve sözleşme detayları belirsiz.
- Adla aramada kültür/karakter duyarlılığı ve trimming/normalizasyon kuralları belirtilmemiş; implementasyonda netleştirilmeli.
- İlişkili “books” koleksiyonunun adı/gezinti özelliği bu dosyadan bilinmiyor; mapping tarafında tutarlılık gerektirir.

### Genel Değerlendirme
Kod tabanı yalnızca Domain katmanındaki bir repository arayüzünü gösteriyor. Uygulama, Altyapı ve API katmanları görünmediğinden hedef çatı, konfigürasyon anahtarları ve veri erişim stratejileri belirsiz. Sözleşmede null-döndürme semantiği net; fakat hata yönetimi, case-sensitivity ve ilişki yükleme stratejileri implementasyon kademesinde açıkça tanımlanmalı. `IRepository<T>` kontratının görünürlüğü, ortak CRUD sözleşmesinin kapsamını değerlendirmek için gereklidir.### Project Overview
Proje adı: Library. Amaç: kütüphane alanındaki temel varlıklar ve sözleşmeleri (repository arayüzleri) tanımlayan Domain katmanı. Hedef çatı/TFM bu dosyadan anlaşılmıyor. Mimari olarak, Domain katmanında `Book` entity’si için repository sözleşmesi tanımlanmış; uygulama ve altyapı katmanlarının bu sözleşmeyi kullanması amaçlanır.

Mimari desen: Clean Architecture (çıkarım) — Domain katmanı yalın tipler ve arayüzler içerir; uygulama/altyapı ayrımı bu dosyadan görülmüyor fakat Domain bağımsızdır.

Projeler/Assembly’ler:
- Library.Domain — Domain katmanı; entity’ler ve repository arayüzleri.

Harici paketler: Bu dosyadan görünmüyor.

Konfigürasyon: Bu dosyadan görünmüyor.

### Architecture Diagram
Library.Domain
  (başka katmanlara bağımlılık bildirmiyor; bağımsız sözleşmeler)

---
### `Library.Domain/Interfaces/IBookRepository.cs`

**1. Genel Bakış**
`IBookRepository`, `Book` varlığı için depolama erişim sözleşmesini tanımlar. Domain katmanına aittir ve uygulama/altyapı katmanlarının bu arayüzü uygulayıp kullanmasını amaçlar. Kitapların uygunluk durumuna ve ISBN’e göre alınmasını standartlaştırır.

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
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Müsait durumdaki tüm `Book` kayıtlarını döndürür. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Verilen `isbn` değeriyle eşleşen `Book` kaydını döndürür; bulunamazsa `null`. |

**5. Temel Davranışlar ve İş Kuralları**
- Sözleşme — davranış içermez; implementasyon depoya özgüdür.
- `GetByISBNAsync` için ISBN formatı/normalizasyonu bu arayüzde tanımlı değildir.
- `GetAvailableBooksAsync`’in “müsaitlik” kriteri Domain sözleşmesinde belirsiz; implementasyon veya `Book` modelinin durumlarına bağlıdır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `Book` entity’si, `IRepository<Book>` taban sözleşmesi.
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `Library.Domain.Interfaces.IRepository<T>`

Genel Değerlendirme
- Sadece Domain arayüzü görüldüğü için mimarinin diğer katmanları ve uygulamalar bu depodan anlaşılamıyor.
- `IRepository<Book>` tanımı bu depoda gösterilmediğinden, temel CRUD kapsamı ve sözleşme ayrıntıları belirsiz.
- ISBN doğrulama/normalizasyon politikaları sözleşmeye yansıtılmamış; bu, uygulama/altyapı katmanlarında tutarlı uygulanmalıdır.### Project Overview
Proje Adı: Library (türetim: `Library.Domain` namespace’inden). Amaç: Kütüphane alan modelini ve sözleşmelerini tanımlamak; özellikle müşteri (üye) yönetimine ilişkin repository sözleşmelerini sağlamak. Hedef Framework: Bu dosyadan kesin olarak belirlenemiyor.

Mimari Desen: Clean Architecture/N-Tier esintili katmanlı yapı. Bu dosya Domain katmanında yer alan repository sözleşmesini içerir. Domain katmanı, uygulama/infrastructure tarafından referans alınır ve bağımlılık yönü Domain → hiçbir şeye, Application/Infrastructure → Domain şeklindedir.

Projeler/Assembly’ler:
- Library.Domain — Alan varlıkları ve sözleşmeler (entity’ler, repository interface’leri).

Kullanılan Dış Paketler/Çatılar: Bu dosyadan görünmüyor.

Yapılandırma Gereksinimleri: Bu dosyadan görünmüyor.

### Architecture Diagram
[API/Presentation] → [Application] → [Infrastructure] → (uygulama zamanı implementasyonları)
                               ↑
                              [Domain] (entity’ler ve interface’ler; üst katmanlar Domain’i referans alır)

---
### `Library.Domain/Interfaces/ICustomerRepository.cs`

**1. Genel Bakış**
`ICustomerRepository`, `Customer` varlıkları için repository sözleşmesini genişleterek e-posta, üyelik numarası ve aktiflik durumuna göre sorgulama yetenekleri tanımlar. Domain katmanında yer alır ve uygulama hizmetlerinin altyapıdaki veri erişim implementasyonlarına bağımlılığını tersine çevirir.

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
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre tekil müşteriyi asenkron olarak getirir. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre tekil müşteriyi asenkron olarak getirir. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Aktif durumdaki tüm müşterileri asenkron olarak listeler. |

Not: `IRepository<Customer>` üyeleri bu dosyada tanımlı değildir; kalıtsal API bu dosyadan anlaşılamıyor.

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok. Default değerler: Bu dosyadan anlaşılmıyor; interface yalnızca sözleşme tanımlar.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri/handler’lar tarafından çağrılması beklenir.
- **Aşağı akış:** Implementasyon tarafında veri kaynağı (örn. ORM/SQL) ile entegrasyon.
- **İlişkili tipler:** `Customer` (entity), `IRepository<Customer>` (genel repository sözleşmesi).

**7. Eksikler ve Gözlemler**
- Asenkron imzalarda `CancellationToken` parametresi bulunmuyor; uzun süren I/O işlemlerinde iptal desteği gerekebilir.
- `GetActiveCustomersAsync` için sayfalama/sıralama kriterleri tanımlı değil; büyük veri kümelerinde performans ve bellek kullanımı açısından sınırlamalar doğurabilir.

---
Genel Değerlendirme
- Kod, Clean Architecture’a uygun olarak Domain katmanında yalın bir repository sözleşmesi sunuyor.
- Mevcut dosyada dış bağımlılık veya konfigürasyon görünmüyor; bu beklenen bir durum.
- Asenkron imzalara `CancellationToken` eklenmesi ve listeleme operasyonlarına sayfalama/sıralama sözleşmelerinin dahil edilmesi faydalı olabilir.
- `IRepository<T>` tanımı bu depoda görünmediğinden, sözleşmenin tam kapsamı bu dosyadan çıkarılamıyor.### Project Overview
- Proje adı: Library (çıkarım: `Library.Domain` alan isimlerinden)
- Amaç: Domain katmanında generic repository sözleşmesini tanımlayarak veri erişim detaylarını soyutlamak ve üst katmanların (Application/Infrastructure) ortak bir depolama arayüzü üzerinden çalışmasını sağlamak.
- Hedef çatı: Bu dosyadan kesin olarak anlaşılamıyor (.NET sürümü belirtilmemiş).
- Mimari desen: Clean Architecture/N‑Katmanlı eğilimi; burada görülen Domain katmanı yalnızca arayüz/sözleşme tanımlar.
- Keşfedilen projeler/assembly’ler:
  - Library.Domain — Domain sözleşmeleri (repository arayüzü).
- Kullanılan harici paketler/çatı: Bu dosyadan anlaşılamıyor.
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılamıyor.

### Architecture Diagram
[Consumers (Application/Infrastructure)] -> Library.Domain

---

### `Library.Domain/Interfaces/IRepository.cs`

**1. Genel Bakış**
Generic `IRepository<T>` arayüzü, aggregate/entity tipleri için temel CRUD operasyonlarını asenkron olarak soyutlar. Domain katmanına aittir ve veri erişim detaylarını Infrastructure katmanına bırakacak şekilde sözleşme tanımlar.

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
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Verilen `Guid` kimliğe göre tek bir varlığı döndürür veya yoksa `null`. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Tüm varlıkları döndürür. |
| AddAsync | `Task AddAsync(T entity)` | Yeni varlığı ekler. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Mevcut varlığı günceller. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Verilen `Guid` kimliğe sahip varlığı siler. |

**5. Temel Davranışlar ve İş Kuralları**
- Generic kısıt: `where T : class` — referans tiplerle sınırlıdır.
- Tüm operasyonlar asenkron desenle tanımlanmıştır; I/O tabanlı veri erişimi beklenir.
- `GetByIdAsync` bulunamadığında `null` dönebilir; exception sözleşmesi bu dosyadan anlaşılamıyor.
- Kimlik temsilinin `Guid` olduğu varsayımı arayüz sözleşmesine gömülüdür.

**6. Bağlantılar**
- Yukarı akış: Application servisleri, domain servisleri veya Infrastructure implementasyonları tarafından kullanılır (DI üzerinden çözümlenir).
- Aşağı akış: Harici bağımlılık yok; implementasyonlar veri katmanına bağlanacaktır.
- İlişkili tipler: Bu dosyadan anlaşılamıyor (entity/DTO belirtilmemiş).

**7. Eksikler ve Gözlemler**
- Sayfalama, filtreleme ve sorgu ifadeleri (specification pattern) desteklenmiyor; sadece temel CRUD kapsamı var.
- `DeleteAsync` ve `GetByIdAsync` için bulunamama durumlarında beklenen davranış açık değil (null/exception politikası belirtilmemiş).

---

Genel Değerlendirme
- Mevcut kod yalnızca Domain katmanında generic bir repository arayüzü sunuyor; implementasyonlar ve üst katmanlar bu girdiyle görünür değil.
- Guid tabanlı kimlik varsayımı tüm entity’ler için sabitlenmiş; farklı kimlik türlerine ihtiyaç varsa esneklik kısıtlı olabilir.
- Gelişmiş kullanım senaryoları (specification, unit of work, transaction sınırları, soft delete, concurrency) bu sözleşmede yer almıyor; ihtiyaç halinde genişletilmesi gerekebilir.### Project Overview
- Project Name: Library
- Purpose: Kütüphane alanı için domain sözleşmelerini (repository arayüzleri) ve entity referanslarını tanımlamak.
- Target Framework: Bu dosyadan anlaşılmıyor.
- Architecture Pattern: Katmanlı/Clean mimari eğilimli yapı; Domain katmanı arayüz ve entity’leri barındırıyor, uygulama/altyapı katmanları tarafından tüketilmesi amaçlanmış görünüyor.
- Discovered Projects/Assemblies:
  - Library.Domain — Domain entity’leri ve repository arayüzleri (iş kuralları sözleşmeleri).
- Key External Packages/Frameworks: Bu dosyadan anlaşılmıyor.
- Configuration Requirements: Bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Domain.Interfaces --> Library.Domain.Entities

---

### `Library.Domain/Interfaces/IStaffRepository.cs`

**1. Genel Bakış**
`IStaffRepository`, `Staff` entity’si için repository sözleşmesini genişletir ve e-posta ile sorgulama ile aktif personel listesini elde etme operasyonlarını tanımlar. Domain katmanında yer alır ve altyapıda implementasyonu beklenir.

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
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | Verilen e-posta ile eşleşen `Staff` kaydını asenkron getirir, bulunamazsa `null` döner. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Aktif durumdaki tüm `Staff` kayıtlarını asenkron olarak listeler. |

**5. Temel Davranışlar ve İş Kuralları**
DTO — davranış yok.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir.
- **Aşağı akış:** `IRepository<Staff>`; `Library.Domain.Entities.Staff`.
- **İlişkili tipler:** `Staff`, `IRepository<T>`.

**7. Eksikler ve Gözlemler**
- Implementasyon bu depoda görünmüyor; altyapı katmanında somut bir repository beklenir.### Project Overview
Proje adı (çıkarım): Library  
Amaç: Kütüphane varlıkları (kitaplar, kategoriler, personel, müşteriler) için kalıcı veri erişimi ve şema yapılandırması sağlamak.  
Hedef framework: Bu dosyadan anlaşılmıyor.  
Mimari: Katmanlı/Clean esintili. Görünen katmanlar: Domain (entity’ler) ve Infrastructure (EF Core tabanlı veri erişimi).  
Projeler/Assembly’ler:
- Library.Domain — Entity tanımları (`Book`, `BookCategory`, `Staff`, `Customer`)
- Library.Infrastructure — Veri erişimi ve EF Core `DbContext` yapılandırmaları
Kullanılan dış paket/çatı: Microsoft.EntityFrameworkCore (EF Core).  
Konfigürasyon gereksinimleri: EF Core sağlayıcısı ve bağlantı dizesiyle `DbContextOptions<LibraryDbContext>` konfigürasyonu; bağlantı dizesi anahtarı/provider bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure -> Library.Domain

---

### `Library.Infrastructure/Data/LibraryDbContext.cs`

**1. Genel Bakış**  
`LibraryDbContext`, EF Core üzerinden kütüphane alanındaki varlıkların kalıcılığını yönetir ve şema kurallarını tanımlar. Infrastructure katmanında yer alır ve Domain entity’lerine ilişkin tablo, ilişki ve indeks yapılandırmalarını içerir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `Microsoft.EntityFrameworkCore.DbContext`
- **Uygular:** Yok
- **Namespace:** `Library.Infrastructure.Data`

**3. Bağımlılıklar**
- `DbContextOptions<LibraryDbContext>` — EF Core bağlamı için sağlayıcı/bağlantı ve davranış konfigürasyonu

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | `DbContext` için seçenekleri alır. |
| Books | `public DbSet<Book> Books { get; }` | `Book` varlıkları için sorgu/komut girişi. |
| BookCategories | `public DbSet<BookCategory> BookCategories { get; }` | `BookCategory` varlıkları için erişim. |
| Staff | `public DbSet<Staff> Staff { get; }` | `Staff` varlıkları için erişim. |
| Customers | `public DbSet<Customer> Customers { get; }` | `Customer` varlıkları için erişim. |
| OnModelCreating | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Varlık yapılandırmaları ve ilişkileri tanımlar. |

**5. Temel Davranışlar ve İş Kuralları**
- `Book`: `Title` (max 200), `Author` (max 150), `ISBN` (max 20) zorunlu; `ISBN` benzersiz indeks. `BookCategory` ile çoklu ilişki, FK `BookCategoryId`, silmede `SetNull` davranışı.
- `BookCategory`: `Name` (max 100) zorunlu ve benzersiz; `Description` (max 500) opsiyonel; `Books` ile 1-çok ilişki.
- `Staff`: `FirstName`/`LastName` (max 100), `Email` (max 200) ve `Position` (max 100) zorunlu; `Email` benzersiz; `Phone` (max 20) opsiyonel.
- `Customer`: `FirstName`/`LastName` (max 100), `Email` (max 200), `MembershipNumber` (max 50) zorunlu; `Email` ve `MembershipNumber` benzersiz; `Phone` (max 20), `Address` (max 500) opsiyonel.
- Veri bütünlüğü: Zorunlu alanlar ve benzersiz indekslerle iş kuralları veri seviyesinde korunur.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir; repository/service katmanları bu bağlamı kullanır.
- Aşağı akış: EF Core (`Microsoft.EntityFrameworkCore`), Domain entity’leri (`Book`, `BookCategory`, `Staff`, `Customer`).
- İlişkili tipler: `Library.Domain.Entities.*` varlıkları.

**7. Eksikler ve Gözlemler**
- `OnDelete(DeleteBehavior.SetNull)` için `Book.BookCategoryId` alanının null olabilir olması gerekir; alanın nullability’si bu dosyadan anlaşılmıyor. Uyuşmazlık varsa çalışma zamanı hatasına yol açabilir.
- Yapılandırmalar tek dosyada fluent API ile tanımlı; büyük projelerde `IEntityTypeConfiguration<T>` ile ayrıştırma bakım kolaylığı sağlayabilir.

---

Genel Değerlendirme
- Mimari olarak Domain ve Infrastructure katmanları net; EF Core kullanımı yerinde ve kısıtlar iş kurallarını destekliyor.
- Bağlantı dizesi/provider detayları görünmüyor; ortam bazlı konfigürasyon için `appsettings` anahtar adları belirginleştirilebilir.
- Varlık yapılandırmalarının ayrı konfigürasyon sınıflarına taşınması ölçeklenebilirliği artırabilir.
- İlişki silme kuralı (`SetNull`) ile FK nullability’si tutarlı olmalı; Domain entity tanımlarında doğrulanması önerilir.### Project Overview
Proje adı: Library (katman: Infrastructure). Amaç: EF Core `DbContext` kurulumu ve Domain katmanındaki repository arayüzlerinin somut implementasyonlarla DI konteynerine kaydı. Hedef framework bu dosyadan anlaşılmıyor.

Mimari: Temiz Mimari (Clean Architecture) göstergeleri var. `Infrastructure` katmanı, `Domain` arayüzlerini uygular ve dış kaynaklara (veritabanı) erişimi sağlar. Üst katmanlar (API/Application) bu katmanı DI uzantısı üzerinden tüketir.

Projeler/Assembly’ler:
- Library.Infrastructure — Altyapı; EF Core `DbContext` ve repository kayıtları.
- Library.Domain — Arayüzler (`Library.Domain.Interfaces`) referans olarak kullanılıyor (bu dosyadan implementasyonlar Infrastructure’da).

Dış bağımlılıklar:
- Entity Framework Core (`Microsoft.EntityFrameworkCore`) ve SQL Server sağlayıcısı (`UseSqlServer`)
- `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Configuration`

Konfigürasyon gereksinimleri:
- Connection string anahtarı: `DefaultConnection` (appsettings veya dış konfigürasyonda tanımlı olmalı)

### Architecture Diagram
[API/Application] -> Library.Infrastructure -> Library.Domain
Library.Infrastructure.Data (DbContext) -> SQL Server
Library.Infrastructure.Repositories -> Library.Infrastructure.Data
Library.Infrastructure -> Library.Domain.Interfaces

---
### `Library.Infrastructure/DependencyInjection.cs`

**1. Genel Bakış**
`DependencyInjection` statik sınıfı, Infrastructure katmanı için bir DI uzantısı sağlar. EF Core `LibraryDbContext`’i ve Domain arayüzlerine karşılık gelen repository implementasyonlarını `Scoped` ömürle kaydeder. Altyapı katmanına aittir.

**2. Tip Bilgisi**
- **Tip:** static class
- **Miras:** Yok
- **Uygılar:** Yok
- **Namespace:** `Library.Infrastructure`

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | EF Core `LibraryDbContext` ve repository servislerini DI konteynerine ekler. |

**5. Temel Davranışlar ve İş Kuralları**
- `LibraryDbContext` SQL Server sağlayıcısıyla `DefaultConnection` connection string’i üzerinden yapılandırılır.
- Repository kayıtları `Scoped` yaşam süresiyle eklenir: `IBookRepository`→`BookRepository`, `IBookCategoryRepository`→`BookCategoryRepository`, `IStaffRepository`→`StaffRepository`, `ICustomerRepository`→`CustomerRepository`.
- `configuration.GetConnectionString("DefaultConnection")` değeri yoksa veritabanına bağlanırken çalışma zamanı hatası alınabilir.

**6. Bağlantılar**
- **Yukarı akış:** Kompozisyon kökünden (ör. API `Program.cs`/`Startup`) çağrılır.
- **Aşağı akış:** `LibraryDbContext`, EF Core SQL Server sağlayıcısı; `BookRepository`, `BookCategoryRepository`, `StaffRepository`, `CustomerRepository`; `Library.Domain.Interfaces` arayüzleri.
- **İlişkili tipler:** `Library.Infrastructure.Data.LibraryDbContext`, `IBookRepository`, `IBookCategoryRepository`, `IStaffRepository`, `ICustomerRepository` ve bunların somut implementasyonları.

**7. Eksikler ve Gözlemler**
- Connection string adı sabit (`DefaultConnection`); yapılandırılabilir hale getirilmesi veya yokluğunda açık hata mesajı/guard eklenmesi düşünülebilir.
- Veritabanı sağlayıcısı sabit (`UseSqlServer`); farklı ortamlar için esneklik yok.

Genel Değerlendirme
- Altyapı katmanı, Clean Architecture’a uygun şekilde Domain arayüzlerini uygulayıp DI’a kayıt ediyor. Bağımlılıklar net ve sınırlı. Konfigürasyon adının/sunucusunun sabitlenmesi esneklik açısından kısıtlayıcı; çoklu ortam/sağlayıcı desteği ve connection string doğrulaması eklenebilir. Üst katmanlar (API/Application) ve Domain entity/DTO detayları bu girdi kapsamında görünmüyor.### Project Overview
Proje adı: Library. Amaç: Kütüphane alanındaki `BookCategory` varlıklarının kalıcı katmanda yönetilmesi (CRUD ve sorgular). Hedef çerçeve: bu dosyadan anlaşılmıyor. Mimari, katmanlı (Domain ve Infrastructure) yaklaşımı işaret ediyor: `Library.Domain` alan modelleri ve sözleşmeleri, `Library.Infrastructure` veri erişimi ve kalıcılık.

Keşfedilen projeler/assembly’ler:
- Library.Domain — `Entities` ve `Interfaces` (ör. `BookCategory`, `IBookCategoryRepository`)
- Library.Infrastructure — EF Core tabanlı repository ve `LibraryDbContext` ile veri erişimi

Kullanılan dış paket/çerçeveler:
- Microsoft.EntityFrameworkCore (EF Core)

Konfigürasyon gereksinimleri:
- Veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları muhtemel; bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure → Library.Domain

Notlar:
- `Library.Infrastructure.Repositories` içinde `BookCategoryRepository`, `Library.Domain.Entities` ve `Library.Domain.Interfaces` türlerine bağlıdır.
- `Library.Infrastructure.Data.LibraryDbContext` iç bağımlılıktır (aynı assembly).

---

### `Library.Infrastructure/Repositories/BookCategoryRepository.cs`

**1. Genel Bakış**
`BookCategory` varlıkları için EF Core tabanlı repository implementasyonudur. Domain katmanındaki `IBookCategoryRepository` kontratını karşılar ve Infrastructure katmanında konumlanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookCategoryRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `BookCategories` DbSet’i üzerinden veri erişimi ve `SaveChangesAsync` ile kalıcılık.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `BookCategoryRepository(LibraryDbContext context)` | DbContext enjekte eder. |
| GetByIdAsync | `Task<BookCategory?> GetByIdAsync(Guid id)` | ID ile kategori bulur. |
| GetAllAsync | `Task<IEnumerable<BookCategory>> GetAllAsync()` | Tüm kategorileri listeler. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Ada göre ilk eşleşen kategoriyi getirir. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | İlgili `Books` navigation’ı dahil ederek getirir. |
| AddAsync | `Task AddAsync(BookCategory entity)` | Yeni kategori ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(BookCategory entity)` | Varolan kategoriyi günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | ID’ye göre kategoriyi bulup siler ve kaydeder (varsa). |

**5. Temel Davranışlar ve İş Kuralları**
- `GetWithBooksAsync` `Include(c => c.Books)` ile eager loading yapar.
- `AddAsync`, `UpdateAsync`, `DeleteAsync` her çağrıda `SaveChangesAsync` çalıştırır; işlem bazlı kalıcılık immediate’tir.
- `DeleteAsync` kategoriyi bulamazsa sessizce hiçbir işlem yapmaz.
- Eşitlik kontrolleri doğrudan `Name` ve `Id` alanlarına göre yapılır; kültür/trim case-handling uygulanmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; uygulama servisleri veya handler’lar tarafından çağrılması muhtemeldir.
- **Aşağı akış:** `LibraryDbContext`, EF Core (`DbSet`, `Include`, `FindAsync`, `SaveChangesAsync`).
- **İlişkili tipler:** `IBookCategoryRepository`, `BookCategory`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Her metotta `SaveChangesAsync` çağrısı, Unit of Work senaryolarında toplu işlemleri zorlaştırabilir.
- `CancellationToken` desteği yok; uzun sorgularda iptal imkanı sağlanmıyor.
- Hata yönetimi/özel istisna sarmalama yok; `SaveChangesAsync` hataları üst katmana çıplak geçer.

---

Genel Değerlendirme
- Katmanlı mimari sinyalleri net: Domain sözleşmeleri ve Infrastructure implementasyonu ayrılmış.
- Repository, EF Core’a doğrudan bağlı; UoW deseni veya transaction kapsamı bu dosyada görünmüyor.
- İyileştirme alanları: `CancellationToken` eklenmesi, kültüre duyarlı arama (`GetByNameAsync`) ve birim-of-work ile batched `SaveChanges` desteği. Ayrıca, hata yayılım stratejisinin (ör. domain-özel istisnalar) netleştirilmesi faydalı olur.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” ve amaç, kütüphane kitap verilerini kalıcı katmanda yönetmek (CRUD ve sorgular). Hedef çerçeve bu dosyadan anlaşılamıyor; .NET (C#) ve EF Core kullanımı görülüyor. Mimari, Domain ve Infrastructure katmanlarının ayrıldığı Clean Architecture/N‑Tier benzeri bir düzeni işaret ediyor: Domain (entity ve repository kontratları), Infrastructure (EF Core ile repository implementasyonları). Keşfedilen projeler/assembly’ler: 
- Library.Domain — `Entities`, `Interfaces` (görüldü: `Book`, `IBookRepository`)
- Library.Infrastructure — EF Core tabanlı repository implementasyonu (görüldü: `BookRepository`)
Kullanılan dış paketler/çerçeveler: Microsoft Entity Framework Core (`Microsoft.EntityFrameworkCore`). Konfigürasyon gereksinimleri (ör. connection string, appsettings anahtarları) bu dosyadan anlaşılamıyor; `LibraryDbContext` tarafından belirlenecektir.

### Architecture Diagram
Domain (Entities, Interfaces)
      ↑
      │ (Repository kontratı kullanımı)
Infrastructure (EF Core Repository Implementations)

---
### `Library.Infrastructure/Repositories/BookRepository.cs`

**1. Genel Bakış**
`BookRepository`, `IBookRepository` sözleşmesini EF Core ile gerçekleştiren kalıcılık katmanı sınıfıdır. `Book` entity’leri için temel CRUD ve özel sorguları (`GetAvailableBooksAsync`, `GetByISBNAsync`) sağlar. Mimari olarak Infrastructure katmanına aittir ve Domain katmanındaki entity ve arayüzleri uygular.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IBookRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Book` seti üzerinden veri erişimi ve `SaveChangesAsync` işlemleri.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BookRepository(LibraryDbContext context)` | EF Core `LibraryDbContext` bağımlılığını alır. |
| GetByIdAsync | `public Task<Book?> GetByIdAsync(Guid id)` | Bir kitabı kimliğine göre getirir; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitapları listeler. |
| GetAvailableBooksAsync | `public Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable` true olan kitapları döner. |
| GetByISBNAsync | `public Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre ilk eşleşen kitabı döner; yoksa `null`. |
| AddAsync | `public Task AddAsync(Book entity)` | Yeni kitabı ekler ve değişiklikleri kaydeder. |
| UpdateAsync | `public Task UpdateAsync(Book entity)` | Var olan kitabı günceller ve değişiklikleri kaydeder. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kitap varsa siler ve değişiklikleri kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Ekleme, güncelleme ve silme işlemleri sonrası `SaveChangesAsync` çağrılır; işlem anında kalıcı hale gelir.
- `GetAvailableBooksAsync` yalnızca `IsAvailable == true` olan kayıtları filtreler.
- `GetByISBNAsync` ilk eşleşeni döner; birden fazla eşleşme durumunda ilk kayıt gelir.
- `DeleteAsync` kitap bulunamazsa sessizce çıkar; exception fırlatmaz.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden `IBookRepository` olarak çözümlenir; Application/Service katmanı veya API controller’larca çağrılması beklenir.
- **Aşağı akış:** `LibraryDbContext`, EF Core (`DbSet<Book>`, LINQ, `SaveChangesAsync`).
- **İlişkili tipler:** `Book` (Domain entity), `IBookRepository` (Domain arayüzü), `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- Toplu işlemler veya transaction yönetimi yok; her çağrıda `SaveChangesAsync` yapılması birim-iş (Unit of Work) deseninden sapma olabilir.
- `UpdateAsync` ve `DeleteAsync` için eşzamanlılık (concurrency) veya bulunamayan kayıtlar için geri bildirim yok; üst katmanda hata yönetimi gerekebilir.

---
Genel Değerlendirme
Kod, Domain ve Infrastructure ayrımını takip eden yalın bir repository uygulaması sunuyor. EF Core doğrudan repository içinde kullanılmakta; Unit of Work veya ayrı bir transaction katmanı görünmüyor. Concurrency, hata yönetimi ve validasyon sorumlulukları üst katmanlara bırakılmış. Konfigürasyon, hedef framework ve ek projeler bu veri setinde görünmüyor; tam mimari resmi tamamlamak için `LibraryDbContext`, Domain model ve olası Application/API katmanlarının incelenmesi önerilir.### Project Overview
Proje adı: Library. Amaç: kütüphane müşterileriyle ilgili veri erişim işlemlerini gerçekleştirmek (müşteri sorgulama ve CRUD). Hedef çerçeve: .NET (tam sürüm bu dosyadan anlaşılmıyor).

Mimari desen: Clean Architecture eğilimli katmanlama. Domain katmanında entity ve repository kontratları, Infrastructure katmanında EF Core tabanlı repository implementasyonu bulunuyor.

Projeler/Assembly’ler:
- Library.Domain — Entity’ler (`Customer`) ve kontratlar (`ICustomerRepository`)
- Library.Infrastructure — Veri erişimi ve persistans (`CustomerRepository`, `LibraryDbContext`)

Kullanılan dış paketler/çatı:
- Microsoft.EntityFrameworkCore — EF Core ile DbContext ve async LINQ uzantıları

Yapılandırma gereksinimleri:
- Veritabanı bağlantı dizesi ve EF Core sağlayıcı ayarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
[Library.Infrastructure] --> [Library.Domain]

---

### `Library.Infrastructure/Repositories/CustomerRepository.cs`

**1. Genel Bakış**
`CustomerRepository`, `ICustomerRepository` kontratını EF Core kullanarak uygular; müşteri varlıkları için okuma/yazma operasyonlarını gerçekleştirir. Mimari olarak Infrastructure katmanına aittir ve `LibraryDbContext` üzerinden kalıcı depolamaya erişir.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `Library.Domain.Interfaces.ICustomerRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Customer` set’i üzerinde CRUD ve sorgular

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public CustomerRepository(LibraryDbContext context)` | DbContext bağımlılığını alır. |
| GetByIdAsync | `public Task<Customer?> GetByIdAsync(Guid id)` | Kimliğe göre müşteriyi döner; yoksa `null`. |
| GetAllAsync | `public Task<IEnumerable<Customer>> GetAllAsync()` | Tüm müşterileri listeler. |
| GetByEmailAsync | `public Task<Customer?> GetByEmailAsync(string email)` | E-postaya göre ilk eşleşeni döner; yoksa `null`. |
| GetByMembershipNumberAsync | `public Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Üyelik numarasına göre ilk eşleşeni döner; yoksa `null`. |
| GetActiveCustomersAsync | `public Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | `IsActive` olan müşterileri listeler. |
| AddAsync | `public Task AddAsync(Customer entity)` | Yeni müşteri ekler ve `SaveChangesAsync` çağırır. |
| UpdateAsync | `public Task UpdateAsync(Customer entity)` | Var olan müşteriyi günceller ve `SaveChangesAsync` çağırır. |
| DeleteAsync | `public Task DeleteAsync(Guid id)` | Kimliğe göre müşteriyi siler; varsa `SaveChangesAsync` çağırır. |

**5. Temel Davranışlar ve İş Kuralları**
- Okuma yöntemleri EF Core sorgularıyla ilk eşleşeni veya liste döner; bulunamazsa `null`.
- `GetActiveCustomersAsync` sadece `IsActive == true` kayıtlarını döner.
- Yazma işlemleri (`AddAsync`, `UpdateAsync`, `DeleteAsync`) her çağrıda `SaveChangesAsync` ile kalıcılaşır.
- `DeleteAsync`, müşteri bulunamazsa sessizce no-op yapar (exception fırlatmaz).
- Hata yönetimi veya transaction kapsamı bu sınıfta özel olarak tanımlı değil; EF Core varsayılan davranışları geçerlidir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden çözümlenir (servis katmanı veya uygulama katmanı tüketir).
- Aşağı akış: `LibraryDbContext`, EF Core (`DbSet<Customer>`, `FindAsync`, `ToListAsync`, `FirstOrDefaultAsync`).
- İlişkili tipler: `Customer`, `ICustomerRepository`, `LibraryDbContext`.

**7. Eksikler ve Gözlemler**
- `DeleteAsync` için bulunamayan kimlikte sessiz no-op, çağıran taraf geri bildirim alamaz; bu durum iş kuralı gereği tartışmalı olabilir.
- Her yazma işleminde anında `SaveChangesAsync` çağrısı Unit of Work yaklaşımıyla tutarsız olabilir; toplu işlem senaryolarında transaction yönetimi eksik kalabilir.

---

Genel Değerlendirme
- Katmanlaşma Clean Architecture ilkelerine uyumlu görünüyor (Domain kontrat, Infrastructure implementasyon).
- Unit of Work/transaction yönetimi merkezi bir noktadan ele alınmıyor; her repo çağrısında `SaveChangesAsync` çağrısı ölçeklenebilirlik ve tutarlılık açısından gözden geçirilmeli.
- Konfigürasyon, sağlayıcı seçimi ve bağlantı dizesi bu görünümde belirsiz; Infrastructure başlatımı ve DI kayıtları dokümante edilmeli.### Project Overview
Proje adı: Library (çıkarım)
Amaç: Kitap varlıkları için depo (repository) işlemlerini sağlamak; özellikle bellek içi (in-memory) bir `IBookRepository` implementasyonu.
Hedef framework: Bu dosyadan anlaşılmıyor.
Mimari örüntü: Katmanlı/Clean Architecture etkileri — Domain (çekirdek model ve kontratlar) ile Infrastructure (kalıcılık/altyapı implementasyonları) ayrımı.
Keşfedilen projeler/assembly’ler:
- Library.Domain — Çekirdek domain: `Book` entity’si ve `IBookRepository` kontratı.
- Library.Infrastructure — Altyapı katmanı: `InMemoryBookRepository` ile domain kontratlarının in-memory implementasyonu.
Kullanılan dış paketler/çerçeveler: Bu dosyadan anlaşılmıyor (yalnızca BCL kullanılmakta).
Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (in-memory implementasyon herhangi bir connection string gerektirmez).

### Architecture Diagram
Library.Infrastructure.Repositories -> Library.Domain.Interfaces  
Library.Infrastructure.Repositories -> Library.Domain.Entities

---
### `Library.Infrastructure/Repositories/InMemoryBookRepository.cs`

**1. Genel Bakış**
`InMemoryBookRepository`, `IBookRepository` arayüzünün bellek içi bir implementasyonudur. Testler, prototipler veya kalıcı depolama olmadan hızlı geliştirme için kullanılır. Mimari olarak Infrastructure katmanına aittir ve Domain’deki `Book` entity’si ile `IBookRepository` kontratını uygular.

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
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Id’ye göre kitabı bulur; yoksa `null` döner. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Tüm kitap koleksiyonunu döner. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | `IsAvailable == true` olan kitapları filtreler. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | ISBN’e göre kitabı bulur; yoksa `null` döner. |
| AddAsync | `Task AddAsync(Book entity)` | Kitabı listeye ekler. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Id eşleşirse kaydı günceller; bulunamazsa sessizce geçer. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id’ye göre kitabı siler; bulunamazsa sessizce geçer. |

**5. Temel Davranışlar ve İş Kuralları**
- Tüm metotlar asenkron imza taşır ancak bellek içi işlemler `Task.FromResult`/`Task.CompletedTask` ile tamamlanır.
- `GetAvailableBooksAsync` yalnızca `IsAvailable` true olanları döner.
- `UpdateAsync` ve `DeleteAsync` hedef kayıt bulunamazsa exception fırlatmaz; hiçbir işlem yapmadan tamamlanır.
- Liste tabanlı depolama; kalıcılık yok ve eşzamanlılık güvenliği sağlanmıyor (thread-safe değil).
- `GetAllAsync` alttaki listeyi `IEnumerable<Book>` olarak döner; dışarıdan değiştirilemez ancak aynı referansı paylaşır.

**6. Bağlantılar**
- **Yukarı akış:** DI üzerinden çözümlenir; `IBookRepository`’yi tüketen servisler/uygulama katmanı bileşenleri.
- **Aşağı akış:** Harici bağımlılık yok; dahili olarak `List<Book>` kullanır.
- **İlişkili tipler:** `Library.Domain.Entities.Book`, `Library.Domain.Interfaces.IBookRepository`

**7. Eksikler ve Gözlemler**
- Eşzamanlı erişim için kilitleme/koleksiyon güvenliği yok; çoklu iş parçacığında tutarsızlık riski.
- `AddAsync` için benzersiz `ISBN` kontrolü veya yinelenen kayıt önleme yok.
- Güncelle/sil operasyonlarında bulunamayan kayıt durumunda geribildirim/exception yok; bu, çağıran için belirsizlik yaratabilir.

---
Genel Değerlendirme
- Kod, Domain ve Infrastructure ayrımıyla basit bir katmanlı/Clean Architecture yaklaşımını işaret ediyor.
- Altyapı implantasyonu test/demolar için uygun; üretim senaryolarında kalıcı depolama, eşzamanlılık kontrolü ve hata yönetimi eklenmeli.
- Dış bağımlılık ve konfigürasyon görünmüyor; bu, in-memory senaryolar için normaldir ancak gerçek depo adaptörü (ör. EF Core) ile genişletilmesi beklenir.### Project Overview
Proje adı koddan “Library” olarak anlaşılmaktadır. Amaç, bir kütüphane domain’ine ait personel (“staff”) verilerini EF Core üzerinden kalıcı katmana erişen repository ile yönetmektir. Hedef framework bu dosyadan anlaşılmıyor. Mimari olarak Domain ve Infrastructure katmanları görülüyor; Infrastructure, EF Core tabanlı veri erişimi sağlar ve Domain’daki entity ve interface’leri uygular. Keşfedilen projeler/assembly’ler: 
- Library.Domain — `Staff` entity’si ve `IStaffRepository` kontratı
- Library.Infrastructure — EF Core ile repository implementasyonları ve `LibraryDbContext`

Kullanılan dış bağımlılıklar: Microsoft Entity Framework Core. Konfigürasyon gereksinimleri (connection string, appsettings anahtarları) bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library.Infrastructure (Repositories, Data) --> Library.Domain (Entities, Interfaces)

---
### `Library.Infrastructure/Repositories/StaffRepository.cs`

**1. Genel Bakış**
`StaffRepository`, `IStaffRepository` sözleşmesini EF Core kullanarak uygular ve `Staff` varlıkları için temel CRUD ve sorgu işlemlerini sunar. Infrastructure katmanında yer alır ve Domain katmanındaki entity ve arayüze dayanır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** Yok
- **Uygular:** `IStaffRepository`
- **Namespace:** `Library.Infrastructure.Repositories`

**3. Bağımlılıklar**
- `LibraryDbContext` — EF Core DbContext; `Staff` DbSet’i üzerinden veri erişimi

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `StaffRepository(LibraryDbContext context)` | DbContext’i DI ile alır. |
| GetByIdAsync | `Task<Staff?> GetByIdAsync(Guid id)` | Id’ye göre tek bir `Staff` döner. |
| GetAllAsync | `Task<IEnumerable<Staff>> GetAllAsync()` | Tüm `Staff` kayıtlarını listeler. |
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | E-posta adresine göre ilk eşleşeni döner. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | `IsActive == true` olan personelleri listeler. |
| AddAsync | `Task AddAsync(Staff entity)` | Yeni `Staff` ekler ve kaydeder. |
| UpdateAsync | `Task UpdateAsync(Staff entity)` | Var olan `Staff` kaydını günceller ve kaydeder. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Id’ye göre `Staff` var ise siler ve kaydeder. |

**5. Temel Davranışlar ve İş Kuralları**
- Okuma operasyonları EF Core LINQ sorguları ile gerçekleştirilir; `GetAllAsync` ve aktif filtreli listeleme sağlar.
- Yazma operasyonlarının her birinde `SaveChangesAsync()` çağrılır; işlem bazlı kaydetme tercih edilmiştir.
- `DeleteAsync` varlık bulunamazsa sessizce çıkış yapar; exception fırlatılmaz.
- `UpdateAsync` doğrudan `Update` kullanır; detached entity’ler için tüm alanları değişmiş kabul edilebilir.

**6. Bağlantılar**
- Yukarı akış: DI üzerinden `IStaffRepository` tüketicileri (servisler veya uygulama katmanı) tarafından çağrılır.
- Aşağı akış: `LibraryDbContext`, `DbSet<Staff>` ve EF Core altyapısı.
- İlişkili tipler: `Staff` (Domain entity), `IStaffRepository` (Domain arayüzü), `LibraryDbContext` (Infrastructure data).

**7. Eksikler ve Gözlemler**
- Async EF Core çağrılarında `CancellationToken` desteği yok.
- Her operasyon kendi içinde `SaveChangesAsync()` çağırıyor; birim-iş (Unit of Work) veya çoklu işlem senaryolarında esneklik sınırlı olabilir. 

### Genel Değerlendirme
Kod, klasik repository desenini EF Core ile uygular ve Domain-Infrastructure ayrımını korur. Katman bağımlılık yönü doğru (Infrastructure -> Domain). Gözle görülür şekilde transaction kapsamı ve birim-iş deseni yok; çok adımlı işlemler için merkezi kaydetme stratejisi düşünülmeli. `CancellationToken` desteğinin eklenmesi ve olası eşzamanlılık (concurrency) stratejisinin belirlenmesi faydalı olacaktır. Hedef framework, konfigürasyon ve diğer katmanlar (Application/API) bu dosyadan anlaşılamıyor.### Project Overview
Proje adı, koddan anlaşıldığı kadarıyla “Library” sunum katmanı (ASP.NET Core Web API). Amaç, kitap kategorileri için HTTP uç noktaları sağlamaktır. Hedef çatı .NET (ASP.NET Core) olup kesin sürüm bu dosyadan anlaşılamıyor. Mimari olarak Presentation (API) katmanı `Library.Application` katmanındaki servis ve DTO’ları kullanıyor.

Mimari desen: N‑Tier
- Presentation/API: `Library` (Controller’lar; HTTP endpoint’leri)
- Application: `Library.Application` (DTO’lar, servis kontratları)

Keşfedilen projeler/assembly’ler:
- Library: API sunumu, controller’lar
- Library.Application: Uygulama katmanı; `DTO` ve `Service` arayüzleri

Harici paketler/çerçeveler:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)

Yapılandırma gereksinimleri:
- Bu dosyadan görünen özel konfigürasyon anahtarı veya connection string yok.

### Architecture Diagram
Library (API/Presentation) --> Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/BookCategoriesController.cs`

**1. Genel Bakış**
`BookCategoriesController`, kitap kategorileri için okuma odaklı HTTP endpoint’leri sağlar. Presentation/API katmanına aittir ve uygulama katmanındaki `IBookCategoryService` üzerinden veri erişimini soyutlar.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookCategoryService` — Kategori verileri için uygulama katmanı servisi (listeleme ve tekil getirme)

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Oluşturucu | `BookCategoriesController(IBookCategoryService categoryService)` | Servis bağımlılığını enjekte eder. |
| GetAll | `Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Tüm kategori kayıtlarını döner; `200 OK` ile `IEnumerable<BookCategoryDto>`. |
| GetById | `Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | ID ile kategori getirir; yoksa `404 NotFound`, varsa `200 OK`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GET /api/BookCategories`: Tüm kategorileri asenkron döner.
- `GET /api/BookCategories/{id:guid}`: `Guid` formatı zorunlu; sonuç `null` ise `NotFound` döner.
- Girdi doğrulaması ve hata yönetimi bu dosyada tanımlı değil; servis katmanına delege edildiği varsayılır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (ör. frontend, API tüketicileri)
- **Aşağı akış:** `IBookCategoryService`
- **İlişkili tipler:** `BookCategoryDto`, `IBookCategoryService`

**7. Eksikler ve Gözlemler**
- CRUD’a göre eksikler: `POST`, `PUT/PATCH`, `DELETE` endpoint’leri yok.
- Authorization/Authentication öznitelikleri yok; yetkilendirme gereksinimi belirsiz.
- `CancellationToken` desteği yok; uzun süren işlemler için iptal desteği eklenebilir.
- Hata yönetimi (ör. servis istisnaları) için merkezi bir politika veya try-catch görünmüyor.

Genel Değerlendirme
- Katmanlaşma net: API, Application katmanına bağımlı. Ancak yalnızca okuma uçları mevcut; yazma operasyonları eksik.
- Çapraz kesen kaygılar (yetkilendirme, hata işleme, logging, iptal belirteci) görünür değil; projede varsa filtre/middleware seviyesinde olabilir, bu dosyadan anlaşılmıyor.
- DTO ve servis arayüzü kullanımı iyi bir ayrışım sağlıyor; ancak sözleşmeye ait validasyon ve hata durumlarının ele alınışı API yüzeyinde standardize edilmemiş görünüyor.### Project Overview
Proje adı: Library (ASP.NET Core API). Amaç: Kitaplar için CRUD ve sorgulama uç noktaları sağlamak. Hedef çatı: ASP.NET Core Web API (tam .NET sürümü bu dosyadan anlaşılmıyor).

Mimari: N‑Katmanlı bir düzen izleniyor gibi görünüyor:
- Presentation/API: `Library.Controllers` altında web uç noktaları.
- Application: `Library.Application.DTOs` ve `Library.Application.Interfaces` kullanımıyla servis sözleşmeleri ve DTO’lar.

Keşfedilen projeler/assembly’ler:
- Library: Web API katmanı (Controllers).
- Library.Application: Uygulama sözleşmeleri (interfaces) ve DTO’lar.

Dış bağımlılıklar:
- `Microsoft.AspNetCore.Mvc` (ASP.NET Core MVC/Web API).

Konfigürasyon:
- Bu dosyada özel bir konfigürasyon gereksinimi görünmüyor (connection string veya appsettings anahtarı belirtilmemiş).

### Architecture Diagram
Library (API/Presentation) --> Library.Application (Interfaces, DTOs)

---
### `Library/Controllers/BooksController.cs`

**1. Genel Bakış**
`BooksController`, kitaplara yönelik HTTP uç noktalarını sunar: listeleme, tekil getirme, uygun/available kitaplar, oluşturma, güncelleme ve silme. Presentation/API katmanında yer alır ve iş kurallarını `IBookService` üzerinden Uygulama katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IBookService` — Kitaplara yönelik uygulama hizmeti; CRUD ve sorgulama operasyonları.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public BooksController(IBookService bookService)` | Servis bağımlılığını DI ile alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | Tüm kitapları döndürür, `200 OK`. |
| GetById | `public async Task<ActionResult<BookDto>> GetById(Guid id)` | ID’ye göre kitabı getirir; yoksa `404 NotFound`. |
| GetAvailable | `public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | Uygun/erişilebilir kitapları döndürür, `200 OK`. |
| Create | `public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | Kitap oluşturur; `201 Created` ve `Location` header ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | Kitabı günceller; yoksa `404`, başarıda `204 NoContent`. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Kitabı siler; sonuçta `204 NoContent`. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound()` üretir.
- `Create`: Başarılı oluşturma sonrası `CreatedAtAction` ile yeni kaynağın konumunu bildirir.
- `Update`: `IBookService.UpdateAsync` sırasında `KeyNotFoundException` yakalanır ve `404 NotFound` döner; aksi halde `204 NoContent`.
- `Delete`: Her durumda `204 NoContent` döner; var olmayan kayıt için özel bir hata eşlemesi yok (servis tarafı davranışı bu dosyadan anlaşılmıyor).
- Model doğrulaması için sadece `[ApiController]` özniteliğinin sağladığı otomatik model state denetimleri kullanılır; ilave doğrulama mantığı controller’da yok.
- Yetkilendirme/kimlik doğrulama öznitelikleri tanımlı değil.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (API tüketicileri).
- **Aşağı akış:** `IBookService`.
- **İlişkili tipler:** `BookDto`, `CreateBookDto`, `UpdateBookDto`, `IBookService`.

**7. Eksikler ve Gözlemler**
- `Delete` için var olmayan kaynakta nasıl davranıldığı controller seviyesinde yönetilmiyor; tutarlı bir `404 NotFound` haritalaması eksik olabilir.
- Güvenlik: Herhangi bir `[Authorize]` niteliği veya yetkilendirme yok; korumalı olması gereken uç noktalar için risk oluşturabilir.
- Hata yönetimi: Genel istisna yakalama/standart problem detayları için global exception handling veya `ProblemDetails` kullanımı görünmüyor.

---
### Genel Değerlendirme
Kod, API katmanının Application katmanına arayüzler ve DTO’lar üzerinden bağlandığını gösteriyor; bu, katmanlı bir mimariye işaret ediyor. Controller basit ve sorumlulukları uygun şekilde delege ediyor. İyileştirme alanları: silme operasyonunda tutarlı bulunamadı senaryosu yönetimi, merkezi hata/yakalama politikası, yetkilendirme eklenmesi ve giriş doğrulamalarının (ör. `Update` ve `Create` için) daha açık kurallarla güçlendirilmesi. Ayrıca, loglama ve problem ayrıntıları için standart bir middleware kullanımı faydalı olabilir.### Project Overview
- Proje adı: Library (çıkarım: `Library` ve `Library.Application` ad alanlarından)
- Amaç: Müşteri (customer) varlıklarına yönelik HTTP tabanlı CRUD ve sorgulama uç noktaları sağlayan bir ASP.NET Core Web API sunmak.
- Hedef çatı/TFM: ASP.NET Core Web API (kesin .NET sürümü bu dosyadan anlaşılmıyor).
- Mimari desen: N‑Katmanlı yaklaşım
  - Presentation/API: `Library` (Controllers) — HTTP uç noktaları, model binding, HTTP yanıtları
  - Application: `Library.Application` — DTO’lar (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`) ve servis kontratları (`ICustomerService`)
  - Domain/Infrastructure: Bu dosyadan anlaşılmıyor (referanslar görünmüyor).
- Projeler/Assembly’ler:
  - Library — Web API sunumu
  - Library.Application — Uygulama katmanı kontrat ve DTO’ları
- Dış bağımlılıklar:
  - ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`)
- Konfigürasyon gereksinimleri: Bu dosyadan anlaşılmıyor (connection string veya appsettings anahtarı görünmüyor).

### Architecture Diagram
Presentation/API (Library.Controllers)
  ↓ depends on
Application (Library.Application.Interfaces, Library.Application.DTOs)
  ↓ (muhtemel, bu dosyadan görünmüyor)
Domain / Infrastructure

---
### `Library/Controllers/CustomersController.cs`

**1. Genel Bakış**
`CustomersController`, müşteri verileri için RESTful uç noktaları sağlayan API katmanı denetleyicisidir. Listeleme, tekil getirme, aktifleri getirme, oluşturma, güncelleme ve silme işlemlerini `ICustomerService` üzerinden delege eder. Presentation/API katmanında yer alır.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `ICustomerService` — Müşteri CRUD ve sorgulama işlemlerini yürüten uygulama servisi

**4. Public API**
| Üye | İmza | Açıklama |
|---|---|---|
| Constructor | `public CustomersController(ICustomerService customerService)` | Servis bağımlılığını alır. |
| GetAll | `public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Tüm müşterileri döner. |
| GetById | `public async Task<ActionResult<CustomerDto>> GetById(Guid id)` | ID’ye göre müşteri döner; yoksa 404. |
| GetActive | `public async Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Aktif müşterileri döner. |
| Create | `public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Yeni müşteri oluşturur; 201 ve Location header ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Mevcut müşteriyi günceller; başarıda 204, bulunamazsa 404. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Müşteriyi siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById`: Servis `null` dönerse `NotFound (404)` yanıtı verir.
- `Create`: `CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer)` ile 201 ve kaynak konumu üretir.
- `Update`: `KeyNotFoundException` yakalanırsa `NotFound (404)` döner; aksi halde `NoContent (204)`.
- `Delete`: Her durumda `NoContent (204)` döner; silinecek kayıt yoksa davranış servis implementasyonuna bağlıdır.
- Rotalar: `[Route("api/[controller]")]`, eylem bazlı `[HttpGet]`, `[HttpGet("{id:guid}")]`, `[HttpGet("active")]`, `[HttpPost]`, `[HttpPut("{id:guid}")]`, `[HttpDelete("{id:guid}")]`.
- Model binding: `Create` ve `Update` gövdeden (`[FromBody]`) DTO alır.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (örn. frontend, Postman) bu controller’ı çağırır.
- **Aşağı akış:** `ICustomerService`
- **İlişkili tipler:** `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`, `ICustomerService`

**7. Eksikler ve Gözlemler**
- Authorization/Authentication öznitelikleri yok; tüm uç noktalar herkese açık görünüyor.
- `Delete` için bulunamayan kayıt senaryosunda özel hata eşlemesi yok; davranış servis katmanına bırakılmış.

---
Genel Değerlendirme
- Kod, Presentation (API) ve Application katmanları ayrımını net gösteriyor; Domain/Infrastructure görünmüyor.
- Controller yalın ve görevini servis katmanına delege ediyor; hata haritalama kısmen mevcut (Update 404), diğer uç noktalarda tutarlılık artırılabilir (ör. Delete için bulunamayan kaynak 404).
- Güvenlik açısından yetkilendirme/kimlik doğrulama yok; üretim ortamı için uygun policy/role tabanlı koruma eklenmeli.
- Girdi doğrulaması ve problem details üretimi için `ApiController` model doğrulama davranışı mevcut; ancak DTO üzerinde validation attribute’ları bu dosyadan anlaşılmıyor.### Project Overview
Proje adı: Library. Amaç: Kütüphane personeli (staff) yönetimi için HTTP API uç noktaları sağlamak. Hedef çatı: ASP.NET Core Web API (versiyon bu dosyadan anlaşılmıyor). Mimari olarak en azından API (Presentation) ve Application katmanları ayrışmış; controller doğrudan `Library.Application` altındaki servis ve DTO’ları kullanıyor.

Mimari desen: N‑Tier (Presentation → Application). Controller, iş kurallarını Application servislerine deleg eder; veri erişim/altyapı katmanı bu dosyadan görünmüyor.

Projeler/Assembly’ler:
- Library (API/Presentation) — ASP.NET Core controller’ları barındırır.
- Library.Application (Application) — `DTO` ve `Service` kontratlarını barındırır.

Dış bağımlılıklar:
- ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`) — Web API altyapısı ve model binding.

Yapılandırma gereksinimleri:
- Bu dosyadan görülen özel appsettings veya connection string anahtarı yok.

### Architecture Diagram
Library (API/Presentation) → Library.Application (DTOs, Interfaces)

---
### `Library/Controllers/StaffController.cs`

**1. Genel Bakış**
`StaffController`, personel (staff) varlıklarına yönelik CRUD ve filtrelenmiş okuma işlemleri için HTTP uç noktaları sağlar. API/Presentation katmanına aittir ve iş kurallarını `IStaffService` üzerinden Application katmanına delege eder.

**2. Tip Bilgisi**
- **Tip:** class
- **Miras:** `ControllerBase`
- **Uygular:** Yok
- **Namespace:** `Library.Controllers`

**3. Bağımlılıklar**
- `IStaffService` — Personel verilerine yönelik iş mantığı ve veri erişimi operasyonlarını sağlayan uygulama servisi.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|
| Ctor | `public StaffController(IStaffService staffService)` | Uygulama servis bağımlılığını enjekte eder. |
| GetAll | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Tüm personel listesini döner. |
| GetById | `public async Task<ActionResult<StaffDto>> GetById(Guid id)` | ID ile personeli getirir; yoksa 404 döner. |
| GetActive | `public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Aktif personel listesini döner. |
| Create | `public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Yeni personel oluşturur; 201 ve `Location` ile döner. |
| Update | `public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Personeli günceller; başarıda 204, bulunamazsa 404. |
| Delete | `public async Task<IActionResult> Delete(Guid id)` | Personeli siler; 204 döner. |

**5. Temel Davranışlar ve İş Kuralları**
- `GetById` bulunamayan kayıt için `NotFound()` döner.
- `Create` başarılı oluşturma sonrası `CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff)` ile 201 ve kaynak konumu üretir.
- `Update` içinde `KeyNotFoundException` yakalanır ve 404’e eşlenir.
- `Delete` hata haritalaması yapmaz; servis katmanındaki hatalar doğrudan yüzeye çıkabilir (bu dosyadan başka haritalama görünmüyor).

**DTO — davranış yok. Default değerler:**
- DTO içerikleri ve varsayılanları bu dosyadan anlaşılmıyor.

**6. Bağlantılar**
- **Yukarı akış:** HTTP istemcileri (ör. frontend, Postman) bu controller’ı çağırır.
- **Aşağı akış:** `IStaffService`
- **İlişkili tipler:** `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`, `IStaffService`

**7. Eksikler ve Gözlemler**
- Uç noktalarda yetkilendirme/kimlik doğrulama öznitelikleri yok; hassas personel verileri için güvenlik açığı oluşturabilir.
- `Delete` için bulunamayan kaynak senaryosunda 404 dönüş mantığı açıkça haritalanmamış (servis hangi exception’ı fırlatıyor bu dosyadan anlaşılmıyor).

Genel Değerlendirme
- Mimari ayrışım net: API, Application katmanına arayüz üzerinden bağımlı. Domain/Infrastructure katmanları görünmüyor; varsa dokümante edilmeli.
- Hata eşleme kısmen tutarlı (`Update` 404 map’lerken `Delete`’de benzer haritalama yok).
- Güvenlik öznitelikleri (ör. `[Authorize]`) eksik; rol bazlı yetkilendirme gereksinimleri tanımlanmalı.
- Model doğrulama öznitelikleri ve `ApiBehaviorOptions` kullanımı bu dosyadan görünmüyor; `Create`/`Update` için validasyon stratejisi net değil.### Project Overview
Proje adı: Library (ASP.NET Core Web API). Amaç: Web API barındırma, uygulama ve altyapı katmanlarını DI ile bütünleştirme ve HTTP uç noktalarını sunma. Hedef çatı: .NET 6+ (top-level statements, minimal hosting, Swagger entegrasyonundan çıkarım).

Mimari: Katmanlı (N-Tier). API/Presentation katmanı `Library` projesinde; Application hizmetleri `Library.Application` üzerinden eklenir; Infrastructure bağımlılıkları `Library.Infrastructure` ile sağlanır. API katmanı yalnızca Application’a, Application ise Infrastructure’a bağımlı olacak şekilde tasarlanmış görünür.

Projeler/Assembly’ler:
- Library (API/Presentation): ASP.NET Core Web API host ve middleware konfigürasyonu.
- Library.Application (Application): İş kuralları/servis kayıtları için DI uzantısı `AddApplication()`.
- Library.Infrastructure (Infrastructure): Veri erişimi/harici kaynaklar için DI uzantısı `AddInfrastructure(IConfiguration)`.

Dış paket/çerçeveler:
- ASP.NET Core (WebApplication host, Controllers)
- Swashbuckle/Swagger (`AddEndpointsApiExplorer`, `AddSwaggerGen`) — OpenAPI dokümantasyonu

Konfigürasyon gereksinimleri:
- `AddInfrastructure(builder.Configuration)` çağrısı yapılandırmaya ihtiyaç duyduğunu gösterir; olası bağlantı dizeleri veya sağlayıcı ayarları bu dosyadan anlaşılmıyor.

### Architecture Diagram
Library (API/Presentation)
  -> Library.Application (Application)
      -> Library.Infrastructure (Infrastructure)

---
### `Library/Program.cs`

**1. Genel Bakış**
ASP.NET Core Web API giriş noktasıdır; servis kayıtlarını gerçekleştirir, HTTP pipeline’ı kurar ve denetleyicileri haritalar. Mimari olarak Presentation/API katmanına aittir ve Application ile Infrastructure katmanlarını DI üzerinden entegre eder.

**2. Tip Bilgisi**
- Tip: Top-level statements (örtük `Program` sınıfı)
- Miras: Yok
- Uygular: Yok
- Namespace: Global (bu dosyadan anlaşılmıyor)

**3. Bağımlılıklar**
Harici bağımlılık yok.

**4. Public API**

| Üye | İmza | Açıklama |
|---|---|---|

**5. Temel Davranışlar ve İş Kuralları**
- `AddApplication()` ve `AddInfrastructure(builder.Configuration)` ile katman servisleri DI konteynerine eklenir.
- `AddControllers()`, `AddEndpointsApiExplorer()`, `AddSwaggerGen()` ile API ve Swagger/OpenAPI kurulur.
- Development ortamında `UseSwagger()` ve `UseSwaggerUI()` etkinleştirilir.
- `UseHttpsRedirection()` ile HTTPS yönlendirmesi uygulanır.
- `UseAuthorization()` eklenir; kimlik doğrulama konfigürasyonu bu dosyadan anlaşılmıyor.
- `MapControllers()` ile attribute-routed controller’lar uç noktaya bağlanır.
- `app.Run()` ile host başlatılır.

**6. Bağlantılar**
- Yukarı akış: ASP.NET Core host/runtime tarafından çalıştırılır.
- Aşağı akış: `Library.Application` ve `Library.Infrastructure` DI uzantıları; Controller uç noktaları.
- İlişkili tipler: DI uzantıları `AddApplication`, `AddInfrastructure` (uygulama ve altyapı modülleri).

**7. Eksikler ve Gözlemler**
- `UseAuthorization()` var ancak kimlik doğrulama (`UseAuthentication`/authentication scheme) yapılandırması bu dosyada görünmüyor; yetkilendirme etkisiz olabilir.
- Altyapı konfigürasyon anahtarları (ör. connection string) görünmüyor; dağıtımda eksik ayar hatalarına yol açabilir.

Genel Değerlendirme
- Katmanlı mimari net: API yalnızca Application/Infrastructure’a DI üzerinden bağlanıyor.
- Ortam temelli Swagger etkinleştirmesi doğru konumda.
- Yetkilendirme için kimlik doğrulama eksikliği potansiyel güvenlik açığıdır.
- Konfigürasyon anahtarlarına dair örnek/appsettings şeması belgelenmemiş; geliştirici deneyimi için eklenmesi faydalı olur.