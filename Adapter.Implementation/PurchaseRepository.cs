using Adapter.Contract;
using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Adapter.Implementation
{
	public class PurchaseRepository : IPurchaseRepository
	{
		private readonly IUnitOfWork unitOfWork;

		public PurchaseRepository(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public HttpStatusCode Read(Guid purchaseId)
		{
			var reader = this.unitOfWork.CreateReader();

			Console.WriteLine($"Reading purchase with id {purchaseId}");
			reader.ReadData();

			return HttpStatusCode.OK;
		}

		public Response<Purchase> Create(Purchase purchase)
		{
			var writer = this.unitOfWork.CreateWriter();

			//do stuff with writer
			Console.WriteLine($"Creating purchase with id {purchase.Id}");
			writer.CreatePurchase();

			this.unitOfWork.SaveChanges(writer);

			return purchase;
		}
	}
}
