using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
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
		public async Task Create([FromBody] CreateOwnerDTO dto)
		{
			await _validator.ValidateAndThrowAsync(dto);
			var owner = _mapper.Map<Owner>(dto);
			await _service.Create(owner);
		}

		[HttpGet("{id:int}")]
		public async Task<OwnerDTO> Get([FromRoute] int id)
		{
			var owner = await _service.GetById(id);
			return _mapper.Map<OwnerDTO>(owner);
		}

		[HttpPost("{ownerId:int}/[action]/{vehicleId:int}")]
		public async Task InitialBindVehicle([FromRoute] int ownerId, [FromRoute] int vehicleId)
		{
			await _service.OwnVehicle(ownerId, vehicleId);
		}


		[HttpGet("{ownerId:int}/[action]")]
		public async Task<List<VehicleDTO>> GetBindedVehicles([FromRoute] int ownerId)
		{
			var listOfBindedVehicles = await _service.GetVehicles(ownerId);
			return _mapper.Map<List<VehicleDTO>>(listOfBindedVehicles);
		}

		[HttpGet("{ownerId:int}/[action]")]
		public async Task<List<AppointmentDTO>> GetAppointments([FromRoute] int ownerId)
		{
			var listOfAppointments = await _service.GetAppointments(ownerId);
			return _mapper.Map<List<AppointmentDTO>>(listOfAppointments);
		}

		[HttpGet("{onwerId:int}/[action]/{appointmentId:int}")]
		public async Task<AppointmentDTO> GetAppointmentById([FromRoute] int ownerId, [FromRoute] int appointmentId)
		{
			var appointment = await _service.GetAppointmentByAppointmentId(ownerId, appointmentId);
			return _mapper.Map<AppointmentDTO>(appointment);
		}








	}
}
