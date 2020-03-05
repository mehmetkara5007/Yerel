using Ninject.Modules;
using Yerel.Absract;
using Yerel.DataAccess.Concrete;

namespace Yerel.Business.Infrastructure.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //Bll Binding
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IStockService>().To<StockManager>().InSingletonScope();

            //Dal binding
            Bind<IProductDal>().To<ProductDal>().InSingletonScope();
            Bind<IStockDal>().To<StockDal>().InSingletonScope();
        }
    }
}