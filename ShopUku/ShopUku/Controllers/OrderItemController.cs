using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemService _orderItemService;

        public OrderItemController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public List<OrderItems> GetOrderItems(int? page)
        {
            return _orderItemService.GetAllOrderItems(page);
        }

        [HttpGet("{id}")]
        public OrderItems GetOrderItemsId(int id)
        {
            return _orderItemService.GetOrderItemsById(id);
        }

        [HttpPost]
        public OrderItems PostOrderItems(OrderItems model)
        {
            return _orderItemService.CreateOrderItems(model);
        }

        [HttpPut("{id}")]
        public OrderItems PutOrderItems(int id, OrderItems model)
        {
            return _orderItemService.UpdateOrderItems(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteOrderItems(int id)
        {
            return _orderItemService.RemoveOrderItems(id);
        }
    }
}
