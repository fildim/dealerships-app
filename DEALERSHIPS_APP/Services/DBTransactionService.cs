using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DEALERSHIPS_APP.Services
{
	public interface IDBTransactionService
	{
		Task Begin();
		Task Commit();
		Task Rollback();
	}

	public class DBTransactionService : IDBTransactionService
	{
		private readonly DealershipDbContext _dbContext;
		private IDbContextTransaction? _transaction;

		public DBTransactionService(DealershipDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Begin()
		{
			_transaction = await _dbContext.Database.BeginTransactionAsync();
		}

		public async Task Commit()
		{
			if (_transaction == null)
			{
				throw new ArgumentNullException(nameof(_transaction));
			}

			await _transaction.CommitAsync();
		}

		public async Task Rollback()
		{
			if (_transaction == null)
			{
				throw new ArgumentNullException(nameof(_transaction));
			}

			await _transaction.RollbackAsync();
		}
	}
}
