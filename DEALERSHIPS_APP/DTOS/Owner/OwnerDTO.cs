namespace DEALERSHIPS_APP.DTOS.Owner
{
	public class OwnerDTO
	{
		public int Id { get; set; }
		public string Firstname { get; set; } = null!;
		public string Lastname { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public DateTime Created { get; set; }
	}
}
