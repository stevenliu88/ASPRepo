namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addName1 : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Pay as you go' WHERE Id = 0");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Quarter' WHERE Id = 2");
            Sql("Update MembershipTypes SET Name = 'Annual' WHERE Id = 3");


        }

        public override void Down()
        {
        }
    }
}
