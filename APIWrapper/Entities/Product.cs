using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWrapper
{
    public class Product : BaseEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public bool? isAvailable { get; set; }
        public int? UnitsInStock { get; set; }
        public string Category { get; set; }
        public int? ShelfLife { get; set; } //in days
        //many more such properties
    }
}