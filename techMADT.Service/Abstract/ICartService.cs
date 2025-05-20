using techMADT2.Core.Entities;

namespace techMADT2.Service.Abstract
{
    public interface ICartService
    {
        void AddProduct(Product product, int quantity);
        void UpdateProduct(Product product, int quantity);
        void RemoveProduct(Product product, int quantity);
        decimal TotalPrice();
        void ClearAll();
    }
}
