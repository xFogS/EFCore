using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ChampionshipDB : DbContext
    {
        public ChampionshipDB() { /*Database.EnsureCreated(); Database.EnsureDeleted();*/ }
        public ChampionshipDB(DbContextOptions<ChampionshipDB> options) : base(options) { }
        public DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP;Initial Catalog=ChampionshipFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Team>().Property(x => x.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Team>().HasData(
            new Team()
            {
                Id = 1,
                Name = "Ukraine national football team",
                City = "Kyiv",
                Wins = 0,
                Loss = 0,
                Draw = 0,
            },
            new Team
            {
                Id = 2,
                Name = "Joma",
                City = "Portillo de Toledo",
                Wins = 0,
                Loss = 0,
                Draw = 0,
            });
            modelBuilder.Entity<Team>().Property(x => x.goalsScored).HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(x => x.goalsLosses).HasDefaultValue(0);
        }
    }
}
