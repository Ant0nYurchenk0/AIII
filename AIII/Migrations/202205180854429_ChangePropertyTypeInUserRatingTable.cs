namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangePropertyTypeInUserRatingTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRatings", "MovieId", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.UserRatings", "MovieId", c => c.Int(nullable: false));
        }
    }
}
