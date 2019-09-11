namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'12b9fdfb-32a2-4145-9b98-f6b7b4e55a20', N'admin@steamapp.com', 0, N'AK1q9kOCSLwAwG9Kaam8nJGQqCmosRVQiQJ5WqOeWQveFOSYUqVTPYxf6WO6HlLCdg==', N'94eb8778-907d-41ff-a2e9-1e016e618508', NULL, 0, 0, NULL, 1, 0, N'admin@steamapp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd372eaf2-0625-47f0-a65f-cc7f66ae9c24', N'guest@steamapp.com', 0, N'AObDtN+jBPI2N4aiTyDVQZiV5PesvGAIGgaGvrKd7RtY8WYGtg7M6On2p7ThmGKEyA==', N'472420a6-4ab0-4894-95e4-1a63d7e85de2', NULL, 0, 0, NULL, 1, 0, N'guest@steamapp.com')
");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1b027e16-b180-441c-8f1b-c11f81bd158b', N'CanManageGames')
");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'12b9fdfb-32a2-4145-9b98-f6b7b4e55a20', N'1b027e16-b180-441c-8f1b-c11f81bd158b')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd372eaf2-0625-47f0-a65f-cc7f66ae9c24', N'1b027e16-b180-441c-8f1b-c11f81bd158b')
");
        }
        
        public override void Down()
        {
        }
    }
}
