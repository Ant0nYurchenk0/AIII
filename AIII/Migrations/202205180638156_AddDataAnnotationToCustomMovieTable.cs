namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToCustomMovieTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomMovies", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.CustomMovies", "Genres", c => c.String(nullable: false));
            AlterColumn("dbo.CustomMovies", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.CustomMovies", "Countries", c => c.String(nullable: false));
            AlterColumn("dbo.CustomMovies", "Plot", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomMovies", "Plot", c => c.String());
            AlterColumn("dbo.CustomMovies", "Countries", c => c.String());
            AlterColumn("dbo.CustomMovies", "Type", c => c.String());
            AlterColumn("dbo.CustomMovies", "Genres", c => c.String());
            AlterColumn("dbo.CustomMovies", "Image", c => c.String());
        }
    }
}
