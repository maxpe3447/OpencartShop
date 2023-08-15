namespace OpencartShop.Domain.Entities
{
    public class FavoriteProducts : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products? Products { get; set; }
        public int CustomersId { get; set; }
        public Customers? Customers { get; set; }
    }
}
