namespace NawafizApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.H_View",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.House", "h_ViewId", c => c.Int(nullable: false));
            CreateIndex("dbo.House", "h_ViewId");
            AddForeignKey("dbo.House", "h_ViewId", "dbo.H_View", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.House", "h_ViewId", "dbo.H_View");
            DropIndex("dbo.House", new[] { "h_ViewId" });
            DropColumn("dbo.House", "h_ViewId");
            DropTable("dbo.H_View");
        }
    }
}
