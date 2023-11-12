using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Repositories
{
	public interface ILoginCredentialRepository
	{
		Task Create(Logincredential logincredential);
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
	}
}
