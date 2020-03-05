using Ninject.Modules;

namespace Yerel.Business.Infrastructure.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.Create()).InSingletonScope();
            Bind<IStockService>().ToConstant(WcfProxy<IStockService>.Create()).InSingletonScope();
        }
    }
}
