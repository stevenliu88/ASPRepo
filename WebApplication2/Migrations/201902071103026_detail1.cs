namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detail1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name,ReleaseDate,DateAdded,Stock) VALUES (1,'Comdy',convert(datetime, '06/11/2009'),convert(datetime,'04/05/2016'),5)");
          
        }
        
        public override void Down()
        {
        }
    }
}
