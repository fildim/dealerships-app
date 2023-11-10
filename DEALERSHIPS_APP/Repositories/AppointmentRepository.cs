using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
	public interface IAppointmentRepository
	{
		Task Create(Appointment appointment);
		Task<Appointment?> GetByVehicleIdAndDateOfArrival(int vehicleId, DateTime dateOfArrival);
		Task<List<Appointment>> GetByGarageId(int garageId);
		Task<List<Appointment>> GetByGarageIdAndOwnerId(int garageId, int ownerId);
		Task<List<Appointment>> GetByOwnerId(int ownerId);
		Task<Appointment?> GetById(int id);
		Task Update(Appointment appointment);
	}

	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly DealershipDbContext _dbContext;

		public AppointmentRepository(DealershipDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(Appointment appointment)
		{
			_dbContext.Appointments.Add(appointment);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Appointment?> GetById(int id)
		{
			return await _dbContext.Appointments.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Appointment?> GetByVehicleIdAndDateOfArrival(int vehicleId, DateTime dateOfArrival)
		{
			return await _dbContext.Appointments.SingleOrDefaultAsync(x => x.VehicleId == vehicleId && x.DateOfArrival == dateOfArrival);
		}

		public async Task<List<Appointment>> GetByOwnerId(int ownerId)
		{
			return await _dbContext.Appointments.Where(x => x.OwnerId == ownerId).ToListAsync();
		}

		public async Task<List<Appointment>> GetByGarageId(int garageId)
		{
			return await _dbContext.Appointments.Where(x => x.GarageId == garageId).ToListAsync();
		}

		public async Task<List<Appointment>> GetByGarageIdAndOwnerId(int garageId, int ownerId)
		{
			return await _dbContext.Appointments.Where(x => x.GarageId == garageId && x.OwnerId == ownerId).ToListAsync();
		}

		public async Task Update(Appointment appointment)
		{
			_dbContext.Appointments.Update(appointment);
			await _dbContext.SaveChangesAsync();
		}
	}
}
