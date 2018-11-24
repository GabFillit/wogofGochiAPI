using MeilleurDisponnible.Models.Game;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models
{
    public class MeilleurDisponnibleContext : DbContext
    {
        public MeilleurDisponnibleContext(DbContextOptions<MeilleurDisponnibleContext> options)
            : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        
    }
}
