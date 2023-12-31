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
    // �ifre politikalar�n� devre d��� b�rakma
    options.Password.RequireDigit = false;   // Rakam zorunlu de�il
    options.Password.RequireLowercase = false;  // K���k harf zorunlu de�il
    options.Password.RequireUppercase = false;  // B�y�k harf zorunlu de�il
    options.Password.RequireNonAlphanumeric = false;  // Alfan�merik olmayan karakter zorunlu de�il
    options.Password.RequiredLength = 1;  // Minimum �ifre uzunlu�u
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

// CORS politikalar�n� ayarla
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
