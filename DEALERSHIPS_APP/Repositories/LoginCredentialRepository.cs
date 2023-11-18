using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Repositories
{
	public interface ILoginCredentialRepository
	{
		Task Create(Logincredential logincredential);
        Task<Logincredential?> GetByPhone(string phone);
    }

	public class LoginCredentialRepository : ILoginCredentialRepository
	{
		private readonly DealershipDbContext _dbContext;

		public LoginCredentialRepository(DealershipDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(Logincredential logincredential)
		{
			_dbContext.Logincredentials.Add(logincredential);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Logincredential?> GetByPhone(string phone)
		{
			return await _dbContext.Logincredentials.SingleOrDefaultAsync(x => x.Phone == phone);			
		}
	}
}
