namespace AIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTeamMembersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TeamMembers ( Name, Photo, Role, GeneralInfo) VALUES " +
                "( 'Aleksandr', 'https://ibb.co/B2YX0sN', 'Developer, QA Engineer', '')");

            Sql("INSERT INTO TeamMembers ( Name, Photo, Role, GeneralInfo) VALUES " +
                "( 'Anton', 'https://ibb.co/B2YX0sN', ' Team Lead, Scrum Master', '')");

            Sql("INSERT INTO TeamMembers ( Name, Photo, Role, GeneralInfo) VALUES " +
                "( 'Anna', 'https://ibb.co/B2YX0sN', 'Developer, Site Designer', '')");
        }
        
        public override void Down()
        {
        }
    }
}
