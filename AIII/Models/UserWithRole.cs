using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIII.Models
{
    public class UserWithRole
    {
        public string UserId { get; set; }

        [Display(Name = "User")]
        public string UserEmail { get; set; }
        [Display(Name = "Roles")]
        public IEnumerable<string> RolesNames { get; set; }
    }
}