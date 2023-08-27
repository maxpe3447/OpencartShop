namespace OpencartShop.Domain.Entities
{
    public class FavoriteProduct : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customers { get; set; }
    }
}
