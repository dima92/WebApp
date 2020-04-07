using BLL.ModelDto;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IDetailBll
    {
        List<DetailDto> GetAll();
        Detail GetById(int detailId);
        IQueryable<Detail> GetByStorekeeperId(int storekeeperId);
        void Add(DetailDto detail);
        void Update(DetailDto detail);
        void MarkDeleted(int detailId);
        void Delete(int detailId);
    }
}
