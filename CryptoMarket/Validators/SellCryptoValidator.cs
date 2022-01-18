using CryptoMarket.Models;
using FluentValidation;

namespace CryptoMarket.Validators
{
    public class SellCryptoValidator : AbstractValidator<SellCrypto>
    {
        public SellCryptoValidator()
        {
            RuleFor(x => x.CryptoName).NotEmpty().WithMessage("CryptoCurrency Name must not be empty");
            RuleFor(x => x.CryptoQuantity).GreaterThan(0).NotEmpty().WithMessage("Enter the amount of currency you want to sell");
        }
    }
}
