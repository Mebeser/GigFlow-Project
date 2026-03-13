




YOBODOBO
Backend Eğitimi
.NET 10 | Clean Architecture | CQRS


GigFlow
Freelancer İş Platformu
Proje Ödev Dokümantasyonu





Eğitmen: Ömer Faruk Doğan
Teknoloji: .NET 10 | Entity Framework Core | MediatR | FluentValidation
Mimari: Clean Architecture + CQRS Pattern
 
1. Proje Hakkında
GigFlow, freelancer’lar ile iş verenler (client) arasında köprü kuran bir iş platformu backend projesidir. Bu projede öğrenciler; temiz mimari (Clean Architecture), CQRS deseni, Entity Framework Core ve .NET 10 teknolojilerini kullanarak gerçek dünyaya yakın bir uygulama geliştireceklerdir.

1.1 Proje Kapsamı
Platform aşağıdaki temel iş süreçlerini kapsamaktadır:
•	Kategori ve yetenek (skill) yönetimi
•	Freelancer portföy yönetimi
•	İş ilanı oluşturma, listeleme ve yönetimi
•	Teklif (proposal) verme ve değerlendirme süreçleri
•	Sözleşme oluşturma ve milestone bazlı iş takibi
•	Değerlendirme (review) sistemi
•	İş ilanı durumlarına göre otomatik kural yönetimi (Domain Rules)

1.2 Öğrenme Hedefleri
Bu projeyi tamamlayan öğrenciler aşağıdaki konularda yetkinlik kazanacaktır:
1.	Clean Architecture katmanlarını doğru şekilde yapılandırma
2.	CQRS (Command Query Responsibility Segregation) desenini MediatR ile uygulama
3.	Entity Framework Core ile veritabanı işlemleri ve migration yönetimi
4.	Repository Pattern ve Unit of Work kavramlarını pratikte kullanma
5.	FluentValidation ile veri doğrulama kuralları yazma
6.	Domain kurallarını (business rules) entity seviyesinde uygulama
7.	RESTful API tasarımı ve controller yapılandırması
8.	AutoMapper ile DTO dönüşümleri
 
2. Mimari Yapı (Clean Architecture)
Proje, Clean Architecture prensiplerine uygun olarak 5 katmandan oluşmaktadır. Her katmanın sorumluluğu kesin sınırlarla belirlenmiştir. Bağımlılık yönü daima dıştan içe doğrudur.

2.1 Katman Yapısı ve Sorumlulukları
Katman	Sorumluluk
Domain	Entity sınıfları, enum’lar, domain kuralları (business rules), value object’ler. Hiçbir dış bağımlılığı yoktur.
Application	CQRS komutları (Commands) ve sorguları (Queries), handler’lar, validator’lar, DTO’lar, interface tanımları (repository, service). MediatR ile orchestration.
Infrastructure	Dış servis entegrasyonları (e-posta, dosya yükleme, bildirim vb.). Application katmanındaki interface’lerin dış servislere yönelik implementasyonları.
Persistence	DbContext, migration’lar, repository implementasyonları, entity configuration’lar (Fluent API). Veritabanına erişimden sorumlu tek katman.
Presentation (API)	Controller’lar, middleware’ler, Program.cs yapılandırması, Swagger. Dış dünyaya açılan tek kapı.

2.2 CQRS Yapısı (Application Katmanı)
Application katmanında tüm işlemler CQRS (Command Query Responsibility Segregation) desenine göre ayrılmaktadır. Yazma işlemleri Command, okuma işlemleri ise Query olarak modellenir. Her ikisi de MediatR aracılığıyla yönetilir.

Tip	Kullanım Alanı	Örnek Dosyalar
Command	Veri oluşturma, güncelleme, silme (CUD) işlemleri	CreateJobPostingCommand.cs, CreateJobPostingCommandHandler.cs, CreateJobPostingCommandValidator.cs
Query	Veri okuma ve listeleme (R) işlemleri	GetAllJobPostingsQuery.cs, GetAllJobPostingsQueryHandler.cs, GetJobPostingByIdQuery.cs

Her Feature (JobPostings, Proposals, Contracts vb.) için aşağıdaki klasör yapısı uygulanacaktır:

  Features/
    └── JobPostings/
        ├── Commands/
        │   ├── CreateJobPosting/
        │   │   ├── CreateJobPostingCommand.cs
        │   │   ├── CreateJobPostingCommandHandler.cs
        │   │   └── CreateJobPostingCommandValidator.cs
        │   ├── UpdateJobPosting/
        │   └── DeleteJobPosting/
        ├── Queries/
        │   ├── GetAllJobPostings/
        │   └── GetJobPostingById/
        ├── DTOs/
        └── Profiles/  (AutoMapper)

2.3 Tam Proje Klasör Yapısı
Aşağıdaki yapı, Solution Explorer’da görünen proje hiyerarşisini yansıtmaktadır:

  GigFlow.sln
  ├── GigFlow.Domain/
  │   ├── Entities/
  │   └── Enums/
  ├── GigFlow.Application/
  │   ├── Features/
  │   │   ├── Categories/
  │   │   ├── Skills/
  │   │   ├── JobPostings/
  │   │   ├── Proposals/
  │   │   ├── Contracts/
  │   │   ├── Milestones/
  │   │   ├── Reviews/
  │   │   └── Portfolios/
  │   ├── Repositories/  (Interfaces)
  │   └── ApplicationServiceRegistration.cs
  ├── GigFlow.Infrastructure/
  │   └── (Dış servis implementasyonları)
  ├── GigFlow.Persistence/
  │   ├── Contexts/
  │   ├── Migrations/
  │   ├── Repositories/
  │   ├── Configurations/  (Fluent API)
  │   └── PersistenceServiceRegistration.cs
  └── GigFlow.Presentation/
      ├── Controllers/
      ├── Program.cs
      └── appsettings.json
 
3. Entity Tabloları ve Veritabanı Şeması
Aşağıda projedeki tüm entity’lerin alan tanımları, veri tipleri ve ilişkileri detaylı olarak verilmiştir. Tüm entity’ler BaseEntity sınıfından türetilecektir.

BaseEntity (Soyut Sınıf)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	Primary Key, otomatik üretilir
CreatedDate	DateTime	Kayıt oluşturulma tarihi
UpdatedDate	DateTime?	Son güncelleme tarihi (nullable)

Category (Kategori)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
Name	string (100)	Zorunlu, benzersiz
Description	string (500)	Opsiyonel
ParentCategoryId	Guid?	FK → Category (self-referencing, nullable)
SubCategories	ICollection<Category>	Navigation: alt kategoriler
Skills	ICollection<Skill>	Navigation: kategoriye ait yetenekler
JobPostings	ICollection<JobPosting>	Navigation: kategoriye ait ilanlar

Skill (Yetenek)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
Name	string (100)	Zorunlu, benzersiz
CategoryId	Guid	FK → Category (zorunlu)
Category	Category	Navigation property
JobPostingSkills	ICollection<JobPostingSkill>	Navigation: bu yeteneğe sahip ilanlar

JobPosting (İş İlanı)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
Title	string (200)	Zorunlu
Description	string (5000)	Zorunlu, detaylı açıklama
CategoryId	Guid	FK → Category
BudgetMin	decimal(18,2)	Minimum bütçe
BudgetMax	decimal(18,2)	Maksimum bütçe (BudgetMin’den büyük olmalı)
BudgetType	BudgetType (enum)	Fixed = 0, Hourly = 1
Duration	ProjectDuration (enum)	Short = 0, Medium = 1, Long = 2
ExperienceLevel	ExperienceLevel (enum)	Entry = 0, Intermediate = 1, Expert = 2
Status	JobStatus (enum)	Open = 0, InProgress = 1, Completed = 2, Cancelled = 3
ClientId	Guid?	FK → ClientProfile (üyelik sistemi eklenince zorunlu)
Deadline	DateTime?	Başvuru son tarihi
Category	Category	Navigation property
JobPostingSkills	ICollection<JobPostingSkill>	Navigation: aranan yetenekler
Proposals	ICollection<Proposal>	Navigation: gelen teklifler

 
JobPostingSkill (İlan-Yetenek İlişkisi / Many-to-Many)
Alan Adı	Veri Tipi	Açıklama / Kısıt
JobPostingId	Guid	Composite PK, FK → JobPosting
SkillId	Guid	Composite PK, FK → Skill
JobPosting	JobPosting	Navigation property
Skill	Skill	Navigation property

Proposal (Teklif)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
JobPostingId	Guid	FK → JobPosting
FreelancerId	Guid?	FK → FreelancerProfile (üyelik sonrası zorunlu)
CoverLetter	string (3000)	Zorunlu, teklif açıklaması
ProposedAmount	decimal(18,2)	Teklif edilen tutar (> 0)
EstimatedDuration	int	Tahmini süre (gün cinsinden)
Status	ProposalStatus (enum)	Pending = 0, Accepted = 1, Rejected = 2, Withdrawn = 3
JobPosting	JobPosting	Navigation property

Contract (Sözleşme)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
JobPostingId	Guid	FK → JobPosting
ProposalId	Guid	FK → Proposal
FreelancerId	Guid	Sözleşmedeki freelancer
ClientId	Guid	Sözleşmedeki iş veren
TotalAmount	decimal(18,2)	Toplam sözleşme tutarı
StartDate	DateTime	Sözleşme başlangıç tarihi
EndDate	DateTime?	Sözleşme bitiş tarihi
Status	ContractStatus (enum)	Active = 0, Completed = 1, Cancelled = 2, Disputed = 3
Milestones	ICollection<Milestone>	Navigation: sözleşme aşamaları
Reviews	ICollection<Review>	Navigation: değerlendirmeler

Milestone (Sözleşme Aşaması)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
ContractId	Guid	FK → Contract
Title	string (200)	Zorunlu
Description	string (2000)	Aşama açıklaması
Amount	decimal(18,2)	Aşama ödemesi (> 0)
DueDate	DateTime	Teslim tarihi
Status	MilestoneStatus (enum)	Pending = 0, InProgress = 1, Submitted = 2, Approved = 3, Rejected = 4
Order	int	Sıralama numarası (1, 2, 3...)
Contract	Contract	Navigation property

 
Review (Değerlendirme)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
ContractId	Guid	FK → Contract
ReviewerId	Guid	Değerlendirmeyi yapan kişi
RevieweeId	Guid	Değerlendirilen kişi
Rating	int	1–5 arası puan (zorunlu)
Comment	string (2000)	Yorum metni
Contract	Contract	Navigation property

Portfolio (Portföy)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
FreelancerId	Guid	Portföy sahibi freelancer
Title	string (200)	Zorunlu, proje başlığı
Description	string (3000)	Proje açıklaması
ProjectUrl	string (500)?	Canlı proje linki (opsiyonel)
ImageUrl	string (500)?	Görsel URL (opsiyonel)


3.1 Enum Tanımları
Aşağıdaki enum’lar Domain katmanında Enums/ klasörü altında tanımlanacaktır:

Enum Adı	Değerler	Kullanım Yeri
BudgetType	Fixed = 0, Hourly = 1	JobPosting.BudgetType
ProjectDuration	Short = 0, Medium = 1, Long = 2	JobPosting.Duration
ExperienceLevel	Entry = 0, Intermediate = 1, Expert = 2	JobPosting.ExperienceLevel
JobStatus	Open = 0, InProgress = 1, Completed = 2, Cancelled = 3	JobPosting.Status
ProposalStatus	Pending = 0, Accepted = 1, Rejected = 2, Withdrawn = 3	Proposal.Status
ContractStatus	Active = 0, Completed = 1, Cancelled = 2, Disputed = 3	Contract.Status
MilestoneStatus	Pending = 0, InProgress = 1, Submitted = 2, Approved = 3, Rejected = 4	Milestone.Status

3.2 Entity İlişki Haritası
Aşağıdaki ilişkiler Fluent API ile Persistence katmanında Configurations/ klasörü altında yapılandırılacaktır:

•	Category → Skill: Bire-çok (HasMany)
•	Category → Category: Self-referencing bire-çok (ParentCategory)
•	Category → JobPosting: Bire-çok
•	JobPosting ↔ Skill: Çoğa-çok (JobPostingSkill ara tablosu ile)
•	JobPosting → Proposal: Bire-çok
•	Proposal → Contract: Bire-bir
•	Contract → Milestone: Bire-çok
•	Contract → Review: Bire-çok
 
4. Domain Kuralları (Business Rules)
Aşağıdaki iş kuralları entity sınıfları içinde veya Application katmanında validator’lar aracılığıyla uygulanacaktır:

4.1 İş İlanı Kuralları
1.	BudgetMax değeri BudgetMin’den büyük veya eşit olmalıdır.
2.	Status = Cancelled olan bir ilana teklif gönderilemez.
3.	Status = Completed olan bir ilan güncellenemez.
4.	Bir ilanda en az 1, en fazla 10 skill seçilebilir.
5.	Deadline geçmiş bir ilana teklif yapılamaz.
4.2 Teklif Kuralları
1.	Aynı freelancer aynı ilana birden fazla teklif gönderemez.
2.	ProposedAmount 0’dan büyük olmalıdır.
3.	Bir teklif kabul edildiğinde (Accepted), aynı ilandaki diğer teklifler otomatik olarak Rejected yapılır.
4.	Status = Withdrawn olan bir teklif tekrar aktif yapılamaz.
4.3 Sözleşme Kuralları
1.	Sözleşme sadece Accepted durumundaki bir tekliften oluşturulabilir.
2.	Bir teklif için sadece bir sözleşme oluşturulabilir.
3.	Sözleşme oluşturulduğunda ilanın status’ü InProgress olarak güncellenir.
4.	Cancelled bir sözleşme yeniden aktif yapılamaz.
4.4 Milestone Kuralları
1.	Milestone’ların Amount toplamları Contract.TotalAmount’ı aşamaz.
2.	Milestone sırasıyla ilerler: önceki milestone Approved olmadan sonraki InProgress yapılamaz.
3.	Tüm milestone’lar Approved olduğunda sözleşme otomatik Completed olur.
4.5 Değerlendirme Kuralları
1.	Değerlendirme sadece Completed durumundaki sözleşmeler için yapılabilir.
2.	Rating 1–5 arasında olmalıdır.
3.	Aynı kişi aynı sözleşme için birden fazla değerlendirme yapamaz.
 
5. Ödev Görevleri
Öğrenciler aşağıdaki görevleri sırasıyla tamamlayacaktır. Her görev bir öncekinin tamamlanmasına bağlıdır.

Faz 1: Proje Kurulumu ve Domain Katmanı
No	Görev	Detay	Katman
1.1	Solution Oluşturma	GigFlow.sln oluşturun ve 5 katman projesini (Domain, Application, Infrastructure, Persistence, Presentation) ekleyin. Proje referanslarını Clean Architecture’a uygun şekilde ayarlayın.	Tümü
1.2	BaseEntity Oluşturma	Id, CreatedDate, UpdatedDate alanlarını içeren abstract BaseEntity sınıfını Domain katmanında oluşturun.	Domain
1.3	Enum Tanımları	BudgetType, ProjectDuration, ExperienceLevel, JobStatus, ProposalStatus, ContractStatus, MilestoneStatus enum’larını Domain/Enums/ altında oluşturun.	Domain
1.4	Entity Sınıfları	Category, Skill, JobPosting, JobPostingSkill, Proposal, Contract, Milestone, Review, Portfolio entity sınıflarını dokümandaki şemaya uygun olarak oluşturun. Navigation property’leri eklemeyi unutmayın.	Domain

Faz 2: Persistence Katmanı
No	Görev	Detay	Katman
2.1	DbContext Oluşturma	GigFlowDbContext sınıfını oluşturun. Tüm entity’ler için DbSet tanımlayın.	Persistence
2.2	Fluent API Konfigürasyonlar	Her entity için ayrı configuration sınıfı oluşturun (IEntityTypeConfiguration). Alan uzunlukları, ilişkiler, index’ler ve varsayılan değerleri burada tanımlayın.	Persistence
2.3	Migration Oluşturma	InitialCreate migration’ını oluşturun ve veritabanını güncelleyin. PostgreSQL veya MSSQL kullanabilirsiniz.	Persistence
2.4	Repository Interface & Impl.	Application katmanında generic IRepository<T> ve her entity için özel repository interface’lerini tanımlayın. Persistence katmanında bunların implementasyonlarını yazın.	App + Pers
2.5	Seed Data	En az 5 kategori, 15 skill ve 3 örnek iş ilanı için seed data oluşturun.	Persistence
2.6	Service Registration	PersistenceServiceRegistration sınıfında DbContext ve repository’lerin DI kaydını yapın.	Persistence

Faz 3: Application Katmanı (CQRS)
No	Görev	Detay	Katman
3.1	MediatR & Paket Kurulumu	MediatR, AutoMapper, FluentValidation NuGet paketlerini Application katmanına ekleyin. ApplicationServiceRegistration içinde DI kayıtlarını yapın.	Application
3.2	Category CQRS	CreateCategory, UpdateCategory, DeleteCategory command’larını ve GetAllCategories, GetCategoryById query’lerini handler ve validator ile birlikte oluşturun.	Application
3.3	Skill CQRS	CreateSkill, UpdateSkill, DeleteSkill command’ları ve GetSkillsByCategory, GetSkillById query’lerini oluşturun.	Application
3.4	JobPosting CQRS	CreateJobPosting (skill ataması dahil), UpdateJobPosting, DeleteJobPosting command’ları ve GetAllJobPostings (filtreleme + sayfalama), GetJobPostingById, GetJobPostingsByCategory query’lerini oluşturun.	Application
3.5	Proposal CQRS	CreateProposal, UpdateProposal, WithdrawProposal, AcceptProposal, RejectProposal command’ları ve GetProposalsByJobPosting, GetProposalById query’lerini oluşturun. AcceptProposal’da diğer tekliflerin otomatik reddini uygulayın.	Application
3.6	Contract CQRS	CreateContract (kabul edilen tekliften otomatik), UpdateContractStatus command’ları ve GetContractById, GetContractsByFreelancer, GetContractsByClient query’lerini oluşturun.	Application
3.7	Milestone CQRS	CreateMilestone, UpdateMilestoneStatus, UpdateMilestone command’ları ve GetMilestonesByContract query’sini oluşturun. Tüm milestone tamamlandığında sözleşme otomatik kapansın.	Application
3.8	Review CQRS	CreateReview command’ı ve GetReviewsByContract, GetReviewsByUser query’lerini oluşturun. Sadece completed sözleşmelere izin verin.	Application
3.9	Portfolio CQRS	CreatePortfolio, UpdatePortfolio, DeletePortfolio command’ları ve GetPortfoliosByFreelancer query’sini oluşturun.	Application
3.10	Validation Kuralları	Tüm command’lar için FluentValidation kuralları yazın. Bölüm 4’teki domain kurallarını burada uygulayın.	Application
 
Faz 4: Presentation Katmanı (API)
No	Görev	Detay	Katman
4.1	Controller Yapılandırması	Her entity için ayrı API controller oluşturun: CategoriesController, SkillsController, JobPostingsController, ProposalsController, ContractsController, MilestonesController, ReviewsController, PortfoliosController.	Presentation
4.2	Program.cs Konfigürasyonu	Tüm katman service registration’larını çağırın, Swagger’ı yapılandırın, CORS ayarlarını yapın, exception middleware ekleyin.	Presentation
4.3	Global Exception Handling	Tüm uygulama genelinde hata yönetimi için bir ExceptionMiddleware oluşturun. Validation hataları, not found hataları ve genel hatalar için uygun HTTP status code döndürün.	Presentation
4.4	Swagger Dokümantasyonu	Tüm endpoint’ler için Swagger’da açıklamalar, örnek request/response ve grouping yapılandırmasını tamamlayın.	Presentation
4.5	API Test	Tüm CRUD işlemlerini Swagger veya Postman üzerinden test edin. Domain kurallarının doğru çalıştığını doğrulayın (orn: deadline geçmiş ilana teklif verememe).	Presentation

Faz 5: Infrastructure Katmanı
No	Görev	Detay	Katman
5.1	Service Registration	InfrastructureServiceRegistration sınıfını oluşturun ve Presentation katmanında çağırın.	Infrastructure
5.2	Loglama Servisi (Opsiyonel)	Serilog veya benzeri bir loglama kütüphanesi entegrasyonu yapın. Önemli işlemleri (sözleşme oluşturma, teklif kabul vb.) loglayın.	Infrastructure
 
6. Opsiyonel Görev: Üyelik Sistemi
⚠️  Bu bölüm opsiyoneldir. Temel görevleri tamamlayan öğrenciler, projelerini bir üst seviyeye taşımak için üyelik sistemini entegre edebilirler.

6.1 Ek Entity’ler
Üyelik sistemi için aşağıdaki yeni entity’ler eklenmelidir:

AppUser (Kullanıcı)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
Email	string (200)	Zorunlu, benzersiz, e-posta formatı
PasswordHash	string	Hash’lenmiş şifre (BCrypt önerilir)
FirstName	string (100)	Zorunlu
LastName	string (100)	Zorunlu
UserType	UserType (enum)	Freelancer = 0, Client = 1, Admin = 2
IsActive	bool	Varsayılan: true
FreelancerProfile	FreelancerProfile?	Navigation (UserType = Freelancer ise)
ClientProfile	ClientProfile?	Navigation (UserType = Client ise)

FreelancerProfile (Freelancer Profili)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
UserId	Guid	FK → AppUser (benzersiz, bire-bir)
Title	string (200)	Profesyonel unvan (örn: Full Stack Developer)
Bio	string (3000)	Kişisel tanıtım
HourlyRate	decimal(18,2)	Saatlik ücret
AverageRating	decimal(3,2)	Hesaplanan ortalama puan (1.00–5.00)
TotalEarnings	decimal(18,2)	Toplam kazanç (hesaplanan)
User	AppUser	Navigation property
FreelancerSkills	ICollection<FreelancerSkill>	Navigation: sahip olunan yetenekler
Portfolios	ICollection<Portfolio>	Navigation: portföy öğeleri

ClientProfile (İş Veren Profili)
Alan Adı	Veri Tipi	Açıklama / Kısıt
Id	Guid	PK (BaseEntity’den)
UserId	Guid	FK → AppUser (benzersiz, bire-bir)
CompanyName	string (200)?	Şirket adı (opsiyonel)
Website	string (500)?	Şirket web sitesi (opsiyonel)
TotalSpent	decimal(18,2)	Toplam harcama (hesaplanan)
User	AppUser	Navigation property
JobPostings	ICollection<JobPosting>	Navigation: yayınlanan ilanlar

FreelancerSkill (Freelancer-Yetenek İlişkisi)
Alan Adı	Veri Tipi	Açıklama / Kısıt
FreelancerProfileId	Guid	Composite PK, FK → FreelancerProfile
SkillId	Guid	Composite PK, FK → Skill
FreelancerProfile	FreelancerProfile	Navigation property
Skill	Skill	Navigation property

 
6.2 Üyelik Sistemi Görevleri
No	Görev	Detay	Katman
6.1	User Entity & Migration	AppUser, FreelancerProfile, ClientProfile ve FreelancerSkill entity’lerini oluşturun. Mevcut entity’lerdeki nullable olan FreelancerId ve ClientId alanlarını zorunlu FK olarak güncelleyin. Yeni migration oluşturun.	Domain + Pers
6.2	JWT Authentication	JWT token üretimi için bir TokenService oluşturun. Login ve Register endpoint’lerini AuthController altında yazın. Access token ve refresh token mekanizması kurun.	App + Pres
6.3	Register / Login CQRS	RegisterCommand (kullanıcı kaydı + profil oluşturma) ve LoginQuery (kimlik doğrulama + token dönme) yazın. Şifre BCrypt ile hash’leyin.	Application
6.4	Yetkilendirme (Authorization)	Controller’lara [Authorize] attribute ekleyin. Freelancer sadece kendi tekliflerini görebilsin, Client sadece kendi ilanlarını yönetebilsin. Role-based ve resource-based authorization uygulayın.	Presentation
6.5	Profil Yönetimi CQRS	UpdateFreelancerProfile, UpdateClientProfile, AddFreelancerSkill, RemoveFreelancerSkill command’larını ve GetFreelancerProfile, GetClientProfile, SearchFreelancers query’lerini oluşturun.	Application
6.6	Ortalama Puan Hesaplama	Yeni bir Review eklendiginde FreelancerProfile.AverageRating otomatik güncellensin. Domain event veya handler içinde hesaplama yapın.	Application

6.3 Ek Enum
Enum Adı	Değerler	Kullanım Yeri
UserType	Freelancer = 0, Client = 1, Admin = 2	AppUser.UserType
 
7. Değerlendirme Kriterleri
Proje aşağıdaki kriterler üzerinden değerlendirilecektir:

Kriter	Puan	Açıklama
Clean Architecture Uyumu	20	Katman bağımlılıkları doğru mu? Bağımlılık yönü içe doğru mu?
CQRS Implementasyonu	20	Command/Query ayrımı, handler yapısı, MediatR kullanımı
Entity & Veritabanı Tasarımı	15	Entity ilişkileri, Fluent API konfigurasyonları, migration’lar
Domain Kuralları (Business Rules)	15	Bölüm 4’teki kurallar uygulanmış mı?
Validation (FluentValidation)	10	Tüm command’lar için uygun doğrulama kuralları var mı?
API Tasarımı & Swagger	10	RESTful uyum, hata yönetimi, dokümantasyon
Kod Kalitesi & Temizlik	10	Naming conventions, SOLID prensipleri, gereksiz kod yok
TOPLAM	100	Üyelik sistemi bonus +20 puan

7.1 Bonus Puanlama (Üyelik Sistemi)
Üyelik sistemini başarıyla tamamlayan öğrenciler 100 puan üzerine +20 bonus puan alacaktır. Değerlendirme; JWT implementasyonu (5 puan), yetkilendirme kuralları (5 puan), profil yönetimi CQRS (5 puan) ve ortalama puan hesaplama mantığı (5 puan) üzerinden yapılacaktır.
 
8. Teknik Gereksinimler ve NuGet Paketleri

8.1 Kullanılacak NuGet Paketleri
Paket	Katman	Amaç
MediatR	Application	CQRS handler yönetimi
FluentValidation	Application	Command doğrulama kuralları
AutoMapper	Application	Entity ↔ DTO dönüşümleri
Microsoft.EntityFrameworkCore	Persistence	ORM ve veritabanı erişimi
Npgsql.EFCore / SqlServer	Persistence	PostgreSQL veya MSSQL provider
Swashbuckle.AspNetCore	Presentation	Swagger/OpenAPI dokümantasyonu
BCrypt.Net-Next (Opsiyonel)	Infrastructure	Şifre hashleme (Üyelik sistemi için)
System.IdentityModel.Tokens.Jwt (Ops.)	Infrastructure	JWT token üretimi (Üyelik sistemi için)

8.2 Genel Kurallar
•	Proje .NET 10 SDK üzerinde geliştirilecektir.
•	Veritabanı olarak PostgreSQL veya MSSQL tercih edilebilir.
•	Tüm entity’ler BaseEntity’den türetilmelidir.
•	Soft delete kullanmak opsiyoneldir ancak önerilir.
•	Connection string appsettings.json içinde saklanmalıdır.
•	Controller’larda iş mantığı OLMAMALIDIR; tüm mantık Application katmanındadır.
•	Her command için FluentValidation validator yazılmalıdır.
•	Async/await tüm veritabanı işlemlerinde kullanılmalıdır.

8.3 Teslim Bilgileri
•	Proje GitHub repository’sine yüklenmelidir.
•	README.md dosyasında kurulum adımları ve kullanılan teknolojiler belirtilmelidir.
•	.gitignore dosyası eklenmelidir (bin/, obj/, appsettings.Development.json vb.).
•	Migration’lar repository’ye dahil edilmelidir.
•	Postman collection veya Swagger screenshot’ları eklenmesi artı puandır.


Başarılar!
YOBODOBO Backend Eğitimi – Eğitmen: Ömer Faruk Doğan
