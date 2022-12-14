using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract
{
	public class Purchase
	{
		public Guid Id { get; set; }

		public List<PurchaseItem> PurchaseItems { get; set; }
	}
}
