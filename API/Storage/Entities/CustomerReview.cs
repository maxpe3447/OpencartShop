namespace Api.Storage.Entities
{
    public class CustomerReview : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int StarCount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
    }
}
