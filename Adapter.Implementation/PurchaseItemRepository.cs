using Adapter.Contract;
using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Adapter.Implementation
{
	public class PurchaseItemRepository : IPurchaseItemRepository
	{
		private readonly IUnitOfWork unitOfWork;

		public PurchaseItemRepository(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public HttpStatusCode Read(int purchaseItemId)
		{
			var reader = this.unitOfWork.CreateReader();

			Console.WriteLine($"Read purchaseItem");
			reader.ReadData();

			return HttpStatusCode.OK;
		}

		public Response<PurchaseItem> CreateForPurchase(Guid purchaseId, PurchaseItem purchaseItem)
		{
			// the repositories don't know if they are in a transaction or not, they always work the same
			var writer = this.unitOfWork.CreateWriter();

			//do stuff with writer
			Console.WriteLine($"Create purchaseItem for purchase with id {purchaseId}");
			writer.CreatePurchaseItem();

			this.unitOfWork.SaveChanges(writer);	//this is a no-op in case of a transaction being active

			return purchaseItem;
		}
	}
}
