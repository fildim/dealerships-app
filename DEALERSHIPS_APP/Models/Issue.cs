using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Issue
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
