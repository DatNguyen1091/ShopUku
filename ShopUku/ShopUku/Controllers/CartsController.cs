using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartsController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public List<Carts> GetCarts(int? page)
        {
            return _cartService.GetAllCarts(page);
        }

        [HttpGet("{id}")]
        public Carts GetCartsId(int id)
        {
            return _cartService.GetCartsById(id);
        }

        [HttpPost]
        public Carts PostCarts(Carts model)
        {
            return _cartService.CreateCarts(model);
        }

        [HttpPut("{id}")]
        public Carts PutCarts(int id, Carts model)
        {
            return _cartService.UpdateCarts(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteCarts(int id)
        {
            return _cartService.RemoveCarts(id);
        }
    }
}
