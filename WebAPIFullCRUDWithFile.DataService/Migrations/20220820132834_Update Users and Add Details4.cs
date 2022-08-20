using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIFullCRUDWithFile.DataService.Migrations
{
    public partial class UpdateUsersandAddDetails4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UsersId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UsersId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UserDetails");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UserId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UsersId",
                table: "UserDetails",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UsersId",
                table: "UserDetails",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
