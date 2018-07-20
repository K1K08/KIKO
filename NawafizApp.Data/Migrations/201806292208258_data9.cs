namespace NawafizApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "EmailConfirmed", c => c.Boolean());
            AlterColumn("dbo.User", "PhoneNumberConfirmed", c => c.Boolean());
            AlterColumn("dbo.User", "TwoFactorEnabled", c => c.Boolean());
            AlterColumn("dbo.User", "LockoutEnabled", c => c.Boolean());
            AlterColumn("dbo.User", "AccessFailedCount", c => c.Int());
            AlterColumn("dbo.User", "FullName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "FullName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.User", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "LockoutEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "EmailConfirmed", c => c.Boolean(nullable: false));
        }
    }
}
