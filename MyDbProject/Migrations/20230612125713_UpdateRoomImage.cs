using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDbProject.Migrations
{
    public partial class UpdateRoomImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "RoomImageEntities");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "RoomImageEntities",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "RoomImageEntities",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "RoomImageEntities",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
