using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = true;
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.ShowLogin = true;
            ViewBag.ShowTitle = true;
            return View();
        }
    }
}