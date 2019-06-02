using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserSkillRepository : IBaseRepositoryAsync<UserSkill>
    {
        Task<UserSkill> FindAllIncludedAsync(params object[] id);
        Task<List<UserSkill>> AllForUserAsync(int userId);
    }
}