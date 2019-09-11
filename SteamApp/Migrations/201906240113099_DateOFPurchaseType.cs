namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOFPurchaseType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "DateOfPurchase", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
