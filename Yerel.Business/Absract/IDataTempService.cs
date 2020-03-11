using System.Collections.Generic;
using System.ServiceModel;
using Yerel.Entities;

namespace Yerel.Business
{
    [ServiceContract]
    public interface IDataTempService 
    {
        [OperationContract]
        List<DataTemp> GetAll();

        [OperationContract]
        DataTemp GetDataTempById(int DataTempId);

        [OperationContract]
        DataTemp Insert(DataTemp DataTemp);

        [OperationContract]
        void Update(DataTemp DataTemp);

        [OperationContract]
        void Delete(int DataTempId);
    }
}