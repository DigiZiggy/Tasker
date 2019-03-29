using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class AddressCreateViewModel
    {
        public Address Address { get; set; }
        public SelectList CitySelectList { get; set; }
    }
}