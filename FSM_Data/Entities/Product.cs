using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Data.Entities
{
    [Table("Product")]
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Brand Brands { get; set; }
        public virtual Category Categorys { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
