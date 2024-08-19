using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadJokes.Migrations
{
    /// <inheritdoc />
    public partial class AddedEyeRollJoiningModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EyeRolls",
                columns: table => new
                {
                    EyeRollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DadJokeUserId = table.Column<int>(type: "int", nullable: false),
                    DadJokeUserId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DadJokeId = table.Column<int>(type: "int", nullable: false),
                    DadJokeId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeRolls", x => x.EyeRollId);
                    table.ForeignKey(
                        name: "FK_EyeRolls_AspNetUsers_DadJokeUserId1",
                        column: x => x.DadJokeUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EyeRolls_DadJokes_DadJokeId1",
                        column: x => x.DadJokeId1,
                        principalTable: "DadJokes",
                        principalColumn: "DadJokeId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EyeRolls_DadJokeId1",
                table: "EyeRolls",
                column: "DadJokeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EyeRolls_DadJokeUserId1",
                table: "EyeRolls",
                column: "DadJokeUserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EyeRolls");
        }
    }
}
