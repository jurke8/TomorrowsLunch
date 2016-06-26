namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ingredients_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Carbohydrates", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredients", "Fat", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredients", "Proteins", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "Proteins");
            DropColumn("dbo.Ingredients", "Fat");
            DropColumn("dbo.Ingredients", "Carbohydrates");
        }
    }
}
