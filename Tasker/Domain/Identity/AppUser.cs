using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        // add relationships and data fields you need
        public ICollection<User> Users { get; set; }
   
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string LastName { get; set; }

    }
}