using AutoMapper;
using FSM_Application.Repository;
using FSM_Data.Entities;
using FSM_ViewModel.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Application.Catalog.OrderCatalog
{
    public class OrderServices : IOrderServices
    {
        private readonly IMapper _mapper;
        private readonly IAllRepositorys<Order> _orderRepositorys;
        public OrderServices(IMapper mapper, IAllRepositorys<Order> orderRepositorys)
        {
            _mapper = mapper;
            _orderRepositorys = orderRepositorys;
        }

        public async Task<Guid> CreateOrder(CreateOrder createOrder)
        {
            var order = _mapper.Map<CreateOrder,Order>(createOrder);
            order.CreatedAt = DateTime.Now;
            order.Status = FSM_Data.Enum.Status.Active;
            order.IsDeleted = true;

            order.OrderDetails = new List<OrderDetail>()
            {
                new OrderDetail()
                {
                    ProductId = createOrder.ProductId,
                    Quantity = createOrder.Quantity,
                    Price = createOrder.Price,
                }
            };
            var addOrder = await _orderRepositorys.AddItems(order);
            return order.Id;
        }

        public async Task<GetAllOrder> GetAllOrderById(Guid id)
        {
            var order = await _orderRepositorys.GetItemsById(id);
            var result = _mapper.Map<Order, GetAllOrder>(order);
            return result;
        }

        public async Task<IEnumerable<GetAllOrder>> GetAllOrders()
        {
            var orders = await _orderRepositorys.GetAllItems();
            var result = _mapper.Map<IEnumerable<Order>, IEnumerable<GetAllOrder>>(orders);
            return result;
        }
    }
}
