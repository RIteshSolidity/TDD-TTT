using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Models;

namespace CustomerApplication.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private customerdbContext _context;
        public CustomerRepository(customerdbContext context)
        {
            _context = context;
        }

        public bool DeleteCustomer(int customerid)
        {
            Customers cust = GetSingleCustomer(customerid);
            _context.Remove(cust);
            _context.SaveChanges();           
            return true;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
           return _context.Customers.ToList();
        }

        public Customers GetSingleCustomer(int Customerid)
        {
          return  _context.Customers.Where((x) => x.CustomerId == Customerid).FirstOrDefault();
        }

        public  async Task<Customers> InsertCustomer(Customers customer)
        {
           await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer; 
        }

        public Customers UpdateCustomer(Customers customer)
        {
            int custid = customer.CustomerId;
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            Customers cust = GetSingleCustomer(custid);
            return cust;
        }
    }
}
