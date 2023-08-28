namespace OpencartShop.Domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public User? Users { get; set; }
        public List<FavoriteProduct>? FavoriteProducts { get; set; }
        public List<Cart>? Carts { get; set; }
        public List<Order>? Orders { get; set; }
        public List<ReturnProduct>? ReturnProducts { get; set; }
    }
}
