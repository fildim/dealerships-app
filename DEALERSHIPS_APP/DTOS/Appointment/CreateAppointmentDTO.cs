namespace DEALERSHIPS_APP.DTOS.Appointment
{
	public class CreateAppointmentDTO
	{
		public int OwnerId { get; set; }
		public int VehicleId { get; set; }
		public int GarageId { get; set; }
		public DateTime DateOfArrival { get; set; }
	}
}
