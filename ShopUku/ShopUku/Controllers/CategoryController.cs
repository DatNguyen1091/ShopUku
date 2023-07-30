using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Categories> GetCategories(int? page)
        {
            return _categoryService.GetAllCategories(page);
        }

        [HttpGet("{id}")]
        public Categories GetCategoriesId(int id)
        {
            return _categoryService.GetCategoriesById(id);
        }

        [HttpPost]
        public Categories PostCategories(Categories model)
        {
            return _categoryService.CreateCategories(model);
        }

        [HttpPut("{id}")]
        public Categories PutCategories(int id, Categories model)
        {
            return _categoryService.UpdateCategories(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteCategories(int id)
        {
            return _categoryService.RemoveCategories(id);
        }
    }
}
