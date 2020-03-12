namespace BLL.Interfaces
{
    public interface IBllFactory
    {
        IDetailBll DetailBll { get; }
        IStorekeeperBll StorekeeperBll { get; }
    }
}
