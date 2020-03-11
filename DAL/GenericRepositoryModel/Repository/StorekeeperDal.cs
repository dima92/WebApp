using DAL.DAL_Core.Interfaces;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.GenericRepositoryModel.Interface;

namespace DAL.GenericRepositoryModel.Repository
{
    public class StorekeeperDal : GenericRepository<Storekeeper>, IStorekeeperDal
    {
        public StorekeeperDal(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}