using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Payment = BLL.App.DTO.Payment;

namespace WebApp.ViewModels
{
    public class PaymentCreateViewModel
    {
        public Payment Payment { get; set; }
        public SelectList InvoiceSelectList { get; set; }
    }
}