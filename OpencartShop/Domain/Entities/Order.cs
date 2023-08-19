namespace OpencartShop.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public Customer? Customers { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
        public decimal? Discount { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
