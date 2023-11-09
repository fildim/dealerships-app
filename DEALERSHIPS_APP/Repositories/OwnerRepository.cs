using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
    public interface IOwnerRepository
    {
        Task Create(Owner owner);
        Task<Owner?> GetById(int id);
        Task<Owner?> GetByPhone(string phone);
    }



    public class OwnerRepository : IOwnerRepository
    {
        private readonly DealershipDbContext _dbContext;

        public OwnerRepository(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public async Task Create(Owner owner)
        {
            _dbContext.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Owner?> GetById(int id)
        {
            return await _dbContext.Owners.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Owner?> GetByPhone(string phone)
        {
            return await _dbContext.Owners.SingleOrDefaultAsync(x => x.Phone == phone);
        }





    }
}



