using Microsoft.EntityFrameworkCore;
using MyShop.Data;

var builder = WebApplication.CreateBuilder(args);

// ⭐️ ДОБАВЬТЕ ЭТО СРАЗУ ДЛЯ RAILWAY
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Cors политики
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000",
            "https://myshop-beta-blond.vercel.app",
            "https://*.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ⭐️ ВАЖНО: Cors ДОЛЖЕН быть первым
app.UseCors("AllowReactApp");

// ⭐️ УБЕРИТЕ UseHttpsRedirection в Production
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGet("/", () => "MyShop Backend API is running! 🚀");
app.MapControllers();

app.Run();