using P06.Shared;
using P06.Shared.Shop;

namespace P06.Shared.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}
