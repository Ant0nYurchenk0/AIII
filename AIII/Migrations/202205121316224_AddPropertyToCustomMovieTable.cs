namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToCustomMovieTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomMovies");
            DropPrimaryKey("dbo.Movies");
            //AddColumn("dbo.CustomMovies", "Id", c => c.String(nullable: false, maxLength: 128));
            //AddColumn("dbo.CustomMovies", "Image", c => c.String());
            //AddColumn("dbo.CustomMovies", "ReleaseDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.CustomMovies", "Genres", c => c.String());
            //AddColumn("dbo.CustomMovies", "Countries", c => c.String());
            //AddColumn("dbo.CustomMovies", "Stars", c => c.String());
            AddColumn("dbo.CustomMovies", "CumulativeWorldwideGross", c => c.String());
            AlterColumn("dbo.CustomMovies", "Budget", c => c.String());
            AlterColumn("dbo.Movies", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CustomMovies", "Id");
            AddPrimaryKey("dbo.Movies", "Id");
            //DropColumn("dbo.CustomMovies", "MovieId");
            //DropColumn("dbo.CustomMovies", "Poster");
            //DropColumn("dbo.CustomMovies", "Year");
            //DropColumn("dbo.CustomMovies", "Genre");
            //DropColumn("dbo.CustomMovies", "Country");
            //DropColumn("dbo.CustomMovies", "Cast");
            //DropColumn("dbo.CustomMovies", "BoxOffice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomMovies", "BoxOffice", c => c.Double(nullable: false));
            AddColumn("dbo.CustomMovies", "Cast", c => c.String());
            AddColumn("dbo.CustomMovies", "Country", c => c.String(nullable: false));
            AddColumn("dbo.CustomMovies", "Genre", c => c.String());
            AddColumn("dbo.CustomMovies", "Year", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomMovies", "Poster", c => c.String());
            AddColumn("dbo.CustomMovies", "MovieId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.CustomMovies");
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CustomMovies", "Budget", c => c.Double(nullable: false));
            DropColumn("dbo.CustomMovies", "CumulativeWorldwideGross");
            DropColumn("dbo.CustomMovies", "Stars");
            DropColumn("dbo.CustomMovies", "Countries");
            DropColumn("dbo.CustomMovies", "Genres");
            DropColumn("dbo.CustomMovies", "ReleaseDate");
            DropColumn("dbo.CustomMovies", "Image");
            DropColumn("dbo.CustomMovies", "Id");
            AddPrimaryKey("dbo.Movies", "Id");
            AddPrimaryKey("dbo.CustomMovies", "MovieId");
        }
    }
}
