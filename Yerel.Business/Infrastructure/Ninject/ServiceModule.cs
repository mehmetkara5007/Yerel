using Ninject.Modules;

namespace Yerel.Business.Infrastructure.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataTempService>().ToConstant(WcfProxy<IDataTempService>.Create()).InSingletonScope();
            Bind<IUserService>().ToConstant(WcfProxy<IUserService>.Create()).InSingletonScope();
        }
    }
}
