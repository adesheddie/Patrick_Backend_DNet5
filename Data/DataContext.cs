
using Microsoft.EntityFrameworkCore;
using Patrick_Backend_DNet5.Models;
using Rpg_project.Models;

namespace Rpg_project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Characters> Characters { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }



        // below code is to add default entries
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Fireball", Points = 20 },
                new Skill { Id = 2, Name = "Frenzy", Points = 30 },
                new Skill { Id = 3, Name = "Blizzard", Points = 55 }
            );
        }

    }
}