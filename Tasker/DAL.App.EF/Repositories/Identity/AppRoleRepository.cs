using Contracts.DAL.App.Repositories.Identity;
using DAL.Base.EF.Repositories;
using Domain.Identity;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppRoleRepository : BaseRepository<AppRole, AppDbContext>, IAppRoleRepository
    {
        public AppRoleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}