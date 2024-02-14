using M4_Project_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace M4_Project_v2.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context {  get; set; }

        public HomeController(ContactContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var contacts = context.Contacts.OrderBy(m => m.Fname).ToList();
            return View(contacts);
        }

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
