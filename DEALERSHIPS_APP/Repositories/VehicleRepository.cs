using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAll();
    }

    public class VehicleRepository : IVehicleRepository
    {
        private readonly DealershipDbContext _dbContext;

        public VehicleRepository(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Vehicle>> GetAll()
        {
            return await _dbContext.Vehicles.ToListAsync();
        }
    }
}
