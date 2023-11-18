using AutoMapper;
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
    public interface IOwnerService
    {
        Task Create(Owner owner, string password);
        Task<List<Appointment>> GetAllAppointmentsById(int ownerId);
        Task<Appointment> GetAppointmentByAppointmentId(int ownerId, int appointmentId);
        Task<List<Vehicle>> GetBindedVehicles(int ownerId);
        Task<Owner> GetById(int id);
        Task InitialBindVehicle(int ownerId, int vehicleId);
        Task<string> Login(string phone, string password);
    }



    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IOwnershipRepository _ownershipRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IOwnershipHistoryRepository _ownershipHistoryRepository;
        private readonly IAppointmentRepository _appointmentRepository;
		private readonly ILoginCredentialRepository _loginCredentialRepository;
		private readonly IMapper _mapper;
        private readonly IDBTransactionService _dbTransactionService;

        public OwnerService(
			IOwnerRepository repository,
			IOwnershipRepository ownershipRepository,
			IVehicleRepository vehicleRepository,
			IOwnershipHistoryRepository ownershipHistoryRepository,
			IMapper mapper,
			IDBTransactionService dbTransactionService,
			IAppointmentRepository appointmentRepository,
            ILoginCredentialRepository loginCredentialRepository)
        {
            this._ownerRepository = repository;
            _ownershipRepository = ownershipRepository;
            _vehicleRepository = vehicleRepository;
            _ownershipHistoryRepository = ownershipHistoryRepository;
            _mapper = mapper;
            _dbTransactionService = dbTransactionService;
            _appointmentRepository = appointmentRepository;
			_loginCredentialRepository = loginCredentialRepository;
		}




        public async Task Create(Owner owner, string password)
        {
            var ownerCheck = await _ownerRepository.GetByPhone(owner.Phone);

            if (ownerCheck != null)
            {
                throw new EntityAlreadyExistsException($"Owner with phone = '{owner.Phone}' already exists");
            }

            await _dbTransactionService.Begin();

            try
            {
                var now = DateTime.Now;

                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

				owner.Created = now;
				await _ownerRepository.Create(owner);

                var loginCredentials = new Logincredential
                {
                    Phone = owner.Phone,
                    Password = encryptedPassword,
                    Created = now
				};

                await _loginCredentialRepository.Create(loginCredentials);

                await _dbTransactionService.Commit();
			}
            catch (Exception)
            {
				await _dbTransactionService.Rollback();
				throw;
			}
        }


        public async Task<Owner> GetById(int id)
        {
            var owner = await _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new EntityNotFoundException($"Owner with id = '{id}' not found");
            }

            return owner;
        }


        public async Task InitialBindVehicle(int ownerId, int vehicleId)
        {
            var owner = await _ownerRepository.GetById(ownerId);

            if (owner == null)
            {
                throw new EntityNotFoundException($"Owner with id = '{ownerId}' not found");
            }

            var ownershipHistories = await _ownershipHistoryRepository.GetAllByVehicleId(vehicleId);

            if (ownershipHistories.Count == 0)
            {
                throw new EntityNotFoundException($"Vehicle with id = '{vehicleId}' history not found");
            }

            var vehicle = await _vehicleRepository.GetById(vehicleId);

            if (vehicle == null)
            {
                throw new EntityNotFoundException($"Vehicle with id = '{vehicleId}' not found");
            }

            var listOfBindedVehicles = await _ownershipRepository.GetAllVehicleIds();

            if (listOfBindedVehicles.Contains(vehicleId))
            {
                throw new EntityAlreadyExistsException($"Vehicle with id = '{vehicleId}' is already binded");
            }


            await _dbTransactionService.Begin();

            try
            {
                var timeNowIs = DateTime.Now;

                var ownership = new Ownership { OwnerId = ownerId, VehicleId = vehicleId, Created = timeNowIs };

                await _ownershipRepository.Create(ownership);

                var lastOwnershipHistory = ownershipHistories.OrderByDescending(x => x.Id).First();

                var newOwnershipHistory = _mapper.Map<OwnershipHistory>(lastOwnershipHistory);

                newOwnershipHistory.Id = 0;
                newOwnershipHistory.CurrentOwnerId = ownerId;
                newOwnershipHistory.DateOfSale = timeNowIs;
                newOwnershipHistory.Created = timeNowIs;

                await _ownershipHistoryRepository.Create(newOwnershipHistory);;

                await _dbTransactionService.Commit();
            }
            catch
            {
                await _dbTransactionService.Rollback();
                throw;
            }
        }



       


        public async Task<List<Vehicle>> GetBindedVehicles(int ownerId)
        {
            var listOfVehicles = await _ownershipRepository.GetVehiclesByOwnerId(ownerId);

            if (listOfVehicles.Count == 0)
            {
                throw new EntityNotFoundException($"Owner with id = '{ownerId}' has no binded vehicles");
            }

            return listOfVehicles;
        }


        public async Task<Vehicle?> GetVehicleById(int vehicleId)
        {
            return await _vehicleRepository.GetById(vehicleId);
        }


        public async Task<List<Appointment>> GetAllAppointmentsById(int ownerId)
        {
            var listOfAppointments = await _appointmentRepository.GetAllByOwnerId(ownerId);

            return listOfAppointments;
        }

        public async Task<Appointment> GetAppointmentByAppointmentId(int ownerId, int appointmentId)
        {
            var appointment = await _appointmentRepository.GetById(appointmentId);

            if (appointment == null || appointment.OwnerId != ownerId)
            {
                throw new EntityNotFoundException($"Appointment with id = '{appointmentId}' not found");
            }

            return appointment;
        }

        public async Task<string> Login(string phone, string password)
        {
            var loginCheck = await _loginCredentialRepository.GetByPhone(phone);

            if (loginCheck == null)
            {
                throw new AuthenticationException($"Login credentials for phone = '{phone}' not found");
            }

            var encryptedPassword = BCrypt.Net.BCrypt.Verify(password, loginCheck.Password);
            
            if (encryptedPassword == false)
            {
                throw new AuthenticationException($"Login credentials for phone = '{phone}' not verified");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>
                {
                    new Claim("userId", (await _ownerRepository.GetByPhone(phone))!.Id.ToString())
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            return JsonConvert.SerializeObject(new JwtSecurityTokenHandler().WriteToken(tokeOptions));
        }
        





        // TransferBindVehicle()


    }
}
