namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newyy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Stock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Stock", c => c.Int(nullable: false));
        }
    }
}
