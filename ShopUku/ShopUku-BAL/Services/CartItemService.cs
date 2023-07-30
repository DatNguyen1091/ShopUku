using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class CartItemService
    {
        private CartItemRepository _cartItemRepository;
        public CartItemService(CartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public List<CartItems> GetAllCartItems(int? page)
        {
            return _cartItemRepository.GetAll(page);
        }

        public CartItems GetCartItemsById(int id)
        {
            return _cartItemRepository.GetById(id);
        }

        public CartItems CreateCartItems(CartItems model)
        {
            return _cartItemRepository.Create(model);
        }

        public CartItems UpdateCartItems(int id, CartItems model)
        {
            var result = _cartItemRepository.Update(id, model);
            return result;
        }

        public string RemoveCartItems(int id)
        {
            var result = _cartItemRepository.Delete(id);
            return result;
        }
    }
}
