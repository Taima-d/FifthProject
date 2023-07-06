using Microsoft.EntityFrameworkCore.Migrations;
namespace MyDbProject.Migrations
{
    public partial class assignAdmintoUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] ([UserId],[RoleId]) VALUES (N'3131abe3-5b67-4896-8fe7-bc5197a56045' ,N'0c463d5d-2010-4472-98b9-36ab15c183ad')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[UserRoles] WHERE UserId ='3131abe3-5b67-4896-8fe7-bc5197a56045' and RoleId='0c463d5d-2010-4472-98b9-36ab15c183ad' ");
        }
    }
}
