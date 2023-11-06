using System.ComponentModel.DataAnnotations;

namespace DEALERSHIPS_APP.DTOS.Garage
{
    public class CreateGarageDTO
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;


    }
}
