using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMarket.Migrations
{
    public partial class DBv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserCurrencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "UserCurrencies",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
