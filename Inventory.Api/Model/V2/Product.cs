namespace Inventory.Api.Model.V2
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal MaxRetailPrice { get; set; }
        public string? Description { get; set; }

        public List<Order> Orders { get; set; }
    }
}
