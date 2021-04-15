using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linqtosql.Models;

namespace linqtosql.Controllers
{
    public class ProductController : Controller
    {
        private DataClassesBikeStoreDataContext db = new DataClassesBikeStoreDataContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = from product in db.products select product;
            return View(products);

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            product product = db.products.Single(x => x.product_id == id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product product)
        {
            try
            {
                // TODO: Add insert logic here
                db.products.InsertOnSubmit(product);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            product product = db.products.Single(x => x.product_id == id);
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product product)
        {
            try
            {
                // TODO: Add update logic here
                product product1 = db.products.Single(x => x.product_id == id);
                product1.product_name = product.product_name;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
