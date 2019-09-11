namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsoleType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsoleTypes",
                c => new
                    {
                        ConsoleTypeID = c.Byte(nullable: false),
                        ConsoleName = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ConsoleTypeID);
            
            AddColumn("dbo.Clients", "IsSubscribedOnSteam", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "ConsoleTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clients", "ConsoleTypeID");
            AddForeignKey("dbo.Clients", "ConsoleTypeID", "dbo.ConsoleTypes", "ConsoleTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "ConsoleTypeID", "dbo.ConsoleTypes");
            DropIndex("dbo.Clients", new[] { "ConsoleTypeID" });
            DropColumn("dbo.Clients", "ConsoleTypeID");
            DropColumn("dbo.Clients", "IsSubscribedOnSteam");
            DropTable("dbo.ConsoleTypes");
        }
    }
}
