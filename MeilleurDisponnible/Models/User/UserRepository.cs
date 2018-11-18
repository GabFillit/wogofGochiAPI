using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class UserRepository : IUserRepository
    {
        public static List<UserEntity> UserList { get; set; }

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
            return UserList;
        }

        public UserEntity GetUser(int id)
        {
            return UserList.FirstOrDefault(user => user.Id == id);
        }

        public int CreateUser(string name)
        {
            int id = UserList.Count;
            UserList.Add(new UserEntity
            {
                Id = id,
                Name = name
            });

            return id;
        }

        public void UpdateUser(UserEntity user, string name)
        {
            user.Name = name;
        }

        public void DeleteUser(UserEntity user)
        {
            UserList.Remove(user);
        }
    }
}
