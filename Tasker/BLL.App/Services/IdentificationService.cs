using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class IdentificationService : BaseEntityService<BLL.App.DTO.Identification, DAL.App.DTO.Identification, IAppUnitOfWork>, IIdentificationService
    {
        public IdentificationService(IAppUnitOfWork uow) : base(uow, new IdentificationMapper())
        {
            ServiceRepository = Uow.Identifications;
        }

        public override async Task<BLL.App.DTO.Identification> FindAsync(params object[] id)
        {
            return IdentificationMapper.MapFromDAL(await Uow.Identifications.FindAsync(id));
        }
           
    }
}