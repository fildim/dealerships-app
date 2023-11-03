using DEALERSHIPS_APP.DTOS.Owner;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DEALERSHIPS_APP.Validators.Owner
{
    public class CreateOwnerValidator : AbstractValidator<CreateOwnerDTO>
    {
        public CreateOwnerValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Phone).Must(x => new Regex("^\\d{10}$").IsMatch(x)).WithMessage("'{PropertyName}' must be 10 numbers");

        }
    }
}
