namespace OpencartShop.Domain.Entities
{
    public class ProductColor : IEntity
    {
        public int Id { get; set; }
        public int ColorsId { get; set; }
        public Color? Color { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
