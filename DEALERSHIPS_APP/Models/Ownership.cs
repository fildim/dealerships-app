
namespace DEALERSHIPS_APP.Models;

public partial class Ownership
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int? OwnerId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
