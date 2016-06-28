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
            var name = UserController.name;
            ViewBag.Name = name;

            var ir = new IngredientRepository();
            var model = ir.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var ir = new IngredientRepository();
            int carbs, fat, proteins;
            carbs = (Int32.TryParse(frmc["carbohydrates"], out carbs)) ? carbs : 0;
            fat = (Int32.TryParse(frmc["fat"], out fat)) ? fat : 0;
            proteins = (Int32.TryParse(frmc["proteins"], out proteins)) ? proteins : 0;

            ir.Create(new Ingredient()
            {
                Name = frmc["name"],
                Carbohydrates = carbs,
                Fat = fat,
                Proteins = proteins
            });
            return RedirectToAction("Ingredients");
        }
        public ActionResult Delete(Guid id)
        {
            var ir = new IngredientRepository();
            var model = ir.GetAll();
            var toDelete = model.Where(x => id.Equals(x.Id)).FirstOrDefault();
            ir.Delete(toDelete);
            return RedirectToAction("Ingredients");
        }
    }
}