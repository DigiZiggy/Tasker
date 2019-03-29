using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PaymentCreateViewModel
    {
        public Payment Payment { get; set; }
        public SelectList InvoiceSelectList { get; set; }
        public SelectList MeansOfPaymentSelectList { get; set; }
    }
}