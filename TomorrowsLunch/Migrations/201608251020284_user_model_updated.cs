namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_model_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Activity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Activity");
            DropColumn("dbo.Users", "Weight");
            DropColumn("dbo.Users", "Height");
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Gender");
        }
    }
}
