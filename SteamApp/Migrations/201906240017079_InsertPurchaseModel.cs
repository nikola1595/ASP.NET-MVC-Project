namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPurchaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        DateOfPurchase = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        ClientID = c.Int(),
                        GameID = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Games", t => t.GameID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodID, cascadeDelete: true)
                .Index(t => t.PaymentMethodID)
                .Index(t => t.ClientID)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.Purchases", "Game_GameID", "dbo.Games");
            DropForeignKey("dbo.Purchases", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.Purchases", new[] { "Game_GameID" });
            DropIndex("dbo.Purchases", new[] { "Client_ClientID" });
            DropIndex("dbo.Purchases", new[] { "PaymentMethodID" });
            DropTable("dbo.Purchases");
        }
    }
}
