using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserInGroup : BaseEntity
    {
//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}