using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIFullCRUDWithFile.DataService.Migrations
{
    public partial class UpdateUsersandAddDetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetailsEntity_Users_UserModelEntityId",
                table: "UserDetailsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetailsEntity",
                table: "UserDetailsEntity");

            migrationBuilder.RenameTable(
                name: "UserDetailsEntity",
                newName: "UserDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetailsEntity_UserModelEntityId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserModelEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UserModelEntityId",
                table: "UserDetails",
                column: "UserModelEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UserModelEntityId",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UserDetailsEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserModelEntityId",
                table: "UserDetailsEntity",
                newName: "IX_UserDetailsEntity_UserModelEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetailsEntity",
                table: "UserDetailsEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetailsEntity_Users_UserModelEntityId",
                table: "UserDetailsEntity",
                column: "UserModelEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
