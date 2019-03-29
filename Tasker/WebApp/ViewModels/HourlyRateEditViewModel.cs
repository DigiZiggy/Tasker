using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class HourlyRateEditViewModel
    {
        public HourlyRate HourlyRate { get; set; }
        public SelectList PriceListSelectList { get; set; }
    }
}