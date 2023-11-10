
using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
	public interface IGarageRepository
	{
		Task Create(Garage garage);
		Task<Garage?> GetById(int id);
		Task<Garage?> GetByPhone(string phone);
	}

	public class GarageRepository : IGarageRepository
	{
		private readonly DealershipDbContext _dbContext;

		public GarageRepository(DealershipDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(Garage garage)
		{
			_dbContext.Garages.Add(garage);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Garage?> GetById(int id)
		{
			return await _dbContext.Garages.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Garage?> GetByPhone(string phone)
		{
			return await _dbContext.Garages.SingleOrDefaultAsync(x => x.Phone == phone);
		}
	}
}
