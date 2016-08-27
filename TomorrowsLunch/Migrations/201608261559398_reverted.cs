namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverted : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MealIngredients", newName: "MealIngredient");
            DropForeignKey("dbo.IngredientMeals", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.IngredientMeals", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.IngredientMeals", new[] { "Ingredient_Id" });
            DropIndex("dbo.IngredientMeals", new[] { "Meal_Id" });
            RenameColumn(table: "dbo.MealIngredient", name: "Meal_Id", newName: "MealRefId");
            RenameColumn(table: "dbo.MealIngredient", name: "Ingredient_Id", newName: "IngredientRefId");
            RenameIndex(table: "dbo.MealIngredient", name: "IX_Meal_Id", newName: "IX_MealRefId");
            RenameIndex(table: "dbo.MealIngredient", name: "IX_Ingredient_Id", newName: "IX_IngredientRefId");
            DropTable("dbo.IngredientMeals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IngredientMeals",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredient_Id = c.Guid(),
                        Meal_Id = c.Guid(),
                    })
                .PrimaryKey(t => new { t.IngredientId, t.MealId });
            
            RenameIndex(table: "dbo.MealIngredient", name: "IX_IngredientRefId", newName: "IX_Ingredient_Id");
            RenameIndex(table: "dbo.MealIngredient", name: "IX_MealRefId", newName: "IX_Meal_Id");
            RenameColumn(table: "dbo.MealIngredient", name: "IngredientRefId", newName: "Ingredient_Id");
            RenameColumn(table: "dbo.MealIngredient", name: "MealRefId", newName: "Meal_Id");
            CreateIndex("dbo.IngredientMeals", "Meal_Id");
            CreateIndex("dbo.IngredientMeals", "Ingredient_Id");
            AddForeignKey("dbo.IngredientMeals", "Meal_Id", "dbo.Meals", "Id");
            AddForeignKey("dbo.IngredientMeals", "Ingredient_Id", "dbo.Ingredients", "Id");
            RenameTable(name: "dbo.MealIngredient", newName: "MealIngredients");
        }
    }
}
