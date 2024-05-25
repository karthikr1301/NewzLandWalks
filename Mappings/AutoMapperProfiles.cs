using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nzd.api.Models.Domains;
using Nzd.api.Models.Dtos;

namespace Nzd.api.Mappings
{
    public class profileMappers :Profile
    {
        public profileMappers()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();

        }
        
    }
}