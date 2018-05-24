namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisitions", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Requisitions", "Title", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Requisitions", "GenreId");
            AddForeignKey("dbo.Requisitions", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Requisitions", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requisitions", "Genre", c => c.String());
            DropForeignKey("dbo.Requisitions", "GenreId", "dbo.Genres");
            DropIndex("dbo.Requisitions", new[] { "GenreId" });
            AlterColumn("dbo.Requisitions", "Title", c => c.String());
            DropColumn("dbo.Requisitions", "GenreId");
        }
    }
}
