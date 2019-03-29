using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class InvoiceLine : BaseEntity
    {
//        [Required]
        public decimal Price { get; set; }
        
//        [Required]
        public int Amount { get; set; }
        public decimal VATpercentage { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalWithoutVAT { get; set; }
        
//        [Required]
        public decimal Total { get; set; }
        public string Comment { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}