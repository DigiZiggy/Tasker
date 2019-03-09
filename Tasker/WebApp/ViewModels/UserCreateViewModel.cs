using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserCreateViewModel
    {
        public User User { get; set; }
        public SelectList HourlyRateSelectList { get; set; }
        public SelectList UserTypeSelectList { get; set; }
    }
}