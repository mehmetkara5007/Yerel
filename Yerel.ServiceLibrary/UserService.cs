using System.Collections.Generic;
using Yerel.Business;
using Yerel.Business.Infrastructure.Ninject;
using Yerel.Entities;

namespace Yerel.ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        private readonly IUserService _UserService;


        public UserService()
        {
            _UserService = DependencyResolver<IUserService>.Resolve();
        }

        public List<User> GetAll()
        {
            return _UserService.GetAll();
        }

        public void Update(User User)
        {
            _UserService.Update(User);
        }

        public User GetUserById(int UserId)
        {
            return _UserService.GetUserById(UserId);
        }

        public void Delete(int UserId)
        {
            _UserService.Delete(UserId);
        }

        public User Insert(User User)
        {
            return _UserService.Insert(User);
        }

        public User GetUserByEmail(string mail, string pass)
        {
            return _UserService.GetUserByEmail(mail, pass);
        }
    }
}
