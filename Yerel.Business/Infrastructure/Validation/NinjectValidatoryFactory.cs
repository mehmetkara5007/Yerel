using System;
using FluentValidation;
using Ninject;

namespace Yerel.Business.Infrastructure.Validation
{
    public class NinjectValidatoryFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public NinjectValidatoryFactory()
        {
            _kernel = new StandardKernel();

            //_kernel.Bind<IValidator<Personel>>().To<PersonelValidator>().InSingletonScope();
            //_kernel.Bind<IValidator<DilKelime>>().To<DilKelimeValidator>().InSingletonScope();
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (validatorType == null) ? null : (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
