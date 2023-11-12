
namespace DEALERSHIPS_APP.Models;

public partial class OwnershipHistory
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int FactoryId { get; set; }

    public int? DealershipId { get; set; }

    public int? PreviousOwnerId { get; set; }

    public int? CurrentOwnerId { get; set; }

    public DateTime DateOfManufacture { get; set; }

    public DateTime? DateOfSale { get; set; }

    public DateTime? DateOfTransfer { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Owner? CurrentOwner { get; set; }

    public virtual Dealership? Dealership { get; set; }

    public virtual Factory Factory { get; set; } = null!;

    public virtual Owner? PreviousOwner { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
