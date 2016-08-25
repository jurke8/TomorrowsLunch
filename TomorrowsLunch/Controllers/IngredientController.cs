using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomorrowsLunch.Models;
using TomorrowsLunch.Repositories;

namespace TomorrowsLunch.Controllers
{
    public class IngredientController : Controller
    {
        public ActionResult Ingredients()
        {
            ViewBag.ShowLogin = false;
            ViewBag.ShowTitle = false;
            ViewBag.Name = UserController.currentUser.Name;


            var ir = new IngredientRepository();
            var model = ir.GetAll(UserController.currentUser.Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var ir = new IngredientRepository();
            int carbs, fat, proteins, calories;
            carbs = (Int32.TryParse(frmc["carbohydrates"], out carbs)) ? carbs : 0;
            fat = (Int32.TryParse(frmc["fat"], out fat)) ? fat : 0;
            proteins = (Int32.TryParse(frmc["proteins"], out proteins)) ? proteins : 0;
            calories = (Int32.TryParse(frmc["calories"], out calories)) ? calories : 0;


            ir.Create(new Ingredient()
            {
                Name = frmc["name"],
                Carbohydrates = carbs,
                Calories = calories,
                Fat = fat,
                Proteins = proteins,
                CreatedByUser = UserController.currentUser.Id
            });
            return RedirectToAction("Ingredients");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection frmc)
        {
            var ir = new IngredientRepository();
            int calories, carbs, fat, proteins;
            Guid id;
            calories = (Int32.TryParse(frmc["calories"], out calories)) ? calories : 0;
            carbs = (Int32.TryParse(frmc["carbohydrates"], out carbs)) ? carbs : 0;
            fat = (Int32.TryParse(frmc["fat"], out fat)) ? fat : 0;
            proteins = (Int32.TryParse(frmc["proteins"], out proteins)) ? proteins : 0;
            id = new Guid(frmc["id"]);

            var ingredientModel = ir.GetSpecific(id);
            ingredientModel.Name = frmc["name"];
            ingredientModel.Calories = calories;
            ingredientModel.Carbohydrates = carbs;
            ingredientModel.Fat = fat;
            ingredientModel.Proteins = proteins;

            ir.Update(ingredientModel);
            return RedirectToAction("Ingredients");
        }
        public ActionResult Delete(Guid id)
        {
            var ir = new IngredientRepository();
            var model = ir.GetAll(UserController.currentUser.Id);
            var toDelete = model.Where(x => id.Equals(x.Id)).FirstOrDefault();
            ir.Delete(toDelete);
            return RedirectToAction("Ingredients");
        }
    }
}