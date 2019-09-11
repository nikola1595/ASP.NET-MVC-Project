namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);


            Sql("SET UPDATE  Categories SET CategoryDetails='Multiplayer online battle arena(MOBA), also known as action real - time strategy(ARTS), is a subgenre of strategy video games that originated as a subgenre of real - time strategy, in which a player controls a single character in a team who compete versus another team of players',WHERE CategoryID=1)");
            Sql("SET UPDATE  Categories SET CategoryDetails='A role-playing game (RPG) is a genre of video game where the gamer controls a fictional character (or characters) that undertakes a quest in an imaginary world.',WHERE CategoryID=2)");
            Sql("SET UPDATE  Categories SET CategoryDetails='Massively multiplayer online role-playing games (MMORPGs) are a combination of role-playing video games and massively multiplayer online games in which a very large number of players interact with one another within a virtual world.',WHERE CategoryID= 3)");
            Sql("SET UPDATE  Categories SET CategoryDetails='First-person shooter (FPS) is a video game genre centered around gun and other weapon-based combat in a first-person perspective; that is, the player experiences the action through the eyes of the protagonist. ',WHERE CategoryID= 4)");
            Sql("SET UPDATE  Categories SET CategoryDetails='Roguelike is a subgenre of role-playing video game characterized by a dungeon crawl through procedurally generated levels, turn-based gameplay, tile-based graphics, and permanent death of the player character.',WHERE CategoryID= 5)");
            Sql("SET UPDATE  Categories SET CategoryDetails='Action-adventure is a video game genre that combine core elements from both the action game and adventure game genres.With the decline of the adventure game genre from mainstream popularity, the use of the term(and the hybrid term action-adventure) has been more liberal.It is not uncommon for gamers to apply the term adventure or action to describe the genre of fiction to which a game belongs, and not the gameplay itself.',WHERE CategoryID= 6)");
            

        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
