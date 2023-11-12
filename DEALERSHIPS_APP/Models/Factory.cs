
namespace DEALERSHIPS_APP.Models;

public partial class Factory
{
    public int Id { get; set; }

    public string Location { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<OwnershipHistory> OwnershipHistories { get; set; } = new List<OwnershipHistory>();
}
