using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nzd.api.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Nzd.api.Data;
using Nzd.api.Models.Dtos;
using Nzd.api.Repository;
using AutoMapper;


namespace Nzd.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly RkvWalkContext dbContext;

        private readonly IRegionRepository _regionRepository;

        private readonly IMapper _mapper;

        public RegionController(RkvWalkContext dbContext, IRegionRepository regionRepository,
         IMapper mapper)
        {
            this.dbContext=dbContext;
            _regionRepository=regionRepository;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database -Domain Models
            var regionsDomain= await _regionRepository.GetAllAsync();

            //Map domain models to dtots

            // var regionsDto=new List<RegionDto>();
            // foreach (var regionDomain in regionsDomain)
            // {
            //     regionsDto.Add(new RegionDto
            //     {
            //         Id=regionDomain.Id,
            //         Name=regionDomain.Name,
            //         Code=regionDomain.Code,
            //         RegionImageUrl=regionDomain.RegionImageUrl
            //     });
            // }
            var regionsDto= _mapper.Map<List<RegionDto>>(regionsDomain);
                

            //return dtos

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain= await _regionRepository.GetByIdAsync(id);
            if(regionDomain==null)
            {
                return NotFound();
            }
            // var regionDto=new RegionDto()
            // {
            //     Id=regionDomain.Id,
            //     Name=regionDomain.Name,
            //     Code=regionDomain.Code,
            //     RegionImageUrl=regionDomain.RegionImageUrl
            // };
            var regionDto=_mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDto addregionrequestdto)
        {
            //dto to domain model
            // var regionDomainModel=new Region
            // {
            //     Name=addregionrequestdto.Name,
            //     Code=addregionrequestdto.Code,
            //     RegionImageUrl=addregionrequestdto.RegionImageUrl
            // };
            var regionDomainModel=_mapper.Map<Region>(addregionrequestdto);
            //save in the reions
            regionDomainModel=await _regionRepository.CreateAsync(regionDomainModel);
            
            

            //map daomain model back to dto
            // var regionDto = new RegionDto
            // {
            //     Id=regionDomainModel.Id,
            //     Name=regionDomainModel.Name,
            //     Code=regionDomainModel.Code,
            //     RegionImageUrl=regionDomainModel.RegionImageUrl

            // };
            var regionDto=_mapper.Map<RegionDto>(regionDomainModel);
            return CreatedAtAction(nameof( GetById),new {id=regionDomainModel.Id}, regionDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateRegionRequestDto updateregionrequesdto)
        {
            //dto to domain model
            // var regionDomainModel = new Region
            // {
            //     Code= updateregionrequesdto.Code,
            //     Name= updateregionrequesdto.Name,
            //     RegionImageUrl= updateregionrequesdto.RegionImageUrl
            // };
            var regionDomainModel = _mapper.Map<Region>(updateregionrequesdto);

            regionDomainModel=await _regionRepository.UpdateAsync(id,regionDomainModel);

            if(regionDomainModel==null)
            {
                return NotFound();
            }

            // map domain model to dto

            // var regionDto= new RegionDto
            // {
            //     Id=regionDomainModel.Id,
            //     Name=regionDomainModel.Name,
            //     Code=regionDomainModel.Code,
            //     RegionImageUrl=regionDomainModel.RegionImageUrl
            // };
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel=await _regionRepository.DeleteAsync(id);
            if(regionDomainModel==null)
            {
                return NotFound();
            }
    
            // var regionDto= new RegionDto
            // {
            //     Id=regionDomainModel.Id,
            //     Name=regionDomainModel.Name,
            //     Code=regionDomainModel.Code,
            //     RegionImageUrl=regionDomainModel.RegionImageUrl
            // };
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);

        }


        /*[HttpGet]
        public IActionResult GetAll()
        {
            var region = new List<Region>{
                new Region{
                    Id = Guid.NewGuid(), 
                    Name = "North Island", 
                    Code = "146",
                    RegionImageUrl="https://search.app.goo.gl/HkarDwk"},
                new Region{
                    Id = Guid.NewGuid(),
                    Name = "South Island",
                    Code ="64",
                 RegionImageUrl="https://search.app.goo.gl/3beNc2b"},
            };

            return Ok(region);
        }*/
       
        
        
    }
}