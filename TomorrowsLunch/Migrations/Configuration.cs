namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TomorrowsLunch.DummyData;
    using TomorrowsLunch.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TomorrowsLunch.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TomorrowsLunch.Models.ApplicationDbContext";
        }

        protected override void Seed(TomorrowsLunch.Models.ApplicationDbContext context)
        {
            try
            {
                var initialUserId = System.Guid.Empty;
                var initialDate = System.DateTime.Now;

                //MealsDummy.Data.ForEach(meal =>
                //{
                //    meal.DateCreated = initialDate;
                //    meal.CreatedByUser = initialUserId;
                //    //foreach (Ingredient ingredient in IngredientsDummy.Data)
                //    //{
                //    //    meal.Ingredients.Add(ingredient);
                //    //}
                //    context.Meals.AddOrUpdate(m => m.Name, meal);
                //});

                IngredientsDummy.Data.ForEach(ingredient =>
                {
                    ingredient.DateCreated = initialDate;
                    ingredient.CreatedByUser = initialUserId;
                    context.Ingredients.AddOrUpdate(i => i.Name, ingredient);
                });
                //MealIngredientQuantitiesDummy.Data.ForEach(mealIngredientQuantity =>
                //{
                //    mealIngredientQuantity.DateCreated = initialDate;
                //    mealIngredientQuantity.CreatedByUser = initialUserId;
                //    context.MealIngredientQuantites.AddOrUpdate(miq => miq.Name, mealIngredientQuantity);
                //});
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
