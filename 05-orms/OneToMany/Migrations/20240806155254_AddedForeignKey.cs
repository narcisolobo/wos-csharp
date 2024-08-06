using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToMany.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieBuffId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieBuffId",
                table: "Movies",
                column: "MovieBuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieBuffs_MovieBuffId",
                table: "Movies",
                column: "MovieBuffId",
                principalTable: "MovieBuffs",
                principalColumn: "MovieBuffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieBuffs_MovieBuffId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieBuffId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieBuffId",
                table: "Movies");
        }
    }
}
