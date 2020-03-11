using Yerel.Core.DataAccess;
using Yerel.Entities;

namespace Yerel.Absract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetUserByEmail(string mail, string pass);
    }
}
