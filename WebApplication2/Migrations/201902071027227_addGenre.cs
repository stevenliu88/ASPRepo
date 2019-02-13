namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre_ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Genre_Stock");
            DropColumn("dbo.Movies", "Genre_DateAdded");
            DropColumn("dbo.Movies", "Genre_ReleaseDate");
        }
    }
}
