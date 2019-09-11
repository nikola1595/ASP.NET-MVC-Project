namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GamePrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "GamePrice");
            DropColumn("dbo.Games", "CategoryID");
        }
    }
}
