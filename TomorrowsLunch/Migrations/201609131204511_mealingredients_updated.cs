namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mealingredients_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealIngredientQuantities", "IngredientCarbohydrates", c => c.Int(nullable: false));
            AddColumn("dbo.MealIngredientQuantities", "IngredientFat", c => c.Int(nullable: false));
            AddColumn("dbo.MealIngredientQuantities", "IngredientProteins", c => c.Int(nullable: false));
            AddColumn("dbo.MealIngredientQuantities", "IngredientCalories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MealIngredientQuantities", "IngredientCalories");
            DropColumn("dbo.MealIngredientQuantities", "IngredientProteins");
            DropColumn("dbo.MealIngredientQuantities", "IngredientFat");
            DropColumn("dbo.MealIngredientQuantities", "IngredientCarbohydrates");
        }
    }
}
