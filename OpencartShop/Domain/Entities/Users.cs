namespace OpencartShop.Domain.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public Customers? Customers { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

    }
}
