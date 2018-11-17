using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class UserRepository : IUserRepository
    {
        public List<UserEntity> UserList { get; set; }

        public UserRepository()
        {
            UserList = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 0,
                    Name = "default"
                }
            };
        }

        public List<UserEntity> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUser(int id)
        {
            return UserList.ElementAtOrDefault(id);
        }

        public void CreateUser(string name)
        {
            UserList.Add(new UserEntity
            {
                Id = UserList.Count,
                Name = name
            });
        }

        public bool UpdateUser(int id, string name)
        {
            bool updated = false;
            UserEntity user = UserList.ElementAtOrDefault(id);
            if (user != null)
            {
                user.Name = name;
                updated = true;
            }
            return updated;
        }

        public void DeleteUser(int id)
        {
            UserList.RemoveAt(id);
        }
    }
}
