using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Infrastructure.Data;
using TurkcellPasajApp.Infrastructure.Repositories;
using TurkcellPasajApp.MVC.Extensions;
using TurkcellPasajApp.Services;
using TurkcellPasajApp.Services.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(10); // Session süresini burada ayarlayabilirsiniz
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddInjections(connectionString);//extension yazdýk.(IoC Extensions)



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<TurkcellPasajAppDbContext>()
            .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Login"; // Giriş yapmamış kullanıcıları bu sayfaya yönlendir
    options.AccessDeniedPath = "/Home/AccessDenied"; // Yetkisiz erişim durumunda yönlendirilecek sayfa
   
});

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
