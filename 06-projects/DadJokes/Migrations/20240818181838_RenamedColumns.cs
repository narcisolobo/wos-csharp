using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadJokes.Migrations
{
    /// <inheritdoc />
    public partial class RenamedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dad_jokes",
                table: "dad_jokes");

            migrationBuilder.RenameTable(
                name: "dad_jokes",
                newName: "DadJokes");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "joke",
                table: "DadJokes",
                newName: "Joke");

            migrationBuilder.RenameColumn(
                name: "dad_joke_id",
                table: "DadJokes",
                newName: "DadJokeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadJokes",
                table: "DadJokes",
                column: "DadJokeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DadJokes",
                table: "DadJokes");

            migrationBuilder.RenameTable(
                name: "DadJokes",
                newName: "dad_jokes");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Joke",
                table: "dad_jokes",
                newName: "joke");

            migrationBuilder.RenameColumn(
                name: "DadJokeId",
                table: "dad_jokes",
                newName: "dad_joke_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dad_jokes",
                table: "dad_jokes",
                column: "dad_joke_id");
        }
    }
}
