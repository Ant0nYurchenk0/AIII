namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddImageToSearchInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchInfoes", "Image", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.SearchInfoes", "Image");
        }
    }
}
