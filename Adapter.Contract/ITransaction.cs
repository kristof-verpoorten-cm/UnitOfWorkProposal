using System;

namespace Adapter.Contract
{
	public interface ITransaction : IDisposable
	{
		bool IsActive { get; }

		IReadEntities Reader { get; }

		IWriteEntities Writer { get; }

		void Commit();

		void Rollback();
	}
}
