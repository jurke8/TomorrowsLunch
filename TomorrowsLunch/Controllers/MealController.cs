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
        private static string name;

        // GET: Meal
        public ActionResult Meals()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;

            ViewBag.Name = name;

            var mr = new MealRepository();
            var model = mr.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Meals(FormCollection frmc)
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = name;

            var mealName = frmc["name"];
            var mr = new MealRepository();
            mr.Create(new Meal() { Name = mealName });
            var model = mr.GetAll();
            return View(model);
        }
    }
}