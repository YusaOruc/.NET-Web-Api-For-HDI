using Auth.Core.Extensions;
using Auth.Api.Extensions;
using HDIWebApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HdiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
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

builder.Services.AddAuthModule(builder.Configuration);
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
