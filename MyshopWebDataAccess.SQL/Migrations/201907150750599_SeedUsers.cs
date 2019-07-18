namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'227fcda6-892d-45eb-984d-cad45126b069', N'guest@gmail.com', 0, N'AIySEFJBqhSYdu1JMTymaTpdKTRkElRyWTSGF1L87AtC+E+UVDpNVttq6a16oMuvgw==', N'fad0ffcf-6417-4904-af77-f2574978aed5', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd7d837d8-4a31-4ced-8b93-efda3047dcae', N'admin@gmail.com', 0, N'AMqjKbXmaJBSEpP9cajfJ6fYgjlTfBhwFGHxGo+rXih43Mjm1ZCtnc9bpI1svzMEBw==', N'b1afe476-7616-475b-bf65-2782ee6bd706', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'782259f4-5383-4716-bf9f-f967e286b90e', N'CanManageProduct')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd7d837d8-4a31-4ced-8b93-efda3047dcae', N'782259f4-5383-4716-bf9f-f967e286b90e')
");
        }

    public override void Down()
        {
        }
    }
}
