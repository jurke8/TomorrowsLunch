namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredientmeals_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientMeals",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngredientId, t.MealId })
                .ForeignKey("dbo.Ingredients", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientMeals", "Id", "dbo.Meals");
            DropForeignKey("dbo.IngredientMeals", "Id", "dbo.Ingredients");
            DropIndex("dbo.IngredientMeals", new[] { "Id" });
            DropTable("dbo.IngredientMeals");
        }
    }
}
