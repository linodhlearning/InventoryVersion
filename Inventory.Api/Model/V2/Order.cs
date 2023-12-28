namespace Inventory.Api.Model.V2
{
    public class Order
    {
        public Guid Id { get; set; }
        public required string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public Statuses Status { get; set; }
    }

    public enum Statuses
    {
        None = 0,
        Pending = 1,
        AwaitingPayment = 2,
        Completed = 3
    }
}
