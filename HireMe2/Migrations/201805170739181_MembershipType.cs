namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Candidates", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Candidates", "MembershipTypeId");
            AddForeignKey("dbo.Candidates", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Candidates", new[] { "MembershipTypeId" });
            DropColumn("dbo.Candidates", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
