namespace OpencartShop.Domain.Entities
{
    public class Products : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public decimal? PromotionPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public byte[]? Image { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
