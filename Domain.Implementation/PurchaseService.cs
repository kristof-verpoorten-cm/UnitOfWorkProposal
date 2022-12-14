using Adapter.Contract;
using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Implementation
{
	public class PurchaseService : IPurchaseService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IPurchaseRepository purchaseRepository;
		private readonly IPurchaseItemRepository purchaseItemRepository;

		public PurchaseService(
			IUnitOfWork unitOfWork,
			IPurchaseRepository purchaseRepository, 
			IPurchaseItemRepository purchaseItemRepository)
		{
			this.unitOfWork = unitOfWork;
			this.purchaseRepository = purchaseRepository;
			this.purchaseItemRepository = purchaseItemRepository;
		}
		public Response<Purchase> Create(Purchase purchase)
		{
			return this.purchaseRepository.Create(purchase);
		}

		public Response<Purchase> CreateWithPurchaseItems(Purchase purchase, ICollection<PurchaseItem> purchaseItems)
		{
			if (this.unitOfWork.BeginTransaction().IsNot(HttpStatusCode.NoContent, out var beginTransactionFail))
			{
				return beginTransactionFail;
			}

			this.purchaseRepository.Create(purchase);	//the service uses the same repository functions wheter a transaction is active or not
			this.purchaseRepository.Read(purchase.Id);

			foreach(var purchaseItem in purchaseItems)
			{
				this.purchaseItemRepository.CreateForPurchase(purchase.Id, purchaseItem);
			}

			this.unitOfWork.CommitTransaction();

			return purchase;
		}
	}
}
