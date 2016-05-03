namespace TommorowsLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password_changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }
    }
}
