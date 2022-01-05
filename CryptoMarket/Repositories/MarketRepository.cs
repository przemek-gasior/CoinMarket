using CryptoMarket.Configs;
using CryptoMarket.Models;
using CryptoMarket.Services;
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

                _userDbContext.SaveChanges();
            }

            
            
        }
    }
}
