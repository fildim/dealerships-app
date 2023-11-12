using DEALERSHIPS_APP.DTOS.Owner;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DEALERSHIPS_APP.Validators.Owner
{
    public class CreateOwnerValidator : AbstractValidator<CreateOwnerDTO>
    {
        public CreateOwnerValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
            RuleFor(x => x.Phone).Must(x => new Regex("^\\d{10}$").IsMatch(x)).WithMessage("'{PropertyName}' must be 10 numbers");
            RuleFor(x => x.Password).Must(x => new Regex("^\\d{8}$").IsMatch(x));

        }
    }
}
