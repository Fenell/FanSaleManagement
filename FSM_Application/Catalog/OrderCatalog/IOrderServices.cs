using FSM_ViewModel.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.OrderCatalog
{
    public interface IOrderServices
    {
        Task<IEnumerable<GetAllOrder>> GetAllOrders();
        Task<GetAllOrder> GetAllOrderById(Guid id);
        Task<Guid> CreateOrder(CreateOrder createOrder);
    }
}
