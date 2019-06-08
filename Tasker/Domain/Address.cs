using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Base;

namespace Domain
{
    public class Address : BaseEntity, IDomainEntity
    {

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public MultiLangString Country { get; set; }
        
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public MultiLangString City { get; set; }
        
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Street { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string HouseNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string UnitNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string PostalCode { get; set; }
        
        public ICollection<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public ICollection<TaskerTask> TasksOnAddress { get; set; }
        
    }
}