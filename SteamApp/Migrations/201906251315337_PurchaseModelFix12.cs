namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModelFix12 : DbMigration
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
        }
    }
}
