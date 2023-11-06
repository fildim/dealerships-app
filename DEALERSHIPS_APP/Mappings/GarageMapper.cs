using AutoMapper;
using DEALERSHIPS_APP.DTOS.Garage;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
    public class GarageMapper : Profile
    {
        public GarageMapper()
        {
            CreateMap<CreateGarageDTO, Models.Garage>();
            CreateMap<Garage, ReadOnlyGarageDTO>();
        }
    }
}
