using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserEditViewModel
    {
        public User User { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList HourlyRateSelectList { get; set; }
        public SelectList UserTypeSelectList { get; set; }
    }
}