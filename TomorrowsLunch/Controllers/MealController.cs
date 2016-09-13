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
            var recipe = frmc["recipe"];

            var ir = new IngredientRepository();
            var ingredients = ir.GetAll(UserController.currentUser.Id);
            var mealIngredients = new List<Ingredient>();
            var quanitites = new List<int>();
            var ingredientsQuantites = new List<MealIngredientQuantity>();
            for (int i = 1; i < frmc.Count-1; i++)
            {
                if (i % 2 != 0)
                {
                    mealIngredients.Add(ingredients.Where(ing => ing.Id.ToString().Equals(frmc[i])).FirstOrDefault());
                }
                else
                {
                    int quantity;
                    quantity = (Int32.TryParse(frmc[i], out quantity)) ? quantity : 0;
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
                    IngredientCarbohydrates = mealIngredients.ElementAt(i).Carbohydrates,
                    IngredientFat = mealIngredients.ElementAt(i).Fat,
                    IngredientProteins = mealIngredients.ElementAt(i).Proteins,
                    IngredientCalories = mealIngredients.ElementAt(i).Calories,
                    Quantity = quanitites.ElementAt(i)
                });
            }
            var meal = mr.Create(new Meal()
            {
                Name = mealName,
                CreatedByUser = UserController.currentUser.Id,
                MealIngredientQuantites = ingredientsQuantites,
                Recipe = recipe
            });

            return RedirectToAction("Meals");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection frmc)
        {
            //var ir = new IngredientRepository();
            //int calories, carbs, fat, proteins;
            //Guid id;
            //calories = (Int32.TryParse(frmc["calories"], out calories)) ? calories : 0;
            //carbs = (Int32.TryParse(frmc["carbohydrates"], out carbs)) ? carbs : 0;
            //fat = (Int32.TryParse(frmc["fat"], out fat)) ? fat : 0;
            //proteins = (Int32.TryParse(frmc["proteins"], out proteins)) ? proteins : 0;
            //id = new Guid(frmc["id"]);

            //var ingredientModel = ir.GetSpecific(id);
            //ingredientModel.Name = frmc["name"];
            //ingredientModel.Calories = calories;
            //ingredientModel.Carbohydrates = carbs;
            //ingredientModel.Fat = fat;
            //ingredientModel.Proteins = proteins;

            //ir.Update(ingredientModel);
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