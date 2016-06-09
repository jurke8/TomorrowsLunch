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
            var name = HomeController.name;
            ViewBag.Name = name;

            var ir = new IngredientRepository();
            var model = ir.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frmc)
        {
            var ingredientName = frmc["name"];
            var ir = new IngredientRepository();
            ir.Create(new Ingredient() { Name = ingredientName });
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