using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nombre Producto"; //can be null
        public string Description { get; set; } = "Descripción Producto";
        public float Price { get; set; } = 0;
        public string Image { get; set; } = "https://climate.onep.go.th/wp-content/uploads/2020/01/default-image-300x225.jpg"; // default image
        public Category Category { get; set; } = Category.Laptop;
    }
}