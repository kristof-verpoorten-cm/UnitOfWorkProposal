using Adapter.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Implementation
{
	public class ContextFactory : IContextFactory
	{
		public IReadEntities CreateReader()
		{
			return new ReadEntities();
		}

		public IWriteEntities CreateWriter()
		{
			return new WriteEntities();
		}
	}
}
