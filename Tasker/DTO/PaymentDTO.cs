using System;

namespace DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public int PaymentCode { get; set; }
        
        public DateTime TimeOfPayment { get; set; }
        
        public decimal Total { get; set; }

        public string Comment { get; set; }

    }
}