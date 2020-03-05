using System;
using Yerel.Core.Entities;

namespace Yerel.Entities
{
    public class Product : IEntity
    {
        public Product()
        {
        }
        public int Id { get; set; }
        public int Brand { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public Int16 Year { get; set; }
        public decimal Price { get; set; }
    }
}
