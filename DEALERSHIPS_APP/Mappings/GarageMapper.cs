using AutoMapper;
using DEALERSHIPS_APP.DTOS.Garage;

namespace DEALERSHIPS_APP.Mappings
{
    public class GarageMapper : Profile
    {
        public GarageMapper()
        {
            CreateMap<CreateGarageDTO, Models.Garage>();
        }
    }
}
