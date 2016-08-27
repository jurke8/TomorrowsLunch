using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;

namespace TomorrowsLunch.Repositories
{
    public class MealIngredientQuantityRepository : BaseRepository<MealIngredientQuantity>
    {
        public List<MealIngredientQuantity> GetAll()
        {
            var mealIngredientQuantitesList = new List<MealIngredientQuantity>();
            using (var db = new ApplicationDbContext())
            {
                mealIngredientQuantitesList = db.MealIngredientQuantites.ToList();
            }
            return mealIngredientQuantitesList;
        }
        public List<MealIngredientQuantity> GetSpecificByUserId(Guid specificUserId)
        {
            IQueryable<MealIngredientQuantity> mealIngredientQuantites;
            using (var db = new ApplicationDbContext())
            {
                mealIngredientQuantites = db.MealIngredientQuantites.Where(iq => iq.CreatedByUser == specificUserId);
            }
            return mealIngredientQuantites.ToList();
        }
    }
   
}