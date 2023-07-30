using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Products> GetAllProducts(int? page)
        {
            return _productRepository.GetAll(page);
        }

        public Products GetProductsById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Products CreateProducts(Products model)
        {
            return _productRepository.Create(model);
        }

        public Products UpdateProducts(int id, Products model)
        {
            var result = _productRepository.Update(id, model);
            return result;
        }

        public string RemoveProducts(int id)
        {
            var result = _productRepository.Delete(id);
            return result;
        }
    }
}
