using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Categories> GetAllCategories(int? page)
        {
            return _categoryRepository.GetAll(page);
        }

        public Categories GetCategoriesById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Categories CreateCategories(Categories model)
        {
            return _categoryRepository.Create(model);
        }

        public Categories UpdateCategories(int id, Categories model)
        {
            var result = _categoryRepository.Update(id, model);
            return result;
        }

        public string RemoveCategories(int id)
        {
            var result = _categoryRepository.Delete(id);
            return result;
        }
    }
}
