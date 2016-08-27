namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredientName_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealIngredientQuantities", "IngredientName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MealIngredientQuantities", "IngredientName");
        }
    }
}
