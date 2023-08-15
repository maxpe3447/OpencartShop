using System.ComponentModel.DataAnnotations;

namespace OpencartShop.Domain.Entities
{
    public class ReturnProducts : IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public Orders? Orders { get; set; }
        public int Quantity { get; set; }
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
        [Required]
        public string? ProductTitle { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string? PhoneOrEmail { get; set; }
        public bool IsOpen { get; set; }
        [Required]
        public string? Reason { get; set; }
        public int? CustomersId { get; set; }
        public Customers? Customers { get; set; }
    }
}
