using System.Data.Entity;

namespace TomorrowsLunch.Models
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MealIngredientQuantity> MealIngredientQuantites { get; set; }
        public DbSet<Calendar> Calendars { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Calendar>()
                        .HasRequired<Meal>(c => c.Meal)
                        .WithMany(m => m.Calendars);

            modelBuilder.Entity<MealIngredientQuantity>()
                        .HasRequired<Meal>(miq => miq.Meal)
                        .WithMany(m => m.MealIngredientQuantites);

        }

    }
}