namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
