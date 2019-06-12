using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Review = BLL.App.DTO.Review;

namespace WebApp.ViewModels
{
    public class ReviewEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Review Review { get; set; }   
        
        /// <summary>
        /// 
        /// </summary>
        public SelectList ReviewGiverSelectList { get; set; }       
        
        /// <summary>
        ///
        /// </summary>
        public SelectList ReviewReceiverSelectList { get; set; }    }
}