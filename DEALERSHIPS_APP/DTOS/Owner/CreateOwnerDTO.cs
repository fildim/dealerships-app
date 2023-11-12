using System.ComponentModel.DataAnnotations;

namespace DEALERSHIPS_APP.DTOS.Owner
{
    public class CreateOwnerDTO
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;



    }
}
