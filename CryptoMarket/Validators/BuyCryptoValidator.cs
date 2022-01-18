using CryptoMarket.Models;
using FluentValidation;

namespace CryptoMarket.Validators
{
    public class BuyCryptoValidator : AbstractValidator<BuyCrypto>
    {
        public BuyCryptoValidator()
        {
            RuleFor(x => x.CryptoName).NotEmpty().WithMessage("CryptoCurrency Name must not be empty");
            RuleFor(x => x.CryptoQuantity).GreaterThan(0).NotEmpty().WithMessage("Enter the amount of currency you want to buy");

        }
    }
}
