using AutoMapper;
using CryptoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data, Currency>().IncludeMembers(o => o.Quote);
            CreateMap<Quote, Currency>()
                .ForMember(dest => dest.PriceInUsd, o => o.MapFrom(o => o.Usd.Price))
                .ForMember(dest => dest.PercentChange1h, o => o.MapFrom(o => o.Usd.Percent_Change_1h))
                .ForMember(dest => dest.PercentChange24h, o => o.MapFrom(o => o.Usd.Percent_Change_24h))
                .ForMember(dest => dest.PercentChange7d, o => o.MapFrom(o => o.Usd.Percent_Change_7d))
                .ForMember(dest => dest.MarketCapUSD, o => o.MapFrom(o => o.Usd.Market_Cap));

            CreateMap<User, UserDto>().IncludeMembers(cw => cw.Wallet);
            CreateMap<CryptoWallet, UserDto>()
                .ForMember(x => x.Currencies, x => x.MapFrom(x => x.Currencies));
            CreateMap<UserCurrency, UserCurrencyDto>();


        }
    }
}
