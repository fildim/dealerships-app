using AutoMapper;
using DEALERSHIPS_APP.DTOS.Vehicle;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<Vehicle, ReadOnlyVehicleDTO>().ReverseMap();
        }
    }
}
