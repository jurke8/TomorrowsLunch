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
        public ActionResult Meals()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = UserController.currentUser.Name;
            var ir = new IngredientRepository();
            var mr = new MealRepository();

            ViewBag.Meals = mr.GetAll(UserController.currentUser.Id);
            var model = ir.GetAll(UserController.currentUser.Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var mealName = frmc["name"];
            var ir = new IngredientRepository();
            var ingredients = ir.GetAll(UserController.currentUser.Id);
            var mealIngredients = new List<Ingredient>() { new Ingredient() { Name = "probica", Id = Guid.Parse("0d9623b6-5bfb-4c64-8d48-0cdfe9521584") } };
            mealIngredients.Clear();
            var quanitites = new List<decimal>();
            var ingredientsQuantites = new List<MealIngredientQuantity>();
            for (int i = 1; i < frmc.Count; i++)
            {
                var x = frmc[i];
                if (i % 2 != 0)
                {
                    mealIngredients.Add(ingredients.Where(ing => ing.Id.ToString().Equals(frmc[i])).FirstOrDefault());
                }
                else
                {
                    decimal quantity;
                    quantity = (Decimal.TryParse(frmc[i], out quantity)) ? quantity : 0;
                    quanitites.Add(quantity);
                }
            }
            var mr = new MealRepository();
            for (int i = 0; i < mealIngredients.Count; i++)
            {
                ingredientsQuantites.Add(new MealIngredientQuantity()
                {
                    CreatedByUser = UserController.currentUser.Id,
                    IngredientId = mealIngredients.ElementAt(i).Id,
                    IngredientName = mealIngredients.ElementAt(i).Name,
                    Quantity = quanitites.ElementAt(i)
                });
            }
            var meal = mr.Create(new Meal()
            {
                Name = mealName,
                CreatedByUser = UserController.currentUser.Id,
                MealIngredientQuantites = ingredientsQuantites
            });

            return RedirectToAction("Meals");
        }
        public ActionResult Delete(Guid id)
        {
            var mr = new MealRepository();
            var model = mr.GetAll(UserController.currentUser.Id);
            var toDelete = model.Where(x => id.Equals(x.Id)).FirstOrDefault();
            mr.DeleteMeal(toDelete);
            return RedirectToAction("Meals");
        }
        public ActionResult Recipes()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = UserController.currentUser.Name;

            return View();
        }
    }
}