using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Contract
{
	public interface IWriteEntities: IReadEntities
	{
		void SaveChanges();

		void CreatePurchase();

		void CreatePurchaseItem();
	}
}
