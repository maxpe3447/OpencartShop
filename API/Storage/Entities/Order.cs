namespace Api.Storage.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
        public decimal? Discount { get; set; }
        public bool IsCancel { get; set; } = false;
        public List<OrderItem>? OrderItems { get; set; }
    }
}
