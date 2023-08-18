namespace OpencartShop.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int SubcategoryId { get; set; }
        public string Title { get; set; } = null!;
        public SubCatalog? SubCatalogs { get; set; }
    }
}
