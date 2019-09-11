namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelPurchase : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Purchases", "PaymentMethodID");
            AddForeignKey("dbo.Purchases", "PaymentMethodID", "dbo.PaymentMethods", "PaymentMethodID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "PaymentMethodID", "dbo.PaymentMethods");
            DropIndex("dbo.Purchases", new[] { "PaymentMethodID" });
        }
    }
}
