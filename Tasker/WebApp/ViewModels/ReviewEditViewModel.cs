using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ReviewEditViewModel
    {
        public Review Review { get; set; }        
        public SelectList ReviewGiverSelectList { get; set; }        
        public SelectList ReviewReceiverSelectList { get; set; }    }
}