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
        void CreateUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        int SaveUser();
    }
}
