using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using datalib.DbSets;

namespace datalib
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<Customer> FindByName(string name);
        Customer Create(Customer customer);
    }

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DemoContext _db;
        private readonly ILogger _log;
        public CustomerRepository(DemoContext dbContext, ILogger<CustomerRepository> logger) : base(dbContext)
        {
            _db = dbContext;
            _log = logger;
        }

        public new Customer GetSingle(int id)
        {
            return _db.Set<Customer>().FirstOrDefault(x => x.Id == id);           
        }

        public IEnumerable<Customer> FindByName(string name)
        {            
            return _db.Customers.Where(c => c.FamilyName == name).ToList();
        }

        public Customer Create(Customer customer)
        {
            try
            {
                customer.CDate = DateTime.Now;
                return _db.Customers.Add(customer).Entity;         
            }
            catch (Exception e)
            {
                _log.LogError(e, "Can not create new User!");
                throw e;
            }
        }
    }
}
