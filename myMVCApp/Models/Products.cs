using System.Collections.Generic;

namespace myMVCApp.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<int>? CategoryIds { get; set; }

        public Products(int id, string name, string description, decimal price, List<int> categoryIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryIds = categoryIds;
        }
    }
}
