namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre_ReleaseDate");
            DropColumn("dbo.Movies", "Genre_DateAdded");
            DropColumn("dbo.Movies", "Genre_Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_ReleaseDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
