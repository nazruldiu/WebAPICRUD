using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIFullCRUDWithFile.DataService.Migrations
{
    public partial class UpdateUsersandAddDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Emial",
                table: "Users",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "UserDetailsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserModelEntityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetailsEntity_Users_UserModelEntityId",
                        column: x => x.UserModelEntityId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetailsEntity_UserModelEntityId",
                table: "UserDetailsEntity",
                column: "UserModelEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetailsEntity");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Emial");

            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Users",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
