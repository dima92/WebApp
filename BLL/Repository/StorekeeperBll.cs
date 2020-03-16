using BLL.Interfaces;
using BLL.ModelDto;
using DAL.DAL_Core.Repository;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Repository
{
    public class StorekeeperBll : IStorekeeperBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        private readonly DalFactory _dalFactory;

        public StorekeeperBll(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<StorekeeperDto> GetAll()
        {
            List<StorekeeperDto> result = new List<StorekeeperDto>();
            var allStorekeepers = _context.Storekeepers.AsQueryable();
            foreach (var storekeeper in allStorekeepers)
            {
                result.Add(new StorekeeperDto
                {
                    Id = storekeeper.Id,
                    Name = storekeeper.Name,
                    SumKolDetail = storekeeper.SumKolDetail
                });
            }

            return result;

        }

        public Storekeeper Get(int id)
        {
            return _dalFactory.StorekeeperDal.GetById(id);
        }

        public List<StorekeeperDto> Add(StorekeeperDto storekeeper)
        {
            List<StorekeeperDto> result = new List<StorekeeperDto>();
            var stock = _context.Storekeepers.ToList();
            foreach (var item in stock)
            {
                result.Add(new StorekeeperDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    SumKolDetail = item.SumKolDetail
                });
            }

            return result;
        }

        public Storekeeper Delete(int storekeeperId)
        {
            Storekeeper storekeeperDetail = _context.Storekeepers.FirstOrDefault(x => x.Id == storekeeperId);
            if (storekeeperDetail == null)
            {
                Storekeeper storekeeperObj = _context.Storekeepers.First(f => f.Id == storekeeperId);
                _context.Storekeepers.Remove(storekeeperObj);
                _context.SaveChanges();
            }
            else
            {
                Detail detail = _context.Details.Where(p => p.Quantity > 0).FirstOrDefault(x => x.StorekeeperId == storekeeperId);
            }

            return storekeeperDetail;
        }
    }
}