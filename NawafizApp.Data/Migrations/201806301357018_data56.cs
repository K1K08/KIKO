namespace NawafizApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data56 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auction", "starttime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Auction", "endtime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auction", "endtime");
            DropColumn("dbo.Auction", "starttime");
        }
    }
}
