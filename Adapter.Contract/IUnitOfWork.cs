using System.Net;

namespace Adapter.Contract
{
	public interface IUnitOfWork
	{
		HttpStatusCode BeginTransaction();
		IReadEntities CreateReader();
		IWriteEntities CreateWriter();
		HttpStatusCode RollbackTransaction();
		HttpStatusCode CommitTransaction();
		void SaveChanges(IWriteEntities writer);
	}
}
