using DAL.GenericRepositoryModel.Interface;

namespace DAL.DAL_Core.Interfaces
{
    public interface IDalFactory
    {
        IStorekeeperDal StorekeeperDal { get; }
        IDetailDal DetailDal { get; }
    }
}