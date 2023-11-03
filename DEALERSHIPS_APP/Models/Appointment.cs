using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public int VehicleId { get; set; }

    public int GarageId { get; set; }

    public DateTime DateOfArrival { get; set; }

    public int Mileage { get; set; }

    public string? Diagnosis { get; set; }

    public DateTime? DateOfPickup { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Garage Garage { get; set; } = null!;

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual Owner Owner { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
