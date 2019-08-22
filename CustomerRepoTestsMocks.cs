using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CustomerApplication.Models;
using CustomerApplication.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace XUnitTestProject1
{
    public class CustomerRepoTests
    {

        private IEnumerable<Customers> GetMyCustomers()
        {
            return new List<Customers> {
                new Customers(){ CustomerAge = 1, CustomerId = 1, CustomerName = "abc" , EmailId="abc@abc.com" },
                new Customers(){ CustomerAge = 2, CustomerId = 2, CustomerName = "xyz" , EmailId="xyz@xyz.com" },
            };
        }

        [Fact]
        public async Task InsertCutomerTest() {
            // arrange
            Customers cust = (GetMyCustomers() as List<Customers>)[0];

            Mock<DbSet<Customers>> _custs = new Mock<DbSet<Customers>>(MockBehavior.Strict);
            Mock<customerdbContext> _dbcontext = new Mock<customerdbContext>();
            _dbcontext.Setup(x => x.Customers).Returns(_custs.Object);
            _custs.Setup(y => y.AddAsync(cust, CancellationToken.None)).Returns(Task.FromResult(_dbcontext.Object.Entry(cust)));


            // act
            CustomerRepository rep = new CustomerRepository(_dbcontext.Object);
            Customers newCust = await rep.InsertCustomer(cust);

            //Assert
            Assert.Equal("abc", newCust.CustomerName);
            _custs.Verify(x => x.AddAsync(cust,CancellationToken.None));
            _dbcontext.Verify(y => y.SaveChangesAsync(CancellationToken.None));
            
        }
    }
}
