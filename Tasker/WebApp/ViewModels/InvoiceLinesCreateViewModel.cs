using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class InvoiceLinesCreateViewModel
    {
        public InvoiceLine InvoiceLine { get; set; }
        public SelectList InvoiceSelectList { get; set; }
        public SelectList TaskSelectList { get; set; }
    }
}