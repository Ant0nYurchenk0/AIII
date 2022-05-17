using System;
using System.ComponentModel.DataAnnotations;

namespace AIII.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Role { get; set; }

        [Display(Name ="General Info")]
        public string GeneralInfo { get; set; }
    }
}