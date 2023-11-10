using DEALERSHIPS_APP.DTOS.Appointment;
using FluentValidation;

namespace DEALERSHIPS_APP.Validators.Appointment
{
	public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentDTO>
	{
		public CreateAppointmentValidator()
		{
			RuleFor(x => x.OwnerId).NotEmpty();
			RuleFor(x => x.VehicleId).NotEmpty();
			RuleFor(x => x.GarageId).NotEmpty();
			RuleFor(x => x.DateOfArrival).NotEmpty().GreaterThan(DateTime.Now);
		}
	}
}
