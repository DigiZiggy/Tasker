using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Payment
    {
        public int Id { get; set; }

        [Display(Name = nameof(MeansOfPayment), ResourceType = typeof(Resources.Domain.Payment))]
        public string MeansOfPayment { get; set; }
        
        [Display(Name = nameof(PaymentCode), ResourceType = typeof(Resources.Domain.Payment))]
        public int PaymentCode { get; set; }
        
        [Display(Name = nameof(TimeOfPayment), ResourceType = typeof(Resources.Domain.Payment))]
        public DateTime TimeOfPayment { get; set; }
        
        [Display(Name = nameof(Total), ResourceType = typeof(Resources.Domain.Payment))]
        public decimal Total { get; set; }
        
        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Payment))]
        public string Comment { get; set; }
        
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}