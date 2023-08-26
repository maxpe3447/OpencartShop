namespace OpencartShop.Domain.Entities
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
