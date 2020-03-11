using DAL.EF;

namespace DAL.DAL_Core.Interfaces
{
    public interface IDbFactory
    {
        DetailContext Init();
    }
}