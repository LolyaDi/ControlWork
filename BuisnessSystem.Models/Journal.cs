using BuisnessSystem.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BuisnessSystem.Models
{
    public class Journal: Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
