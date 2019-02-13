namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTEst2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
