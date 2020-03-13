using System.Collections.Generic;
using DAL.Entities;
using System.Linq;
using BLL.ModelDto;

namespace BLL.Interfaces
{
    public interface IStorekeeperBll
    {
        List<StorekeeperDto> GetAll();
        Storekeeper Get(int id);
        void Add(StorekeeperDto storekeeper);
        bool Delete(int storekeeperId);
    }
}
