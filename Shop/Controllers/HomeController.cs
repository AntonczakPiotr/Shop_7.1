using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string search = null)
        {
            IEnumerable<Category> model;
            if (!string.IsNullOrEmpty(search))
                model = _db.Categories.Where(c => c.Name.Contains(search)).ToList();
            else
                model = _db.Categories.ToList();

            var selectedCategories =
                from c in _db.Categories
                where c.Name.Length < 7
                select c;

            var selectedCategories2 = _db.Categories.Where(c => c.Name.Length < 7 && c.Id < 2).Take(10);

            var model2 = _db.Categories.ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}