using Microsoft.AspNetCore.Mvc;
using ShopUku_BAL.Services;
using ShopUku_DAL.Model;

namespace ShopUku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<Customers> GetCustomers(int? page)
        {
            return _customerService.GetAllCustomers(page);
        }

        [HttpGet("{id}")]
        public Customers GetCustomersId(int id)
        {
            return _customerService.GetCustomersById(id);
        }

        [HttpPost]
        public Customers PostCustomers(Customers model)
        {
            return _customerService.CreateCustomers(model);
        }

        [HttpPut("{id}")]
        public Customers PutCustomers(int id, Customers model)
        {
            return _customerService.UpdateCustomers(id, model);
        }

        [HttpDelete("{id}")]
        public string DeleteCustomers(int id)
        {
            return _customerService.RemoveCustomers(id);
        }
    }
}
