using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;

namespace DAL.App.EF.Repositories
{
    public class AppUserRepository : BaseRepositoryAsync<AppUser>, IAppUserRepository
    {
        public AppUserRepository(IDataContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}