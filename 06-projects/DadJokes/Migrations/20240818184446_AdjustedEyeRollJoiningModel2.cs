using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadJokes.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedEyeRollJoiningModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId",
                table: "EyeRolls");

            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_DadJokes_DadJokeId1",
                table: "EyeRolls");

            migrationBuilder.DropIndex(
                name: "IX_EyeRolls_DadJokeUserId",
                table: "EyeRolls");

            migrationBuilder.RenameColumn(
                name: "DadJokeId1",
                table: "EyeRolls",
                newName: "DadJokeUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_EyeRolls_DadJokeId1",
                table: "EyeRolls",
                newName: "IX_EyeRolls_DadJokeUserId1");

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

            migrationBuilder.AlterColumn<string>(
                name: "DadJokeId",
                table: "EyeRolls",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EyeRolls_DadJokeId",
                table: "EyeRolls",
                column: "DadJokeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId1",
                table: "EyeRolls",
                column: "DadJokeUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EyeRolls_DadJokes_DadJokeId",
                table: "EyeRolls",
                column: "DadJokeId",
                principalTable: "DadJokes",
                principalColumn: "DadJokeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_AspNetUsers_DadJokeUserId1",
                table: "EyeRolls");

            migrationBuilder.DropForeignKey(
                name: "FK_EyeRolls_DadJokes_DadJokeId",
                table: "EyeRolls");

            migrationBuilder.DropIndex(
                name: "IX_EyeRolls_DadJokeId",
                table: "EyeRolls");

            migrationBuilder.RenameColumn(
                name: "DadJokeUserId1",
                table: "EyeRolls",
                newName: "DadJokeId1");

            migrationBuilder.RenameIndex(
                name: "IX_EyeRolls_DadJokeUserId1",
                table: "EyeRolls",
                newName: "IX_EyeRolls_DadJokeId1");

            migrationBuilder.AlterColumn<string>(
                name: "DadJokeUserId",
                table: "EyeRolls",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DadJokeId",
                table: "EyeRolls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EyeRolls_DadJokes_DadJokeId1",
                table: "EyeRolls",
                column: "DadJokeId1",
                principalTable: "DadJokes",
                principalColumn: "DadJokeId");
        }
    }
}
