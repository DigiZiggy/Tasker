using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserTaskRepository : BaseRepository<DAL.App.DTO.UserTask, Domain.UserTask, AppDbContext>, IUserTaskRepository
    {
        public UserTaskRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new UserTaskMapper())
        {
        }
               
        public override async Task<List<DAL.App.DTO.UserTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .Select(e => UserTaskMapper.MapFromDomain(e)).ToListAsync(); 
        }
    }
}