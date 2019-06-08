using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain
{
    public class Translation  : BaseEntity
    {
        [MaxLength(5)] // et-EE
        public string Culture { get; set; }
        
        [MaxLength(10240)]
        public string Value { get; set; }


        public int MultiLangStringId { get; set; }
        public MultiLangString MultiLangString { get; set; }
    }
}
