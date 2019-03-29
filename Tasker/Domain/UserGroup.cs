using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserGroup : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Name { get; set; }

//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}