using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class IdentificationTypeRepository : BaseRepositoryAsync<IdentificationType>, IIdentificationTypeRepository
    {
        public IdentificationTypeRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<IdentificationType>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();
        }
    }
}