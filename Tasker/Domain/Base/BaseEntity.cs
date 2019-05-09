using Contracts.DAL.Base;

namespace Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }

}