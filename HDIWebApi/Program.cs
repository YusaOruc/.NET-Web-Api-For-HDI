using Auth.Core.Extensions;
using Auth.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survey.Api.Extensions;
using Data.Core.DbContexts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HdiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, b => b.MigrationsAssembly("HDIWebApi"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
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
