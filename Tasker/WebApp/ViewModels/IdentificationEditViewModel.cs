using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class IdentificationEditViewModel
    {
        public Identification Identification { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}