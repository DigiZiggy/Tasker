using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;


namespace BLL.App.DTO
{
    public class Invoice
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(InvoiceNumber), ResourceType = typeof(Resources.Domain.Invoice))]
        public int InvoiceNumber { get; set; }
        
        [Display(Name = nameof(Date), ResourceType = typeof(Resources.Domain.Invoice))]
        public DateTime Date { get; set; }
        
        [Display(Name = nameof(TotalWithVAT), ResourceType = typeof(Resources.Domain.Invoice))]
        public decimal TotalWithVAT { get; set; }
        
        [Display(Name = nameof(TotalWithoutVAT), ResourceType = typeof(Resources.Domain.Invoice))]
        public decimal TotalWithoutVAT { get; set; }
        
        [Display(Name = nameof(VAT), ResourceType = typeof(Resources.Domain.Invoice))]
        public decimal VAT { get; set; }
        
        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Invoice))]
        public string Comment { get; set; }
                
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}