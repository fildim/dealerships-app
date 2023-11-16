using DEALERSHIPS_APP.DTOS.Garage;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DEALERSHIPS_APP.Validators.Garage
{
    public class CreateGarageValidator : AbstractValidator<CreateGarageDTO>
    {
        public CreateGarageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
            RuleFor(x => x.Address).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
            RuleFor(x => x.Phone).Must(x => new Regex("^\\d{10}$").IsMatch(x)).WithMessage("'{PropertyName}' must be 10 numbers");
            RuleFor(x => x.Password).Must(x => new Regex("^\\d{8}$").IsMatch(x));
        }


    }
}
