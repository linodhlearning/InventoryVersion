using Inventory.Api.Model.V1;

namespace Inventory.Api.Services.V1
{
    public interface IProductService
    {
        public List<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "X Mouse",
                Price = 10.22m
            },
            new Product()
            {
                Id = 2,
                Name = "X Headphone",
                Price = 659.99m
            },
            new Product()
            {
                Id = 3,
                Name = "X Keyboard",
                Price = 139.99m
            }
        };
        }
    }
}
