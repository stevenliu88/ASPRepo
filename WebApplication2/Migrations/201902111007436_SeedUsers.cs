namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'129541b5-0a6a-4443-9d12-3fd4eaa9e863', N'admin@gmail.com', 0, N'AB70a2C3BgCPWwc0yIrbfi508jhDi7VdBdHXcf0FaIIIOUweEBwt1+4q9oKwzdW4NA==', N'55944d03-7688-49c9-bc68-3e0fdc583150', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd9bfdc11-30ee-45ed-b07a-896d84201e58', N'guest@gmail.com', 0, N'AIFJ5UCUkX5vr5rfSQDtDqlr8wBoeuqbKZ/0iR+udclIQ5k/6hKPWJjtFqWVwd1AHA==', N'705552a4-293b-4780-8040-68a40c9acb67', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ec458f64-72ec-4564-a03d-3bfcf4904465', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'129541b5-0a6a-4443-9d12-3fd4eaa9e863', N'ec458f64-72ec-4564-a03d-3bfcf4904465')


");
        }
        
        public override void Down()
        {
        }
    }
}
