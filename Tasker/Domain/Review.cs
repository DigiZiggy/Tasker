using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class Review : BaseEntity, IDomainEntity
    {
//        [Required]
        public int Rating { get; set; }
        
        [ForeignKey(nameof(ReviewComment))]
        public int ReviewCommentId { get; set; }
        public MultiLangString ReviewComment { get; set; }

              
        public int ReviewGiverId { get; set; } 
        public AppUser ReviewGiver { get; set; }        
        
        public int ReviewReceiverId { get; set; }
        public AppUser ReviewReceiver { get; set; }  
    }
}