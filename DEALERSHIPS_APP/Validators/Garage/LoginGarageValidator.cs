using DEALERSHIPS_APP.DTOS.Garage;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DEALERSHIPS_APP.Validators.Garage
{
    public class LoginGarageValidator : AbstractValidator<LoginGarageDTO>
    {
        public LoginGarageValidator()
        {
            RuleFor(x => x.Phone).Must(x => new Regex("^\\d{10}$").IsMatch(x)).WithMessage("'{PropertyName}' must be 10 numbers");
            RuleFor(x => x.Password).Must(x => new Regex("^\\d{8}$").IsMatch(x));

        }
    }
}
