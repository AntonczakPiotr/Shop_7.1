﻿using System.Collections.Generic;

namespace Shop.Models
{
    public class Category : IEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}