namespace SteamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1056d49c-c9d5-4289-b5df-394cbaffa08f', N'admin@admin.com', 0, N'AKw00vDZX2KFADDEsxc8GG69pYm6XWfo1iAeI6shYof1q3/UUpYgBn0S5wTaB4RUGg==', N'cb0847ea-8e94-42e5-ad45-a01466a9a3d2', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'25c9d35f-c662-4fa6-a571-cf4c63ef223c', N'admin@steamapp.org', 0, N'AIhfKJ8sPcnsE/a4OseNjLm/7Y+EWHvRzWFAKEzTb+q5OJmzvZoszDuZIRh8eGlkjA==', N'ddb469c7-2c94-4370-b007-8e0e9bda7bcb', NULL, 0, 0, NULL, 1, 0, N'admin@steamapp.org')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2f86ef21-4f00-47ae-a23e-6b4c621cc294', N'admin@steamapp.com', 0, N'AEQlkjmWLDHxhthmlVcc+XN8DrOa46S2Xt/Nf8kJ4oH+oIGlO6azBO+6hKgFv1NieQ==', N'e2316c49-404f-4cea-9d58-24b0649fd6c9', NULL, 0, 0, NULL, 1, 0, N'admin@steamapp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84a0ce29-f0c3-4741-ade4-8372120f4d29', N'guest@steamapp.com', 0, N'APWWzr+3J5RhHT0UDvHHPGg1JulSqjbesXAWC784o8bKWRUswO9vfIdpeRVelnaAjA==', N'b74b84d5-daf0-4a09-b50e-e33be61f5412', NULL, 0, 0, NULL, 1, 0, N'guest@steamapp.com')
");

            Sql(@"INSERT INTO[dbo].[AspNetRoles]
        ([Id], [Name]) VALUES(N'36879349-28a6-489e-93ae-f3de7d247f86', N'CanManageGames')
");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25c9d35f-c662-4fa6-a571-cf4c63ef223c', N'36879349-28a6-489e-93ae-f3de7d247f86')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2f86ef21-4f00-47ae-a23e-6b4c621cc294', N'36879349-28a6-489e-93ae-f3de7d247f86')"); 

        }
        
        public override void Down()
        {
        }
    }
}
