using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
	public interface IGarageService
	{
		Task Create(Garage garage);
		Task<List<Appointment>> GetAppointmentsByOwnerId(int garageId, int ownerId);
		Task<List<Appointment>> GetAppointments(int garageId);
		Task<Appointment> GetAppointmentByAppointmentId(int garageId, int appointmentId);
		Task<Garage> GetById(int id);
	}

	public class GarageService : IGarageService
	{
		private readonly IGarageRepository _garageRepository;
		private readonly IAppointmentRepository _appointmentRepository;

		public GarageService(IGarageRepository repository, IAppointmentRepository appointmentRepository)
		{
			_garageRepository = repository;
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

		public async Task<List<Appointment>> GetAppointments(int garageId)
		{
			return await _appointmentRepository.GetByGarageId(garageId);
		}

		public async Task<List<Appointment>> GetAppointmentsByOwnerId(int garageId, int ownerId)
		{
			return await _appointmentRepository.GetByGarageIdAndOwnerId(garageId, ownerId);
		}

		//todo implement in controller
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
