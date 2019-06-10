
using ee.itcollege.sigrid.narep.Contracts.DAL.Base;

namespace Domain
{
    public abstract class DomainEntity : IDomainEntity
    {
        public int Id { get; set; } // Primary Key for every entity type  
    }
}