using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain
{
    public class Invoice : DomainEntity
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
        
        public List<Payment> Payments { get; set; }

    }
}