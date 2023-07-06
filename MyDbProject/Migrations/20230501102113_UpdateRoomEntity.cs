using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDbProject.Migrations
{
    public partial class UpdateRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomSize",
                table: "RoomEntities",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "RoomDirection",
                table: "RoomEntities",
                newName: "RoomSizeW");

            migrationBuilder.AddColumn<string>(
                name: "RoomDirection1",
                table: "RoomEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomDirection2",
                table: "RoomEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomSizeH",
                table: "RoomEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.DropColumn(
                name: "RoomDirection1",
                table: "RoomEntities");

            migrationBuilder.DropColumn(
                name: "RoomDirection2",
                table: "RoomEntities");

            migrationBuilder.DropColumn(
                name: "RoomSizeH",
                table: "RoomEntities");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "RoomEntities",
                newName: "RoomSize");

            migrationBuilder.RenameColumn(
                name: "RoomSizeW",
                table: "RoomEntities",
                newName: "RoomDirection");
        }
    }
}
