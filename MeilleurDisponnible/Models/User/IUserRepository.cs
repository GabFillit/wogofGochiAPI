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
        bool UpdateUser(int id, string name);
        void DeleteUser(int id);
    }
}
