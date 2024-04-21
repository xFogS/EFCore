using EFCore._1_Work;
using EFCore.Main;
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
        public List<TournamentTable> TournamentTables { get; set; } = [];
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public IQueryable<Team> GetTeams(string city)
        {
            return FromExpression(() => GetTeams(city));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP;Initial Catalog=ChampionshipFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Team>().Property(x => x.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Player>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Player>().Property(x => x.Position).IsRequired().HasMaxLength(50);
            modelBuilder.HasDbFunction(() => GetTeams(default!));
        }
    }
}
