using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<CreateAppointmentDTO, Appointment>();
        }

    }
}
