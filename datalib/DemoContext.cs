using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using datalib.DbSets;

namespace datalib
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }

}
