using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class UserRepository : IUserRepository
    {
        public MeilleurDisponnibleContext _context;
        public UserRepository(MeilleurDisponnibleContext context)
        {
            _context = context;
        }

        public List<UserEntity> GetUsers()
        {
            var userList = _context.UserEntity.ToList();
            return userList;
        }

        public UserEntity GetUser(int id)
        {
            var user = _context.UserEntity
                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void CreateUser(UserEntity user)
        {
            _context.UserEntity
                .Add(user);
        }

        public void UpdateUser(UserEntity user)
        {
            _context.Update(user);
        }

        public void DeleteUser(UserEntity user)
        {
            _context.Remove(user);
        }

        public int SaveUser()
        {
            return _context.SaveChanges();
        }
    }
}
