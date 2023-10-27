using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLife.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedReturnDeadlineToBorrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Borrows",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDeadline",
                table: "Borrows",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "dateadd(m, 1, getutcdate())");

            migrationBuilder.Sql(@"
                UPDATE Borrows
                SET ReturnDeadline = ReturnDate
            ");

            migrationBuilder.Sql(@"
                UPDATE Borrows
                SET ReturnDate = NULL;
            ");
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDeadline",
                table: "Borrows");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Borrows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
