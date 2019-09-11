namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intPayment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "PaymentMethodID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "PaymentMethodID", c => c.Byte(nullable: false));
        }
    }
}
