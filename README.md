# ☕ KafeMenuApi

Modern platformlar (web, mobil veya oyunlar) için dinamik menü ve ürün yönetimi sağlayan bir backend servisidir. .NET 9 ve Minimal API mimarisi ile geliştirilmiş; Entity Framework Core 9 ve SQLite ile veritabanı yönetimi sağlanmıştır.

### 🛠 Kullanılan Teknolojiler
- **Framework:** .NET 9.0 (ASP.NET Core Minimal API)
- **Veritabanı ORM:** Entity Framework Core 9 (Code-First)
- **Veritabanı:** SQLite (`kafemenu.db`)
- **API Dokümantasyon:** Swagger/OpenAPI

### 🚀 Özellikler (Endpoints)
| Metot | Uç Nokta | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/menu` | Tüm menü listesini getirir. |
| **GET** | `/api/menu/{id}` | Belirtilen ID'ye sahip ürünü getirir. |
| **POST** | `/api/menu` | Menüye yeni ürün ekler. |
| **DELETE** | `/api/menu/{id}` | Ürünü veritabanından kalıcı olarak siler. |

### ⚙️ Yerel Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

1. Projeyi bilgisayarınıza klonlayın: `git clone https://github.com/ikbaltorun/KafeMenuApi.git`
2. Terminal üzerinden proje dizinine gidin: `cd KafeMenuApi`
3. Veritabanını oluşturmak için şu komutu çalıştırın: `dotnet ef database update`
4. Uygulamayı başlatmak için: `dotnet run`
5. Tarayıcınızdan Swagger arayüzüne gidin: `http://localhost:5193/swagger`

---
*Bu proje, ileride oyun projeleri ile entegre etmek üzere geliştirilmiştir.*
