namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a72d7a8-48de-44f0-816e-45b7672d688f', N'bulik2004x@gmail.com', 0, N'ACwVOzfisetQLFmyIZA/BMFmlARmRYG/RbI+skUNbqGSQRJFYOY7l7TZtRlaPvL37A==', N'537b77dd-ff95-40ae-a0ba-e61a5a96c737', NULL, 0, 0, NULL, 1, 0, N'bulik2004x@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad9ea8fb-38db-41ba-a5e0-6a4fa6d178fb', N'user@gmail.com', 0, N'AIKuQUC6x02kAvkQ1W5hlQ8uwLE7l/w0FFjl4xWMdavSBdGHlqDW3ZNeSyys5Ke7Ew==', N'dce07838-1513-4c86-b988-1bca2a15b352', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'056cc502-8e45-4073-850d-e32145664eb0', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10660009-f023-46c5-a659-cbb0e3d964b4', N'User')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a72d7a8-48de-44f0-816e-45b7672d688f', N'056cc502-8e45-4073-850d-e32145664eb0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad9ea8fb-38db-41ba-a5e0-6a4fa6d178fb', N'10660009-f023-46c5-a659-cbb0e3d964b4')

");
        }
        
        public override void Down()
        {
        }
    }
}
