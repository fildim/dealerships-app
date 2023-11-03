﻿using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Dealership
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<OwnershipHistory> OwnershipHistories { get; set; } = new List<OwnershipHistory>();
}
