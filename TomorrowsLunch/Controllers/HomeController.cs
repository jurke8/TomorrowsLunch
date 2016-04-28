using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TommorowsLunch.Providers;

namespace TomorrowsLunch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var p = new MealProvider();
            var x = p.GetAllMeals();
            foreach (var item in x)
            {
                ViewBag.Message += item.Name + " ";
            }
            return View();
        }
        public ActionResult Generic()
        {
            return View();
        }

        public ActionResult Elements()
        {
            return View();
        }
        
    }
}