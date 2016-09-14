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
            ViewBag.ShowTitle = true;

            ViewBag.ShowLogin = true;
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