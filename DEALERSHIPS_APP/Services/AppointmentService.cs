using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IAppointmentService
    {
        Task Create(Appointment appointment);
        Task<Appointment> GetById(int id);
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
            var appointmentCheck = await _appointmentRepository.Get(appointment.VehicleId, appointment.DateOfArrival); 

            if (appointmentCheck != null)
            {
                throw new EntityAlreadyExistsException($"Appointment with vehicle id = '{appointment.VehicleId}' and date of arrival = '{appointment.DateOfArrival}' already exists");
            }

            appointment.Created = DateTime.Now;
            await _appointmentRepository.Create(appointment);
        }

        public async Task<Appointment> GetById(int id)
        {
            var appointment = await _appointmentRepository.GetById(id);

            if (appointment == null)
            {
                throw new EntityNotFoundException($"Appointment with id = '{id}' not found");
            }

            return appointment;
        }


        
    }

}

