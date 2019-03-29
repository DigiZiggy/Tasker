using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class CityEditViewModel
    {
        public City City { get; set; }
        public SelectList CountrySelectList { get; set; }
    }
}