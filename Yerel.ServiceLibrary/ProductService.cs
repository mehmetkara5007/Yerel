using System.Collections.Generic;
using Yerel.Business;
using Yerel.Business.Infrastructure.Ninject;
using Yerel.Entities;

namespace Yerel.ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        private readonly IProductService _ProductService;


        public ProductService()
        {
            _ProductService = DependencyResolver<IProductService>.Resolve();
        }

        public List<Product> GetAll()
        {
            return _ProductService.GetAll();
        }

        public void Update(Product Product)
        {
            _ProductService.Update(Product);
        }

        public Product GetProductById(int ProductId)
        {
            return _ProductService.GetProductById(ProductId);
        }

        public void Delete(int ProductId)
        {
            _ProductService.Delete(ProductId);
        }

        public Product Insert(Product Product)
        {
            return _ProductService.Insert(Product);
        }
    }
}
