namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersAndRolesAgain : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8cdd848e-17bc-4bd1-9e63-943f49386bc3', N'b7d12111-fd20-45aa-9062-12717c94f72b')
");

        }

        public override void Down()
        {
        }
    }
}
