using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class HourlyRateCreateViewModel
    {
        public HourlyRate HourlyRate { get; set; }
        public SelectList PriceListSelectList { get; set; }
    }
}