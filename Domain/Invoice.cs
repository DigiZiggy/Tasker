using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Invoice : BaseEntity
    {
        [Required]
        public int InvoiceNumber { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        public decimal TotalWithVAT { get; set; }
        public decimal TotalWithoutVAT { get; set; }
        public decimal VAT { get; set; }
        public string Comment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}