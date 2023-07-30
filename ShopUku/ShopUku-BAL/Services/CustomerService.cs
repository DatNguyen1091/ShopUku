using ShopUku_DAL.Model;
using ShopUku_DAL.Repository;

namespace ShopUku_BAL.Services
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customers> GetAllCustomers(int? page)
        {
            return _customerRepository.GetAll(page);
        }

        public Customers GetCustomersById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customers CreateCustomers(Customers model)
        {
            return _customerRepository.Create(model);
        }

        public Customers UpdateCustomers(int id, Customers model)
        {
            var result = _customerRepository.Update(id, model);
            return result;
        }

        public string RemoveCustomers(int id)
        {
            var result = _customerRepository.Delete(id);
            return result;
        }
    }
}
