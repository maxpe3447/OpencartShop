namespace OpencartShop.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public Customer? Customers { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

    }
}
