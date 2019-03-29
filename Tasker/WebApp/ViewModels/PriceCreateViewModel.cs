using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class PriceCreateViewModel
    {
        public Price Price { get; set; }
        public SelectList PriceListSelectList { get; set; }
    }
}