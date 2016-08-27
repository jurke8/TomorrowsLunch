namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany_added : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IngredientQuantities", newName: "MealIngredientQuantities");
            CreateIndex("dbo.MealIngredientQuantities", "MealId");
            AddForeignKey("dbo.MealIngredientQuantities", "MealId", "dbo.Meals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealIngredientQuantities", "MealId", "dbo.Meals");
            DropIndex("dbo.MealIngredientQuantities", new[] { "MealId" });
            RenameTable(name: "dbo.MealIngredientQuantities", newName: "IngredientQuantities");
        }
    }
}
