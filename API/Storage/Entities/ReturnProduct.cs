using System.ComponentModel.DataAnnotations;

namespace Api.Storage.Entities
{
    public class ReturnProduct : IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public Order? Orders { get; set; }
        public int Quantity { get; set; }
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
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
        public bool IsActive { get; set; } = true;
        [Required]
        public string? Reason { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
