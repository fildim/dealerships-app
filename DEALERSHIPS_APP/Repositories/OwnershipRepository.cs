using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IOwnershipRepository
    {
        Task Create(Ownership ownership);
        Task<List<int>> GetAllVehicleIds();
        Task<List<Vehicle>> GetVehiclesByOwnerId(int ownerId);
    }

    public class OwnershipRepository : IOwnershipRepository
    {
        private readonly DealershipDbContext _dbContext;

        public OwnershipRepository(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<int>> GetAllVehicleIds()
        {
            return await _dbContext.Ownerships.Select(x => x.VehicleId).ToListAsync();
        }

        public async Task Create(Ownership ownership)
        {
            _dbContext.Ownerships.Add(ownership);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Vehicle>> GetVehiclesByOwnerId(int ownerId)
        {
            return await _dbContext.Ownerships.Include(x => x.Vehicle).Where(x => x.OwnerId == ownerId).Select(x => x.Vehicle).ToListAsync();
        }


    }
}
