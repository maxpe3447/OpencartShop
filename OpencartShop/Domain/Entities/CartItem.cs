using System.ComponentModel.DataAnnotations;

namespace OpencartShop.Domain.Entities
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int CartsId { get; set; }
        public Carts? Carts { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
