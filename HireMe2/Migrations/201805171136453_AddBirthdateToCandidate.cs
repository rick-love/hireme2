namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCandidate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Birthdate");
        }
    }
}
