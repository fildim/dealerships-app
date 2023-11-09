using AutoMapper;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.DTOS.Vehicle;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DEALERSHIPS_APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOwnerDTO> _validator;

        public OwnerController(IOwnerService service, IMapper mapper, IValidator<CreateOwnerDTO> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }



        [HttpPost]
        public async Task Create([FromBody]CreateOwnerDTO dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var owner = _mapper.Map<Owner>(dto);
            await _service.Create(owner);
        }

        [HttpGet("{id:int}")]
        public async Task<ReadOnlyOwnerDTO> Get([FromRoute]int id)
        {
            var owner = await _service.GetById(id);
            return _mapper.Map<ReadOnlyOwnerDTO>(owner);
        }

        [HttpPost("{ownerId:int}/[action]/{vehicleId:int}")]
        public async Task InitialBindVehicle([FromRoute]int ownerId, [FromRoute]int vehicleId)
        {
            await _service.InitialBindVehicle(ownerId, vehicleId);
        }


        [HttpGet("{ownerId:int}/[action]")]
        public async Task<List<ReadOnlyVehicleDTO>> GetBindedVehicles([FromRoute]int ownerId)
        {
            var listOfBindedVehicles = await _service.GetBindedVehicles(ownerId);
            return _mapper.Map<List<ReadOnlyVehicleDTO>>(listOfBindedVehicles);
        }








    }
}
