namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test33 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (2,'Action',11/09/2007,17/09/2016,3)");
          
        }
        
        public override void Down()
        {
        }
    }
}
