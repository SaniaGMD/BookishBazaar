using System.Collections.Generic;

namespace myMVCApp.Models
{
    
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<string>? CategoryIds { get; set; }

        public Products()
        {
            // Parameterless constructor
        }
        public Products(int id, string name, string description, decimal price, List<string> categoryIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryIds = categoryIds;
        }
    }
}
