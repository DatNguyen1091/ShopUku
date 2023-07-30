using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<Orders> GetOrder(int? page)
        {
            return _orderService.GetAllOrder(page);
        }

        [HttpGet("{id}")]
        public Orders GetOrderId(int id)
        {
            return _orderService.GetOrderById(id);
        }

        [HttpPost]
        public Orders PostOrder(Orders model)
        {
            return _orderService.CreateOrder(model);
        }

        [HttpPut("{id}")]
        public Orders PutOrder(int id, Orders model)
        {
            return _orderService.UpdateOrder(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteOrder(int id)
        {
            return _orderService.RemoveOrder(id);
        }
    }
}
