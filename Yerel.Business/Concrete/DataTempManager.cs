using System.Collections.Generic;
using Yerel.Absract;
using Yerel.Entities;

namespace Yerel.Business
{
    public class DataTempManager: IDataTempService
    {
        private readonly IDataTempDal _DataTempDal;

        public DataTempManager(IDataTempDal DataTempDal)
        {
            _DataTempDal = DataTempDal;
        }

        public List<DataTemp> GetAll()
        {
            return _DataTempDal.GetList();
        }

        public DataTemp GetDataTempById(int DataTempId)
        {
            return _DataTempDal.Get(t => t.Id == DataTempId);
        }

        public DataTemp Insert(DataTemp DataTemp)
        {
            return _DataTempDal.Add(DataTemp);
        }

        public void Update(DataTemp DataTemp)
        {
            _DataTempDal.Update(DataTemp);
        }

        public void Delete(int DataTempId)
        {
            var DataTemp = _DataTempDal.Get(t => t.Id == DataTempId);
            _DataTempDal.Delete(DataTemp);
        }
    }
}