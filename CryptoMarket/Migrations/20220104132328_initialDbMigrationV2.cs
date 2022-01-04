using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMarket.Migrations
{
    public partial class initialDbMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoWallet",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoWallet", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInUsd = table.Column<float>(type: "real", nullable: false),
                    PercentChange1h = table.Column<float>(type: "real", nullable: false),
                    PercentChange24h = table.Column<float>(type: "real", nullable: false),
                    PercentChange7d = table.Column<float>(type: "real", nullable: false),
                    MarketCapUSD = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsdBalance = table.Column<float>(type: "real", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CryptoWallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "CryptoWallet",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WalletCurrency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletCurrency", x => new { x.CurrencyId, x.WalletId });
                    table.ForeignKey(
                        name: "FK_WalletCurrency_CryptoWallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "CryptoWallet",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletCurrency_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_WalletId",
                table: "Users",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletCurrency_WalletId",
                table: "WalletCurrency",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WalletCurrency");

            migrationBuilder.DropTable(
                name: "CryptoWallet");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
