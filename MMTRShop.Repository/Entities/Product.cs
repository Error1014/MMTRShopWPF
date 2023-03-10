using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        public int CountInStarage { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }
        public virtual List<CartItem>? CartItem { get; set; }

        public virtual List<OrderContent>? Content { get; set; }
        public virtual List<Feedback>? Feedback { get; set; }

    }
}
