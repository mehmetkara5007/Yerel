using System.Collections.Generic;
using Yerel.Absract;
using Yerel.Entities;

namespace Yerel.Business
{
    public class ProductManager: IProductService
    {
        private readonly IProductDal _ProductDal;

        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public List<Product> GetAll()
        {
            return _ProductDal.GetList();
        }

        public Product GetProductById(int ProductId)
        {
            return _ProductDal.Get(t => t.Id == ProductId);
        }

        public Product Insert(Product Product)
        {
            return _ProductDal.Add(Product);
        }

        public void Update(Product Product)
        {
            _ProductDal.Update(Product);
        }

        public void Delete(int ProductId)
        {
            var Product = _ProductDal.Get(t => t.Id == ProductId);
            _ProductDal.Delete(Product);
        }
    }
}