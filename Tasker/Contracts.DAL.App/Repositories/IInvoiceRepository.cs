using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IInvoiceRepository : IBaseRepository<DALAppDTO.Invoice>
    {

    }
    
    public interface IInvoiceRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
    }
}