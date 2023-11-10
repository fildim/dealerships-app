namespace DEALERSHIPS_APP.DTOS.Garage
{
	public class GarageDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string Address { get; set; } = null!;
		public DateTime Created { get; set; }
	}
}
