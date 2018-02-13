using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using datalib;
using datalib.DbSets;
using AutoMapper;
using demoRestService.DTOs;

namespace demoRestService.Controllers
{
    [Route("api/[controller]/[action]")]    
    public class CustomerController : Controller
    {
        private readonly ILogger _log;
        private readonly ICustomerRepository _custRepo;
        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository custRepo)
        {
            _log = logger;
            _custRepo = custRepo;
        }
       
        [HttpGet]
        //[Route("{id?}", Name = "Get")]
        public CustomerDto Get(int id)
        {
            var cust = _custRepo.GetSingle(id);
            return Mapper.Map<CustomerDto>(cust);
        }
       
        [HttpGet]
        //[Route("{name?}", Name = "FindCustomer")]        
        public IEnumerable<CustomerDto> FindCustomer(string name)
        {
            return Mapper.Map <List<CustomerDto>>(_custRepo.FindByName(name));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CustomerDto customer)
        {
            try
            {
                var newcust = _custRepo.Create(Mapper.Map<Customer>(customer));
                _custRepo.Commit();
                CreatedAtRouteResult result = CreatedAtRoute( new { controller = "Customer", id = newcust.Id }, Mapper.Map<CustomerDto>(newcust));
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CustomerDto customer)
        {
            var dbcust = _custRepo.GetSingle(id);
            if (dbcust == null) return NotFound();
            Mapper.Map<CustomerDto, Customer>(customer, dbcust);
            _custRepo.Update(dbcust);
            _custRepo.Commit();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbcust = _custRepo.GetSingle(id);
            if (dbcust == null) return NotFound();            
            _custRepo.Delete(dbcust);
            _custRepo.Commit();
            return NoContent();
        }
    }
}