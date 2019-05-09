using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class IdentificationCreateViewModel
    {
        public Identification Identification { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}