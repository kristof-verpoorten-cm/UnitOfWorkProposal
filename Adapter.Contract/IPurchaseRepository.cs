using Domain.Contract;
using Geevers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Adapter.Contract
{
	public interface IPurchaseRepository
	{
		HttpStatusCode Read(Guid purchaseId);

		Response<Purchase> Create(Purchase purchase);
	}
}
