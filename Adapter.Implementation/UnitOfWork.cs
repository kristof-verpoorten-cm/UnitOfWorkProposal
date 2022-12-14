using Adapter.Contract;
using System.Net;

namespace Adapter.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IContextFactory contextFactory;

		private IWriteEntities transactionContext = null;
		private bool transactionInProgress = false;

		public UnitOfWork(IContextFactory contextFactory)
		{
			this.contextFactory = contextFactory;
		}

		public HttpStatusCode BeginTransaction()
		{
			if (this.transactionInProgress)
			{
				return HttpStatusCode.BadRequest;
			}

			this.transactionContext = this.contextFactory.CreateWriter();
			this.transactionInProgress = true;

			return HttpStatusCode.NoContent;
		}

		public IReadEntities CreateReader()
		{
			if (false == this.transactionInProgress)
			{
				return this.contextFactory.CreateReader();
			}

			return this.transactionContext;
		}

		public IWriteEntities CreateWriter()
		{
			if (false == this.transactionInProgress)
			{
				return this.contextFactory.CreateWriter();
			}
			
			return this.transactionContext;
		}

		public HttpStatusCode CommitTransaction()
		{
			if (false == this.transactionInProgress)
			{
				return HttpStatusCode.BadRequest;
			}

			this.transactionContext.SaveChanges();
			this.transactionInProgress = false;

			return HttpStatusCode.NoContent;
		}

		public HttpStatusCode RollbackTransaction()
		{
			if (false == this.transactionInProgress)
			{
				return HttpStatusCode.BadRequest;
			}

			this.transactionContext = null;
			this.transactionInProgress = false;

			return HttpStatusCode.NoContent;
		}

		public void SaveChanges(IWriteEntities writer)
		{
			//only save changes when no transaction in progress, otherwise they need to be saved by calling CommitTransaction
			if (false == this.transactionInProgress)
			{
				writer.SaveChanges();
			}
		}
	}
}
