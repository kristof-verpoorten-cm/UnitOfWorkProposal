namespace Adapter.Contract
{
	public interface IUnitOfWork
	{
		ITransaction BeginTransaction();

		bool TransactionInProgress { get; }

		IReadEntities CreateReader();

		IWriteEntities CreateWriter();

		void SaveChanges(IWriteEntities writer);
	}
}
