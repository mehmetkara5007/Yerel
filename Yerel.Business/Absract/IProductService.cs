using System.Collections.Generic;
using System.ServiceModel;
using Yerel.Entities;

namespace Yerel.Business
{
    [ServiceContract]
    public interface IProductService 
    {
        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        Product GetProductById(int ProductId);

        [OperationContract]
        Product Insert(Product Product);

        [OperationContract]
        void Update(Product Product);

        [OperationContract]
        void Delete(int ProductId);
    }
}