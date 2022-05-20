namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfWatchedToInt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatings", "WatchedAmount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRatings", "WatchedAmount");
        }
    }
}
