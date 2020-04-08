using System.Collections.Generic;
using DAL.Entities;
using BLL.ModelDto;

namespace BLL.Interfaces
{
    public interface IStorekeeperBll
    {
        List<StorekeeperDto> GetAll();
        Storekeeper Get(int id);
        void Add(StorekeeperDto storekeeper);
        void Update(StorekeeperDto storekeeper);
        void Delete(int storekeeperId);
    }
}
