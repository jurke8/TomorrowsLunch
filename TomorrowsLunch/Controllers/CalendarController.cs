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
            var user = UserController.currentUser;
            ViewBag.Message = message;
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = user.Name;
            var cr = new CalendarRepository();
            var mr = new MealRepository();
            var allMeals = mr.GetAll(user.Id).OrderBy(m => m.Calories).ToList();
            ViewBag.Meals = allMeals;
            var model = cr.GetAll(user.Id).OrderByDescending(c => c.CalendarDate);
            var lastCalendars = cr.GetLastTwo(user.Id);

            var caloriesFromMeals = allMeals.OrderBy(m => m.Calories).Select(m => m.Calories).ToList();
            var similarCalories = GetSimilarCalories(caloriesFromMeals, Convert.ToInt32(user.CaloriesPerDay), Convert.ToDecimal(user.BMI));
            var suggestions = new List<Meal>();
            foreach (var item in similarCalories)
            {
                suggestions.Add(allMeals.Where(m => m.Calories == item).FirstOrDefault());
            }
            if (lastCalendars.Count > 0 && allMeals.Count > 1)
            {
                var toRemove = new List<Meal>();
                foreach (var item in suggestions)
                {
                    if (lastCalendars.Select(lc => lc.Meal).Select(m => m.Name).ToList().Contains(item.Name))
                    {
                        toRemove.Add(item);
                    }
                }
                foreach (var item in toRemove)
                {
                    suggestions.Remove(item);
                }
            }
            if (Convert.ToDecimal(user.BMI) < 19)
            {
                ViewBag.BMI = "Vaša težina je ispod granice normale";
            }
            else if (Convert.ToDecimal(user.BMI) >= 19 && Convert.ToDecimal(user.BMI) <= 25)
            {
                ViewBag.BMI = "Vaša težina je u granicama normale";
            }
            else
            {
                ViewBag.BMI = "Vaša težina je iznad granica normale";
            }
            ViewBag.Suggestions = suggestions;
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

            cr.Create(new Models.Calendar() { MealId = Guid.Parse(mealId), CalendarDate = date, DayOfWeek = dayOfWeek, CreatedByUser = UserController.currentUser.Id });

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
        private List<int> GetSimilarCalories(List<int> mealsCalories, int userCalories, decimal BMI)
        {
            var mealsCaloriesCount = mealsCalories.Count;
            if (mealsCalories.Count < 1)
            {
                return mealsCalories;
            }
            if (BMI< 19)
            {
                if (mealsCaloriesCount > 2)
                {
                    return mealsCalories.Skip(mealsCaloriesCount - 3).Take(3).ToList();
                }
            }
            else if (BMI >=19 && BMI <= 25)
            {
                mealsCalories.Add(userCalories);
                mealsCalories.Sort();
                var indexOfUserCalories = mealsCalories.IndexOf(userCalories);
                var returnList = new List<int>();
                if (indexOfUserCalories > 1)
                {
                    returnList.Add(mealsCalories.ElementAt(indexOfUserCalories - 1));
                    returnList.Add(mealsCalories.ElementAt(indexOfUserCalories - 2));
                    if (mealsCaloriesCount - indexOfUserCalories > 2)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 2));
                    }
                    else if (mealsCaloriesCount - indexOfUserCalories > 1)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                    }
                }
                else if(indexOfUserCalories > 0)
                {
                    returnList.Add(mealsCalories.ElementAt(indexOfUserCalories - 1));
                    if (mealsCaloriesCount - indexOfUserCalories > 2)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 2));
                    }
                    else if (mealsCaloriesCount - indexOfUserCalories > 1)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                    }
                }
                else
                {
                    if (mealsCaloriesCount - indexOfUserCalories > 2)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 2));
                    }
                    else if (mealsCaloriesCount - indexOfUserCalories > 1)
                    {
                        returnList.Add(mealsCalories.ElementAt(indexOfUserCalories + 1));
                    }
                }
                return returnList;
            }
            else
            {
                if (mealsCaloriesCount > 2)
                {
                    return mealsCalories.Take(3).ToList();
                }
            }
            return mealsCalories;
        }
    }
}