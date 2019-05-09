using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PaymentEditViewModel
    {
        public Payment Payment { get; set; }
        public SelectList InvoiceSelectList { get; set; }
    }
}