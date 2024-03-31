using static System.Net.WebRequestMethods;
using System.Reflection.PortableExecutable;
using The_Breadpit.Models;
using The_Breadpit.Data;


/* Adding admin and manager account if not already in table */
using BreadPitContext context = new BreadPitContext(); // give acces to database.

// Check for the existence of the base admin and manager accounts.
var dbAdminAccounts = context.Accounts
    .Where(a => a.Role == AccountRole.admin && a.Username == "admin")
    .FirstOrDefault();
var dbManagerAccounts = context.Accounts
    .Where(a => a.Role == AccountRole.manager && a.Username == "manager")
    .FirstOrDefault();
if (dbAdminAccounts == null)
{
    Account adminAccount = new Account()
    {
        Username = "admin",
        Email = "admin@admin.be",
        Password = "Admin123",
        Role = AccountRole.admin
    };

    context.Accounts.Add(adminAccount);
    context.SaveChanges();
    Console.WriteLine("BASE ADMIN ACCOUNT ADDED!");
}
if (dbManagerAccounts == null)
{
    Account managerAccount = new Account()
    {
        Username = "manager",
        Email = "manager@manager.be",
        Password = "Manager123",
        Role = AccountRole.manager
    };

    context.Accounts.Add(managerAccount);
    context.SaveChanges();
    Console.WriteLine("BASE MANAGER ACCOUNT ADDED!");
}


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