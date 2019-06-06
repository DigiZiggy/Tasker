using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.App.EF.Mappers.Identity;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppUserRepository : BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.Identity.AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new AppUserMapper())
        {
        }
    }
}