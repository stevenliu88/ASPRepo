namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
