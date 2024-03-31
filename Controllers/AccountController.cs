using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using The_Breadpit.Data;
using The_Breadpit.Models;


namespace The_Breadpit.Controllers
{
    public class AccountController : Controller
    {
        private BreadPitContext context = new BreadPitContext();

        public IActionResult Admin()
        {
            try
            {
                var usedAccount = AccountRepository.AccountResponses.First();

                if (usedAccount != null) // if a user has logged in.
                {
                    if (usedAccount.Role != AccountRole.admin)
                        return RedirectToAction("Login", "Home");
                    return View("Admin", usedAccount.Username);
                }
                else
                {
                    // Notify via console
                    Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nError: this wasnt supposed to happen.\r\n");

                    return RedirectToAction("Error", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Manager()
        {
            try
            {
                var usedAccount = AccountRepository.AccountResponses.First();

                if (usedAccount != null) // if a user has logged in.
                {
                    if (usedAccount.Role != AccountRole.manager)
                        return RedirectToAction("Login", "Home");
                    return View("Manager", usedAccount.Username);
                }
                else
                {
                    // Notify via console
                    Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nError: this wasnt supposed to happen.\r\n");

                    return RedirectToAction("Error", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult User()
        {
            try
            {
                var usedAccount = AccountRepository.AccountResponses.First();

                if (usedAccount != null) // if a user has logged in / registered.
                {
                    if (usedAccount.Role != AccountRole.user)
                        return RedirectToAction("Login", "Home");
                    return View("User", usedAccount.Username);
                }
                else
                {
                    // Notify via console
                    Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nError: this wasnt supposed to happen.\r\n");

                    return RedirectToAction("Error", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            AccountRepository.ClearAccount();
            return RedirectToAction("Index", "Home");
        }

        /*Admin pages (Has acces to all pages from here)*/
        public IActionResult AdminUpdateOrder()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminUpdateProduct()
        {
            // Retrieve product data from the database
            ICollection<Product> products = context.Products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price)
                .ThenBy(p => p.ProductName)
                .ToList();

            return View(products);
        }
        [HttpPost]
        public IActionResult AdminAddProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(p);
                context.SaveChanges();
            }

            return RedirectToAction("AdminUpdateProduct");
        }
        [HttpPost]
        public IActionResult AdminEditProduct(List<int> selectedProducts, Product product)
        {
            foreach (var id in selectedProducts)
            {
                Console.WriteLine($"Product ID: {id}");
                var selectedProduct = context.Products
                    .Where(p=> p.Id == id)
                    .FirstOrDefault();

                if (selectedProduct != null)
                {
                    if (product.Price != 0)
                        selectedProduct.Price = product.Price;
                }

            }

            if (product.Price != 0)
            {
                Console.WriteLine($"Have changed prices to: {product.Price}");
                context.SaveChanges();
            }
            else
                Console.WriteLine("Have not changed prices.");

            return RedirectToAction("AdminUpdateProduct");
        }
        [HttpPost]
        public IActionResult AdminDeleteProduct(List<int> selectedProducts)
        {
            foreach (var id in selectedProducts)
            {
                Console.WriteLine($"Product ID: {id}");
                var selectedProduct = context.Products
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                if (selectedProduct is Product)
                {
                    Console.WriteLine($"product name: {selectedProduct.ProductName}");
                    context.Remove(selectedProduct);
                }
            }
            Console.WriteLine("Have been deleted");
            context.SaveChanges();
            return RedirectToAction("AdminUpdateProduct");
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
            // Retrieve product data from the database
            ICollection<Product> products = context.Products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price)
                .ThenBy(p => p.ProductName)
                .ToList();

            return View(products);
        }
        public IActionResult UserViewOrder()
        {
            return View();
        }
    }
}
