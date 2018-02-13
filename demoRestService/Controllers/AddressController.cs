﻿using System;
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
    public class AddressController : Controller
    {
        private readonly ILogger _log;
        private readonly IAddressRepository _adrRepo;
        public AddressController(ILogger<AddressController> logger, IAddressRepository adrRepo)
        {
            _log = logger;
            _adrRepo = adrRepo;
        }

        [HttpGet]
        public AddressDto Get(int id)
        {
            var data = _adrRepo.GetSingle(id);
            return Mapper.Map<AddressDto>(data);
        }

        /* http://localhost:49822/api/address/getbycustomer?id=1 */
        [HttpGet]
        public AddressDto GetByCustomer(int id)
        {
            var data = _adrRepo.FindByCustomer(id);
            return Mapper.Map<AddressDto>(data);
        }
    }
}