namespace OpencartShop.Domain.Entities
{
    public class Colors : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
