using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserSkillEditViewModel
    {
        public UserSkill UserSkill { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList SkillSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
    }
}