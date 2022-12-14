using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Contract
{
	public interface IContextFactory
	{
		IReadEntities CreateReader();
		IWriteEntities CreateWriter();
	}
}
