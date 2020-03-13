using DAL.Entities;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IDetailBll
    {
        IQueryable<Detail> GetAll();
        Detail GetById(int detailId);
        IQueryable<Detail> GetByStorekeeperId(int storekeeperId);
        void Add(Detail detail);
        void Update(Detail detail);
        void MarkDeleted(int detailId);
        void Delete(int storekeeperId);
    }
}
