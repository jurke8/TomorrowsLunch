namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealIngredient", "MealRefId", "dbo.Meals");
            DropForeignKey("dbo.MealIngredient", "IngredientRefId", "dbo.Ingredients");
            DropIndex("dbo.MealIngredient", new[] { "MealRefId" });
            DropIndex("dbo.MealIngredient", new[] { "IngredientRefId" });
            DropTable("dbo.MealIngredient");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        MealRefId = c.Guid(nullable: false),
                        IngredientRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealRefId, t.IngredientRefId });
            
            CreateIndex("dbo.MealIngredient", "IngredientRefId");
            CreateIndex("dbo.MealIngredient", "MealRefId");
            AddForeignKey("dbo.MealIngredient", "IngredientRefId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MealIngredient", "MealRefId", "dbo.Meals", "Id", cascadeDelete: true);
        }
    }
}
