using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TaskEditViewModel
    {
        public Task Task { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList TaskTypeSelectList { get; set; }
    }
}