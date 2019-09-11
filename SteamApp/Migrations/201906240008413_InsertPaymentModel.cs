namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPaymentModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PaymentMethods(PaymentMethodName) VALUES('Visa')");
            Sql("INSERT INTO PaymentMethods(PaymentMethodName) VALUES('MasterCard')");
            Sql("INSERT INTO PaymentMethods(PaymentMethodName) VALUES('Paypal')");
        }
        
        public override void Down()
        {

        }
    }
}
