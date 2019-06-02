using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class IdentificationService : BaseEntityService<Identification, IAppUnitOfWork>, IIdentificationService
    {
        public IdentificationService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<Identification> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.Identifications.FindAllIncludedAsync(id);
        }
               
        public async Task<List<Identification>> AllForUserAsync(int userId)
        {
            return await Uow.Identifications.AllForUserAsync(userId);
        }
    }
}