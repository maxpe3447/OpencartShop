namespace OpencartShop.Domain.Entities
{
    public class CustomerReviews : IEntity
    {
        public int Id { get; set; }
        public int? CustomersId { get; set; }
        public Customers? Customers { get; set; }
        public int StarCount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
    }
}
