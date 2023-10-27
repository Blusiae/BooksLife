using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLife.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeleteBehaviorForBookTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
