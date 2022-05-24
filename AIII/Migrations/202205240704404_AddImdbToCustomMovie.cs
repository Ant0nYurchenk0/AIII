namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddImdbToCustomMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomMovies", "ImdbRating", c => c.Double());
        }

        public override void Down()
        {
            DropColumn("dbo.CustomMovies", "ImdbRating");
        }
    }
}
