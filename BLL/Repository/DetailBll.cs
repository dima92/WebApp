using BLL.Interfaces;
using BLL.ModelDto;
using DAL.DAL_Core.Repository;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BLL.Repository
{
    public class DetailBll : IDetailBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;

        public DetailBll(DalFactory dalFactory, IMapper mapper)
        {
            _dalFactory = dalFactory;
            _mapper = mapper;
        }

        public List<DetailDto> GetAll()
        {
            var result = new List<DetailDto>();
            var allDetails = _context.Details.Include(st => st.Storekeeper).ToList();
            foreach (var detail in allDetails)
            {
                result.Add(new DetailDto
                {
                    Id = detail.Id,
                    Created = detail.Created,
                    DeleteDate = detail.DeleteDate,
                    Name = detail.Name,
                    NomenclatureCode = detail.NomenclatureCode,
                    Quantity = detail.Quantity,
                    SpecAccount = detail.SpecAccount,
                    NameStorekeeper = detail.Storekeeper.Name,
                    StorekeeperId = detail.StorekeeperId,
                    Storekeeper = detail.Storekeeper.Name
                });
            }

            return result;
        }

        public Detail GetById(int detailId)
        {
            return _dalFactory.DetailDal.GetById(detailId);
        }

        public IQueryable<Detail> GetByStorekeeperId(int storekeeperId)
        {
            return _context.Details.Where(x => x.Id == storekeeperId);
        }

        public List<DetailDto> Add(DetailDto detail)
        {
            _dalFactory.DetailDal.Add(new Detail
            {
                Id = detail.Id,
                Name = detail.Name,
                Quantity = detail.Quantity,
                NomenclatureCode = detail.NomenclatureCode,
                SpecAccount = detail.SpecAccount,
                Created = detail.Created,
                DeleteDate = detail.DeleteDate,
                StorekeeperId = detail.StorekeeperId
            });

            return null;
        }

        public void Update(List<DetailDto> data)
        {
            foreach (DetailDto detail in data)
            {
                Detail result = _mapper.Map<Detail>(detail);
                result.Created = DateTime.Now;
                result.DeleteDate = null;
                _dalFactory.DetailDal.UpdateVoid(result, result.Id);
            }
        }

        public void MarkDeleted(int detailId)
        {
            var detail = _context.Details.FirstOrDefault(x => x.Id == detailId);
            if (detail == null) return;
            detail.DeleteDate = DateTime.Now;
            detail.Quantity = 0;
        }

        public void Delete(int detailId)
        {
            var detail = _context.Details.FirstOrDefault(x => x.Id == detailId);
            _context.Remove(detail ?? throw new InvalidOperationException());
            _context.SaveChanges();
        }
    }
}