using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskerTask = BLL.App.DTO.TaskerTask;

namespace WebApp.ViewModels
{
    public class TaskCreateViewModel
    {
        public TaskerTask TaskerTask { get; set; }
        public SelectList AddressSelectList { get; set; }
    }
}