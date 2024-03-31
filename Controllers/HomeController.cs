using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using The_Breadpit.Data;
using The_Breadpit.Models;

namespace The_Breadpit.Controllers
{
    public class HomeController : Controller
    {
        private BreadPitContext context = new BreadPitContext();

        public IActionResult Index()
        {
            // Retrieve product data from the database
            ICollection<Product> products = context.Products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price)
                .ThenBy(p => p.ProductName)
                .ToList();
            return View("Index", products);
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                var usedAccount = AccountRepository.AccountResponses.First();
                if (usedAccount.Role == AccountRole.admin)
                    return RedirectToAction("Admin", "Account");
                else if (usedAccount.Role == AccountRole.manager)
                    return RedirectToAction("Manager", "Account");
                else if (usedAccount.Role == AccountRole.user)
                    return RedirectToAction("User", "Account");
                else
                    AccountRepository.ClearAccount();

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(AccountLoginResponse account)
        {
            if (ModelState.IsValid)
            {
                // Check for the existence of the account.
                var existingAccounts = context.Accounts;
                if (existingAccounts != null)
                {
                    foreach (Account existingAccount in existingAccounts)
                    {
                        // Checking if the account used in the form is in the database
                        // and redirecting the account to the correct account page
                        if (existingAccount.Username == account.Username &&
                            existingAccount.Password == account.Password
                            && existingAccount.Role == AccountRole.admin)
                        {
                            // Give the account login data in a local storage
                            AccountRepository.AddAccount(existingAccount);

                            return RedirectToAction("Admin", "Account");
                        }
                        else if (existingAccount.Username == account.Username &&
                            existingAccount.Password == account.Password
                            && existingAccount.Role == AccountRole.manager)
                        {
                            // Give the account login data in a local storage
                            AccountRepository.AddAccount(existingAccount);

                            return RedirectToAction("Manager", "Account");
                        }
                        else if (existingAccount.Username == account.Username &&
                            existingAccount.Password == account.Password
                            && existingAccount.Role == AccountRole.user)
                        {
                            // Give the account login data in a local storage
                            AccountRepository.AddAccount(existingAccount);

                            return RedirectToAction("User", "Account");
                        }
                    }
                }
            }
            // Display error
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            try
            {
                var usedAccount = AccountRepository.AccountResponses.First();
                if (usedAccount.Role == AccountRole.admin)
                    return RedirectToAction("Admin", "Account");
                else if (usedAccount.Role == AccountRole.manager)
                    return RedirectToAction("Manager", "Account");
                else if (usedAccount.Role == AccountRole.user)
                    return RedirectToAction("User", "Account");
                else
                    AccountRepository.ClearAccount();

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterResponse account)
        {
            if (ModelState.IsValid)
            {
                // Check for the existence of the account.
                var existingAccounts = context.Accounts;
                if (existingAccounts != null)
                {
                    foreach (Account existingAccount in existingAccounts)
                    {
                        // Checking if the account used in the form is in the database
                        // and redirecting the account to the correct account page
                        if (existingAccount.Username == account.Username &&
                            existingAccount.Password == account.Password
                            && existingAccount.Email == account.Email)
                        {
                            // Display error
                            ModelState.AddModelError("", "Invalid username, email or password.");
                            return View();
                        }
                    }
                }
            }            
            // Make a new account and store it in the database.
            Account newAccount = new Account()
            {
                Username = account.Username,
                Email = account.Email,
                Password = account.Password,
                Role = AccountRole.user
            };
            context.Accounts.Add(newAccount);
            context.SaveChanges();

            // Give the account login data in a local storage
            AccountRepository.AddAccount(newAccount);

            return RedirectToAction("User", "Account");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
