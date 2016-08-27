namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_quantity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientQuantities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MealId = c.Guid(nullable: false),
                        IngredientId = c.Guid(nullable: false),
                        CreatedByUser = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IngredientQuantities");
        }
    }
}
