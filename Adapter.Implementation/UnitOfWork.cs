using Adapter.Contract;
using Geevers.Infrastructure;
using System.Net;

namespace Adapter.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IContextFactory contextFactory;

		private ITransaction currentTransaction = null;

		public UnitOfWork(IContextFactory contextFactory)
		{
			this.contextFactory = contextFactory;
		}

		public ITransaction BeginTransaction()
		{
			if (this.TransactionInProgress)
			{
				return this.currentTransaction;
			}

			this.currentTransaction = new Transaction(this.contextFactory.CreateWriter());

			return this.currentTransaction;
		}

		public bool TransactionInProgress => this.currentTransaction?.IsActive ?? false;

		public IReadEntities CreateReader()
		{
			if (false == this.TransactionInProgress)
			{
				return this.contextFactory.CreateReader();
			}

			return this.currentTransaction.Reader;
		}

		public IWriteEntities CreateWriter()
		{
			if (false == this.TransactionInProgress)
			{
				return this.contextFactory.CreateWriter();
			}

			return this.currentTransaction.Writer;
		}

		
		public void SaveChanges(IWriteEntities writer)
		{
			//only save changes when no transaction in progress, otherwise they need to be saved by calling CommitTransaction
			if (false == this.TransactionInProgress)
			{
				writer.SaveChanges();
			}
		}
	}
}
