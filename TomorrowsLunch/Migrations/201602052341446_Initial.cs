namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedByUser = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedByUser = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealIngredient",
                c => new
                    {
                        MealRefId = c.Guid(nullable: false),
                        IngredientRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealRefId, t.IngredientRefId })
                .ForeignKey("dbo.Meals", t => t.MealRefId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientRefId, cascadeDelete: true)
                .Index(t => t.MealRefId)
                .Index(t => t.IngredientRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealIngredient", "IngredientRefId", "dbo.Ingredients");
            DropForeignKey("dbo.MealIngredient", "MealRefId", "dbo.Meals");
            DropIndex("dbo.MealIngredient", new[] { "IngredientRefId" });
            DropIndex("dbo.MealIngredient", new[] { "MealRefId" });
            DropTable("dbo.MealIngredient");
            DropTable("dbo.Meals");
            DropTable("dbo.Ingredients");
        }
    }
}
