using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PriceEditViewModel
    {
        public Price Price { get; set; }
        public SelectList PriceListSelectList { get; set; }
    }
}