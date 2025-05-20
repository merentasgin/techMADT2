using techMADT2.Core.Entities;

namespace techMADT2.Models
{
    public class CheckOutViewModel
    {
        public List<CartLine>? CartProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
