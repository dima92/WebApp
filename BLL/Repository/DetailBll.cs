using BLL.Interfaces;
using BLL.ModelDto;
using DAL.DAL_Core.Repository;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Repository
{
    public class DetailBll : IDetailBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());
        private DalFactory dalFactory;

        public DetailBll(DalFactory dalFactory)
        {
            this.dalFactory = dalFactory;
        }

        public List<DetailDto> GetAll()
        {
            List<DetailDto> result = new List<DetailDto>();
            var allDetails = _context.Details.ToList();
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
                    //NameStorekeeper = detail.Storekeeper.Name
                });
            }

            return result;
        }

        public Detail GetById(int detailId)
        {
            return dalFactory.DetailDal.GetById(detailId);
        }

        public IQueryable<Detail> GetByStorekeeperId(int storekeeperId)
        {
            return _context.Details.Where(x => x.Id == storekeeperId);
        }

        public List<DetailDto> Add(DetailDto detail)
        {
            List<DetailDto> result = new List<DetailDto>();
            var det = _context.Details.ToList();
            foreach (var item in det)
            {
                result.Add(new DetailDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    NomenclatureCode = item.NomenclatureCode,
                    SpecAccount = item.SpecAccount,
                    NameStorekeeper = item.Storekeeper.Name,
                    Created = item.Created,
                    DeleteDate = item.DeleteDate
                });
            }

            return result;
        }

        public void Update( Detail detail)
        {
            _context.Details.Update(detail);
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
            _context.Remove(detail);
            _context.SaveChanges();
        }
    }
}