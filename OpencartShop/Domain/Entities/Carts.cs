namespace OpencartShop.Domain.Entities
{
    public class Carts : IEntity
    {
        public int Id { get; set; }
        public int? CustomersId { get; set; }
        public Customers? Customers { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    }
}
