using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;


namespace TommorowsLunch.Providers
{
    public class MealProvider
    {
        public List<Meal> GetAllMeals()
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
        public Meal GetSpecificMeal(Guid specificMealId)
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
        public Meal UpdateMeal(Meal updatedMeal)
        {
            using (var db = new ApplicationDbContext())
            {
                //db.Meals.Attach(newMeal);
                db.Entry(updatedMeal).State = EntityState.Modified;
                db.SaveChanges();
            }
            return updatedMeal;
        }
        public Meal CreateMeal(Meal newMeal)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Meals.Add(newMeal);
                db.SaveChanges();
            }
            return newMeal;
        }
        public Meal DeleteMeal(Meal meal)
        {
            meal.Deleted = true;
            return UpdateMeal(meal);
        }
    }
    //public class DataModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}