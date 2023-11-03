using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IAppointmentRepository
    {
        Task Create (Appointment appointment);
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
    }
}
