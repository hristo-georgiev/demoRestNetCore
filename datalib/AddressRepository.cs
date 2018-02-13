using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Linq;
using datalib.DbSets;

namespace datalib
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Address FindByCustomer(int customerId);        
    }

    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly DemoContext _db;
        private readonly ILogger _log;

        public AddressRepository(DemoContext dbContext, ILogger<AddressRepository> logger) : base(dbContext)
        {
            _db = dbContext;
            _log = logger;
        }

        public new Address GetSingle(int id)
        {
            return _db.Set<Address>().FirstOrDefault(x => x.Id == id);
        }    

        public Address FindByCustomer(int customerId)
        {
           return _db.Addresses.Where(a => a.CustomerId == customerId).SingleOrDefault();
        }
    }
}
