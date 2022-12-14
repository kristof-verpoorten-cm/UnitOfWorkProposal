using Domain.Contract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkProposal
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel(new DependencyInjectionModule());
			var purchaseService = kernel.Get<IPurchaseService>();
			var purchaseItemService = kernel.Get<IPurchaseItemService>();

			Console.WriteLine("CREATE A PURCHASE WITHOUT TRANSACTION");
			Console.WriteLine("=====================================");
			purchaseService.Create(new Purchase { Id = Guid.NewGuid() });

			Console.WriteLine("\n\n\nCREATE A PURCHASE AND PURCHASEITEMS WITH A TRANSACTION");
			Console.WriteLine("======================================================");
			var purchaseId = Guid.NewGuid();
			purchaseService.CreateWithPurchaseItems(
				new Purchase { Id = purchaseId },
				new List<PurchaseItem> {
					new PurchaseItem(),
					new PurchaseItem(),
					new PurchaseItem()
				}
			);

			Console.WriteLine("\n\n\nCREATE A PURCHASEITEM FOR AN EXISTING PURCHASE WITHOUT A TRANSACTION");
			Console.WriteLine("==========================================================================");
			purchaseItemService.Create(purchaseId, new PurchaseItem());

			Console.ReadLine();
		}	
	}
}
