using Adapter.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Implementation
{
	public class ReadEntities : IReadEntities
	{
		private Guid contextId;

		public ReadEntities()
		{
			contextId = Guid.NewGuid();
		}

		public void ReadData()
		{
			Console.WriteLine($"IReadEntities for context with ID {this.contextId}: Reading data");
		}
	}
}
