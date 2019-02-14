using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDapper.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
