using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public sealed class DetailContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
        public DbSet<Storekeeper> Storekeepers { get; set; }

        public DetailContext(DbContextOptions<DetailContext> options) : base(options)
        {
             Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}