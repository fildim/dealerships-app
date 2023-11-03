using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IAppointmentService
    {
        Task Create(Appointment appointment);
    }


    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository repository)
        {
            this._appointmentRepository = repository;
        }




        public async Task Create(Appointment appointment)
        {

            appointment.Created = DateTime.Now;
            await _appointmentRepository.Create(appointment);
        }
    }
}
