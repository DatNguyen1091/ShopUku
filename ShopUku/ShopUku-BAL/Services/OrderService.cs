using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class OrderService
    {
        private OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Orders> GetAllOrder(int? page)
        {
            return _orderRepository.GetAll(page);
        }

        public Orders GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Orders CreateOrder(Orders model)
        {
            return _orderRepository.Create(model);
        }

        public Orders UpdateOrder(int id, Orders model)
        {
            var result = _orderRepository.Update(id, model);
            return result;
        }

        public string RemoveOrder(int id)
        {
            var result = _orderRepository.Delete(id);
            return result;
        }
    }
}
