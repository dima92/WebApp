using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.Repository
{
    public class StorekeeperBll : IStorekeeperBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        public IQueryable<Storekeeper> GetAll()
        {
            return _context.Storekeepers.AsQueryable();
        }

        public Storekeeper Get(int id)
        {
            return _context.Storekeepers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Storekeeper storekeeper)
        {
            _context.Storekeepers.Add(storekeeper);
            _context.SaveChanges();
        }

        public void Delete(int storekeeperId)
        {
            var storekeeper = _context.Storekeepers.FirstOrDefault(x => x.Id == storekeeperId);
            if (storekeeper == null) return;
            _context.Storekeepers.Remove(storekeeper);
            _context.SaveChanges();
        }
    }
}