using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MeansOfPaymentRepository : BaseRepository<MeansOfPayment>, IMeansOfPaymentRepository
    {
        public MeansOfPaymentRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<MeansOfPayment>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();        
        }
    }
}