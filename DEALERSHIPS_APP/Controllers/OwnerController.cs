using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.DTOS.Vehicle;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEALERSHIPS_APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	[Authorize]
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


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody]LoginOwnerDTO login)
        {
            return await _service.Login(login.Phone, login.Password);
        }


        [HttpPost]
        [AllowAnonymous]
		public async Task Create([FromBody]CreateOwnerDTO dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var owner = _mapper.Map<Owner>(dto);
            await _service.Create(owner, dto.Password);
        }

        [HttpGet("{id:int}")]
        public async Task<ReadOnlyOwnerDTO> Get([FromRoute]int id)
        {
            var owner = await _service.GetById(id);

            return _mapper.Map<ReadOnlyOwnerDTO>(owner);
        }

        [HttpPost("{id:int}/[action]/{vehicleId:int}")]
        public async Task InitialBindVehicle([FromRoute]int id, [FromRoute]int vehicleId)
        {
            await _service.InitialBindVehicle(id, vehicleId);
        }


        [HttpGet("{id:int}/[action]")]
        public async Task<List<ReadOnlyVehicleDTO>> GetBindedVehicles([FromRoute]int id)
        {
            var listOfBindedVehicles = await _service.GetBindedVehicles(id);

            return _mapper.Map<List<ReadOnlyVehicleDTO>>(listOfBindedVehicles);
        }

        [HttpGet("{id:int}/[action]")]
        public async Task<List<ReadOnlyAppointmentDTO>> GetAppointments([FromRoute]int id)
        {
            var listOfAppointments = await _service.GetAllAppointmentsById(id);

            return _mapper.Map<List<ReadOnlyAppointmentDTO>>(listOfAppointments);
        }

        [HttpGet("{id:int}/[action]/{appointmentId:int}")]
        public async Task<ReadOnlyAppointmentDTO> GetAppointmentByAppointmentId([FromRoute] int id, [FromRoute] int appointmentId)
        {
            var appointment = await _service.GetAppointmentByAppointmentId(id, appointmentId);
            return _mapper.Map<ReadOnlyAppointmentDTO>(appointment);
        }








    }
}
