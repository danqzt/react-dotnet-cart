using System;
using Server.Interfaces;
using Server.Repositories;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt => opt.AddPolicy("cors-policy", builder =>
   builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000")
));
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(a =>
  {
      a.IdleTimeout = TimeSpan.FromHours(24);
      a.Cookie.IsEssential = true;
      a.Cookie.HttpOnly = true;
      a.Cookie.SameSite = SameSiteMode.Lax;
      a.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
  });

builder.Services.AddSingleton<ICartRepository, CartRepository>();
builder.Services.AddSingleton<ICountryRepository, CountryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("cors-policy");
//app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
