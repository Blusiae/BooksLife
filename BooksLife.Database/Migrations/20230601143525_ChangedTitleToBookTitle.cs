using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLife.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTitleToBookTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Titles_TitleId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Authors_AuthorId",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Titles",
                table: "Titles");

            migrationBuilder.RenameTable(
                name: "Titles",
                newName: "BookTitles");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_AuthorId",
                table: "BookTitles",
                newName: "IX_BookTitles_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTitles",
                table: "BookTitles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTitles_TitleId",
                table: "Books",
                column: "TitleId",
                principalTable: "BookTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTitles_TitleId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTitles_Authors_AuthorId",
                table: "BookTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTitles",
                table: "BookTitles");

            migrationBuilder.RenameTable(
                name: "BookTitles",
                newName: "Titles");

            migrationBuilder.RenameIndex(
                name: "IX_BookTitles_AuthorId",
                table: "Titles",
                newName: "IX_Titles_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Titles",
                table: "Titles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Titles_TitleId",
                table: "Books",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Authors_AuthorId",
                table: "Titles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
