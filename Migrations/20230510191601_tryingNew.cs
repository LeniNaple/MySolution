using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalSol.Migrations
{
    /// <inheritdoc />
    public partial class tryingNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersInformations_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInformations",
                table: "UsersInformations");

            migrationBuilder.RenameTable(
                name: "UsersInformations",
                newName: "UserEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserEntity_AdressId",
                table: "AspNetUsers",
                column: "AdressId",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserEntity_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "UsersInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInformations",
                table: "UsersInformations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersInformations_AdressId",
                table: "AspNetUsers",
                column: "AdressId",
                principalTable: "UsersInformations",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
