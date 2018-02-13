using System;
using System.Collections.Generic;
using System.Text;

namespace datalib.DbSets
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public DateTime CDate { get; set; }
    }
}
