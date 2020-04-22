using System.Collections.Generic;
using Yerel.Absract;
using Yerel.Entities;

namespace Yerel.Business
{
    public class UserManager: IUserService
    {
        private readonly IUserDal _UserDal;

        public UserManager(IUserDal UserDal)
        {
            _UserDal = UserDal;
        }

        public List<User> GetAll()
        {
            return _UserDal.GetList();
        }

        public User GetUserById(int UserId)
        {
            return _UserDal.Get(t => t.Id == UserId);
        }

        public User Insert(User User)
        {
            return _UserDal.Add(User);
        }

        public void Update(User User)
        {
            _UserDal.Update(User);
        }

        public void Delete(int UserId)
        {
            var User = _UserDal.Get(t => t.Id == UserId);
            _UserDal.Delete(User);
        }

        public User GetUserByEmail(string mail, string pass)
        {
            return _UserDal.GetUserByEmail(mail, pass);
        }
    }
}