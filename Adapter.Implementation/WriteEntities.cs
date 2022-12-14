using Adapter.Contract;
using System;

namespace Adapter.Implementation
{
	public class WriteEntities : IWriteEntities
	{
		private Guid contextId;

		public WriteEntities()
		{
			contextId = Guid.NewGuid();
		}

		public void CreatePurchase()
		{
			Console.WriteLine($"IWriteEntities for context with ID {this.contextId}: Creating a new purchase");
		}

		public void CreatePurchaseItem()
		{
			Console.WriteLine($"IWriteEntities for context with ID {this.contextId}: Creating a new purchase item");
		}

		public void ReadData()
		{
			Console.WriteLine($"IReadEntities for context with ID {this.contextId}: Reading data");
		}

		public void SaveChanges()
		{
			Console.WriteLine($"IWriteEntities for context with ID {this.contextId}: SaveChanges()");
		}
	}
}
