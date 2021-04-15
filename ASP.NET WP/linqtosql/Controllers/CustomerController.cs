using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linqtosql.Models;

namespace linqtosql.Controllers
{
    public class CustomerController : Controller
    {
        private DataClassesBikeStoreDataContext db = new DataClassesBikeStoreDataContext();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = from customer in db.customers select customer;
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            customer customer = db.customers.Single(x => x.customer_id == id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                db.customers.InsertOnSubmit(customer);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            customer customer = db.customers.Single(x => x.customer_id == id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, customer customer)
        {
            try
            {
                // TODO: Add update logic here
                customer customer1 = db.customers.Single(x => x.customer_id == id);
                customer1.first_name = customer.first_name;
                customer1.last_name = customer.last_name;
                customer1.phone = customer.phone;
                customer1.email = customer.email;
                customer1.street = customer.street;
                customer1.city = customer.city;
                customer1.state = customer.state;
                customer1.zip_code = customer.zip_code;

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            customer customer = db.customers.Single(x => x.customer_id == id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                customer customer2 = db.customers.Single(x => x.customer_id == id);
                db.customers.DeleteOnSubmit(customer2);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
