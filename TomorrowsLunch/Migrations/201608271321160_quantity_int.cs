namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantity_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealIngredientQuantities", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealIngredientQuantities", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
