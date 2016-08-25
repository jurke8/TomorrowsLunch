namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calories_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Calories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "Calories");
        }
    }
}
