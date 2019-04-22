using System;

namespace DAL.App.DTO
{
    public class UserSkillDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public string Comment { get; set; }

    }
}