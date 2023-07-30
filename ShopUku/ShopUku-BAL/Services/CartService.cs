using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class CartService
    {
        private CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public List<Carts> GetAllCarts(int? page)
        {
            return _cartRepository.GetAll(page);
        }

        public Carts GetCartsById(int id)
        {
            return _cartRepository.GetById(id);
        }

        public Carts CreateCarts(Carts model)
        {
            return _cartRepository.Create(model);
        }

        public Carts UpdateCarts(int id, Carts model)
        {
            var result = _cartRepository.Update(id, model);
            return result;
        }

        public string RemoveCarts(int id)
        {
            var result = _cartRepository.Delete(id);
            return result;
        }
    }
}
