namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedModeratorRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'187c025c-12bf-4282-9dbc-e65b9a72ed86', N'Moderator')");
        }
        
        public override void Down()
        {
        }
    }
}
