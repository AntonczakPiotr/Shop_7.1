using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ReviewsController : BaseController
    {
        // GET: Reviews
        public ActionResult Index([Bind(Prefix = "Id")] int productId)
        {
            var product = _db.Products.Find(productId);

            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }

        public ActionResult Create(int productId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review model)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = model.ProductId });
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.Find(id);

            if (review != null)
            {
                return View(review);
            }
            return RedirectToAction("Index", "Products");
        }
        /*
         Żeby zmienić nazwę osoby dodającej komentaarz można wpisać:
         http://localhost:56239/Reviews/Edit/8?name=NewName
         nacisnąć przycisk "Save". Żeby temu zapobiec dodano:
         [Bind(Exclude ="Name")] - niestety to nie działa dobrze, bo można usunąć !!!
        */
        [HttpPost]
        public ActionResult Edit([Bind(Exclude ="Name")] Review model)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = model.ProductId });
            }

            return View(model);
        }
    }
}