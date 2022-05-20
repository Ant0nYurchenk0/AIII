namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoPropertyInCustomMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomMovies", "Video", c => c.String(nullable: false));
            DropColumn("dbo.UserRatings", "Watched");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRatings", "Watched", c => c.Boolean());
            DropColumn("dbo.CustomMovies", "Video");
        }
    }
}
