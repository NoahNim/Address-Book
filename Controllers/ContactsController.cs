using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contacts.Models;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
          List<Contact> allContacts = Contact.GetAll();
          return View(allContacts);
        }

        [HttpGet("/contacts/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpGet("/contacts/{id}")]
        public ActionResult Details(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
        }
        [HttpPost("/")]
        public ActionResult Create()
        {
          Contact newContact = new Contact (Request.Form["new-name"], Request.Form["new-phone"], Request.Form["new-address"]);
          newContact.Save();
          List<Contact> allContacts = Contact.GetAll();
          return View("Index", allContacts);
        }
        [HttpPost("/Contacts/delete")]
        public ActionResult DeleteAll()
        {
            Contact.ClearAll();
            return View();
        }
    }
}
