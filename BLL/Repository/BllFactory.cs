using AutoMapper;
using BLL.Interfaces;
using DAL.DAL_Core.Repository;

namespace BLL.Repository
{
    public class BllFactory : IBllFactory
    {
        private readonly DalFactory _dalFactory;
        private readonly IMapper _mapper;
        private IStorekeeperBll _storekeeperBll;
        private IDetailBll _detailBll;
        public BllFactory(IMapper mapper)
        {
            _mapper = mapper;
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IStorekeeperBll StorekeeperBll => _storekeeperBll ??= new StorekeeperBll(_dalFactory, _mapper);
        public IDetailBll DetailBll => _detailBll ??= new DetailBll(_dalFactory, _mapper);
    }
}
