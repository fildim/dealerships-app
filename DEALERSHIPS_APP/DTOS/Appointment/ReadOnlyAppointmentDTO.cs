﻿namespace DEALERSHIPS_APP.DTOS.Appointment
{
    public class ReadOnlyAppointmentDTO
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
    }
}
