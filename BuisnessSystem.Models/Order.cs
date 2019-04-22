using BuisnessSystem.Models.Abstract;

namespace BuisnessSystem.Models
{
    public class Order: Entity
    {
        public Client Client { get; set; }

        public Journal Journal { get; set; }

        public bool IsDelivered { get; set; }
    }
}
