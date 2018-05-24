namespace HireMe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Development') ");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Architecture') ");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'DevOps') ");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Database') ");
        }
        
        public override void Down()
        {
        }
    }
}
