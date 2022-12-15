using Adapter.Contract;

namespace Adapter.Implementation
{
	public class Transaction: ITransaction
	{
		private IWriteEntities writeEntities;

		public Transaction(IWriteEntities writeEntities)
		{
			this.writeEntities = writeEntities;
		}

		public bool IsActive => this.writeEntities != null;

		public IReadEntities Reader => this.writeEntities;

		public IWriteEntities Writer => this.writeEntities;

		public void Commit()
		{
			this.writeEntities.SaveChanges();
		}

		public void Rollback()
		{
			this.writeEntities = null;
		}

		public void Dispose()
		{
			this.Rollback();
		}
	}
}
