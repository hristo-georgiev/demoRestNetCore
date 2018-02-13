using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using datalib.DbSets;
using demoRestService.DTOs;

namespace demoRestService.Mapping
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
