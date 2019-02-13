namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDob : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers Set Birthday = '09/09/1988' WHERE NAME = 'steven liu' ");
            Sql("Update Customers Set Birthday = '10/05/2016' WHERE NAME = 'emily Liu' ");

        }
        
        public override void Down()
        {
        }
    }
}
