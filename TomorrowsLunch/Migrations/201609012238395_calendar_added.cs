namespace TomorrowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendar_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CalendarDate = c.DateTime(nullable: false),
                        CreatedByUser = c.Guid(nullable: false),
                        MealId = c.Guid(nullable: false),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "MealId", "dbo.Meals");
            DropIndex("dbo.Calendars", new[] { "MealId" });
            DropTable("dbo.Calendars");
        }
    }
}
