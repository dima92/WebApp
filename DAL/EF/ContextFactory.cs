using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.EF
{
    public class ContextFactory : IDesignTimeDbContextFactory<DetailContext>
    {
        public DetailContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DetailContext>();
            optionsBuilder.UseSqlServer("Data Source=detaildb.db");
            return new DetailContext(optionsBuilder.Options);
        }
    }
}
