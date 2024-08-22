namespace Api.Storage.Entities
{
    public class FavoriteProduct
    {
        public int ProductId { get; set; }
        public Product? Products { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
