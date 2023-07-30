using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandService _brandService;
        public BrandsController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public List<Brands> GetBrands(int? page)
        {
            return _brandService.GetAllBrands(page);
        }

        [HttpGet("{id}")]
        public Brands GetBrandsId(int id)
        {
            return _brandService.GetBrandsById(id);
        }

        [HttpPost]
        public Brands PostBrands(Brands model)
        {
            return _brandService.CreateBrands(model);
        }

        [HttpPut("{id}")]
        public Brands PutBrands(int id, Brands model)
        {
            return _brandService.UpdateBrands(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteBrands(int id)
        {
            return _brandService.RemoveBrands(id);
        }
    }
}
