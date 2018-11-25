using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public interface IUserRepository
    {
        List<UserEntity> GetUsers();
        UserEntity GetUser(int id);
        void CreateUser(string name);
        void UpdateUser(UserEntity user, string name);
        void DeleteUser(UserEntity user);
    }
}
