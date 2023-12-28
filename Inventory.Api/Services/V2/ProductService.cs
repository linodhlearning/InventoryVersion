using Inventory.Api.Model.V2;

namespace Inventory.Api.Services.V2
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
                Name = "Y Mouse",
                MaxRetailPrice = 51.25m,
                Description="Y Mouse has better features",
                Orders=GetOrders(2,"200")
            },
            new Product()
            {
                Id = 2,
                Name = "Y Headphone",
                MaxRetailPrice = 189.99m,
                Description="Y Headphone is best in the market",
                  Orders=GetOrders(3,"300")
            },
            new Product()
            {
                Id = 3,
                Name = "Y Keyboard",
                MaxRetailPrice = 319.99m,
             Description="Y keyboard has some shining marketing around it to make gullable customers fall pray",
               Orders=GetOrders(1,"400")
            }
        };
        }

        private List<Order> GetOrders(int recordCount, string orderPrefix = "1001")
        {
            int count = 0; var list = new List<Order>();
            while (count < recordCount)
            {
                list.Add(new Order()
                {
                    Id = Guid.NewGuid(),
                    OrderNo = $"{orderPrefix}{count}",
                    OrderDate = DateTime.Today.AddDays(-count),
                    Status = GetStatus(count)
                });
                count++;
            }
            return list;
        }

        private Statuses GetStatus(int count)
        {
            var values = Enum.GetValues(typeof(Statuses));
            if (values == null) return Statuses.None;
            if (count < values.Length) return (Statuses)count;

            Random random = new Random();
            var status = values.GetValue(random.Next(values.Length)) as Statuses?;
            return status.HasValue ? status.Value : Statuses.None;
        }
    }
}
