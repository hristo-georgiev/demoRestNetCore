using System;
using System.Collections.Generic;
using System.Text;

namespace datalib.DbSets
{
    
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FamilyName { get; set; }
        public DateTime CDate { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
