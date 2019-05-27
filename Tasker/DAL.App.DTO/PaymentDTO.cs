using System;
using Domain;

namespace DAL.App.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public string MeansOfPayment { get; set; }
        
        public int PaymentCode { get; set; }
        
        public DateTime TimeOfPayment { get; set; }
        
        public decimal Total { get; set; }
        
        public string Comment { get; set; }
        
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}