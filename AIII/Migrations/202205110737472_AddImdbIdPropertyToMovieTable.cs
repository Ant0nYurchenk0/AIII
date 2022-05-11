namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImdbIdPropertyToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImdbMovieId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ImdbMovieId");
        }
    }
}
