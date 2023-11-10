using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IAppointmentRepository
    {
        Task Create (Appointment appointment);
        Task<Appointment?> Get(int vehicleId, DateTime dateOfArrival);
        Task<List<Appointment>?> GetAllByGarageId(int garageId);
        Task<List<Appointment>?> GetAllByGarageIdForOwnerId(int garageId, int ownerId);
        Task<List<Appointment>?> GetAllByOwnerId(int ownerId);
        Task<Appointment?> GetById(int id);
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

        public async Task<Appointment?> Get(int vehicleId, DateTime dateOfArrival)
        {
            return await _dbContext.Appointments.SingleOrDefaultAsync(x => x.VehicleId == vehicleId && x.DateOfArrival == dateOfArrival);
        }


        public async Task SetDiagnosis(int appointmentId, string diagnosis)
        {
            var appointment = await _dbContext.Appointments.Where(x => x.Id == appointmentId).SingleOrDefaultAsync();
            appointment.Diagnosis = diagnosis;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Appointment>?> GetAllByOwnerId(int ownerId)
        {
            return await _dbContext.Appointments.Where(x => x.OwnerId == ownerId).ToListAsync();
        }

        public async Task<List<Appointment>?> GetAllByGarageId(int garageId)
        {
            return await _dbContext.Appointments.Where(x => x.GarageId == garageId).ToListAsync();
        }

        public async Task<List<Appointment>?> GetAllByGarageIdForOwnerId(int garageId, int ownerId)
        {
            return await _dbContext.Appointments.Where(x => x.GarageId == garageId &&  x.OwnerId == ownerId).ToListAsync();
        }


    }
}
