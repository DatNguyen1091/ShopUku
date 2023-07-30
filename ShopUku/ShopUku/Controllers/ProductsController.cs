using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Products> GetProducts(int? page)
        {
            return _productService.GetAllProducts(page);
        }

        [HttpGet("{id}")]
        [Authorize]
        public Products GetProductsId(int id)
        {
            return _productService.GetProductsById(id);
        }

        [HttpPost]
        public Products PostProducts(Products model)
        {
            return _productService.CreateProducts(model);
        }

        [HttpPut("{id}")]
        public Products PutProducts(int id, Products model)
        {
            return _productService.UpdateProducts(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteProducts(int id)
        {
            return _productService.RemoveProducts(id);
        }
    }
}
