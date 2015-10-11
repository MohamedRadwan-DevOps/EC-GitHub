using System.Collections.Generic;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.Services.Abstract
{
    public interface IUserServices
    {
        User AddUser(User user);
        User UpdateUser(User user);
        User GetUser(int id);
        List<User> GetAllUsers();
        bool AuthenticateUser(string userName, string password);
    }
}