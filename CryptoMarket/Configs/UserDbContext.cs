using CryptoMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Configs
{
    public class UserDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=CoinMarketDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WalletCurrency>()
                .HasKey(wc => new { wc.CurrencyId, wc.WalletId });
            modelBuilder.Entity<WalletCurrency>()
                .HasOne(wc => wc.Currency)
                .WithMany(wc => wc.Wallets)
                .HasForeignKey(wc => wc.CurrencyId);
            modelBuilder.Entity<WalletCurrency>()
                .HasOne(wc => wc.Wallet)
                .WithMany(wc => wc.Currencies)
                .HasForeignKey(wc => wc.WalletId);
            modelBuilder.Entity<CryptoWallet>()
                .HasKey(cw => cw.WalletId);

        }
    }
}
