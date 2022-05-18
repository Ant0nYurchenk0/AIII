namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyTypeInUserRatingTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRatings", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRatings", "UserId", c => c.Int(nullable: false));
        }
    }
}
