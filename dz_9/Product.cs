using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_9
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string name, decimal price, string category, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
        }
    }
}
