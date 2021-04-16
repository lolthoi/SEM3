using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Controllers
{
    public class ContactController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Contact
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var contacts = from s in db.Contacts
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    contacts = contacts.OrderByDescending(s => s.Name);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.Name);
                    break;
            }
            return View(contacts.ToList());
            //var contacts = from contact in db.Contacts select contact;
            //return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var contacts = db.Contacts.Single(x => x.Id == id);
            return View(contacts);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (db.Contacts.Any(x => x.Name.Contains(contact.Name)))
                {
                    return View("Error");
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var contacts = db.Contacts.Single(x => x.Id == id);
            return View(contacts);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                // TODO: Add update logic here
                var contacts = db.Contacts.Single(x => x.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var contacts = db.Contacts.Single(x => x.Id == id);
            return View(contacts);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var contact2 = db.Contacts.Single(x => x.Id == id);
                db.Contacts.Remove(contact2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
