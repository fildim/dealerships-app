using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
    public interface IGarageService
    {
        Task Create(Garage garage, string password);
        Task<List<Appointment>> GetAllAppoinmentsByOwnerId(int garageId, int ownerId);
        Task<List<Appointment>> GetAppointments(int garageId);
        Task<Appointment> GetAppointmentByAppointmentId(int garageId, int appointmentId);
        Task<Garage> GetById(int id);
        
    }


    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ILoginCredentialRepository _loginCredentialRepository;
        private readonly IDBTransactionService _dBTransactionService;

        public GarageService(IGarageRepository repository, IAppointmentRepository appointmentRepository, IDBTransactionService dBTransactionService, ILoginCredentialRepository loginCredentialRepository)
        {
            this._garageRepository = repository;
            _appointmentRepository = appointmentRepository;
            _dBTransactionService = dBTransactionService;
            _loginCredentialRepository = loginCredentialRepository;
        }



        public async Task Create(Garage garage, string password)
        {
            var garageCheck = await _garageRepository.GetByPhone(garage.Phone);

            if (garageCheck != null)
            {
                throw new EntityAlreadyExistsException($"Garage with phone = '{garage.Phone}' already exists");
            }

            await _dBTransactionService.Begin();

            try
            {
                var now = DateTime.Now;

                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

                garage.Created = now;
                await _garageRepository.Create(garage);

                var loginCredentials = new Logincredential
                {
                    Phone = garage.Phone,
                    Password = encryptedPassword,
                    Created = now
                };

                await _loginCredentialRepository.Create(loginCredentials);

                await _dBTransactionService.Commit();
            }
            catch (Exception )
            {
                await _dBTransactionService.Rollback();
                throw;
            }
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


        public async Task<List<Appointment>> GetAppointments(int garageId)
        {
            var listOfAppointments = await _appointmentRepository.GetAllByGarageId(garageId);

            return listOfAppointments;
        }


        public async Task<List<Appointment>> GetAllAppoinmentsByOwnerId(int garageId, int ownerId)
        {
            var listOfAppointments = await _appointmentRepository.GetAllByGarageIdForOwnerId(garageId, ownerId);

            return listOfAppointments;
        }




        public async Task<Appointment> GetAppointmentByAppointmentId(int garageId, int appointmentId)
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
