using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using System.Net;
using TomorrowsLunch.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace TomorrowsLunch.Controllers
{
    public class UserController : Controller
    {
        public static User currentUser;
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
                    var data = Encoding.ASCII.GetBytes(frmc["pass"]);
                    var sha1 = new SHA1CryptoServiceProvider();
                    var hashedPasssword = sha1.ComputeHash(data);
                    int age, height, weight, activity;
                    age = (Int32.TryParse(frmc["age"], out age)) ? age : 25;
                    height = (Int32.TryParse(frmc["height"], out height)) ? height : 180;
                    weight = (Int32.TryParse(frmc["weight"], out weight)) ? weight : 70;
                    activity = (Int32.TryParse(frmc["activity"], out activity)) ? activity : 3;
                    activity = (activity == -1) ? 3 : activity;
                    var newUser = ur.Create(new User() { Name = userName, Email = frmc["email"], Password = hashedPasssword, Age = age, Height = height, Weight = weight, Activity = activity, Gender = frmc["gender"] });
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
                var data = Encoding.ASCII.GetBytes(frmc["pass"]);
                var sha1 = new SHA1CryptoServiceProvider();
                var hashedPasssword = sha1.ComputeHash(data);
                if (hashedPasssword.SequenceEqual(user.Password))
                {
                    currentUser = user;
                    ViewBag.ShowLogin = false;
                    ViewBag.ShowTitle = false;
                    return RedirectToAction("Calendar", "Calendar", new { message = "Uspješno ste prijavljeni" });
                }
                else
                {
                    return RedirectToAction("Login", "User", new { message = "Kriva lozinka!!!" });
                }
            }
        }
        public ActionResult EditProfile()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = currentUser.Name;


            var model = currentUser;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProfile(FormCollection frmc)
        {
            var ur = new UserRepository();
            int age, height, weight, activity;
            age = (Int32.TryParse(frmc["age"], out age)) ? age : 25;
            height = (Int32.TryParse(frmc["height"], out height)) ? height : 180;
            weight = (Int32.TryParse(frmc["weight"], out weight)) ? weight : 70;
            activity = (Int32.TryParse(frmc["activity"], out activity)) ? activity : 3;
            activity = (activity == -1) ? 3 : activity;
            currentUser.Email = frmc["email"];
            currentUser.Age = age;
            currentUser.Height = height;
            currentUser.Weight = weight;
            currentUser.Activity = activity;
            currentUser.Gender = frmc["gender"];
            ur.Update(currentUser);
            return RedirectToAction("EditProfile");
        }
    }
}