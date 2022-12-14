using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract
{
	public interface IPurchaseService
	{
		Response<Purchase> Create(Purchase purchase);

		Response<Purchase> CreateWithPurchaseItems(Purchase purchase, ICollection<PurchaseItem> purchaseItems);
	}
}
