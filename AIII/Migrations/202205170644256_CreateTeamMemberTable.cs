namespace AIII.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateTeamMemberTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamMembers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Photo = c.String(),
                    Role = c.String(),
                    GeneralInfo = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.TeamMembers");
        }
    }
}
