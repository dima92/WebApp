using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class DetailContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
        public DbSet<Storekeeper> Storekeepers { get; set; }

        public DetailContext(DbContextOptions<DetailContext> options) : base(options)
        {
        }
    }
}
