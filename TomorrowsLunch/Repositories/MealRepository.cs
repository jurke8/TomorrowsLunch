using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;

namespace TomorrowsLunch.Repositories
{
    public class MealRepository : BaseRepository<Meal>
    {
        public List<Meal> GetAll()
        {
            IQueryable<Meal> meals;
            var mealsList = new List<Meal>();
            using (var db = new ApplicationDbContext())
            {
                meals = db.Meals.Include(m => m.Ingredients).Where(m => !m.Deleted);
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
                meal = db.Meals.Include(p => p.Ingredients).Where(m => m.Id == specificMealId);
                returnValue = meal.FirstOrDefault();
            }
            return returnValue;
        }
    }
   
}