using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIFullCRUDWithFile.DataService.Migrations
{
    public partial class UpdateUsersandAddDetails3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UserModelEntityId",
                table: "UserDetails");

            migrationBuilder.RenameColumn(
                name: "UserModelEntityId",
                table: "UserDetails",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserModelEntityId",
                table: "UserDetails",
                newName: "IX_UserDetails_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UsersId",
                table: "UserDetails",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UsersId",
                table: "UserDetails");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserDetails",
                newName: "UserModelEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UsersId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserModelEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UserModelEntityId",
                table: "UserDetails",
                column: "UserModelEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
