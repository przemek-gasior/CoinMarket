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
        public virtual DbSet<UserCurrency> UserCurrencies { get; set; }
        public virtual DbSet<CryptoWallet> Wallets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=CoinsDB;Trusted_Connection=True;");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CryptoWallet>()
                .HasKey(cw => cw.WalletId);
            modelBuilder.Entity<UserCurrency>()
                .HasKey(x => x.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<User>()
                .HasOne(w => w.Wallet)
                .WithOne();
        }
    }
}
