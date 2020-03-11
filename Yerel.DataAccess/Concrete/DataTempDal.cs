using Yerel.Absract;
using Yerel.Core.DataAccess.EntityFramework;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete
{
    public class DataTempDal : EfEntityRepositoryBase<DataTemp, DBContext>, IDataTempDal
    {
    }
}
