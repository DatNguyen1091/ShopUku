using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _cartItemService;
        public CartItemController(CartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public List<CartItems> GetCartItems(int? page)
        {
            return _cartItemService.GetAllCartItems(page);
        }

        [HttpGet("{id}")]
        public CartItems GetCartItemsId(int id)
        {
            return _cartItemService.GetCartItemsById(id);
        }

        [HttpPost]
        public CartItems PostCartItems(CartItems model)
        {
            return _cartItemService.CreateCartItems(model);
        }

        [HttpPut("{id}")]
        public CartItems PutCartItems(int id, CartItems model)
        {
            return _cartItemService.UpdateCartItems(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteCartItems(int id)
        {
            return _cartItemService.RemoveCartItems(id);
        }
    }
}
