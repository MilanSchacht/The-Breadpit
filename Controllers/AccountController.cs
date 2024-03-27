using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using The_Breadpit.Models;

namespace The_Breadpit.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Admin()
        {
            var account = AccountRepository.LoginResponses.First();
            AccountRepository.ClearLogedinAccount();

            if (account != null)
            {
                // Notify via console
                Console.WriteLine($"\r\n======\r\nNOTICE\r\n======\r\n\r\nA admin account logged in:\r\n"+account.Username+"\r\n");
            }
            else
            {
                // Notify via console
                Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nError: this wasnt supposed to happen.\r\n");
            }

            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult User()
        {
            if (AccountRepository.RegisterResponses.First() != null) // if a new user regesters himself.
            {
                var account = AccountRepository.RegisterResponses.First();
                AccountRepository.ClearRegisteredAccount();

                // Notify via console
                Console.WriteLine($"\r\n======\r\nNOTICE\r\n======\r\n\r\nA user account logged in for the first time:\r\n" + account.Username + "\r\n");

                return View();
            }
            else if (AccountRepository.LoginResponses.First() != null) // if a user logs in.
            {
                var account = AccountRepository.LoginResponses.First();
                AccountRepository.ClearLogedinAccount();

                // Notify via console
                Console.WriteLine($"\r\n======\r\nNOTICE\r\n======\r\n\r\nA user account has logged in:\r\n" + account.Username + "\r\n");

                return View();
            }
            else
            {
                // Notify via console
                Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nError: this wasnt supposed to happen.\r\n");

                return RedirectToAction("Error", "Home");
            }
        }

        /*Admin pages (Has acces to all pages from here)*/
        public IActionResult AdminUpdateOrder()
        {
            return View();
        }
        public IActionResult AdminUpdatePrice()
        {
            return View();
        }
        public IActionResult AdminManageUser()
        {
            return View();
        }

        /*Manager pages (Has acces to all pages from here)*/

        public IActionResult ManageOrders()
        {
            return View();
        }

        /*User pages (Has acces to all pages from here)*/
        public IActionResult UserOrder()
        {
            return View();
        }
        public IActionResult UserViewOrder()
        {
            return View();
        }
    }
}
