using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IGarageService
    {
        Task Create(Garage garage);
        Task<List<Appointment>> GetAllAppoinmentsByOwnerId(int garageId, int ownerId);
        Task<List<Appointment>> GetAllAppointmentsByGarageId(int garageId);
        Task<Appointment> GetAppointmentById(int garageId, int appointmentId);
        Task<Garage> GetById(int id);
        Task<Garage> GetByPhone(string phone);
    }


    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public GarageService(IGarageRepository repository, IAppointmentRepository appointmentRepository)
        {
            this._garageRepository = repository;
            _appointmentRepository = appointmentRepository;
        }



        public async Task Create(Garage garage)
        {
            var garageCheck = await _garageRepository.GetByPhone(garage.Phone);

            if (garageCheck != null)
            {
                throw new EntityAlreadyExistsException($"Garage with phone = '{garage.Phone}' already exists");
            }

            garage.Created = DateTime.Now;
            await _garageRepository.Create(garage);
        }


        public async Task<Garage> GetById(int id)
        {
            var garage = await _garageRepository.GetById(id);

            if (garage == null)
            {
                throw new EntityNotFoundException($"Garage with id = '{id}' not found");
            }

            return garage;
        }

        public async Task<Garage> GetByPhone(string phone)
        {
            var garage = await _garageRepository.GetByPhone(phone);

            if (garage == null)
            {
                throw new EntityNotFoundException($"Garage with phone = '{phone}' not found");
            }

            return garage;
        }

        public async Task<List<Appointment>> GetAllAppointmentsByGarageId(int garageId)
        {
            var listOfAppointments = await _appointmentRepository.GetAllByGarageId(garageId);

            if (listOfAppointments == null)
            {
                throw new EntityNotFoundException($"Garage with id = '{garageId}' has no appointments");
            }

            return listOfAppointments;
        }


        public async Task<List<Appointment>> GetAllAppoinmentsByOwnerId(int garageId, int ownerId)
        {
            var listOfAppointments = await _appointmentRepository.GetAllByGarageIdForOwnerId(garageId, ownerId);

            if (listOfAppointments == null)
            {
                throw new EntityNotFoundException($"Garage with id = '{garageId}' has no appointments for owner with id = '{ownerId}'");
            }

            return listOfAppointments;
        }




        public async Task<Appointment> GetAppointmentById(int garageId, int appointmentId)
        {
            var appointment = await _appointmentRepository.GetById(appointmentId);

            if (appointment == null || appointment.GarageId != garageId)
            {
                throw new EntityNotFoundException($"Appointment with id = '{appointmentId}' not found");
            }

            return appointment;
        }



    }
}
