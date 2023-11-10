namespace DEALERSHIPS_APP.DTOS.Vehicle
{
	public class VehicleDTO
	{
		public int Id { get; set; }
		public string Vin { get; set; } = null!;
		public string Model { get; set; } = null!;
		public DateTime DateOfManufacture { get; set; }
		public int Mileage { get; set; }
		public bool Crashed { get; set; }
	}
}
