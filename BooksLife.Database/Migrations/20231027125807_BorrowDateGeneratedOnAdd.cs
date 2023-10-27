using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLife.Database.Migrations
{
    /// <inheritdoc />
    public partial class BorrowDateGeneratedOnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "Borrows",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "Borrows",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
