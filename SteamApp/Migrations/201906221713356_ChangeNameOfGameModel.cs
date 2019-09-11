namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameOfGameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameYearPublished", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "GameYear");


        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameYear", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "GameYearPublished");
        }
    }
}
