﻿using AutoMapper;
using DEALERSHIPS_APP.Exceptions;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;

namespace DEALERSHIPS_APP.Services
{
	public interface IOwnerService
	{
		Task Create(Owner owner);
		Task<List<Appointment>> GetAppointments(int ownerId);
		Task<Appointment> GetAppointmentByAppointmentId(int ownerId, int appointmentId);
		Task<List<Vehicle>> GetVehicles(int ownerId);
		Task<Owner> GetById(int id);
		Task OwnVehicle(int ownerId, int vehicleId);
	}

	public class OwnerService : IOwnerService
	{
		private readonly IOwnerRepository _ownerRepository;
		private readonly IOwnershipRepository _ownershipRepository;
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IOwnershipHistoryRepository _ownershipHistoryRepository;
		private readonly IAppointmentRepository _appointmentRepository;
		private readonly IMapper _mapper;
		private readonly IDBTransactionService _dbTransactionService;

		public OwnerService(IOwnerRepository repository, IOwnershipRepository ownershipRepository, IVehicleRepository vehicleRepository, IOwnershipHistoryRepository ownershipHistoryRepository, IMapper mapper, IDBTransactionService dbTransactionService, IAppointmentRepository appointmentRepository)
		{
			_ownerRepository = repository;
			_ownershipRepository = ownershipRepository;
			_vehicleRepository = vehicleRepository;
			_ownershipHistoryRepository = ownershipHistoryRepository;
			_mapper = mapper;
			_dbTransactionService = dbTransactionService;
			_appointmentRepository = appointmentRepository;
		}

		public async Task Create(Owner owner)
		{
			var ownerCheck = await _ownerRepository.GetByPhone(owner.Phone);

			if (ownerCheck != null)
			{
				throw new EntityAlreadyExistsException($"Owner with phone = '{owner.Phone}' already exists");
			}

			owner.Created = DateTime.Now;
			await _ownerRepository.Create(owner);
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

		public async Task OwnVehicle(int ownerId, int vehicleId)
		{
			var owner = await _ownerRepository.GetById(ownerId);

			if (owner == null)
			{
				throw new EntityNotFoundException($"Owner with id = '{ownerId}' not found");
			}

			var ownershipHistories = await _ownershipHistoryRepository.GetByVehicleId(vehicleId);

			if (ownershipHistories.Count == 0)
			{
				throw new EntityNotFoundException($"Vehicle with id = '{vehicleId}' history not found");
			}

			var vehicle = await _vehicleRepository.GetById(vehicleId);

			if (vehicle == null)
			{
				throw new EntityNotFoundException($"Vehicle with id = '{vehicleId}' not found");
			}

			var ownedVehicles = await _ownershipRepository.Get();

			if (ownedVehicles.Contains(vehicleId))
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

				await _ownershipHistoryRepository.Create(newOwnershipHistory); ;

				await _dbTransactionService.Commit();
			}
			catch
			{
				await _dbTransactionService.Rollback();
				throw;
			}
		}

		public async Task<List<Vehicle>> GetVehicles(int ownerId)
		{
			return await _ownershipRepository.GetByOwnerId(ownerId);
		}

		public async Task<List<Appointment>> GetAppointments(int ownerId)
		{
			return await _appointmentRepository.GetByOwnerId(ownerId);
		}

		public async Task<Appointment> GetAppointmentByAppointmentId(int ownerId, int appointmentId)
		{
			var appointment = await _appointmentRepository.GetById(appointmentId);

			if (appointment == null || !appointment.OwnerId.Equals(ownerId))
			{
				throw new EntityNotFoundException($"Appointment with id = '{appointmentId}' not found");
			}

			return appointment;
		}

		// TransferBindVehicle()
	}
}
