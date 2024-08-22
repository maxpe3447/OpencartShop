namespace Api.Storage.Entities
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Quantity { get; set; } = 1;
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    }
}
