using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepositoryPatternTutorial.Core;
using RepositoryPatternTutorial.Infrastructr;
using RepositoryPatternTutorial.Core.Interfaces;

namespace RepositoryPatternTutorial.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private ProductContext db = new ProductContext();

        // Old Method
        // private ProductRepository db = new ProductRepository();

        // Interface Method With Unity DI
        IProductRepository db;
        public ProductsController(IProductRepository db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            return View(db.GetProducts());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Product product = db.Products.Find(id);
            Product product = db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,inStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                // db.Products.Add(product);
                //db.SaveChanges();
                db.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,inStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                db.Edit(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.FindById(Convert.ToInt32(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.FindById(Convert.ToInt32(id));
            // db.Products.Remove(product);
            // db.SaveChanges();
            db.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
