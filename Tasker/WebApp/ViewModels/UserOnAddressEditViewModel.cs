using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserOnAddress = BLL.App.DTO.UserOnAddress;

namespace WebApp.ViewModels
{
    public class UserOnAddressEditViewModel
    {
        public UserOnAddress UserOnAddress { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList AddressSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}