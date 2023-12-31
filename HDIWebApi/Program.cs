using Auth.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survey.Api.Extensions;
using Data.Core.DbContexts;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Data.Core.Entity;
using Microsoft.Extensions.DependencyInjection;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HdiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, b => b.MigrationsAssembly("HDIWebApi"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Þifre politikalarýný devre dýþý býrakma
    options.Password.RequireDigit = false;   // Rakam zorunlu deðil
    options.Password.RequireLowercase = false;  // Küçük harf zorunlu deðil
    options.Password.RequireUppercase = false;  // Büyük harf zorunlu deðil
    options.Password.RequireNonAlphanumeric = false;  // Alfanümerik olmayan karakter zorunlu deðil
    options.Password.RequiredLength = 1;  // Minimum þifre uzunluðu
})
    .AddEntityFrameworkStores<HdiDbContext>()
    .AddDefaultTokenProviders();

// Auto Mapper Configurations
//builder.Services.AddAutoMapper(cfg =>
//{
//    cfg.AddCollectionMappers();
//}, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthModule(builder.Configuration);
builder.Services.AddSurveyModule();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS politikalarýný ayarla
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
