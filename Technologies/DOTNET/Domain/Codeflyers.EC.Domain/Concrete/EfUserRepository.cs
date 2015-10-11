using System;
using System.Linq;
using System.Linq.Expressions;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.Domain.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private EfDbContext _efDbContext = new EfDbContext();
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User AddOrUpdate(User entity)
        {
            User User;
            if (entity.UserId == 0)
            {
                User = _efDbContext.Users.Add(entity);
            }
            else
            {
                User = _efDbContext.Users.Find(entity.UserId);
                User.Name = entity.Name;
                User.Email = entity.Email;
                User.Phone = entity.Phone;
                User.Address = entity.Address;
                User.PostCode = entity.PostCode;
                User.Country = entity.Country;
                User.State = entity.State;
                User.UserName = entity.UserName;
                User.Password = entity.Password;
            }
            Save();
            return User;
        }

        public User GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public User GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _efDbContext.Users;
        }

        public IQueryable<User> GetMany(Expression<Func<User, bool>> @where)
        {
            return _efDbContext.Users.Where(@where);
        }

        public User Remove(int id)
        {
            var user = _efDbContext.Users.Find(id);
            if (user != null)
            {
                _efDbContext.Users.Remove(user);
                Save();
                return user;
            }
            return null;
        }

        public User Remove(User obj)
        {
            if (obj != null)
            {
                var user = _efDbContext.Users.Find(obj.UserId);
                return Remove(user.UserId);
            }
            throw new ArgumentNullException("obj","The obj can't be null");
        }

        public User Remove(Expression<Func<User, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _efDbContext.SaveChanges();
        }
    }
}
