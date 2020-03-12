using DAL.Entities;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IStorekeeperBll
    {
        IQueryable<Storekeeper> GetAll();
        Storekeeper Get(int id);
        void Add(Storekeeper storekeeper);
        void Delete(int storekeeperId);
    }
}
