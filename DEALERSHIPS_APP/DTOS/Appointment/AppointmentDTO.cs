using DEALERSHIPS_APP.DTOS.Garage;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.DTOS.Vehicle;

namespace DEALERSHIPS_APP.DTOS.Appointment
{
	public class AppointmentDTO
	{
		public int Id { get; set; }
		public OwnerDTO Owner { get; set; } = null!;
		public VehicleDTO Vehicle { get; set; } = null!;
		public GarageDTO Garage { get; set; } = null!;
		public DateTime DateOfArrival { get; set; }
		public int Mileage { get; set; }
		public string? Diagnosis { get; set; }
		public DateTime? DateOfPickup { get; set; }
		public DateTime Created { get; set; }
	}
}
