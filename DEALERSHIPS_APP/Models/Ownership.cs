using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Ownership
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int OwnerId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Owner Owner { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
