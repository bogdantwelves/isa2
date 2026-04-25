using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v250426Key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money");

            migrationBuilder.DropIndex(
                name: "IX_CountryCurrencies_CountryId",
                table: "CountryCurrencies");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Money",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Money",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrencies_CountryId",
                table: "CountryCurrencies",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
