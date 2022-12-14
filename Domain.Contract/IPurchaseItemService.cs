using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract
{
	public interface IPurchaseItemService
	{
		Response<PurchaseItem> Create(Guid purchaseId, PurchaseItem purchaseItem);
	}
}
