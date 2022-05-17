namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToTeamMembersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamMembers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamMembers", "Name");
        }
    }
}
