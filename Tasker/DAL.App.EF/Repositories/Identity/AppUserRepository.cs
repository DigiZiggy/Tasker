using Contracts.DAL.App.Repositories.Identity;
using DAL.Base.EF.Repositories;
using Domain.Identity;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppUserRepository : BaseRepository<AppRole, AppDbContext>, IAppRoleRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}