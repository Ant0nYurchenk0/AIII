namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeCustomMovieModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomMovies", "Title", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.CustomMovies", "Title", c => c.String());
        }
    }
}
