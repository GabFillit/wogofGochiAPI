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
                .FirstOrDefault<UserEntity>(u => u.Id == id);
            return user;
        }

        public void CreateUser(string name)
        {
            _context.UserEntity
                .Add(new UserEntity
                {
                    Name = name
                });

            _context.SaveChanges();
        }

        public void UpdateUser(UserEntity user, string name)
        {
            user.Name = name;
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(UserEntity user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
