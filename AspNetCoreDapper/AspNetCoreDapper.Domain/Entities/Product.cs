using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDapper.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
