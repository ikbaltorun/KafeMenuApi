using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger ve API test ekranı ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı bağlantısını ayarlıyoruz (SQLite kullan diyoruz)
builder.Services.AddDbContext<KafeContext>(options =>
    options.UseSqlite("Data Source=kafemenu.db"));

var app = builder.Build();

// Geliştirici ortamında Swagger'ı aktif et
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 1. GET: Tüm menüyü getir
app.MapGet("/api/menu", async (KafeContext db) => 
    await db.Urunler.ToListAsync());

// 2. GET by ID: Tek ürün getir
app.MapGet("/api/menu/{id}", async (int id, KafeContext db) => 
    await db.Urunler.FindAsync(id) is Urun urun ? Results.Ok(urun) : Results.NotFound("Ürün bulunamadı!"));

// 3. POST: Yeni ürün ekle
app.MapPost("/api/menu", async (Urun yeniUrun, KafeContext db) => 
{
    db.Urunler.Add(yeniUrun);
    await db.SaveChangesAsync(); // Veritabanına kaydet
    return Results.Created($"/api/menu/{yeniUrun.Id}", yeniUrun);
});

// 4. DELETE: Ürün sil
app.MapDelete("/api/menu/{id}", async (int id, KafeContext db) => 
{
    var urun = await db.Urunler.FindAsync(id);
    if (urun == null) return Results.NotFound("Silinecek ürün bulunamadı!");
    
    db.Urunler.Remove(urun);
    await db.SaveChangesAsync(); // Veritabanından kalıcı sil
    return Results.Ok($"{urun.Ad} menüden başarıyla silindi.");
});

app.Run();

// --- SINIFLARIMIZ ---

class Urun
{
    public int Id { get; set; }
    public string? Ad { get; set; } 
    public decimal Fiyat { get; set; }
}

// Veritabanı yöneticimiz (Entity Framework)
class KafeContext : DbContext
{
    public KafeContext(DbContextOptions<KafeContext> options) : base(options) { }
    
    // SQL'de "Urunler" adında bir tablo oluşturulacak
    public DbSet<Urun> Urunler { get; set; }
}