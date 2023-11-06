using DEALERSHIPS_APP.DTOS.Garage;
using FluentValidation;

namespace DEALERSHIPS_APP.Validators.Garage
{
    public class CreateGarageValidator : AbstractValidator<CreateGarageDTO>
    {
        public CreateGarageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(10).WithMessage("'{PropertyName}' must be 10 numbers");
            RuleFor(x => x.Address).NotEmpty().MaximumLength(50).WithMessage("'{PropertyName}' must be maximum 50 characters");
        }


    }
}
