namespace OpencartShop.Domain.Entities
{
    public class DeliveryMethod : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
