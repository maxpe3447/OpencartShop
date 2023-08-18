namespace OpencartShop.Domain.Entities
{
    public class Catalog : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public List<SubCatalog>? SubCatalogs { get; set; }
    }
}
