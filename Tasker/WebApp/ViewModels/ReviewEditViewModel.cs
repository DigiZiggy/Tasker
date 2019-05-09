using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ReviewEditViewModel
    {
        public Review Review { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}