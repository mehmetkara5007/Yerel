using Ninject;

namespace Yerel.Business.Infrastructure.Ninject
{
    public static class DependencyResolver<T>
    {
        private static readonly IKernel _kernel;
        static DependencyResolver()
        {
            _kernel = new StandardKernel(new BusinessModule());
        }

        public static T Resolve()
        {
            return _kernel.Get<T>();
        }
    }
}