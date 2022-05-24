namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeMovieTableCreateCustomMovieTableCreateUserRatingTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Movies");
            CreateTable(
                "dbo.CustomMovies",
                c => new
                {
                    MovieId = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Poster = c.String(),
                    Year = c.DateTime(nullable: false),
                    Genre = c.String(),
                    Type = c.String(),
                    Country = c.String(),
                    Plot = c.String(),
                    Budget = c.Double(nullable: false),
                    Cast = c.String(),
                    BoxOffice = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.MovieId);

            CreateTable(
                "dbo.UserRatings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    MovieId = c.Int(nullable: false),
                    GoodEmodjiAmount = c.Int(nullable: false),
                    BadEmodjiAmount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movies", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "IsInIMDB", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
            DropColumn("dbo.Movies", "MovieId");
            DropColumn("dbo.Movies", "ImdbMovieId");
            DropColumn("dbo.Movies", "Title");
            DropColumn("dbo.Movies", "Poster");
            DropColumn("dbo.Movies", "Year");
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "Type");
            DropColumn("dbo.Movies", "Country");
            DropColumn("dbo.Movies", "Cast");
            DropColumn("dbo.Movies", "Plot");
            DropColumn("dbo.Movies", "Budget");
            DropColumn("dbo.Movies", "BoxOffice");
            DropColumn("dbo.Movies", "RatingIMDB");
            DropColumn("dbo.Movies", "SiteUserRating");
            DropColumn("dbo.Movies", "GoodEmodjiAmount");
            DropColumn("dbo.Movies", "BadEmodjiAmount");
        }

        public override void Down()
        {
            AddColumn("dbo.Movies", "BadEmodjiAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GoodEmodjiAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "SiteUserRating", c => c.Double(nullable: false));
            AddColumn("dbo.Movies", "RatingIMDB", c => c.String());
            AddColumn("dbo.Movies", "BoxOffice", c => c.Double(nullable: false));
            AddColumn("dbo.Movies", "Budget", c => c.Double(nullable: false));
            AddColumn("dbo.Movies", "Plot", c => c.String());
            AddColumn("dbo.Movies", "Cast", c => c.String());
            AddColumn("dbo.Movies", "Country", c => c.String());
            AddColumn("dbo.Movies", "Type", c => c.String());
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Year", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Poster", c => c.String());
            AddColumn("dbo.Movies", "Title", c => c.String());
            AddColumn("dbo.Movies", "ImdbMovieId", c => c.Int());
            AddColumn("dbo.Movies", "MovieId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Movies");
            DropColumn("dbo.Movies", "IsInIMDB");
            DropColumn("dbo.Movies", "Id");
            DropTable("dbo.UserRatings");
            DropTable("dbo.CustomMovies");
            AddPrimaryKey("dbo.Movies", "MovieId");
        }
    }
}
