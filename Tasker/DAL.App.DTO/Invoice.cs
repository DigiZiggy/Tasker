using System;
using System.Collections.Generic;
using DAL.App.DTO.Identity;


namespace DAL.App.DTO
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
        
        public ICollection<Payment> Payments { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}