namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddImbdKeyToUserNullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImdbKey", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImdbKey");
        }
    }
}
