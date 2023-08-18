namespace OpencartShop.Domain.Entities
{
    public class OrderItems : IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public Orders? Orders { get; set;}
        public int Quantity { get; set; } = 1;
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
