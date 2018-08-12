namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSpecialUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f06a3fd4-13f1-45c4-bbb0-c393d1fa6464', N'surauciusevaldas@gmail.com', 1, N'AABx0vR7Q4ycDIsePxFZoOMIMIUCnWMjjlHk94TUQ9ggTYXujjXTfxmQKlRy71s2UQ==', N'c8f84991-b637-4b66-9707-214bea7deacf', NULL, 0, 0, NULL, 1, 0, N'Evaldas')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0e391ce4-59bb-4f30-b34e-3083a5e1a39a', N'CanManageUsers')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f06a3fd4-13f1-45c4-bbb0-c393d1fa6464', N'0e391ce4-59bb-4f30-b34e-3083a5e1a39a')    
            ");
        }
        
        public override void Down()
        {
        }
    }
}
