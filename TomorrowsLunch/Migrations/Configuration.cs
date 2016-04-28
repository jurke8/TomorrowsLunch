namespace TommorowsLunch.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            var initialUserId = System.Guid.NewGuid();
            var initialDate = System.DateTime.Now;

            MealsDummy.Data.ForEach(meal =>
            {
                meal.DateCreated = initialDate;
                meal.CreatedByUser = initialUserId;
                foreach (Ingredient ingredient in IngredientsDummy.Data)
                {
                    meal.Ingredients.Add(ingredient);
                }
                context.Meals.AddOrUpdate(m => m.Name, meal);
            });

            IngredientsDummy.Data.ForEach(ingredient =>
            {
                ingredient.DateCreated = initialDate;
                ingredient.CreatedByUser = initialUserId;
                context.Ingredients.AddOrUpdate(i => i.Name, ingredient);

            });
            context.SaveChanges();

        }
    }
}
