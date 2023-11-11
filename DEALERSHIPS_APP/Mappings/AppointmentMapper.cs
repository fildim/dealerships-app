using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<CreateAppointmentDTO, Appointment>();
            CreateMap<Appointment, ReadOnlyAppointmentDTO>();
             //   .ConstructUsing((x,y) => {
             //   var owner = y.Mapper.Map<ReadOnlyOwnerDTO>(x.Owner);
             //   return new ReadOnlyAppointmentDTO
             //   {
             //       Id = x.Id,
             //       Owner = owner,

             //   };
             //});
        }

    }
}
