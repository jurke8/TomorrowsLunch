using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class MealController : Controller
    {

        public ActionResult Meals()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            var name = HomeController.name;
            ViewBag.Name = name;

            var mr = new MealRepository();
            var model = mr.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var mealName = frmc["name"];
            var mr = new MealRepository();
            mr.Create(new Meal() { Name = mealName });
            return RedirectToAction("Meals");
        }
        public ActionResult Delete(Guid id)
        {
            var mr = new MealRepository();
            var model = mr.GetAll();
            var toDelete = model.Where(x => id.Equals(x.Id)).FirstOrDefault();
            mr.Delete(toDelete);
            return RedirectToAction("Meals");
        }
        public ActionResult Recipes()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            var name = HomeController.name;
            ViewBag.Name = name;
            return View();
        }


    }
}