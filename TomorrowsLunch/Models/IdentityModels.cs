using System.Data.Entity;

namespace TomorrowsLunch.Models
{
     //You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //}

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Meal>()
                        .HasMany<Ingredient>(i => i.Ingredients)
                        .WithMany(m => m.Meals)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MealRefId");
                            cs.MapRightKey("IngredientRefId");
                            cs.ToTable("MealIngredient");
                        });
        }
        
    }
}