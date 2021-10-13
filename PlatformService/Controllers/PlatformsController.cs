using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using System;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");
            var platformItens = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItens));
        }

        [HttpGet("{id}")]
        public ActionResult<PlatformReadDto> GetPlatform(int id)
        {
            Console.WriteLine("--> Getting Platform...");
            var platformItens = _repository.GetPlatformById(id);

            if(platformItens != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItens));
            }

            return NotFound();
        }
    }
}