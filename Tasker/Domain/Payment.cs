using System;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Base;

namespace Domain
{
    public class Payment : BaseEntity, IDomainEntity
    {

        [ForeignKey(nameof(MeansOfPayment))]
        public int MeansOfPaymentId { get; set; }
        public MultiLangString MeansOfPayment { get; set; }
        
//        [Required]
        public int PaymentCode { get; set; }
        
//        [Required]
        public DateTime TimeOfPayment { get; set; }
        
//        [Required]
        public decimal Total { get; set; }
        
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public MultiLangString Comment { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}