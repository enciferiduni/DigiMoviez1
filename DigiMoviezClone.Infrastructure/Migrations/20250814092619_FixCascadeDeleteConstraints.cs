using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiMoviezClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movie_MovieId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movie_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movie_MovieId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movie_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
