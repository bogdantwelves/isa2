using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Soft.Web.Migrations
{
    /// <inheritdoc />
    public partial class v190326Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movie",
                newName: "ValidTo");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Movie",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Movie",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Movie",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "Movie",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movie",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Movie",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
