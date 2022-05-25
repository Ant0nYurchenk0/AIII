namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagToSearchInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchInfoes", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SearchInfoes", "Tag");
        }
    }
}
