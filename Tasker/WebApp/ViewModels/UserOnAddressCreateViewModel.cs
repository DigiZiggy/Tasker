using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserOnAddressCreateViewModel
    {
        public UserOnAddress UserOnAddress { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList AddressSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}