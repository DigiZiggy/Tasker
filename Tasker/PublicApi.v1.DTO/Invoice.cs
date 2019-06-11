using System;
using System.Collections.Generic;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Invoice
    {
        public int Id { get; set; }
        
        public int InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalWithVAT { get; set; }
        public decimal TotalWithoutVAT { get; set; }
        public decimal VAT { get; set; }       
        public string Comment { get; set; } 
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}