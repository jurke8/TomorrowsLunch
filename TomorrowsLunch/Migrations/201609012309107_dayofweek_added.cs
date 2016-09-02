namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayofweek_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "DayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "DayOfWeek");
        }
    }
}
