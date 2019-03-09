using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;

namespace Domain
{
    public class Review : BaseEntity
    {
        [Required]
        public int Rating { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Comment { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}