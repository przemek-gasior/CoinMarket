using CryptoMarket.Configs;
using CryptoMarket.Helpers;
using CryptoMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Repositories
{
    public class MarketRepository : IMarketRepository
    {
        private readonly UserDbContext _userDbContext;

        public MarketRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<ICollection<Currency>> FetchMarketData()
        {
            return await _userDbContext.Currencies.ToListAsync();
        }

        public async Task<Currency> GetCryptoByNameAsync(string name)
        {
           return await _userDbContext.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task SaveMarketData(MarketDTO marketData)
        {
            foreach (var item in marketData.CurrenciesMarket)
            {
                if( _userDbContext.Currencies.AsNoTracking().FirstOrDefault(x => x.Name == item.Name) == null)
                {
                   await _userDbContext.AddAsync(item);
                }
                else
                {
                    try
                    {
                        _userDbContext.Update(item);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                    }
                }
            }
            _userDbContext.SaveChanges();

        }

        public async Task UpdateUserWalletPurchase(User user, BuyCrypto transaction)
        {
           var wallet = await _userDbContext.Wallets.Include(x => x.Currencies).FirstOrDefaultAsync(x => x.WalletId == user.WalletId);
           var currencyToBuy = await _userDbContext.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == transaction.CryptoName);
           var processedCurrency= wallet.Currencies.ToList().FirstOrDefault(x => x.Name.ToLower() == transaction.CryptoName.ToLower());
            

            if ( processedCurrency == null)
                wallet.Currencies.Add(new UserCurrency
                {                
                    Name = currencyToBuy.Name,
                    Quantity = transaction.CryptoQuantity
                });
            else
            {
                processedCurrency.Quantity += transaction.CryptoQuantity;
                user.UsdBalance -= transaction.TransactionCost;
            }

         _userDbContext.SaveChanges();
        }

        public async Task UpdateUserWalletSell(User user, SellCrypto transaction)
        {
            var wallet = await _userDbContext.Wallets.Include(x => x.Currencies).FirstOrDefaultAsync(x => x.WalletId == user.WalletId);
            var currencyToSell = await _userDbContext.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Name == transaction.CryptoName);
            var processedCurrency = wallet.Currencies.ToList().FirstOrDefault(x => x.Name.ToLower() == transaction.CryptoName.ToLower());

            if (processedCurrency == null || processedCurrency.Quantity < transaction.CryptoQuantity)
            {
                throw new AppException("non sufficient amount of " + transaction.CryptoName);
            }
            else
            {
                processedCurrency.Quantity -= transaction.CryptoQuantity;
                user.UsdBalance += transaction.ValueOfTransaction;
            }

            _userDbContext.SaveChanges();

        }
    }
}
