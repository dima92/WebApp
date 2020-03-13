using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class DetailContext : DbContext
    {
       

        public DetailContext(DbContextOptions<DetailContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Storekeeper> Storekeepers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
