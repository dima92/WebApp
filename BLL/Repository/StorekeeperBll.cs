using System.Collections.Generic;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using BLL.ModelDto;

namespace BLL.Repository
{
    public class StorekeeperBll : IStorekeeperBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        public List<StorekeeperDto> GetAll()
        {
            List<StorekeeperDto> result = new List<StorekeeperDto>();
            var allstorekeepers = _context.Storekeepers.AsQueryable();
            foreach (var storekeeper in allstorekeepers)
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
            return _context.Storekeepers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(StorekeeperDto storekeeper)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Storekeeper storekeeper)
        {
            _context.Storekeepers.Add(storekeeper);
            _context.SaveChanges();
        }

        public bool Delete(int storekeeperId)
        {

            Detail storekeeperDetail = _context.Details.FirstOrDefault(x => x.StorekeeperId == storekeeperId);
            //если за кладовщиком не числятся детали
            if (storekeeperDetail == null)
            {
                Storekeeper storerkeperObj = _context.Storekeepers.First(f => f.Id == storekeeperId);
                _context.Storekeepers.Remove(storerkeperObj);
                _context.SaveChanges();
            }
            else
            { // за кладовщиком числется детали

            }

            return false;
        }
    }
}