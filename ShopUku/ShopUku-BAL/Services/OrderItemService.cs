using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class OrderItemService
    {
        private OrderItemRepository _orderItemRepository;

        public OrderItemService(OrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public List<OrderItems> GetAllOrderItems(int? page)
        {
            return _orderItemRepository.GetAll(page);
        }

        public OrderItems GetOrderItemsById(int id)
        {
            return _orderItemRepository.GetById(id);
        }

        public OrderItems CreateOrderItems(OrderItems model)
        {
            return _orderItemRepository.Create(model);
        }

        public OrderItems UpdateOrderItems(int id, OrderItems model)
        {
            var result = _orderItemRepository.Update(id, model);
            return result;
        }

        public string RemoveOrderItems(int id)
        {
            var result = _orderItemRepository.Delete(id);
            return result;
        }
    }
}
