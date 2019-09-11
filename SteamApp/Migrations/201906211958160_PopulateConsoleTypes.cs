namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateConsoleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ConsoleTypes (ConsoleTypeID, ConsoleName, SignUpFee, DurationInMonths) VALUES(1,'PC',0,0)");
            Sql("INSERT INTO ConsoleTypes (ConsoleTypeID, ConsoleName, SignUpFee, DurationInMonths) VALUES(2,'Xbox One',30,3)");
            Sql("INSERT INTO ConsoleTypes (ConsoleTypeID, ConsoleName, SignUpFee, DurationInMonths) VALUES(3,'PS4',40,6)");
            Sql("INSERT INTO ConsoleTypes (ConsoleTypeID, ConsoleName, SignUpFee, DurationInMonths) VALUES(4,'Xbox360',50,8)");
            Sql("INSERT INTO ConsoleTypes (ConsoleTypeID, ConsoleName, SignUpFee, DurationInMonths) VALUES(5,'PS5',100,12)");
        }
        
        public override void Down()
        {
        }
    }
}
