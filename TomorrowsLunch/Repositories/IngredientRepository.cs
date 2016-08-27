using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;


namespace TomorrowsLunch.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>
    {
        public List<Ingredient> GetAll(Guid currentUser)
        {
            IQueryable<Ingredient> ingredients;
            var ingredientsList = new List<Ingredient>();
            using (var db = new ApplicationDbContext())
            {
                ingredients = db.Ingredients.Where(i => !i.Deleted).Where(i => i.CreatedByUser == currentUser).OrderByDescending(x => x.DateCreated);
                ingredientsList = ingredients.ToList();
            }
            return ingredientsList;
        }
        public Ingredient GetSpecific(Guid specificIngredientId)
        {
            Ingredient returnValue;
            IQueryable<Ingredient> ingredient;
            using (var db = new ApplicationDbContext())
            {
                //include
                ingredient = db.Ingredients.Where(i => i.Id == specificIngredientId);
                returnValue = ingredient.FirstOrDefault();
            }
            return returnValue;
        }
    }
}