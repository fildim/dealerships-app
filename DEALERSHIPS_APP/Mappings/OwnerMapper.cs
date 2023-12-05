using AutoMapper;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
    public class OwnerMapper : Profile
    {
        public OwnerMapper()
        {
            CreateMap<CreateOwnerDTO, Owner>();
            CreateMap<Owner, ReadOnlyOwnerDTO>().ReverseMap();
        }
    }
}
