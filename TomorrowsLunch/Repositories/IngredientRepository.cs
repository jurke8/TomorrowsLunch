using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using TomorrowsLunch.AzureMachineLearning;
using System.Web.Script.Serialization;

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
                ingredients = db.Ingredients.Where(i => !i.Deleted).Where(i => (i.CreatedByUser == currentUser || i.CreatedByUser == Guid.Empty));

                //AML
                IngredientsClustering.Ingredients = ingredients.ToList();
                IngredientsClustering.InvokeRequestResponseService().Wait();
                ingredientsList = IngredientsClustering.Ingredients.OrderBy(i => i.Group).ToList();
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