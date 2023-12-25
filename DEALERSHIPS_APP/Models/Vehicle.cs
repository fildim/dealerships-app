
namespace DEALERSHIPS_APP.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Vin { get; set; } = null!;

    public string Model { get; set; } = null!;

    public DateTime DateOfManufacture { get; set; }

    public int Mileage { get; set; }

    public bool Crashed { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<OwnershipHistory> OwnershipHistories { get; set; } = new List<OwnershipHistory>();

    public virtual Ownership? Ownership { get; set; }
}
