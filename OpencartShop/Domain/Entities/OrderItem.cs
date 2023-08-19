namespace OpencartShop.Domain.Entities
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public Order? Orders { get; set;}
        public int Quantity { get; set; } = 1;
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
