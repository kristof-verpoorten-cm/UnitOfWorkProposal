using Adapter.Contract;
using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Implementation
{
	public class PurchaseItemService : IPurchaseItemService
	{
		private readonly IPurchaseItemRepository purchaseItemRepository;

		public PurchaseItemService(IPurchaseItemRepository purchaseItemRepository)
		{
			this.purchaseItemRepository = purchaseItemRepository;
		}

		public Response<PurchaseItem> Create(Guid purchaseId, PurchaseItem purchaseItem)
		{
			return this.purchaseItemRepository.CreateForPurchase(purchaseId, purchaseItem);
		}
	}
}
