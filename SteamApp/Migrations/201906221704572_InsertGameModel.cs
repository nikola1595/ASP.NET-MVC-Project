namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGameModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games(Name,GameYearPublished,GameFor,CategoryID,GamePrice) VALUES('Dota 2',2012,'PC',1,0)");
            Sql("INSERT INTO Games(Name,GameYearPublished,GameFor,CategoryID,GamePrice) VALUES('Tom Clancy The Division',2016,'PC Xbox One PS4',2,40)");
            Sql("INSERT INTO Games(Name,GameYearPublished,GameFor,CategoryID,GamePrice) VALUES('Elder Scrolls Online',2014,'PC PS4 Xbox One',3,15)");
            Sql("INSERT INTO Games(Name,GameYearPublished,GameFor,CategoryID,GamePrice) VALUES('Borderlands 2',2014,'PC Xbox 360',4,60)");
            Sql("INSERT INTO Games(Name,GameYearPublished,GameFor,CategoryID,GamePrice) VALUES('The Binding of Isaac: Rebirth',2014,'PC',5,11)");

        }
        
        public override void Down()
        {
        }
    }
}
