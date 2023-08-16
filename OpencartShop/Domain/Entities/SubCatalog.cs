using System.ComponentModel.DataAnnotations.Schema;

namespace OpencartShop.Domain.Entities
{
    public class SubCatalog : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ParentCatalog { get; set; }

        [ForeignKey(nameof(ParentCatalog))]
        public Catalog? Catalog { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
