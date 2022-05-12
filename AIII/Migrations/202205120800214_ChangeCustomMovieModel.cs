namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomMovieModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomMovies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.CustomMovies", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomMovies", "Country", c => c.String());
            AlterColumn("dbo.CustomMovies", "Title", c => c.String());
        }
    }
}
