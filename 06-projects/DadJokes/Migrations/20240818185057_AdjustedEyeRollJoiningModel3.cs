using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadJokes.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedEyeRollJoiningModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId1",
                table: "EyeRolls");

            migrationBuilder.DropIndex(
                name: "IX_EyeRolls_DadJokeUserId1",
                table: "EyeRolls");

            migrationBuilder.DropColumn(
                name: "DadJokeUserId1",
                table: "EyeRolls");

            migrationBuilder.AlterColumn<string>(
                name: "DadJokeUserId",
                table: "EyeRolls",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EyeRolls_DadJokeUserId",
                table: "EyeRolls",
                column: "DadJokeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId",
                table: "EyeRolls",
                column: "DadJokeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId",
                table: "EyeRolls");

            migrationBuilder.DropIndex(
                name: "IX_EyeRolls_DadJokeUserId",
                table: "EyeRolls");

            migrationBuilder.AlterColumn<int>(
                name: "DadJokeUserId",
                table: "EyeRolls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DadJokeUserId1",
                table: "EyeRolls",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EyeRolls_DadJokeUserId1",
                table: "EyeRolls",
                column: "DadJokeUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId1",
                table: "EyeRolls",
                column: "DadJokeUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
