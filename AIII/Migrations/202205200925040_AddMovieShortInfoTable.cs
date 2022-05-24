namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMovieShortInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieShortInfoes",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Title = c.String(),
                    Image = c.String(),
                    ImdbRating = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.MovieShortInfoes");
        }
    }
}
