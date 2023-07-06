using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDbProject.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserType], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3131abe3-5b67-4896-8fe7-bc5197a56045', 3, N'Admin', N'ADMIN', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHcWyHBfDhT4nlw4o1H9z745SRv7xMh/xzGjduh9kdc6FSWLv6G83Ty7qEWNzJSQxQ==', N'TKAPZFZ3D3DSXFODUC7RCINGU6EYEZ37', N'ed61a287-7d19-457d-bb2c-8398bef374e2', NULL, 0, 0, NULL, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[Users] where Id= '3131abe3-5b67-4896-8fe7-bc5197a56045' ");
        }
    }
}
