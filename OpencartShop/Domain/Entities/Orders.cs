namespace OpencartShop.Domain.Entities
{
    public class Orders : IEntity
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public Customers? Customers { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
        public decimal? Discount { get; set; }
        public List<OrderItems>? OrderItems { get; set; }
    }
}
