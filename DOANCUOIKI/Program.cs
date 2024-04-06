using DOANCUOIKI.Models;
using DOANCUOIKI.Repositories;
using DOANCUOIKI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBanRepository, EFBanRepository>();
builder.Services.AddScoped<IMonAnRepository, EFMonAnRepository>();
builder.Services.AddScoped<ILoaiThucPhamRepository, EFLoaiThucPhamRepository>();
builder.Services.AddScoped<IHoaDonRepository, EFHoaDonRepository>();
builder.Services.AddScoped<ICTHoaDonRepository, EFCTHoaDonRespository>();
builder.Services.AddScoped<IHTThanhToanRepository, EFHTTThanhToanRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
