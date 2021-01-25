namespace Project_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a55436e-3b48-47af-9664-91a5187a38ee', N'superadmin@watchit.com', 0, N'AMPZwOOsMoGyPY7wWeI/TAsayEsBp+tFFGXPxnS4ZJxEMjHILb8zuOhDlkA9rk4Kzw==', N'ef6ebb7c-f417-4e88-8a04-5f43078e2c04', NULL, 0, 0, NULL, 1, 0, N'superadmin@watchit.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8bbd9696-612a-40da-8671-e0a89d3c2d85', N'admin@watchit.com', 0, N'AD5Q5c3PuSTWN+GF2wk9s22DUEGmTBPZCKHLjQOfZndLHFE5Khn3nWqO+h7ngeHx9Q==', N'c7d2cf04-af7b-4e95-92e1-a80b20479be2', NULL, 0, 0, NULL, 1, 0, N'admin@watchit.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f611b596-b1bb-4347-953e-47d1840e3bb9', N'guest@watchit.com', 0, N'ALc7xuQAGtx8fBL+r9gMK1g3TvIxC2g2aB95uDW1dz3sv6iD+omduk8aaHgRKKAByQ==', N'00c610d7-1773-4ba1-993f-431d6aed3728', NULL, 0, 0, NULL, 1, 0, N'guest@watchit.com')
                  
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2bfad674-523e-4757-a55c-2203e958dd28', N'canManageMovies')

                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a55436e-3b48-47af-9664-91a5187a38ee', N'2bfad674-523e-4757-a55c-2203e958dd28')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
