using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserInGroupCreateViewModel
    {
        public UserInGroup UserInGroup { get; set; }
        public SelectList UserGroupSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}