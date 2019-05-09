using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class Invoice : BaseEntity
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
        public string Comment { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public ICollection<Payment> Payments { get; set; }

    }
}