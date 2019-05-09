using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class InvoiceCreateViewModel
    {
        public Invoice Invoice { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}