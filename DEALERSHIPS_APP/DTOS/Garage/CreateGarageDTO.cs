using System.ComponentModel.DataAnnotations;

namespace DEALERSHIPS_APP.DTOS.Garage
{
    public class CreateGarageDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length is 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(10, ErrorMessage = "Max Length is 10 characters")]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Max Length is 50 characters")]
        public string Address { get; set; } = null!;


    }
}
