using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserRepository : IBaseRepositoryAsync<User>
    {
        Task<IEnumerable<User>> AllAsync(int userId);

    }
}