namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mealingredient_changed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MealIngredient", newName: "MealIngredients");
            RenameColumn(table: "dbo.MealIngredients", name: "MealRefId", newName: "Meal_Id");
            RenameColumn(table: "dbo.MealIngredients", name: "IngredientRefId", newName: "Ingredient_Id");
            RenameIndex(table: "dbo.MealIngredients", name: "IX_MealRefId", newName: "IX_Meal_Id");
            RenameIndex(table: "dbo.MealIngredients", name: "IX_IngredientRefId", newName: "IX_Ingredient_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MealIngredients", name: "IX_Ingredient_Id", newName: "IX_IngredientRefId");
            RenameIndex(table: "dbo.MealIngredients", name: "IX_Meal_Id", newName: "IX_MealRefId");
            RenameColumn(table: "dbo.MealIngredients", name: "Ingredient_Id", newName: "IngredientRefId");
            RenameColumn(table: "dbo.MealIngredients", name: "Meal_Id", newName: "MealRefId");
            RenameTable(name: "dbo.MealIngredients", newName: "MealIngredient");
        }
    }
}
