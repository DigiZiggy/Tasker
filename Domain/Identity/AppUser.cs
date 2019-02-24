using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        // add relationships and data fields you need
        public List<User> Users { get; set; }
   
    }
}