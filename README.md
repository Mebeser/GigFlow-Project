# GigFlow

**GigFlow**, freelancer ekosistemini modelleyen, modern backend mimarisi prensiplerini (**Onion Architecture + CQRS**) üretim kalitesinde uygulamak amacıyla geliştirilmiş bir REST API projesidir.

---

## 🏗️ Mimari

Proje, **Onion Architecture** prensiplerine göre katmanlara ayrılmıştır. Her katman yalnızca içteki katmana bağımlıdır; bu sayede domain mantığı altyapıdan tamamen izole edilmiştir.

```
GigFlow/
├── Domain/           # Entity'ler, domain rule'lar, interface'ler
├── Application/      # CQRS Handler'lar, DTO'lar, FluentValidation
├── Infrastructure/   # JWT, harici servisler
├── Persistence/      # EF Core, DbContext, Migration'lar
└── Presentation/     # ASP.NET Core Web API, Controller'lar
```

### Neden bu mimari?

Geleneksel N-Tier mimarilerde UI veya veritabanı değiştiğinde tüm katmanlar etkilenir. Onion Architecture'da bağımlılık yönü her zaman **içe doğru** akar — domain hiçbir şeyden haberdar değildir. Bu yapı test edilebilirliği artırır ve uzun vadeli bakımı kolaylaştırır.

---

## ⚙️ Teknoloji Stack

| Katman | Teknoloji |
|---|---|
| Framework | ASP.NET Core 10 |
| ORM | Entity Framework Core 10 |
| Mimari Pattern | Onion Architecture, CQRS |
| Mediator | MediatR 14 |
| Doğrulama | FluentValidation 12 |
| Kimlik Doğrulama | JWT Bearer Token |
| Parola Güvenliği | BCrypt.Net |
| Nesne Eşleme | AutoMapper 16 |
| Veritabanı | MS SQL Server (Docker) |
| API Dokümantasyonu | OpenAPI / Swagger |

---

## 🔑 Temel Özellikler

- **Kimlik Doğrulama:** JWT tabanlı kayıt ve giriş sistemi, BCrypt ile şifrelenmiş parola yönetimi
- **Kategori & Yetenek Yönetimi:** Freelancer'ların hizmet sunduğu alan ve becerilerin yönetimi
- **Freelancer Portföy Yönetimi:** Portföy oluşturma ve güncelleme
- **İş İlanı Sistemi:** İş ilanı oluşturma, listeleme, durum yönetimi
- **Teklif Süreci:** Freelancer'ların iş ilanlarına proposal göndermesi ve işverenin değerlendirmesi
- **Sözleşme & Milestone:** Onaylanan tekliflerden sözleşme oluşturma, iş sürecinin milestone bazlı takibi
- **Değerlendirme Sistemi:** İş tamamlandığında çift yönlü review mekanizması
- **Domain Rules:** İş ilanı durumuna göre otomatik iş kuralları (Domain-Driven Design prensibi)

---

## 🚀 Kurulum

### Gereksinimler
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

### 1. Veritabanını Başlat (Docker)

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Password" \
  -p 1433:1433 --name gigflow-sql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Bağlantı Dizesini Ayarla

`Presentation/appsettings.json` dosyasını düzenle:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=GigFlowDb;User Id=sa;Password=YourStrong!Password;TrustServerCertificate=True"
  },
  "JwtSettings": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "GigFlow",
    "Audience": "GigFlowClient",
    "ExpiryMinutes": 60
  }
}
```

### 3. Migration'ları Uygula

```bash
dotnet ef database update --project Persistence --startup-project Presentation
```

### 4. Uygulamayı Çalıştır

```bash
cd Presentation
dotnet run
```

Swagger UI: `https://localhost:{port}/swagger`

---

## 📐 CQRS Yaklaşımı

Proje, okuma ve yazma işlemlerini birbirinden ayıran **CQRS (Command Query Responsibility Segregation)** pattern'ini MediatR aracılığıyla uygular.

```
// Komut örneği — veri değiştirir
CreateJobPostingCommand → CreateJobPostingHandler → IJobPostingRepository

// Sorgu örneği — yalnızca veri okur
GetActiveJobPostingsQuery → GetActiveJobPostingsHandler → IJobPostingRepository
```

Her komut ve sorgu, **FluentValidation** ile giriş doğrulamasından geçer.

---

## 📄 Lisans

MIT
