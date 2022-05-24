namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameUserRatingTableColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatings", "LikesAmount", c => c.Int());
            AddColumn("dbo.UserRatings", "DislikesAmount", c => c.Int());
            DropColumn("dbo.UserRatings", "GoodEmodjiAmount");
            DropColumn("dbo.UserRatings", "BadEmodjiAmount");
        }

        public override void Down()
        {
            AddColumn("dbo.UserRatings", "BadEmodjiAmount", c => c.Int(nullable: false));
            AddColumn("dbo.UserRatings", "GoodEmodjiAmount", c => c.Int(nullable: false));
            DropColumn("dbo.UserRatings", "DislikesAmount");
            DropColumn("dbo.UserRatings", "LikesAmount");
        }
    }
}
