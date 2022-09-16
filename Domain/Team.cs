﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; } 
        public string TeamName { get; set; }
        public List<Employee> Employees { get; set; }
        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}