using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class CreateUserDTO : IMappable
    {
        public string name { get; set; }
    }
}
