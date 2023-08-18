namespace OpencartShop.Domain.Entities
{
    public class Customers : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Users>? Users { get; set; }
        public List<FavoriteProducts>? FavoriteProducts { get; set; }
        public List<Carts>? Carts { get; set; }
        public List<Orders>? Orders { get; set; }
        public List<ReturnProducts>? ReturnProducts { get; set; }
    }
}
