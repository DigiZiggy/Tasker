using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class Invoice : BaseEntity, IDomainEntity
    {
//        [Required]
        public int InvoiceNumber { get; set; }
        
//        [Required]
        public DateTime Date { get; set; }
        
//        [Required]
        public decimal TotalWithVAT { get; set; }
        
//        [Required]
        public decimal TotalWithoutVAT { get; set; }
        
//        [Required]
        public decimal VAT { get; set; }
        
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public MultiLangString Comment { get; set; }
 
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public ICollection<Payment> Payments { get; set; }

    }
}