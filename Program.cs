using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Test_Case.Helpers;
using Test_Case.Hubs;
using Test_Case.Models;
using Test_Case.Services.Implementations;
using Test_Case.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// JWT ayarlarını kontrol etme ve ekleme işlemleri
var jwtKey = builder.Configuration["Jwt:Key"];

// Token ayarlama işlemleri
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// Appsettings.json'dan ayarları almak için gerekli yapılandırma
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

// Singleton olarak JwtHelpers ekleme
builder.Services.AddSingleton(sp =>
{
    var jwtSettings = sp.GetRequiredService<IOptions<JwtSettings>>().Value;
    return new JwtHelpers(jwtSettings);
});

// Kullanıcı servisini ekleyin
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<OfferService, OfferService>();
builder.Services.AddScoped<IServeService, ServeService>();
builder.Services.AddScoped<CommentService, CommentService>();

// DbContext kaydını yapma
builder.Services.AddDbContext<LZ_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// HTTP istek işleme pipeline'ı
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Case API v1"));
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication(); // JWT kimlik doğrulama
app.UseAuthorization();  // Yetkilendirme

// API Controller'larını haritalama
app.MapControllers();

app.UseCors("AllowAll");
app.MapHub<ChatHub>("chat");

// Uygulamayı başlatma
app.Run();
