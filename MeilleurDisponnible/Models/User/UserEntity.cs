﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeilleurDisponnible.Models.Game;
using Microsoft.EntityFrameworkCore;

namespace MeilleurDisponnible.Models
{
    public class UserEntity : EntityBase 
    {
        public string Name { get; set; }
    }
}
