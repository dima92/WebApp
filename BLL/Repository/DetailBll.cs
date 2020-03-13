using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Repository
{
    public class DetailBll : IDetailBll
    {
        private readonly DetailContext _context = new DetailContext(new DbContextOptions<DetailContext>());

        public IQueryable<Detail> GetAll()
        {
            return _context.Details.AsQueryable();
        }

        public Detail GetById(int detailId)
        {
            return _context.Details.FirstOrDefault(x => x.Id == detailId);
        }

        public IQueryable<Detail> GetByStorekeeperId(int storekeeperId)
        {
            return _context.Details.Where(x => x.Id == storekeeperId);
        }

        public void Add(Detail detail)
        {
            _context.Details.Add(detail);
            _context.SaveChanges();
        }

        public void Update(Detail detail)
        {
            _context.Entry(detail).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void MarkDeleted(int detailId)
        {
            var detail = _context.Details.FirstOrDefault(x => x.Id == detailId);
            if (detail == null) return;
            detail.DeleteDate = DateTime.Now;
            detail.Quantity = 0;
            Update(detail);
        }

        public void Delete(int storekeeperId)
        {
            //Detail storekeeperDetail = _context.Details.FirstOrDefault(x => x.StorekeeperId == storekeeperId);
            //if (storekeeperDetail == null)
            //{
            //    _context.Details.Remove(_context.Storekeepers.Where(p=> p.));
            //    _context.SaveChanges();
            //}

        }
    }
}