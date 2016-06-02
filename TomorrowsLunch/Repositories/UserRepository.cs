using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;


namespace TomorrowsLunch.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        //    public List<User> GetAllUsers()
        //    {
        //        IQueryable<User> users;
        //        var mealsList = new List<Meal>();
        //        using (var db = new ApplicationDbContext())
        //        {
        //            users = db.
        //        }
        //        return mealsList;
        //    }
        //    public User GetSpecificMeal(Guid specificMealId)
        //    {
        //        Meal returnValue;
        //        IQueryable<User> meal;
        //        using (var db = new ApplicationDbContext())
        //        {
        //            //include
        //            meal = db.Meals.Include(p => p.Ingredients).Where(m => m.Id == specificMealId);
        //            returnValue = meal.FirstOrDefault();
        //        }
        //        return returnValue;
        //    }
        //    public User UpdateMeal(User updatedMeal)
        //    {
        //        using (var db = new ApplicationDbContext())
        //        {
        //            //db.Meals.Attach(newMeal);
        //            db.Entry(updatedMeal).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return updatedMeal;
        //    }
        //    public User CreateMeal(User newMeal)
        //    {
        //        using (var db = new ApplicationDbContext())
        //        {
        //            db.Meals.Add(newMeal);
        //            db.SaveChanges();
        //        }
        //        return newMeal;
        //    }
        //    public Meal DeleteMeal(User meal)
        //    {
        //        meal.Deleted = true;
        //        return UpdateMeal(meal);
        //    }
        //}
        //public class DataModel
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    }
}