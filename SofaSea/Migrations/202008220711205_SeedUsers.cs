namespace SofaSea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'458e5dad-a161-41f1-a1a1-9a8bad36ec19', N'admin@sofasea.com', 0, N'AGmy/zoA4recQzIEMMRTSRXbH89LFDXiAtubD+xAJdCrDkZnrYl3ZhpU6RrNGv9rYQ==', N'bd4aae79-11b0-4e67-b30d-15d8750ea62a', NULL, 0, 0, NULL, 1, 0, N'admin@sofasea.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8c5217e5-4464-4ff6-8c6f-5bf80a6372d4', N'guest@sofasea.com', 0, N'ADSfAQfwBWZwUNpmquoyEUJMhLV1fQ9xlOBRwM6JX49rtZcwYAxmwFD2Jd/jrt/Jdg==', N'bf94163c-d9ba-41fe-ac28-45c32a0a1457', NULL, 0, 0, NULL, 1, 0, N'guest@sofasea.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'54602ba8-94f2-4f54-885c-6e027ffd5659', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'458e5dad-a161-41f1-a1a1-9a8bad36ec19', N'54602ba8-94f2-4f54-885c-6e027ffd5659')

");

        }
        public override void Down()
        {
        }
    }
}
