using BuisnessSystem.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuisnessSystem.Models
{
    public class Publisher: Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string TelephoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        public List<Journal> Journals { get; set; }
    }
}
