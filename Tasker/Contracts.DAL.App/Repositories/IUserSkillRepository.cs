using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserSkillRepository : IBaseRepositoryAsync<UserSkill, int>
    {
        Task<UserSkill> FindAllIncludedAsync(params object[] id);      
    }
}