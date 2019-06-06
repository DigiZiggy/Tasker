using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Identification = BLL.App.DTO.Identification;

namespace WebApp.ViewModels
{
    public class IdentificationCreateViewModel
    {
        public Identification Identification { get; set; }
        public SelectList AppUserSelectList { get; set; }
    }
}