using System.Collections.Generic;
using Yerel.Absract;
using Yerel.Entities;

namespace Yerel.Business
{
    public class StockManager: IStockService
    {
        private readonly IStockDal _StockDal;

        public StockManager(IStockDal StockDal)
        {
            _StockDal = StockDal;
        }

        public List<Stock> GetAll()
        {
            return _StockDal.GetList();
        }

        public Stock GetStockById(int StockId)
        {
            return _StockDal.Get(t => t.store_id == StockId);
        }

        public Stock Insert(Stock Stock)
        {
            return _StockDal.Add(Stock);
        }

        public void Update(Stock Stock)
        {
            _StockDal.Update(Stock);
        }

        public void Delete(int StockId)
        {
            var Stock = _StockDal.Get(t => t.store_id == StockId);
            _StockDal.Delete(Stock);
        }
    }
}