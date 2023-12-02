using P06.Shared;
using P06.Shared.Services.ProductService;
using P06.Shared.Shop;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Product>>()
                {
                    Data = ProductSeeder.GenerateProductData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new  ServiceResponse<List<Product>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
           
        }
    }
}
