using DAL.DAL_Core.Interfaces;
using DAL.EF;
using DAL.GenericRepositoryModel.Interface;
using DAL.GenericRepositoryModel.Repository;

namespace DAL.DAL_Core.Repository
{
    public class DalFactory : IDalFactory
    {
        private IStorekeeperDal _storekeeperDal;
        private IDetailDal _detailDal;

        private DetailContext _dbContext;
        private readonly IDbFactory _dbFactory;

        public DalFactory(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public DetailContext DbContext => _dbContext ??= _dbFactory.Init();

        public IStorekeeperDal StorekeeperDal => _storekeeperDal ??= new StorekeeperDal(_dbFactory);
        public IDetailDal DetailDal => _detailDal ??= new DetailDal(_dbFactory);
    }
}