using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IIdentificationRepository : IIdentificationRepository<DALAppDTO.Identification>
    {

    }
    
    public interface IIdentificationRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        Task<TDALEntity> FindAllIncludedAsync(params object[] id);      
        Task<TDALEntity> FindForUserAsync(int id, int userId);

    }
}