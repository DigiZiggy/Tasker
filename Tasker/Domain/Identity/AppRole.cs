using ee.itcollege.sigrid.narep.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppRole  :  IdentityRole<int>, IDomainEntity
    {
        
    }
}