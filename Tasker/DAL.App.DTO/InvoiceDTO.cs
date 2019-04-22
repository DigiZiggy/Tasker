using System;

namespace DAL.App.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        public int InvoiceNumber { get; set; }
        
        public DateTime Date { get; set; }

        public decimal TotalWithVAT { get; set; }
        
        public decimal TotalWithoutVAT { get; set; }
        
        public decimal VAT { get; set; }
        
        public string Comment { get; set; }

    }
}