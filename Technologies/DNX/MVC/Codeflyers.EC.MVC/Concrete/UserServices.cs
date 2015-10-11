using System.Collections.Generic;
using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Abstract;

namespace Codeflyers.EC.MVC.Concrete
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddOrUpdate(user);
        }
        public User UpdateUser(User user)
        {
            return _userRepository.AddOrUpdate(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public bool AuthenticateUser(string userName, string password)
        {
            User user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                return user.Password == password;
            }
            return false;
        }
    }
}
