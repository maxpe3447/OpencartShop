using System.ComponentModel.DataAnnotations;

namespace Api.Storage.Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public string? Area { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? AddressString { get; set; }

        public int PostOfficeNumber { get; set; }

        public int DeliveryMethodId { get; set; }
        public DeliveryMethod? DeliveryMethods { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
