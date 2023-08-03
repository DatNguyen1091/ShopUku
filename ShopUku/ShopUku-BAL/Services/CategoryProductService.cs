using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class CategoryProductService
    {
        private CategoryProductRepository _categoryProductRepository;

        public CategoryProductService(CategoryProductRepository categoryProductRepository)
        {
            _categoryProductRepository = categoryProductRepository;
        }

        public List<CategoryProduct> GetCatePro()
        {
            return _categoryProductRepository.GetCategoryProduct();
        }

        public List<CategoryProduct> GetCateProCateId(int CateId)
        {
            return _categoryProductRepository.GetCategoryProductByCateId(CateId);
        }

    }
}
