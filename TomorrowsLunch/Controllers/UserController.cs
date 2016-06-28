using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using System.Net;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class UserController : Controller
    {
        public static string name;

        public ActionResult Registration(string message)
        {
            ViewBag.ShowLogin = true;
            ViewBag.ShowTitle = true;
            ViewBag.Message = message;

            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormCollection frmc)
        {
            var userName = frmc["name"];
            if (frmc["pass"] != frmc["confirmpass"])
            {
                ViewBag.ShowLogin = true;
                ViewBag.ShowTitle = true;
                return RedirectToAction("Registration", new { message = "Lozinke se ne podudaraju!!!" });
            }
            else
            {
                var ur = new UserRepository();
                if (ur.UserNameExist(userName))
                {
                    ViewBag.ShowLogin = true;
                    ViewBag.ShowTitle = true;
                    return RedirectToAction("Registration", new { message = "Korisničko ime postoji!!!" });
                }
                else
                {
                    var newUser = ur.Create(new User() { Name = userName, Email = frmc["email"], Password = frmc["pass"] });
                    ViewBag.ShowLogin = false;
                    ViewBag.ShowTitle = false;
                    return RedirectToAction("Login", new { message = "Uspješno ste registrirani!!!" });
                }
            }
        }
        public ActionResult Login(string message)
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = true;
            if ("Uspješno ste registrirani!!!".Equals(message))
            {
                ViewBag.RegistrationMessage = message;
            }
            else
            {
                ViewBag.Message = message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frmc)
        {
            var userName = frmc["name"];
            var ur = new UserRepository();
            if (!ur.UserNameExist(userName))
            {
                return RedirectToAction("Login", "User", new { message = "Korisničko ime ne postoji!!!" });
            }
            else
            {
                var user = ur.GetSpecificByName(userName);
                if (user.Password.Equals(frmc["pass"]))
                {
                    name = user.Name;
                    ViewBag.ShowLogin = false;
                    ViewBag.ShowTitle = false;
                    return RedirectToAction("Home", "Home", new { message = "Uspješno ste prijavljeni" });
                }
                else
                {
                    return View(new { message = "Kriva lozinka!!!" });
                }
            }
        }
    }
}