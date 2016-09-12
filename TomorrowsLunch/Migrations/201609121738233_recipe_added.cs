namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipe_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "Recipe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "Recipe");
        }
    }
}
