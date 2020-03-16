using System.Collections.Generic;
using DAL.Entities;
using BLL.ModelDto;

namespace BLL.Interfaces
{
    public interface IStorekeeperBll
    {
        List<StorekeeperDto> GetAll();
        Storekeeper Get(int id);
        List<StorekeeperDto> Add(StorekeeperDto storekeeper);
        Storekeeper Delete(int storekeeperId);
    }
}
