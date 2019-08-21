using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Models;

namespace CustomerApplication.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomers();

        Customers GetSingleCustomer(int Customerid);

        Customers InsertCustomer(Customers customer);

        Customers UpdateCustomer(Customers customer);

        bool DeleteCustomer(int customerid);
    }
}
