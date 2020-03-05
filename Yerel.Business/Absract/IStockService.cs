using System.Collections.Generic;
using System.ServiceModel;
using Yerel.Entities;

namespace Yerel.Business
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        List<Stock> GetAll();

        [OperationContract]
        Stock GetStockById(int StockId);

        [OperationContract]
        Stock Insert(Stock Stock);

        [OperationContract]
        void Update(Stock Stock);

        [OperationContract]
        void Delete(int StockId);
    }
}