using System.Data.SqlClient;
using System.Linq;
using Yerel.Absract;
using Yerel.Core.DataAccess.EntityFramework;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, DBContext>, IUserDal
    {
        public User GetUserByEmail(string mail, string pass)
        {
            using (var context = new DBContext())
            {
                var UserByEmail = new SqlParameter("@mail", mail);
                var UserByEmail2 = new SqlParameter("@pass", pass);
                var result = context.Database.SqlQuery<User>("GetUserByEmail @mail, @pass", UserByEmail, UserByEmail2).FirstOrDefault();
                return result;
            }
        }

    }
}
