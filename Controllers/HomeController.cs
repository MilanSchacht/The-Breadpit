using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using The_Breadpit.Models;

namespace The_Breadpit.Controllers
{
    public class HomeController : Controller
    {
        //TODO NEXT: 08 -> 05/06/07

        // TODO: viewbag test
        //ViewBag.mail = "";
        //ViewBag.password = "";

        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            string viewModel = hour + ":" + minute.ToString("00");
            return View("Index",viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginResponse account)
        {
            // Store account login while site is running
            if (ModelState.IsValid)
            {
                //===============-|- CHANGE -|-===============
                // Give the account login data in a database
                AccountRepository.AddLogedinAccount(account);

                // Temp to admin
                return RedirectToAction("Admin", "Account");
                //============================================
            }
            else
            {
                // Notify via console
                Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nFailed to log account in.\r\n");
                
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterResponse account)
        {
            // Store account login while site is running
            if (ModelState.IsValid)
            {
                // Give the account login data in a database
                AccountRepository.AddRegisteredAccount(account);

                //===============-|- CHANGE -|-===============
                // Temp to user
                return RedirectToAction("User", "Account");
                //============================================
            }
            else
            {
                // Notify via console
                Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nFailed to register account.\r\n");
                
                return View();
            }
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
