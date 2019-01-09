using MeilleurDisponnible.Models.Character;
using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Models.Stats;
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

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<Game.Game> GameEntity { get; set; }
        public DbSet<Character.Character> CharacterEntity { get; set; }
        public DbSet<Stat> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var gameEntityBuilder = modelBuilder.Entity<Game.Game>();
            gameEntityBuilder
                .HasOne(g => g.User);
            gameEntityBuilder
                .HasOne(g => g.Character)
                .WithOne(c => c.Game)
                .HasForeignKey<Character.Character>(g => g.GameId);

            var characterEntityBuilder = modelBuilder.Entity<Character.Character>();
            characterEntityBuilder
                .HasOne(c => c.Game)
                .WithOne(g => g.Character);
            characterEntityBuilder
                .HasMany(c => c.Stats)
                .WithOne(s => s.Character);

            modelBuilder.Entity<Stat>()
                .HasOne(s => s.Character)
                .WithMany(c => c.Stats);
        }
    }
}
