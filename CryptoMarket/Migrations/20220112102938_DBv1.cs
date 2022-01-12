using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMarket.Migrations
{
    public partial class DBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInUsd = table.Column<float>(type: "real", nullable: false),
                    PercentChange1h = table.Column<float>(type: "real", nullable: false),
                    PercentChange24h = table.Column<float>(type: "real", nullable: false),
                    PercentChange7d = table.Column<float>(type: "real", nullable: false),
                    MarketCapUSD = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCurrencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCurrencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "CryptoWalletUserCurrency",
                columns: table => new
                {
                    CryptoWalletsWalletId = table.Column<int>(type: "int", nullable: false),
                    CurrenciesCurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoWalletUserCurrency", x => new { x.CryptoWalletsWalletId, x.CurrenciesCurrencyId });
                    table.ForeignKey(
                        name: "FK_CryptoWalletUserCurrency_UserCurrencies_CurrenciesCurrencyId",
                        column: x => x.CurrenciesCurrencyId,
                        principalTable: "UserCurrencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CryptoWalletUserCurrency_Wallets_CryptoWalletsWalletId",
                        column: x => x.CryptoWalletsWalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsdBalance = table.Column<float>(type: "real", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptoWalletUserCurrency_CurrenciesCurrencyId",
                table: "CryptoWalletUserCurrency",
                column: "CurrenciesCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WalletId",
                table: "Users",
                column: "WalletId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoWalletUserCurrency");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserCurrencies");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
