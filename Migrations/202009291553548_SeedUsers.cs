namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29c32e9d-7b12-4a7f-abd6-d76c78c744d8', N'ghest@vidly.com', 0, N'AHozC0jQNnb4DtfKRFXg6miLTACpOJklzWJ6tdYXi0/lWkOjQ55iWh4uDtMWtuBvdg==', N'1ded414d-5f9f-48f0-aab2-71da8cca8419', NULL, 0, 0, NULL, 1, 0, N'ghest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b00775df-b063-4652-adb7-ae7791dc950b', N'admin@vidly.com', 0, N'ADSPHkgpFo60l3H6yFmRFFi9EGPVKt9AzN0bHbfjjmfZeROz7aYtk761eENU4++Wnw==', N'1871e889-fe71-4805-a085-a0422565e8dd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7af6467e-82d9-4773-918a-2d005dde832b', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b00775df-b063-4652-adb7-ae7791dc950b', N'7af6467e-82d9-4773-918a-2d005dde832b')
");
        }
        
        public override void Down()
        {
        }
    }
}
