using FSM_Application.Catalog.OrderCatalog;
using FSM_ViewModel.OrderViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM_BackendAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var orders = await _orderServices.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _orderServices.GetAllOrderById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedOrder([FromForm] CreateOrder createOrder)
        {
            var result = await _orderServices.CreateOrder(createOrder);

            if (result == null)
                return BadRequest();

            var orderNew = await _orderServices.GetAllOrderById(result);

            return CreatedAtAction(nameof(GetOrderById), new { id = result }, orderNew);
        }
    }
}
