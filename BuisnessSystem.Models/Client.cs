using BuisnessSystem.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuisnessSystem.Models
{
    public class Client: Entity
    {
        [Required]
        [MaxLength(150)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(15)]
        public string TelephoneNumber { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
    }
}
