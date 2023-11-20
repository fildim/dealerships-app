using DEALERSHIPS_APP.DTOS.Owner;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DEALERSHIPS_APP.Validators.Owner
{
    public class LoginOwnerValidator : AbstractValidator<LoginOwnerDTO>
    {
        public LoginOwnerValidator()
        {
            RuleFor(x => x.Phone).Must(x => new Regex("^\\d{10}$").IsMatch(x)).WithMessage("'{PropertyName}' must be 10 numbers");
            RuleFor(x => x.Password).Must(x => new Regex("^\\d{8}$").IsMatch(x));

        }
    }
}
