using System;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;

namespace Domain
{
    public class Payment : DomainEntity
    {
        public string MeansOfPayment { get; set; }
        
//        [Required]
        public int PaymentCode { get; set; }
        
//        [Required]
        public DateTime TimeOfPayment { get; set; }
        
//        [Required]
        public decimal Total { get; set; }
        public string Comment { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}