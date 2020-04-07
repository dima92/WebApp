using System;
using BLL.Interfaces;
using BLL.ModelDto;
using DAL.DAL_Core.Repository;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Infrastructure;

namespace BLL.Repository
{
    public class StorekeeperBll : IStorekeeperBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;

        public StorekeeperBll(DalFactory dalFactory, IMapper mapper)
        {
            _dalFactory = dalFactory;
            _mapper = mapper;
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
            _dalFactory.StorekeeperDal.Add(new Storekeeper

            {
                Name = storekeeper.Name
            });

            return null;
        }

        public void Update(List<StorekeeperDto> data)
        {
            foreach (StorekeeperDto storekeeper in data)
            {
                Storekeeper result = _mapper.Map<Storekeeper>(storekeeper);
                _dalFactory.StorekeeperDal.UpdateVoid(result, result.Id);
            }
        }

        public void Delete(int storekeeperId)
        {
            Storekeeper storekeeperDetail = _context.Storekeepers.FirstOrDefault(x => x.Id == storekeeperId);

            if (_context.Details.Any(a => a.StorekeeperId == storekeeperId))
            {
                throw new ValidationException("Нельзя удалить кладовщика, за которым числятся детали");
            }
            else
            {
                _context.Storekeepers.Remove(storekeeperDetail ?? throw new InvalidOperationException());
                _context.SaveChanges();
            }
        }
    }
}