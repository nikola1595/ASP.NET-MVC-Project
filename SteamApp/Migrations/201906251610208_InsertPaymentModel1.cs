namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPaymentModel1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PaymentMethods(PaymentMethodID,PaymentMethodName) VALUES(1,'Visa')");
            Sql("INSERT INTO PaymentMethods(PaymentMethodID,PaymentMethodName) VALUES(2,'MasterCard')");
            Sql("INSERT INTO PaymentMethods(PaymentMethodID,PaymentMethodName) VALUES(3,'Paypal')");
        }
        
        public override void Down()
        {
        }
    }
}
