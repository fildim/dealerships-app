using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IOwnershipRepository
    {
        Task<List<int>> GetAllVehicleIds();
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
    }
}
