using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Payment : BaseEntity
    {
//        [Required]
        public int PaymentCode { get; set; }
        
//        [Required]
        public DateTime TimeOfPayment { get; set; }
        
//        [Required]
        public decimal Total { get; set; }
        public string Comment { get; set; }

        public int MeansOfPaymentId { get; set; }
        public MeansOfPayment MeansOfPayment { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}