using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Calendar(string message)
        {
            ViewBag.Message = message;
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = UserController.currentUser.Name;
            var cr = new CalendarRepository();

            var mr = new MealRepository();
            ViewBag.Meals = mr.GetAll(UserController.currentUser.Id);
            var model = cr.GetAll(UserController.currentUser.Id).OrderByDescending(c => c.CalendarDate);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var date = Convert.ToDateTime(frmc["date"]);
            var mealId = frmc["meal"];
            var cr = new CalendarRepository();
            var model = cr.GetAll(UserController.currentUser.Id);
            var dayOfWeek = date.ToString("dddd", new CultureInfo("hr-HR"));

            cr.Create(new Models.Calendar() { MealId = Guid.Parse(mealId), CalendarDate = date, DayOfWeek= dayOfWeek, CreatedByUser = UserController.currentUser.Id });

            return RedirectToAction("Calendar");
        }
        public ActionResult Delete(Guid id)
        {
            var cr = new CalendarRepository();
            var model = cr.GetAll(UserController.currentUser.Id);
            var toDelete = model.Where(x => id.Equals(x.Id)).FirstOrDefault();
            cr.Delete(toDelete);
            return RedirectToAction("Calendar");
        }
    }
}