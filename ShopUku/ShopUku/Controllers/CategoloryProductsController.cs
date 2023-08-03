using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoloryProductsController : ControllerBase
    {
        private readonly CategoryProductService _categoryProductService;
        public CategoloryProductsController(CategoryProductService categoryProductService)
        {
            _categoryProductService = categoryProductService;
        }

        [HttpGet]
        public List<CategoryProduct> GetCaPro()
        {
            return _categoryProductService.GetCatePro();
        }

        [HttpGet("{CateId}")]
        public List<CategoryProduct> GetCaProCateId(int CateId)
        {
            return _categoryProductService.GetCateProCateId(CateId);
        }
    }
}
