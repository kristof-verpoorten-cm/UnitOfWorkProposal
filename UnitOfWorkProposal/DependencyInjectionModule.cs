using Adapter.Contract;
using Adapter.Implementation;
using Domain.Contract;
using Domain.Implementation;
using Ninject.Modules;

namespace UnitOfWorkProposal
{
	internal class DependencyInjectionModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IPurchaseService>().To<PurchaseService>();
			Bind<IPurchaseItemService>().To<PurchaseItemService>();

			Bind<IPurchaseRepository>().To<PurchaseRepository>();
			Bind<IPurchaseItemRepository>().To<PurchaseItemRepository>();

			//in our website this needs to be in request scope instead of singleton
			Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
			Bind<IContextFactory>().To<ContextFactory>();
			Bind<IWriteEntities>().To<WriteEntities>();
			Bind<IReadEntities>().To<ReadEntities>();
		}
	}
}
