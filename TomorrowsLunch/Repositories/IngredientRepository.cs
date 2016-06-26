using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;


namespace TomorrowsLunch.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>
    {
        public List<Ingredient> GetAll()
        {
            IQueryable<Ingredient> ingredients;
            var ingredientsList = new List<Ingredient>();
            using (var db = new ApplicationDbContext())
            {
                ingredients = db.Ingredients.Include(i => i.Meals).Where(i => !i.Deleted).OrderByDescending(x => x.DateCreated); ;
                ingredientsList = ingredients.ToList();
            }
            return ingredientsList;
        }
    }
}