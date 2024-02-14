using M4_Project_v2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add EF Core DI
builder.Services.AddDbContext<ContactContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("ContactContext")));

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

app.MapControllerRoute(
    name: "Details",
    pattern: "{controller=Contact}/{action=Details}/{id:int}",
    defaults: new {controller="Contact", action="Details"});

app.MapControllerRoute(
    name: "Delete",
    pattern: "{controller=Contact}/{action=Delete}/{id:int}",
    defaults: new { controller = "Contact", action = "Delete" });

app.MapControllerRoute(
    name: "Edit",
    pattern: "{controller=Contact}/{action=Edit}/{id:int}",
    defaults: new { controller = "Contact", action = "Edit" });
app.Run();
