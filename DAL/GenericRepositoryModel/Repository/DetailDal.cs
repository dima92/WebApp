using DAL.DAL_Core.Interfaces;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.GenericRepositoryModel.Interface;

namespace DAL.GenericRepositoryModel.Repository
{
    public class DetailDal : GenericRepository<Detail>, IDetailDal
    {
        public DetailDal(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}