using DEALERSHIPS_APP.DTOS.Garage;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.DTOS.Vehicle;

namespace DEALERSHIPS_APP.DTOS.Appointment
{
    public class ReadOnlyAppointmentDTO
    {
        public int Id { get; set; }

        public ReadOnlyOwnerDTO Owner { get; set; }

        public ReadOnlyVehicleDTO Vehicle { get; set; }

        public ReadOnlyGarageDTO Garage { get; set; }

        public DateTime DateOfArrival { get; set; }

        public int Mileage { get; set; }

        public string? Diagnosis { get; set; }

        public DateTime? DateOfPickup { get; set; }

        public DateTime Created { get; set; }
    }
}
