using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Owner
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<OwnershipHistory> OwnershipHistoryCurrentOwners { get; set; } = new List<OwnershipHistory>();

    public virtual ICollection<OwnershipHistory> OwnershipHistoryPreviousOwners { get; set; } = new List<OwnershipHistory>();

    public virtual ICollection<Ownership> Ownerships { get; set; } = new List<Ownership>();
}
