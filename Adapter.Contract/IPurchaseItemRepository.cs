using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Adapter.Contract
{
	public interface IPurchaseItemRepository
	{
		HttpStatusCode Read(int purchaseItemId);

		Response<PurchaseItem> CreateForPurchase(Guid purchaseId, PurchaseItem purchaseItem);
	}
}
