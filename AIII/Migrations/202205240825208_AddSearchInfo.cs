namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSearchInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchInfoes",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Title = c.String(),
                    Genres = c.String(),
                    ImdbRating = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.SearchInfoes");
        }
    }
}
