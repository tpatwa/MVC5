namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersAndRoles : DbMigration
    {
        public override void Up()
        {
//            Sql(@"
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8cdd848e-17bc-4bd1-9e63-943f49386bc3', N'admin@vidly.com', 0, N'ADzvSvNZCBvDkLZkjIceNiNFI4REMmp+rlbUoTS7gep10Aq9fbzorCtLnGRocXUnXA==', N'c3322420-2f00-4ffc-affa-bddc810c35ca', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fae586ab-46ab-41c0-b904-f57fc87940d6', N'guest@vidly.com', 0, N'AKnWTArR3b3JiKPIvSbKL4KJ+VRVca1Npbqr7F7iXMTEVfVSFa7l2ATpRRqzz82FpA==', N'748ecdad-158b-4992-b2bd-e081cc5562c1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b7d12111-fd20-45aa-9062-12717c94f72b', N'CanManageMovies')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8cdd848e-17bc-4bd1-9e63-943f49386bc3', N'b7d12111-fd20-45aa-9062-12717c94f72b')
//");

            Sql(@"

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8cdd848e-17bc-4bd1-9e63-943f49386bc3', N'b7d12111-fd20-45aa-9062-12717c94f72b')
");


        }
        
        public override void Down()
        {
        }
    }
}
