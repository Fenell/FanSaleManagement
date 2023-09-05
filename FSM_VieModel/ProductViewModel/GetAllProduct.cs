using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_ViewModel.ProductViewModel
{
    public class GetAllProduct
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
    }
}
