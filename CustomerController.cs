using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Models;
using CustomerApplication.Repository;

namespace CustomerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return _repo.GetAllCustomers();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customers Get(int id)
        {
            return _repo.GetSingleCustomer(id);
        }

        // POST: api/Customer
        [HttpPost]
        public Customers Post([FromBody] Customers value)
        {
            return _repo.InsertCustomer(value);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public Customers Put([FromBody] Customers value)
        {
            return _repo.UpdateCustomer(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _repo.DeleteCustomer(id);
        }
    }
}
