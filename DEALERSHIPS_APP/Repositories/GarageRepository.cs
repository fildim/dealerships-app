
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IGarageRepository
    {
        Task Create(Garage garage);
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
    }
}
