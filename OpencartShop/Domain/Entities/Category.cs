namespace OpencartShop.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int SubcategoryId { get; set; }
        public SubCatalog? Subcatalog { get; set; }
    }
}
