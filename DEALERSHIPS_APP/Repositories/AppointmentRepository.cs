using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IAppointmentRepository
    {
        Task Create (Appointment appointment);
        Task<Appointment?> Get(int vehicleId, DateTime dateOfArrival);
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



    }
}
