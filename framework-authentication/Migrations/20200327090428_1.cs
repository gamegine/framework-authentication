using Microsoft.EntityFrameworkCore.Migrations;

namespace framework_authentication.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_Usersid",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_Usersid",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "Token");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersByEmailid",
                table: "Token",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Token_UsersByEmailid",
                table: "Token",
                column: "UsersByEmailid");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UsersByEmailid",
                table: "Token",
                column: "UsersByEmailid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UsersByEmailid",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_UsersByEmailid",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersByEmailid",
                table: "Token");

            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "Token",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Token_Usersid",
                table: "Token",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_Usersid",
                table: "Token",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
