using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TaskEditViewModel
    {
        public TaskerTask TaskerTask { get; set; }
        public SelectList AddressSelectList { get; set; }
    }
}