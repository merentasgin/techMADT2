using techMADT2.Core.Entities;

namespace techMADT2.Models
{
    public class CartViewModel
    {
        public List<CartLine>? CartLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
