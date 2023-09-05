using FSM_Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_ViewModel.OrderViewModel
{
    public class CreateOrder
    {
        public Guid ProductId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
