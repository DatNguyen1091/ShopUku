using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class BrandService
    {
        private readonly BrandsRepository _brandsRepository;
        public BrandService(BrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        public List<Brands> GetAllBrands(int? page)
        {
            return _brandsRepository.GetAll(page);
        }

        public Brands GetBrandsById(int id)
        {
            return _brandsRepository.GetById(id);
        }

        public Brands CreateBrands(Brands model)
        {
            return _brandsRepository.Create(model);
        }

        public Brands UpdateBrands(int id, Brands model)
        {
            var result = _brandsRepository.Update(id, model);
            return result;
        }

        public string RemoveBrands(int id)
        {
            var result = _brandsRepository.Delete(id);
            return result;
        }
    }
}
