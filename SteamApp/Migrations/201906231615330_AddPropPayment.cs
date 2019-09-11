namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropPayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "PaymentMethodID", "dbo.PaymentMethods");
            DropIndex("dbo.Purchases", new[] { "PaymentMethodID" });
            DropPrimaryKey("dbo.PaymentMethods");
            AlterColumn("dbo.PaymentMethods", "PaymentMethodID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PaymentMethods", "PaymentMethodID");
            DropTable("dbo.Purchases");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        DateOfPurchase = c.DateTime(nullable: false),
                        PaymentMethodID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            DropPrimaryKey("dbo.PaymentMethods");
            AlterColumn("dbo.PaymentMethods", "PaymentMethodID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.PaymentMethods", "PaymentMethodID");
            CreateIndex("dbo.Purchases", "PaymentMethodID");
            AddForeignKey("dbo.Purchases", "PaymentMethodID", "dbo.PaymentMethods", "PaymentMethodID", cascadeDelete: true);
        }
    }
}
