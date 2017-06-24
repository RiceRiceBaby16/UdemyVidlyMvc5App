namespace CourseByMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Horror');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Science Fiction');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romantic Comedy');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Thriller');");
        }
        
        public override void Down()
        {
        }
    }
}
