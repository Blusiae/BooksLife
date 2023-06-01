using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLife.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBookEntityForeginKeyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTitles_TitleId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "Books",
                newName: "BookTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_TitleId",
                table: "Books",
                newName: "IX_Books_BookTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTitles_BookTitleId",
                table: "Books",
                column: "BookTitleId",
                principalTable: "BookTitles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTitles_BookTitleId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookTitleId",
                table: "Books",
                newName: "TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookTitleId",
                table: "Books",
                newName: "IX_Books_TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTitles_TitleId",
                table: "Books",
                column: "TitleId",
                principalTable: "BookTitles",
                principalColumn: "Id");
        }
    }
}
