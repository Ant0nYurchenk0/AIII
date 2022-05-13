namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomMoviePropertyName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomMovies");
            AlterColumn("dbo.CustomMovies", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CustomMovies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomMovies");
            AlterColumn("dbo.CustomMovies", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CustomMovies", "Id");
        }
    }
}
