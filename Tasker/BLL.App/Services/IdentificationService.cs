using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class IdentificationService : BaseEntityService<BLL.App.DTO.Identification, DAL.App.DTO.Identification, IAppUnitOfWork>, IIdentificationService
    {
        public IdentificationService(IAppUnitOfWork uow) : base(uow, new IdentificationMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Identification, Domain.Identification>();
        }

        public async Task<BLL.App.DTO.Identification> FindAllIncludedAsync(params object[] id)
        {
            return IdentificationMapper.MapFromDAL(await Uow.Identifications.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.Identification> FindForUserAsync(int id, int userId)
        {
            return IdentificationMapper.MapFromDAL(await Uow.Identifications.FindForUserAsync(id, userId));
        }
               
        public async Task<List<BLL.App.DTO.Identification>> AllForUserAsync(int userId)
        {
            return (await Uow.Identifications.AllForUserAsync(userId)).Select(e => IdentificationMapper.MapFromDAL(e)).ToList();
        }
    }
}