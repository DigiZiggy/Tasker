using System.Threading.Tasks;

namespace Contracts.DAL.Base
{
    //dummy for dependency injection
    public interface IDataContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
