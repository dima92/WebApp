using DAL.Entities;
using System.Linq;
using BLL.ModelDto;

namespace BLL.Interfaces
{
    public interface IStorekeeperBll
    {
        IQueryable<Storekeeper> GetAll();
        Storekeeper Get(int id);
        void Add(StorekeeperDto storekeeper);
        void Delete(int storekeeperId);
    }
}
