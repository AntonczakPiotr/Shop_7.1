using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    //[Table("Produkty")]
    public class Product : IEntity
    {
        //[Key]
        //public int ProductId { get; set; }

        [Required]
        [MaxLength(60), MinLength(3)]
        //[Column("Nazwa")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}