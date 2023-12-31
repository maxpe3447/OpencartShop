﻿namespace OpencartShop.Domain.Entities
{
    public class ProductSize : IEntity
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public Product? Products { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Units { get; set; } = null!;
    }
}
