namespace OpencartShop.Domain.Entities
{
    public class ProductColors : IEntity
    {
        public int Id { get; set; }
        public int ColorsId { get; set; }
        public Colors? Color { get; set; }

        public int ProductsId { get; set; }
        public Products? Products { get; set; }

    }
}
