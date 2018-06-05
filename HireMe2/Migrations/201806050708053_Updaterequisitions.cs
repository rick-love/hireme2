namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updaterequisitions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requisitions", "DateOpened", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requisitions", "DateOpened", c => c.String());
        }
    }
}
