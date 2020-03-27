using Microsoft.EntityFrameworkCore.Migrations;

namespace framework_authentication.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UsersByEmailid",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_UsersByEmailid",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "UsersByEmailid",
                table: "Token");

            migrationBuilder.AddColumn<string>(
                name: "hashedPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersByPasswordid",
                table: "Token",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Token_UsersByPasswordid",
                table: "Token",
                column: "UsersByPasswordid");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UsersByPasswordid",
                table: "Token",
                column: "UsersByPasswordid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UsersByPasswordid",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_UsersByPasswordid",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "hashedPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersByPasswordid",
                table: "Token");

            migrationBuilder.AddColumn<int>(
                name: "UsersByEmailid",
                table: "Token",
                type: "int",
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
    }
}
