using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ReviewCreateViewModel
    {
        public Review Review { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList TaskSelectList { get; set; }
    }
}