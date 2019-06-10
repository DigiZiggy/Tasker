using System.Threading.Tasks;

namespace ee.itcollege.sigrid.narep.Contracts.DAL.Base
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}

