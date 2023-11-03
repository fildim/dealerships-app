using System.ComponentModel.DataAnnotations;

namespace DEALERSHIPS_APP.DTOS.Appointment
{
    public class CreateAppointmentDTO
    {
        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int GarageId { get; set; }

        [Required]
        public DateTime DateOfArrival { get; set; }


    }
}
