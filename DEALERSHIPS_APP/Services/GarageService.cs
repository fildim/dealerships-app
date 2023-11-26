using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DEALERSHIPS_APP.Services
{
    public interface IGarageService
    {
        Task Create(Garage garage, string password);
        Task<List<Appointment>> GetAllAppoinmentsByOwnerId(int garageId, int ownerId);
        Task<List<Appointment>> GetAppointments(int garageId);
        Task<Appointment> GetAppointmentByAppointmentId(int garageId, int appointmentId);
        Task<Garage> GetById(int id);
        Task<List<Garage>> GetAll();
        Task<string> Login(string phone, string password);
        Task UpdateAppointment(Appointment appointment);
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
                    Created = now,
                    UserType = "garage"
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

        public async Task<List<Garage>> GetAll()
        {
            var listOfGarages = await _garageRepository.GetAll();

            if (listOfGarages == null)
            {
                throw new EntityNotFoundException("No garages found");
            }

            return listOfGarages;
        }

        public async Task<string> Login(string phone, string password)
        {
            var loginCheck = await _loginCredentialRepository.GetByPhone(phone);

            if (loginCheck == null)
            {
                throw new AuthenticationException($"Login credentials for phone = '{phone}' not found");
            }

            if (loginCheck.UserType != "garage")
            {
                throw new AuthenticationException($"Login credentials for phone = '{phone}' not verified");
            }

            var encryptedPassword = BCrypt.Net.BCrypt.Verify(password, loginCheck.Password);

            if (encryptedPassword == false)
            {
                throw new AuthenticationException($"Login credentials for phone = '{phone}' not verified");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var garage = await _garageRepository.GetByPhone(phone);

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5161",
                audience: "https://localhost:5161",
                claims: new List<Claim>
                {
                    new Claim("userId", garage!.Id.ToString()),
                    new Claim("garageName", garage.Name),
					new Claim("userType", "garage")
				},
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            return JsonConvert.SerializeObject(new JwtSecurityTokenHandler().WriteToken(tokenOptions));
        }


        public async Task UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.GetById(appointment.Id);

            if (existingAppointment == null)
            {
                throw new EntityNotFoundException($"Appointment with id = '{appointment.Id}' not found");
            }

            existingAppointment.DateOfPickup = appointment.DateOfPickup;
            existingAppointment.Diagnosis = appointment.Diagnosis;
            existingAppointment.Mileage = appointment.Mileage;
            existingAppointment.Vehicle.Crashed = appointment.Vehicle.Crashed;
            existingAppointment.Updated = DateTime.Now;

            await _appointmentRepository.Update(existingAppointment);
        }



    }
}
