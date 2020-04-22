using System.Collections.Generic;
using System.ServiceModel;
using Yerel.Entities;

namespace Yerel.Business
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAll();

        [OperationContract]
        User GetUserByEmail(string mail, string pass);

        [OperationContract]
        User GetUserById(int UserId);

        [OperationContract]
        User Insert(User User);

        [OperationContract]
        void Update(User User);

        [OperationContract]
        void Delete(int UserId);
    }
}