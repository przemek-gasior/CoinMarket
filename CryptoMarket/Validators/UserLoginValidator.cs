using CryptoMarket.Models;
using FluentValidation;

namespace CryptoMarket.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Name).MinimumLength(6).MaximumLength(30).Matches("[a - zA - Z0 - 9]").WithMessage("Username must be 6 to 30 characters a-z, A-Z and/or 0-9");
            RuleFor(x => x.Password).MinimumLength(6).MaximumLength(30).Matches("[a - zA - Z0 - 9]").WithMessage("Password must be 6 to 30 characters  a-z, A-Z and/or 0-9");
        }
    }
}
