using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMarket.Migrations
{
    public partial class DBv20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Wallets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
