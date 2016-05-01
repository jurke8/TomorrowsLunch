using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TommorowsLunch.Providers;
using TomorrowsLunch.Models;

namespace TomorrowsLunch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //    var p = new MealProvider();
            //    var m = new Meal() { Name = "piletina", CreatedByUser = Guid.NewGuid() };
            //    p.CreateMeal(m);
            //    var x = p.GetAllMeals();
            //    foreach (var item in x)
            //    {
            //        ViewBag.Message += item.Name + " ";
            //    }
            ViewBag.ShowLogin = true;
            return View();
        }
        public ActionResult Generic()
        {
            ViewBag.ShowLogin = false;
            return View();
        }

        public ActionResult Elements()
        {
            ViewBag.ShowLogin = false;
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.ShowLogin = false;
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.ShowLogin = true;
            return View();
        }

    }
}