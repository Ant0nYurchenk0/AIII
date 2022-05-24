namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddWatchedToUserRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatings", "Watched", c => c.Boolean());
        }

        public override void Down()
        {
            DropColumn("dbo.UserRatings", "Watched");
        }
    }
}
