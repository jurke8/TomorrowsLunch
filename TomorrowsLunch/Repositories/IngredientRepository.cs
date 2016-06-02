using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;


namespace TomorrowsLunch.Repositories
{
    public class IngredientRepository
    {
        public List<Ingredient> GetAll()
        {
            IQueryable<Ingredient> ingredients;
            var ingredientsList = new List<Ingredient>();
            using (var db = new ApplicationDbContext())
            {
                ingredients = db.Ingredients.Include(i => i.Meals).Where(i => !i.Deleted);
                ingredientsList = ingredients.ToList();
            }
            return ingredientsList;
        }
    }
}