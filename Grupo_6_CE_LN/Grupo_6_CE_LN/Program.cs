using Microsoft.EntityFrameworkCore;
using Grupo_6_CE_LN.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CasoEstudioContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CasoEstudio"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controlles=Home}/{action=Index}/{id?}");

app.Run();
