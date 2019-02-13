namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test44 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (2,'Action',convert(datetime, '06/11/2009'),convert(datetime,'04/05/2016'),5)");
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (3,'Action',convert(datetime, '06/11/2009'),convert(datetime,'04/05/2016'),10)");
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (4,'Family',convert(datetime, '06/11/2009'),convert(datetime,'04/05/2016'),7)");
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (5,'Romance',convert(datetime, '06/11/2009'),convert(datetime,'04/05/2016'),11)");
        }
        
        public override void Down()
        {
        }
    }
}
