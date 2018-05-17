namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WillRecieveRequisitionPosting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "WillReceiveRequisitionPosting", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "WillReceiveRequisitionPosting");
        }
    }
}
