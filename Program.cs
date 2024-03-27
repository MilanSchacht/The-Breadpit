using static System.Net.WebRequestMethods;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Adds the strict transport security header
    app.UseHsts();
}
// Redirects HTTP requests to HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// Om status codes te laten genereren zullen we middleware moeten toevoegen
app.UseStatusCodePages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();