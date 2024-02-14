using M4_Project_v2.Models;
using Microsoft.AspNetCore.Mvc;

namespace M4_Project_v2.Controllers
{
    public class ContactController : Controller
    {
       private ContactContext context {  get; set; }
        public ContactController(ContactContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contact());
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            ViewBag.Action = "Edit";
            var contact = context.Contacts.Find(id);
            return View(contact);
                
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(contact.Id == 0)
                {
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                    context.SaveChanges();
                }
                return View(contact);
            }
            else
            {
                ViewBag.Action = (contact.Id == 0) ? "Add" : "Edit";
                return View(contact);
            }

            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete (Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var contact = context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
    }
}
