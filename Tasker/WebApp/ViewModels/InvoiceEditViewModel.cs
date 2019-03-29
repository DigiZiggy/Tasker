using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class InvoiceEditViewModel
    {
        public Invoice Invoice { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}