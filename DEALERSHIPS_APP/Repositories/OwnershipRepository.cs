using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
	public interface IOwnershipRepository
	{
		Task Create(Ownership ownership);
		Task<List<int>> Get();
		Task<List<Vehicle>> GetByOwnerId(int ownerId);
	}

	public class OwnershipRepository : IOwnershipRepository
	{
		private readonly DealershipDbContext _dbContext;

		public OwnershipRepository(DealershipDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<int>> Get()
		{
			return await _dbContext.Ownerships.Select(x => x.VehicleId).ToListAsync();
		}

		public async Task Create(Ownership ownership)
		{
			_dbContext.Ownerships.Add(ownership);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Vehicle>> GetByOwnerId(int ownerId)
		{
			return await _dbContext.Ownerships.Where(x => x.OwnerId == ownerId).Select(x => x.Vehicle).ToListAsync();
		}
	}
}
