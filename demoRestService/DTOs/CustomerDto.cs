using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoRestService.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FamilyName { get; set; }
    }
}
