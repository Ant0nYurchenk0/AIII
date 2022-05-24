namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    MovieId = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Poster = c.String(),
                    Year = c.DateTime(nullable: false),
                    Genre = c.String(),
                    Type = c.String(),
                    Country = c.String(),
                    Cast = c.String(),
                    Plot = c.String(),
                    Budget = c.Double(nullable: false),
                    BoxOffice = c.Double(nullable: false),
                    RatingIMDB = c.String(),
                    SiteUserRating = c.Double(nullable: false),
                    GoodEmodjiAmount = c.Int(nullable: false),
                    BadEmodjiAmount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MovieId);


        }

        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
