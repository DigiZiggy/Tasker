using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Invoice = BLL.App.DTO.Invoice;

namespace WebApp.ViewModels
{
    public class InvoiceCreateViewModel
    {
        public Invoice Invoice { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}