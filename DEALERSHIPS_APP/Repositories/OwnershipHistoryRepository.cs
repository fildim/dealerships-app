using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IOwnershipHistoryRepository
    {
        Task Create(OwnershipHistory ownershipHistory);
        Task<List<OwnershipHistory>> GetAllByVehicleId(int vehicleId);
    }

    public class OwnershipHistoryRepository : IOwnershipHistoryRepository
    {
        private readonly DealershipDbContext _dbContext;

        public OwnershipHistoryRepository(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OwnershipHistory>> GetAllByVehicleId(int vehicleId)
        {
            return await _dbContext.OwnershipHistories.Where(x => x.VehicleId == vehicleId).ToListAsync();
        }

        public async Task Create(OwnershipHistory ownershipHistory)
        {
            _dbContext.OwnershipHistories.Add(ownershipHistory);
            await _dbContext.SaveChangesAsync();
        }


    }
}
