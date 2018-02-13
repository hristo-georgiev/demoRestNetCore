using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoRestService.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
    }
}
