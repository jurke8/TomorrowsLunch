using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;

namespace TomorrowsLunch.Repositories
{
    public class MealRepository : BaseRepository<Meal>
    {
        public object DeleteMeal(Meal meal)
        {
            var miqr = new MealIngredientQuantityRepository();
            meal.Deleted = true;
            meal.MealIngredientQuantites.ToList().ForEach(
                miq =>
                {
                    miqr.Delete(miq);
                });
            return Update(meal);
        }
        public List<Meal> GetAll(Guid currentUser)
        {
            IQueryable<Meal> meals;
            var mealsList = new List<Meal>();
            using (var db = new ApplicationDbContext())
            {
                meals = db.Meals.Include(m => m.MealIngredientQuantites).Where(m => !m.Deleted).Where(m => m.CreatedByUser == currentUser).OrderByDescending(x => x.DateCreated);
                mealsList = meals.ToList();
            }
            return mealsList;
        }
        public Meal GetSpecific(Guid specificMealId)
        {
            Meal returnValue;
            IQueryable<Meal> meal;
            using (var db = new ApplicationDbContext())
            {
                //include
                meal = db.Meals.Include(m => m.MealIngredientQuantites).Where(m => m.Id == specificMealId);
                returnValue = meal.FirstOrDefault();
            }
            return returnValue;
        }
    }

}