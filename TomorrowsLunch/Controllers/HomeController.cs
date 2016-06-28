using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            //var mr = new MealRepository();
            //var id = Guid.NewGuid();
            //var m = new Meal() { Name = "proba_update2", CreatedByUser = id };
            //mr.Create(m);
            //var myId = mr.GetAll().Where(y => y.CreatedByUser == id).Single().Id;

            //var myMeal = mr.GetSpecific(myId);
            //((Meal)myMeal).Name = "proba_update3";

            //mr.Update(myMeal);

            //ViewBag.Message = ((Meal)myMeal).Name;

            //foreach (var item in x)
            //{
            //    ViewBag.Message += item.Name + " ";
            //}
            ViewBag.ShowTitle = true;

            ViewBag.ShowLogin = true;
            return View();
        }
        public ActionResult Generic()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;

            return View();
        }

        public ActionResult Elements()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;

            ViewBag.Name = UserController.currentUser.Name;
            return View();
        }

        public ActionResult Home(string message)
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;

            ViewBag.Message = message;
            ViewBag.Name = UserController.currentUser.Name;

            return View();
        }
        
        
    }
}