namespace OpencartShop.Domain.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int? CustomersId { get; set; }
        public Customer? Customers { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    }
}
