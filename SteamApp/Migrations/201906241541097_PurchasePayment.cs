namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchasePayment : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Purchases", name: "PaymentMethodID", newName: "PaymentMethod_PaymentMethodID");
            RenameIndex(table: "dbo.Purchases", name: "IX_PaymentMethodID", newName: "IX_PaymentMethod_PaymentMethodID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Purchases", name: "IX_PaymentMethod_PaymentMethodID", newName: "IX_PaymentMethodID");
            RenameColumn(table: "dbo.Purchases", name: "PaymentMethod_PaymentMethodID", newName: "PaymentMethodID");
        }
    }
}
