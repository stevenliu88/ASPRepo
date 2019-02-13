namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AddedToDB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "AddedToDB", c => c.DateTime(nullable: false));
        }
    }
}
