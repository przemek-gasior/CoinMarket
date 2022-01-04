﻿// <auto-generated />
using System;
using CryptoMarket.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CryptoMarket.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20220104132328_initialDbMigrationV2")]
    partial class initialDbMigrationV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CryptoMarket.Models.CryptoWallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("WalletId");

                    b.ToTable("CryptoWallet");
                });

            modelBuilder.Entity("CryptoMarket.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("MarketCapUSD")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PercentChange1h")
                        .HasColumnType("real");

                    b.Property<float>("PercentChange24h")
                        .HasColumnType("real");

                    b.Property<float>("PercentChange7d")
                        .HasColumnType("real");

                    b.Property<float>("PriceInUsd")
                        .HasColumnType("real");

                    b.Property<float?>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CryptoMarket.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UsdBalance")
                        .HasColumnType("real");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CryptoMarket.Models.WalletCurrency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("CurrencyId", "WalletId");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletCurrency");
                });

            modelBuilder.Entity("CryptoMarket.Models.User", b =>
                {
                    b.HasOne("CryptoMarket.Models.CryptoWallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("CryptoMarket.Models.WalletCurrency", b =>
                {
                    b.HasOne("CryptoMarket.Models.Currency", "Currency")
                        .WithMany("Wallets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoMarket.Models.CryptoWallet", "Wallet")
                        .WithMany("Currencies")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("CryptoMarket.Models.CryptoWallet", b =>
                {
                    b.Navigation("Currencies");
                });

            modelBuilder.Entity("CryptoMarket.Models.Currency", b =>
                {
                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
