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
            Bind<IDataTempService>().To<DataTempManager>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();

            //Dal binding
            Bind<IDataTempDal>().To<DataTempDal>().InSingletonScope();
            Bind<IUserDal>().To<UserDal>().InSingletonScope();
        }
    }
}