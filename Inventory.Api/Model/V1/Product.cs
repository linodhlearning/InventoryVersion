namespace Inventory.Api.Model.V1
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
