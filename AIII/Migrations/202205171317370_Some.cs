namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ImdbKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ImdbKey", c => c.String());
        }
    }
}
