using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class IdentificationTypeRepository : BaseRepository<IdentificationType>, IIdentificationTypeRepository
    {
        public IdentificationTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<IdentificationType>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();
        }
    }
}